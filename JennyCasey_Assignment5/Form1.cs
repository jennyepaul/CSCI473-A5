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
using System.Diagnostics;
using System.Linq;

namespace JennyCasey_Assignment5
{
    public partial class Form1 : Form
    {
        private static bool isEasyGame = false;
        private static bool isMediumGame = false;
        private static bool isHardGame = false;
        private static bool isDown = false;
        private static bool Hide_Board = false;
        private static bool Paused = false; 

        private static List<TextBox> generatedEasyTextboxes = new List<TextBox>();
        private static List<TextBox> generatedMedTextboxes = new List<TextBox>();
        private static List<TextBox> generatedHardTextboxes = new List<TextBox>();


        public static int L;
        public static int W;

        public static int timerticks;
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

            //resetEasyPuzzleTextboxes();
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
            List<string> gameStatsEasy1 = new List<string>();
            List<string> gameStatsMedium1 = new List<string>();
            List<string> gameStatsHard1 = new List<string>();

            List<char> gameValuesMedium1 = new List<char>();
            List<char> gameValuesHard1 = new List<char>();

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
           
           
           
            //store each value of the easy file into a char
            gameStatsEasy1[0].Split('0');
            char val = gameStatsEasy1[0][0];
            char val2 = gameStatsEasy1[0][1];
            char val3 = gameStatsEasy1[0][2];

            gameStatsEasy1[1].Split('0');
            char val4 = gameStatsEasy1[1][0];
            char val5 = gameStatsEasy1[1][1];
            char val6 = gameStatsEasy1[1][2];

            gameStatsEasy1[2].Split('0');
            char val7 = gameStatsEasy1[2][0];
            char val8 = gameStatsEasy1[2][1];
            char val9 = gameStatsEasy1[2][2];

            //add the individual values to a list to iterate through later
            for (int n = 0; n < 5; n++)
            {
                for (int j = 0; j < 5; j++)
                {
                    gameValuesMedium1.Add(gameStatsMedium1[n][j]);
                }
            }
           
