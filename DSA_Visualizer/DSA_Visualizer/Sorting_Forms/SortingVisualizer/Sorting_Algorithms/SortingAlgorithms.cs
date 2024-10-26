using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;

namespace DSA_Visualizer.Sorting_Forms.SortingVisualizer.Sorting_Algorithms
{

    public abstract class SortingAlgorithms
    {


        protected RectangleManger recManager;

        /* Pass this token to whichever functions need to be canclled*/
        protected CancellationTokenSource cancellationTokenSource; // Determiens if task should be cancelled
        private Label compareOutput;
        private Label swapOutput;


        private int totalComparisons;
        private int totalSwaps;

        protected int animationSpeed;
        private float animationSteps; // Dictates smoothness of animation
        private float offsetX;

        private bool isPaused;


        public SortingAlgorithms(RectangleManger recManager) {
            this.recManager = recManager;
            this.cancellationTokenSource = new CancellationTokenSource();

            this.totalComparisons = 0;
            this.totalSwaps = 0;

            this.animationSteps = 1f; // Frames
            this.animationSpeed = 300;

            this.offsetX = 10f;

            this.isPaused = false;
        }

        /* ====================== GETTERS & SETTERS ====================== */
        public Label CompareOutput { 
            set { this.compareOutput = value; }
        }

        public Label SwapOutput {
            set { this.swapOutput = value;  }
        }


        public int TotalComparisons { 
            get { return totalComparisons; }
            set { totalComparisons = value; }
        }

        public int TotalSwaps { 
            get{ return totalSwaps; }
            set { totalSwaps = value; }
        }

        public bool IsPaused
        {
            get { return this.isPaused; }
            set { this.isPaused = value; }
        }

        public void setAnimationSpeed(int val) { this.animationSpeed = val; }
        public void setOffsetX(float val) { this.offsetX = val; }

        public abstract Task sort(); // Abstract method to impelment


        /* ====================== PAUSE & TERMINATE SORTS ====================== */

        public async Task pauseSort() {
            while (isPaused) await Task.Delay(100); 
        }

        public void terminateSort() { 
            cancellationTokenSource.Cancel(); // Tells token to cancel any tasks associated with it
        }

        /* ====================== SWAPPING ====================== */
        public async Task swap(int i, int j)
        {

            await animateSwap(i, j);

            ColoredRectangle temp = recManager.Rectangles[i];
            recManager.Rectangles[i] = recManager.Rectangles[j];
            recManager.Rectangles[j] = temp;
            recManager.Panel.Invalidate();
        }

        /*
         * @brief Swap animation function
         * 
         * @details Use task.Delay to delate execution of lines after each x posiiton increment.
         * Rectangles gradually shift horizontally to their desired target positions
         * 
         * @param 
         *      1) int: index of first rectangle
         *      2) int: index of second rectangle
         */
        public async Task animateSwap(int i, int j) {
            if (this.IsPaused) await pauseSort(); // Pause animation if paused

            // Update swapping bool
            recManager.Rectangles[i].isSwapping = true;
            recManager.Rectangles[j].isSwapping = true;

            //Store original rectangles
            RectangleF rectI = recManager.Rectangles[i].rect;
            RectangleF rectJ = recManager.Rectangles[j].rect;

            // Claculate distance between two rectangles
            float distance = Math.Abs(rectJ.X - rectI.X);

            while (true) {
                if (cancellationTokenSource.IsCancellationRequested)
                {
                    recManager.Rectangles[i].isSwapping = false;
                    recManager.Rectangles[j].isSwapping = false;
                    recManager.deselectRec(i);
                    recManager.deselectRec(j);

                    return; // Exit out of function
                }

                if (this.IsPaused) await pauseSort(); // Pause sort if paused

                if (recManager.Rectangles[i].rect.X + offsetX < rectJ.X)
                {
                    recManager.Rectangles[i].rect = new RectangleF(
                        recManager.Rectangles[i].rect.X + offsetX,
                        rectI.Y,
                        rectI.Width,
                        rectI.Height
                    );
                }
                else {
                    // Snap rectangle to target position
                    recManager.Rectangles[i].rect = new RectangleF( 
                        rectJ.X,
                        rectI.Y,
                        rectI.Width,
                        rectI.Height
                    );
                }


                if (recManager.Rectangles[j].rect.X - offsetX > rectI.X)
                {
                    recManager.Rectangles[j].rect = new RectangleF(
                        recManager.Rectangles[j].rect.X - offsetX,
                        rectJ.Y,
                        rectJ.Width,
                        rectJ.Height
                    );
                }
                else {
                    // Snap rectangle to target position
                    recManager.Rectangles[j].rect = new RectangleF( 
                        rectI.X,
                        rectJ.Y,
                        rectJ.Width,
                        rectJ.Height
                    );
                }

                // Check if they arrived at target desitination
                if (recManager.Rectangles[i].rect.X >= rectJ.X && recManager.Rectangles[j].rect.X <= rectI.X) break;

                recManager.Panel.Invalidate(); // Redraw panel
                await Task.Delay(animationSpeed);
               

            }
            if (this.IsPaused) await pauseSort(); // Pause sort if paused

            // Unhighlight the swapped rectangles
            if (!(recManager.Rectangles[i].isSorted)) recManager.deselectRec(i);
            recManager.deselectRec(j);
           

            // Update swaping bools
            recManager.Rectangles[i].isSwapping = false;
            recManager.Rectangles[j].isSwapping = false;

            await Task.Delay((animationSpeed/2));
        }


        public async Task highlightAllGreen() {
            Color lightGreen = ColorTranslator.FromHtml("#3ade60");

            for (int i = 0; i < recManager.NumRectangles; i++) {
                if (cancellationTokenSource.IsCancellationRequested) return;
                recManager.selectRec(i, new SolidBrush(lightGreen));

                if (recManager.NumRectangles >= 500)
                {
                    await Task.Delay(1);
                }
                else
                {
                    await Task.Delay(5);
                }
            }
        }

        /* ====================== UPDATE OUTPUTS ====================== */
        public void updateCompare() {
            totalComparisons++;
            compareOutput.Text = totalComparisons.ToString();
        }

        public void updateSwap() {
            totalSwaps++;
            swapOutput.Text = totalSwaps.ToString();
        }

    }
}
