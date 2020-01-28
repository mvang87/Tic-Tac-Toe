using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Tic_Tac_Toe : Form
    {
        bool turn = true;
        int turn_count = 0;

        public Tic_Tac_Toe()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by Mark Vang\n\nThis is my first Windows C# Application", "Tic Tac Toe About");
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
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
            turn_count++;

            CheckForWinner();
        }

        private void CheckForWinner()
        {
            bool Winner = false;

            //Horizontial
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                Winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                Winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                Winner = true;
            //Vertical Check
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                Winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                Winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                Winner = true;
            //Diagonal
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                Winner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                Winner = true;

            if (Winner)
            {
                disablebuttons();
                {
                    String Win = "";
                    if (turn)
                        Win = "O";
                    else
                        Win = "X";
                    MessageBox.Show("Player " + Win + " Wins!", "Winner Winner Chicken Dinner!");
                }
            }
            else
            {
                if (turn_count == 9)
                    MessageBox.Show("This game resulted in a Draw!", "Draw");
            }
        }   

        private void disablebuttons()
        {
            try
            {
                foreach (Control b in Controls)
                {
                    Button e = (Button)b;
                    e.Enabled = false;
                }
            }
            catch { }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch { }
        }
    }
}