            //add the individual values to a list to iterate through later
            for(int n = 0; n < 7; n++)
            {
                for(int j = 0; j < 7; j++)
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
                        //draw our vertical lines 
                        graphics.DrawLine(gamePen, W / 3, 0, W / 3, L);
                        graphics.DrawLine(gamePen, (2 * W / 3), 0, (2 * W / 3), L);

                        //draw horizontal lines
                        graphics.DrawLine(gamePen, 0, (L / 3), W, (L / 3));
                        graphics.DrawLine(gamePen, 0, (2 * L / 3), W, (2 * L / 3));

                        using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                        {
                            //FIRST ROW OF VALUES
                            //cell 1
                           if (Hide_Board)
                            {
                                resetEasyPuzzleTextboxes();

                                PointF pointF1 = new PointF(W / 6, L / 6);
                                e.Graphics.DrawString("?", font1, Brushes.Black, pointF1);
                            }
                            else if (val != '0')
                            {
                                //we have a value so print that to the board
                                PointF pointF1 = new PointF(W / 6, L / 6);
                                e.Graphics.DrawString(val.ToString(), font1, Brushes.Black, pointF1);
                            }
                            else
                            {
                                //it is zero, so user has to figure out what the value is
                                Point pointF1 = new Point((W / 6) - 20, L / 6);
                                TextBox txt = new TextBox();
                                txt.Name = "easyPuzzleCell1";
                                txt.Text = "";
                                txt.Location = pointF1;
                                txt.Height = 30;
                                txt.Width = 30;
                                //txt.Font.Size = 24;
                                canvas.Controls.Add(txt);

                                generatedEasyTextboxes.Add(txt);
                            }
                            //cell 2
                            if (Hide_Board)
                            {
                                resetEasyPuzzleTextboxes();

                                PointF pointF2 = new PointF(3 * (W / 6), (L / 6));
                                e.Graphics.DrawString("?", font1, Brushes.Black, pointF2);
                            }
                            else if (val2 != '0')
                            {
                                PointF pointF2 = new PointF(3 * (W / 6), (L / 6));
                                e.Graphics.DrawString(val2.ToString(), font1, Brushes.Black, pointF2);
                            }
                            else
                            {
                                //it is zero, so user has to figure out what the value is
                                Point pointF2 = new Point((3 * W / 6) - 20, L / 6);
                                TextBox txt = new TextBox();
                                txt.Name = "easyPuzzleCell2";
                                txt.Text = "";
                                txt.Location = pointF2;
                                txt.Height = 30;
                                txt.Width = 30;
                                canvas.Controls.Add(txt);
                                generatedEasyTextboxes.Add(txt);

                            }
                            //cell3 
                            if (Hide_Board)
                            {
                                resetEasyPuzzleTextboxes();

                                PointF pointF3 = new PointF(5 * (W / 6), (L / 6));
                                e.Graphics.DrawString("?", font1, Brushes.Black, pointF3);
                            }
                            else if (val3 != '0')
                            {
                                PointF pointF3 = new PointF(5 * (W / 6), (L / 6));
                                e.Graphics.DrawString(val3.ToString(), font1, Brushes.Black, pointF3);
                            }
                            else
                            {
                                //it is zero, so user has to figure out what the value is
                                Point pointF3 = new Point((5 * W / 6) - 20, L / 6);
                                TextBox txt = new TextBox();
                                txt.Name = "easyPuzzleCell3";
                                txt.Text = "";
                                txt.Location = pointF3;
                                txt.Height = 30;
                                txt.Width = 30;
                                canvas.Controls.Add(txt);

                                generatedEasyTextboxes.Add(txt);

                            }

                            //SECOND ROW OF VALUES
                            //cell 4
                            if (Hide_Board)
                            {
                                resetEasyPuzzleTextboxes();

                                PointF pointF4 = new PointF(W / 6, (3 * L / 6));
                                e.Graphics.DrawString("?", font1, Brushes.Black, pointF4);
                            }
                            else if (val4 != '0')
                            {
                                PointF pointF4 = new PointF(W / 6, (3 * L / 6));
                                e.Graphics.DrawString(val4.ToString(), font1, Brushes.Black, pointF4);
                            }
                            else
                            {
                                //it is zero, so user has to figure out what the value is
                                Point pointF4 = new Point(W / 6 - 20, (3 * L / 6));
                                TextBox txt = new TextBox();
                                txt.Name = "easyPuzzleCell4";
                                txt.Text = "";
                                txt.Location = pointF4;
                                txt.Height = 30;
                                txt.Width = 30;
                                canvas.Controls.Add(txt);

                                generatedEasyTextboxes.Add(txt);

                            }
                            //cell 5
                            if (Hide_Board)
                            {
                                resetEasyPuzzleTextboxes();

                                PointF pointF5 = new PointF(3 * (W / 6), (3 * L / 6));
                                e.Graphics.DrawString("?", font1, Brushes.Black, pointF5);
                            }
                            else if (val5 != '0')
                            {
                                PointF pointF5 = new PointF(3 * (W / 6), (3 * L / 6));
                                e.Graphics.DrawString(val5.ToString(), font1, Brushes.Black, pointF5);
                            }
                            else
                            {

                                //it is zero, so user has to figure out what the value is
                                Point pointF5 = new Point(3 * (W / 6) - 20, (3 * L / 6));
                                TextBox txt = new TextBox();
                                txt.Name = "easyPuzzleCell5";
                                txt.Text = "";
                                txt.Location = pointF5;
                                txt.Height = 30;
                                txt.Width = 30;
                                canvas.Controls.Add(txt);

                                generatedEasyTextboxes.Add(txt);

                            }
                            //cell6 
                            if (Hide_Board)
                            {
                                PointF pointF6 = new PointF(5 * (W / 6), (3 * L / 6));
                                e.Graphics.DrawString("?", font1, Brushes.Black, pointF6);
                            }
                            else if (val6 != '0')
                            {
                                PointF pointF6 = new PointF(5 * (W / 6), (3 * L / 6));
                                e.Graphics.DrawString(val6.ToString(), font1, Brushes.Black, pointF6);
                            }
                            else
                            {

                                //it is zero, so user has to figure out what the value is
                                Point pointF6 = new Point((5 * W / 6) - 20, (3 * L / 6));
                                TextBox txt = new TextBox();
                                txt.Name = "easyPuzzleCell6";
                                txt.Text = "";
                                txt.Location = pointF6;
                                txt.Height = 30;
                                txt.Width = 30;
                                canvas.Controls.Add(txt);

                                generatedEasyTextboxes.Add(txt);

                            }
                            //THIRD ROW OF VALUES
                            //cell 7
                            if (Hide_Board)
                            {
                                PointF pointF7 = new PointF(W / 6, (5 * L / 6));
                                e.Graphics.DrawString("?", font1, Brushes.Black, pointF7);
                            }
                            else if (val7 != '0')
                            {
                                PointF pointF7 = new PointF(W / 6, (5 * L / 6));
                                e.Graphics.DrawString(val7.ToString(), font1, Brushes.Black, pointF7);
                            }
                            else
                            {
                                //it is zero, so user has to figure out what the value is
                                Point pointF7 = new Point(W / 6 - 20, (5 * L / 6));
                                TextBox txt = new TextBox();
                                txt.Name = "easyPuzzleCell7";
                                txt.Text = "";
                                txt.Location = pointF7;
                                txt.Height = 30;
                                txt.Width = 30;
                                canvas.Controls.Add(txt);

                                generatedEasyTextboxes.Add(txt);

                            }
                            //cell 8
                            if (Hide_Board)
                            {
                                PointF pointF8 = new PointF(3 * (W / 6), (5 * L / 6));
                                e.Graphics.DrawString("?", font1, Brushes.Black, pointF8);
                            }
                            else if (val8 != '0')
                            {
                                PointF pointF8 = new PointF(3 * (W / 6), (5 * L / 6));
                                e.Graphics.DrawString(val8.ToString(), font1, Brushes.Black, pointF8);
                            }
                            else
                            {
                                //it is zero, so user has to figure out what the value is
                                Point pointF8 = new Point(3 * (W / 6) - 20, (5 * L / 6));
                                TextBox txt = new TextBox();
                                txt.Name = "easyPuzzleCell8";
                                txt.Text = "";
                                txt.Location = pointF8;
                                txt.Height = 30;
                                txt.Width = 30;
                                canvas.Controls.Add(txt);

                                generatedEasyTextboxes.Add(txt);

                            }
                            //cell 9
                            if (Hide_Board)
                            {
                                PointF pointF9 = new PointF(5 * (W / 6), (5 * L / 6));
                                e.Graphics.DrawString("?", font1, Brushes.Black, pointF9);
                            }
                            else if (val9 != '0')
                            {
                                PointF pointF9 = new PointF(5 * (W / 6), (5 * L / 6));
                                e.Graphics.DrawString(val9.ToString(), font1, Brushes.Black, pointF9);
                            }
                            else
                            {
                                //it is zero, so user has to figure out what the value is
                                Point pointF9 = new Point(5 * (W / 6) - 20, (5 * L / 6));
                                TextBox txt = new TextBox();
                                txt.Name = "easyPuzzleCell9";
                                txt.Text = "";
                                txt.Location = pointF9;
                                txt.Height = 30;
                                txt.Width = 30;
                                canvas.Controls.Add(txt);

                                generatedEasyTextboxes.Add(txt);

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
                            if (Hide_Board)
                            {
                                //remove all the textboxes from the board 
                                resetMediumPuzzleTextboxes();

                                //replace all the squares with a "?" to hide the board from the player
                                PointF point = new PointF(xPoints[xSub] * (W / 10), yPoints[ySub] * (L / 10));
                                e.Graphics.DrawString("?", Font, Brushes.Black, point);
                            }
                            else if (gameValuesMedium1[c] != '0' && !Hide_Board)
                            {
                                using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                                {
                                    //we have a value so print that to the board
                                    PointF point = new PointF(xPoints[xSub] * (W / 10), yPoints[ySub] * (L / 10));
                                    e.Graphics.DrawString(gameValuesMedium1[c].ToString(), font1, Brushes.Black, point);
                                }
                            }
                            else if (!Hide_Board)
                            {
                                Point point2 = new Point(xPoints[xSub] * (W / 10) - 10, yPoints[ySub] * (L / 10));
                                TextBox txt = new TextBox();
                                txt.Name = "medPuzzleCell" + c;
                                txt.Text = "";
                                txt.Location = point2;
                                txt.Height = 30;
                                txt.Width = 30;
                                //txt.Font.Size = 24
                                canvas.Controls.Add(txt);
                                generatedMedTextboxes.Add(txt);
                               

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
                            if (Hide_Board)
                            {
                                //remove all of the text boxes currently on the board 
                                resetHardPuzzleTextboxes(); 

                                //replace each square with a "?" to hide the board from the user
                                PointF point = new PointF(xPoints[xSub] * (W / 14), yPoints[ySub] * (L / 14));
                                e.Graphics.DrawString("?", Font, Brushes.Black, point);
                            }
                            //if the value is not a zero, then we want to print it on the board
                            else if (gameValuesHard1[z] != '0' && !Hide_Board)
                            {
                                using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                                {
                                    //we have a value so print that to the board
                                    PointF point = new PointF(xPoints[xSub] * (W / 14),  yPoints[ySub] * (L / 14)); 
                                   e.Graphics.DrawString(gameValuesHard1[z].ToString(), font1, Brushes.Black, point);

                                }
                            }
                            //else it IS a 0, so we want to allow the user to guess what the value could be
                            else if (!Hide_Board)
                            {
                                
                                //it is zero, so user has to figure out what the value is, so we need to add a textbox
                                Point point2 = new Point(xPoints[xSub] * (W / 14), yPoints[ySub] * (L / 14));
                               TextBox txt = new TextBox();
                               txt.Name = "hardPuzzleCell" + z;
                               txt.Text = "";
                               txt.Location = point2;
                               txt.Height = 30;
                               txt.Width = 30;
                               //txt.Font.Size = 24
                               canvas.Controls.Add(txt);
                               generatedHardTextboxes.Add(txt);
                               
                            }
                            //increment the x subscript
                            xSub++;
                            //if the subcript is at 7, we finished a row, so reset the xsubscript
                            //and increment the y since we are going down to another row
                            if(xSub == 7)
                            {
                                xSub = 0;
                                ySub++;
                            }
                        }
                    }
                }
            }
        }
        private void newGameButton_MouseDown(object sender, MouseEventArgs e)
        {
            isDown = true;
            canvas.Refresh();

            //start the timer when a player chooses a puzzle
            tmrCounter.Enabled = true;
            i = 0;


        }

