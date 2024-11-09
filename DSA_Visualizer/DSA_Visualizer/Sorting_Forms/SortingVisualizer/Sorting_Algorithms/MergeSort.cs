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
            Console.Write("Before swap: ");
            recManager.printRectangleHeights();

            //await mergeSort(recManager.Rectangles, 0, recManager.NumRectangles - 1);
            recManager.selectRec(1, Brushes.Blue);
            await animateMoveRectangle(1, 3);


            Console.Write("After swap: ");
            recManager.printRectangleHeights();
            
        }

        public async Task mergeSort(List<ColoredRectangle> list, int start, int end) {
            if (start >= end) return;
            if (this.IsPaused) await pauseSort(); // Pause sort if paused

            int mid = start + (end - start) / 2; // Find mid index


            // Split array in half
            await highlightSection(start, mid, Brushes.Gray);
            await highlightSection(start, mid, Brushes.White); // Unhighlight
            await mergeSort(list, start, mid);

            if (this.IsPaused) await pauseSort(); // Pause sort if paused

            await highlightSection(mid + 1, end, Brushes.Gray);
            await highlightSection(mid + 1, end, Brushes.White); // Unhighlight
            await mergeSort(list, mid + 1, end);
            

            // Merge two subarrays in their sorted positions
            await merge(list, start, mid, end);
        }


        public async Task merge(List<ColoredRectangle> list, int start, int mid, int end) {
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
              
            // Compare values in both the lsits and merge values back to original list
            int i, j, k;
            i = j = 0;
            k = start;

            while (i < leftListLength && j < rightListLength) {
                if (this.IsPaused) await pauseSort(); // Pause sort if paused
                if (leftList[i].rect.Height < rightList[j].rect.Height)
                {
                    list[k] = leftList[i];
                    i++;
                }
                else
                {
                    list[k] = rightList[j];
                    j++;
                }
                k++;
            }

            // Insert remaining values
            while (i < leftListLength)
            {
                if (this.IsPaused) await pauseSort(); // Pause sort if paused
                list[k] = leftList[i];
                i++;
                k++;
            }

            while (j < rightListLength)
            {
                if (this.IsPaused) await pauseSort(); // Pause sort if paused
                list[k] = rightList[j];
                j++;
                k++;
            }
        }


        public async Task highlightSection(int startIdx, int endIdx, Brush color) {
            for (int i = startIdx; i <= endIdx; i++) recManager.selectRec(i, color);
            await Task.Delay(animationSpeed);
        }
    }
}
