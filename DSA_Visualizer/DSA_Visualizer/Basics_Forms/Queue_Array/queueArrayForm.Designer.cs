namespace DSA_Visualizer.Basics_Forms.Queue_Array
{
    partial class QueueArrayForm
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DisplayQueueBtn = new System.Windows.Forms.Button();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.enqueueTxt = new System.Windows.Forms.TextBox();
            this.DequeueBtn = new System.Windows.Forms.Button();
            this.EnqueueBtn = new System.Windows.Forms.Button();
            this.AnimationTimer = new System.Windows.Forms.Timer(this.components);
            this.SlimePictureBox0 = new System.Windows.Forms.PictureBox();
            this.SlimePictureBox1 = new System.Windows.Forms.PictureBox();
            this.SlimePictureBox2 = new System.Windows.Forms.PictureBox();
            this.SlimePictureBox3 = new System.Windows.Forms.PictureBox();
            this.SlimePictureBox4 = new System.Windows.Forms.PictureBox();
            this.SlimePictureBox5 = new System.Windows.Forms.PictureBox();
            this.SlimePictureBox6 = new System.Windows.Forms.PictureBox();
            this.SlimePictureBox7 = new System.Windows.Forms.PictureBox();
            this.SlimePictureBox8 = new System.Windows.Forms.PictureBox();
            this.SlimePictureBox9 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SlimePictureBox0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlimePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlimePictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlimePictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlimePictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlimePictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlimePictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlimePictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlimePictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlimePictureBox9)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(15)))), ((int)(((byte)(12)))));
            this.panel1.Controls.Add(this.DisplayQueueBtn);
            this.panel1.Controls.Add(this.ClearBtn);
            this.panel1.Controls.Add(this.enqueueTxt);
            this.panel1.Controls.Add(this.DequeueBtn);
            this.panel1.Controls.Add(this.EnqueueBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 625);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1157, 145);
            this.panel1.TabIndex = 5;
            // 
            // DisplayQueueBtn
            // 
            this.DisplayQueueBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DisplayQueueBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DisplayQueueBtn.Font = new System.Drawing.Font("Microsoft YaHei", 11F, System.Drawing.FontStyle.Bold);
            this.DisplayQueueBtn.Location = new System.Drawing.Point(598, 39);
            this.DisplayQueueBtn.Name = "DisplayQueueBtn";
            this.DisplayQueueBtn.Size = new System.Drawing.Size(126, 49);
            this.DisplayQueueBtn.TabIndex = 7;
            this.DisplayQueueBtn.Text = "Display Queue";
            this.DisplayQueueBtn.UseVisualStyleBackColor = true;
            this.DisplayQueueBtn.Click += new System.EventHandler(this.DisplayQueueBtn_Click);
            // 
            // ClearBtn
            // 
            this.ClearBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ClearBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClearBtn.Font = new System.Drawing.Font("Microsoft YaHei", 11F, System.Drawing.FontStyle.Bold);
            this.ClearBtn.Location = new System.Drawing.Point(466, 38);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(126, 49);
            this.ClearBtn.TabIndex = 6;
            this.ClearBtn.Text = "Clear Queue";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // enqueueTxt
            // 
            this.enqueueTxt.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enqueueTxt.Location = new System.Drawing.Point(96, 52);
            this.enqueueTxt.Name = "enqueueTxt";
            this.enqueueTxt.Size = new System.Drawing.Size(100, 23);
            this.enqueueTxt.TabIndex = 5;
            this.enqueueTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DequeueBtn
            // 
            this.DequeueBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DequeueBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DequeueBtn.Font = new System.Drawing.Font("Microsoft YaHei", 13F, System.Drawing.FontStyle.Bold);
            this.DequeueBtn.Location = new System.Drawing.Point(334, 38);
            this.DequeueBtn.Name = "DequeueBtn";
            this.DequeueBtn.Size = new System.Drawing.Size(126, 49);
            this.DequeueBtn.TabIndex = 4;
            this.DequeueBtn.Text = "Dequeue";
            this.DequeueBtn.UseVisualStyleBackColor = true;
            this.DequeueBtn.Click += new System.EventHandler(this.DequeueBtn_Click);
            // 
            // EnqueueBtn
            // 
            this.EnqueueBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EnqueueBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EnqueueBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.EnqueueBtn.Font = new System.Drawing.Font("Microsoft YaHei", 13F, System.Drawing.FontStyle.Bold);
            this.EnqueueBtn.Location = new System.Drawing.Point(202, 38);
            this.EnqueueBtn.Name = "EnqueueBtn";
            this.EnqueueBtn.Size = new System.Drawing.Size(126, 49);
            this.EnqueueBtn.TabIndex = 3;
            this.EnqueueBtn.Text = "Enqueue";
            this.EnqueueBtn.UseVisualStyleBackColor = true;
            this.EnqueueBtn.Click += new System.EventHandler(this.EnqueueBtn_Click);
            // 
            // AnimationTimer
            // 
            this.AnimationTimer.Tick += new System.EventHandler(this.AnimationTimer_Tick);
            // 
            // SlimePictureBox0
            // 
            this.SlimePictureBox0.BackColor = System.Drawing.Color.Transparent;
            this.SlimePictureBox0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SlimePictureBox0.Cursor = System.Windows.Forms.Cursors.Default;
            this.SlimePictureBox0.Location = new System.Drawing.Point(266, 325);
            this.SlimePictureBox0.Name = "SlimePictureBox0";
            this.SlimePictureBox0.Size = new System.Drawing.Size(64, 64);
            this.SlimePictureBox0.TabIndex = 6;
            this.SlimePictureBox0.TabStop = false;
            this.SlimePictureBox0.Paint += new System.Windows.Forms.PaintEventHandler(this.SlimePictureBox0_Paint);
            // 
            // SlimePictureBox1
            // 
            this.SlimePictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.SlimePictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SlimePictureBox1.Location = new System.Drawing.Point(336, 325);
            this.SlimePictureBox1.Name = "SlimePictureBox1";
            this.SlimePictureBox1.Size = new System.Drawing.Size(64, 64);
            this.SlimePictureBox1.TabIndex = 7;
            this.SlimePictureBox1.TabStop = false;
            this.SlimePictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.SlimePictureBox1_Paint);
            // 
            // SlimePictureBox2
            // 
            this.SlimePictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SlimePictureBox2.Location = new System.Drawing.Point(406, 325);
            this.SlimePictureBox2.Name = "SlimePictureBox2";
            this.SlimePictureBox2.Size = new System.Drawing.Size(64, 64);
            this.SlimePictureBox2.TabIndex = 8;
            this.SlimePictureBox2.TabStop = false;
            this.SlimePictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.SlimePictureBox2_Paint);
            // 
            // SlimePictureBox3
            // 
            this.SlimePictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SlimePictureBox3.Location = new System.Drawing.Point(476, 325);
            this.SlimePictureBox3.Name = "SlimePictureBox3";
            this.SlimePictureBox3.Size = new System.Drawing.Size(64, 64);
            this.SlimePictureBox3.TabIndex = 9;
            this.SlimePictureBox3.TabStop = false;
            this.SlimePictureBox3.Paint += new System.Windows.Forms.PaintEventHandler(this.SlimePictureBox3_Paint);
            // 
            // SlimePictureBox4
            // 
            this.SlimePictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SlimePictureBox4.Location = new System.Drawing.Point(546, 325);
            this.SlimePictureBox4.Name = "SlimePictureBox4";
            this.SlimePictureBox4.Size = new System.Drawing.Size(64, 64);
            this.SlimePictureBox4.TabIndex = 10;
            this.SlimePictureBox4.TabStop = false;
            this.SlimePictureBox4.Paint += new System.Windows.Forms.PaintEventHandler(this.SlimePictureBox4_Paint);
            // 
            // SlimePictureBox5
            // 
            this.SlimePictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SlimePictureBox5.Location = new System.Drawing.Point(616, 325);
            this.SlimePictureBox5.Name = "SlimePictureBox5";
            this.SlimePictureBox5.Size = new System.Drawing.Size(64, 64);
            this.SlimePictureBox5.TabIndex = 11;
            this.SlimePictureBox5.TabStop = false;
            this.SlimePictureBox5.Paint += new System.Windows.Forms.PaintEventHandler(this.SlimePictureBox5_Paint);
            // 
            // SlimePictureBox6
            // 
            this.SlimePictureBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SlimePictureBox6.Location = new System.Drawing.Point(686, 325);
            this.SlimePictureBox6.Name = "SlimePictureBox6";
            this.SlimePictureBox6.Size = new System.Drawing.Size(64, 64);
            this.SlimePictureBox6.TabIndex = 12;
            this.SlimePictureBox6.TabStop = false;
            this.SlimePictureBox6.Paint += new System.Windows.Forms.PaintEventHandler(this.SlimePictureBox6_Paint);
            // 
            // SlimePictureBox7
            // 
            this.SlimePictureBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SlimePictureBox7.Location = new System.Drawing.Point(756, 325);
            this.SlimePictureBox7.Name = "SlimePictureBox7";
            this.SlimePictureBox7.Size = new System.Drawing.Size(64, 64);
            this.SlimePictureBox7.TabIndex = 13;
            this.SlimePictureBox7.TabStop = false;
            this.SlimePictureBox7.Paint += new System.Windows.Forms.PaintEventHandler(this.SlimePictureBox7_Paint);
            // 
            // SlimePictureBox8
            // 
            this.SlimePictureBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SlimePictureBox8.Location = new System.Drawing.Point(826, 325);
            this.SlimePictureBox8.Name = "SlimePictureBox8";
            this.SlimePictureBox8.Size = new System.Drawing.Size(64, 64);
            this.SlimePictureBox8.TabIndex = 14;
            this.SlimePictureBox8.TabStop = false;
            this.SlimePictureBox8.Paint += new System.Windows.Forms.PaintEventHandler(this.SlimePictureBox8_Paint);
            // 
            // SlimePictureBox9
            // 
            this.SlimePictureBox9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SlimePictureBox9.Location = new System.Drawing.Point(896, 325);
            this.SlimePictureBox9.Name = "SlimePictureBox9";
            this.SlimePictureBox9.Size = new System.Drawing.Size(64, 64);
            this.SlimePictureBox9.TabIndex = 15;
            this.SlimePictureBox9.TabStop = false;
            this.SlimePictureBox9.Paint += new System.Windows.Forms.PaintEventHandler(this.SlimePictureBox9_Paint);
            // 
            // QueueArrayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1157, 770);
            this.Controls.Add(this.SlimePictureBox9);
            this.Controls.Add(this.SlimePictureBox8);
            this.Controls.Add(this.SlimePictureBox7);
            this.Controls.Add(this.SlimePictureBox6);
            this.Controls.Add(this.SlimePictureBox5);
            this.Controls.Add(this.SlimePictureBox4);
            this.Controls.Add(this.SlimePictureBox3);
            this.Controls.Add(this.SlimePictureBox2);
            this.Controls.Add(this.SlimePictureBox1);
            this.Controls.Add(this.SlimePictureBox0);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QueueArrayForm";
            this.ShowIcon = false;
            this.Text = "queueArrayForm";
            this.Load += new System.EventHandler(this.QueueArrayForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SlimePictureBox0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlimePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlimePictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlimePictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlimePictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlimePictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlimePictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlimePictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlimePictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlimePictureBox9)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button EnqueueBtn;
        private System.Windows.Forms.Button DequeueBtn;
        private System.Windows.Forms.TextBox enqueueTxt;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Timer AnimationTimer;
        private System.Windows.Forms.Button DisplayQueueBtn;
        private System.Windows.Forms.PictureBox SlimePictureBox0;
        private System.Windows.Forms.PictureBox SlimePictureBox1;
        private System.Windows.Forms.PictureBox SlimePictureBox2;
        private System.Windows.Forms.PictureBox SlimePictureBox3;
        private System.Windows.Forms.PictureBox SlimePictureBox4;
        private System.Windows.Forms.PictureBox SlimePictureBox5;
        private System.Windows.Forms.PictureBox SlimePictureBox6;
        private System.Windows.Forms.PictureBox SlimePictureBox7;
        private System.Windows.Forms.PictureBox SlimePictureBox8;
        private System.Windows.Forms.PictureBox SlimePictureBox9;
    }
}