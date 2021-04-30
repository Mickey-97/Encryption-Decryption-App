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
    public partial class sdes : Form
    {
        int[] input = new int[8];
        int[] ep = new int[] { 4, 1, 2, 3, 2, 3, 4, 1 };
        int[] p10 = new int[] { 3, 5, 2, 7, 4, 10, 1, 9, 8, 6 };




        private void sdes_Load(object sender, EventArgs e)
        {

        }
        int[] p4 = new int[] { 2, 4, 3, 1 };

        int[] ipn = new int[] { 4, 1, 3, 5, 7, 2, 8, 6 };

        int[,] s0 = new int[4, 4] { { 1, 0, 3, 2 }, { 3, 2, 1, 0 }, { 0, 2, 1, 3 }, { 3, 1, 3, 2 } };
        int[,] s1 = new int[4, 4] { { 0, 1, 2, 3 }, { 2, 0, 1, 3 }, { 3, 0, 1, 0 }, { 2, 1, 0, 3 } };
        string subkey2 = "";

        int[] ip = new int[] { 2, 6, 3, 1, 4, 8, 5, 7 };
        int[] mainkey = new int[10];
        string subkey1 = "";


        int[] p8 = new int[] { 6, 3, 7, 4, 8, 5, 10, 9 };
        public sdes()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string temp = richTextBox1.Text;
            string temp2 = textBox1.Text;
            int[] tempinput = new int[8];
            int[] tempkey = new int[10];
            int[] left = new int[4];
            int[] right = new int[4];
            int t1 = 0;
            for (int i = 0; i < temp2.Length; i++)
            {
                mainkey[i] = (int)char.GetNumericValue(temp2[i]);
            }
            for (int i = 0; i < p10.Length; i++)
            {
                tempkey[i] = mainkey[(p10[i] - 1)];
            }
            for (int i = 0; i < 5; i++)
            {
                if (i == 0)
                {
                    t1 = tempkey[0];
                }
                if (i < 4)
                {
                    tempkey[i] = tempkey[i + 1];
                }
                else
                {
                    tempkey[i] = t1;
                }
            }
            for (int i = 5; i < 10; i++)
            {
                if (i == 5)
                {
                    t1 = tempkey[i];
                }
                if (i < 9)
                {
                    tempkey[i] = tempkey[i + 1];
                }
                else
                {
                    tempkey[i] = t1;
                }
            }
            for (int i = 0; i < p8.Length; i++)
            {
                subkey1 += tempkey[(p8[i] - 1)].ToString();
            }
            for (int i = 0; i < 5; i++)
            {
                if (i == 0)
                {
                    t1 = tempkey[0];
                }
                if (i < 4)
                {
                    tempkey[i] = tempkey[i + 1];
                }
                else
                {
                    tempkey[i] = t1;
                }
            }
            for (int i = 5; i < 10; i++)
            {
                if (i == 5)
                {
                    t1 = tempkey[i];
                }
                if (i < 9)
                {
                    tempkey[i] = tempkey[i + 1];
                }
                else
                {
                    tempkey[i] = t1;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                if (i == 0)
                {
                    t1 = tempkey[0];
                }
                if (i < 4)
                {
                    tempkey[i] = tempkey[i + 1];
                }
                else
                {
                    tempkey[i] = t1;
                }
            }
            for (int i = 5; i < 10; i++)
            {
                if (i == 5)
                {
                    t1 = tempkey[i];
                }
                if (i < 9)
                {
                    tempkey[i] = tempkey[i + 1];
                }
                else
                {
                    tempkey[i] = t1;
                }
            }
            for (int i = 0; i < p8.Length; i++)
            {
                subkey2 += tempkey[(p8[i] - 1)].ToString();
            }
            //=============================================================
            for (int i = 0; i < temp.Length; i++)
            {
                input[i] = (int)char.GetNumericValue(temp[i]);
            }
            for (int i = 0; i < ip.Length; i++)
            {
                tempinput[i] = input[(ip[i] - 1)];
            }
            for (int i = 0; i < tempinput.Length / 2; i++)
            {
                left[i] = tempinput[i];
            }
            for (int i = tempinput.Length / 2; i < tempinput.Length; i++)
            {
                right[i - 4] = tempinput[i];
            }
            for (int z = 0; z < 2; z++)
            {
                string rightcopy = "";
                int binaryright = 0;
                int binarykey = 0;
                for (int i = 0; i < 8; i++)
                {
                    rightcopy += right[(ep[i] - 1)].ToString();
                }
                binaryright = Convert.ToInt32(rightcopy, 2);
                if (z == 0)
                {
                    binarykey = Convert.ToInt32(subkey1, 2);
                }
                else
                {
                    binarykey = Convert.ToInt32(subkey2, 2);
                }
                int result = binaryright ^ binarykey;
                string t = Convert.ToString(result, 2);
                if (t.Length != 8)
                {
                    while (true)
                    {
                        t = t.Insert(0, "0");
                        if (t.Length == 8)
                        {
                            break;
                        }
                    }
                }
                string tt = "";
                int[] sbox = new int[4];
                int row = 0, col = 0;

                for (int i = 0; i < 2; i++)
                {
                    tt = "";
                    if (i == 0)
                    {
                        tt += t[1];
                        tt += t[2];
                        row = Convert.ToInt32(tt, 2);
                        tt = "";
                        tt += t[0];
                        tt += t[3];
                        col = Convert.ToInt32(tt, 2);
                        tt = Convert.ToString(s0[row, col], 2);
                        if (tt == "0")
                        {
                            sbox[0] = 0;
                            sbox[1] = 0;
                        }
                        else if (tt == "1")
                        {
                            sbox[0] = 0;
                            sbox[1] = 1;
                        }
                        else
                        {
                            sbox[0] = (int)char.GetNumericValue(tt[0]);
                            sbox[1] = (int)char.GetNumericValue(tt[1]);
                        }
                    }
                    else
                    {
                        tt += t[5];
                        tt += t[6];
                        row = Convert.ToInt32(tt, 2);
                        tt = "";
                        tt += t[4];
                        tt += t[7];
                        col = Convert.ToInt32(tt, 2);
                        tt = Convert.ToString(s1[row, col], 2);
                        if (tt == "0")
                        {
                            sbox[2] = 0;
                            sbox[3] = 0;
                        }
                        else if (tt == "1")
                        {
                            sbox[2] = 1;
                            sbox[3] = 0;
                        }
                        else
                        {
                            sbox[2] = (int)char.GetNumericValue(tt[0]);
                            sbox[3] = (int)char.GetNumericValue(tt[1]);
                        }
                    }
                }
                int[] hamo = new int[4];
                int[] finalleft = new int[4];
                for (int i = 0; i < p4.Length; i++)
                {
                    hamo[i] = sbox[(p4[i] - 1)];
                }
                for (int i = 0; i < 4; i++)
                {
                    if (left[i] == hamo[i])
                    {
                        finalleft[i] = 0;
                    }
                    else
                    {
                        finalleft[i] = 1;
                    }
                }
                if (z == 0)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        left[i] = right[i];
                        right[i] = finalleft[i];
                    }
                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        tempinput[i] = finalleft[i];
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        tempinput[i + 4] = right[i];
                    }
                    int[] final = new int[8];
                    string toto = "";
                    for (int i = 0; i < ipn.Length; i++)
                    {
                        final[i] = tempinput[(ipn[i] - 1)];
                        toto += final[i];
                    }
                    richTextBox2.Text = toto;
                }
            }
            //========================================================
        }
    }
}
