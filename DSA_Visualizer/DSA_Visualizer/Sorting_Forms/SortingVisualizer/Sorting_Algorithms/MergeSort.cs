using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Visualizer.Sorting_Forms.SortingVisualizer.Sorting_Algorithms
{
    public class MergeSort : SortingAlgorithms
    {

        public MergeSort(RectangleManger recManager) : base(recManager) { }


        public override async Task sort() {

            // Initialize original indexes
            for (int i = 0; i < recManager.NumRectangles; i++) recManager.Rectangles[i].originalIndex = i;
                    

            Console.Write("Before swap: ");
            recManager.printRectangleHeights();

            await mergeSort(recManager.Rectangles, 0, recManager.NumRectangles - 1);
      
            Console.Write("After swap: ");
            recManager.printRectangleHeights();
            
        }

      
     

        public async Task mergeSort(List<ColoredRectangle> list, int start, int end) {
            if (start >= end) return;
            if (this.IsPaused) await pauseSort(); // Pause sort if paused

            int mid = start + (end - start) / 2; // Find mid index



            // Split array in half
            cancellationTokenSource.Token.ThrowIfCancellationRequested();
            await highlightSection(start, mid, Brushes.Gray);
            await highlightSection(start, mid, Brushes.White); // Unhighlight
            await mergeSort(list, start, mid);

            if (this.IsPaused) await pauseSort(); // Pause sort if paused

            cancellationTokenSource.Token.ThrowIfCancellationRequested();
            await highlightSection(mid + 1, end, Brushes.Gray);
            await highlightSection(mid + 1, end, Brushes.White); // Unhighlight
            await mergeSort(list, mid + 1, end);
            

            // Merge two subarrays in their sorted positions
            await merge(list, start, mid, end);
        }

        public async Task merge(List<ColoredRectangle> list, int start, int mid, int end)
        {
            cancellationTokenSource.Token.ThrowIfCancellationRequested();
            if (this.IsPaused) await pauseSort(); // Pause sort if paused

            // Highlight over the area we are merging
            await highlightSection(start, end, Brushes.Red);


            int leftListLength = mid - start + 1; // 5 [_, _, _, _, _]
            int rightListLength = end - mid; // 4 [_, _, _, _]

            List<ColoredRectangle> leftList = new List<ColoredRectangle>();
            List<ColoredRectangle> rightList = new List<ColoredRectangle>();

            // Populate two subarrays

            for (int leftIdx = 0; leftIdx < leftListLength; leftIdx++) leftList.Add(list[start + leftIdx]);
            for (int rightIdx = 0; rightIdx < rightListLength; rightIdx++) rightList.Add(list[mid + 1 + rightIdx]);


            // Compare values in both the lists and merge values back to original list
            int i, j, k;
            i = j = 0;
            k = start;

            // List to execute all tasks
            List<Task> moveTasks = new List<Task>();
            while (i < leftListLength && j < rightListLength)
            {
                cancellationTokenSource.Token.ThrowIfCancellationRequested();
                if (this.IsPaused) await pauseSort(); // Pause sort if paused
                if (leftList[i].rect.Height < rightList[j].rect.Height)
                {
                    
                    moveTasks.Add(moveRectangle(leftList[i], k));
                    list[k] = leftList[i];
                    i++;
                }
                else
                {
                   
                    moveTasks.Add(moveRectangle(rightList[j], k));
                    list[k] = rightList[j];
                    j++;
                }
                k++;
            }

            // Insert remaining values
            while (i < leftListLength)
            {
                cancellationTokenSource.Token.ThrowIfCancellationRequested();
                if (this.IsPaused) await pauseSort(); // Pause sort if paused
                Console.WriteLine("Moving i(2): " + leftList[i].originalIndex + " to k: " + k);
                moveTasks.Add(moveRectangle(leftList[i], k));
                list[k] = leftList[i];
                i++;
                k++;
            }

            while (j < rightListLength)
            {
                cancellationTokenSource.Token.ThrowIfCancellationRequested();
                if (this.IsPaused) await pauseSort(); // Pause sort if paused
                Console.WriteLine("Moving j(2): " + rightList[j].originalIndex + " to k: " + k);
                moveTasks.Add(moveRectangle(rightList[j], k));
                list[k] = rightList[j];
                j++;
                k++;
            }

            
            // Execute all tasks simultaneously
            await Task.WhenAll(moveTasks);
            await placeBack(list, start, end);
            await highlightSection(start, end, Brushes.White);
            
            
        }

        // Move rectangle i underneath j's position
        public async Task moveRectangle(ColoredRectangle rectI, int j)
        {
            float finalX = recManager.Width * j;
            float finalY = recManager.Panel.Height - rectI.rect.Height;

            // If small amount of rectangles or animationSpeed is slow -> slow down animation speed
            // 
            if (recManager.NumRectangles < 250 || animationSpeed != 2)
            {
                await animateMoveRectangle(rectI, finalX, finalY);
            }
            else { // Skip animation and update position immediately
                finalY += rectI.rect.Height;
                rectI.rect = new RectangleF(finalX, finalY, rectI.rect.Width, rectI.rect.Height);
                recManager.Panel.Invalidate();
            }
                
        }

        // Place back into original positions
        public async Task placeBack(List<ColoredRectangle> list, int start, int end) {
            List<Task> moveTasks = new List<Task>();    

            // Move rectangles back to their original position
            for (int i = start; i <= end; i++) {
                float finalX = list[i].rect.X;
                float finalY = recManager.PanelCurrHeight - list[i].rect.Height; 

                moveTasks.Add(animateMoveRectangle(list[i], finalX, finalY));            
            }

            await Task.WhenAll(moveTasks);
        
        }

        public async Task highlightSection(int startIdx, int endIdx, Brush color)
        {
            for (int i = startIdx; i <= endIdx; i++) recManager.selectRec(i, color);
            if (recManager.NumRectangles < 250 || animationSpeed != 2) await Task.Delay(animationSpeed);
        }

    }
}
