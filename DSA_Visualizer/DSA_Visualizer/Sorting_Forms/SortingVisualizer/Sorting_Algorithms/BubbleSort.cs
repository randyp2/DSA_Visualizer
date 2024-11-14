using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Visualizer.Sorting_Forms.SortingVisualizer.Sorting_Algorithms
{
    public class BubbleSort : SortingAlgorithms
    {

        public BubbleSort(RectangleManger recManager) : base(recManager) { }

        public override async Task sort() {
            Console.Write("Before swap: ");
            recManager.printRectangleHeights();

            await bubbleSort(recManager.Rectangles);
            await highlightAllGreen();

            Console.Write("After swap: ");
            recManager.printRectangleHeights();
        }

        public async Task bubbleSort(List<ColoredRectangle> list) {
            // If swapped is false during after one iteration in outerloop then sort is finished
            bool swapped;

            for (int i = 0; i < list.Count - 1; i++) {
                cancellationTokenSource.Token.ThrowIfCancellationRequested(); // Cancel sort if requested
                if (this.IsPaused) await pauseSort(); // Pause sort if paused

                swapped = false;

                for (int j = 0; j < list.Count - i - 1; j++) { // No need to check last element 
                    cancellationTokenSource.Token.ThrowIfCancellationRequested(); // Cancel sort if requested
                    if (this.IsPaused) await pauseSort(); // Pause sort if paused

                    recManager.selectRec(j, Brushes.Blue);

                    updateCompare();
                    if (list[j] > list[j+1])
                    {
                        await swap(j, j + 1);
                        updateSwap();

                        swapped = true;
                    }
                    
                    recManager.deselectRec(j);
                    recManager.deselectRec(j+1);
                }

                if (!swapped) break; // Sort is finished

            }
        }
    }
}
