
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1371, 24);
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
            this.newGameButton.Size = new System.Drawing.Size(127, 32);
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
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(932, 448);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(427, 215);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 698);
            this.Controls.Add(this.richTextBox1);
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
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

