using DSA_Visualizer.Sorting_Forms.SortingVisualizer.Sorting_Algorithms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSA_Visualizer.Sorting_Forms.SortingVisualizer
{
    public partial class sortingVisualizerForm : Form
    {
        private const int RESIZE_HEIGHT = 175;
        private const int DISPLAY_HEIGHT = 431;
        private const int INCREASED_HEIGHT = 606;
        private const int MINIMIZED_HEIGHT = 256;


        private const int DISPLAY_XPOS = 79;
        private const int DISPLAY_YPOS = 101;

        private RectangleManger recManager;
        private SortingAlgorithms algorithms;
        private AnalysisManager analysisManager;

        private bool resetBtnPressed;

        public sortingVisualizerForm()
        {
            InitializeComponent();
            SetDoubleBuffered(this); // Remove flickering of form
            SetDoubleBuffered(displayPanel); // Remove flickering of display panel
            this.analysisPanel.Visible = false;
            this.displayPanel.BackColor = Color.FromArgb(225, 0, 0, 0); // Transparent background

            this.recManager = new RectangleManger(displayPanel);
            recManager.PanelCurrHeight = DISPLAY_HEIGHT;

            this.analysisManager = new AnalysisManager(analysisPanel); 

            this.resetBtnPressed = false;
            
            this.resetBtn.Hide();
        }


        /* ====================== RESET FUNCTIONS ====================== */

        // Cancel any animation for swapping
        // Redisplay the current amount of rectangles selected
        public void resetDisplayPanel()
        {
            recManager.resetRectangles();
            displayPanel.Invalidate();

            resetBtn.Hide(); // Hide reset btn
            sortBtn.Text = "Sort";
        }

        // Reset total compares and swaps
        public void resetLabelOutputs()
        {
            this.cmprOutput.Text = "0";
            this.swapsOutput.Text = "0";
        }

        public void resetDisplay() {
            if (displayPanel.Size.Height == DISPLAY_HEIGHT) return;
            recManager.PanelCurrHeight = DISPLAY_HEIGHT;

            // Decrease size and recenter
            displayPanel.Size = new Size(displayPanel.Size.Width, displayPanel.Size.Height - RESIZE_HEIGHT);
            displayPanel.Location = new Point(displayPanel.Location.X, displayPanel.Location.Y + (RESIZE_HEIGHT / 2));

            // Repopulate & redraw rectangles
            recManager.populateRectangles();
            displayPanel.Invalidate();

        }

        /* ====================== FORM MODIFIER FUNCTIONS ====================== */

        public void moveDisplay() {
            


            int newSize = DISPLAY_HEIGHT + RESIZE_HEIGHT;
            if (recManager.PanelCurrHeight == newSize/2) return;

            recManager.PanelCurrHeight = newSize/2;

            // Increase size and recenter
            displayPanel.Size = new Size(displayPanel.Size.Width, newSize); 
            displayPanel.Location = new Point(displayPanel.Location.X, displayPanel.Location.Y - (RESIZE_HEIGHT/2));

           
            // Repopulate & redraw rectangles
            recManager.populateRectangles();
            displayPanel.Invalidate();


        }

        /* ====================== INITIALIZATION FUNCTIONS ====================== */

        /*
         * @brief Initializse recManager class
         * 
         * @details Set number of rectangles; Populate the rectangle list
         * 
         * @param 
         *  i) int: value from scroll bar
         */
        public void initializerecManager(int value)
        {
            switch (value)
            {
                case 0: recManager.NumRectangles = 10; break;
                case 1: recManager.NumRectangles = 100; break;
                case 2: recManager.NumRectangles = 250; break;
                case 3: recManager.NumRectangles = 500; break;
                case 4: recManager.NumRectangles = 1000; break;
            }

            recManager.populateRectangles();
        }

        /*
         * @brief Initialize SortingAlgorithm class
         * 
         * @details Initialize SortingAlgorithm to value in
         * combobox
         */
        private void initializeAlgorithm()
        {
            string algorithm = algComboBox.Text;

            if (algorithm != "Merge Sort") resetDisplay();

            // Determine algorithm
            switch (algorithm)
            {
                case "Bogo Sort":


                // O(n^2) algorithms
                case "Insertion Sort":
                    algorithms = new InsertionSort(this.recManager);        
                    analysisManager.InitializeInformation("Insertion Sort");
                    initializeAlgorithmOutputs();
                    break;

                case "Bubble Sort":
                    algorithms = new BubbleSort(this.recManager);
                    analysisManager.InitializeInformation("Bubble Sort");
                    
                    initializeAlgorithmOutputs();
                    break;

                case "Selection Sort":
                    algorithms = new SelectionSort(this.recManager);
                    analysisManager.InitializeInformation("Selection Sort");
                  
                    initializeAlgorithmOutputs();
                    break;


                // O(nlogn) algorithms
                case "Quick Sort":
                    algorithms = new QuickSort(this.recManager);
                    analysisManager.InitializeInformation("Quick Sort");
                    
                    initializeAlgorithmOutputs();
                    break;
                

                case "Merge Sort":
                    algorithms = new MergeSort(this.recManager);
                    analysisManager.InitializeInformation("Merge Sort");
                    
                    moveDisplay();
                    initializeAlgorithmOutputs();
                    break;
            }

            int reversedVal = speedTrackBar.Maximum - speedTrackBar.Value + speedTrackBar.Minimum;
            algorithms?.setAnimationSpeed(reversedVal);
            initializeAlgorithmSpeed();
        }

        


        /*
         * @brief Update algorithm speed
         * 
         * @details Have left most trackbar be slowest speed and rightmost be fastest speed
         */
        private void initializeAlgorithmSpeed() {
            int reversedVal = speedTrackBar.Maximum - speedTrackBar.Value + speedTrackBar.Minimum;
            algorithms?.setAnimationSpeed(reversedVal);

            if (speedTrackBar.Value == speedTrackBar.Maximum) reversedVal = 1;
            if (sizeBar.Value != 0)
            {
                algorithms?.setOffsetX(1000 / reversedVal);
                algorithms?.setOffsetY(1000 / reversedVal);
            }
            
        }

        // Update total compares and swaps
        public void initializeAlgorithmOutputs()
        {
            algorithms.CompareOutput = cmprOutput;
            algorithms.SwapOutput = swapsOutput;
        }
        
        // Check for algorithm
        public bool validAlgorithm() {
            // Error check
            if (algComboBox.Text == "")
            {
                MessageBox.Show(
                    "Please choose sorting algorithm",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }

            return true;
        }



        /* ====================== FORM EVENTS ====================== */
        private void sortingVisualizerForm_Load(object sender, EventArgs e)
        {
          
            initializerecManager(sizeBar.Value);
            displayPanel.Invalidate();

            // Analysis panel
            createRoundedPanel(analysisPanel, 20);
        }

        // Paint event to trigger rectangle drawing
        private void displayPanel_Paint(object sender, PaintEventArgs e) { recManager.drawRectangles(e.Graphics);}
        
        /*
         * @brief Sort Button On Click Event
         * 
         * @details Run sorting function based on algorithm
         * 
         */
        private void sortBtn_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (recManager.NumRectangles == 0) {
                MessageBox.Show(
                    "Please choose input size first", // Message text
                    "Warning",  // Title
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // Handle sort, pause, and unpause functions
            if (sortBtn.Text == "Sort")
            {
                if (!validAlgorithm()) return;

                //initializeAlgorithm();
                algorithms?.sort(); // If class is not null

                if (algorithms != null)
                {
                    this.resetBtn.Show(); // Unhide reset button
                    sortBtn.Text = "Pause";
                }
            }
            else if (sortBtn.Text == "Pause")
            {
                // Pause animation
                algorithms.IsPaused = true;
                sortBtn.Text = "Resume";
            }
            else if (sortBtn.Text == "Resume") {
                // Unpause animation
                algorithms.IsPaused = false;
                sortBtn.Text = "Pause";
            }

        }

        // Stop any animations
        // Reset display panel
        private void resetBtn_Click(object sender, EventArgs e)
        {
            this.resetBtnPressed = true;
            algorithms.terminateSort();
            resetDisplayPanel();
            resetLabelOutputs();
            initializeAlgorithm(); // Create new instance of algorithm
        }

        private void algComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            initializeAlgorithm();
        }

        // Update number of rectangles
        private void sizeBar_Scroll(object sender, EventArgs e)
        {
            initializerecManager(sizeBar.Value);
            sortBtn.Text = "Sort";
            displayPanel.Invalidate();
            resetLabelOutputs();

        }

        private void speedTrackBar_Scroll(object sender, EventArgs e)
        {
            initializeAlgorithmSpeed();
        }


        /* ====================== ANALYSIS WINDOW ====================== */
      

        private void analysisMenuBtn_MouseEnter(object sender, EventArgs e)
        {
            this.analysisPanel.Visible = true;
            this.analysisMenuBtn.Visible = false;
        }

        private void analysisPanel_MouseLeave(object sender, EventArgs e)
        {
            Point mousePos = this.PointToClient(Cursor.Position); // Get mouse position relative to whole form

            if (!this.analysisPanel.Bounds.Contains(mousePos)) { // If the mouse's position is contained in the panel
                this.analysisPanel.Visible = false;
                this.analysisMenuBtn.Visible = true;
            }
            
        }

        /*
         *  Create rounded edges on square panel
         */
        private void createRoundedPanel(Panel panel, int cornerRad) {
            Rectangle bounds = panel.ClientRectangle;
            int diameter = 2 * cornerRad;

            GraphicsPath path = new GraphicsPath();

            // Top-left
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);

            // Top-right corner
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);

            // Bottom-right corner
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);

            // Bottom-left corner
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);

            path.CloseFigure();

            panel.Region = new Region(path);



        }

        /* ==================================================================== */
        /* ------------ REMOVE WHITE FLICKERING OF PANEL ------------
        *                      DO NOT MODIFY!
        * 
        * Source: https://www.codeproject.com/Questions/728551/Remove-flickering-due-to-TableLayoutPanel-Panel-in
        *
        */
        #region .. Double Buffered function ..
        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;
            System.Reflection.PropertyInfo aProp = typeof(System.Windows.Forms.Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            aProp.SetValue(c, true, null);
        }

        #endregion


        #region .. code for Flucuring ..

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

       



        #endregion

        /*==================================================================== */
    }
}
