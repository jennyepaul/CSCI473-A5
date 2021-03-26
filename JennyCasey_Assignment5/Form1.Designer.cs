
namespace JennyCasey_Assignment5
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.newGameButton = new System.Windows.Forms.Button();
            this.gameDifficultyDropDown = new System.Windows.Forms.ComboBox();
            this.difficultyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.rowSumBox = new System.Windows.Forms.PictureBox();
            this.columnSumBox = new System.Windows.Forms.PictureBox();
            this.diagnal1SumBox = new System.Windows.Forms.PictureBox();
            this.diagnal2SumBox = new System.Windows.Forms.PictureBox();
            this.PauseResume_Button = new System.Windows.Forms.Button();
            this.tmrCounter = new System.Windows.Forms.Timer(this.components);
            this.Timer_Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowSumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnSumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnal1SumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnal2SumBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1371, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(167, 63);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1030, 503);
            this.canvas.TabIndex = 1;
            this.canvas.TabStop = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            // 
            // newGameButton
            // 
            this.newGameButton.Location = new System.Drawing.Point(139, 0);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(145, 40);
            this.newGameButton.TabIndex = 2;
            this.newGameButton.Text = "Start New Puzzle";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.newGameButton_MouseDown);
            this.newGameButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.newGameButton_MouseUp);
            // 
            // gameDifficultyDropDown
            // 
            this.gameDifficultyDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameDifficultyDropDown.FormattingEnabled = true;
            this.gameDifficultyDropDown.Location = new System.Drawing.Point(12, 2);
            this.gameDifficultyDropDown.Name = "gameDifficultyDropDown";
            this.gameDifficultyDropDown.Size = new System.Drawing.Size(121, 28);
            this.gameDifficultyDropDown.TabIndex = 3;
            this.difficultyToolTip.SetToolTip(this.gameDifficultyDropDown, "Please select a difficulty for the puzzle!");
            this.gameDifficultyDropDown.SelectedIndexChanged += new System.EventHandler(this.gameDifficultyDropDown_SelectedIndexChanged);
            // 
            // difficultyToolTip
            // 
            this.difficultyToolTip.AutomaticDelay = 100;
            // 
            // rowSumBox
            // 
            this.rowSumBox.Location = new System.Drawing.Point(1199, 63);
            this.rowSumBox.Name = "rowSumBox";
            this.rowSumBox.Size = new System.Drawing.Size(116, 503);
            this.rowSumBox.TabIndex = 4;
            this.rowSumBox.TabStop = false;
            this.rowSumBox.Paint += new System.Windows.Forms.PaintEventHandler(this.rowSumBox_Paint);
            // 
            // columnSumBox
            // 
            this.columnSumBox.Location = new System.Drawing.Point(163, 572);
            this.columnSumBox.Name = "columnSumBox";
            this.columnSumBox.Size = new System.Drawing.Size(1034, 82);
            this.columnSumBox.TabIndex = 5;
            this.columnSumBox.TabStop = false;
            this.columnSumBox.Paint += new System.Windows.Forms.PaintEventHandler(this.columnSumBox_Paint);
            // 
            // diagnal1SumBox
            // 
            this.diagnal1SumBox.Location = new System.Drawing.Point(1203, 12);
            this.diagnal1SumBox.Name = "diagnal1SumBox";
            this.diagnal1SumBox.Size = new System.Drawing.Size(112, 50);
            this.diagnal1SumBox.TabIndex = 6;
            this.diagnal1SumBox.TabStop = false;
            this.diagnal1SumBox.Paint += new System.Windows.Forms.PaintEventHandler(this.diagnal1SumBox_Paint);
            // 
            // diagnal2SumBox
            // 
            this.diagnal2SumBox.Location = new System.Drawing.Point(1199, 560);
            this.diagnal2SumBox.Name = "diagnal2SumBox";
            this.diagnal2SumBox.Size = new System.Drawing.Size(116, 59);
            this.diagnal2SumBox.TabIndex = 7;
            this.diagnal2SumBox.TabStop = false;
            this.diagnal2SumBox.Paint += new System.Windows.Forms.PaintEventHandler(this.diagnal2SumBox_Paint);
            // 
            // PauseResume_Button
            // 
            this.PauseResume_Button.Location = new System.Drawing.Point(327, 2);
            this.PauseResume_Button.Name = "PauseResume_Button";
            this.PauseResume_Button.Size = new System.Drawing.Size(117, 38);
            this.PauseResume_Button.TabIndex = 8;
            this.PauseResume_Button.Text = "Pause";
            this.PauseResume_Button.UseVisualStyleBackColor = true;
            this.PauseResume_Button.Click += new System.EventHandler(this.PauseResume_Button_Click);
            // 
            // tmrCounter
            // 
            this.tmrCounter.Interval = 1000;
            this.tmrCounter.Tick += new System.EventHandler(this.tmrCounter_Tick);
            // 
            // Timer_Label
            // 
            this.Timer_Label.AutoSize = true;
            this.Timer_Label.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Timer_Label.Location = new System.Drawing.Point(477, 9);
            this.Timer_Label.Name = "Timer_Label";
            this.Timer_Label.Size = new System.Drawing.Size(0, 31);
            this.Timer_Label.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 698);
            this.Controls.Add(this.Timer_Label);
            this.Controls.Add(this.PauseResume_Button);
            this.Controls.Add(this.diagnal2SumBox);
            this.Controls.Add(this.diagnal1SumBox);
            this.Controls.Add(this.columnSumBox);
            this.Controls.Add(this.rowSumBox);
            this.Controls.Add(this.gameDifficultyDropDown);
            this.Controls.Add(this.newGameButton);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Jenny and Casey\'s Sudoku Game";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowSumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnSumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnal1SumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnal2SumBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.ComboBox gameDifficultyDropDown;
        private System.Windows.Forms.ToolTip difficultyToolTip;
        private System.Windows.Forms.PictureBox rowSumBox;
        private System.Windows.Forms.PictureBox columnSumBox;
        private System.Windows.Forms.PictureBox diagnal1SumBox;
        private System.Windows.Forms.PictureBox diagnal2SumBox;
        private System.Windows.Forms.Button PauseResume_Button;
        private System.Windows.Forms.Timer tmrCounter;
        private System.Windows.Forms.Label Timer_Label;
    }
}

