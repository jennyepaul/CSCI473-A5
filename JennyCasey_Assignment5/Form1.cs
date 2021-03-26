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
        private static bool isMediumBoard = false;
        private static bool isHardBoard = false;

        //all totals variables  for an easy board
        private static int row1EasySum = 0;
        private static int row2EasySum = 0;
        private static int row3EasySum = 0;
        private static int diagnal1EasySum = 0;
        private static int diagnal2EasySum = 0;
        private static int col1EasySum = 0;
        private static int col2EasySum = 0;
        private static int col3EasySum = 0;

        //all totals variables for a medium board
        private static int row1MediumSum = 0;
        private static int row2MediumSum = 0;
        private static int row3MediumSum = 0;
        private static int row4MediumSum = 0;
        private static int row5MediumSum = 0;
        private static int col1MediumSum = 0;
        private static int col2MediumSum = 0;
        private static int col3MediumSum = 0;
        private static int col4MediumSum = 0;
        private static int col5MediumSum = 0;
        private static int diagnal1MediumSum = 0;
        private static int diagnal2MediumSum = 0;

        //all totals variables for a hard board
        private static int row1HardSum = 0;
        private static int row2HardSum = 0;
        private static int row3HardSum = 0;
        private static int row4HardSum = 0;
        private static int row5HardSum = 0;
        private static int row6HardSum = 0;
        private static int row7HardSum = 0;
        private static int col1HardSum = 0;
        private static int col2HardSum = 0;
        private static int col3HardSum = 0;
        private static int col4HardSum = 0;
        private static int col5HardSum = 0;
        private static int col6HardSum = 0;
        private static int col7HardSum = 0;
        private static int diagnal1HardSum = 0;
        private static int diagnal2HardSum = 0;

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
                        isMediumBoard = true;
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
                        isHardBoard = true;
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
                                Point point2 = new Point(xPoints[xSub] * (W / 14) - 10, yPoints[ySub] * (L / 14) - 10);
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

        private void calculateInitialMediumRowSums(List<char> list1)
        {
            int val;
            //go through the medium board
            for (int i = 0; i < 5; i++)
            {
                val = int.Parse(list1[i].ToString());
                row1MediumSum += val;
            }

            for (int i = 5; i < 10; i++)
            {
                val = int.Parse(list1[i].ToString());
                row2MediumSum += val;
            }

            for (int i = 10; i < 15; i++)
            {
                val = int.Parse(list1[i].ToString());
                row3MediumSum += val;
            }
            for (int i = 15; i < 20; i++)
            {
                val = int.Parse(list1[i].ToString());
                row4MediumSum += val;
            }
            for (int i = 20; i < 25; i++)
            {
                val = int.Parse(list1[i].ToString());
                row5MediumSum += val;
            }

        }

        private void calculateInitialMediumColSums(List<char> list1)
        {
            int val;
            //go through the medium board
            for (int i = 0; i < 21; i+=5)
            {
                val = int.Parse(list1[i].ToString());
                col1MediumSum += val;
            }

            for (int i = 1; i < 22; i+=5)
            {
                val = int.Parse(list1[i].ToString());
                col2MediumSum += val;
            }

            for (int i = 2; i < 23; i+=5)
            {
                val = int.Parse(list1[i].ToString());
                col3MediumSum += val;
            }
            for (int i = 3; i < 24; i+=5)
            {
                val = int.Parse(list1[i].ToString());
                col4MediumSum += val;
            }
            for (int i = 4; i < 25; i+=5)
            {
                val = int.Parse(list1[i].ToString());
                col5MediumSum += val;
            }
        }
        private void calculateInitialMediumDiagnalSums(List<char> list1)
        {
            int val;

            //go through the medium board
            for (int i = 4; i < 21; i += 4)
            {
                val = int.Parse(list1[i].ToString());
                diagnal1MediumSum += val;
            }

            //go through the medium board
            for (int i = 0; i < 25; i += 6)
            {
                val = int.Parse(list1[i].ToString());
                diagnal2MediumSum += val;
            }
        }
        
        private void calculateInitialHardRowSums(List<char> list1)
        {
            int val;
            //go through the hard board rows and calculate the initial values
            for (int i = 0; i < 7; i++)
            {
                val = int.Parse(list1[i].ToString());
                row1HardSum += val;
            }

            for (int i = 7; i < 14; i++)
            {
                val = int.Parse(list1[i].ToString());
                row2HardSum += val;
            }

            for (int i = 14; i < 21; i++)
            {
                val = int.Parse(list1[i].ToString());
                row3HardSum += val;
            }
            for (int i = 21; i < 28; i++)
            {
                val = int.Parse(list1[i].ToString());
                row4HardSum += val;
            }
            for (int i = 28; i < 35; i++)
            {
                val = int.Parse(list1[i].ToString());
                row5HardSum += val;
            }
            for (int i = 35; i < 42; i++)
            {
                val = int.Parse(list1[i].ToString());
                row6HardSum += val;
            }
            for (int i = 42; i < 49; i++)
            {
                val = int.Parse(list1[i].ToString());
                row7HardSum += val;
            }
        }

        private void calculateInitialHardColSums(List<char> list1)
        {
            int val;
            //go through the hard board columns and calculate the initial values 
            for (int i = 0; i < 43; i+=7)
            {
                val = int.Parse(list1[i].ToString());
                col1HardSum += val;
            }

            for (int i = 1; i < 44; i+=7)
            {
                val = int.Parse(list1[i].ToString());
                col2HardSum += val;
            }

            for (int i = 2; i < 45; i+=7)
            {
                val = int.Parse(list1[i].ToString());
                col3HardSum += val;
            }
            for (int i = 3; i < 46; i+=7)
            {
                val = int.Parse(list1[i].ToString());
                col4HardSum += val;
            }
            for (int i = 4; i < 47; i+=7)
            {
                val = int.Parse(list1[i].ToString());
                col5HardSum += val;
            }
            for (int i = 5; i < 48; i+=7)
            {
                val = int.Parse(list1[i].ToString());
                col6HardSum += val;
            }
            for (int i = 6; i < 49; i+=7)
            {
                val = int.Parse(list1[i].ToString());
                col7HardSum += val;
            }
        }
        private void calculateInitialHardDiagnalSums(List <char> list1)
        {
            int val;

            //go through the medium board
            for (int i = 6; i < 43; i += 6)
            {
                val = int.Parse(list1[i].ToString());
                diagnal1HardSum += val;
            }

            //go through the medium board
            for (int i = 0; i < 49; i += 8)
            {
                val = int.Parse(list1[i].ToString());
                diagnal2HardSum += val;
            }
        }
        private void numberInput(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            int value = int.Parse(textbox.Text);

            //set flags based on what board we are building
            if (textbox.Name.Contains("easy"))
            {
                isEasyBoard = true;
                isMediumBoard = false;
                isHardBoard = false;
            }
            if(textbox.Name.Contains("med"))
            {
                isMediumBoard = true;
                isEasyBoard = false;
                isHardBoard = false;
            }
            if(textbox.Name.Contains("hard"))
            {
                isHardBoard = true;
                isMediumBoard = false;
                isEasyBoard = false;
            }

            if (isEasyBoard)
            {
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
            //MEDIUM BOARD CALCULTIONS IF CHANGE IN TEXT BOXES
            if (isMediumBoard)
            {
                //5 ROWS OF MEDIUM TABLE
                if (textbox.Name == "medPuzzleCell0" || textbox.Name == "medPuzzleCell1" || textbox.Name == "medPuzzleCell2"
                                || textbox.Name == "medPuzzleCell3" || textbox.Name == "medPuzzleCell4")
                {
                    row1MediumSum += int.Parse(textbox.Text);
                    rowSumBox.Refresh();
                }
                if (textbox.Name == "medPuzzleCell5" || textbox.Name == "medPuzzleCell6" || textbox.Name == "medPuzzleCell7"
                                || textbox.Name == "medPuzzleCell8" || textbox.Name == "medPuzzleCell9")
                {
                    row2MediumSum += int.Parse(textbox.Text);
                    rowSumBox.Refresh();
                }
                if (textbox.Name == "medPuzzleCell10" || textbox.Name == "medPuzzleCell11" || textbox.Name == "medPuzzleCell12"
                                || textbox.Name == "medPuzzleCell13" || textbox.Name == "medPuzzleCell14")
                {
                    row3MediumSum += int.Parse(textbox.Text);
                    rowSumBox.Refresh();
                }
                if (textbox.Name == "medPuzzleCell15" || textbox.Name == "medPuzzleCell16" || textbox.Name == "medPuzzleCell17"
                                || textbox.Name == "medPuzzleCell18" || textbox.Name == "medPuzzleCell19")
                {
                    row4MediumSum += int.Parse(textbox.Text);
                    rowSumBox.Refresh();
                }
                if (textbox.Name == "medPuzzleCell20" || textbox.Name == "medPuzzleCell21" || textbox.Name == "medPuzzleCell22"
                                || textbox.Name == "medPuzzleCell23" || textbox.Name == "medPuzzleCell24")
                {
                    row5MediumSum += int.Parse(textbox.Text);
                    rowSumBox.Refresh();
                }
                
                //COLUMNS OF MEDIUM TABLE
                if (textbox.Name == "medPuzzleCell0" || textbox.Name == "medPuzzleCell5" || textbox.Name == "medPuzzleCell10"
                                || textbox.Name == "medPuzzleCell15" || textbox.Name == "medPuzzleCell20")
                {
                    col1MediumSum += int.Parse(textbox.Text);
                    columnSumBox.Refresh();
                }
                if (textbox.Name == "medPuzzleCell1" || textbox.Name == "medPuzzleCell6" || textbox.Name == "medPuzzleCell11"
                                || textbox.Name == "medPuzzleCell16" || textbox.Name == "medPuzzleCell21")
                {
                    col2MediumSum += int.Parse(textbox.Text);
                    columnSumBox.Refresh();
                }
                if (textbox.Name == "medPuzzleCell2" || textbox.Name == "medPuzzleCell7" || textbox.Name == "medPuzzleCell12"
                                || textbox.Name == "medPuzzleCell17" || textbox.Name == "medPuzzleCell22")
                {
                    col3MediumSum += int.Parse(textbox.Text);
                    columnSumBox.Refresh();
                }
                if (textbox.Name == "medPuzzleCell3" || textbox.Name == "medPuzzleCell8" || textbox.Name == "medPuzzleCell13"
                                || textbox.Name == "medPuzzleCell18" || textbox.Name == "medPuzzleCell23")
                {
                    col4MediumSum += int.Parse(textbox.Text);
                    columnSumBox.Refresh();
                }
                if (textbox.Name == "medPuzzleCell4" || textbox.Name == "medPuzzleCell9" || textbox.Name == "medPuzzleCell14"
                                || textbox.Name == "medPuzzleCell19" || textbox.Name == "medPuzzleCell24")
                {
                    col5MediumSum += int.Parse(textbox.Text);
                    columnSumBox.Refresh();
                }
                //diagnals changing
                if (textbox.Name == "medPuzzleCell0" || textbox.Name == "medPuzzleCell6" || textbox.Name == "medPuzzleCell12"
                                || textbox.Name == "medPuzzleCell18" || textbox.Name == "medPuzzleCell24")
                {
                    diagnal2MediumSum += int.Parse(textbox.Text);
                    diagnal2SumBox.Refresh();

                }
                if (textbox.Name == "medPuzzleCell4" || textbox.Name == "medPuzzleCell8" || textbox.Name == "medPuzzleCell12"
                                || textbox.Name == "medPuzzleCell16" || textbox.Name == "medPuzzleCell20")
                {
                    diagnal1MediumSum += int.Parse(textbox.Text);
                    diagnal1SumBox.Refresh();
                }

            }
            //HARD BOARD CALCULATIONS IF CHANGE IN TeXT BOXES
            if(isHardBoard)
            {
                //7 ROWS FOR HARD BOARD
                if (textbox.Name == "hardPuzzleCell0" || textbox.Name == "hardPuzzleCell1" || textbox.Name == "hardPuzzleCell2"
                                || textbox.Name == "hardPuzzleCell3" || textbox.Name == "hardPuzzleCell4" || textbox.Name == "hardPuzzleCell5"
                                || textbox.Name == "hardPuzzleCell6")
                {
                    row1HardSum += int.Parse(textbox.Text);
                    rowSumBox.Refresh();
                }
                if (textbox.Name == "hardPuzzleCell7" || textbox.Name == "hardPuzzleCell8" || textbox.Name == "hardPuzzleCell9"
                                || textbox.Name == "hardPuzzleCell10" || textbox.Name == "hardPuzzleCell11" || textbox.Name == "hardPuzzleCell12"
                                || textbox.Name == "hardPuzzleCell13")
                {
                    row2HardSum += int.Parse(textbox.Text);
                    rowSumBox.Refresh();
                }
                if (textbox.Name == "hardPuzzleCell14" || textbox.Name == "hardPuzzleCell15" || textbox.Name == "hardPuzzleCell16"
                               || textbox.Name == "hardPuzzleCell17" || textbox.Name == "hardPuzzleCell18" || textbox.Name == "hardPuzzleCell19"
                               || textbox.Name == "hardPuzzleCell20")
                {
                    row3HardSum += int.Parse(textbox.Text);
                    rowSumBox.Refresh();
                }
                if (textbox.Name == "hardPuzzleCell21" || textbox.Name == "hardPuzzleCell22" || textbox.Name == "hardPuzzleCell23"
                               || textbox.Name == "hardPuzzleCell24" || textbox.Name == "hardPuzzleCell25" || textbox.Name == "hardPuzzleCell26"
                               || textbox.Name == "hardPuzzleCell27")
                {
                    row4HardSum += int.Parse(textbox.Text);
                    rowSumBox.Refresh();
                }
                if (textbox.Name == "hardPuzzleCell28" || textbox.Name == "hardPuzzleCell29" || textbox.Name == "hardPuzzleCell30"
                             || textbox.Name == "hardPuzzleCell31" || textbox.Name == "hardPuzzleCell32" || textbox.Name == "hardPuzzleCell33"
                             || textbox.Name == "hardPuzzleCell34")
                {
                    row5HardSum += int.Parse(textbox.Text);
                    rowSumBox.Refresh();
                }
                if (textbox.Name == "hardPuzzleCell35" || textbox.Name == "hardPuzzleCell36" || textbox.Name == "hardPuzzleCell37"
                             || textbox.Name == "hardPuzzleCell38" || textbox.Name == "hardPuzzleCell39" || textbox.Name == "hardPuzzleCell40"
                             || textbox.Name == "hardPuzzleCell41")
                {
                    row6HardSum += int.Parse(textbox.Text);
                    rowSumBox.Refresh();
                }
                if (textbox.Name == "hardPuzzleCell42" || textbox.Name == "hardPuzzleCell43" || textbox.Name == "hardPuzzleCell44"
                            || textbox.Name == "hardPuzzleCell45" || textbox.Name == "hardPuzzleCell46" || textbox.Name == "hardPuzzleCell47"
                            || textbox.Name == "hardPuzzleCell48")
                {
                    row7HardSum += int.Parse(textbox.Text);
                    rowSumBox.Refresh();
                }

                //7 COLUMNS FOR HARD BOARD
                if (textbox.Name == "hardPuzzleCell0" || textbox.Name == "hardPuzzleCell7" || textbox.Name == "hardPuzzleCell14"
                                || textbox.Name == "hardPuzzleCel21" || textbox.Name == "hardPuzzleCell28" || textbox.Name == "hardPuzzleCell35"
                                || textbox.Name == "hardPuzzleCell42")
                {
                    col1HardSum += int.Parse(textbox.Text);
                    columnSumBox.Refresh();
                }
                if (textbox.Name == "hardPuzzleCell1" || textbox.Name == "hardPuzzleCell8" || textbox.Name == "hardPuzzleCell15"
                               || textbox.Name == "hardPuzzleCel22" || textbox.Name == "hardPuzzleCell29" || textbox.Name == "hardPuzzleCell36"
                               || textbox.Name == "hardPuzzleCell43")
                {
                    col2HardSum += int.Parse(textbox.Text);
                    columnSumBox.Refresh();
                }
                if (textbox.Name == "hardPuzzleCell2" || textbox.Name == "hardPuzzleCell9" || textbox.Name == "hardPuzzleCell16"
                              || textbox.Name == "hardPuzzleCel23" || textbox.Name == "hardPuzzleCell30" || textbox.Name == "hardPuzzleCell37"
                              || textbox.Name == "hardPuzzleCell44")
                {
                    col3HardSum += int.Parse(textbox.Text);
                    columnSumBox.Refresh();
                }
                if (textbox.Name == "hardPuzzleCell3" || textbox.Name == "hardPuzzleCell10" || textbox.Name == "hardPuzzleCell17"
                              || textbox.Name == "hardPuzzleCel24" || textbox.Name == "hardPuzzleCell31" || textbox.Name == "hardPuzzleCell38"
                              || textbox.Name == "hardPuzzleCell45")
                {
                    col4HardSum += int.Parse(textbox.Text);
                    columnSumBox.Refresh();
                }
                if (textbox.Name == "hardPuzzleCell4" || textbox.Name == "hardPuzzleCell11" || textbox.Name == "hardPuzzleCell18"
                              || textbox.Name == "hardPuzzleCel25" || textbox.Name == "hardPuzzleCell32" || textbox.Name == "hardPuzzleCell39"
                              || textbox.Name == "hardPuzzleCell46")
                {
                    col5HardSum += int.Parse(textbox.Text);
                    columnSumBox.Refresh();
                }
                if (textbox.Name == "hardPuzzleCell5" || textbox.Name == "hardPuzzleCell12" || textbox.Name == "hardPuzzleCell19"
                              || textbox.Name == "hardPuzzleCel26" || textbox.Name == "hardPuzzleCell33" || textbox.Name == "hardPuzzleCell40"
                              || textbox.Name == "hardPuzzleCell47")
                {
                    col6HardSum += int.Parse(textbox.Text);
                    columnSumBox.Refresh();
                }
                if (textbox.Name == "hardPuzzleCell6" || textbox.Name == "hardPuzzleCell13" || textbox.Name == "hardPuzzleCell20"
                              || textbox.Name == "hardPuzzleCel27" || textbox.Name == "hardPuzzleCell34" || textbox.Name == "hardPuzzleCell41"
                              || textbox.Name == "hardPuzzleCell48")
                {
                    col7HardSum += int.Parse(textbox.Text);
                    columnSumBox.Refresh();
                }
                //diagnals changing
                if (textbox.Name == "hardPuzzleCell0" || textbox.Name == "hardPuzzleCell8" || textbox.Name == "hardPuzzleCell16"
                              || textbox.Name == "hardPuzzleCell24" || textbox.Name == "hardPuzzleCell32" || textbox.Name == "hardPuzzleCell40"
                              || textbox.Name == "hardPuzzleCell48")
                {
                    diagnal2HardSum += int.Parse(textbox.Text);
                    diagnal2SumBox.Refresh();

                }
                if (textbox.Name == "hardPuzzleCell6" || textbox.Name == "hardPuzzleCell12" || textbox.Name == "hardPuzzleCell18"
                              || textbox.Name == "hardPuzzleCell24" || textbox.Name == "hardPuzzleCell30" || textbox.Name == "hardPuzzleCell36"
                              || textbox.Name == "hardPuzzleCell42")
                {
                    diagnal1HardSum += int.Parse(textbox.Text);
                    diagnal1SumBox.Refresh();
                }
            }
      
            
        }
        private void newGameButton_MouseDown(object sender, MouseEventArgs e)
        {
            isDown = true;
            canvas.Refresh();
            if (isBoardLoaded)
            {
                if (isEasyBoard)
                {
                    //calc and load the totals for the easy game board rows
                    calculateInitialEasyRowSums(gameValuesEasy1);
                    rowSumBox.Refresh();

                    //calc and load the totals for the easy game board columns
                    calculateInitialEasyColSums(gameValuesEasy1);
                    columnSumBox.Refresh();

                    //calc and load the diagnal totals for easy board
                    calculateInitialEasyDiagnalSums(gameValuesEasy1);
                    diagnal1SumBox.Refresh();
                    diagnal2SumBox.Refresh();
                }
                if(isMediumBoard)
                {
                    //calc and load the row totals for medium board
                    calculateInitialMediumRowSums(gameValuesMedium1);
                    rowSumBox.Refresh();

                    //calc and load the column totals for medium board
                    calculateInitialMediumColSums(gameValuesMedium1);
                    columnSumBox.Refresh();

                    //calc and load the diagnal totals for medium board
                    calculateInitialMediumDiagnalSums(gameValuesMedium1);
                    diagnal1SumBox.Refresh();
                    diagnal2SumBox.Refresh();
                }
                if(isHardBoard)
                {
                    //calculate and load the intial values for rows for hard board
                    calculateInitialHardRowSums(gameValuesHard1);
                    rowSumBox.Refresh();

                    //calc and load the initial values for the columns for the hard board
                    calculateInitialHardColSums(gameValuesHard1);
                    columnSumBox.Refresh();

                    //calc and load the diagnal totals for hard board
                    calculateInitialHardDiagnalSums(gameValuesHard1);
                    diagnal1SumBox.Refresh();
                    diagnal2SumBox.Refresh();
                }
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
            isMediumBoard = false;
            isHardBoard = false;
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
                if(isMediumBoard)
                {
                    using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        PointF pointF1 = new PointF(rowSumBox.Width / 10, rowSumBox.Height / 10);
                        e.Graphics.DrawString(row1MediumSum.ToString(), font1, Brushes.Black, pointF1);

                        PointF pointF2 = new PointF(rowSumBox.Width / 10, 3 * rowSumBox.Height / 10);
                        e.Graphics.DrawString(row2MediumSum.ToString(), font1, Brushes.Black, pointF2);

                        PointF pointF3 = new PointF(rowSumBox.Width / 10, 5 * rowSumBox.Height / 10);
                        e.Graphics.DrawString(row3MediumSum.ToString(), font1, Brushes.Black, pointF3);

                        PointF pointF4 = new PointF(rowSumBox.Width / 10, 7 * rowSumBox.Height / 10);
                        e.Graphics.DrawString(row4MediumSum.ToString(), font1, Brushes.Black, pointF4);

                        PointF pointF5 = new PointF(rowSumBox.Width / 10, 9 * rowSumBox.Height / 10);
                        e.Graphics.DrawString(row5MediumSum.ToString(), font1, Brushes.Black, pointF5);

                    }
                }
                if(isHardBoard)
                {
                    using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        PointF pointF1 = new PointF(rowSumBox.Width / 14, rowSumBox.Height / 14);
                        e.Graphics.DrawString(row1HardSum.ToString(), font1, Brushes.Black, pointF1);

                        PointF pointF2 = new PointF(rowSumBox.Width / 14, 3 * rowSumBox.Height / 14);
                        e.Graphics.DrawString(row2HardSum.ToString(), font1, Brushes.Black, pointF2);

                        PointF pointF3 = new PointF(rowSumBox.Width / 14, 5 * rowSumBox.Height / 14);
                        e.Graphics.DrawString(row3HardSum.ToString(), font1, Brushes.Black, pointF3);

                        PointF pointF4 = new PointF(rowSumBox.Width / 14, 7 * rowSumBox.Height / 14);
                        e.Graphics.DrawString(row4HardSum.ToString(), font1, Brushes.Black, pointF4);

                        PointF pointF5 = new PointF(rowSumBox.Width / 14, 9 * rowSumBox.Height / 14);
                        e.Graphics.DrawString(row5HardSum.ToString(), font1, Brushes.Black, pointF5);

                        PointF pointF6 = new PointF(rowSumBox.Width / 14, 11 * rowSumBox.Height / 14);
                        e.Graphics.DrawString(row6HardSum.ToString(), font1, Brushes.Black, pointF6);

                        PointF pointF7 = new PointF(rowSumBox.Width / 14, 13 * rowSumBox.Height / 14);
                        e.Graphics.DrawString(row7HardSum.ToString(), font1, Brushes.Black, pointF7);

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
                if(isMediumBoard)
                {
                    using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        PointF pointF1 = new PointF(columnSumBox.Width / 10, columnSumBox.Height / 10);
                        e.Graphics.DrawString(col1MediumSum.ToString(), font1, Brushes.Black, pointF1);

                        PointF pointF2 = new PointF(3 * columnSumBox.Width / 10, columnSumBox.Height / 10);
                        e.Graphics.DrawString(col2MediumSum.ToString(), font1, Brushes.Black, pointF2);

                        PointF pointF3 = new PointF(5 * columnSumBox.Width / 10, columnSumBox.Height / 10);
                        e.Graphics.DrawString(col3MediumSum.ToString(), font1, Brushes.Black, pointF3);

                        PointF pointF4 = new PointF(7 * columnSumBox.Width / 10, columnSumBox.Height / 10);
                        e.Graphics.DrawString(col4MediumSum.ToString(), font1, Brushes.Black, pointF4);

                        PointF pointF5 = new PointF(9 * columnSumBox.Width / 10, columnSumBox.Height / 10);
                        e.Graphics.DrawString(col5MediumSum.ToString(), font1, Brushes.Black, pointF5);

                    }
                }

                if(isHardBoard)
                {
                    using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        PointF pointF1 = new PointF(columnSumBox.Width / 14, columnSumBox.Height / 14);
                        e.Graphics.DrawString(col1HardSum.ToString(), font1, Brushes.Black, pointF1);

                        PointF pointF2 = new PointF(3 * columnSumBox.Width / 14, columnSumBox.Height / 14);
                        e.Graphics.DrawString(col2HardSum.ToString(), font1, Brushes.Black, pointF2);

                        PointF pointF3 = new PointF(5 * columnSumBox.Width / 14, columnSumBox.Height / 14);
                        e.Graphics.DrawString(col3HardSum.ToString(), font1, Brushes.Black, pointF3);

                        PointF pointF4 = new PointF(7 * columnSumBox.Width / 14, columnSumBox.Height / 14);
                        e.Graphics.DrawString(col4HardSum.ToString(), font1, Brushes.Black, pointF4);

                        PointF pointF5 = new PointF(9 * columnSumBox.Width / 14, columnSumBox.Height / 14);
                        e.Graphics.DrawString(col5HardSum.ToString(), font1, Brushes.Black, pointF5);

                        PointF pointF6 = new PointF(11 * columnSumBox.Width / 14, columnSumBox.Height / 14);
                        e.Graphics.DrawString(col6HardSum.ToString(), font1, Brushes.Black, pointF6);

                        PointF pointF7 = new PointF(13 * columnSumBox.Width / 14, columnSumBox.Height / 14);
                        e.Graphics.DrawString(col7HardSum.ToString(), font1, Brushes.Black, pointF7);

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
                if (isMediumBoard)
                {
                    //paint the sum for the top diagnal total
                    using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        PointF pointF1 = new PointF(diagnal1SumBox.Width / 3, diagnal1SumBox.Height / 3);
                        e.Graphics.DrawString(diagnal1MediumSum.ToString(), font1, Brushes.Black, pointF1);
                    }
                }
                if(isHardBoard)
                {
                    //paint the sum for the top diagnal total
                    using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        PointF pointF1 = new PointF(diagnal1SumBox.Width / 3, diagnal1SumBox.Height / 3);
                        e.Graphics.DrawString(diagnal1HardSum.ToString(), font1, Brushes.Black, pointF1);
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
                if (isMediumBoard)
                {
                    //paint the sum for the bottom diagnal total
                    using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        PointF pointF1 = new PointF(diagnal2SumBox.Width / 3, diagnal2SumBox.Height / 3);
                        e.Graphics.DrawString(diagnal2MediumSum.ToString(), font1, Brushes.Black, pointF1);
                    }
                }
                if(isHardBoard)
                {
                    //paint the sum for the bottom diagnal total
                    using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        PointF pointF1 = new PointF(diagnal2SumBox.Width / 3, diagnal2SumBox.Height / 3);
                        e.Graphics.DrawString(diagnal2HardSum.ToString(), font1, Brushes.Black, pointF1);
                    }
                }
            }
        }    
    }
}
