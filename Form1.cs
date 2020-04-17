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
        bool against_computer = false;
        int cout_turn = 0;
        static String firstplayer, secondplayer;
        public Form1()
        {
            InitializeComponent();
        }

        public static void setPlayerNames(String n1, String n2)
        {
            firstplayer = n1;
            secondplayer = n2; 
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
                    b.Text = "X";
                else
                    b.Text = "O";

                turn = !turn;
                b.Enabled = false;
                cout_turn++;
                checkCurrentWinner();
            

            if((!turn)&&(against_computer))
            {
                computer_Turn();
            }
        }

        private void computer_Turn()
        {
            Button move = null;
            //Tic tac toe opportunities
            move = checkWinBlock("O");//Look for win
            if (move == null)
            {
                move = checkWinBlock("X");//Look for blocking
                if (move == null)
                {
                    move = checkCorner();
                    if (move == null)
                    {
                        move = checkFreeSpace();
                    }
                }
            }
            move.PerformClick();
        }

        private Button checkFreeSpace()
        {
            Console.WriteLine("Checking free space");
            Button b = null;
            foreach (Control c in Controls)
            {
                b = c as Button;
                if(b!= null)
                {
                    if (b.Text == "")
                        return b;
                }
            }
            return null;
        }

        private Button checkCorner()
        {
            Console.WriteLine("Checking corner");
            if (button1.Text == "O")
            {
                if (button3.Text == "")
                    return button3;
                if (button9.Text == "")
                    return button9;
                if (button7.Text == "")
                    return button7;
            }

            if (button3.Text == "O")
            {
                if (button1.Text == "")
                    return button1;
                if (button9.Text == "")
                    return button9;
                if (button7.Text == "")
                    return button7;
            }

            if (button7.Text == "O")
            {
                if (button1.Text == "")
                    return button3;
                if (button3.Text == "")
                    return button3;
                if (button7.Text == "")
                    return button7;
            }

            if (button7.Text == "O")
            {
                if (button1.Text == "")
                    return button3;
                if (button3.Text == "")
                    return button3;
                if (button9.Text == "")
                    return button9;
            }

            if (button1.Text == "")
                return button1;
            if (button3.Text == "")
                return button3;
            if (button7.Text == "")
                return button7;
            if (button9.Text == "")
                return button9;

            return null;
        }

        private Button checkWinBlock(string mark)
        {
            Console.WriteLine("Checking win or block:  " + mark);
            //Horizontal
            if ((button1.Text == mark) && (button2.Text == mark) && (button3.Text == ""))
                return button3;
            if ((button2.Text == mark) && (button3.Text == mark) && (button1.Text == ""))
                return button1;
            if ((button1.Text == mark) && (button3.Text == mark) && (button2.Text == ""))
                return button2;

            if ((button4.Text == mark) && (button5.Text == mark) && (button6.Text == ""))
                return button6;
            if ((button5.Text == mark) && (button6.Text == mark) && (button4.Text == ""))
                return button4;
            if ((button4.Text == mark) && (button6.Text == mark) && (button5.Text == ""))
                return button5;

            if ((button7.Text == mark) && (button8.Text == mark) && (button9.Text == ""))
                return button9;
            if ((button8.Text == mark) && (button9.Text == mark) && (button7.Text == ""))
                return button7;
            if ((button7.Text == mark) && (button9.Text == mark) && (button8.Text == ""))
                return button8;

            //Vertical
            if ((button1.Text == mark) && (button4.Text == mark) && (button7.Text == ""))
                return button7;
            if ((button4.Text == mark) && (button7.Text == mark) && (button1.Text == ""))
                return button1;
            if ((button1.Text == mark) && (button7.Text == mark) && (button4.Text == ""))
                return button4;

            if ((button2.Text == mark) && (button5.Text == mark) && (button8.Text == ""))
                return button8;
            if ((button5.Text == mark) && (button8.Text == mark) && (button2.Text == ""))
                return button2;
            if ((button2.Text == mark) && (button8.Text == mark) && (button5.Text == ""))
                return button5;

            if ((button3.Text == mark) && (button6.Text == mark) && (button9.Text == ""))
                return button9;
            if ((button6.Text == mark) && (button9.Text == mark) && (button3.Text == ""))
                return button3;
            if ((button3.Text == mark) && (button9.Text == mark) && (button6.Text == ""))
                return button6;

            //Diagonal
            if ((button1.Text == mark) && (button5.Text == mark) && (button9.Text == ""))
                return button9;
            if ((button5.Text == mark) && (button9.Text == mark) && (button1.Text == ""))
                return button1;
            if ((button1.Text == mark) && (button9.Text == mark) && (button5.Text == ""))
                return button5;

            if ((button3.Text == mark) && (button5.Text == mark) && (button7.Text == ""))
                return button7;
            if ((button5.Text == mark) && (button7.Text == mark) && (button3.Text == ""))
                return button3;
            if ((button3.Text == mark) && (button7.Text == mark) && (button5.Text == ""))
                return button5;

            return null;
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
                {
                    winner = secondplayer;
                    o_result.Text = (Int32.Parse(o_result.Text) + 1).ToString();
                }
                else
                {
                    winner = firstplayer;
                    x_result.Text = (Int32.Parse(x_result.Text) + 1).ToString();
                }

                MessageBox.Show(winner + " wins","Hooray");
            }//end if
            else
            {
                if (cout_turn == 9)
                {
                    draw_result.Text = (Int32.Parse(draw_result.Text) + 1).ToString();
                    MessageBox.Show("Congratulations,There is a Draw", "Crap");
                    newGameToolStripMenuItem.PerformClick();
                }
            }
        }//end checkCurrentWinner
        private void disableButtons()
        {
                foreach (Control c in Controls)
                {
                    try
                    {
                        Button b = (Button)c;
                        b.Enabled = false;
                    }
                    catch { }
                }//end foreach
            //try,  we navigating that , because menu strip is not a button
            
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            cout_turn = 0;
                foreach (Control c in Controls)
                {
                    try
                    {
                        Button b = (Button)c;
                        b.Enabled = true;
                        b.Text = "";
                    }
                    catch { }
                }//end foreach
            //try,  we navigating that , because menu strip is not a button
           
        }

        private void button_Enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)
                    b.Text = "X";
                else
                    b.Text = "O";
            }
        }

        private void button_Leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if(b.Enabled)
            {
                b.Text = "";
            }
        }

        private void resetResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x_result.Text = "0";
            o_result.Text = "0";
            draw_result.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form f2 = new Form2();
            f2.ShowDialog();
            label1.Text = firstplayer;
            label2.Text = secondplayer;
            if (label2.Text == "Computer")
            {
                against_computer = true;
            }
            else
            {
                against_computer = false;
            }
        }

         
        
    }
}
