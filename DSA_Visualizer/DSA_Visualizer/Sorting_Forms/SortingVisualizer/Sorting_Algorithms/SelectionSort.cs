using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Visualizer.Sorting_Forms.SortingVisualizer.Sorting_Algorithms
{
    public class SelectionSort : SortingAlgorithms
    {

        public SelectionSort(RectangleManger recManager) : base(recManager) { }

        public override async Task sort() {
            Console.Write("Before swap: ");
            recManager.printRectangleHeights();

            await selectionSort(recManager.Rectangles);
            await highlightAllGreen();

            Console.Write("After swap: ");
            recManager.printRectangleHeights();
        }

        public async Task selectionSort(List<ColoredRectangle> list) {
            int minIdx;

            for (int i = 0; i < list.Count - 1; i++) {
                cancellationTokenSource.Token.ThrowIfCancellationRequested(); // Cancel sort if requested
                if (this.IsPaused) await pauseSort(); // Pause sort if paused

                minIdx = i;
                recManager.selectRec(minIdx, Brushes.Red);
                await Task.Delay(animationSpeed);

                // Find minimum
                for (int j = i + 1; j < list.Count; j++) {
                    cancellationTokenSource.Token.ThrowIfCancellationRequested(); // Cancel sort if requested
                    if (this.IsPaused) await pauseSort(); // Pause sort if paused

                    recManager.selectRec(j, Brushes.Blue);
                    Console.WriteLine("Animation speed: " + animationSpeed);
                    await Task.Delay(animationSpeed);


                    if (list[minIdx] > list[j])
                    {
                        recManager.deselectRec(minIdx); // Deslect old min
                        await Task.Delay(animationSpeed);

                        minIdx = j;
                        recManager.selectRec(minIdx, Brushes.Red); // Select new min
                        await Task.Delay(animationSpeed);

                    }
                    else
                    {

                        await Task.Delay(animationSpeed);
                        recManager.deselectRec(j);
                    }
                }

                if (minIdx != i) {
                    await swap(i, minIdx);
                    if (recManager.NumRectangles < 250 || animationSpeed != 2) await Task.Delay(animationSpeed);
                }

                recManager.deselectRec(i);
                recManager.deselectRec(minIdx);
            }
        }
    }
}