        private void newGameButton_MouseUp(object sender, MouseEventArgs e)
        {
            //reset all flags
            isDown = false;
            isEasyGame = false;
            isMediumGame = false;
            isHardGame = false;
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

        private void PauseResume_Button_Click(object sender, EventArgs e)
        {
            //Display the current time when user clicks pause
            if (PauseResume_Button.Text == "Pause")
            {
                Paused = true;
                tmrCounter.Enabled = false;  
                PauseResume_Button.Text = "Resume";     
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
                isDown = true;
                Hide_Board = true;
                canvas.Refresh();
            }
            else if (PauseResume_Button.Text == "Resume")
            {
                PauseResume_Button.Text = "Pause";           
                tmrCounter.Enabled = true;
                isDown = true;
                Hide_Board = false;
                canvas.Refresh();
                //somehow return to version previous to the pause
            }           
        }

        static string convertseconds(int seconds)
        {
            int totalsecs = seconds;
            int hours = seconds / 3600;
            seconds = seconds % 3600;
            int minutes = seconds / 60;
            seconds = seconds % 60;

            if (totalsecs < 0)
            {
                return string.Format("No Time");
            }    
            else if (totalsecs < 60)
            {
                return string.Format("{0:D2} seconds", seconds);
            }
            else if (totalsecs < 3599)
            {
                return string.Format("{0:D2} minutes and {1:D2} seconds", minutes, seconds);
            }
            else
            {
                return string.Format("{0:D2} hours, {1:D2} minutes and {2:D2} seconds", hours, minutes, seconds);
            }          
        }

        int i = 0;
        private void tmrCounter_Tick(object sender, EventArgs e)
        {
            i++;
            timerticks = i;
            //every time the counter ticks convert the amount of seconds to hours, minutes and seconds and display the time
            string time = convertseconds(i);
            Timer_Label.Text = "Current Time: " + time;

        }

        List<string> EasyTimer = new List<string>();
        int k = 0;
        private void Complete_Button_Click(object sender, EventArgs e)
        {
            tmrCounter.Enabled = false;
            k++;
            if (gameDifficultyDropDown.Text == "Easy")
            {

                string TimeRecord;
                if (k == 1)
                {
                    using (StreamReader inFile = new StreamReader("../../easy/eTimes.txt"))
                    {
                        while ((TimeRecord = inFile.ReadLine()) != null)
                        {
                            EasyTimer.Add(TimeRecord);
                        }
                    }
                }

                EasyTimer.Add(i.ToString());

                if (EasyTimer.Count != 0)
                {
                    int average = 0;
                    int numofTimes = 0;
                    int smallest = int.Parse(EasyTimer[0]);
                    foreach (string item in EasyTimer)
                    {
                        int m = int.Parse(item);
                        average = m + average;
                        numofTimes++;
                        if (m < smallest)
                        {
                            smallest = m;
                        }
                    }
                    average = average / numofTimes;

                    MessageBox.Show(Timer_Label.Text + "\nAverage for Easy Puzzles: " + convertseconds(average) + "\nFastest Time: " + convertseconds(smallest));
                }
                else
                {
                    MessageBox.Show(Timer_Label.Text + "\nAverage: " + convertseconds(i) + "\nFastest Time: " + convertseconds(i));
                }

                using (StreamWriter writer = new StreamWriter("../../easy/eTimes.txt"))
                {
                    foreach (string item in EasyTimer)
                    {
                        writer.WriteLine(item + " ");
                    }
                }
                
            }
            else if (gameDifficultyDropDown.Text == "Medium")
            {
                
            }
            else if (gameDifficultyDropDown.Text == "Hard")
            {
                
            }
        }
    }
}