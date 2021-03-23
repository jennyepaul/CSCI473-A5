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

        private static List<TextBox> generatedEasyTextboxes = new List<TextBox>();
        private static List<TextBox> generatedMedTextboxes = new List<TextBox>();


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

            resetEasyPuzzleTextboxes();
        }

        private void gameDifficultyDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            //depending what difficulty the user entered, we need to draw the corresponding playing field
            if (gameDifficultyDropDown.Text == "Easy")
            {
                isEasyGame = true;
            }
            else if (gameDifficultyDropDown.Text == "Medium")
            {
                isMediumGame = true;

            }
            else if (gameDifficultyDropDown.Text == "Hard")
            {
                isHardGame = true;
            }
        }
        private void canvas_Paint(object sender, PaintEventArgs e)
        {

            string gameRecordEasy1, gameRecordMedium1;
            List<string> gameStatsEasy1 = new List<string>();
            List<string> gameStatsMedium1 = new List<string>();

            List<char> gameValuesMedium1 = new List<char>();

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
           
            Graphics graphics = e.Graphics;
            if (isDown)
            {
                using (Pen gamePen = new Pen(Color.Black))
                {
                    gamePen.Width = 3;

                    //draw the perimeter lines
                    graphics.DrawLine(gamePen, 0, 0, W, 0);
                    graphics.DrawLine(gamePen, 0, L, W, L);

                    graphics.DrawLine(gamePen, 0, 0, 0, L);
                    graphics.DrawLine(gamePen, W, 0, W, L);

                    //if user wanted to play an easy game, then paint a 3x3 
                    if (isEasyGame)
                    {
                        //get rid of any textboxes from medium game
                        resetMediumPuzzleTextboxes();

                        //draw our vertical lines 
                        graphics.DrawLine(gamePen, W / 3, 0, W / 3, L);
                        graphics.DrawLine(gamePen, (2 * W / 3), 0, (2 * W / 3), L);

                        //draw horizontal lines
                        graphics.DrawLine(gamePen, 0, (L / 3), W, (L / 3));
                        graphics.DrawLine(gamePen, 0, (2 * L / 3), W, (2 * L / 3));

                        using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                        {
                            /*
                            for(int i = 1; i < 9; i++)
                            {
                                if (val != '0')
                                {
                                    PointF pointF1 = new PointF(W / 6, L / 6);
                                    e.Graphics.DrawString(val.ToString(), font1, Brushes.Black, pointF1);
                                }
                            }
                            */
                            //FIRST ROW OF VALUES
                            //cell 1
                            if (val != '0')
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
                            if (val2 != '0')
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
                            if (val3 != '0')
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
                            if (val4 != '0')
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
                            if (val5 != '0')
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
                            if (val6 != '0')
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
                            if (val7 != '0')
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
                            if (val8 != '0')
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
                            if (val9 != '0')
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
                        //get rid of any textboxes from hard game
                        resetEasyPuzzleTextboxes();

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

                        //go through the char values in the list, and if they are not 0, we can add to the board
                        //if they are zero, we need to create a text box so that the user can enter their guesses in
                        for(int i = 0; i < gameValuesMedium1.Count; i++)
                        {
                            if (gameValuesMedium1[i] != '0')
                            {
                                using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                                {
                                    //based on what index we are at, depends what cell the information goes in
                                    switch (i)
                                    {
                                        case 0:
                                            //we have a value so print that to the board
                                            PointF pointF1 = new PointF(W / 10, L / 10);
                                            e.Graphics.DrawString(gameValuesMedium1[i].ToString(), font1, Brushes.Black, pointF1);
                                            break;
                                        case 1:
                                            //we have a value so print that to the board
                                            PointF pointF2 = new PointF(3 * W / 10 - 10, L / 10);
                                            e.Graphics.DrawString(gameValuesMedium1[i].ToString(), font1, Brushes.Black, pointF2);
                                            break;
                                        case 2:
                                            //we have a value so print that to the board
                                            PointF pointF3 = new PointF(5 * W / 10 - 10, L / 10);
                                            e.Graphics.DrawString(gameValuesMedium1[i].ToString(), font1, Brushes.Black, pointF3);
                                            break;
                                        case 3:
                                            //we have a value so print that to the board
                                            PointF pointF4 = new PointF(7 * W / 10 - 10, L / 10);
                                            e.Graphics.DrawString(gameValuesMedium1[i].ToString(), font1, Brushes.Black, pointF4);
                                            break;
                                        case 4:
                                            //we have a value so print that to the board
                                            PointF pointF5 = new PointF(9* W / 10 - 10, L / 10);
                                            e.Graphics.DrawString(gameValuesMedium1[i].ToString(), font1, Brushes.Black, pointF5);
                                            break;
                                        case 5:
                                            //we have a value so print that to the board
                                            PointF pointF6 = new PointF(W / 10, 3 * L / 10);
                                            e.Graphics.DrawString(gameValuesMedium1[i].ToString(), font1, Brushes.Black, pointF6);
                                            break;
                                        case 6:
                                            //we have a value so print that to the board
                                            PointF pointF7 = new PointF(3 * W / 10, 3 * L / 10);
                                            e.Graphics.DrawString(gameValuesMedium1[i].ToString(), font1, Brushes.Black, pointF7);
                                            break;
                                        case 7:
                                            //we have a value so print that to the board
                                            PointF pointF8 = new PointF(5 * W / 10, 3 * L / 10);
                                            e.Graphics.DrawString(gameValuesMedium1[i].ToString(), font1, Brushes.Black, pointF8);
                                            break;
                                        case 8:
                                            //we have a value so print that to the board
                                            PointF pointF9 = new PointF(7 * W / 10, 3 * L / 10);
                                            e.Graphics.DrawString(gameValuesMedium1[i].ToString(), font1, Brushes.Black, pointF9);
                                            break;
                                        case 9:
                                            //we have a value so print that to the board
                                            PointF pointF10 = new PointF(9 * W / 10, 3 * L / 10);
                                            e.Graphics.DrawString(gameValuesMedium1[i].ToString(), font1, Brushes.Black, pointF10);
                                            break;


                                    }
                                }
                            }
                            else
                            {
                                //based on what index we are at, depends what cell the textbox will go in
                                if (i == 0)
                                {
                                    //it is zero, so user has to figure out what the value is
                                    Point pointF1 = new Point((W / 10) - 10, L / 10);
                                    TextBox txt = new TextBox();
                                    txt.Name = "medPuzzleCell1";
                                    txt.Text = "";
                                    txt.Location = pointF1;
                                    txt.Height = 30;
                                    txt.Width = 30;
                                    //txt.Font.Size = 24;
                                    canvas.Controls.Add(txt);
                                    generatedMedTextboxes.Add(txt);
                                    
                                }
                                else if(i == 1)
                                {
                                    //it is zero, so user has to figure out what the value is
                                    Point pointF2 = new Point(3 * W / 10 - 10, L / 10);
                                    TextBox txt = new TextBox();
                                    txt.Name = "medPuzzleCell2";
                                    txt.Text = "";
                                    txt.Location = pointF2;
                                    txt.Height = 30;
                                    txt.Width = 30;
                                    //txt.Font.Size = 24;
                                    canvas.Controls.Add(txt);
                                    generatedMedTextboxes.Add(txt);
                                }
                                else if( i == 2)
                                {
                                    //it is zero, so user has to figure out what the value is
                                    Point pointF3 = new Point(5 * W / 10 - 10, L / 10);
                                    TextBox txt = new TextBox();
                                    txt.Name = "medPuzzleCell3";
                                    txt.Text = "";
                                    txt.Location = pointF3;
                                    txt.Height = 30;
                                    txt.Width = 30;
                                    //txt.Font.Size = 24;
                                    canvas.Controls.Add(txt);
                                    generatedMedTextboxes.Add(txt);
                                }
                                else if( i ==3)
                                {
                                    //it is zero, so user has to figure out what the value is
                                    Point pointF4 = new Point(7 * W / 10 - 10, L / 10);
                                    TextBox txt = new TextBox();
                                    txt.Name = "medPuzzleCell4";
                                    txt.Text = "";
                                    txt.Location = pointF4;
                                    txt.Height = 30;
                                    txt.Width = 30;
                                    //txt.Font.Size = 24;
                                    canvas.Controls.Add(txt);
                                    generatedMedTextboxes.Add(txt);
                                }
                                else if(i == 4)
                                {
                                    //it is zero, so user has to figure out what the value is
                                     Point pointF5 = new Point(9 * W / 10 - 10, L / 10);
                                    TextBox txt = new TextBox();
                                    txt.Name = "medPuzzleCell5";
                                    txt.Text = "";
                                    txt.Location = pointF5;
                                    txt.Height = 30;
                                    txt.Width = 30;
                                    //txt.Font.Size = 24;
                                    canvas.Controls.Add(txt);
                                    generatedMedTextboxes.Add(txt);

                                }
                                else if( i == 5)
                                {
                                    //it is zero, so user has to figure out what the value is
                                    Point pointF6 = new Point( W / 10 - 10, 3 *  L / 10);
                                    TextBox txt = new TextBox();
                                    txt.Name = "medPuzzleCell6";
                                    txt.Text = "";
                                    txt.Location = pointF6;
                                    txt.Height = 30;
                                    txt.Width = 30;
                                    //txt.Font.Size = 24;
                                    canvas.Controls.Add(txt);
                                    generatedMedTextboxes.Add(txt);
                                }
                                else if( i == 6)
                                {
                                    //it is zero, so user has to figure out what the value is
                                    Point pointF7 = new Point(3 * W / 10 - 10, 3 * L / 10);
                                    TextBox txt = new TextBox();
                                    txt.Name = "medPuzzleCell7";
                                    txt.Text = "";
                                    txt.Location = pointF7;
                                    txt.Height = 30;
                                    txt.Width = 30;
                                    //txt.Font.Size = 24;
                                    canvas.Controls.Add(txt);
                                    generatedMedTextboxes.Add(txt);
                                }
                                else if(i == 7)
                                {
                                    //it is zero, so user has to figure out what the value is
                                    Point pointF8 = new Point( 5 * W / 10 - 10, 3 * L / 10);
                                    TextBox txt = new TextBox();
                                    txt.Name = "medPuzzleCell8";
                                    txt.Text = "";
                                    txt.Location = pointF8;
                                    txt.Height = 30;
                                    txt.Width = 30;
                                    //txt.Font.Size = 24;
                                    canvas.Controls.Add(txt);
                                    generatedMedTextboxes.Add(txt);
                                }
                                else if(i == 8)
                                {
                                    //it is zero, so user has to figure out what the value is
                                    Point pointF9 = new Point(7 * W / 10 - 10, 3 * L / 10);
                                    TextBox txt = new TextBox();
                                    txt.Name = "medPuzzleCell9";
                                    txt.Text = "";
                                    txt.Location = pointF9;
                                    txt.Height = 30;
                                    txt.Width = 30;
                                    //txt.Font.Size = 24;
                                    canvas.Controls.Add(txt);
                                    generatedMedTextboxes.Add(txt);
                                }
                                else if(i ==9)
                                {
                                    //it is zero, so user has to figure out what the value is
                                    Point pointF10 = new Point(9 * W / 10 - 10, 3 * L / 10);
                                    TextBox txt = new TextBox();
                                    txt.Name = "medPuzzleCell10";
                                    txt.Text = "";
                                    txt.Location = pointF10;
                                    txt.Height = 30;
                                    txt.Width = 30;
                                    //txt.Font.Size = 24;
                                    canvas.Controls.Add(txt);
                                    generatedMedTextboxes.Add(txt);
                                }
                            
                            }
                        }
                    }
                    else if (isHardGame)
                    {
                        //get rid of any textboxes from medium and easy game
                        resetEasyPuzzleTextboxes();
                        resetMediumPuzzleTextboxes();

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
                    }
                }
            }
        }

        private void newGameButton_MouseDown(object sender, MouseEventArgs e)
        {
            isDown = true;
            canvas.Refresh();
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
    }
}