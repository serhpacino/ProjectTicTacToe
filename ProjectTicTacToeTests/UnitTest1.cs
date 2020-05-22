using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectTicTacToe;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTicTacToeTests
{
    [TestClass]
    public class UnitTest1
    {
        ProjectTicTacToe.Form2 form2 = new ProjectTicTacToe.Form2();
        ProjectTicTacToe.Form1 form1 = new ProjectTicTacToe.Form1();
        [TestMethod]
        public void PlayAgainstComputerClickTest()
        {
            var expected = "Computer";
            form2.button2_Click(null, null);
            form1.Form1_Load(null, null);
            var result = form1.label2.Text;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void CheckingIsPlayerPlayAgainstComputer()
        {
            form2.button2_Click(null, null);
            form1.Form1_Load(null, null);
            Assert.IsTrue(form1.against_computer);
        }
        [TestMethod]
        public void button_Click_Test()
        {


            form1.Form1_Load(null, null);
            form1.button_click(form1.button1, null);

            Assert.AreEqual("X", form1.button1.Text);
        }

        [TestMethod]
        public void checkFreeSpaceTest()
        {
            form1.button_click(form1.button1, null);

            form1.computer_Turn();

            Assert.IsNotNull(form1.checkFreeSpace());
        }
        [TestMethod]
        public void checkCornerTest()
        {
            form1.button1.Text = "X";
            form1.button2.Text = "O";
            form1.button3.Text = "X";
            form1.button4.Text = "X";
            form1.button5.Text = "O";
            form1.button6.Text = "X";
            form1.button7.Text = "X";
            form1.button8.Text = "O";
            form1.button9.Text = "X";
            form1.checkCorner();
            Assert.IsNull(form1.checkCorner());
        }
        [TestMethod]
        public void checkWinBlockHorizntalTest()
        {
            var expected = "X";
            form1.button1.Text = "X";
            form1.button2.Text = "X";

            form1.checkWinBlock(expected);
            Assert.AreEqual(form1.button3, form1.checkWinBlock(expected));
        }
        [TestMethod]
        public void checkWinBlockVerticalTest()
        {
            var expected = "X";
            form1.button2.Text = "X";
            form1.button5.Text = "X";

            form1.checkWinBlock(expected);
            Assert.AreEqual(form1.button8, form1.checkWinBlock(expected));
        }
        [TestMethod]
        public void checkWinBlockDiagonalTest()
        {
            var expected = "X";
            form1.button1.Text = "X";
            form1.button5.Text = "X";

            form1.checkWinBlock(expected);
            Assert.AreEqual(form1.button9, form1.checkWinBlock(expected));
        }
        [TestMethod]
        public void checkCurrentWinnerHorizontalTest()
        {

            form1.button1.Text = form1.button2.Text;
            form1.button2.Text = form1.button3.Text;
            form1.button1.Enabled = false;
            form1.checkCurrentWinner();
            Assert.AreEqual(true, form1.current_winner);
        }
        [TestMethod]
        public void checkCurrentWinnerVerticalTest()
        {

            form1.button2.Text = form1.button5.Text;
            form1.button5.Text = form1.button8.Text;
            form1.button2.Enabled = false;
            form1.checkCurrentWinner();
            Assert.AreEqual(true, form1.current_winner);
        }
        [TestMethod]
        public void checkCurrentWinnerDiagonalTest()
        {

            form1.button1.Text = form1.button5.Text;
            form1.button5.Text = form1.button9.Text;
            form1.button1.Enabled = false;
            form1.checkCurrentWinner();
            Assert.AreEqual(true, form1.current_winner);
        }
        [TestMethod]
        public void checkCurrentWinnerDrawTest()
        {
            form1.draw_result.Text = "0";
            form1.current_winner = false;
            form1.cout_turn = 9;
            form1.checkCurrentWinner();
            Assert.AreEqual("1", form1.draw_result.Text);
        }
        [TestMethod]
        public void disableButtonsTest()
        {
            form1.button1.Enabled = true;
            form1.disableButtons();
            Assert.IsFalse(form1.button1.Enabled);

        }
        [TestMethod]
        public void newGameToolStripMenuItem_ClickTest()
        {
            var expected = "";
            form1.newGameToolStripMenuItem_Click(form1.newGameToolStripMenuItem, null);
            foreach (Control c in form1.Controls)
            {
                try
                {
                    Button b = (Button)c;
                    Assert.IsTrue( b.Enabled);
                    Assert.AreEqual(expected,b.Text);
                }
                catch { }
            }
        }
        [TestMethod]
        public void resetResultsToolStripMenuItem_ClickTest()
        {
            var expected = "0";
            form1.x_result.Text = "1";
            form1.o_result.Text = "2";
            form1.draw_result.Text = "3";
            form1.resetResultsToolStripMenuItem_Click(form1.resetResultsToolStripMenuItem,null);
            Assert.AreEqual(expected, form1.x_result.Text, form1.o_result.Text, form1.draw_result.Text);
        }
    }
}
