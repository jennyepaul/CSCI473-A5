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

            string gameRecord;
            List<string> gameStats = new List<string>();

            //read in the info from an easy file and store into a list
            using (StreamReader inFile = new StreamReader("../../easy/e1.txt"))
            {
                while ((gameRecord = inFile.ReadLine()) != null)
                {
                    gameStats.Add(gameRecord);
                }
            }

            gameStats[0].Split('0');
            char val = gameStats[0][0];
            char val2 = gameStats[0][1];
            char val3 = gameStats[0][2];

            gameStats[1].Split('0');
            char val4 = gameStats[1][0];
            char val5 = gameStats[1][1];
            char val6 = gameStats[1][2];

            gameStats[2].Split('0');
            char val7 = gameStats[2][0];
            char val8 = gameStats[2][1];
            char val9 = gameStats[2][2];


            //addValuesToEasyBoard(val, val2, val3, val4, val5, val6, val7, val8, val9);

            /*
            //REMOVE THIS - just to test we have all info storing into the list
            foreach(var i in gameStats)
            {
                output.AppendText("info: " + i + "\n");
            }
            */
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

                    //TextBox txt = new TextBox();


                    //if user wanted to play an easy game, then paint a 3x3 
                    if (isEasyGame)
                    {
                        //easyPuzzleCell1textbox.Visible = true;
                        //easyPuzzleCell2Textbox.Visible = true;

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
                        // txt.Dispose();
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
                    }
                    else if (isHardGame)
                    {

                        resetEasyPuzzleTextboxes();

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
        private void addValuesToEasyBoard(char a, char b, char c, char d, char e, char f, char g, char h, char i)
        {
            //MAYBE ADD IT SO THAT USER CAN EDIT THE LABELS? OR ADD A TEXT AREA/ SET THE VALUES THAT ARE SET AND DISABLE EDITING
            //USE DRAW STRING --> ON ASSIGNMENT DIRECTIONS


            if (isDown)
            {
            }
        }
    }
}