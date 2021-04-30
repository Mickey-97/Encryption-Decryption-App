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
    public partial class Saes : Form
    {
        string key;
        string[] smallkeys = new string[3];
        string[] input = new string[4];
        string[] cipher = new string[4];
        string[] ws = new string[6];
        string[] w_refrence = new string[] { "10000000", "00110000" };
        string[] sbox = new string[] { "1001", "0100", "1010", "1011", "1101", "0001", "1000", "0101", "0110", "0010", "0000", "0011", "1100", "1110", "1111", "0111" };
        string[] nibble = new string[] { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111" };
        string[] addition = new string[] { "0123456789abcdef", "1032547698badcfe", "23016745ab89efcd", "32107654ba98fedc", "45670123cdef89ab", "54761032dcfe98ba", "67452301efcdab89", "76543210fedcba98", "89abcdef01234567", "98badcfe10325476", "ab89efcd23016745", "ba98fedc32107654", "cdef89ab45670123", "dcfe98ba54761032", "efcdab8967452301", "fedcba9876543210" };
        string[] multiblication = new string[] { "0000000000000000", "0123456789abcdef", "02468ace3175b9fd", "0365cfa9b8de7412", "048c37bf62ea51d9", "05af72d8eb419c36", "06cabd71539fe824", "07e9f816da3425cb", "083b6e5dc4f7a291", "09182b3a4d5c6f7e", "0a7de493f5821b6c", "0b5ea1f47c29d683", "0cb759e2a61df348", "0d941c852fb63ea7", "0ef1d32c97684ab5", "0fd2964b1ec3875a" };
        public Saes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        string toChar(int n)
        {
            const string alpha = "0123456789ABCDEF";
            return alpha.Substring(n, 1);
        }

        string convert_to_decimal(string n)
        {
            int Index = 0;
            int Decimal = 0;
            foreach (char Char in n.Reverse())
            {
                if (Index != 0)
                {
                    Decimal += Index * 2 * Convert.ToInt32(Char.ToString());
                    Index = Index * 2;
                }
                else
                {
                    Decimal += Convert.ToInt32(Char.ToString());
                    Index++;
                }
            }
            return Decimal.ToString();
        }

        string convert_to_hex(int d)
        {
            string answer = "";
            var r = d % 16;
            if (d - r == 0)
            {
                answer = toChar(Convert.ToInt32(r));
            }
            else
            {
                answer = convert_to_hex((d - r) / 16) + toChar(Convert.ToInt32(r));
            }
            return answer;
        }

        string convert_to_binary(string hexvalue)
        {
            string answer = "";
            answer = Convert.ToString(Convert.ToInt32(hexvalue, 16), 2);
            return answer;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            int k = 0;
            int j = 0;
            foreach (char c in richTextBox1.Text)
            {
                if (j == 4)
                {
                    k++;
                    j = 0;
                }
                input[k] += c;
                j++;
            }
            key = richTextBox3.Text;
            //============================================================
            //generate keys
            for (int i = 0; i < 8; i++)
            {
                ws[0] += key[i];
                ws[1] += key[i + 8];
            }
            j = 0;
            for (int i = 2; i < 6; i++)
            {
                if (i % 2 == 0)
                {
                    string temp1 = "", temp2 = "", temp3 = "";
                    for (int q = 0; q < ws[i - 2].Length; q++)
                    {
                        if (ws[i - 2][q] == w_refrence[j][q])
                        {
                            temp1 += "0";
                        }
                        else
                        {
                            temp1 += "1";
                        }
                    }
                    string temp = "";
                    for (int q = 0; q < ws[i - 1].Length / 2; q++)
                    {
                        temp2 += ws[i - 1][q + (ws[i - 1].Length / 2)];
                        temp += ws[i - 1][q];
                    }
                    temp2 += temp;
                    string t = "";
                    for (int z = 0; z < temp2.Length; z++)
                    {
                        if (z == temp2.Length / 2)
                        {
                            for (int q = 0; q < nibble.Length; q++)
                            {
                                if (t == nibble[q])
                                {
                                    temp3 += sbox[q];
                                }
                            }
                            t = "";
                        }
                        t += temp2[z];
                    }
                    for (int q = 0; q < nibble.Length; q++)
                    {
                        if (t == nibble[q])
                        {
                            temp3 += sbox[q];
                        }
                    }
                    for (int q = 0; q < temp3.Length; q++)
                    {
                        if (temp1[q] == temp3[q])
                        {
                            ws[i] += "0";
                        }
                        else
                        {
                            ws[i] += "1";
                        }
                    }
                    j++;
                }
                else
                {
                    for (int q = 0; q < ws[i - 1].Length; q++)
                    {
                        if (ws[i - 1][q] == ws[i - 2][q])
                        {
                            ws[i] += "0";
                        }
                        else
                        {
                            ws[i] += "1";
                        }
                    }
                }
            }
            //===========================================================================
            int f = 0;
            for (int i = 0; i < 3; i++)
            {
                smallkeys[i] = ws[i + f] + ws[i + f + 1];
                f++;
            }
            //===========================================================================
            //encryption
            string[] working = new string[4];
            f = 0;
            for (int q = 0; q < 4; q++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (input[q][i] == smallkeys[0][f])
                    {
                        working[q] += "0";
                    }
                    else
                    {
                        working[q] += "1";
                    }
                    f++;
                }
            }
            //================================================================================
            string tt = "";
            //subnib
            for (int q = 0; q < 4; q++)
            {
                for (int i = 0; i < nibble.Length; i++)
                {
                    if (working[q] == nibble[i])
                    {
                        working[q] = sbox[i];
                        break;
                    }
                }
            }
            //swapping
            tt = working[1];
            working[1] = working[3];
            working[3] = tt;
            tt = "";
            //mix Columns
            for (int q = 0; q < 4; q += 2)
            {
                string tt1 = working[q];
                string tt2 = working[q + 1];
                for (int p = 0; p < 2; p++)
                {
                    string one = "";
                    string two = "";
                    string m1;
                    string m2;
                    if (p == 0)
                    {
                        m1 = "1";
                        m2 = "4";
                    }
                    else
                    {
                        m1 = "4";
                        m2 = "1";
                    }
                    one = convert_to_hex(Convert.ToInt32(convert_to_decimal(tt1)));
                    two = convert_to_hex(Convert.ToInt32(convert_to_decimal(tt2)));
                    for (int i = 0; i < 16; i++)
                    {
                        if (multiblication[i][1].ToString().ToLower() == one.ToLower())
                        {
                            for (int z = 0; z < 16; z++)
                            {
                                if (multiblication[1][z].ToString().ToLower() == m1.ToLower())
                                {
                                    one = multiblication[i][z].ToString().ToLower();
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    for (int i = 0; i < 16; i++)
                    {
                        if (multiblication[i][1].ToString().ToLower() == two.ToLower())
                        {
                            for (int z = 0; z < 16; z++)
                            {
                                if (multiblication[1][z].ToString().ToLower() == m2.ToLower())
                                {
                                    two = multiblication[i][z].ToString().ToLower();
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    //=============================================================================================
                    for (int i = 0; i < 16; i++)
                    {
                        if (addition[i][0].ToString().ToLower() == one.ToLower())
                        {
                            for (int z = 0; z < 16; z++)
                            {
                                if (addition[0][z].ToString().ToLower() == two.ToLower())
                                {
                                    one = addition[i][z].ToString().ToLower();
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    //==============================================================================================
                    tt = convert_to_binary(one);
                    string ans = "";
                    if (tt.Length < 4)
                    {
                        for (int i = 0; i < 4 - tt.Length; i++)
                        {
                            ans += "0";
                        }
                    }
                    ans += tt;
                    working[q + p] = ans;
                }
            }
            //adding k1
            f = 0;
            for (int q = 0; q < 4; q++)
            {
                tt = working[q];
                working[q] = "";
                for (int i = 0; i < 4; i++)
                {
                    if (tt[i] == smallkeys[1][f])
                    {
                        working[q] += "0";
                    }
                    else
                    {
                        working[q] += "1";
                    }
                    f++;
                }
            }
            //==========================================================================================================
            for (int q = 0; q < 4; q++)
            {
                for (int i = 0; i < nibble.Length; i++)
                {
                    if (working[q] == nibble[i])
                    {
                        working[q] = sbox[i];
                        break;
                    }
                }
            }
            //swap nibbles
            tt = working[1];
            working[1] = working[3];
            working[3] = tt;
            tt = "";
            //add k2
            f = 0;
            for (int q = 0; q < 4; q++)
            {
                tt = working[q];
                working[q] = "";
                for (int i = 0; i < 4; i++)
                {
                    if (tt[i] == smallkeys[2][f])
                    {
                        working[q] += "0";
                    }
                    else
                    {
                        working[q] += "1";
                    }
                    f++;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                cipher[i] = working[i];
                richTextBox2.Text += cipher[i];
            }
            MessageBox.Show(working[0] + "===" + working[1] + "===" + working[2] + "===" + working[3]);
            //==========================================================================================================
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
