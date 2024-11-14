using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Visualizer.Sorting_Forms.SortingVisualizer.Sorting_Algorithms
{
    public class QuickSort : SortingAlgorithms
    {
        public QuickSort(RectangleManger recManager) : base(recManager) { 
        }


        public override async Task sort() {     
            Console.Write("Before swap: ");
            recManager.printRectangleHeights();

            int l = 0;
            int h = recManager.NumRectangles - 1;
            List<ColoredRectangle> list = recManager.Rectangles;
            await qs(list, l, h);

            Console.Write("After swap: ");
            recManager.printRectangleHeights();

            await highlightAllGreen();
            
        }


        public async Task qs(List<ColoredRectangle> list, int low, int high)
        {
            if (this.IsPaused) await pauseSort(); // Pause sort if paused

            if (low < high)
            {
                cancellationTokenSource.Token.ThrowIfCancellationRequested();
                
                int pivot = await partition(list, low, high);

                if (this.IsPaused) await pauseSort(); // Pause sort if paused
                
                await qs(list, low, pivot - 1);

                
                if (this.IsPaused) await pauseSort(); // Pause sort if paused

                
                await qs(list, pivot + 1, high);
            }
            else {
                if (low > 0 && low < recManager.NumRectangles)
                {
                    recManager.selectRec(low, Brushes.Green);
                }
                else if (high < recManager.NumRectangles && high > 0)
                {
                    recManager.selectRec(high, Brushes.Green);
                }
                else {
                    recManager.selectRec(0, Brushes.Green);
                }
            }
        }

        public async Task<int> partition(List<ColoredRectangle> list, int l, int r)
        {
            
            
            ColoredRectangle pivot = list[l];
            recManager.selectRec(l, Brushes.Green);
            
            int leftPtr = l + 1;
            int rightPtr = r;

            recManager.selectRec(leftPtr, Brushes.Red);
            recManager.selectRec(rightPtr, Brushes.Blue);
            if (recManager.NumRectangles < 250 || animationSpeed != 2)  await Task.Delay(animationSpeed);


            while (leftPtr <= rightPtr)
            {
                cancellationTokenSource.Token.ThrowIfCancellationRequested(); // Cancel function 
                if (this.IsPaused) await pauseSort(); // Pause sort if paused


                updateCompare();
                while (leftPtr <= r && list[leftPtr] <= pivot)
                {
                    
                    recManager.deselectRec(leftPtr);
                    leftPtr++;
                    if (leftPtr < recManager.NumRectangles) recManager.selectRec(leftPtr, Brushes.Red);

                    if(recManager.NumRectangles < 250 || animationSpeed != 2) await Task.Delay(animationSpeed);
                }

                updateCompare();
                while (rightPtr >= l && list[rightPtr] > pivot)
                {
                    
                    recManager.deselectRec(rightPtr);
                    rightPtr--;
                    if (rightPtr >= 0) recManager.selectRec(rightPtr, Brushes.Blue);

                    if (recManager.NumRectangles < 250 || animationSpeed != 2)  await Task.Delay(animationSpeed);
                }
                
                // Deselect rectangles
                if (leftPtr < recManager.NumRectangles) recManager.deselectRec(leftPtr);
                if (rightPtr > 0) recManager.deselectRec(rightPtr);

                if (leftPtr < rightPtr)
                {
                    recManager.selectRec(leftPtr, Brushes.Gray);
                    recManager.selectRec(rightPtr, Brushes.Gray);
                    updateSwap();
                    await swap(leftPtr, rightPtr);
                }

            }

            if (this.IsPaused) await pauseSort(); // Pause sort if paused

            recManager.selectRec(rightPtr, Brushes.Blue);
            recManager.Rectangles[l].isSorted = true;
            updateSwap();
            await swap(l, rightPtr);
            
            return rightPtr;
        }


    }
}
