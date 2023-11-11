using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SentenceScrambler
{
	public partial class Form1 : Form
	{
		public int passes = 1;
		public Form1()
		{
			InitializeComponent();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e) //1
		{
			toolStripMenuItem3.CheckState = CheckState.Unchecked;
			toolStripMenuItem4.CheckState = CheckState.Unchecked;
			toolStripMenuItem2.CheckState = CheckState.Checked;
			passes = 1;
		}

		private void toolStripMenuItem3_Click(object sender, EventArgs e) //2
		{
			toolStripMenuItem2.CheckState = CheckState.Unchecked;
			toolStripMenuItem4.CheckState = CheckState.Unchecked;
			toolStripMenuItem3.CheckState = CheckState.Checked;
			passes = 2;
		}
		private void toolStripMenuItem4_Click(object sender, EventArgs e) //3
		{
			toolStripMenuItem3.CheckState = CheckState.Unchecked;
			toolStripMenuItem2.CheckState = CheckState.Unchecked;
			toolStripMenuItem4.CheckState = CheckState.Checked;
			passes = 3;
		}

        private void button1_Click(object sender, EventArgs e)
        {
			if (textBox1.Text == "" || textBox1.Text == null)
			{
				MessageBox.Show("Input is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
                return;
			}
			Random rnd = new Random();
			string sentence = textBox1.Text;
			sentence = sentence.Trim('.').Trim('?').Trim('!').Trim('¡').Trim('¿');
            if (sentence == "" || sentence == null)
            {
                MessageBox.Show("Input is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				textBox1.Text = "";
                return;
            }
            string[] words = sentence.Split(' ');
			string newSentence = "";
			for (int i = passes; i > 0; i--) rnd.Shuffle(words);
			foreach (string word in words) newSentence = newSentence + " " + word;

            textBox2.Text = newSentence;
        }

        private void theUseIsObviousIsntItToolStripMenuItem_Click(object sender, EventArgs e)
        {
			MessageBox.Show("Whatever.\n\nYou input a text, press the button and the program will randomize the order of the words.", ":3", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    static class RandomizeOrder
    {
        public static void Shuffle<T>(this Random rng, T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }
}