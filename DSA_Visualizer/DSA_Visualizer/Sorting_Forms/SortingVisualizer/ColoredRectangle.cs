using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Visualizer.Sorting_Forms.SortingVisualizer
{
    public class ColoredRectangle
    {
        public bool isSwapping { get; set; }
        public RectangleF rect { get; set; }
        public Brush Color { get; set; }

        public bool isSorted { get; set; }

        public ColoredRectangle(RectangleF rect, Brush color)
        {
            this.rect = rect;
            Color = color;
            this.isSwapping = false;
        }
    }
}
