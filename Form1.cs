using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTicTacToe
{
    public partial class Form1 : Form
    {
        bool turn = true; // True is X turn and O is false turn
        int cout_turn = 0; 
        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is project created by Serhii Chernov and Maciej Wosko","Tic Tac Toe About");
        }

        private void exitGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
            turn = !turn;
            b.Enabled = false;
            cout_turn++;

            checkCurrentWinner();
        }
        private void checkCurrentWinner()
        {
            bool current_winner = false;
            //horizontal checks
            if((button1.Text== button2.Text) && (button2.Text == button3.Text)&&(!button1.Enabled))
            {
                current_winner = true;
            }
            else if ((button4.Text == button5.Text) && (button5.Text == button6.Text) && (!button4.Enabled))
            {
                current_winner = true;
            }
            else if ((button7.Text == button8.Text) && (button8.Text == button9.Text) && (!button7.Enabled))
            {
                current_winner = true;
            }
            //vertical checks
            else if ((button1.Text == button4.Text) && (button4.Text == button7.Text) && (!button1.Enabled))
            {
                current_winner = true;
            }
            else if ((button2.Text == button5.Text) && (button5.Text == button8.Text) && (!button2.Enabled))
            {
                current_winner = true;
            }
            else if ((button3.Text == button6.Text) && (button6.Text == button9.Text) && (!button3.Enabled))
            {
                current_winner = true;
            }
            //diagonal checks
            else if ((button1.Text == button5.Text) && (button5.Text == button9.Text) && (!button1.Enabled))
            {
                current_winner = true;
            }
            else if ((button3.Text == button5.Text) && (button5.Text == button7.Text) && (!button7.Enabled))
            {
                current_winner = true;
            }


            if (current_winner)
            {
                disableButtons();
                string winner = "";
                if (turn)
                    winner = "O";
                else
                    winner = "X";

                MessageBox.Show(winner + " is a winner","Hooray");
            }//end if
            else
            {
                if (cout_turn == 9)
                    MessageBox.Show("Congratulations,There is a Draw","Crap");
            }
        }//end checkCurrentWinner
        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }//end foreach
            }//try,  we navigating that , because menu strip is not a button
            catch { }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            cout_turn = 0;
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }//end foreach
            }//try,  we navigating that , because menu strip is not a button
            catch { }
        }
    }
}
