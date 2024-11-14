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

        public int originalIndex { get; set; } // For mergesort
        public ColoredRectangle(RectangleF rect, Brush color)
        {
            this.rect = rect;
            Color = color;
            this.isSwapping = false;
        }

        public static bool operator <(ColoredRectangle rectI, ColoredRectangle rectJ) {
            if (rectI == null || rectJ == null) return false;

            return rectI.rect.Height < rectJ.rect.Height;   
        }

        public static bool operator >(ColoredRectangle rectI, ColoredRectangle rectJ) {
            if (rectI == null || rectJ == null) return false;

            return rectI.rect.Height > rectJ.rect.Height;
        }


        public static bool operator <=(ColoredRectangle rectI, ColoredRectangle rectJ)
        {
            if (rectI == null || rectJ == null) return false;

            return rectI.rect.Height <= rectJ.rect.Height;
        }

        public static bool operator >=(ColoredRectangle rectI, ColoredRectangle rectJ)
        {
            if (rectI == null || rectJ == null) return false;

            return rectI.rect.Height >= rectJ.rect.Height;
        }



    }
}
