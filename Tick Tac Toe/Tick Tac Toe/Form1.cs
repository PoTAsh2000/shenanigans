using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Tick_Tac_Toe
{
    public partial class Form1 : Form
    {
        public string move = "X";
        Button[] allSquares = new Button[9];

        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
            allSquares = new Button[9] { Square1, Square2, Square3, Square4, Square5, Square6, Square7, Square8, Square9};
        }

        // If the last move placed was an X change the current move to O and vice versa
        private void TeamMove(String lastmove)
        {
            if (lastmove == "X")
            {
                move = "O";
            }
            else
            {
                move = "X";
            }
        }

        private void CheckWinOrDraw ()
        {
            // Create a list of button arrays. Each button array contains 3 buttons that are required to make a winning row, col, or diagnal.
            // For example btn Square1 btn Square2 btn Square3 are the first 3 buttons on the top row. If all of these are checked by one team it means that team has won 3 in a row
            List<Button[]> allPosibleWins = new List<Button[]>();
            allPosibleWins.Add(new Button[] { Square1, Square2, Square3 });
            allPosibleWins.Add(new Button[] { Square4, Square5, Square6 });
            allPosibleWins.Add(new Button[] { Square7, Square8, Square9 });
            allPosibleWins.Add(new Button[] { Square1, Square4, Square7 });
            allPosibleWins.Add(new Button[] { Square2, Square5, Square8 });
            allPosibleWins.Add(new Button[] { Square3, Square6, Square9 });
            allPosibleWins.Add(new Button[] { Square1, Square5, Square9 });
            allPosibleWins.Add(new Button[] { Square3, Square5, Square7 });

            // Loop over all the button arrays in the list at once
            foreach (Button[] buttons in allPosibleWins)
            {
                // Loop through each button in the array and check if the text is equal to the team that just did a move
                // If a button on a row, col or diagnal is equal to the playing team increase int checks by one
                int checks = 0;
                for (int i = 0; i < buttons.Length; i++) {
                    if (buttons[i].Text == move)
                    {
                        checks += 1;
                    }
                }

                // If checks equals 3 that means that there is a full row, col or diagnal checked by one team meaning: Tick tac toe, three in a row!
                // Now that a team has won, display the winning team and disable all buttons to stop the players from clicking it
                if (checks == 3)
                {
                    label1.Text = $"Team {move} won!";
                    foreach (Button square in allSquares)
                    {
                        square.Enabled = false;
                    }
                }
            }

            int squaresChecked = 0;
            foreach (Button square in allSquares)
            {
                if (square.Text != "")
                {
                    squaresChecked += 1;
                }
            }
            
            if (squaresChecked == 9)
            {
                label1.Text = "Game is a draw";
                foreach (Button square in allSquares)
                {
                    square.Enabled = false;
                }
            }
        }

        /*
         * Down here I detect all button presses
         * If the buttons text is empty you are able to click it
         * After the click I call the method checkWins to check if it was a winning move
         * At the end the method TeamMove changes the team from O to X or X to O
         */

        private void Square1_Click(object sender, EventArgs e)
        {
            if (Square1.Text == "")
            {
                Square1.Text = move;
                CheckWinOrDraw();
                TeamMove(move);
            }
        }

        private void Square2_Click(object sender, EventArgs e)
        {
            if (Square2.Text == "")
            {
                Square2.Text = move;
                CheckWinOrDraw();
                TeamMove(move);
            }
        }

        private void Square3_Click(object sender, EventArgs e)
        {
            if (Square3.Text == "")
            {
                Square3.Text = move;
                CheckWinOrDraw();
                TeamMove(move);
            }
        }

        private void Square4_Click(object sender, EventArgs e)
        {
            if (Square4.Text == "")
            {
                Square4.Text = move;
                CheckWinOrDraw();
                TeamMove(move);
            }
        }

        private void Square5_Click(object sender, EventArgs e)
        {
            if (Square5.Text == "")
            {
                Square5.Text = move;
                CheckWinOrDraw();
                TeamMove(move);
            }
        }

        private void Square6_Click(object sender, EventArgs e)
        {
            if (Square6.Text == "")
            {
                Square6.Text = move;
                CheckWinOrDraw();
                TeamMove(move);
            }
        }

        private void Square7_Click(object sender, EventArgs e)
        {
            if (Square7.Text == "")
            {
                Square7.Text = move;
                CheckWinOrDraw();
                TeamMove(move);
            }
        }

        private void Square8_Click(object sender, EventArgs e)
        {
            if (Square8.Text == "")
            {
                Square8.Text = move;
                CheckWinOrDraw();
                TeamMove(move);
            }
        }

        private void Square9_Click(object sender, EventArgs e)
        {
            if (Square9.Text == "")
            {
                Square9.Text = move;
                CheckWinOrDraw();
                TeamMove(move);
            }
        }

        // This function restarts the game
        private void ButtonReset_Click(object sender, EventArgs e)
        {
            // Reset all squares to starting position
            foreach (Button square in allSquares)
            {
                square.Text = "";
                square.Enabled = true;
            }
            move = "X";
            label1.Text = "";
        }
    }
}
