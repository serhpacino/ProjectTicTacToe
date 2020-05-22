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
    /// Klasa reprezentująca okno wyboru przeciwnika. 
    /// </summary>
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void Form2_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Funkcja umożliwia zmianę nazwy gracza lub obu graczy. 
        /// </summary>
        public void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") && (textBox2.Text == ""))
            {
                Form1.setPlayerNames("Player 1", "Player 2");
                this.Close();
            }
            else
            {
                Form1.setPlayerNames(textBox1.Text, textBox2.Text);
                this.Close();
            }
        }
        /// <summary>
        /// Funkcja umożliwia nam zagranie z komputerem.
        /// </summary>
        public void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                Form1.setPlayerNames("Player", "Computer");
                this.Close();
            }
            else
            {
                Form1.setPlayerNames(textBox1.Text, "Computer");
                this.Close();
            }
        }
    }
}
