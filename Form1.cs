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
    /// <summary>
    /// Klasa , która zawiera wszystkie metody które są realizowane w programie.
    /// </summary>
    public partial class Form1 : Form
    {
       public bool current_winner;
       public bool turn = true; 
       public bool against_computer = false;
       public int cout_turn = 0;
        static String firstplayer, secondplayer;
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Funkcja umożliwia wpisanie nazwy jednego lub dwóch graczy.
        /// </summary>
        /// <param name="n1">Pierwszy gracz.</param>
        /// <param name="n2">Drugi gracz.</param>
        public static void setPlayerNames(String n1, String n2)
        {
            firstplayer = n1;
            secondplayer = n2; 
        }
        /// <summary>
        /// Funkcja wyświetła informację o twórcach aplikacji po naciśnięciu przycisku About.
        /// </summary>
        /// <param name="sender">Parametr , który odwoluje się do obiektu.</param>
        /// <param name="e">Parametr zawierający informację o wydarzeniu(wyświetlienie informacji).</param>
        public void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is project created by Serhii Chernov and Maciej Wosko","Tic Tac Toe About");
        }
        /// <summary>
        /// Funkcja umożliwiająca wyjście z gry po naciśnięciu przycisku Exit Game. 
        /// </summary>
        /// <param name="sender">Parametr , który odwoluje się do obiektu.</param>
        /// <param name="e">Parametr zawierający informację o wydarzeniu(wyświetlienie informacji).</param>
        public void exitGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Funkcja umożliwiająca wstawienie znaku "X" lub "O", po naciśnięciu przycisku, dodatkowo uniemożliwia ponowne naciśnięcie przycisku, w którym został już wstawiony symbol.
        /// Jeżeli wybierzemy gre z komputerem i skonczyliśmy turę to nastąpi tura komputera.
        /// </summary>
        public void button_click(object sender, EventArgs e)
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
        /// <summary>
        /// Funkcja sprawia , że komputer sprawdza czy gracz może wygrać w następnej turze , jeśli może wygrać to blokuje mu wygraną poprzez wstawienie swojego symbolu.
        /// Jeżeli gracz ustawi swój symbol w rogu to komputer również ustawi swój symbol w dowolnym pustym rogu.
        /// </summary>
        public void computer_Turn()
        {
          Button move = null;
            
            move = checkWinBlock("O");
            if (move == null)
            {
                move = checkWinBlock("X");
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
        /// <summary>
        /// Metoda sprawia , że komputer szuka wolnego miejsca by wstawić swój symbol.
        /// </summary>
        /// <returns>b jeżeli znajdzie wolne miejsce , w przeciwnym razie zwróci wartość null.</returns>
        public Button checkFreeSpace()
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
        /// <summary>
        /// Metoda sprawdza dostępność pól znajdujących się po rogach .
        /// </summary>
        /// <returns>button jeżeli występuje puste miejsce, w przeciwnym razie zwróci wartość null.</returns>
        public Button checkCorner()
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
        /// <summary>
        /// Sprawdzenie czy użytkownik zaznaczył swój symbol w danym polu , komputer analizuje te pola ,aby zablokować gracza.
        /// </summary>
        /// <param name="mark">Przycisk ktory został zajęty przez symbol.</param>
        /// <returns>button jeżeli komputer może zablokować gracza, w przeciwnym razie zwróci wartość null.</returns>
        public Button checkWinBlock(string mark)
        {
            Console.WriteLine("Checking win or block:  " + mark);
            
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
        /// <summary>
        /// Funkcja sprawdza kto wygrał daną rundę lub weryfikuje czy zaistniał remis.
        /// </summary>
        public void checkCurrentWinner()
        {
            current_winner = false;
            
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
            }
            else
            {
                if (cout_turn == 9)
                {
                    draw_result.Text = (Int32.Parse(draw_result.Text) + 1).ToString();
                    MessageBox.Show("Congratulations,There is a Draw", "Crap");
                    newGameToolStripMenuItem.PerformClick();
                }
            }
        }
        /// <summary>
        /// Funkcja naprawiająca wykrywanie przycisków z Menu jako przyciski ,w których możemy wstawiać nasz symbol. 
        /// </summary>
        public void disableButtons()
        {
                foreach (Control c in Controls)
                {
                    try
                    {
                        Button b = (Button)c;
                        b.Enabled = false;
                    }
                    catch { }
                }
            
            
        }
        /// <summary>
        /// Funkcja umożliwia nam po kliknięciu przycisku "New Game" przejść do nowej gry. 
        /// </summary>
        public void newGameToolStripMenuItem_Click(object sender, EventArgs e)
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
                }
          
           
        }
        /// <summary>
        /// Funkcja sygnalizuje nam możliwość wstawienie naszego symbolu poprzez podświetlenie pustego pola. 
        /// </summary>
        public void button_Enter(object sender, EventArgs e)
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
        /// <summary>
        /// Funkcja kasuje podświetlenie pustego miejsca, po wyjechaniu kursorem za jego obszar.  
        /// </summary>
        public void button_Leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if(b.Enabled)
            {
                b.Text = "";
            }
        }
        /// <summary>
        /// Funkcja umożliwia zresetowania statystyk poprzez naciśnięcie przycisku "Reset Results".
        /// </summary>
        public void resetResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x_result.Text = "0";
            o_result.Text = "0";
            draw_result.Text = "0";
        }
        /// <summary>
        /// Funkcja umożliwia wyświetlenie ekranu wyboru przeciwnika.
        /// </summary>
        public void Form1_Load(object sender, EventArgs e)
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
