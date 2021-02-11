namespace Ksu.Cis300.Othello
{
    partial class UserInterface
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
            this.uxStatusBar = new System.Windows.Forms.StatusStrip();
            this.uxStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.uxToolBar = new System.Windows.Forms.ToolStrip();
            this.uxBoard = new System.Windows.Forms.FlowLayoutPanel();
            this.uxSquareLocation = new System.Windows.Forms.ToolTip(this.components);
            this.uxStatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxStatusBar
            // 
            this.uxStatusBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.uxStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxStatus});
            this.uxStatusBar.Location = new System.Drawing.Point(0, 290);
            this.uxStatusBar.Name = "uxStatusBar";
            this.uxStatusBar.Padding = new System.Windows.Forms.Padding(2, 0, 14, 0);
            this.uxStatusBar.Size = new System.Drawing.Size(494, 32);
            this.uxStatusBar.TabIndex = 4;
            this.uxStatusBar.Text = "statusStrip1";
            // 
            // uxStatus
            // 
            this.uxStatus.Name = "uxStatus";
            this.uxStatus.Size = new System.Drawing.Size(60, 25);
            this.uxStatus.Text = "Status";
            // 
            // uxToolBar
            // 
            this.uxToolBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.uxToolBar.Location = new System.Drawing.Point(0, 0);
            this.uxToolBar.Name = "uxToolBar";
            this.uxToolBar.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.uxToolBar.Size = new System.Drawing.Size(494, 28);
            this.uxToolBar.TabIndex = 6;
            this.uxToolBar.Text = "toolStrip1";
            // 
            // uxBoard
            // 
            this.uxBoard.BackColor = System.Drawing.Color.Black;
            this.uxBoard.Location = new System.Drawing.Point(0, 42);
            this.uxBoard.Name = "uxBoard";
            this.uxBoard.Size = new System.Drawing.Size(208, 148);
            this.uxBoard.TabIndex = 5;
            // 
            // uxSquareLocation
            // 
            this.uxSquareLocation.ShowAlways = true;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(494, 322);
            this.Controls.Add(this.uxStatusBar);
            this.Controls.Add(this.uxToolBar);
            this.Controls.Add(this.uxBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "UserInterface";
            this.Text = "Othello";
            this.uxStatusBar.ResumeLayout(false);
            this.uxStatusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip uxStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel uxStatus;
        private System.Windows.Forms.ToolStrip uxToolBar;
        private System.Windows.Forms.FlowLayoutPanel uxBoard;
        private System.Windows.Forms.ToolTip uxSquareLocation;
    }
}

