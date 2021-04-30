using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Meks
{
    public partial class Playfair : Form
    {

        char[] alpha;
        string text = "";
        char[,] matrix = new char[5, 5];
        int f = 0;
        int pos1 = 0;
        int pos2 = 0;
        int pos3 = 0;
        int pos4 = 0;
        string lol = null;
        int miko = 0;
        int mike = 0;
        int h = 0;

        string answer = "";
        public Playfair()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //encrypt
            richTextBox4.Text = "";
            answer = "";
            lol = null;
            miko = 0;
            mike = 0;
            h = 0;

            string m = richTextBox1.Text.ToUpper();
            m.Replace(" ", string.Empty);
            for (int i = 0; i < m.Length; i++)
            {
                if (m[i] != ' ')
                {
                    if (i + 1 < m.Length)
                    {
                        if (m[i] == m[i + 1])
                        {
                            text += m[i];
                            text += 'X';
                        }
                        else
                        {
                            text += m[i];
                            text += m[i + 1];
                            i++;
                        }
                    }
                    else
                    {
                        text += m[i];
                        text += 'X';
                    }
                }
            }
            if (richTextBox3.Text != null)
            {
                lol = richTextBox3.Text.ToUpper();
                if ((lol.Contains('i') || lol.Contains('j')))
                {
                    alpha = "ABCDEFGHKLMNOPQRSTUVWXYZ".ToCharArray();
                }
                else
                {
                    alpha = "ABCDEFGHIKLMNOPQRSTUVWXYZ".ToCharArray();

                }

                for (int i = 0; i < 5; i++)
                {

                    for (int k = 0; k < 5; k++)
                    {
                        if (h < lol.Length)
                        {
                            matrix[mike, miko] = lol[h];
                            h++;
                        }
                        else
                        {
                            for (int q = f; q < alpha.Length; q++)
                            {
                                if (!lol.Contains(alpha[q]))
                                {
                                    matrix[mike, miko] = alpha[q];
                                    f++;
                                    break;
                                }
                                else
                                {
                                    f++;
                                }
                            }
                        }
                        miko++;
                    }
                    miko = 0;
                    mike++;
                }

            }
            else
            {
                MessageBox.Show("Error Enter KeyWord!!");
            }

            for (int q = 0; q < text.Length; q += 2)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        if (text[q] != 'j' && text[q] != 'J')
                        {
                            if (matrix[i, k] == text[q])
                            {
                                pos1 = i;
                                pos2 = k;

                            }
                        }
                        else
                        {
                            if (matrix[i, k] == 'I')
                            {
                                pos1 = i;
                                pos2 = k;

                            }
                        }
                        if (text[q + 1] != 'j' && text[q + 1] != 'J')
                        {
                            if (matrix[i, k] == text[q + 1])
                            {
                                pos3 = i;
                                pos4 = k;

                            }
                        }
                        else
                        {
                            if (matrix[i, k] == 'I')
                            {
                                pos1 = i;
                                pos2 = k;

                            }
                        }
                    }

                }
                if (pos1 == pos3)
                {
                    if (pos2 + 1 < 5)
                    {
                        answer += matrix[pos1, pos2 + 1];
                    }
                    else
                    {
                        answer += matrix[pos1, 0];
                    }

                    if (pos4 + 1 < 5)
                    {
                        answer += matrix[pos3, pos4 + 1];
                    }
                    else
                    {
                        answer += matrix[pos3, 0];
                    }
                }
                else if (pos2 == pos4)
                {
                    if (pos1 + 1 < 5)
                    {
                        answer += matrix[pos1 + 1, pos2];
                    }
                    else
                    {
                        answer += matrix[0, pos2];
                    }

                    if (pos3 + 1 < 5)
                    {
                        answer += matrix[pos3 + 1, pos4];
                    }
                    else
                    {
                        answer += matrix[0, pos4];
                    }

                }
                else
                {
                    answer += matrix[pos1, pos4];
                    answer += matrix[pos3, pos2];
                }
            }
            richTextBox4.Text = answer;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //decrypt
            answer = "";
            richTextBox4.Text = "";
            lol = null;
            miko = 0;
            mike = 0;
            h = 0;
            string fo = "";

            string text = richTextBox2.Text.ToUpper();


            if (richTextBox3.Text != null)
            {

                lol = richTextBox3.Text.ToUpper();
                if ((lol.Contains('i') || lol.Contains('j')))
                {
                    alpha = "ABCDEFGHKLMNOPQRSTUVWXYZ".ToCharArray();
                }
                else
                {
                    alpha = "ABCDEFGHIKLMNOPQRSTUVWXYZ".ToCharArray();

                }

                for (int i = 0; i < 5; i++)
                {

                    for (int k = 0; k < 5; k++)
                    {
                        if (h < lol.Length)
                        {
                            matrix[mike, miko] = lol[h];
                            h++;
                        }
                        else
                        {
                            for (int q = f; q < alpha.Length; q++)
                            {
                                if (!lol.Contains(alpha[q]))
                                {
                                    matrix[mike, miko] = alpha[q];
                                    f++;
                                    break;
                                }
                                else
                                {
                                    f++;
                                }
                            }
                        }
                        miko++;
                    }
                    miko = 0;
                    mike++;
                }

            }
            else
            {
                MessageBox.Show("Error Enter KeyWord!!");
            }
            for (int q = 0; q < text.Length; q += 2)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        if (matrix[i, k] == text[q])
                        {
                            pos1 = i;
                            pos2 = k;

                        }
                        if (matrix[i, k] == text[q + 1])
                        {
                            pos3 = i;
                            pos4 = k;

                        }
                    }

                }
                if (pos1 == pos3)
                {
                    if (pos2 - 1 >= 0)
                    {
                        answer += matrix[pos1, pos2 - 1];
                    }
                    else
                    {
                        answer += matrix[pos1, 4];
                    }

                    if (pos4 - 1 >= 0)
                    {
                        answer += matrix[pos3, pos4 - 1];
                    }
                    else
                    {
                        answer += matrix[pos3, 4];
                    }
                }
                else if (pos2 == pos4)
                {
                    if (pos1 - 1 >= 0)
                    {
                        answer += matrix[pos1 - 1, pos2];
                    }
                    else
                    {
                        answer += matrix[4, pos2];
                    }

                    if (pos3 - 1 >= 0)
                    {
                        answer += matrix[pos3 - 1, pos4];
                    }
                    else
                    {
                        answer += matrix[4, pos4];
                    }

                }
                else
                {
                    answer += matrix[pos1, pos4];
                    answer += matrix[pos3, pos2];
                }
            }
            for (int i = 0; i < answer.Length; i++)
            {
                if (answer[i] == 'X')
                {
                    if (i + 1 < answer.Length && i > 1)
                    {

                        if (answer[i - 1] != answer[i + 1])
                        {
                            fo += answer[i];
                        }
                    }
                    else
                    {
                        if (i + 1 < answer.Length)
                        {
                            fo += answer[i];
                        }
                    }
                }
                else
                {
                    fo += answer[i];
                }

            }

            richTextBox4.Text = fo;
        }
    }
}
