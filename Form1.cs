using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        SnakeGame game;
        Timer timer;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (game != null)
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        game.nextDirection = SnakeGame.Direction.Left;
                        break;
                    case Keys.Up:
                        game.nextDirection = SnakeGame.Direction.Up;
                        break;
                    case Keys.Right:
                        game.nextDirection = SnakeGame.Direction.Right;
                        break;
                    case Keys.Down:
                        game.nextDirection = SnakeGame.Direction.Down;
                        break;
                    default:
                        break;
                }
            }
        }

        private void StartBttn_Click(object sender, EventArgs e)
        {
            int minGridSize = 15;
            if (minGridSize > GetGridSize())
                GridSizeTxtBox.Text = minGridSize.ToString();

            game = new SnakeGame(GetGridSize());

            int minMiliseconds = 200;
            if (GetMiliseconds() < minMiliseconds)
                MilisecondsTxtBox.Text = minMiliseconds.ToString();

            timer = new Timer()
            {
                Interval = GetMiliseconds(),
            };
            timer.Tick += UpdateOrchestrator;

        }

        private void UpdateOrchestrator(object sender, EventArgs e)
        {
            game.Update();
        }

        private int GetGridSize() => Convert.ToInt32(GridSizeTxtBox.Text);
        private int GetMiliseconds() => Convert.ToInt32(MilisecondsTxtBox.Text);

        private void GridSizeTxtBox_TextChanged(object sender, EventArgs e)
        {
            GridSizeTxtBox.Text = ToOnlyDigits(GridSizeTxtBox.Text);
        }

        private void MilisecondsTxtBox_TextChanged(object sender, EventArgs e)
        {
            MilisecondsTxtBox.Text = ToOnlyDigits(MilisecondsTxtBox.Text);
        }

        private string ToOnlyDigits(string unprocessed)
        {
            string unprocessedText = unprocessed;
            string processedText = string.Empty;
            char[] chars = unprocessedText.ToCharArray();
            if (chars.Length == 0)
            {
                processedText = "0";
            }
            else
            {
                foreach (char c in chars)
                    if (char.IsDigit(c))
                        unprocessedText += c;
            }
            return processedText;
        }
    }
}
