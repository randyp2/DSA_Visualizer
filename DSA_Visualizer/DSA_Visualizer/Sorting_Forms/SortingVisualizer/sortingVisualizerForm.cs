using DSA_Visualizer.Sorting_Forms.SortingVisualizer.Sorting_Algorithms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSA_Visualizer.Sorting_Forms.SortingVisualizer
{
    public partial class sortingVisualizerForm : Form
    {
        private RectangleManger recMnger;
        private SortingAlgorithms algorithms;

        public sortingVisualizerForm()
        {
            InitializeComponent();
            SetDoubleBuffered(this); // Remove flickering of form
            SetDoubleBuffered(displayPanel); // Remove flickering of display panel
            recMnger = new RectangleManger(displayPanel);

            this.displayPanel.BackColor = Color.FromArgb(225, 0, 0, 0); // Transparent background
            this.resetBtn.Hide();
        }

        /* ====================== RESET FUNCTIONS ====================== */

        // Cancel any animation for swapping
        // Redisplay the current amount of rectangles selected
        public void resetDisplayPanel()
        {
            recMnger.resetRectangles();
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

        /* ====================== INITIALIZATION FUNCTIONS ====================== */
       
        /*
         * @brief Initializse recManager class
         * 
         * @details Set number of rectangles; Populate the rectangle list
         * 
         * @param 
         *  i) int: value from scroll bar
         */
        public void initializeRecMnger(int value)
        {
            switch (value)
            {
                case 0: recMnger.NumRectangles = 10; break;
                case 1: recMnger.NumRectangles = 100; break;
                case 2: recMnger.NumRectangles = 250; break;
                case 3: recMnger.NumRectangles = 500; break;
                case 4: recMnger.NumRectangles = 1000; break;
            }

            recMnger.populateRectangles();
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

            // Determine algorithm
            switch (algorithm)
            {
                case "Quick Sort":
                    algorithms = new QuickSort(this.recMnger);
                    initializeAlgorithmOutputs();
                    break;

                case "Insertion Sort":
                    algorithms = new InsertionSort(this.recMnger);
                    initializeAlgorithmOutputs();
                    break;  
            }

            int reversedVal = speedTrackBar.Maximum - speedTrackBar.Value + speedTrackBar.Minimum;
            algorithms?.setAnimationSpeed(reversedVal);
            initializeAlgorithmSpeed();
        }

        private void initializeAlgorithmSpeed() {
            int reversedVal = speedTrackBar.Maximum - speedTrackBar.Value + speedTrackBar.Minimum;
            algorithms?.setAnimationSpeed(reversedVal);

            if (speedTrackBar.Value == speedTrackBar.Maximum) reversedVal = 1;
            if (sizeBar.Value != 0) algorithms?.setOffsetX(1000 / reversedVal);
        }

        public void initializeAlgorithmOutputs()
        {
            algorithms.CompareOutput = cmprOutput;
            algorithms.SwapOutput = swapsOutput;
        }

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
            initializeRecMnger(sizeBar.Value);
            displayPanel.Invalidate();
        }

        // Paint event to trigger rectangle drawing
        private void displayPanel_Paint(object sender, PaintEventArgs e) { recMnger.drawRectangles(e.Graphics);}
        
        /*
         * @brief Sort Button On Click Event
         * 
         * @details Run sorting function based on algorithm
         * 
         */
        private void sortBtn_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (recMnger.NumRectangles == 0) {
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

                initializeAlgorithm();
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
            algorithms.terminateSort();
            resetDisplayPanel();
            resetLabelOutputs();
            initializeAlgorithm(); // Create new instance of algorithm
        }

        // Update number of rectangles
        private void sizeBar_Scroll(object sender, EventArgs e)
        {
            initializeRecMnger(sizeBar.Value);
            sortBtn.Text = "Sort";
            displayPanel.Invalidate();
            resetLabelOutputs();

        }

        private void speedTrackBar_Scroll(object sender, EventArgs e)
        {
            initializeAlgorithmSpeed();
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
