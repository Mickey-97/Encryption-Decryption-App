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
    public partial class Rc4 : Form
    {
        string plain;
        string key;
        string cipher = "";
        int[] s = new int[8];
        int[] t = new int[8];
        public Rc4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        int XOR(int n1, int n2)
        {
            int answer;
            string n11, n22, temp = "";
            n11 = convert_to_binary(n1);
            n22 = convert_to_binary(n2);
            for (int i = 0; i < n11.Length; i++)
            {
                if (n11[i] == n22[i])
                {
                    temp += "0";
                }
                else
                {
                    temp += "1";
                }
            }
            answer = Convert.ToInt32(convert_to_hex(temp));
            return answer;
        }

        string convert_to_hex(string d)
        {
            string answer = "";
            string[] dict = new string[] { "000", "001", "010", "011", "100", "101", "110", "111" };
            for (int i = 0; i < 8; i++)
            {
                if (d == dict[i])
                {
                    answer = i.ToString();
                }
            }
            return answer;
        }

        string convert_to_binary(int d)
        {
            string answer = "";
            string[] dict = new string[] { "000", "001", "010", "011", "100", "101", "110", "111" };
            for (int i = 0; i < 8; i++)
            {
                if (d == i)
                {
                    answer = dict[i];
                }
            }
            return answer;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            plain = richTextBox1.Text;
            key = richTextBox2.Text;
            for (int i = 0; i < 8; i++)
            {
                s[i] = i;
                if (i < key.Length)
                {
                    t[i] = Convert.ToInt32(char.GetNumericValue(key[i]));
                }
                else
                {
                    t[i] = Convert.ToInt32(char.GetNumericValue(key[(i - key.Length)]));
                }
            }
            int j = 0;
            for (int i = 0; i < 8; i++)
            {
                j = (j + s[i] + t[i]) % 8;
                int temp = s[i];
                s[i] = s[j];
                s[j] = temp;
            }
            int l = 0;
            j = 0;
            int which = 0;
            int f, k;
            while (which < plain.Length)
            {
                l = (l + 1) % 8;
                j = (j + s[l]) % 8;
                int temp = s[l];
                s[l] = s[j];
                s[j] = temp;
                f = (s[l] + s[j]) % 8;
                k = s[f];
                cipher += XOR(k, Convert.ToInt32(char.GetNumericValue(plain[which])));
                which++;
            }
            richTextBox3.Text = cipher;
        }
    }
}
