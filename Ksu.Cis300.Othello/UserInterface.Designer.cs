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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInterface));
            this.uxStatusBar = new System.Windows.Forms.StatusStrip();
            this.uxStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.uxToolBar = new System.Windows.Forms.ToolStrip();
            this.uxNewGame = new System.Windows.Forms.ToolStripButton();
            this.uxPass = new System.Windows.Forms.ToolStripButton();
            this.uxUndo = new System.Windows.Forms.ToolStripButton();
            this.uxWhiteScore = new System.Windows.Forms.ToolStripTextBox();
            this.uxWhiteLabel = new System.Windows.Forms.ToolStripLabel();
            this.uxBlackScore = new System.Windows.Forms.ToolStripTextBox();
            this.uxBlackLabel = new System.Windows.Forms.ToolStripLabel();
            this.uxBoard = new System.Windows.Forms.FlowLayoutPanel();
            this.uxSquareLocation = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.uxStatusBar.SuspendLayout();
            this.uxToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxStatusBar
            // 
            this.uxStatusBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.uxStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxStatus});
            this.uxStatusBar.Location = new System.Drawing.Point(0, 418);
            this.uxStatusBar.Name = "uxStatusBar";
            this.uxStatusBar.Padding = new System.Windows.Forms.Padding(2, 0, 12, 0);
            this.uxStatusBar.Size = new System.Drawing.Size(716, 26);
            this.uxStatusBar.TabIndex = 4;
            this.uxStatusBar.Text = "statusStrip1";
            // 
            // uxStatus
            // 
            this.uxStatus.Name = "uxStatus";
            this.uxStatus.Size = new System.Drawing.Size(49, 20);
            this.uxStatus.Text = "Status";
            // 
            // uxToolBar
            // 
            this.uxToolBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.uxToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxNewGame,
            this.uxPass,
            this.uxUndo,
            this.uxWhiteScore,
            this.uxWhiteLabel,
            this.uxBlackScore,
            this.uxBlackLabel});
            this.uxToolBar.Location = new System.Drawing.Point(0, 0);
            this.uxToolBar.Name = "uxToolBar";
            this.uxToolBar.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.uxToolBar.Size = new System.Drawing.Size(716, 27);
            this.uxToolBar.TabIndex = 6;
            this.uxToolBar.Text = "toolStrip1";
            // 
            // uxNewGame
            // 
            this.uxNewGame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.uxNewGame.Image = ((System.Drawing.Image)(resources.GetObject("uxNewGame.Image")));
            this.uxNewGame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uxNewGame.Name = "uxNewGame";
            this.uxNewGame.Size = new System.Drawing.Size(86, 24);
            this.uxNewGame.Text = "New Game";
            this.uxNewGame.Click += new System.EventHandler(this.uxNewGame_Click);
            // 
            // uxPass
            // 
            this.uxPass.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.uxPass.Image = ((System.Drawing.Image)(resources.GetObject("uxPass.Image")));
            this.uxPass.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uxPass.Name = "uxPass";
            this.uxPass.Size = new System.Drawing.Size(40, 24);
            this.uxPass.Text = "Pass";
            this.uxPass.Click += new System.EventHandler(this.uxPass_Click);
            // 
            // uxUndo
            // 
            this.uxUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.uxUndo.Image = ((System.Drawing.Image)(resources.GetObject("uxUndo.Image")));
            this.uxUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uxUndo.Name = "uxUndo";
            this.uxUndo.Size = new System.Drawing.Size(49, 24);
            this.uxUndo.Text = "Undo";
            this.uxUndo.Click += new System.EventHandler(this.uxUndo_Click);
            // 
            // uxWhiteScore
            // 
            this.uxWhiteScore.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.uxWhiteScore.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.uxWhiteScore.Name = "uxWhiteScore";
            this.uxWhiteScore.ReadOnly = true;
            this.uxWhiteScore.Size = new System.Drawing.Size(100, 27);
            this.uxWhiteScore.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // uxWhiteLabel
            // 
            this.uxWhiteLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.uxWhiteLabel.Name = "uxWhiteLabel";
            this.uxWhiteLabel.Size = new System.Drawing.Size(51, 24);
            this.uxWhiteLabel.Text = "White:";
            // 
            // uxBlackScore
            // 
            this.uxBlackScore.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.uxBlackScore.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.uxBlackScore.Name = "uxBlackScore";
            this.uxBlackScore.ReadOnly = true;
            this.uxBlackScore.Size = new System.Drawing.Size(100, 27);
            this.uxBlackScore.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // uxBlackLabel
            // 
            this.uxBlackLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.uxBlackLabel.Name = "uxBlackLabel";
            this.uxBlackLabel.Size = new System.Drawing.Size(47, 24);
            this.uxBlackLabel.Text = "Black:";
            // 
            // uxBoard
            // 
            this.uxBoard.BackColor = System.Drawing.Color.Black;
            this.uxBoard.Location = new System.Drawing.Point(0, 34);
            this.uxBoard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uxBoard.Name = "uxBoard";
            this.uxBoard.Size = new System.Drawing.Size(185, 118);
            this.uxBoard.TabIndex = 5;
            // 
            // uxSquareLocation
            // 
            this.uxSquareLocation.ShowAlways = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Location = new System.Drawing.Point(0, 27);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(716, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(716, 444);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.uxStatusBar);
            this.Controls.Add(this.uxToolBar);
            this.Controls.Add(this.uxBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "UserInterface";
            this.Text = "Othello";
            this.uxStatusBar.ResumeLayout(false);
            this.uxStatusBar.PerformLayout();
            this.uxToolBar.ResumeLayout(false);
            this.uxToolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip uxStatusBar;
        private System.Windows.Forms.ToolStripStatusLabel uxStatus;
        private System.Windows.Forms.ToolStrip uxToolBar;
        private System.Windows.Forms.FlowLayoutPanel uxBoard;
        private System.Windows.Forms.ToolTip uxSquareLocation;
        private System.Windows.Forms.ToolStripButton uxNewGame;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton uxPass;
        private System.Windows.Forms.ToolStripButton uxUndo;
        private System.Windows.Forms.ToolStripTextBox uxWhiteScore;
        private System.Windows.Forms.ToolStripLabel uxWhiteLabel;
        private System.Windows.Forms.ToolStripTextBox uxBlackScore;
        private System.Windows.Forms.ToolStripLabel uxBlackLabel;
    }
}

