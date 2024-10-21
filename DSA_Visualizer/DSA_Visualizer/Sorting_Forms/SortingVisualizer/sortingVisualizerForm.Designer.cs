namespace DSA_Visualizer.Sorting_Forms.SortingVisualizer
{
    partial class sortingVisualizerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.displayPanel = new System.Windows.Forms.Panel();
            this.sizeBar = new System.Windows.Forms.TrackBar();
            this.sortBtn = new System.Windows.Forms.Button();
            this.algComboBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmprOutput = new System.Windows.Forms.Label();
            this.swapsOutput = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.speedTrackBar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.resetBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sizeBar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // displayPanel
            // 
            this.displayPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.displayPanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.displayPanel.Location = new System.Drawing.Point(79, 101);
            this.displayPanel.Name = "displayPanel";
            this.displayPanel.Size = new System.Drawing.Size(1000, 431);
            this.displayPanel.TabIndex = 0;
            this.displayPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.displayPanel_Paint);
            // 
            // sizeBar
            // 
            this.sizeBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sizeBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(15)))), ((int)(((byte)(12)))));
            this.sizeBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.sizeBar.LargeChange = 1;
            this.sizeBar.Location = new System.Drawing.Point(111, 58);
            this.sizeBar.Maximum = 4;
            this.sizeBar.Name = "sizeBar";
            this.sizeBar.Size = new System.Drawing.Size(115, 45);
            this.sizeBar.TabIndex = 1;
            this.sizeBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sizeBar.Scroll += new System.EventHandler(this.sizeBar_Scroll);
            // 
            // sortBtn
            // 
            this.sortBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sortBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sortBtn.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sortBtn.Location = new System.Drawing.Point(498, 17);
            this.sortBtn.Name = "sortBtn";
            this.sortBtn.Size = new System.Drawing.Size(140, 94);
            this.sortBtn.TabIndex = 2;
            this.sortBtn.Text = "Sort";
            this.sortBtn.UseVisualStyleBackColor = true;
            this.sortBtn.Click += new System.EventHandler(this.sortBtn_Click);
            // 
            // algComboBox
            // 
            this.algComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.algComboBox.BackColor = System.Drawing.Color.White;
            this.algComboBox.DropDownHeight = 75;
            this.algComboBox.FormattingEnabled = true;
            this.algComboBox.IntegralHeight = false;
            this.algComboBox.Items.AddRange(new object[] {
            "Bogosort",
            "Bubble Sort",
            "Selection Sort",
            "Quick Sort",
            "Merge Sort"});
            this.algComboBox.Location = new System.Drawing.Point(710, 58);
            this.algComboBox.Name = "algComboBox";
            this.algComboBox.Size = new System.Drawing.Size(121, 21);
            this.algComboBox.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(15)))), ((int)(((byte)(12)))));
            this.panel1.Controls.Add(this.cmprOutput);
            this.panel1.Controls.Add(this.swapsOutput);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.speedTrackBar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.algComboBox);
            this.panel1.Controls.Add(this.sizeBar);
            this.panel1.Controls.Add(this.sortBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 625);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1157, 145);
            this.panel1.TabIndex = 4;
            // 
            // cmprOutput
            // 
            this.cmprOutput.AutoSize = true;
            this.cmprOutput.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmprOutput.ForeColor = System.Drawing.Color.White;
            this.cmprOutput.Location = new System.Drawing.Point(1046, 77);
            this.cmprOutput.Name = "cmprOutput";
            this.cmprOutput.Size = new System.Drawing.Size(17, 19);
            this.cmprOutput.TabIndex = 11;
            this.cmprOutput.Text = "0";
            // 
            // swapsOutput
            // 
            this.swapsOutput.AutoSize = true;
            this.swapsOutput.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.swapsOutput.ForeColor = System.Drawing.Color.White;
            this.swapsOutput.Location = new System.Drawing.Point(995, 29);
            this.swapsOutput.Name = "swapsOutput";
            this.swapsOutput.Size = new System.Drawing.Size(17, 19);
            this.swapsOutput.TabIndex = 10;
            this.swapsOutput.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(902, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "Total Comparisons:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(902, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Total Swaps:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(297, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Animation Speed";
            // 
            // speedTrackBar
            // 
            this.speedTrackBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.speedTrackBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(15)))), ((int)(((byte)(12)))));
            this.speedTrackBar.Cursor = System.Windows.Forms.Cursors.Default;
            this.speedTrackBar.LargeChange = 1;
            this.speedTrackBar.Location = new System.Drawing.Point(305, 58);
            this.speedTrackBar.Maximum = 300;
            this.speedTrackBar.Minimum = 2;
            this.speedTrackBar.Name = "speedTrackBar";
            this.speedTrackBar.Size = new System.Drawing.Size(108, 45);
            this.speedTrackBar.TabIndex = 7;
            this.speedTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.speedTrackBar.Value = 2;
            this.speedTrackBar.Scroll += new System.EventHandler(this.speedTrackBar_Scroll);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(734, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Input Size";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(138, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Input Size";
            // 
            // resetBtn
            // 
            this.resetBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.resetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.resetBtn.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetBtn.Location = new System.Drawing.Point(529, 48);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(75, 31);
            this.resetBtn.TabIndex = 5;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = false;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // sortingVisualizerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DSA_Visualizer.Properties.Resources.Home_BG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1157, 770);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.displayPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "sortingVisualizerForm";
            this.Text = "sortingForm";
            ((System.ComponentModel.ISupportInitialize)(this.sizeBar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel displayPanel;
        private System.Windows.Forms.TrackBar sizeBar;
        private System.Windows.Forms.Button sortBtn;
        private System.Windows.Forms.ComboBox algComboBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar speedTrackBar;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label cmprOutput;
        private System.Windows.Forms.Label swapsOutput;
        private System.Windows.Forms.Label label5;
    }
}