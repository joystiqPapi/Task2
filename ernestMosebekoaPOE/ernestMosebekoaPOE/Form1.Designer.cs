﻿namespace ernestMosebekoaPOE
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
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.lblTimer = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMap = new System.Windows.Forms.Label();
            this.redTypeOfUnits = new System.Windows.Forms.RichTextBox();
            this.tmrTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(534, 54);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(534, 92);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 1;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(531, 25);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(13, 13);
            this.lblTimer.TabIndex = 2;
            this.lblTimer.Text = "0";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblMap);
            this.panel1.Location = new System.Drawing.Point(54, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 310);
            this.panel1.TabIndex = 3;
            // 
            // lblMap
            // 
            this.lblMap.AutoSize = true;
            this.lblMap.Location = new System.Drawing.Point(18, 11);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(35, 13);
            this.lblMap.TabIndex = 0;
            this.lblMap.Text = "label2";
            // 
            // redTypeOfUnits
            // 
            this.redTypeOfUnits.Location = new System.Drawing.Point(474, 190);
            this.redTypeOfUnits.Name = "redTypeOfUnits";
            this.redTypeOfUnits.Size = new System.Drawing.Size(290, 139);
            this.redTypeOfUnits.TabIndex = 0;
            this.redTypeOfUnits.Text = "";
            // 
            // tmrTimer
            // 
            this.tmrTimer.Interval = 1000;
            this.tmrTimer.Tick += new System.EventHandler(this.timerTrigger);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.redTypeOfUnits);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox redTypeOfUnits;
        public System.Windows.Forms.Label lblMap;
        public System.Windows.Forms.Timer tmrTimer;
    }
}

