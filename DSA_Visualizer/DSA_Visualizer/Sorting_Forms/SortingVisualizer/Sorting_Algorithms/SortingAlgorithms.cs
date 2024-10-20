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
            this.animationSpeed = 2;

            this.offsetX = recManager.NumRectangles == 10 ? 10f : 1000f;

            //this.offsetX = 1000f;

            this.isPaused = false;
        }

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

        public void setAnimationSpeed(int val) { this.animationSpeed = val; }
        public void setOffsetX(float val) { this.offsetX = val; }

        public bool IsPaused { 
            get { return this.isPaused; }
            set { this.isPaused = value; }
        }

       

        /*
         * @brief Asynchronous pausing function
         * 
         * @details Delays program every 100ms,
         * then checks isPaused boolean flag
         * 
         */
        public async Task pauseSort() {
            while (isPaused) await Task.Delay(100);
        }

        public void terminateSort() { 
            cancellationTokenSource.Cancel(); // Tells token to cancel any tasks associated with it
        }

        public abstract Task sort(); // Abstract method to impelment

        /*
         * IMPORTANT KEYWORDS:
         *      Async: Allows use of await keyword, to allow delayed animations
         *      Task: Allows function to run asynchronously to Main UI Thread,
         *      allowing users to fidget with the other controls as this function runs in the 
         *      background.
         */

        /*
         * @brief Swap animation function
         * 
         * @details Use task.Delay to delate execution of lines after each x posiiton increment.
         * Rectangles gradually shift horizontally to their desired target positions
         * 
         * @param 
         *      i) int: index of first rectangle
         *      ii) int: index of second rectangle
         */
        public async Task animateSwap(int i, int j) {

            if (this.IsPaused) await pauseSort(); // Pause animation if paused

            // Update swapping bool
            recManager.Rectangles[i].isSwapping = true;
            recManager.Rectangles[j].isSwapping = true;

            //await Task.Delay((animationSpeed/2)); // Perform slight delay when hihglighting rectangles

            //Store original rectangles
            RectangleF rectI = recManager.Rectangles[i].rect;
            RectangleF rectJ = recManager.Rectangles[j].rect;

            // Claculate distance between two rectangles
            float distance = Math.Abs(rectJ.X - rectI.X);
            //float offsetX = distance / animationSteps; // Offset to incremet or decremt x positions
            //float offsetX = 200f;
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

        public async Task swap(int i, int j) {
            
            await animateSwap(i, j);
       
            ColoredRectangle temp = recManager.Rectangles[i];
            recManager.Rectangles[i] = recManager.Rectangles[j];
            recManager.Rectangles[j] = temp;
            recManager.Panel.Invalidate();


        }

        public async Task highlightAllGreen() {
            Color lightGreen = ColorTranslator.FromHtml("#3ade60");

            for (int i = 0; i < recManager.NumRectangles; i++) {
                recManager.selectRec(i, new SolidBrush(lightGreen));
                await Task.Delay(5);
            }

        }

        public void updateCompare() {
            totalComparisons++;
            compareOutput.Text = totalComparisons.ToString();
        }

        public void updateSwap() {
            TotalSwaps++;
            swapOutput.Text = totalSwaps.ToString();
        }



    }
}
