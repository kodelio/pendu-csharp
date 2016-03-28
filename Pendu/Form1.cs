using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pendu_GERMAN_TOSON;

namespace Pendu_GERMAN_TOSON
{
    public partial class Form1 : Form
    {
        private Pendu pendu;
        private Boolean endGame;

        public Form1(Pendu pendu)
        {
            this.pendu = pendu;
            InitializeComponent();
            textBox1.Text = "Nouvelle partie, mot mystère = " + pendu.mot + "\r\n";
            label1.Text = pendu.motMystere;
            endGame = false;
            pictureBox1.ImageLocation = @"..\..\..\images\0.bmp";
        }

        private void lettreBouton(object sender, EventArgs e)
        {
            if (!endGame) { 
                var btn = sender as Button;
                pendu.TesteLettre(btn.Text[0]);
                textBox1.Text += "Le joueur a entré la lettre : " + btn.Text[0] + ", Coups Restants : " + pendu.coupsRestants + "\r\n";
                label1.Text = pendu.motMystere;
                pictureBox1.ImageLocation = @"..\..\..\images\" + (7-pendu.coupsRestants).ToString() + ".bmp";
                if (pendu.mot.Equals(pendu.motMystere))
                {
                    textBox1.Text += "Partie gagnée !";
                    MessageBox.Show("Partie gagnée"); 
                    endGame = true;
                }
                else if (pendu.coupsRestants == 0)
                {
                    label1.Text = pendu.mot;
                    MessageBox.Show("Partie perdue, le mot était : " + pendu.mot);
                    textBox1.Text += "Partie perdue, le mot était : " + pendu.mot;
                }
            }
            textBox1.SelectionStart = textBox1.TextLength;
            textBox1.ScrollToCaret();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pendu = new Pendu();
            textBox1.Text = "Nouvelle partie, mot mystère = " + pendu.mot + "\r\n";
            label1.Text = pendu.motMystere;
            endGame = false;
            pictureBox1.ImageLocation = @"..\..\..\images\0.bmp";
        }
    }
}
