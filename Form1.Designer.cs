﻿namespace SnakeGame
{
    partial class Form1
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
            this.StartBttn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GridSizeTxtBox = new System.Windows.Forms.TextBox();
            this.MilisecondsTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // StartBttn
            // 
            this.StartBttn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StartBttn.Location = new System.Drawing.Point(1, 2);
            this.StartBttn.Name = "StartBttn";
            this.StartBttn.Size = new System.Drawing.Size(107, 22);
            this.StartBttn.TabIndex = 0;
            this.StartBttn.Text = "Start";
            this.StartBttn.UseVisualStyleBackColor = true;
            this.StartBttn.Click += new System.EventHandler(this.StartBttn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(1, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(799, 419);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Grid Size: ";
            // 
            // GridSizeTxtBox
            // 
            this.GridSizeTxtBox.Location = new System.Drawing.Point(189, 4);
            this.GridSizeTxtBox.Name = "GridSizeTxtBox";
            this.GridSizeTxtBox.Size = new System.Drawing.Size(76, 20);
            this.GridSizeTxtBox.TabIndex = 3;
            this.GridSizeTxtBox.Text = "25";
            this.GridSizeTxtBox.TextChanged += new System.EventHandler(this.GridSizeTxtBox_TextChanged);
            // 
            // MilisecondsTxtBox
            // 
            this.MilisecondsTxtBox.Location = new System.Drawing.Point(437, 4);
            this.MilisecondsTxtBox.Name = "MilisecondsTxtBox";
            this.MilisecondsTxtBox.Size = new System.Drawing.Size(83, 20);
            this.MilisecondsTxtBox.TabIndex = 5;
            this.MilisecondsTxtBox.Text = "1000";
            this.MilisecondsTxtBox.TextChanged += new System.EventHandler(this.MilisecondsTxtBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(283, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Milisecond between updates: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MilisecondsTxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GridSizeTxtBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.StartBttn);
            this.Name = "Form1";
            this.Text = "Snake";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartBttn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox GridSizeTxtBox;
        private System.Windows.Forms.TextBox MilisecondsTxtBox;
        private System.Windows.Forms.Label label2;
    }
}

