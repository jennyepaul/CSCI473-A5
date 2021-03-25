using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace JennyCasey_Assignment5
{
    public partial class Form1 : Form
    {
        private static bool isEasyGame = false;
        private static bool isMediumGame = false;
        private static bool isHardGame = false;
        private static bool isDown = false;
        private static bool isBoardLoaded = false;
        private static bool isEasyBoard = false;

        private static int row1EasySum = 0;
        private static int row2EasySum = 0;
        private static int row3EasySum = 0;

        private static int diagnal1EasySum = 0;
        private static int diagnal2EasySum = 0;


        public static int testerTotal;

        private static int col1EasySum = 0;
        private static int col2EasySum = 0;
        private static int col3EasySum = 0;

        private static List<TextBox> generatedEasyTextboxes = new List<TextBox>();
        private static List<TextBox> generatedMedTextboxes = new List<TextBox>();
        private static List<TextBox> generatedHardTextboxes = new List<TextBox>();
        private static List<string> gameStatsEasy1 = new List<string>();
        private static List<string> gameStatsMedium1 = new List<string>();
        private static List<string> gameStatsHard1 = new List<string>();

        public static List<char> gameValuesEasy1 = new List<char>();
        public static List<char> gameValuesMedium1 = new List<char>();
        public static List<char> gameValuesHard1 = new List<char>();


        public static int L;
        public static int W;

        public Form1()
        {
            InitializeComponent();

            //set the length and width of the canvas so less to type later
            L = canvas.Height;
            W = canvas.Width;


            //add options to the drop down
            gameDifficultyDropDown.Items.Add("Easy");
            gameDifficultyDropDown.Items.Add("Medium");
            gameDifficultyDropDown.Items.Add("Hard");
        }


        private void gameDifficultyDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            //NOTE --> WHENEVER THE USER CHANGES TO ANOTHER GAME, SOME PARTS OF THE LINES ARE FADED FROM WHERE OLD TEXTBOX USED TO BE?
            // TRY AND FIX THIS!!


            //depending what difficulty the user entered, we need to draw the corresponding playing field
            if (gameDifficultyDropDown.Text == "Easy")
            {
                isEasyGame = true;
                resetMediumPuzzleTextboxes();
                resetHardPuzzleTextboxes();
            }
            else if (gameDifficultyDropDown.Text == "Medium")
            {
                isMediumGame = true;
                resetEasyPuzzleTextboxes();
                resetHardPuzzleTextboxes();
            }
            else if (gameDifficultyDropDown.Text == "Hard")
            {
                isHardGame = true;
                resetEasyPuzzleTextboxes();
                resetMediumPuzzleTextboxes();
            }
        }
        private void canvas_Paint(object sender, PaintEventArgs e)
        {

            string gameRecordEasy1, gameRecordMedium1, gameRecordHard1;
            //read in the info from an easy 1  file and store into a list
            using (StreamReader inFile = new StreamReader("../../easy/e1.txt"))
            {
                while ((gameRecordEasy1 = inFile.ReadLine()) != null)
                {
                    gameStatsEasy1.Add(gameRecordEasy1);
                }
            }
            //read in the info from an medium 1  file and store into a list
            using (StreamReader inFile = new StreamReader("../../medium/m1.txt"))
            {
                while ((gameRecordMedium1 = inFile.ReadLine()) != null)
                {
                    gameStatsMedium1.Add(gameRecordMedium1);
                }
            }
            //read in the info from an hard 1  file and store into a list
            using (StreamReader inFile = new StreamReader("../../hard/h1.txt"))
            {
                while ((gameRecordHard1 = inFile.ReadLine()) != null)
                {
                    gameStatsHard1.Add(gameRecordHard1);
                }
            }

            //add the individual easy difficulty alues to a list to iterate through later
            for (int n = 0; n < 3; n++)
            {
                for (int j = 0; j < 3; j++)
                {
                    gameValuesEasy1.Add(gameStatsEasy1[n][j]);

                }
            }
            //add the individual medium values to a list to iterate through later
            for (int n = 0; n < 5; n++)
            {
                for (int j = 0; j < 5; j++)
                {
                    gameValuesMedium1.Add(gameStatsMedium1[n][j]);
                }
            }

            //add the individual hard values to a list to iterate through later
            for (int n = 0; n < 7; n++)
            {
                for (int j = 0; j < 7; j++)
                {
                    gameValuesHard1.Add(gameStatsHard1[n][j]);
                }
            }

            Graphics graphics = e.Graphics;
            if (isDown)
            {
                //row1SumEasyText.Text = row1EasySum;
                //print the current totals (IE- any blanks are not added to the sum, only visible values)
                //rowSumBox.Refresh();
                //columnSumBox.Refresh();

                using (Pen gamePen = new Pen(Color.Black))
                {
                    gamePen.Width = 5;

                    //draw the perimeter lines
                    graphics.DrawLine(gamePen, 0, 0, W, 0);
                    graphics.DrawLine(gamePen, 0, L, W, L);

                    graphics.DrawLine(gamePen, 0, 0, 0, L);
                    graphics.DrawLine(gamePen, W, 0, W, L);

                    //if user wanted to play an easy game, then paint a 3x3 
                    if (isEasyGame)
                    {
                        isEasyBoard = true;
                        //draw our vertical lines 
                        graphics.DrawLine(gamePen, W / 3, 0, W / 3, L);
                        graphics.DrawLine(gamePen, (2 * W / 3), 0, (2 * W / 3), L);

                        //draw horizontal lines
                        graphics.DrawLine(gamePen, 0, (L / 3), W, (L / 3));
                        graphics.DrawLine(gamePen, 0, (2 * L / 3), W, (2 * L / 3));

                        //PointF point;
                        int x, y;
                        int[] xPoints = new int[6];
                        int[] yPoints = new int[6];

                        //we'll have 10 points to place either a textbox or a value on the board
                        PointF[] easyGamePoints = new PointF[10];
                        int l = 0;
                        int b = 0;

                        //set our array of x values being 1, 3, 
                        //need this to multiply by width / 10 since we want the middle of each block
                        //to have the label/textbox
                        for (int length = 1; length < 6; length += 2)
                        {
                            x = length;
                            xPoints[l] = x;

                            l++;
                        }
                        //set out array of y values being 1, 3, 5
                        //need this to multiply by length / 10 since we want the middle of each block
                        //to have the label/textbox
                        for (int width = 1; width < 6; width += 2)
                        {
                            y = width;
                            yPoints[b] = y;

                            b++;
                        }
                        int c = 0;
                        int xSub = c;
                        int ySub = 0;

                        for (c = 0; c < 9; c++)
                        {
                            if (gameValuesEasy1[c] != '0')
                            {
                                using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                                {
                                    //we have a value so print that to the board
                                    PointF point = new PointF(xPoints[xSub] * (W / 6), yPoints[ySub] * (L / 6));
                                    e.Graphics.DrawString(gameValuesEasy1[c].ToString(), font1, Brushes.Black, point);
                                }

                            }
                            else
                            {
                                Point point2 = new Point(xPoints[xSub] * (W / 6) - 10, yPoints[ySub] * (L / 6));
                                TextBox txt = new TextBox();
                                txt.Name = "easyPuzzleCell" + c;
                                txt.Text = "";
                                txt.Location = point2;
                                txt.Height = 30;
                                txt.Width = 30;
                                txt.Font = new Font(txt.Font.FontFamily, 14);
                                //txt.Font.Size = 24
                                canvas.Controls.Add(txt);
                                generatedEasyTextboxes.Add(txt);
                                txt.TextChanged += numberInput;
                            }
                            //increment the x subscript
                            xSub++;
                            //if the subcript is at 3, we finished a row, so reset the xsubscript
                            //and increment the y since we are going down to another row
                            if (xSub == 3)
                            {
                                xSub = 0;
                                ySub++;
                            }
                        }
                        
                    }
                    else if (isMediumGame)
                    {
                        //draw our vertical lines s
                        graphics.DrawLine(gamePen, W / 5, 0, W / 5, L);
                        for (int i = 2; i < 5; i++)
                        {
                            graphics.DrawLine(gamePen, (i * W / 5), 0, (i * W / 5), L);
                        }

                        //draw horizontal lines
                        graphics.DrawLine(gamePen, 0, (L / 5), W, (L / 5));
                        for (int i = 2; i < 5; i++)
                        {
                            graphics.DrawLine(gamePen, 0, (i * L / 5), W, (i * L / 5));
                        }

                        //PointF point;
                        int x, y;
                        int[] xPoints = new int[6];
                        int[] yPoints = new int[6];

                        //we'll have 26 points to place either a textbox or a value on the board
                        PointF[] medGamePoints = new PointF[26];
                        int l = 0;
                        int b = 0;

                        //set our array of x values being 1, 3, 5, 7, 9 
                        //need this to multiply by width / 10 since we want the middle of each block
                        //to have the label/textbox
                        for (int length = 1; length < 10; length += 2)
                        {
                            x = length;
                            xPoints[l] = x;

                            l++;
                        }
                        //set out array of y values being 1, 3, 5, 7, 9 
                        //need this to multiply by length / 10 since we want the middle of each block
                        //to have the label/textbox
                        for (int width = 1; width < 10; width += 2)
                        {
                            y = width;
                            yPoints[b] = y;

                            b++;
                        }
                        int c = 0;
                        int xSub = c;
                        int ySub = 0;
                        //go through the char values in the list, and if they are not 0, we can add to the board
                        //if they are zero, we need to create a text box so that the user can enter their guesses in
                        for (c = 0; c < 25; c++)
                        {
                            if (gameValuesMedium1[c] != '0')
                            {
                                using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                                {
                                    //we have a value so print that to the board
                                    PointF point = new PointF(xPoints[xSub] * (W / 10), yPoints[ySub] * (L / 10));
                                    e.Graphics.DrawString(gameValuesMedium1[c].ToString(), font1, Brushes.Black, point);
                                }
                            }
                            else
                            {
                                Point point2 = new Point(xPoints[xSub] * (W / 10) - 10, yPoints[ySub] * (L / 10));
                                TextBox txt = new TextBox();
                                txt.Name = "medPuzzleCell" + c;
                                txt.Text = "";
                                txt.Location = point2;
                                txt.Height = 30;
                                txt.Width = 30;
                                txt.Font = new Font(txt.Font.FontFamily, 14);
                                //txt.Font.Size = 24
                                canvas.Controls.Add(txt);
                                generatedMedTextboxes.Add(txt);
                                txt.TextChanged += numberInput;
                            }
                            //increment the x subscript
                            xSub++;
                            //if the subcript is at 5, we finished a row, so reset the xsubscript
                            //and increment the y since we are going down to another row
                            if (xSub == 5)
                            {
                                xSub = 0;
                                ySub++;
                            }
                        }
                    }
                    else if (isHardGame)
                    {
                        //draw our vertical lines 
                        graphics.DrawLine(gamePen, W / 7, 0, W / 7, L);
                        for (int i = 2; i < 7; i++)
                        {
                            graphics.DrawLine(gamePen, (i * W / 7), 0, (i * W / 7), L);
                        }

                        //draw horizontal lines
                        graphics.DrawLine(gamePen, 0, (L / 7), W, (L / 7));
                        for (int i = 2; i < 7; i++)
                        {
                            graphics.DrawLine(gamePen, 0, (i * L / 7), W, (i * L / 7));
                        }

                        PointF pointF1;
                        int x, y;
                        int[] xPoints = new int[8];
                        int[] yPoints = new int[8];

                        //we'll have 49 points to place either a textbox or a value on the board
                        PointF[] hardGamePoints = new PointF[50];
                        int l = 0;
                        int b = 0;

                        //set our array of x values being 1, 3, 5, 7, 9, 11, 13
                        //need this to multiply by width / 14 since we want the middle of each block
                        //to have the label/textbox
                        for (int length = 1; length < 15; length += 2)
                        {
                            x = length;
                            xPoints[l] = x;

                            l++;
                        }
                        //set out array of y values being 1, 3, 5, 7, 9, 11, 13
                        //need this to multiply by length / 14 since we want the middle of each block
                        //to have the label/textbox
                        for (int width = 1; width < 15; width += 2)
                        {
                            y = width;
                            yPoints[b] = y;

                            b++;
                        }
                        int z = 0;
                        int xSub = z;
                        int ySub = 0;
                        //go through the char list to populate values into board
                        for (z = 0; z < 49; z++)
                        {
                            //if the value is not a zero, then we want to print it on the board
                            if (gameValuesHard1[z] != '0')
                            {
                                using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                                {
                                    //we have a value so print that to the board
                                    PointF point = new PointF(xPoints[xSub] * (W / 14), yPoints[ySub] * (L / 14));
                                    e.Graphics.DrawString(gameValuesHard1[z].ToString(), font1, Brushes.Black, point);

                                }
                            }
                            //else it IS a 0, so we want to allow the user to guess what the value could be
                            else
                            {

                                //it is zero, so user has to figure out what the value is, so we need to add a textbox
                                Point point2 = new Point(xPoints[xSub] * (W / 14), yPoints[ySub] * (L / 14));
                                TextBox txt = new TextBox();
                                txt.Name = "hardPuzzleCell" + z;
                                txt.Text = "";
                                txt.Location = point2;
                                txt.Height = 30;
                                txt.Width = 30;
                                txt.Font = new Font(txt.Font.FontFamily, 14);
                                canvas.Controls.Add(txt);
                                generatedHardTextboxes.Add(txt);

                                //add event when the user enters a number
                                txt.TextChanged += numberInput;


                            }
                            //increment the x subscript
                            xSub++;
                            //if the subcript is at 7, we finished a row, so reset the xsubscript
                            //and increment the y since we are going down to another row
                            if (xSub == 7)
                            {
                                xSub = 0;
                                ySub++;
                            }
                        }
                    }
                }
            }
            isBoardLoaded = true;

        }

        private void calculateInitialEasyRowSums(List<char> list1)
        {
            int val;

            //go through the easy board
            for (int i = 0; i < 3; i++)
            {
                val = int.Parse(list1[i].ToString());
                row1EasySum += val;
            }

            for (int i = 3; i < 6; i++)
            {
                val = int.Parse(list1[i].ToString());
                row2EasySum += val;
            }

            for (int i = 6; i < 9; i++)
            {
                val = int.Parse(list1[i].ToString());
                row3EasySum += val;
            }

        }
        private void calculateInitialEasyColSums(List<char> list1)
        {
            int val;

            //go through the easy board
            for (int i = 0; i < 9; i += 3)
            {
                val = int.Parse(list1[i].ToString());
                col1EasySum += val;
            }

            for (int i = 1; i < 9; i += 3)
            {
                val = int.Parse(list1[i].ToString());
                col2EasySum += val;
            }

            for (int i = 2; i < 9; i += 3)
            {
                val = int.Parse(list1[i].ToString());
                col3EasySum += val;
            }

        }
        private void calculateInitialEasyDiagnalSums(List<char> list1)
        {
            int val;

            //go through the easy board
            for (int i = 2; i < 9; i += 2)
            {
                val = int.Parse(list1[i].ToString());
                diagnal1EasySum += val;
            }

            //go through the easy board
            for (int i = 0; i < 9; i += 4)
            {
                val = int.Parse(list1[i].ToString());
                diagnal2EasySum += val;
            }



        }
        private void numberInput(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            int value = int.Parse(textbox.Text);
            if (textbox.Name.Contains("easy"))
            {
                isEasyBoard = true;
            }
            //row changing total values
            //if the textbox name contains "easy" or any value between 0-2, we know we are in the first row
                if (textbox.Name.Contains("easy") && textbox.Name.Contains("0") || textbox.Name.Contains("1")
                                || textbox.Name.Contains("2"))
            {
                row1EasySum += int.Parse(textbox.Text);
                rowSumBox.Refresh();
            }

            //if the textbox name contains "easy" or any value between 0-2, we know we are in the first row
            if (textbox.Name.Contains("easy") && textbox.Name.Contains("3") || textbox.Name.Contains("4")
                                || textbox.Name.Contains("5"))
            {
                row2EasySum += int.Parse(textbox.Text);
                rowSumBox.Refresh();

            }

            //if the textbox name contains "easy" or any value between 0-2, we know we are in the first row
            if (textbox.Name.Contains("easy") && textbox.Name.Contains("6") || textbox.Name.Contains("7")
                                || textbox.Name.Contains("8"))
            {
                row3EasySum += int.Parse(textbox.Text);
                rowSumBox.Refresh();

            }

            //columns changing total values
            //if the textbox name contains "easy" or values 0, 3, 6 we are in first column
            if (textbox.Name.Contains("easy") && textbox.Name.Contains("0") || textbox.Name.Contains("3")
                                || textbox.Name.Contains("6"))
            {
                col1EasySum += int.Parse(textbox.Text);
                columnSumBox.Refresh();

            }

            //if the textbox name contains "easy" or values 0, 3, 6 we are in first column
            if (textbox.Name.Contains("easy") && textbox.Name.Contains("1") || textbox.Name.Contains("4")
                                || textbox.Name.Contains("7"))
            {
                col2EasySum += int.Parse(textbox.Text);
                columnSumBox.Refresh();

            }

            //if the textbox name contains "easy" or values 0, 3, 6 we are in first column
            if (textbox.Name.Contains("easy") && textbox.Name.Contains("2") || textbox.Name.Contains("5")
                                || textbox.Name.Contains("8"))
            {
                col3EasySum += int.Parse(textbox.Text);
                columnSumBox.Refresh();

            }

            //diagnals changing
            //if the textbox name contains "easy" or have 0, 4, 8 in their name, it is a diagnal
            if (textbox.Name.Contains("easy") && textbox.Name.Contains("0") || textbox.Name.Contains("4")
                                || textbox.Name.Contains("8"))
            {
                diagnal2EasySum += int.Parse(textbox.Text);
                diagnal2SumBox.Refresh();

            }

            //if the textbox name contains "easy" or have 2, 4, 6 in their name, it is a diagnal
            if (textbox.Name.Contains("easy") && textbox.Name.Contains("2") || textbox.Name.Contains("4")
                                || textbox.Name.Contains("6"))
            {
                diagnal1EasySum += int.Parse(textbox.Text);
                diagnal1SumBox.Refresh();
            }


        }
        private void newGameButton_MouseDown(object sender, MouseEventArgs e)
        {
            isDown = true;
            canvas.Refresh();
            if (isBoardLoaded)
            {
                //load the totals for the easy game board rows
                calculateInitialEasyRowSums(gameValuesEasy1);
                rowSumBox.Refresh();

                //load the totals for the easy game board columns
                calculateInitialEasyColSums(gameValuesEasy1);
                columnSumBox.Refresh();

                //
                calculateInitialEasyDiagnalSums(gameValuesEasy1);
                diagnal1SumBox.Refresh();
                diagnal2SumBox.Refresh();
            }

        }

        private void newGameButton_MouseUp(object sender, MouseEventArgs e)
        {
            //reset all flags
            isDown = false;
            isEasyGame = false;
            isMediumGame = false;
            isHardGame = false;
            isEasyBoard = false;
        }

        private void resetEasyPuzzleTextboxes()
        {
            //remove the areas user can enter value for easy textboxes
            for (int i = 0; i < generatedEasyTextboxes.Count; i++)
            {
                canvas.Controls.Remove(generatedEasyTextboxes[i]);
            }
            generatedEasyTextboxes.Clear();

        }

        private void resetMediumPuzzleTextboxes()
        {
            //remove the areas user can enter value for medium textboxes
            for (int i = 0; i < generatedMedTextboxes.Count; i++)
            {
                canvas.Controls.Remove(generatedMedTextboxes[i]);
            }
            generatedMedTextboxes.Clear();

        }

        private void resetHardPuzzleTextboxes()
        {
            //remove the areas user can enter value for hard textboxes
            for (int i = 0; i < generatedHardTextboxes.Count; i++)
            {
                canvas.Controls.Remove(generatedHardTextboxes[i]);
            }
            generatedHardTextboxes.Clear();
        }
        private void rowSumBox_Paint(object sender, PaintEventArgs e)
        {

            Graphics graphics = e.Graphics;

            if (isBoardLoaded)
            {
                if (isEasyBoard)
                {
                    using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        PointF pointF1 = new PointF(rowSumBox.Width / 6, rowSumBox.Height / 6);
                        e.Graphics.DrawString(row1EasySum.ToString(), font1, Brushes.Black, pointF1);


                        PointF pointF2 = new PointF(rowSumBox.Width / 6, 3 * rowSumBox.Height / 6);
                        e.Graphics.DrawString(row2EasySum.ToString(), font1, Brushes.Black, pointF2);

                        PointF pointF3 = new PointF(rowSumBox.Width / 6, 5 * rowSumBox.Height / 6);
                        e.Graphics.DrawString(row3EasySum.ToString(), font1, Brushes.Black, pointF3);

                    }
                }
            }


        }

        private void columnSumBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            if (isBoardLoaded)
            {
                if (isEasyBoard)
                {
                    using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        PointF pointF1 = new PointF(columnSumBox.Width / 6, columnSumBox.Height / 6);
                        e.Graphics.DrawString(col1EasySum.ToString(), font1, Brushes.Black, pointF1);

                        PointF pointF2 = new PointF(3 * columnSumBox.Width / 6, columnSumBox.Height / 6);
                        e.Graphics.DrawString(col2EasySum.ToString(), font1, Brushes.Black, pointF2);

                        PointF pointF3 = new PointF(5 * columnSumBox.Width / 6, columnSumBox.Height / 6);
                        e.Graphics.DrawString(col3EasySum.ToString(), font1, Brushes.Black, pointF3);

                    }
                }
                
            }

        }

        private void diagnal1SumBox_Paint(object sender, PaintEventArgs e)
        {
            if (isBoardLoaded)
            {
                if (isEasyBoard)
                {
                    //paint the sum for the top diagnal total
                    using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        PointF pointF1 = new PointF(diagnal1SumBox.Width / 3, diagnal1SumBox.Height / 3);
                        e.Graphics.DrawString(diagnal1EasySum.ToString(), font1, Brushes.Black, pointF1);
                    }
                }
                
            }
        }

        private void diagnal2SumBox_Paint(object sender, PaintEventArgs e)
        {
            if (isBoardLoaded)
            {
                if (isEasyBoard)
                {
                    //paint the sum for the bottom diagnal total
                    using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        PointF pointF1 = new PointF(diagnal2SumBox.Width / 3, diagnal2SumBox.Height / 3);
                        e.Graphics.DrawString(diagnal2EasySum.ToString(), font1, Brushes.Black, pointF1);
                    }
                }
            }
        }

       
    }
}
