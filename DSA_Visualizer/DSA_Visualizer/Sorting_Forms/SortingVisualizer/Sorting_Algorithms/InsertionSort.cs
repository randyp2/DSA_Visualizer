using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Visualizer.Sorting_Forms.SortingVisualizer.Sorting_Algorithms
{
    public class InsertionSort:SortingAlgorithms
    {

        public InsertionSort(RectangleManger recManager) : base(recManager) {}

        public override async Task sort() {

            await insertionSort(recManager.Rectangles, recManager.NumRectangles);
            highlightAllGreen();
        }

        public async Task insertionSort(List<ColoredRectangle> list, int n) {

            for (int i = 1; i < n; ++i) {
                if (this.IsPaused) await pauseSort(); // Pause partition if paused

                int key = (int)list[i].rect.Height;
                int j = i - 1;

                while (j >= 0 && list[j].rect.Height > key)
                {
                    cancellationTokenSource.Token.ThrowIfCancellationRequested(); // Cancel function 
                    Console.WriteLine("Running inside while loop");

                    if (recManager.NumRectangles < 250 || animationSpeed != 2) await Task.Delay(animationSpeed);
                    recManager.selectRec(j, Brushes.Blue);

                    // Swap list[j] with list[j+1]
                    await swap(j, j + 1);
                   
                    j--;
                }

                
            }
        
        }
    }
}
