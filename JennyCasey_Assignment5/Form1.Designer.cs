
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
            this.PauseResume_Button = new System.Windows.Forms.Button();
            this.Timer_Label = new System.Windows.Forms.Label();
            this.tmrCounter = new System.Windows.Forms.Timer(this.components);
            this.Complete_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
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
            this.canvas.Location = new System.Drawing.Point(171, 92);
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
            // PauseResume_Button
            // 
            this.PauseResume_Button.Location = new System.Drawing.Point(348, 0);
            this.PauseResume_Button.Name = "PauseResume_Button";
            this.PauseResume_Button.Size = new System.Drawing.Size(108, 40);
            this.PauseResume_Button.TabIndex = 4;
            this.PauseResume_Button.Text = "Pause";
            this.PauseResume_Button.UseVisualStyleBackColor = true;
            this.PauseResume_Button.Click += new System.EventHandler(this.PauseResume_Button_Click);
            // 
            // Timer_Label
            // 
            this.Timer_Label.AutoSize = true;
            this.Timer_Label.Location = new System.Drawing.Point(515, 13);
            this.Timer_Label.Name = "Timer_Label";
            this.Timer_Label.Size = new System.Drawing.Size(0, 17);
            this.Timer_Label.TabIndex = 5;
            // 
            // tmrCounter
            // 
            this.tmrCounter.Interval = 1000;
            this.tmrCounter.Tick += new System.EventHandler(this.tmrCounter_Tick);
            // 
            // Complete_Button
            // 
            this.Complete_Button.Location = new System.Drawing.Point(922, 2);
            this.Complete_Button.Name = "Complete_Button";
            this.Complete_Button.Size = new System.Drawing.Size(114, 39);
            this.Complete_Button.TabIndex = 6;
            this.Complete_Button.Text = "Complete";
            this.Complete_Button.UseVisualStyleBackColor = true;
            this.Complete_Button.Click += new System.EventHandler(this.Complete_Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 698);
            this.Controls.Add(this.Complete_Button);
            this.Controls.Add(this.Timer_Label);
            this.Controls.Add(this.PauseResume_Button);
            this.Controls.Add(this.gameDifficultyDropDown);
            this.Controls.Add(this.newGameButton);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Jenny and Casey\'s Sudoku Game";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.ComboBox gameDifficultyDropDown;
        private System.Windows.Forms.ToolTip difficultyToolTip;
        private System.Windows.Forms.Button PauseResume_Button;
        private System.Windows.Forms.Label Timer_Label;
        private System.Windows.Forms.Timer tmrCounter;
        private System.Windows.Forms.Button Complete_Button;
    }
}

