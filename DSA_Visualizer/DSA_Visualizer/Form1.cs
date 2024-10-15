using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSA_Visualizer
{
    public partial class homePage : Form
    {
        private Control navSubPanel; // Stores which sub panel was pressed

        // Collapsed menu bools
        private bool isSubPanelCollapsed; 
        private bool isMenuCollapsed;

        // List of all navBtns
        List<Button> navPanelBtns;

        
        public homePage()
        {
            InitializeComponent();
            
            SetDoubleBuffered(mainDisplayPanel); // Remove flickering

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle; // Change later to dynamic
            titlePanel.BackColor = Color.FromArgb(200, 0, 0, 0);

            // Subpanel Variables
            navSubPanel = null;
            isSubPanelCollapsed = true;
            isMenuCollapsed = false;

            // Populate Nav Btns

            navPanelBtns = new List<Button>();

            foreach (Panel panel in navPanel.Controls)
            {
                foreach (Button button in panel.Controls)
                {
                    if (button.Name[button.Name.Length - 1] == '_') navPanelBtns.Add(button);
                }
            }

            initializeBtnAnimation();
        }

        // Initialize each button to click event
        private void initializeBtnAnimation()
        {
            // Attach buttons to same event
            foreach (Button button in navPanelBtns) button.Click += subPanelBtnClick;
        }

        /*
         * @function timer event for nav animation
         * 
         * @brief expands the height of the submenu until it is fully revealed
         * 
         * @param object sender, Event Listener
         */
        private void dropDownAnimation_Tick(object sender, EventArgs e)
        {

            if (isSubPanelCollapsed) { // If sub menu is collapsed
               
                navSubPanel.Height += 10;
                if (navSubPanel.Size.Height == navSubPanel.MaximumSize.Height) {
                    isSubPanelCollapsed = false;
                    dropDownAnimation.Stop();
                }
            }else { // If sub menu expanded
                navSubPanel.Height -= 10;
                if (navSubPanel.Size.Height == navSubPanel.MinimumSize.Height) {
                    isSubPanelCollapsed = true; 
                    dropDownAnimation.Stop();
                }
            }
        }

        /*
         * @function timer event for menu sidebar animation
         * 
         * @brief expands the menu width to min or max width
         * 
         * @param object sender, Eventlistener
         * 
         */
        private void menuAnimation_Tick(object sender, EventArgs e)
        {
            if (!isMenuCollapsed)
            {
                navPanel.Width -= 10;
                if (navPanel.Width == navPanel.MinimumSize.Width)
                {
                    isMenuCollapsed = true;
                    menuAnimation.Stop();
                }
            }
            else {
                navPanel.Width += 10;
                if (navPanel.Width == navPanel.MaximumSize.Width) {
                    isMenuCollapsed = false;
                    menuAnimation.Stop();
                }
            }
        }

        /*
         * @function subPanel Button Event Listener
         *  
         * @brief Retrieves the button's parent and calls the tick animation
         * 
         * @param object sender, EventArgs e (event listener)
         * 
         */
        private void subPanelBtnClick(object sender, EventArgs e) {
            // Gets button clicked's parent container
            Button btnClicked = (Button)sender;
            navSubPanel = btnClicked.Parent;
            dropDownAnimation.Start();
        }

        // Ininitiate the menu sidebar animation
        private void sidebarBtn_Click(object sender, EventArgs e)
        {
            menuAnimation.Start(); 
        }

        private void sortVisualBtn_Click(object sender, EventArgs e)
        {
            loadForm(new Sorting_Forms.sortingForm());
        }


        // Function to load different forms
        private void loadForm(object Form) {

            // Remove any panels on display panel
            if (this.mainDisplayPanel.Controls.Count > 0) {
                this.mainDisplayPanel.Controls.RemoveAt(0);
            }

            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainDisplayPanel.Controls.Add(f);
            this.mainDisplayPanel.Tag = f;
            f.Show();
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
