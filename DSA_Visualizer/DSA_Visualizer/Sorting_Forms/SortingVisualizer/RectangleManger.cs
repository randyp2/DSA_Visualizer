using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSA_Visualizer.Sorting_Forms.SortingVisualizer
{
    public class RectangleManger
    {
        List<ColoredRectangle> rectanglesCopy; // Stores a copy of rectangles before sorting
        List<ColoredRectangle> rectangles;

        Panel panel;
        Random rnd;

        int numRectangles;
        int panelCurrHeight;
        
        public RectangleManger(Panel displayPanel) {

            populateRectangles();
            numRectangles = 0;
            this.panel = displayPanel;
            this.panelCurrHeight = 0;

            this.rnd = new Random();
            this.rectanglesCopy = new List<ColoredRectangle>();
            this.rectangles = new List<ColoredRectangle>();
        }

        public int PanelCurrHeight { 
            get { return this.panelCurrHeight; }
            set { this.panelCurrHeight = value; }
        }

        public int NumRectangles {
            get { return numRectangles; }
            set { numRectangles = value; }
        }

        public List<ColoredRectangle> Rectangles { 
            get { return rectangles; }
        }

        public Panel Panel { 
            get { return panel; }
        }

       

        /*
         * @brief Initialize rectangles list
         * 
         * @details Generates differing heights for each rectangle
         */
        public void populateRectangles() {
            if (panel == null) return;
            float width = panel.Width / numRectangles;

            rectanglesCopy.Clear();
            rectangles.Clear(); // Clear any existing rectangles

            for (int i = 0; i < numRectangles; i++)
            {
                float height = rnd.Next(0, panelCurrHeight);
                float xPos = i * width;
                float yPos = panelCurrHeight - height;

                rectanglesCopy.Add(new ColoredRectangle(new RectangleF(xPos, yPos, width, height), Brushes.White));
                rectangles.Add(new ColoredRectangle(new RectangleF(xPos, yPos, width, height), Brushes.White));
            }
        }

        // Initialize the rectangles list with their original values (before being swapped)
        public void resetRectangles() {
            for(int i = 0; i < numRectangles; i++)
            {
                ColoredRectangle copyRect = rectanglesCopy[i];
                rectangles[i] = new ColoredRectangle(
                    new RectangleF(copyRect.rect.X,
                    panelCurrHeight - copyRect.rect.Height, 
                    copyRect.rect.Width, 
                    copyRect.rect.Height),

                    Brushes.White
                    );
            }
        }

        /*
         * @brief Draws rectangles onto disply panel
         * 
         * @details Iterates through entire rectangle list and draws each one
         * draws the swaping rectangles last to ensure it is drawn over the
         * current rectangles
         * 
         * @param 
         *      i) Graphics : graphics object to draw on
         */
        public void drawRectangles(Graphics g) {
            if (rectangles == null) return;

            List<ColoredRectangle> toSwap = new List<ColoredRectangle>(); // Stores rectangles in swapping animation

            // Draw all rectangles except for ones in swap mode
            for (int i = 0; i < numRectangles; i++)
            { 
                if (rectangles[i].isSwapping) {
                    toSwap.Add(rectangles[i]);
                    continue;
                }
                g.FillRectangle(rectangles[i].Color, rectangles[i].rect);
            }
           
            // Draw swapping rectangles
            foreach (var rectangles in toSwap) {
                g.FillRectangle(rectangles.Color, rectangles.rect);
            }
        }

        // Debugger helper
        public void printRectangleHeights() {
            foreach (var rectangles in rectangles) { 
                Console.Write(rectangles.rect.Height + " ");
            } 
            Console.WriteLine();
        }

        // Debugger helper
        public void printCopyRectangleHeights() {
            foreach (var rectangles in rectanglesCopy)
            {
                Console.Write(rectangles.rect.Height + " ");
            }
            Console.WriteLine();
        }

        /*
         * @brief Highlight specific rectangle
         * 
         * @details Update the color of the ColoredRectangle property
         * and call invalidate to repaint
         * 
         * @param 
         *      i) int : index of rectangle to select
         *      ii) Brush : Color to highlight/fill rectangle
         */
        public void selectRec(int idx, Brush fillBrush) {          
            rectangles[idx].Color = fillBrush;
            this.panel.Invalidate();
        }


        /*
         * @brief Deselect the given rectangle
         * 
         * @details Set color of ColoredRectangle at idx to
         * white/default color
         * 
         * @param
         *      i) int : idx of ColoredRectangle to deslect
         *      
         */
        public void deselectRec(int idx) {
            rectangles[idx].Color = Brushes.White;
            this.panel.Invalidate();
        }
    }
}
