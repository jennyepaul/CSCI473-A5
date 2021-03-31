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

        private static bool highlightValue = false; 
        private static string easyGame;
        private static string easyGame1;
        private static string mediumGame;
        private static string mediumGame1;
        private static string hardGame;
        private static int gameBoardCount = 1;
        private static bool isNewGame = false;
        private static bool isEasyGame = false;
        private static bool isMediumGame = false;
        private static bool isHardGame = false;
        private static bool isDown = false;
        private static bool isBoardLoaded = false;
        private static bool isEasyBoard = false;
        private static bool isMediumBoard = false;
        private static bool isHardBoard = false;
        private static bool Hide_Board = false;
        private static bool Paused = false;
        private static bool isDeletedValue = false;
        private static bool EasyRowCompleted = false;
        private static bool MediumRowCompleted = false;
        private static bool HardRowCompleted = false;
        private static bool EasyColCompleted = false;
        private static bool MediumColCompleted = false;
        private static bool HardColCompleted = false;
        private static bool EasyDiagnalCompleted1 = false;
        private static bool EasyDiagnalCompleted2 = false;
        private static bool MediumDiagnalCompleted1 = false;
        private static bool MediumDiagnalCompleted2 = false;
        private static bool HardDiagnalCompleted1 = false;
        private static bool HardDiagnalCompleted2 = false;
        private static bool Complete = false;
        private static bool Saved = false;

        //all totals variables  for an easy board
        private static int row1EasySum = 0;
        private static int row2EasySum = 0;
        private static int row3EasySum = 0;
        private static int diagnal1EasySum = 0;
        private static int diagnal2EasySum = 0;
        private static int col1EasySum = 0;
        private static int col2EasySum = 0;
        private static int col3EasySum = 0;
        //actual answer for easy board
        private static int row1AnswerEasy = 0;
        private static int row2AnswerEasy = 0;
        private static int row3AnswerEasy = 0;
        private static int col1AnswerEasy = 0;
        private static int col2AnswerEasy= 0;
        private static int col3AnswerEasy= 0;
        private static int diagnal1AnswerEasy = 0;
        private static int diagnal2AnswerEasy = 0;

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

        //actual totals variables for a medium board
        private static int row1AnswerMed = 0;
        private static int row2AnswerMed = 0;
        private static int row3AnswerMed = 0;
        private static int row4AnswerMed = 0;
        private static int row5AnswerMed = 0;
        private static int col1AnswerMed = 0;
        private static int col2AnswerMed = 0;
        private static int col3AnswerMed = 0;
        private static int col4AnswerMed = 0;
        private static int col5AnswerMed = 0;
        private static int diagnal1AnswerMed = 0;
        private static int diagnal2AnswerMed = 0;


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

        //actual totals variables for hard board
        private static int row1AnswerHard = 0;
        private static int row2AnswerHard = 0;
        private static int row3AnswerHard = 0;
        private static int row4AnswerHard = 0;
        private static int row5AnswerHard = 0;
        private static int row6AnswerHard = 0;
        private static int row7AnswerHard = 0;
        private static int col1AnswerHard= 0;
        private static int col2AnswerHard = 0;
        private static int col3AnswerHard = 0;
        private static int col4AnswerHard = 0;
        private static int col5AnswerHard = 0;
        private static int col6AnswerHard = 0;
        private static int col7AnswerHard = 0;
        private static int diagnal1AnswerHard = 0;
        private static int diagnal2AnswerHard = 0;

        public static List<TextBox> generatedEasyTextboxes = new List<TextBox>();
        public static List<TextBox> generatedMedTextboxes = new List<TextBox>();
        public static List<TextBox> generatedHardTextboxes = new List<TextBox>();

        private static List<string> gameStatsEasy1 = new List<string>();
        private static List<string> gameStatsMedium1 = new List<string>();
        private static List<string> gameStatsHard1 = new List<string>();

        public static List<char> gameValuesEasy1 = new List<char>();
        public static List<char> gameValuesMedium1 = new List<char>();
        public static List<char> gameValuesHard1 = new List<char>();

        public static List<char> gameAnswersEasy1 = new List<char>();
        public static List<char> gameAnswersMed1 = new List<char>();
        public static List<char> gameAnswersHard1 = new List<char>();

        public static List<int> textboxesGuessed = new List<int>();


        public static List<string> EasyTimer = new List<string>();
        public static List<string> MedTimer = new List<string>();
        public static List<string> HardTimer = new List<string>();
        public static int easy_itr = 0;
        public static int med_itr = 0;
        public static int hard_itr = 0;
        public static int newgame_itr = 0;

        public static List<string> EasySaved = new List<string>();
        public static List<string> MediumSaved = new List<string>();

        //counters to tell us when a user finished guessing in rows, columns, and diagnals
        public static int row1Counter = 0;
        public static int row2Counter = 0;
        public static int row3Counter = 0;
        public static int row4Counter = 0;
        public static int row5Counter = 0;
        public static int row6Counter = 0;
        public static int row7Counter = 0;
        public static int col1Counter = 0;
        public static int col2Counter = 0;
        public static int col3Counter = 0;
        public static int col4Counter = 0;
        public static int col5Counter = 0;
        public static int col6Counter = 0;
        public static int col7Counter = 0;
        public static int diagnal1Counter = 0;
        public static int diagnal2Counter = 0;

        public static int L;
        public static int W;

        public static int timerticks;

        //for timer, starts at 0 and counts up, will reset when we pick a new game or reset the board
        public static int i = 0;

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
            //clear all the lists that hold the values when we switch a game
            //gameValuesEasy1.Clear();
            //gameValuesMedium1.Clear();
            //gameValuesHard1.Clear();
            isDown = false;

            //depending what difficulty the user entered, we need to draw the corresponding playing field
            if (gameDifficultyDropDown.Text == "Easy")
            {
                //reset all counters from previous game
                row1Counter = 0;
                row2Counter = 0;
                row3Counter = 0;
                col1Counter = 0;
                col2Counter = 0;
                col3Counter = 0;
                diagnal1Counter = 0;
                diagnal2Counter = 0;
                isEasyGame = true;
                resetMediumPuzzleTextboxes();
                resetHardPuzzleTextboxes();
            }
            else if (gameDifficultyDropDown.Text == "Medium")
            {
                isMediumGame = true;
               
                //reset all counters from previous game
                row1Counter = 0;
                row2Counter = 0;
                row3Counter = 0;
                row4Counter = 0;
                row5Counter = 0;
                col1Counter = 0;
                col2Counter = 0;
                col3Counter = 0;
                row4Counter = 0;
                row5Counter = 0;
                diagnal1Counter = 0;
                diagnal2Counter = 0;

                resetEasyPuzzleTextboxes();
                resetHardPuzzleTextboxes();
            }
            else if (gameDifficultyDropDown.Text == "Hard")
            {
                //reset all counter from previous game
                row1Counter = 0;
                row2Counter = 0;
                row3Counter = 0;
                row4Counter = 0;
                row5Counter = 0;
                row6Counter = 0;
                row7Counter = 0;
                col1Counter = 0;
                col2Counter = 0;
                col3Counter = 0;
                col4Counter = 0;
                col5Counter = 0;
                col6Counter = 0;
                col7Counter = 0;
                diagnal1Counter = 0;
                diagnal2Counter = 0;
                isHardGame = true;
                resetEasyPuzzleTextboxes();
                resetMediumPuzzleTextboxes();
            }
        }
        private void readInFileInfo()
        {
            string gameRecordEasy1, gameRecordMedium1, gameRecordHard1;
            //if the user wants a new game
            if (isNewGame)
            {
                //based on what game difficulty they want & if they have solved other puzzles
                //of that difficulty depends on which puzzle gets loaded, if they want easy and they have
                //solved e1 (count == 2), then we load easy puzzle 2
                if (isEasyGame)
                {
                    if (gameBoardCount == 1)
                    {
                        easyGame1 = "../../easy/e1.txt";
                        easyGame = "../../easy/e1Save.txt";
                    }
                    else if (gameBoardCount == 2)
                    {
                        easyGame1 = "../../easy/e2.txt";
                        easyGame = "../../easy/e2Save.txt";
                        gameStatsEasy1.Clear();
                        gameValuesEasy1.Clear();
                        gameAnswersEasy1.Clear();
                    }
                    else if(gameBoardCount == 3)
                    {
                        easyGame1 = "../../easy/e3.txt";
                        easyGame = "../../easy/e3Save.txt";
                        gameStatsEasy1.Clear();
                        gameValuesEasy1.Clear();
                        gameAnswersEasy1.Clear();
                    }
                    //read in the info from an easy 1  file and store into a list
                    using (StreamReader inFile = new StreamReader(easyGame1))
                    {

                        while ((gameRecordEasy1 = inFile.ReadLine()) != null)
                        {
                            gameStatsEasy1.Add(gameRecordEasy1);
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
                    //add the answer key values into a list
                    for (int n = 4; n < 7; n++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            gameAnswersEasy1.Add(gameStatsEasy1[n][j]);
                        }
                    }
                    //add the values from file into the easy saved file 	
                    for (int i = 0; i < 9; i++)
                    {
                        if (gameValuesEasy1[i] == '0')
                        {
                            EasySaved.Add("");
                        }
                        else
                        {
                            EasySaved.Add(gameValuesEasy1[i].ToString());
                        }
                    }
                }
                if (isMediumGame)
                { 
                    if (gameBoardCount == 1)
                    {
                        mediumGame1 = "../../medium/m1.txt";
                        mediumGame = "../../medium/m1Save.txt";
                    }
                    else if (gameBoardCount == 2)
                    {
                        mediumGame1 = "../../medium/m2.txt";
                        mediumGame = "../../medium/m2Save.txt";
                        gameStatsMedium1.Clear();
                        gameValuesMedium1.Clear();
                        gameAnswersMed1.Clear();
                    }
                    else if (gameBoardCount == 3)
                    {
                        mediumGame1 = "../../medium/m3.txt";
                        mediumGame = "../../medium/m3Save.txt";
                        gameStatsMedium1.Clear();
                        gameValuesMedium1.Clear();
                        gameAnswersMed1.Clear();
                    }
                
                    //read in the info from an medium 1  file and store into a list
                    using (StreamReader inFile = new StreamReader(mediumGame1))
                    {
                        while ((gameRecordMedium1 = inFile.ReadLine()) != null)
                        {
                            gameStatsMedium1.Add(gameRecordMedium1);
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
                    //add the answer key values into a list
                    for (int n = 6; n < 11; n++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            gameAnswersMed1.Add(gameStatsMedium1[n][j]);
                        }
                    }
                    //put values in the medium saved list	
                    for (int i = 0; i < 25; i++)
                    {
                        if (gameValuesMedium1[i] == '0')
                        {
                            MediumSaved.Add("");
                        }
                        else
                        {
                            MediumSaved.Add(gameValuesMedium1[i].ToString());
                        }
                    }
                }
                if (isHardGame)
                {
                    if (gameBoardCount == 1)
                    {
                        hardGame = "../../hard/h1.txt";
                    }
                    else if (gameBoardCount == 2)
                    {
                        hardGame = "../../hard/h2.txt";
                        gameStatsHard1.Clear();
                        gameValuesHard1.Clear();
                        gameAnswersHard1.Clear();
                    }
                    else if (gameBoardCount == 3)
                    {
                        hardGame = "../../hard/h3.txt";
                        gameStatsHard1.Clear();
                        gameValuesHard1.Clear();
                        gameAnswersHard1.Clear();
                    }
                    //read in the info from an hard 1  file and store into a list
                    using (StreamReader inFile = new StreamReader(hardGame))
                    {
                        while ((gameRecordHard1 = inFile.ReadLine()) != null)
                        {
                            gameStatsHard1.Add(gameRecordHard1);
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
                    //add the answer key values into a list
                    for (int n = 8; n < 15; n++)
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            gameAnswersHard1.Add(gameStatsHard1[n][j]);
                        }
                    }
                }
            }
        }
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            readInFileInfo();
           
            //draw the board
            Graphics graphics = e.Graphics;

            //if the user pressed down or is reading 
            if (isDown || highlightValue)
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
                        int xSub = 0;
                        int ySub = 0;
                        for (int c = 0; c < 9; c++)
                        {
                            if (Hide_Board)
                            {

                                PointF point = new PointF(xPoints[xSub] * (W / 6), yPoints[ySub] * (L / 6));
                                e.Graphics.DrawString("?", Font, Brushes.Black, point);
                            }

                            else if (gameValuesEasy1[c] != '0')
                            {
                                using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                                {
                                    //we have a value so print that to the board
                                    PointF point = new PointF(xPoints[xSub] * (W / 6), yPoints[ySub] * (L / 6));
                                    e.Graphics.DrawString(gameValuesEasy1[c].ToString(), font1, Brushes.Black, point);
                                    TextBox txt = new TextBox();
                                    txt.Name = "easyPuzzleCell" + c;
                                    generatedEasyTextboxes.Add(txt);
                                    txt.Visible = false;
                                }
                            }
                            else
                            {   
                                Point point2 = new Point(xPoints[xSub] * (W / 6) - 10, yPoints[ySub] * (L / 6));
                                TextBox txt = new TextBox();
                                txt.Name = "easyPuzzleCell" + c;
                                if (Saved)
                                {
                                    //if a value has been saved then load it into the textbox	
                                    txt.Text = EasySaved[c];
                                    if (txt.Text != "")
                                    {
                                        txt.Click += numberInput;
                                    }
                                }
                                else
                                {
                                    txt.Text = "";
                                }
                                txt.Location = point2;
                                txt.Height = 30;
                                txt.Width = 30;
                                txt.Font = new Font(txt.Font.FontFamily, 14);                      
                                generatedEasyTextboxes.Add(txt);
                                txt.TextChanged += numberInput;
                                txt.KeyDown += deletedValue;                                
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
                        isEasyGame = false;

                        //draw the textboxes on the board now
                        for (int i = 0; i < generatedEasyTextboxes.Count; i++)
                        {
                            canvas.Controls.Add(generatedEasyTextboxes[i]);
                        }

                        
                    }
                    else if (isMediumGame)
                    {
                        isMediumBoard = true;
                        generatedEasyTextboxes.Clear();
                        generatedHardTextboxes.Clear();
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
                                //replace all the squares with a "?" to hide the board from the player
                                PointF point = new PointF(xPoints[xSub] * (W / 10), yPoints[ySub] * (L / 10));
                                e.Graphics.DrawString("?", Font, Brushes.Black, point);
                            }
                            else if (gameValuesMedium1[c] != '0')
                            {
                                using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                                {
                                    //we have a value so print that to the board
                                    PointF point = new PointF(xPoints[xSub] * (W / 10), yPoints[ySub] * (L / 10));
                                    e.Graphics.DrawString(gameValuesMedium1[c].ToString(), font1, Brushes.Black, point);
                                    TextBox txt = new TextBox();
                                    txt.Name = "medPuzzleCell" + c;
                                    generatedMedTextboxes.Add(txt);
                                    txt.Visible = false;
                                }
                            }
                            else
                            {
                                Point point2 = new Point(xPoints[xSub] * (W / 10) - 10, yPoints[ySub] * (L / 10));
                                TextBox txt = new TextBox();
                                txt.Name = "medPuzzleCell" + c;
                                if (Saved)
                                {
                                    //if a value has been saved then load it into the textbox	
                                    txt.Text = MediumSaved[c];
                                    if (txt.Text != "")
                                    {
                                        txt.Click += numberInput;
                                    }
                                }
                                else
                                {
                                    txt.Text = "";
                                }
                                txt.Location = point2;
                                txt.Height = 30;
                                txt.Width = 30;
                                txt.Font = new Font(txt.Font.FontFamily, 14);
                                generatedMedTextboxes.Add(txt);
                                txt.TextChanged += numberInput;
                                txt.KeyDown += deletedValue;

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
                        isMediumGame = false;

                        //draw the textboxes on the board now
                        for (int i = 0; i < generatedMedTextboxes.Count; i++)
                        {
                            canvas.Controls.Add(generatedMedTextboxes[i]);
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
                                //replace each square with a "?" to hide the board from the user
                                PointF point = new PointF(xPoints[xSub] * (W / 14), yPoints[ySub] * (L / 14));
                                e.Graphics.DrawString("?", Font, Brushes.Black, point);
                            }
                            //if the value is not a zero, then we want to print it on the board
                            else if (gameValuesHard1[z] != '0')
                            {
                                using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                                {
                                    //we have a value so print that to the board
                                    PointF point = new PointF(xPoints[xSub] * (W / 14), yPoints[ySub] * (L / 14) - 10);
                                    e.Graphics.DrawString(gameValuesHard1[z].ToString(), font1, Brushes.Black, point);
                                    TextBox txt = new TextBox();
                                    txt.Name = "hardPuzzleCell" + z;
                                    generatedHardTextboxes.Add(txt);
                                    txt.Visible = false;
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
                                generatedHardTextboxes.Add(txt);
                                txt.KeyDown += deletedValue;
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
                    isHardGame = false;

                    //draw the textboxes on the board now
                    for (int i = 0; i < generatedHardTextboxes.Count; i++)
                    {
                        canvas.Controls.Add(generatedHardTextboxes[i]);
                    }
                }
                //if we want to see our progress & we have wrong values then highlight that area on the board
                if(highlightValue)
                {
                    highLightWrongArea(e);
                }
            }
            isBoardLoaded = true;
        }
         
        //these 3 functions calculate the ACTUAL answers for Easy board rows, columns, and diagnals
        private void calculateAnswerEasyRow(List<char> list1)
        {
            int val;
            //calculate the answer key for the easy board's rows
            for (int i = 0; i < 3; i++)
            {
                val = int.Parse(list1[i].ToString());
                row1AnswerEasy += val;
            }

            for (int i = 3; i < 6; i++)
            {
                val = int.Parse(list1[i].ToString());
                row2AnswerEasy += val;
            }

            for (int i = 6; i < 9; i++)
            {
                val = int.Parse(list1[i].ToString());
                row3AnswerEasy += val;
            }
            //output.AppendText("row answers after row adding are:  " + row1AnswerEasy + ", " + row2AnswerEasy + ", " + row3AnswerEasy + "\n");

        }
        private void calculateAnswerEasyColSums(List<char> list1)
        {
            int val;

            //go through the easy board and calculate the answer key 
            for (int i = 0; i < 9; i += 3)
            {
                val = int.Parse(list1[i].ToString());
                col1AnswerEasy += val;
            }

            for (int i = 1; i < 9; i += 3)
            {
                val = int.Parse(list1[i].ToString());
                col2AnswerEasy += val;
            }

            for (int i = 2; i < 9; i += 3)
            {
                val = int.Parse(list1[i].ToString());
                col3AnswerEasy += val;
            }

        }
        private void calculateAnswerEasyDiagnalSums(List<char> list1)
        {
            int val;

            //go through the easy board
            for (int i = 2; i < 7; i += 2)
            {
                val = int.Parse(list1[i].ToString());
                diagnal1AnswerEasy += val;
            }

            //go through the easy board
            for (int i = 0; i < 9; i += 4)
            {
                val = int.Parse(list1[i].ToString());
                diagnal2AnswerEasy += val;
            }
        }

        //these 3 functions calculate the DERIVED answers for Easy board rows, columns, and diagnals
        private void calculateInitialEasyRowSums(List<char> list1)
        {
            int val;

            //go through the easy board
            for (int i = 0; i < 3; i++)
            {
                val = int.Parse(list1[i].ToString());
                row1EasySum += val;

                //if the value is not 0, then add it to the counter for rows since theres a value
                //once we hit 3 values the row is done being guessed/completed and the total will be
                //red or green depending how accurate it is compared to the actual total
                if(list1[i] != '0')
                {
                    row1Counter += 1;
                }
            }

            for (int i = 3; i < 6; i++)
            {
                
                val = int.Parse(list1[i].ToString());
                row2EasySum += val;
                if (list1[i] != '0')
                {
                    row2Counter += 1;
                }
            }

            for (int i = 6; i < 9; i++)
            {
                val = int.Parse(list1[i].ToString());
                row3EasySum += val;
                if (list1[i] != '0')
                {
                    row3Counter += 1;
                }
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
                if(list1[i] != '0')
                {
                    col1Counter += 1;
                }
            }

            for (int i = 1; i < 9; i += 3)
            {
                val = int.Parse(list1[i].ToString());
                col2EasySum += val;
                if (list1[i] != '0')
                {
                    col2Counter += 1;
                }
            }

            for (int i = 2; i < 9; i += 3)
            {
                val = int.Parse(list1[i].ToString());
                col3EasySum += val;
                if (list1[i] != '0')
                {
                    col3Counter += 1;
                }
            }

        }
        private void calculateInitialEasyDiagnalSums(List<char> list1)
        {
            int val;

            //go through the easy board
            for (int i = 2; i < 7; i += 2)
            {
                val = int.Parse(list1[i].ToString());
                diagnal1EasySum += val;
                if(list1[i] != '0')
                {
                    diagnal1Counter++;
                }
            }
            //go through the easy board
            for (int i = 0; i < 9; i += 4)
            {
                val = int.Parse(list1[i].ToString());
                diagnal2EasySum += val;
                if (list1[i] != '0')
                {
                    diagnal2Counter++;
                }
            }
        }

        //these 3 functions calculate the ACTUAL answers for Medium board rows, columns, and diagnals
        private void calculateAnswerMedRow(List<char> list1)
        {
            int val;
            //go through the medium board
            for (int i = 0; i < 5; i++)
            {
                val = int.Parse(list1[i].ToString());
                row1AnswerMed += val;
            }

            for (int i = 5; i < 10; i++)
            {
                val = int.Parse(list1[i].ToString());
                row2AnswerMed += val;
            }

            for (int i = 10; i < 15; i++)
            {
                val = int.Parse(list1[i].ToString());
                row3AnswerMed += val;
            }
            for (int i = 15; i < 20; i++)
            {
                val = int.Parse(list1[i].ToString());
                row4AnswerMed += val;
            }
            for (int i = 20; i < 25; i++)
            {
                val = int.Parse(list1[i].ToString());
                row5AnswerMed += val;
            }
        }
        private void calculateAnswerMedColSums(List<char> list1)
        {
            int val;
            //go through the medium board
            for (int i = 0; i < 21; i += 5)
            {
                val = int.Parse(list1[i].ToString());
                col1AnswerMed += val;
            }

            for (int i = 1; i < 22; i += 5)
            {
                val = int.Parse(list1[i].ToString());
                col2AnswerMed += val;
            }

            for (int i = 2; i < 23; i += 5)
            {
                val = int.Parse(list1[i].ToString());
                col3AnswerMed += val;
            }
            for (int i = 3; i < 24; i += 5)
            {
                val = int.Parse(list1[i].ToString());
                col4AnswerMed += val;
            }
            for (int i = 4; i < 25; i += 5)
            {
                val = int.Parse(list1[i].ToString());
                col5AnswerMed += val;
            }
        }
        private void calculateAnswerMedDiagnalSums(List<char> list1)
        {
            int val;

            //go through the medium board
            for (int i = 4; i < 21; i += 4)
            {
                val = int.Parse(list1[i].ToString());
                diagnal1AnswerMed += val;
            }

            //go through the medium board
            for (int i = 0; i < 25; i += 6)
            {
                val = int.Parse(list1[i].ToString());
                diagnal2AnswerMed += val;
            }
        }

        //these 3 functions calculate the DERIVED answers for Medium board rows, columns, and diagnals
        private void calculateInitialMediumRowSums(List<char> list1)
        {
            int val;
            //go through the medium board
            for (int i = 0; i < 5; i++)
            {
                val = int.Parse(list1[i].ToString());
                row1MediumSum += val;
                if(list1[i] != '0')
                {
                    row1Counter++;
                }
            }

            for (int i = 5; i < 10; i++)
            {
                val = int.Parse(list1[i].ToString());
                row2MediumSum += val;
                if (list1[i] != '0')
                {
                    row2Counter++;
                }
            }

            for (int i = 10; i < 15; i++)
            {
                val = int.Parse(list1[i].ToString());
                row3MediumSum += val;
                if (list1[i] != '0')
                {
                    row3Counter++;
                }
            }
            for (int i = 15; i < 20; i++)
            {
                val = int.Parse(list1[i].ToString());
                row4MediumSum += val;
                if (list1[i] != '0')
                {
                    row4Counter++;
                }
            }
            for (int i = 20; i < 25; i++)
            {
                val = int.Parse(list1[i].ToString());
                row5MediumSum += val;
                if (list1[i] != '0')
                {
                    row5Counter++;
                }
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
                if(list1[i] != '0')
                {
                    col1Counter++;
                }
            }

            for (int i = 1; i < 22; i+=5)
            {
                val = int.Parse(list1[i].ToString());
                col2MediumSum += val;
                if (list1[i] != '0')
                {
                    col2Counter++;
                }
            }

            for (int i = 2; i < 23; i+=5)
            {
                val = int.Parse(list1[i].ToString());
                col3MediumSum += val;
                if (list1[i] != '0')
                {
                    col3Counter++;
                }
            }
            for (int i = 3; i < 24; i+=5)
            {
                val = int.Parse(list1[i].ToString());
                col4MediumSum += val;
                if (list1[i] != '0')
                {
                    col4Counter++;
                }
            }
            for (int i = 4; i < 25; i+=5)
            {
                val = int.Parse(list1[i].ToString());
                col5MediumSum += val;
                if (list1[i] != '0')
                {
                    col5Counter++;
                }
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

        //these 3 functions calculate the ACTUAL answers for Hard board rows, columns, and diagnals
        private void calculateAnswerHardRowSums(List<char> list1)
        {
            int val;
            //go through the hard board rows and calculate the actual row totals
            for (int i = 0; i < 7; i++)
            {
                val = int.Parse(list1[i].ToString());
                row1AnswerHard += val;
            }

            for (int i = 7; i < 14; i++)
            {
                val = int.Parse(list1[i].ToString());
                row2AnswerHard += val;
            }

            for (int i = 14; i < 21; i++)
            {
                val = int.Parse(list1[i].ToString());
                row3AnswerHard += val;
            }
            for (int i = 21; i < 28; i++)
            {
                val = int.Parse(list1[i].ToString());
                row4AnswerHard += val;
            }
            for (int i = 28; i < 35; i++)
            {
                val = int.Parse(list1[i].ToString());
                row5AnswerHard += val;
            }
            for (int i = 35; i < 42; i++)
            {
                val = int.Parse(list1[i].ToString());
                row6AnswerHard += val;
            }
            for (int i = 42; i < 49; i++)
            {
                val = int.Parse(list1[i].ToString());
                row7AnswerHard += val;
            }
        }
        private void calculateAnswerHardColSums(List<char> list1)
        {
            int val;
            //go through the hard board columns and calculate the actual totals to display
            for (int i = 0; i < 43; i += 7)
            {
                val = int.Parse(list1[i].ToString());
                col1AnswerHard += val;
            }

            for (int i = 1; i < 44; i += 7)
            {
                val = int.Parse(list1[i].ToString());
                col2AnswerHard += val;
            }

            for (int i = 2; i < 45; i += 7)
            {
                val = int.Parse(list1[i].ToString());
                col3AnswerHard += val;
            }
            for (int i = 3; i < 46; i += 7)
            {
                val = int.Parse(list1[i].ToString());
                col4AnswerHard += val;
            }
            for (int i = 4; i < 47; i += 7)
            {
                val = int.Parse(list1[i].ToString());
                col5AnswerHard += val;
            }
            for (int i = 5; i < 48; i += 7)
            {
                val = int.Parse(list1[i].ToString());
                col6AnswerHard += val;
            }
            for (int i = 6; i < 49; i += 7)
            {
                val = int.Parse(list1[i].ToString());
                col7AnswerHard += val;
            }
        }
        private void calculateAnswerHardDiagnalSums(List<char> list1)
        {
            int val;

            //go through the hard board and calc derived totals
            for (int i = 6; i < 43; i += 6)
            {
                val = int.Parse(list1[i].ToString());
                diagnal1AnswerHard += val;
            }

            //go through the hard board and calc derived totals
            for (int i = 0; i < 49; i += 8)
            {
                val = int.Parse(list1[i].ToString());
                diagnal2AnswerHard += val;
            }
        }

        //these 3 functions calculate the DERIVED answers for Hardboard rows, columns, and diagnals
        private void calculateInitialHardRowSums(List<char> list1)
        {
            int val;
            //go through the hard board rows and calculate the initial values
            for (int i = 0; i < 7; i++)
            {
                val = int.Parse(list1[i].ToString());
                row1HardSum += val;
                if(list1[i] != '0')
                {
                    row1Counter++;
                }
            }

            for (int i = 7; i < 14; i++)
            {
                val = int.Parse(list1[i].ToString());
                row2HardSum += val;
                if (list1[i] != '0')
                {
                    row2Counter++;
                }
            }

            for (int i = 14; i < 21; i++)
            {
                val = int.Parse(list1[i].ToString());
                row3HardSum += val;
                if (list1[i] != '0')
                {
                    row3Counter++;
                }
            }
            for (int i = 21; i < 28; i++)
            {
                val = int.Parse(list1[i].ToString());
                row4HardSum += val;
                if (list1[i] != '0')
                {
                    row4Counter++;
                }
            }
            for (int i = 28; i < 35; i++)
            {
                val = int.Parse(list1[i].ToString());
                row5HardSum += val;
                if (list1[i] != '0')
                {
                    row5Counter++;
                }
            }
            for (int i = 35; i < 42; i++)
            {
                val = int.Parse(list1[i].ToString());
                row6HardSum += val;
                if (list1[i] != '0')
                {
                    row6Counter++;
                }
            }
            for (int i = 42; i < 49; i++)
            {
                val = int.Parse(list1[i].ToString());
                row7HardSum += val;
                if (list1[i] != '0')
                {
                    row7Counter++;
                }
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
                if(list1[i] != '0')
                {
                    col1Counter++;
                }
            }

            for (int i = 1; i < 44; i+=7)
            {
                val = int.Parse(list1[i].ToString());
                col2HardSum += val;
                if (list1[i] != '0')
                {
                    col2Counter++;
                }
            }

            for (int i = 2; i < 45; i+=7)
            {
                val = int.Parse(list1[i].ToString());
                col3HardSum += val;
                if (list1[i] != '0')
                {
                    col3Counter++;
                }
            }
            for (int i = 3; i < 46; i+=7)
            {
                val = int.Parse(list1[i].ToString());
                col4HardSum += val;
                if (list1[i] != '0')
                {
                    col4Counter++;
                }
            }
            for (int i = 4; i < 47; i+=7)
            {
                val = int.Parse(list1[i].ToString());
                col5HardSum += val;
                if (list1[i] != '0')
                {
                    col5Counter++;
                }
            }
            for (int i = 5; i < 48; i+=7)
            {
                val = int.Parse(list1[i].ToString());
                col6HardSum += val;
                if (list1[i] != '0')
                {
                    col6Counter++;
                }
            }
            for (int i = 6; i < 49; i+=7)
            {
                val = int.Parse(list1[i].ToString());
                col7HardSum += val;
                if (list1[i] != '0')
                {
                    col7Counter++;
                }
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
                if (list1[i] != '0')
                {
                    diagnal1Counter++;
                }
            }

            //go through the medium board
            for (int i = 0; i < 49; i += 8)
            {
                val = int.Parse(list1[i].ToString());
                diagnal2HardSum += val;
                if (list1[i] != '0')
                {
                    diagnal2Counter++;
                }
            }
        }
        
        //if the user deletes a value, then subtract that from the derived totals
        private void deletedValue(object sender, KeyEventArgs e)
        {
            
            TextBox textbox = (TextBox)sender;
            int value; 

            //if they deleted a value from the board while guessing
            //we need to update the totals to reflect that
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                isDeletedValue = true;                
                //set flags based on what board we are building
                if (textbox.Name.Contains("easy"))
                {
                    isEasyBoard = true;
                    isMediumBoard = false;
                    isHardBoard = false;
                }
                if (textbox.Name.Contains("med"))
                {
                    isMediumBoard = true;
                    isEasyBoard = false;
                    isHardBoard = false;
                }
                if (textbox.Name.Contains("hard"))
                {
                    isHardBoard = true;
                    isMediumBoard = false;
                    isEasyBoard = false;
                }
                //if we can parse it to an integer then do math
                if (int.TryParse(textbox.Text, out value))
                {
                    numberInputChange(textbox);
                }
            }
        }
        
        //whenever a number input changes on the board, we need to recalculate the derived totals
        private void numberInput(object sender,  EventArgs e)
        {
            int value;
            TextBox textbox = (TextBox)sender;
            //set flags based on what board we are building
            if (textbox.Name.Contains("easy"))
            {
                isEasyBoard = true;
                isMediumBoard = false;
                isHardBoard = false;

                //place the saved value into the textbox	
                string newValue = textbox.Text;
                char oldvalue = textbox.Name.Last();
                int index = int.Parse(oldvalue.ToString());
                if (index != -1)
                {
                    EasySaved[index] = newValue;
                }
            }
            if (textbox.Name.Contains("med"))
            {
                isMediumBoard = true;
                isEasyBoard = false;
                isHardBoard = false;

                //place the saved value into the textbox	
                string newValue = textbox.Text;
                char oldvalue = textbox.Name.Last();
                string name = textbox.Name;
                string sub_name = name.Substring(name.Length - 2);
                int num = 0;
                bool can_convert = int.TryParse(sub_name, out num);
                int index;
                if (can_convert)
                {
                    index = int.Parse(sub_name);
                }
                else
                {
                    index = int.Parse(oldvalue.ToString());
                }

                if (index != -1)
                {
                    MediumSaved[index] = newValue;
                }
            }
            if (textbox.Name.Contains("hard"))
            {
                isHardBoard = true;
                isMediumBoard = false;
                isEasyBoard = false;
            }
            
            //if we can parse it to an integer then do math because it is a valid number
            if (int.TryParse(textbox.Text, out value))
            {
                numberInputChange(textbox);
            }
            //else user entered something else so not valid
            else
            {
                if(textbox.Text != "")
                {
                    MessageBox.Show("Please enter numbers 1-9 only");
                }
            }
            isDeletedValue = false;
        }
        private void numberInputChange(TextBox textbox)
        {
            int value;
            value = int.Parse(textbox.Text);

            //if we deleted the value, then we need to subtract from the total
            if (isDeletedValue)
            {
                value *= -1;
            }
            if (isEasyBoard)
            {
                //row changing total values
                //if the textbox name contains "easy" or any value between 0-2, we know we are in the first row
                if (textbox.Name == "easyPuzzleCell0" || textbox.Name == "easyPuzzleCell1" || textbox.Name == "easyPuzzleCell2")
                {
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            row1Counter += 1;
                        }
                    }
                    else
                    {
                        row1Counter--;
                    }
                    row1EasySum += value;
                    //if the row counter is 3 then we finished guessing a row, so let's see what color the total should be
                    if (row1Counter == 3)
                    {
                        rowSumBox.Refresh();

                    }
                    else
                    {
                        rowSumBox.Refresh();

                    }
                }
                //if the textbox name contains "easy" or any value between 0-2, we know we are in the first row
                if (textbox.Name.Contains("easy") && textbox.Name.Contains("3") || textbox.Name.Contains("4")
                                    || textbox.Name.Contains("5"))
                {
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            row2Counter += 1;
                        }
                    }
                    else
                    {
                        row2Counter--;
                    }
                    row2EasySum += value;
                    //if the row counter is 3 then we finished guessing a row, so let's see what color the total should be
                    if (row2Counter == 3)
                    {
                        rowSumBox.Refresh();

                    }
                    else
                    {
                        rowSumBox.Refresh();
                    }
                }

                //if the textbox name contains "easy" or any value between 0-2, we know we are in the first row
                if (textbox.Name.Contains("easy") && textbox.Name.Contains("6") || textbox.Name.Contains("7")
                                    || textbox.Name.Contains("8"))
                {
                    //if we did not delete a value then add to counter
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            row3Counter += 1;
                        }
                    }
                    //if we did delete a value then remove form counter
                    else
                    {
                        row3Counter--;
                    }
                    row3EasySum += value;
                    //if the row counter is 3 then we finished guessing a row, so let's see what color the total should be
                    if (row3Counter == 3)
                    {
                        rowSumBox.Refresh();
                    }
                    else
                    {
                        rowSumBox.Refresh();
                    }
             
                }
                //columns changing total values
                //if the textbox name contains "easy" or values 0, 3, 6 we are in first column
                if (textbox.Name.Contains("easy") && textbox.Name.Contains("0") || textbox.Name.Contains("3")
                                    || textbox.Name.Contains("6"))
                {
                    //if we did not delete a value then add to counter
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            col1Counter += 1;
                        }
                    }
                    //if we did delete a value then remove form counter
                    else
                    {
                        col1Counter--;
                    }
                    col1EasySum += value;
                    //if the row counter is 3 then we finished guessing a row, so let's see what color the total should be
                    if (col1Counter == 3)
                    {
                        columnSumBox.Refresh();
                    }
                    else
                    {
                        columnSumBox.Refresh();
                    }
                }
                //if the textbox name contains "easy" or values 0, 3, 6 we are in first column
                if (textbox.Name.Contains("easy") && textbox.Name.Contains("1") || textbox.Name.Contains("4")
                                    || textbox.Name.Contains("7"))
                {
                    //if we did not delete a value then add to counter
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            col2Counter += 1;
                        }
                    }
                    //if we did delete a value then remove form counter
                    else
                    {
                        col2Counter--;
                    }
                    col2EasySum += value;
                    //if the row counter is 3 then we finished guessing a row, so let's see what color the total should be
                    if (col2Counter == 3)
                    {
                        columnSumBox.Refresh();
                    }
                    else
                    {
                        columnSumBox.Refresh();
                    }

                }

                //if the textbox name contains "easy" or values 0, 3, 6 we are in first column
                if (textbox.Name.Contains("easy") && textbox.Name.Contains("2") || textbox.Name.Contains("5")
                                    || textbox.Name.Contains("8"))
                {
                    //if we did not delete a value then add to counter
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            col3Counter += 1;
                        }
                    }
                    //if we did delete a value then remove form counter
                    else
                    {
                        col3Counter--;
                    }
                    col3EasySum += value;
                    //if the row counter is 3 then we finished guessing a row, so let's see what color the total should be
                    if (col3Counter == 3)
                    {
                        columnSumBox.Refresh();
                    }
                    else
                    {
                        columnSumBox.Refresh();
                    }
                }

                //diagnals changing
                //if the textbox name contains "easy" or have 0, 4, 8 in their name, it is a diagnal
                if (textbox.Name == "easyPuzzleCell0" || textbox.Name == "easyPuzzleCell4"
                                    || textbox.Name == "easyPuzzleCell8")
                {
                    //if we did not delete a value then add to counter
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            diagnal2Counter += 1;
                        }
                    }
                    //if we did delete a value then remove form counter
                    else
                    {
                        diagnal2Counter--;
                    }
                    diagnal2EasySum += value;
                    //if the row counter is 3 then we finished guessing a row, so let's see what color the total should be
                    if (diagnal2Counter == 3)
                    {
                        diagnal2SumBox.Refresh();
                    }
                    else
                    {
                        diagnal2SumBox.Refresh();
                    }
                }

                //if the textbox name contains "easy" or have 2, 4, 6 in their name, it is a diagnal
                if (textbox.Name == "easyPuzzleCell2" || textbox.Name == "easyPuzzleCell4"
                                    || textbox.Name == "easyPuzzleCell6")
                {
                    //if we did not delete a value then add to counter
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            diagnal1Counter += 1;
                        }
                    }
                    //if we did delete a value then remove form counter
                    else
                    {
                        diagnal1Counter--;
                    }
                    diagnal1EasySum += value;
                    //if the row counter is 3 then we finished guessing a row, so let's see what color the total should be
                    if (diagnal1Counter == 3)
                    {
                        diagnal1SumBox.Refresh();
                    }
                    else
                    {
                        diagnal1SumBox.Refresh();
                    }

                    //diagnal2EasySum += value;
                    //diagnal2SumBox.Refresh();

                    //diagnal1EasySum += value;
                    //diagnal1SumBox.Refresh();
                }
            }
            //MEDIUM BOARD CALCULTIONS IF CHANGE IN TEXT BOXES
            if (isMediumBoard)
            {
                //5 ROWS OF MEDIUM TABLE
                if (textbox.Name == "medPuzzleCell0" || textbox.Name == "medPuzzleCell1" || textbox.Name == "medPuzzleCell2"
                                || textbox.Name == "medPuzzleCell3" || textbox.Name == "medPuzzleCell4")
                {
                    //if we did not delete a value then add to counter
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            row1Counter+= 1;
                        }
                    }
                    //if we did delete a value then remove form counter
                    else
                    {
                        row1Counter--;
                    }
                    row1MediumSum += value;
                    //if the row counter is 5 then we finished guessing a row, so let's see what color the total should be
                    if (row1Counter == 5)
                    {
                        rowSumBox.Refresh();
                    }
                    else
                    {
                        rowSumBox.Refresh();
                    }
                }
                if (textbox.Name == "medPuzzleCell5" || textbox.Name == "medPuzzleCell6" || textbox.Name == "medPuzzleCell7"
                                || textbox.Name == "medPuzzleCell8" || textbox.Name == "medPuzzleCell9")
                {
                    //if we did not delete a value then add to counter
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            row2Counter += 1;
                        }
                    }
                    //if we did delete a value then remove form counter
                    else
                    {
                        row2Counter--;
                    }
                    row2MediumSum += value;
                    //if the row counter is 5 then we finished guessing a row, so let's see what color the total should be
                    if (row2Counter == 5)
                    {
                        rowSumBox.Refresh();
                    }
                    else
                    {
                        rowSumBox.Refresh();
                    }
                    // row2MediumSum += value;
                    //rowSumBox.Refresh();
                }
                if (textbox.Name == "medPuzzleCell10" || textbox.Name == "medPuzzleCell11" || textbox.Name == "medPuzzleCell12"
                                || textbox.Name == "medPuzzleCell13" || textbox.Name == "medPuzzleCell14")
                {
                    //if we did not delete a value then add to counter
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            row3Counter += 1;
                        }
                    }
                    //if we did delete a value then remove form counter
                    else
                    {
                        row3Counter--;
                    }
                    row3MediumSum += value;
                    //if the row counter is 5 then we finished guessing a row, so let's see what color the total should be
                    if (row3Counter == 5)
                    {
                        rowSumBox.Refresh();
                    }
                    else
                    {
                        rowSumBox.Refresh();
                    }
                    //row3MediumSum += value;
                    //rowSumBox.Refresh();
                }
                if (textbox.Name == "medPuzzleCell15" || textbox.Name == "medPuzzleCell16" || textbox.Name == "medPuzzleCell17"
                                || textbox.Name == "medPuzzleCell18" || textbox.Name == "medPuzzleCell19")
                {
                    //if we did not delete a value then add to counter
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            row4Counter += 1;
                        }
                    }
                    //if we did delete a value then remove form counter
                    else
                    {
                        row4Counter--;
                    }
                    row4MediumSum += value;
                    //if the row counter is 5 then we finished guessing a row, so let's see what color the total should be
                    if (row4Counter == 5)
                    {
                        rowSumBox.Refresh();
                    }
                    else
                    {
                        rowSumBox.Refresh();
                    }
                    //row4MediumSum += value;
                    //rowSumBox.Refresh();
                }
                if (textbox.Name == "medPuzzleCell20" || textbox.Name == "medPuzzleCell21" || textbox.Name == "medPuzzleCell22"
                                || textbox.Name == "medPuzzleCell23" || textbox.Name == "medPuzzleCell24")
                {
                    //if we did not delete a value then add to counter
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            row5Counter += 1;
                        }
                    }
                    //if we did delete a value then remove form counter
                    else
                    {
                        row5Counter--;
                    }
                    row5MediumSum += value;
                    //if the row counter is 5 then we finished guessing a row, so let's see what color the total should be
                    if (row5Counter == 5)
                    {
                        rowSumBox.Refresh();
                    }
                    else
                    {
                        rowSumBox.Refresh();
                    }
                }
                //COLUMNS OF MEDIUM TABLE
                if (textbox.Name == "medPuzzleCell0" || textbox.Name == "medPuzzleCell5" || textbox.Name == "medPuzzleCell10"
                                || textbox.Name == "medPuzzleCell15" || textbox.Name == "medPuzzleCell20")
                {
                    //if we did not delete a value then add to counter
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            col1Counter += 1;
                        }
                    }
                    //if we did delete a value then remove form counter
                    else
                    {
                        col1Counter--;
                    }
                    col1MediumSum += value;
                    //if the row counter is 5 then we finished guessing a column, so let's see what color the total should be
                    if (col1Counter == 5)
                    {
                        columnSumBox.Refresh();
                    }
                    else
                    {
                        columnSumBox.Refresh();
                    }
                }
                if (textbox.Name == "medPuzzleCell1" || textbox.Name == "medPuzzleCell6" || textbox.Name == "medPuzzleCell11"
                                || textbox.Name == "medPuzzleCell16" || textbox.Name == "medPuzzleCell21")
                {
                    //if we did not delete a value then add to counter
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            col2Counter += 1;
                        }
                    }
                    //if we did delete a value then remove form counter
                    else
                    {
                        col2Counter--;
                    }
                    col2MediumSum += value;
                    //if the row counter is 5 then we finished guessing a column, so let's see what color the total should be
                    if (col2Counter == 5)
                    {
                        columnSumBox.Refresh();
                    }
                    else
                    {
                        columnSumBox.Refresh();
                    }
                }
                if (textbox.Name == "medPuzzleCell2" || textbox.Name == "medPuzzleCell7" || textbox.Name == "medPuzzleCell12"
                                || textbox.Name == "medPuzzleCell17" || textbox.Name == "medPuzzleCell22")
                {
                    //if we did not delete a value then add to counter
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            col3Counter += 1;
                        }
                    }
                    //if we did delete a value then remove form counter
                    else
                    {
                        col3Counter--;
                    }
                    col3MediumSum += value;
                    //if the row counter is 5 then we finished guessing a column, so let's see what color the total should be
                    if (col3Counter == 5)
                    {
                        columnSumBox.Refresh();
                    }
                    else
                    {
                        columnSumBox.Refresh();
                    }
                }
                if (textbox.Name == "medPuzzleCell3" || textbox.Name == "medPuzzleCell8" || textbox.Name == "medPuzzleCell13"
                                || textbox.Name == "medPuzzleCell18" || textbox.Name == "medPuzzleCell23")
                {
                    //if we did not delete a value then add to counter
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            col4Counter += 1;
                        }
                    }
                    //if we did delete a value then remove form counter
                    else
                    {
                        col4Counter--;
                    }
                    col4MediumSum += value;
                    //if the row counter is 5 then we finished guessing a column, so let's see what color the total should be
                    if (col4Counter == 5)
                    {
                        columnSumBox.Refresh();
                    }
                    else
                    {
                        columnSumBox.Refresh();
                    }
                }
                if (textbox.Name == "medPuzzleCell4" || textbox.Name == "medPuzzleCell9" || textbox.Name == "medPuzzleCell14"
                                || textbox.Name == "medPuzzleCell19" || textbox.Name == "medPuzzleCell24")
                {
                    //if we did not delete a value then add to counter
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            col5Counter += 1;
                        }
                    }
                    //if we did delete a value then remove form counter
                    else
                    {
                        col5Counter--;
                    }
                    col5MediumSum += value;
                    //if the row counter is 5 then we finished guessing a column, so let's see what color the total should be
                    if (col5Counter == 5)
                    {
                        columnSumBox.Refresh();
                    }
                    else
                    {
                        columnSumBox.Refresh();
                    }
                }
                //diagnals changing
                if (textbox.Name == "medPuzzleCell0" || textbox.Name == "medPuzzleCell6" || textbox.Name == "medPuzzleCell12"
                                || textbox.Name == "medPuzzleCell18" || textbox.Name == "medPuzzleCell24")
                {
                    //if we did not delete a value then add to counter
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            diagnal2Counter += 1;
                        }
                    }
                    //if we did delete a value then remove form counter
                    else
                    {
                        diagnal2Counter--;
                    }
                    diagnal2MediumSum += value;
                    //if the row counter is 5 then we finished guessing a diagnal so let's see what color the total should be
                    if (diagnal2Counter == 5)
                    {
                        diagnal2SumBox.Refresh();
                    }
                    else
                    {
                        diagnal2SumBox.Refresh();
                    }
                }
                if (textbox.Name == "medPuzzleCell4" || textbox.Name == "medPuzzleCell8" || textbox.Name == "medPuzzleCell12"
                                || textbox.Name == "medPuzzleCell16" || textbox.Name == "medPuzzleCell20")
                {
                    //if we did not delete a value then add to counter
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            diagnal1Counter += 1;
                        }
                    }
                    //if we did delete a value then remove form counter
                    else
                    {
                        diagnal1Counter--;
                    }
                    diagnal1MediumSum += value;
                    //if the row counter is 5 then we finished guessing a diagnal, so let's see what color the total should be
                    if (diagnal1Counter == 5)
                    {
                        diagnal1SumBox.Refresh();
                    }
                    else
                    {
                        diagnal1SumBox.Refresh();
                    }
                    //diagnal1MediumSum += value;
                    //diagnal1SumBox.Refresh();
                }

            }
            //HARD BOARD CALCULATIONS IF CHANGE IN TeXT BOXES
            if (isHardBoard)
            {
                //7 ROWS FOR HARD BOARD
                if (textbox.Name == "hardPuzzleCell0" || textbox.Name == "hardPuzzleCell1" || textbox.Name == "hardPuzzleCell2"
                                || textbox.Name == "hardPuzzleCell3" || textbox.Name == "hardPuzzleCell4" || textbox.Name == "hardPuzzleCell5"
                                || textbox.Name == "hardPuzzleCell6")
                {
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            row1Counter += 1;
                        }
                    }
                    else
                    {
                        row1Counter--;
                    }
                    row1HardSum += value;
                    //if the row counter is 7 then we finished guessing a row, so let's see what color the total should be
                    if (row1Counter == 7)
                    {
                        rowSumBox.Refresh();

                    }
                    else
                    {
                        rowSumBox.Refresh();

                    }
                }
                if (textbox.Name == "hardPuzzleCell7" || textbox.Name == "hardPuzzleCell8" || textbox.Name == "hardPuzzleCell9"
                                || textbox.Name == "hardPuzzleCell10" || textbox.Name == "hardPuzzleCell11" || textbox.Name == "hardPuzzleCell12"
                                || textbox.Name == "hardPuzzleCell13")
                {
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            row2Counter += 1;
                        }
                    }
                    else
                    {
                        row2Counter--;
                    }
                    row2HardSum += value;
                    //if the row counter is 7 then we finished guessing a row, so let's see what color the total should be
                    if (row2Counter == 7)
                    {
                        rowSumBox.Refresh();

                    }
                    else
                    {
                        rowSumBox.Refresh();

                    }
                }
                if (textbox.Name == "hardPuzzleCell14" || textbox.Name == "hardPuzzleCell15" || textbox.Name == "hardPuzzleCell16"
                               || textbox.Name == "hardPuzzleCell17" || textbox.Name == "hardPuzzleCell18" || textbox.Name == "hardPuzzleCell19"
                               || textbox.Name == "hardPuzzleCell20")
                {
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            row3Counter += 1;
                        }
                    }
                    else
                    {
                        row3Counter--;
                    }
                    row3HardSum += value;
                    //if the row counter is 7 then we finished guessing a row, so let's see what color the total should be
                    if (row3Counter == 7)
                    {
                        rowSumBox.Refresh();

                    }
                    else
                    {
                        rowSumBox.Refresh();
                    }
                }
                if (textbox.Name == "hardPuzzleCell21" || textbox.Name == "hardPuzzleCell22" || textbox.Name == "hardPuzzleCell23"
                               || textbox.Name == "hardPuzzleCell24" || textbox.Name == "hardPuzzleCell25" || textbox.Name == "hardPuzzleCell26"
                               || textbox.Name == "hardPuzzleCell27")
                {
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            row4Counter += 1;
                        }
                    }
                    else
                    {
                        row4Counter--;
                    }
                    row4HardSum += value;
                    //if the row counter is 7 then we finished guessing a row, so let's see what color the total should be
                    if (row4Counter == 7)
                    {
                        rowSumBox.Refresh();

                    }
                    else
                    {
                        rowSumBox.Refresh();
                    }

                }
                if (textbox.Name == "hardPuzzleCell28" || textbox.Name == "hardPuzzleCell29" || textbox.Name == "hardPuzzleCell30"
                             || textbox.Name == "hardPuzzleCell31" || textbox.Name == "hardPuzzleCell32" || textbox.Name == "hardPuzzleCell33"
                             || textbox.Name == "hardPuzzleCell34")
                {
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            row5Counter += 1;
                        }
                    }
                    else
                    {
                        row5Counter--;
                    }
                    row5HardSum += value;
                    //if the row counter is 7 then we finished guessing a row, so let's see what color the total should be
                    if (row5Counter == 7)
                    {
                        rowSumBox.Refresh();
                    }
                    else
                    {
                        rowSumBox.Refresh();
                    }
                }
                if (textbox.Name == "hardPuzzleCell35" || textbox.Name == "hardPuzzleCell36" || textbox.Name == "hardPuzzleCell37"
                             || textbox.Name == "hardPuzzleCell38" || textbox.Name == "hardPuzzleCell39" || textbox.Name == "hardPuzzleCell40"
                             || textbox.Name == "hardPuzzleCell41")
                {
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            row6Counter += 1;
                        }
                    }
                    else
                    {
                        row6Counter--;
                    }
                    row6HardSum += value;
                    //if the row counter is 7 then we finished guessing a row, so let's see what color the total should be
                    if (row6Counter == 7)
                    {
                        rowSumBox.Refresh();

                    }
                    else
                    {
                        rowSumBox.Refresh();
                    }
                }
                if (textbox.Name == "hardPuzzleCell42" || textbox.Name == "hardPuzzleCell43" || textbox.Name == "hardPuzzleCell44"
                            || textbox.Name == "hardPuzzleCell45" || textbox.Name == "hardPuzzleCell46" || textbox.Name == "hardPuzzleCell47"
                            || textbox.Name == "hardPuzzleCell48")
                {
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            row7Counter += 1;
                        }
                    }
                    else
                    {
                        row7Counter--;
                    }
                    row7HardSum += value;
                    //if the row counter is 7 then we finished guessing a row, so let's see what color the total should be
                    if (row7Counter == 7)
                    {
                        rowSumBox.Refresh();
                    }
                    else
                    {
                        rowSumBox.Refresh();
                    }
                }

                //7 COLUMNS FOR HARD BOARD
                if (textbox.Name == "hardPuzzleCell0" || textbox.Name == "hardPuzzleCell7" || textbox.Name == "hardPuzzleCell14"
                                || textbox.Name == "hardPuzzleCell21" || textbox.Name == "hardPuzzleCell28" || textbox.Name == "hardPuzzleCell35"
                                || textbox.Name == "hardPuzzleCell42")
                {
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            col1Counter += 1;
                        }
                    }
                    else
                    {
                        col1Counter--;
                    }
                    col1HardSum += value;
                    if (col1Counter == 7)
                    {
                        columnSumBox.Refresh();

                    }
                    else
                    {
                        columnSumBox.Refresh();
                    }
                }
                if (textbox.Name == "hardPuzzleCell1" || textbox.Name == "hardPuzzleCell8" || textbox.Name == "hardPuzzleCell15"
                               || textbox.Name == "hardPuzzleCell22" || textbox.Name == "hardPuzzleCell29" || textbox.Name == "hardPuzzleCell36"
                               || textbox.Name == "hardPuzzleCell43")
                {
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            col2Counter += 1;
                        }
                    }
                    else
                    {
                        col2Counter--;
                    }
                    col2HardSum += value;
                    if (col2Counter == 7)
                    {
                        columnSumBox.Refresh();

                    }
                    else
                    {
                        columnSumBox.Refresh();
                    }
                }
                if (textbox.Name == "hardPuzzleCell2" || textbox.Name == "hardPuzzleCell9" || textbox.Name == "hardPuzzleCell16"
                              || textbox.Name == "hardPuzzleCell23" || textbox.Name == "hardPuzzleCell30" || textbox.Name == "hardPuzzleCell37"
                              || textbox.Name == "hardPuzzleCell44")
                {
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            col3Counter += 1;
                        }
                    }
                    else
                    {
                        col3Counter--;
                    }
                    col3HardSum += value;
                    if (col3Counter == 7)
                    {
                        columnSumBox.Refresh();
                    }
                    else
                    {
                        columnSumBox.Refresh();
                    }
                }
                if (textbox.Name == "hardPuzzleCell3" || textbox.Name == "hardPuzzleCell10" || textbox.Name == "hardPuzzleCell17"
                              || textbox.Name == "hardPuzzleCell24" || textbox.Name == "hardPuzzleCell31" || textbox.Name == "hardPuzzleCell38"
                              || textbox.Name == "hardPuzzleCell45")
                {
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            col4Counter += 1;
                        }
                    }
                    else
                    {
                        col4Counter--;
                    }
                    col4HardSum += value;
                    if (col4Counter == 7)
                    {
                        columnSumBox.Refresh();
                    }
                    else
                    {
                        columnSumBox.Refresh();
                    }
                }
                if (textbox.Name == "hardPuzzleCell4" || textbox.Name == "hardPuzzleCell11" || textbox.Name == "hardPuzzleCell18"
                              || textbox.Name == "hardPuzzleCell25" || textbox.Name == "hardPuzzleCell32" || textbox.Name == "hardPuzzleCell39"
                              || textbox.Name == "hardPuzzleCell46")
                {
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            col5Counter += 1;
                        }
                    }
                    else
                    {
                        col5Counter--;
                    }
                    col5HardSum += value;
                    if (col5Counter == 7)
                    {
                        columnSumBox.Refresh();
                    }
                    else
                    {
                        columnSumBox.Refresh();
                    }
                }
                if (textbox.Name == "hardPuzzleCell5" || textbox.Name == "hardPuzzleCell12" || textbox.Name == "hardPuzzleCell19"
                              || textbox.Name == "hardPuzzleCell26" || textbox.Name == "hardPuzzleCell33" || textbox.Name == "hardPuzzleCell40"
                              || textbox.Name == "hardPuzzleCell47")
                {
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            col6Counter += 1;
                        }
                    }
                    else
                    {
                        col6Counter--;
                    }
                    col6HardSum += value;
                    if (col6Counter == 7)
                    {
                        columnSumBox.Refresh();
                    }
                    else
                    {
                        columnSumBox.Refresh();
                    }
                }
                if (textbox.Name == "hardPuzzleCell6" || textbox.Name == "hardPuzzleCell13" || textbox.Name == "hardPuzzleCell20"
                              || textbox.Name == "hardPuzzleCell27" || textbox.Name == "hardPuzzleCell34" || textbox.Name == "hardPuzzleCell41"
                              || textbox.Name == "hardPuzzleCell48")
                {
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            col7Counter += 1;
                        }
                    }
                    else
                    {
                        col7Counter--;
                    }
                    col7HardSum += value;
                    //if the row counter is 7 then we finished guessing a column, so let's see what color the total should be
                    if (col7Counter == 7)
                    {
                        columnSumBox.Refresh();
                    }
                    else
                    {
                        columnSumBox.Refresh();
                    }
                }
                //diagnals changing
                if (textbox.Name == "hardPuzzleCell0" || textbox.Name == "hardPuzzleCell8" || textbox.Name == "hardPuzzleCell16"
                              || textbox.Name == "hardPuzzleCell24" || textbox.Name == "hardPuzzleCell32" || textbox.Name == "hardPuzzleCell40"
                              || textbox.Name == "hardPuzzleCell48")
                {
                    //if we did not delete a value then add to counter
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            diagnal2Counter += 1;
                        }
                    }
                    //if we did delete a value then remove form counter
                    else
                    {
                        diagnal2Counter--;
                    }
                    diagnal2HardSum += value;
                    //if the row counter is 7 then we finished guessing a diagnal, so let's see what color the total should be
                    if (diagnal2Counter == 7)
                    {
                        diagnal2SumBox.Refresh();
                    }
                    else
                    {
                        diagnal2SumBox.Refresh();
                    }
                }
                if (textbox.Name == "hardPuzzleCell6" || textbox.Name == "hardPuzzleCell12" || textbox.Name == "hardPuzzleCell18"
                              || textbox.Name == "hardPuzzleCell24" || textbox.Name == "hardPuzzleCell30" || textbox.Name == "hardPuzzleCell36"
                              || textbox.Name == "hardPuzzleCell42")
                {
                    //if we did not delete a value then add to counter
                    if (!isDeletedValue)
                    {
                        if (!String.IsNullOrEmpty(textbox.Text))
                        {
                            diagnal1Counter += 1;
                        }
                    }
                    //if we did delete a value then remove form counter
                    else
                    {
                        diagnal1Counter--;
                    }
                    diagnal1HardSum += value;
                    //if the row counter is 7 then we finished guessing a diagnal, so let's see what color the total should be
                    if (diagnal1Counter == 7)
                    {
                        diagnal1SumBox.Refresh();
                    }
                    else
                    {
                        diagnal1SumBox.Refresh();
                    }
                }
            }
            completed_puzzle();
        }

        private void newGameButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (newgame_itr > 0 && !Complete)
            {
                Saved = true;
                save_puzzle();
                Hide_Board = false;
                isEasyGame = false;
                isMediumGame = false;
                isHardGame = false;
                if (gameDifficultyDropDown.Text == "Easy")
                {
                    isEasyGame = true;
                    isEasyBoard = true;
                    resetMediumPuzzleTextboxes();
                    resetHardPuzzleTextboxes();
                }
                else if (gameDifficultyDropDown.Text == "Medium")
                {
                    isMediumGame = true;
                    isMediumBoard = true;
                    resetEasyPuzzleTextboxes();
                    resetHardPuzzleTextboxes();
                }
                else if (gameDifficultyDropDown.Text == "Hard")
                {
                    isHardGame = true;
                    isHardBoard = true;
                    resetEasyPuzzleTextboxes();
                    resetMediumPuzzleTextboxes();
                }
            }
            newgame_itr++;
            isNewGame = true;
            isEasyBoard = false;
            isMediumBoard = false;
            isHardBoard = false;
            Complete = false;

            if (PauseResume_Button.Text == "Resume")
            {
                canvas.Refresh();

                PauseResume_Button.Text = "Pause";
                Hide_Board = false;
                isEasyGame = false;
                isMediumGame = false;
                isHardGame = false;
                isEasyBoard = false;
                isMediumBoard = false;
                isHardBoard = false;

                if (gameDifficultyDropDown.Text == "Easy")
                {
                    isEasyGame = true;
                    isEasyBoard = true;
                    resetMediumPuzzleTextboxes();
                    resetHardPuzzleTextboxes();
                }
                else if (gameDifficultyDropDown.Text == "Medium")
                {
                    isMediumGame = true;
                    isMediumBoard = true;
                    resetEasyPuzzleTextboxes();
                    resetHardPuzzleTextboxes();
                }
                else if (gameDifficultyDropDown.Text == "Hard")
                {
                    isHardGame = true;
                    isHardBoard = true;
                    resetEasyPuzzleTextboxes();
                    resetMediumPuzzleTextboxes();
                }

            }
            isDown = true;
            tmrCounter.Enabled = true;
            i = 0;

            canvas.Refresh();
            refresh_totals_and_canvas();
            
        }
        private void refresh_totals_and_canvas()
        {
            //reset the counters
            row1Counter = 0;
            row2Counter = 0;
            row3Counter = 0;
            row4Counter = 0;
            row5Counter = 0;
            row6Counter = 0;
            row7Counter = 0;
            col1Counter = 0;
            col2Counter = 0;
            col3Counter = 0;
            col4Counter = 0;
            col5Counter = 0;
            col6Counter = 0;
            col7Counter = 0;
            diagnal1Counter = 0;
            diagnal2Counter = 0;

            row1AnswerEasy = 0;
            row1EasySum = 0;
            row1EasySum = 0;
            row2EasySum = 0;
            row3EasySum = 0;
            diagnal1EasySum = 0;
            diagnal2EasySum = 0;
            col1EasySum = 0;
            col2EasySum = 0;
            col3EasySum = 0;
            //actual answer for easy board
            row1AnswerEasy = 0;
            row2AnswerEasy = 0;
            row3AnswerEasy = 0;
            col1AnswerEasy = 0;
            col2AnswerEasy = 0;
            col3AnswerEasy = 0;
            diagnal1AnswerEasy = 0;
            diagnal2AnswerEasy = 0;

            //all totals variables for a medium board
            row1MediumSum = 0;
            row2MediumSum = 0;
            row3MediumSum = 0;
            row4MediumSum = 0;
            row5MediumSum = 0;
            col1MediumSum = 0;
            col2MediumSum = 0;
            col3MediumSum = 0;
            col4MediumSum = 0;
            col5MediumSum = 0;
            diagnal1MediumSum = 0;
            diagnal2MediumSum = 0;

            //actual totals variables for a medium board
            row1AnswerMed = 0;
            row2AnswerMed = 0;
            row3AnswerMed = 0;
            row4AnswerMed = 0;
            row5AnswerMed = 0;
            col1AnswerMed = 0;
            col2AnswerMed = 0;
            col3AnswerMed = 0;
            col4AnswerMed = 0;
            col5AnswerMed = 0;
            diagnal1AnswerMed = 0;
            diagnal2AnswerMed = 0;


            //all totals variables for a hard board
            row1HardSum = 0;
            row2HardSum = 0;
            row3HardSum = 0;
            row4HardSum = 0;
            row5HardSum = 0;
            row6HardSum = 0;
            row7HardSum = 0;
            col1HardSum = 0;
            col2HardSum = 0;
            col3HardSum = 0;
            col4HardSum = 0;
            col5HardSum = 0;
            col6HardSum = 0;
            col7HardSum = 0;
            diagnal1HardSum = 0;
            diagnal2HardSum = 0;

            //actual totals variables for hard board
            row1AnswerHard = 0;
            row2AnswerHard = 0;
            row3AnswerHard = 0;
            row4AnswerHard = 0;
            row5AnswerHard = 0;
            row6AnswerHard = 0;
            row7AnswerHard = 0;
            col1AnswerHard = 0;
            col2AnswerHard = 0;
            col3AnswerHard = 0;
            col4AnswerHard = 0;
            col5AnswerHard = 0;
            col6AnswerHard = 0;
            col7AnswerHard = 0;
            diagnal1AnswerHard = 0;
            diagnal2AnswerHard = 0;


            if (isBoardLoaded)
            {
                if (isEasyBoard)
                {
                    //calc and load the derived and actual totals for the easy game board rows
                    calculateInitialEasyRowSums(gameValuesEasy1);
                    calculateAnswerEasyRow(gameAnswersEasy1);
                    rowSumBox.Refresh();

                    //calc and load the dervied and actual totals for the easy game board columns
                    calculateInitialEasyColSums(gameValuesEasy1);
                    calculateAnswerEasyColSums(gameAnswersEasy1);
                    columnSumBox.Refresh();

                    //calc and load the diagnal totals for easy board
                    calculateInitialEasyDiagnalSums(gameValuesEasy1);
                    calculateAnswerEasyDiagnalSums(gameAnswersEasy1);
                    diagnal1SumBox.Refresh();
                    diagnal2SumBox.Refresh();


                }
                if (isMediumBoard)
                {
                    //calc and load the row totals for medium board
                    calculateInitialMediumRowSums(gameValuesMedium1);
                    calculateAnswerMedRow(gameAnswersMed1);
                    rowSumBox.Refresh();

                    //calc and load the column totals for medium board
                    calculateInitialMediumColSums(gameValuesMedium1);
                    calculateAnswerMedColSums(gameAnswersMed1);
                    columnSumBox.Refresh();

                    //calc and load the diagnal totals for medium board
                    calculateInitialMediumDiagnalSums(gameValuesMedium1);
                    calculateAnswerMedDiagnalSums(gameAnswersMed1);
                    diagnal1SumBox.Refresh();
                    diagnal2SumBox.Refresh();
                }
                if (isHardBoard)
                {
                    //calculate and load the intial and actual values for rows for hard board
                    calculateInitialHardRowSums(gameValuesHard1);
                    calculateAnswerHardRowSums(gameAnswersHard1);
                    rowSumBox.Refresh();

                    //calc and load the initial and actual values for the columns for the hard board
                    calculateInitialHardColSums(gameValuesHard1);
                    calculateAnswerHardColSums(gameAnswersHard1);
                    columnSumBox.Refresh();

                    //calc and load the diagnal totals (derived and actual)for hard board
                    calculateInitialHardDiagnalSums(gameValuesHard1);
                    calculateAnswerHardDiagnalSums(gameAnswersHard1);
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
            isNewGame = false;
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

        //this function will decide what color we paint the derived totals in when the user is done guessing for a row, column, and diagnal
        // GREEN if the derived sum is equal to actual sum, RED if it is different, and GREY if they are still in the process of guessing
        private void changePaintColors(object sender, PaintEventArgs e, string valueToPrint, Font font1, int heightDivide, 
            int widthDivide, int widthMultiply, int heightMultiply, bool isAnswer, int counter, int derivedSum, int actualSum, PictureBox box, int cellNumber)
        {
            //widthDivide, heightDivide, widthMultiple, heightMultiply -> adjusts what column and row we are in depending on board difficulty
            //counter -> the row, column, or diagnal counter,
            //derivedSum -> the derived sum of column, row, or diagnal
            //actualSum -> the actual sum for the row, column, diagnal
            //valueToPrint -> the value of the sum (if not answer then it is the derived sum, if it is answer then it is the actual answer
            //box -> the box we want to paint in, row, column, or diagnal 
            if (!isAnswer)
            {
                if (counter == cellNumber)
                {
                    //if its correct, paint in green, if wrong paint it red otherwise paint it in the color since we are still in progress
                    if (derivedSum == actualSum)
                    {
                        PointF pointF4 = new PointF(widthMultiply * box.Width / widthDivide, heightMultiply * box.Height / heightDivide);
                        e.Graphics.DrawString(valueToPrint, font1, Brushes.Green, pointF4);
                    }
                    else if (derivedSum > actualSum || derivedSum < actualSum)
                    {
                        PointF pointF5 = new PointF(widthMultiply * box.Width / widthDivide, heightMultiply * box.Height / heightDivide);
                        e.Graphics.DrawString(valueToPrint, font1, Brushes.Red, pointF5);
                    }
                }
                else
                {
                    PointF pointF4 = new PointF(widthMultiply * box.Width / widthDivide, heightMultiply* box.Height / heightDivide);
                    e.Graphics.DrawString(valueToPrint, font1, Brushes.DarkGray, pointF4);
                }

            }
            else
            {
                PointF pointF4 = new PointF(widthMultiply * box.Width / widthDivide, heightMultiply * box.Height / heightDivide);
                e.Graphics.DrawString(valueToPrint, font1, Brushes.Black, pointF4);
            }
        }

        //paints the easy totals for rows and columns, calls the changePaintColors to see what color to paint them
        private void paintEasyTotals(object sender, PaintEventArgs e, string a, string b, string c, Font font1, int heightDivide, int widthDivide,
                 bool isRow,  bool isAnswer, Brush color)
        {
            //we have a column
            if (!isRow)
            {
                changePaintColors(sender, e, a, font1, heightDivide, widthDivide, 1, 1, isAnswer, col1Counter, col1EasySum, col1AnswerEasy, columnSumBox, 3);
                changePaintColors(sender, e, b, font1, heightDivide, widthDivide, 3, 1, isAnswer, col2Counter, col2EasySum, col2AnswerEasy, columnSumBox, 3);
                changePaintColors(sender, e, c, font1, heightDivide, widthDivide, 5, 1, isAnswer, col3Counter, col3EasySum, col3AnswerEasy, columnSumBox, 3);
            }
            if (isRow)
            {
                changePaintColors(sender, e, a, font1, heightDivide, widthDivide, 1, 1, isAnswer, row1Counter, row1EasySum, row1AnswerEasy, rowSumBox, 3);
                changePaintColors(sender, e, b, font1, heightDivide, widthDivide, 1, 3, isAnswer, row2Counter, row2EasySum, row2AnswerEasy, rowSumBox, 3);
                changePaintColors(sender, e, c, font1, heightDivide, widthDivide, 1, 5, isAnswer, row3Counter, row3EasySum, row3AnswerEasy, rowSumBox, 3);
            }
        }
        //paints the medium totals for rows and columns, calls the changePaintColors to see what color to paint them
        private void paintMediumTotals(object sender, PaintEventArgs e, string a, string b, string c, string d, string f,
                Font font1, int heightDivide, int widthDivide, bool isRow, bool isAnswer, Brush color)
        {
            if(!isRow)
            {
                changePaintColors(sender, e, a, font1, heightDivide, widthDivide, 1, 1, isAnswer, col1Counter, col1MediumSum, col1AnswerMed, columnSumBox, 5);
                changePaintColors(sender, e, b, font1, heightDivide, widthDivide, 3, 1, isAnswer, col2Counter, col2MediumSum, col2AnswerMed, columnSumBox, 5);
                changePaintColors(sender, e, c, font1, heightDivide, widthDivide, 5, 1, isAnswer, col3Counter, col3MediumSum, col3AnswerMed, columnSumBox, 5);
                changePaintColors(sender, e, d, font1, heightDivide, widthDivide, 7, 1, isAnswer, col4Counter, col4MediumSum, col4AnswerMed, columnSumBox, 5);
                changePaintColors(sender, e, f, font1, heightDivide, widthDivide, 9, 1, isAnswer, col5Counter, col5MediumSum, col5AnswerMed, columnSumBox, 5);
    
            }
            if (isRow)
            {
                changePaintColors(sender, e, a, font1, heightDivide, widthDivide, 1, 1, isAnswer, row1Counter, row1MediumSum, row1AnswerMed, rowSumBox, 5);
                changePaintColors(sender, e, b, font1, heightDivide, widthDivide, 1, 3, isAnswer, row2Counter, row2MediumSum, row2AnswerMed, rowSumBox, 5);
                changePaintColors(sender, e, c, font1, heightDivide, widthDivide, 1, 5, isAnswer, row3Counter, row3MediumSum, row3AnswerMed, rowSumBox, 5);
                changePaintColors(sender, e, d, font1, heightDivide, widthDivide, 1, 7, isAnswer, row4Counter, row4MediumSum, row4AnswerMed, rowSumBox, 5);
                changePaintColors(sender, e, f, font1, heightDivide, widthDivide, 1, 9, isAnswer, row5Counter, row5MediumSum, row5AnswerMed, rowSumBox, 5);
            }
        }
        //paints the hard totals for rows and columns, calls the changePaintColors to see what color to paint them
        private void paintHardTotals(object sender, PaintEventArgs e, string a, string b, string c, string d, string f, string g , string h,
               Font font1, int heightDivide, int widthDivide, bool isRow, bool isAnswer, Brush color)
        {
            if(isRow)
            {
                changePaintColors(sender, e, a, font1, heightDivide, widthDivide, 1, 1, isAnswer, row1Counter, row1HardSum, row1AnswerHard, rowSumBox, 7);
                changePaintColors(sender, e, b, font1, heightDivide, widthDivide, 1, 3, isAnswer, row2Counter, row2HardSum, row2AnswerHard, rowSumBox, 7);
                changePaintColors(sender, e, c, font1, heightDivide, widthDivide, 1, 5, isAnswer, row3Counter, row3HardSum, row3AnswerHard, rowSumBox, 7);
                changePaintColors(sender, e, d, font1, heightDivide, widthDivide, 1, 7, isAnswer, row4Counter, row4HardSum, row4AnswerHard, rowSumBox, 7);
                changePaintColors(sender, e, f, font1, heightDivide, widthDivide, 1, 9, isAnswer, row5Counter, row5HardSum, row5AnswerHard, rowSumBox, 7);
                changePaintColors(sender, e, g, font1, heightDivide, widthDivide, 1, 11, isAnswer, row6Counter, row6HardSum, row6AnswerHard, rowSumBox, 7);
                changePaintColors(sender, e, h, font1, heightDivide, widthDivide, 1, 13, isAnswer, row7Counter, row7HardSum, row7AnswerHard, rowSumBox, 7);
            }
            if (!isRow)
            {
                changePaintColors(sender, e, a, font1, heightDivide, widthDivide, 1, 1, isAnswer, col1Counter, col1HardSum, col1AnswerHard, columnSumBox, 7);
                changePaintColors(sender, e, b, font1, heightDivide, widthDivide, 3, 1, isAnswer, col2Counter, col2HardSum, col2AnswerHard, columnSumBox, 7);
                changePaintColors(sender, e, c, font1, heightDivide, widthDivide, 5, 1, isAnswer, col3Counter, col3HardSum, col3AnswerHard, columnSumBox, 7);
                changePaintColors(sender, e, d, font1, heightDivide, widthDivide, 7, 1, isAnswer, col4Counter, col4HardSum, col4AnswerHard, columnSumBox, 7);
                changePaintColors(sender, e, f, font1, heightDivide, widthDivide, 9, 1, isAnswer, col5Counter, col5HardSum, col5AnswerHard, columnSumBox, 7);
                changePaintColors(sender, e, g, font1, heightDivide, widthDivide, 11, 1, isAnswer, col6Counter, col6HardSum, col6AnswerHard, columnSumBox, 7);
                changePaintColors(sender, e, h, font1, heightDivide, widthDivide, 13, 1, isAnswer, col7Counter, col7HardSum, col7AnswerHard, columnSumBox, 7);
            }
        }
        //draw the derived and actual totals for rows for all boards
        private void rowSumBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            if (isBoardLoaded)
            {
                if (isEasyBoard)
                {
                    using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        if (Complete == true)
                        {
                            paintEasyTotals(sender, e, "", "", "", font1, 6, 12, true, false, Brushes.DarkGray);

                            //actual totals
                            paintEasyTotals(sender, e, "", "", "", font1, 6, 2, true, true, Brushes.Black);
                        }
                        else if (Hide_Board == true)
                        {
                            //if we hide the board then make the derived totals "?"
                            paintEasyTotals(sender, e, "?", "?", "?", font1, 6, 12,true, false, Brushes.DarkGray);

                            //actual totals appear as "?" if we hide the board
                            paintEasyTotals(sender, e, "?", "?", "?", font1, 6, 2,true, true, Brushes.Black);
                        }
                        else
                        {
                            //derived totals
                            paintEasyTotals(sender, e, row1EasySum.ToString(), row2EasySum.ToString(), row3EasySum.ToString(), 
                                    font1, 6, 12, true, false, Brushes.DarkGray);

                            //actual totals
                            paintEasyTotals(sender, e, row1AnswerEasy.ToString(), row2AnswerEasy.ToString(), row3AnswerEasy.ToString(), 
                                        font1, 6, 2, true, true, Brushes.Black);
                        }
                        if (row1EasySum == row1AnswerEasy && row2EasySum == row2AnswerEasy && row3EasySum == row3AnswerEasy)
                        {
                            EasyRowCompleted = true;
                        }
                    }
                }
                if(isMediumBoard)
                {
                    using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        if (Hide_Board == true)
                        {
                            //derived totals painted as "?" if we pause
                            paintMediumTotals(sender, e, "?", "?", "?", "?", "?", font1, 10, 20, true, false, Brushes.DarkGray);

                            //actual totals painted as "?" if we pause
                            paintMediumTotals(sender, e, "?", "?", "?", "?", "?", font1, 10, 2, true, true, Brushes.Black);
                        }
                        else if (Complete == true)
                        {
                            //derived totals
                            paintMediumTotals(sender, e, "", "", "", "", "", font1, 10, 20, true, false, Brushes.DarkGray);

                            //actual totals
                            paintMediumTotals(sender, e, "", "", "", "", "", font1, 10, 2, true,true, Brushes.Black);
                        }
                        else
                        {
                            //derived totals
                            paintMediumTotals(sender, e, row1MediumSum.ToString(), row2MediumSum.ToString(), row3MediumSum.ToString(),
                               row4MediumSum.ToString(), row5MediumSum.ToString(), font1, 10, 20, true, false,Brushes.DarkGray);

                            //actual totals
                            paintMediumTotals(sender, e, row1AnswerMed.ToString(), row2AnswerMed.ToString(), row3AnswerMed.ToString(),
                               row4AnswerMed.ToString(), row5AnswerMed.ToString(), font1, 10, 2, true, true,  Brushes.Black);
                        }

                        if (row1MediumSum == row1AnswerMed && row2MediumSum == row2AnswerMed &&
                            row3MediumSum == row3AnswerMed && row4MediumSum == row4AnswerMed && row5MediumSum == row5AnswerMed)
                        {
                            MediumRowCompleted = true;
                        }

                    }
                }
                if(isHardBoard)
                {
                    using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        if (Hide_Board == true)
                        {
                            //derived totals painted as "?" if paused
                            paintHardTotals(sender, e, "?", "?", "?", "?", "?", "?", "?", font1, 14, 28, true,false, Brushes.DarkGray);

                            //actual totals printed as "?" if paused
                            paintHardTotals(sender, e, "?", "?", "?", "?", "?", "?", "?", font1, 14, 2, true, true, Brushes.Black);
                        }
                        else if (Complete == true)
                        {
                            paintHardTotals(sender, e, "", "", "", "", "", "", "", font1, 14, 28, true, false,Brushes.DarkGray);
                            paintHardTotals(sender, e, "", "", "", "", "", "", "", font1, 14, 2, true, true, Brushes.Black);
                        }
                        else
                        {
                            //derived totals
                            paintHardTotals(sender, e, row1HardSum.ToString(), row2HardSum.ToString(), row3HardSum.ToString(),
                                row4HardSum.ToString(), row5HardSum.ToString(), row6HardSum.ToString(),
                                row7HardSum.ToString(), font1, 14, 28, true, false, Brushes.DarkGray);

                            //actual totals
                            paintHardTotals(sender, e, row1AnswerHard.ToString(), row2AnswerHard.ToString(), row3AnswerHard.ToString(),
                               row4AnswerHard.ToString(), row5AnswerHard.ToString(), row6AnswerHard.ToString(),
                               row7AnswerHard.ToString(), font1, 14, 2, true, true,Brushes.Black);
                        }
                        

                        if (row1HardSum == row1AnswerHard && row2HardSum == row2AnswerHard &&
                            row3HardSum == row3AnswerHard && row4HardSum == row4AnswerHard && row5HardSum == row5AnswerHard &&
                            row6HardSum == row6AnswerHard && row7HardSum == row7AnswerHard)
                        {
                            HardRowCompleted = true;
                        }

                    }
                }
            }
        }

        //draw the derived and actual totals for columns for all boards
        private void columnSumBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            if (isBoardLoaded)
            {
                if (isEasyBoard)
                {
                    using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        if (Hide_Board == true)
                        {
                            //derived totals as "?" when we pause the game
                            paintEasyTotals(sender, e, "?", "?", "?", font1, 12, 6, false, false, Brushes.DarkGray);
   
                            //actual totals as "?" when we pause the game
                            paintEasyTotals(sender, e, "?", "?", "?", font1, 2, 6, false, true, Brushes.Black);
                        }
                        else if (Complete == true)
                        {
                            paintEasyTotals(sender, e, "", "", "", font1, 12, 6, false, false, Brushes.DarkGray);

                            //actual totals
                            paintEasyTotals(sender, e, "", "", "", font1, 2, 6, false, true, Brushes.Black);
                        }
                        else
                        {
                            //paint derived totals
                            paintEasyTotals(sender, e, col1EasySum.ToString(), col2EasySum.ToString(), col3EasySum.ToString(), font1, 12, 6, false, false,  Brushes.DarkGray);

                            //actual totals
                            paintEasyTotals(sender, e, col1AnswerEasy.ToString(), col2AnswerEasy.ToString(), col3AnswerEasy.ToString(), font1, 2, 6,false, true, Brushes.Black);
  
                        }

                        if (col1EasySum == col1AnswerEasy && col2EasySum == col2AnswerEasy && col3EasySum == col3AnswerEasy)
                        {
                            EasyColCompleted = true;
                        }

                    }
                }
                if(isMediumBoard)
                {
                    using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        if (Hide_Board == true)
                        {
                            //paint derived totals as "?" if we pause
                            paintMediumTotals(sender, e, "?", "?", "?", "?", "?", font1, 20, 10, false, false, Brushes.DarkGray);

                            //paint actual totals as "?" if we pause
                            paintMediumTotals(sender, e, "?", "?", "?", "?", "?", font1, 2, 10, false, true, Brushes.Black);
                        }
                        else if (Complete == true)
                        {
                            //derived totals
                            paintMediumTotals(sender, e, "", "", "", "", "", font1, 20, 10, false,false,  Brushes.DarkGray);

                            //actual totals
                            paintMediumTotals(sender, e, "", "", "", "", "", font1, 2, 10, false, true, Brushes.Black);
                        }
                        else
                        {
                            //derived totals
                            paintMediumTotals(sender, e, col1MediumSum.ToString(), col2MediumSum.ToString(),
                                col3MediumSum.ToString(), col4MediumSum.ToString(), col5MediumSum.ToString(), font1, 20, 10, false, false, Brushes.DarkGray);

                            //actual totals
                            paintMediumTotals(sender, e, col1AnswerMed.ToString(), col2AnswerMed.ToString(),
                                col3AnswerMed.ToString(), col4AnswerMed.ToString(), col5AnswerMed.ToString(), font1, 2, 10, false, true, Brushes.Black);
                        }

                        if (col1MediumSum == col1AnswerMed && col2MediumSum == col2AnswerMed && col3MediumSum == col3AnswerMed
                            && col4MediumSum == col4AnswerMed && col5MediumSum == col5AnswerMed)
                        {
                            MediumColCompleted = true;
                        }
                    }
                }

                if(isHardBoard)
                {
                    using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        if (Hide_Board == true)
                        {
                            paintHardTotals(sender, e, "?", "?", "?", "?", "?", "?", "?", font1, 14, 14, false, false,Brushes.DarkGray);

                            //actual totals
                            paintHardTotals(sender, e, "?", "?", "?", "?", "?", "?", "?", font1, 2, 14, false,  true, Brushes.Black);
                        }
                        else if (Complete == true)
                        {
                            //derived totals
                            paintHardTotals(sender, e, "", "", "", "", "", "", "", font1, 14, 14, false,false,  Brushes.DarkGray);
                            paintHardTotals(sender, e, "", "", "", "", "", "", "", font1, 2, 14, false, true, Brushes.Black);
                        }
                        else
                        {
                            //derived totals
                            paintHardTotals(sender, e, col1HardSum.ToString(), col2HardSum.ToString(), col3HardSum.ToString(),
                                col4HardSum.ToString(), col5HardSum.ToString(), col6HardSum.ToString(), col7HardSum.ToString(),
                                font1, 14, 14, false, false, Brushes.DarkGray);

                            //actual totals
                            paintHardTotals(sender, e, col1AnswerHard.ToString(), col2AnswerHard.ToString(), col3AnswerHard.ToString(),
                                col4AnswerHard.ToString(), col5AnswerHard.ToString(), col6AnswerHard.ToString(), col7AnswerHard.ToString(),
                                font1, 2, 14, false,true, Brushes.Black);
                        }

                        if (col1HardSum == col1AnswerHard && col2HardSum == col2AnswerHard &&
                            col3HardSum == col3AnswerHard && col4HardSum == col4AnswerHard && col5HardSum == col5AnswerHard &&
                            col6HardSum == col6AnswerHard && col7HardSum == col7AnswerHard)
                        {
                            HardColCompleted = true;
                        }
                    }
                }   
            }
        }

        //draw the derived and actual totals for 1st diagnal for all boards
        private void diagnal1SumBox_Paint(object sender, PaintEventArgs e)
        {
            if (isBoardLoaded)
            {
                if (isEasyBoard)
                {
                    //derived total
                    using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        if (Hide_Board == true)
                        {
                            PointF pointF1 = new PointF(diagnal1SumBox.Width / 6 - 10, diagnal1SumBox.Height / 3);
                            e.Graphics.DrawString("?", font1, Brushes.DarkGray, pointF1);
                        }
                        else if (Complete == true)
                        {
                            PointF pointF1 = new PointF(diagnal1SumBox.Width / 6 - 10, diagnal1SumBox.Height / 3);
                            e.Graphics.DrawString("", font1, Brushes.DarkGray, pointF1);
                        }
                        else
                        {
                            //if we finished guessing for diagnal check and see if we print in green or red
                            //if we are not done guessing the diagnal derived total will be grey
                            if (diagnal1Counter == 3)
                            {
                                if (diagnal1EasySum == diagnal1AnswerEasy)
                                {
                                    PointF pointF1 = new PointF(diagnal1SumBox.Width / 6 - 10, diagnal1SumBox.Height / 3);
                                    e.Graphics.DrawString(diagnal1EasySum.ToString(), font1, Brushes.Green, pointF1);
                                }
                                else if (diagnal1EasySum < diagnal1AnswerEasy || diagnal1EasySum > diagnal1AnswerEasy)
                                {
                                    PointF pointF1 = new PointF(diagnal1SumBox.Width / 6 - 10, diagnal1SumBox.Height / 3);
                                    e.Graphics.DrawString(diagnal1EasySum.ToString(), font1, Brushes.Red, pointF1);
                                }
                            }
                            else
                            {
                                PointF pointF1 = new PointF(diagnal1SumBox.Width / 6 - 10, diagnal1SumBox.Height / 3);
                                e.Graphics.DrawString(diagnal1EasySum.ToString(), font1, Brushes.DarkGray, pointF1);
                            }
                          
                        }
                    }

                    //actual total
                    using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        if (Hide_Board == true)
                        {
                            PointF pointF1 = new PointF(diagnal1SumBox.Width / 2, diagnal1SumBox.Height / 3);
                            e.Graphics.DrawString("?", font1, Brushes.Black, pointF1);
                        }
                        else if (Complete == true)
                        {
                            PointF pointF1 = new PointF(diagnal1SumBox.Width / 2, diagnal1SumBox.Height / 3);
                            e.Graphics.DrawString("", font1, Brushes.Black, pointF1);
                        }
                        else
                        {
                            PointF pointF1 = new PointF(diagnal1SumBox.Width / 2, diagnal1SumBox.Height / 3);
                            e.Graphics.DrawString(diagnal1AnswerEasy.ToString(), font1, Brushes.Black, pointF1);
                        }
                    }

                    if (diagnal1EasySum == diagnal1AnswerEasy)
                    {
                        EasyDiagnalCompleted1 = true;
                    }
                }
                if (isMediumBoard)
                {
                    //derived total
                    using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        if (Hide_Board == true)
                        {
                            PointF pointF1 = new PointF(diagnal1SumBox.Width / 6 - 10, diagnal1SumBox.Height / 3);
                            e.Graphics.DrawString("?", font1, Brushes.DarkGray, pointF1);
                        }
                        else if (Complete == true)
                        {
                            PointF pointF1 = new PointF(diagnal1SumBox.Width / 6 - 10, diagnal1SumBox.Height / 3);
                            e.Graphics.DrawString("", font1, Brushes.DarkGray, pointF1);
                        }
                        else
                        {
                            //if we finished guessing for diagnal check and see if we print in green or red
                            //if we are not done guessing the diagnal derived total will be grey
                            if (diagnal1Counter == 5)
                            {
                                if (diagnal1MediumSum == diagnal1AnswerMed)
                                {
                                    PointF pointF1 = new PointF(diagnal1SumBox.Width / 6 - 10, diagnal1SumBox.Height / 3);
                                    e.Graphics.DrawString(diagnal1MediumSum.ToString(), font1, Brushes.Green, pointF1);
                                }
                                else if (diagnal1MediumSum < diagnal1AnswerMed || diagnal1MediumSum > diagnal1AnswerMed)
                                {
                                    PointF pointF1 = new PointF(diagnal1SumBox.Width / 6 - 10, diagnal1SumBox.Height / 3);
                                    e.Graphics.DrawString(diagnal1MediumSum.ToString(), font1, Brushes.Red, pointF1);
                                }
                            }
                            else
                            {
                                PointF pointF1 = new PointF(diagnal1SumBox.Width / 6 - 10, diagnal1SumBox.Height / 3);
                                e.Graphics.DrawString(diagnal1MediumSum.ToString(), font1, Brushes.DarkGray, pointF1);
                            }
                            
                        }
                    }
                    //actual total
                    using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        if (Hide_Board == true)
                        {
                            PointF pointF1 = new PointF(diagnal1SumBox.Width / 2, diagnal1SumBox.Height / 3);
                            e.Graphics.DrawString("?", font1, Brushes.Black, pointF1);
                        }
                        else if (Complete == true)
                        {
                            PointF pointF1 = new PointF(diagnal1SumBox.Width / 2, diagnal1SumBox.Height / 3);
                            e.Graphics.DrawString("", font1, Brushes.Black, pointF1);
                        }
                        else
                        {
                            PointF pointF1 = new PointF(diagnal1SumBox.Width / 2, diagnal1SumBox.Height / 3);
                            e.Graphics.DrawString(diagnal1AnswerMed.ToString(), font1, Brushes.Black, pointF1);
                        }
                    }

                    if (diagnal1MediumSum == diagnal1AnswerMed)
                    {
                        MediumDiagnalCompleted1 = true;
                    }
                }
                if(isHardBoard)
                {
                    //derived total
                    using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        if (Hide_Board == true)
                        {
                            PointF pointF1 = new PointF(diagnal1SumBox.Width / 6 - 10, diagnal1SumBox.Height / 3);
                            e.Graphics.DrawString("?", font1, Brushes.DarkGray, pointF1);
                        }
                        else if (Complete == true)
                        {
                            PointF pointF1 = new PointF(diagnal1SumBox.Width / 6 - 10, diagnal1SumBox.Height / 3);
                            e.Graphics.DrawString("", font1, Brushes.DarkGray, pointF1);
                        }
                        else
                        {
                            //if we finished guessing all diagnal 1 boxes, then we need to see if we print the derived sum as 
                            //green or red
                            if (diagnal1Counter == 7)
                            {
                                if (diagnal1HardSum == diagnal1AnswerHard)
                                {
                                    PointF pointF1 = new PointF(diagnal1SumBox.Width / 6 - 10, diagnal1SumBox.Height / 3);
                                    e.Graphics.DrawString(diagnal1HardSum.ToString(), font1, Brushes.Green, pointF1);
                                }
                                else if (diagnal1HardSum < diagnal1AnswerHard || diagnal1HardSum > diagnal1AnswerHard)
                                {
                                    PointF pointF1 = new PointF(diagnal1SumBox.Width / 6 - 10, diagnal1SumBox.Height / 3);
                                    e.Graphics.DrawString(diagnal1HardSum.ToString(), font1, Brushes.Red, pointF1);
                                }
                            }
                            else
                            {
                                PointF pointF1 = new PointF(diagnal1SumBox.Width / 6 - 10, diagnal1SumBox.Height / 3);
                                e.Graphics.DrawString(diagnal1HardSum.ToString(), font1, Brushes.DarkGray, pointF1);
                            }
                        }
                    }

                    //actual total
                    using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        if (Hide_Board == true)
                        {
                            PointF pointF1 = new PointF(diagnal1SumBox.Width / 2, diagnal1SumBox.Height / 3);
                            e.Graphics.DrawString("?", font1, Brushes.Black, pointF1);
                        }
                        else if (Complete == true)
                        {
                            PointF pointF1 = new PointF(diagnal1SumBox.Width / 2, diagnal1SumBox.Height / 3);
                            e.Graphics.DrawString("", font1, Brushes.Black, pointF1);
                        }
                        else
                        {
                            PointF pointF1 = new PointF(diagnal1SumBox.Width / 2, diagnal1SumBox.Height / 3);
                            e.Graphics.DrawString(diagnal1AnswerHard.ToString(), font1, Brushes.Black, pointF1);
                        }
                    }

                    if (diagnal1HardSum == diagnal1AnswerHard)
                    {
                        HardDiagnalCompleted1 = true;
                    }
                }
            }
        }

        //draw the derived and actual totals for 2nd diagnal for all boards
        private void diagnal2SumBox_Paint(object sender, PaintEventArgs e)
        {
            if (isBoardLoaded)
            {
                if (isEasyBoard)
                {
                    //derived total
                     using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                     {
                        if (Hide_Board == true)
                        {
                            PointF pointF1 = new PointF(diagnal2SumBox.Width / 6 - 10, diagnal2SumBox.Height / 3);
                            e.Graphics.DrawString("?", font1, Brushes.DarkGray, pointF1);
                        }
                        else if (Complete == true)
                        {
                            PointF pointF1 = new PointF(diagnal2SumBox.Width / 6 - 10, diagnal2SumBox.Height / 3);
                            e.Graphics.DrawString("", font1, Brushes.DarkGray, pointF1);
                        }
                        else
                        {
                            //if we finished guessing all diagnal 2 boxes, then we need to see if we print the derived sum as 
                            //green or red
                            if (diagnal2Counter == 3)
                            {
                                if (diagnal2EasySum == diagnal2AnswerEasy)
                                {
                                    PointF pointF1 = new PointF(diagnal2SumBox.Width / 6 - 10, diagnal2SumBox.Height / 3);
                                    e.Graphics.DrawString(diagnal2EasySum.ToString(), font1, Brushes.Green, pointF1);
                                }
                                else if (diagnal2EasySum < diagnal2AnswerEasy || diagnal2EasySum > diagnal2AnswerEasy)
                                {
                                    PointF pointF1 = new PointF(diagnal2SumBox.Width / 6 - 10, diagnal2SumBox.Height / 3);
                                    e.Graphics.DrawString(diagnal2EasySum.ToString(), font1, Brushes.Red, pointF1);
                                }
                            }
                            else
                            {
                                PointF pointF1 = new PointF(diagnal2SumBox.Width / 6 - 10, diagnal2SumBox.Height / 3);
                                e.Graphics.DrawString(diagnal2EasySum.ToString(), font1, Brushes.DarkGray, pointF1);
                            }
                        }
                     }
                   
                    //actual total
                    using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        if (Hide_Board == true)
                        {
                            PointF pointF1 = new PointF(diagnal2SumBox.Width / 2, diagnal2SumBox.Height / 3);
                            e.Graphics.DrawString("?", font1, Brushes.Black, pointF1);
                        }
                        else if (Complete == true)
                        {
                            PointF pointF1 = new PointF(diagnal2SumBox.Width / 2, diagnal2SumBox.Height / 3);
                            e.Graphics.DrawString("", font1, Brushes.Black, pointF1);
                        }
                        else
                        {
                            PointF pointF1 = new PointF(diagnal2SumBox.Width / 2, diagnal2SumBox.Height / 3);
                            e.Graphics.DrawString(diagnal2AnswerEasy.ToString(), font1, Brushes.Black, pointF1);
                        }
                    }

                    if (diagnal2EasySum == diagnal2AnswerEasy)
                    {
                        EasyDiagnalCompleted2 = true;
                    }
                }
                if (isMediumBoard)
                {
                    //derived total
                    using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        if (Hide_Board == true)
                        {
                            PointF pointF1 = new PointF(diagnal2SumBox.Width / 6 - 10, diagnal2SumBox.Height / 3);
                            e.Graphics.DrawString("?", font1, Brushes.DarkGray, pointF1);
                        }
                        else if (Complete == true)
                        {
                            PointF pointF1 = new PointF(diagnal2SumBox.Width / 6 - 10, diagnal2SumBox.Height / 3);
                            e.Graphics.DrawString("", font1, Brushes.DarkGray, pointF1);
                        }
                        else
                        {
                            //if we finished guessing for diagnal check and see if we print in green or red
                            //if we are not done guessing the diagnal derived total will be grey
                            if (diagnal2Counter == 5)
                            {
                                if (diagnal2MediumSum == diagnal2AnswerMed)
                                {
                                    PointF pointF1 = new PointF(diagnal2SumBox.Width / 6 - 10, diagnal2SumBox.Height / 3);
                                    e.Graphics.DrawString(diagnal2MediumSum.ToString(), font1, Brushes.Green, pointF1);
                                }
                                else if (diagnal2MediumSum < diagnal2AnswerMed || diagnal2MediumSum > diagnal2AnswerMed)
                                {
                                    PointF pointF1 = new PointF(diagnal2SumBox.Width / 6 - 10, diagnal2SumBox.Height / 3);
                                    e.Graphics.DrawString(diagnal2MediumSum.ToString(), font1, Brushes.Red, pointF1);
                                }
                            }
                            else
                            {
                                PointF pointF1 = new PointF(diagnal2SumBox.Width / 6 - 10, diagnal2SumBox.Height / 3);
                                e.Graphics.DrawString(diagnal2MediumSum.ToString(), font1, Brushes.DarkGray, pointF1);
                            }

                            /*
                            PointF pointF1 = new PointF(diagnal2SumBox.Width / 6 - 10, diagnal2SumBox.Height / 3);
                            e.Graphics.DrawString(diagnal2MediumSum.ToString(), font1, Brushes.DarkGray, pointF1);
                            */
                        }
                    }

                    //actual total
                    using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        if (Hide_Board == true)
                        {
                            PointF pointF1 = new PointF(diagnal2SumBox.Width / 2, diagnal2SumBox.Height / 3);
                            e.Graphics.DrawString("?", font1, Brushes.Black, pointF1);
                        }
                        else if (Complete == true)
                        {
                            PointF pointF1 = new PointF(diagnal2SumBox.Width / 2, diagnal2SumBox.Height / 3);
                            e.Graphics.DrawString("", font1, Brushes.Black, pointF1);
                        }
                        else
                        {
                            PointF pointF1 = new PointF(diagnal2SumBox.Width / 2, diagnal2SumBox.Height / 3);
                            e.Graphics.DrawString(diagnal2AnswerMed.ToString(), font1, Brushes.Black, pointF1);
                        }
                    }

                    if (diagnal2MediumSum == diagnal2AnswerMed)
                    {
                        MediumDiagnalCompleted2 = true;
                    }
                }
                if(isHardBoard)
                {
                    //derived total
                    using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        if (Hide_Board == true)
                        {
                            PointF pointF1 = new PointF(diagnal2SumBox.Width / 6 - 10, diagnal2SumBox.Height / 3);
                            e.Graphics.DrawString("?", font1, Brushes.DarkGray, pointF1);
                        }
                        else if (Complete == true)
                        {
                            PointF pointF1 = new PointF(diagnal2SumBox.Width / 6 - 10, diagnal2SumBox.Height / 3);
                            e.Graphics.DrawString("", font1, Brushes.DarkGray, pointF1);
                        }
                        else
                        {
                            //if we finished guessing all diagnal 2 boxes, then we need to see if we print the derived sum as 
                            //green or red
                            if (diagnal2Counter == 7)
                            {
                                if (diagnal2HardSum == diagnal2AnswerHard)
                                {
                                    PointF pointF1 = new PointF(diagnal2SumBox.Width / 6 - 10, diagnal2SumBox.Height / 3);
                                    e.Graphics.DrawString(diagnal2HardSum.ToString(), font1, Brushes.Green, pointF1);
                                }
                                else if (diagnal2HardSum < diagnal2AnswerHard || diagnal2HardSum > diagnal2AnswerHard)
                                {
                                    PointF pointF1 = new PointF(diagnal2SumBox.Width / 6 - 10, diagnal2SumBox.Height / 3);
                                    e.Graphics.DrawString(diagnal2HardSum.ToString(), font1, Brushes.Red, pointF1);
                                }
                            }
                            else
                            {
                                PointF pointF1 = new PointF(diagnal2SumBox.Width / 6 - 10, diagnal2SumBox.Height / 3);
                                e.Graphics.DrawString(diagnal2HardSum.ToString(), font1, Brushes.DarkGray, pointF1);
                            }
                        }
                    }
                    
                    //actual total
                    using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
                    {
                        if (Hide_Board == true)
                        {
                            PointF pointF1 = new PointF(diagnal2SumBox.Width / 2, diagnal2SumBox.Height / 3);
                            e.Graphics.DrawString("?", font1, Brushes.Black, pointF1);
                        }
                        else if (Complete == true)
                        {
                            PointF pointF1 = new PointF(diagnal2SumBox.Width / 2, diagnal2SumBox.Height / 3);
                            e.Graphics.DrawString("", font1, Brushes.Black, pointF1);
                        }
                        else
                        {
                            
                                PointF pointF1 = new PointF(diagnal2SumBox.Width / 2, diagnal2SumBox.Height / 3);
                                e.Graphics.DrawString(diagnal2AnswerHard.ToString(), font1, Brushes.Black, pointF1);
                            
                        }
                    }

                    if (diagnal2HardSum == diagnal2AnswerHard)
                    {
                        HardDiagnalCompleted2 = true;
                    }
                }
            }
        }

        private void PauseResume_Button_Click(object sender, EventArgs e)
        {
            isEasyGame = false;
            isMediumGame = false;
            isHardGame = false;

            //Display the current time when user clicks pause
            if (PauseResume_Button.Text == "Pause")
            {
               
                Paused = true;
                tmrCounter.Enabled = false;
                PauseResume_Button.Text = "Resume";
                isDown = true;
                Hide_Board = true;
                          
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
                Complete = false;
                canvas.Refresh();
                rowSumBox.Refresh();
                columnSumBox.Refresh();
                diagnal1SumBox.Refresh();
                diagnal2SumBox.Refresh();
                //refresh_totals_and_canvas();                
            }
            
            else if (PauseResume_Button.Text == "Resume")
            {
                PauseResume_Button.Text = "Pause";
                isDown = true;
                tmrCounter.Enabled = true;
                Hide_Board = false;
                Paused = false;
                
                if (gameDifficultyDropDown.Text == "Easy")
                {
                    isEasyGame = true;
                    resetMediumPuzzleTextboxes();
                    resetHardPuzzleTextboxes();
                }
                if(gameDifficultyDropDown.Text == "Medium")
                {
                    isMediumGame = true;
                    resetEasyPuzzleTextboxes();
                    resetHardPuzzleTextboxes();
                }
                if(gameDifficultyDropDown.Text == "Hard")
                {
                    isHardGame = true;
                    resetEasyPuzzleTextboxes();
                    resetMediumPuzzleTextboxes();
                }
                
                Hide_Board = false;
                canvas.Refresh();
                rowSumBox.Refresh();
                columnSumBox.Refresh();
                diagnal1SumBox.Refresh();
                diagnal2SumBox.Refresh();
                
                //refresh_totals_and_canvas();
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

        private void tmrCounter_Tick(object sender, EventArgs e)
        {
            i++;
            timerticks = i;
            //every time the counter ticks convert the amount of seconds to hours, minutes and seconds and display the time
            string time = convertseconds(i);
            Timer_Label.Text = "Current Time: " + time;
        }

        private void completed_puzzle()
        {
            if (EasyRowCompleted && EasyColCompleted && EasyDiagnalCompleted2)
            {
                tmrCounter.Enabled = false;
                easy_itr++;
                string EasyTimeRecord;
                if (easy_itr == 1)
                {
                    using (StreamReader inFile = new StreamReader("../../easy/eTimes.txt"))
                    {
                        while ((EasyTimeRecord = inFile.ReadLine()) != null)
                        {
                            EasyTimer.Add(EasyTimeRecord);
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

                    MessageBox.Show("Completed!\n" + Timer_Label.Text + "\nAverage for Easy Puzzles: " + convertseconds(average) + "\nFastest Time: " + convertseconds(smallest));
                }
                else
                {
                    MessageBox.Show("Completed!\n" + Timer_Label.Text + "\nAverage: " + convertseconds(i) + "\nFastest Time: " + convertseconds(i));
                }

                using (StreamWriter writer = new StreamWriter("../../easy/eTimes.txt"))
                {
                    foreach (string item in EasyTimer)
                    {
                        writer.WriteLine(item + " ");
                    }
                }
                Complete = true;
            }
            else if (MediumRowCompleted && MediumColCompleted && MediumDiagnalCompleted1 && MediumDiagnalCompleted2)
            {
                tmrCounter.Enabled = false;
                med_itr++;
                string MedTimeRecord;
                if (med_itr == 1)
                {
                    using (StreamReader inFile = new StreamReader("../../medium/mTimes.txt"))
                    {
                        while ((MedTimeRecord = inFile.ReadLine()) != null)
                        {
                            MedTimer.Add(MedTimeRecord);
                        }
                    }
                }
                MedTimer.Add(i.ToString());
                if (MedTimer.Count != 0)
                {
                    int average = 0;
                    int numofTimes = 0;
                    int smallest = int.Parse(MedTimer[0]);
                    foreach (string item in MedTimer)
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
                    MessageBox.Show("Completed!\n" + Timer_Label.Text + " \nAverage for Medium Puzzles: " + convertseconds(average) + "\nFastest Time: " + convertseconds(smallest));
                }
                else
                {
                    MessageBox.Show("Completed!" + Timer_Label.Text + "\nAverage: " + convertseconds(i) + "\nFastest Time: " + convertseconds(i));
                }
                using (StreamWriter writer = new StreamWriter("../../medium/mTimes.txt"))
                {
                    foreach (string item in MedTimer)
                    {
                        writer.WriteLine(item + " ");
                    }
                }
                Complete = true; 
            }
            else if (HardRowCompleted && HardDiagnalCompleted1 && HardDiagnalCompleted2)
            {
                tmrCounter.Enabled = false;
                hard_itr++;
                string HardTimeRecord;
                if (hard_itr == 1)
                {
                    using (StreamReader inFile = new StreamReader("../../hard/hTimes.txt"))
                    {
                        while ((HardTimeRecord = inFile.ReadLine()) != null)
                        {
                            HardTimer.Add(HardTimeRecord);
                        }
                    }
                }
                HardTimer.Add(i.ToString());
                if (HardTimer.Count != 0)
                {
                    int average = 0;
                    int numofTimes = 0;

                    //ERRORS OUT HERE WHEN COMPLETING HARD PUZZLE
                    int smallest = int.Parse(HardTimer[0]);
                    foreach (string item in HardTimer)
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
                    MessageBox.Show("Completed!\n" + Timer_Label.Text + " \nAverage for Hard Puzzles: " + convertseconds(average) + "\nFastest Time: " + convertseconds(smallest));
                }
                else
                {
                    MessageBox.Show("Completed!" + Timer_Label.Text + "\nAverage: " + convertseconds(i) + "\nFastest Time: " + convertseconds(i));
                }
                using (StreamWriter writer = new StreamWriter("../../hard/hTimes.txt"))
                {
                    foreach (string item in HardTimer)
                    {
                        writer.WriteLine(item + " ");
                    }
                }
                Complete = true;
            }
            if (Complete == true)
            {
                refresh_totals_and_canvas();
                PauseResume_Button.Text = "Pause";
                if (Saved)
                {
                    FileStream easyfileStream = File.Open(easyGame, FileMode.Open);
                    easyfileStream.SetLength(0);
                    easyfileStream.Close();
                    EasySaved.Clear();
                    FileStream medfileStream = File.Open(mediumGame, FileMode.Open);
                    medfileStream.SetLength(0);
                    medfileStream.Close();
                    MediumSaved.Clear();
                }
                Saved = false;
                Complete = false;
                Hide_Board = false;
                isEasyGame = false;
                isMediumGame = false;
                isHardGame = false;
                EasyRowCompleted = false;
                MediumRowCompleted = false;
                HardRowCompleted = false;
                EasyColCompleted = false;
                MediumColCompleted = false;
                HardColCompleted = false;
                EasyDiagnalCompleted1 = false;
                EasyDiagnalCompleted2 = false;
                MediumDiagnalCompleted1 = false;
                MediumDiagnalCompleted2 = false;
                HardDiagnalCompleted1 = false;
                HardDiagnalCompleted2 = false;
                gameDifficultyDropDown.Text = "";
                resetEasyPuzzleTextboxes();
                resetMediumPuzzleTextboxes();
                resetHardPuzzleTextboxes();
                Timer_Label.Text = "";
                gameBoardCount++;

                //if we get up to 3, reset to 1
                if(gameBoardCount == 3)
                {
                    gameBoardCount = 1;
                }
                canvas.Refresh();

            }
        }
        private void resetPuzzleButton_MouseDown(object sender, MouseEventArgs e)
        {
            //refresh everything and clear out the textboxes since we are resetting
            refresh_totals_and_canvas();
            highlightValue = false;
            tmrCounter.Enabled = false;

            //clear out the textboxes
            foreach (TextBox i in generatedEasyTextboxes)
            {
                i.Text = "";
            }
            foreach (TextBox i in generatedMedTextboxes)
            {
                i.Text = "";
            }
            foreach (TextBox i in generatedHardTextboxes)
            {
                i.Text = "";
            }
        }

        private void resetPuzzleButton_MouseUp(object sender, MouseEventArgs e)
        {
            //enable the timer and restart the clock
            tmrCounter.Enabled = true;
            i = 0;
        }

        private void highLightWrongArea(PaintEventArgs e )
        {
            Graphics graphics = e.Graphics;

            //go through the textbox guesses list, and depending what index value it is and what 
            //game board we are checking progress on, we will highlight that row, diagnal, and column
            foreach (int i in textboxesGuessed)
            { 
                Pen highlighter = new Pen(Color.FromArgb(128, 255, 255, 0), 15);
                using (highlighter)
                {
                    highlighter.Width = 30;

                    if (isEasyBoard)
                    {
                        //first row
                        if (i >= 0 && i < 3)
                        {
                            e.Graphics.DrawLine(highlighter, 0, canvas.Height / 6 + 10, canvas.Width, canvas.Height / 6 + 10);
                        }
                        //second row
                        if(i >=3 && i < 6)
                        {
                            e.Graphics.DrawLine(highlighter, 0, 3 * canvas.Height / 6 + 10, canvas.Width, 3 * canvas.Height / 6 + 10);
                        }
                        //third row
                        if (i >= 6 && i < 9)
                        {
                            e.Graphics.DrawLine(highlighter, 0, 5 * canvas.Height / 6 + 10, canvas.Width, 5 * canvas.Height / 6 + 10);
                        }
                        //first column
                        if (i == 0 ||  i == 3 || i == 6)
                        {
                            e.Graphics.DrawLine(highlighter, canvas.Width / 6, 0,  canvas.Width / 6, canvas.Height);
                        }
                        //second column
                        if(i == 1 || i == 4 || i == 7)
                        {
                            e.Graphics.DrawLine(highlighter, 3 * canvas.Width / 6, 0, 3 * canvas.Width / 6, canvas.Height);
                        }
                        //third column
                        if (i == 2 || i == 5 || i == 8)
                        {
                            e.Graphics.DrawLine(highlighter, 5 * canvas.Width / 6, 0, 5 * canvas.Width / 6, canvas.Height);
                        }
                        //diagnal 1
                        if(i == 2 || i == 4 || i == 6)
                        {
                            e.Graphics.DrawLine(highlighter, canvas.Width , 0, 0, canvas.Height);
                        }
                        //diagnal 2
                        if (i == 0|| i == 4 || i == 8)
                        {
                            e.Graphics.DrawLine(highlighter, 0, 0, canvas.Width, canvas.Height);
                        }
                    }
                    if(isMediumBoard)
                    {
                        //rows of medium board
                        if(i >= 0 && i < 5)
                        {
                            e.Graphics.DrawLine(highlighter, 0, canvas.Height / 10 + 10, canvas.Width, canvas.Height / 10 + 10);
                        }
                        if(i >= 5 && i < 9)
                        {
                            e.Graphics.DrawLine(highlighter, 0, 3 * canvas.Height / 10 + 10, canvas.Width, 3 * canvas.Height / 10 + 10);
                        }
                        if (i >= 9 && i < 14)
                        {
                            e.Graphics.DrawLine(highlighter, 0, 5 * canvas.Height / 10 + 10, canvas.Width, 5 * canvas.Height / 10 + 10);
                        }
                        if (i >= 14 && i < 19)
                        {
                            e.Graphics.DrawLine(highlighter, 0, 7 * canvas.Height / 10 + 10, canvas.Width, 7 * canvas.Height / 10 + 10);
                        }
                        if (i >= 19 && i < 25)
                        {
                            e.Graphics.DrawLine(highlighter, 0, 9 *canvas.Height / 10 + 10, canvas.Width, 9 * canvas.Height / 10 + 10);
                        }
                        //columns of medium board
                        if(i == 0 || i == 5 || i == 10 || i == 15 || i == 20)
                        {
                            e.Graphics.DrawLine(highlighter, canvas.Width / 10 + 5, 0, canvas.Width / 10 + 5, canvas.Height);
                        }
                        if (i == 1 || i == 6 || i == 11 || i == 16 || i == 21)
                        {
                            e.Graphics.DrawLine(highlighter, 3 * canvas.Width / 10 + 5, 0, 3 * canvas.Width / 10 + 5, canvas.Height);
                        }
                        if (i == 2 || i == 7 || i == 12 || i == 17 || i == 22)
                        {
                            e.Graphics.DrawLine(highlighter, 5 * canvas.Width / 10 + 5, 0, 5 * canvas.Width / 10 + 5, canvas.Height);
                        }
                        if (i == 3 || i == 8 || i == 13 || i == 18 || i == 23)
                        {
                            e.Graphics.DrawLine(highlighter, 7 * canvas.Width / 10 + 5, 0, 7 * canvas.Width / 10 + 5, canvas.Height);
                        }
                        if (i == 4 || i == 9 || i == 14 || i == 19 || i == 24)
                        {
                            e.Graphics.DrawLine(highlighter, 9 * canvas.Width / 10 + 5, 0, 9 * canvas.Width / 10 + 5, canvas.Height);
                        }
                        //diagnal 1
                        if (i == 4 || i == 8 || i == 12 || i == 16 || i == 20)
                        {
                            e.Graphics.DrawLine(highlighter, canvas.Width, 0, 0, canvas.Height);
                        }
                        //diagnal 2
                        if (i == 0 || i == 6 || i == 12 || i == 18 || i == 24)
                        {
                            e.Graphics.DrawLine(highlighter, 0, 0, canvas.Width, canvas.Height);
                        }
                    }
                    if(isHardBoard)
                    {
                        //rows
                        if(i >= 0 && i < 7)
                        {
                            e.Graphics.DrawLine(highlighter, 0, canvas.Height / 14, canvas.Width, canvas.Height / 14);
                        }
                        if(i >= 7 && i < 14)
                        {
                            e.Graphics.DrawLine(highlighter, 0, 3 * canvas.Height / 14, canvas.Width, 3 * canvas.Height / 14);
                        }
                        if (i >= 14 && i < 21)
                        {
                            e.Graphics.DrawLine(highlighter, 0, 5 * canvas.Height / 14, canvas.Width, 5 * canvas.Height / 14);
                        }
                        if (i >= 21 && i < 28)
                        {
                            e.Graphics.DrawLine(highlighter, 0, 7 * canvas.Height / 14, canvas.Width, 7 * canvas.Height / 14);
                        }
                        if (i >= 28 && i < 35)
                        {
                            e.Graphics.DrawLine(highlighter, 0, 9 * canvas.Height / 14, canvas.Width, 9 * canvas.Height / 14);
                        }
                        if (i >= 35 && i < 42)
                        {
                            e.Graphics.DrawLine(highlighter, 0, 11 * canvas.Height / 14, canvas.Width, 11 * canvas.Height / 14);
                        }
                        if (i >= 42 && i < 49)
                        {
                            e.Graphics.DrawLine(highlighter, 0, 13 * canvas.Height / 14, canvas.Width, 13 * canvas.Height / 14);
                        }
                        //columns
                        if(i == 0 || i == 7 || i == 14 || i == 21 || i == 28 || i == 35 || i == 42)
                        {
                            e.Graphics.DrawLine(highlighter, canvas.Width / 14 + 5 , 0,  canvas.Width /14 + 5, canvas.Height);
                        }
                        if (i == 1 || i == 8 || i == 15 || i == 22 || i == 29 || i == 36 || i == 43)
                        {
                            e.Graphics.DrawLine(highlighter, 3 * canvas.Width / 14 + 5, 0, 3 * canvas.Width / 14 + 5, canvas.Height);
                        }
                        if (i == 2 || i == 9 || i == 16 || i == 23 || i == 30 || i == 37 || i == 44)
                        {
                            e.Graphics.DrawLine(highlighter, 5 * canvas.Width / 14 + 5, 0, 5 * canvas.Width / 14 + 5, canvas.Height);
                        }
                        if (i == 3 || i == 10 || i == 17 || i == 24 || i == 31 || i == 38 || i == 45)
                        {
                            e.Graphics.DrawLine(highlighter, 7 * canvas.Width / 14 + 5, 0, 7 * canvas.Width / 14 + 5, canvas.Height);
                        }
                        if (i == 4 || i == 11 || i == 18 || i == 25 || i == 32 || i == 39 || i == 46)
                        {
                            e.Graphics.DrawLine(highlighter, 9 * canvas.Width / 14 + 5, 0, 9 * canvas.Width / 14 + 5, canvas.Height);
                        }
                        if (i == 5 || i == 12 || i == 19 || i == 26 || i == 33 || i == 40 || i == 47)
                        {
                            e.Graphics.DrawLine(highlighter, 11 * canvas.Width / 14 + 5, 0, 11 * canvas.Width / 14 + 5, canvas.Height);
                        }
                        if (i == 6 || i == 13 || i == 20 || i == 27 || i == 34 || i == 41 || i == 48)
                        {
                            e.Graphics.DrawLine(highlighter, 13 * canvas.Width / 14 + 5, 0, 13 * canvas.Width / 14 + 5, canvas.Height);
                        }
                        //diagnal 1
                        if (i == 6 || i == 12 || i == 18 || i == 24 || i == 30 || i == 36 || i == 42)
                        {
                            e.Graphics.DrawLine(highlighter, canvas.Width, 0, 0, canvas.Height);
                        }
                        //diagnal 2
                        if (i == 0 || i == 8 || i == 16 || i == 24 || i == 32 || i == 40 || i == 48)
                        {
                            e.Graphics.DrawLine(highlighter, 0, 0, canvas.Width, canvas.Height);
                        }

                    }
                }
            }
        }
        
        private void progressButton_Click(object sender, EventArgs e)
        {
            int textboxesFilled = 0;
            int textboxesRight = 0;
            //clear out the textboxes we have guessed
            textboxesGuessed.Clear();

            //if it is the easy board then we need to go through the easy textboxes
            if (isEasyBoard)
            {
                textboxesFilled = 0;
                textboxesRight = 0;
                isEasyGame = true;
                for (int i = 0; i < generatedEasyTextboxes.Count; i++)
                {
                    //if the textbox is not empty see if it is equal to answer key
                    if (!String.IsNullOrEmpty(generatedEasyTextboxes[i].Text))
                    {
                        //add one to textboxed fille
                        textboxesFilled++;
                        if (generatedEasyTextboxes[i].Text == gameAnswersEasy1[i].ToString())
                        {
                            //if the value is right, then add one to the counter, if the number of boxes filled
                            //equals the number of textboxes that are right, the user has entered all right values
                            //else they entered a wrong value
                            textboxesRight++;
                        }
                        else
                        {
                            //add the index to the textbox
                            textboxesGuessed.Add(i);
                        }
                    }
                }
            }
            if (isMediumBoard)
            {
                textboxesFilled = 0;
                textboxesRight = 0;
                isMediumGame = true;

                for (int i = 0; i < generatedMedTextboxes.Count; i++)
                {
                    //if the textbox is not empty see if it is equal to answer key
                    if (!String.IsNullOrEmpty(generatedMedTextboxes[i].Text))
                    {
                        //add one to textboxed fille
                        textboxesFilled++;
                        if (generatedMedTextboxes[i].Text == gameAnswersMed1[i].ToString())
                        {
                            //if the value is right, then add one to the counter, if the number of boxes filled
                            //equals the number of textboxes that are right, the user has entered all right values
                            //else they entered a wrong value
                            textboxesRight++;
                        }
                        else
                        {
                            //add the index to the textbox
                            textboxesGuessed.Add(i);
                        }
                    }
                }
            }
            if(isHardBoard)
            {
                textboxesFilled = 0;
                textboxesRight = 0;
                isHardGame = true;

                for (int i = 0; i < generatedHardTextboxes.Count; i++)
                {
                    //if the textbox is not empty see if it is equal to answer key
                    if (!String.IsNullOrEmpty(generatedHardTextboxes[i].Text))
                    {
                        //add one to textboxed fille
                        textboxesFilled++;
                        if (generatedHardTextboxes[i].Text == gameAnswersHard1[i].ToString())
                        {
                            //if the value is right, then add one to the counter, if the number of boxes filled
                            //equals the number of textboxes that are right, the user has entered all right values
                            //else they entered a wrong value
                            textboxesRight++;
                        }
                        else
                        {
                            //add the index to the textbox
                            textboxesGuessed.Add(i);
                        }
                    }
                }
            }

                //if the amount of boxes we filles equals the amount right, that means
                //all our guesses have been right so send a messagebox message and refresh the board
                //if we previously highlighted it to get rid of highlight bar
                if (textboxesFilled == textboxesRight)
                {
                    if (textboxesFilled != 0)
                    {
                        MessageBox.Show("You're doing great! Keep it up!");
                        if (highlightValue)
                        {
                            canvas.Refresh();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a value guess before seeing progress!");
                    }
                }
                else
                {
                    highlightValue = true;
                    canvas.Refresh();
                }
            
            
        }
        private void save_puzzle()
        {
            if (EasySaved.Count != 0 && isEasyGame)
            {
                using (StreamWriter writer = new StreamWriter(easyGame))
                {
                    for (int i = 0; i < 9; i++)
                    {
                        writer.WriteLine(EasySaved[i]);
                    }
                    for (int n = 4; n < 7; n++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            writer.WriteLine(gameStatsEasy1[n][j]);
                        }
                    }
                }
            }
            if (MediumSaved.Count != 0 && isMediumGame)
            {
                using (StreamWriter writer = new StreamWriter(mediumGame))
                {
                    for (int i = 0; i < 25; i++)
                    {
                        writer.WriteLine(MediumSaved[i]);
                    }
                    for (int n = 6; n < 11; n++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            writer.WriteLine(gameStatsMedium1[n][j]);
                        }
                    }
                }
            }
            refresh_totals_and_canvas();
            resetEasyPuzzleTextboxes();
            resetMediumPuzzleTextboxes();
            resetHardPuzzleTextboxes();
            Timer_Label.Text = "";
            canvas.Refresh();

            readInFileInfo();
        }
    }
}
