using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Numerics;

namespace security_program
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            cipher_type.Items.Add("Ceaser");
            cipher_type.Items.Add("Vingenre");
            cipher_type.Items.Add("PlayFair");
            cipher_type.Items.Add("RailFence");
            cipher_type.Items.Add("Mã hóa hàng");
            cipher_type.Items.Add("DES");
            cipher_type.Items.Add("Diffie_Hellman");
            cipher_type.Items.Add("RSA");
        }



        private void encryption_Click(object sender, EventArgs e)
        {

            //Invoke(new Action(() => richTextBox2.AppendText(((char)(3 + 1 + 48)).ToString())));

            String str = rtxtbanro.Text.ToString();

            if (cipher_type.Text.ToString() == "Ceaser")
            {
                if (check_ceaser_str(str) == 1)
                {
                    int key = Convert.ToInt32(txtkey.Text.ToString());
                    Invoke(new Action(() => rtxtbanma.Clear()));
                    Invoke(new Action(() => rtxtbanma.AppendText(ceaser_encrypt(str, key))));
                }
            }
            if (cipher_type.Text.ToString() == "Vingenre")
            {
                if (check_Vingenre_str(str) == 1)
                {
                    StringBuilder s = new StringBuilder();
                    s.Append(str);
                    string key = txtkey.Text;
                    VigenereEncrypt(ref s, key);
                    Invoke(new Action(() => rtxtbanma.Clear()));
                    Invoke(new Action(() => rtxtbanma.AppendText(s.ToString().ToUpper())));
                }
            }
            else if (cipher_type.Text.ToString() == "PlayFair")
            {
                if (check_PF_str(str) == 1)
                {
                    Invoke(new Action(() => rtxtbanma.Clear()));
                    Invoke(new Action(() => rtxtbanma.AppendText(PlayFair_encrypt(str))));
                }
            }
            else if (cipher_type.Text.ToString() == "RailFence")
            {
                if (check_Rail_str(str) == 1)
                {
                    int key = Convert.ToInt32(txtkey.Text.ToString());
                    Invoke(new Action(() => rtxtbanma.Clear()));
                    Invoke(new Action(() => rtxtbanma.AppendText(Rail_Encrypt(key, str))));
                }
            }
            else if (cipher_type.Text.ToString() == "Mã hóa hàng")
            {
                string IdList = txtkey.Text;
                if (check_MaHoaHang_str(str) == 1)
                {
                    int[] key = IdList.Split(',').Select(h => Int32.Parse(h)).ToArray();
                    Invoke(new Action(() => rtxtbanma.Clear()));
                    Invoke(new Action(() => rtxtbanma.AppendText(MaHoaHang_Encrypt(str, key))));
                }
            }
            else if (cipher_type.Text.ToString() == "DES")
            {
                txtKetQua.Clear();
                if (txtkey.Text.Length != 16)
                {
                    MessageBox.Show(" Độ dài K phải = 16!", "Thông báo");
                    return;
                }
                if (rtxtbanro.Text == "")
                {
                    MessageBox.Show("Mời bạn nhập dữ liệu cần mã hóa!", "Thông báo");
                    return;
                }
                string cypherText = "";
                string plainText = rtxtbanro.Text;
                while (plainText.Length % 16 != 0)
                {
                    plainText += "F";
                }
                rtxtbanro.Text = plainText;
                string[] plainTextArray = new string[plainText.Length / 16];
                int index = 0;
                for (int i = 0; i < plainTextArray.Length; i++)
                {
                    plainTextArray[i] = plainText.Substring(index, 16);
                    index += 16;
                }

                txtKetQua.AppendText("  Bản rõ chia thành các đoạn: ");
                txtKetQua.AppendText(Environment.NewLine);
                for (int i = 0; i < plainTextArray.Length; i++)
                {
                    txtKetQua.AppendText("  Đoạn " + (i + 1) + ": ");
                    txtKetQua.AppendText(plainTextArray[i]);
                    txtKetQua.AppendText(Environment.NewLine);
                }
                for (int k = 0; k < plainTextArray.Length; k++)
                {

                    txtKetQua.AppendText(Environment.NewLine);
                    txtKetQua.AppendText("  Đoạn rõ " + (k + 1) + ": " + plainTextArray[k]); txtKetQua.AppendText(Environment.NewLine);
                    plainText = plainTextArray[k];
                    //bien doi key - > nhi phan
                    Key_Binary();

                    //hoan vi khoa 56 bit
                    HoanViKey();

                    //bang dich theo key theo bang CnDn
                    CnDnTable();

                    //bang key tu 1->16

                    txtKetQua.AppendText(Environment.NewLine);
                    //DES.LnRn(stringArr_NhiPhan(txtBanRo.Text));

                    TimLnRn_MaHoa(plainText);
                    // 16 vong DES
                    txtKetQua.AppendText(Environment.NewLine);
                    txtKetQua.AppendText("  L0:" + string.Join("", DES.listLn[0]));
                    txtKetQua.AppendText("  R0:" + string.Join("", DES.listRn[0]));
                    for (int i = 1; i <= 16; i++)
                    {
                        txtKetQua.AppendText(Environment.NewLine);
                        txtKetQua.AppendText(Environment.NewLine);
                        txtKetQua.AppendText("----------------------------------------------------------------------Vòng " + i + "---------------------------------------------------------------");


                        txtKetQua.AppendText(Environment.NewLine);
                        txtKetQua.AppendText("  L" + i + " :"); if (i <= 9) txtKetQua.AppendText("  ");
                        for (int j = 0; j < DES.listLn[i].Length; j++)
                            txtKetQua.AppendText(DES.listLn[i][j]);

                        txtKetQua.AppendText(Environment.NewLine);

                        txtKetQua.AppendText("  E(R" + (i - 1) + ") :"); if (i <= 9) txtKetQua.AppendText("  ");
                        txtKetQua.AppendText(string.Join(" ", DES.listE_R[i - 1]));
                        txtKetQua.AppendText(Environment.NewLine);

                        txtKetQua.AppendText("  K" + (i) + ":"); if (i <= 9) txtKetQua.AppendText("  ");
                        txtKetQua.AppendText(string.Join(" ", DES.key_List[i - 1]));
                        txtKetQua.AppendText(Environment.NewLine);

                        txtKetQua.AppendText("  ER" + (i - 1) + " XOR K" + (i) + ":"); if (i <= 9) txtKetQua.AppendText("  ");
                        txtKetQua.AppendText(string.Join(" ", DES.listERXorK[i - 1]));
                        txtKetQua.AppendText(Environment.NewLine);

                        txtKetQua.AppendText("  SBox_Out " + (i) + ":"); if (i <= 9) txtKetQua.AppendText("  ");
                        txtKetQua.AppendText(string.Join(" ", DES.listSboxOut[i - 1]));
                        txtKetQua.AppendText(Environment.NewLine);

                        txtKetQua.AppendText("  S" + (i) + "  B" + (i) + ":"); if (i <= 9) txtKetQua.AppendText("  ");
                        txtKetQua.AppendText(string.Join(" ", DES.listSnBnArray[i - 1]));
                        txtKetQua.AppendText(Environment.NewLine);

                        txtKetQua.AppendText("  F(R" + (i - 1) + "K" + (i) + "):"); if (i <= 9) txtKetQua.AppendText("  ");
                        txtKetQua.AppendText(string.Join(" ", DES.listFRK[i - 1]));

                        txtKetQua.AppendText(Environment.NewLine);
                        txtKetQua.AppendText("  L" + (i - 1) + " :"); if (i <= 9) txtKetQua.AppendText("  ");
                        for (int j = 0; j < DES.listLn[i].Length; j++)
                            txtKetQua.AppendText(DES.listLn[i - 1][j] + " ");
                        txtKetQua.AppendText(Environment.NewLine);
                        txtKetQua.AppendText("  R" + i + " :"); if (i <= 9) txtKetQua.AppendText("  ");
                        for (int j = 0; j < DES.listRn[i].Length; j++)
                            txtKetQua.AppendText(DES.listRn[i][j] + " ");

                    }
                    string[] R16L16 = DES.listRn[16].Concat(DES.listLn[16]).ToArray();
                    string[] hoanviIpNegative1 = DES.hoanVi(DES.MT_IP_negative1, R16L16, 64);

                    txtKetQua.AppendText(Environment.NewLine);
                    txtKetQua.AppendText(Environment.NewLine);
                    string hoanviIpNegative1Str = string.Join("", hoanviIpNegative1);
                    txtKetQua.AppendText("  IP-1:" + hoanviIpNegative1Str);
                    cypherText += DES.binary4bitToHexDecimal(hoanviIpNegative1Str); txtKetQua.AppendText(Environment.NewLine);
                    txtKetQua.AppendText("  Bản mã của đoạn: " + DES.binary4bitToHexDecimal(hoanviIpNegative1Str)); txtKetQua.AppendText(Environment.NewLine);
                    txtKetQua.AppendText("_____________________________________________________________________________________"); txtKetQua.AppendText(Environment.NewLine);
                    DES.DisposeAll();
                }
                rtxtbanma.Text = cypherText.ToUpper();
            }
            else if (cipher_type.Text.ToString() == "RSA")
            {
                if (rsa_check() == 1)
                {
                    Invoke(new Action(() => rtxtbanma.Clear()));
                    Invoke(new Action(() => rtxtbanma.AppendText(rsa_encrypt())));
                }
            }
        }


        private void Decryption_Click(object sender, EventArgs e)
        {
            String str = rtxtbanma.Text.ToString();
            if (cipher_type.Text.ToString() == "Ceaser")
            {

                if (check_ceaser_str(str) == 1)
                {
                    int key = Convert.ToInt32(txtkey.Text.ToString());
                    Invoke(new Action(() => txtKetQua.Clear()));
                    Invoke(new Action(() => txtKetQua.AppendText(ceaser_decrypt(str, key))));
                }
            }
            if (cipher_type.Text.ToString() == "Vingenre")
            {

                if (check_Vingenre_str(str) == 1)
                {
                    StringBuilder s = new StringBuilder();
                    s.Append(str);
                    string key = txtkey.Text;
                    VigenereDecrypt(ref s, key);
                    Invoke(new Action(() => txtKetQua.Clear()));
                    Invoke(new Action(() => txtKetQua.AppendText(s.ToString().ToUpper())));
                }
            }
            else if (cipher_type.Text.ToString() == "PlayFair")
            {
                Invoke(new Action(() => txtKetQua.Clear()));
                Invoke(new Action(() => txtKetQua.AppendText(PlayFair_decrypt(str))));
            }

            else if (cipher_type.Text.ToString() == "RailFence")
            {
                if (check_Rail_str(str) == 1)
                {
                    int key = Convert.ToInt32(txtkey.Text.ToString());
                    Invoke(new Action(() => txtKetQua.Clear()));
                    Invoke(new Action(() => txtKetQua.AppendText(Rail_Decrypt(key, str))));
                }
            }
            else if (cipher_type.Text.ToString() == "Mã hóa hàng")
            {
                //string IdList = txtkey.Text;
                //int[] key = IdList.Split(',').Select(h => Int32.Parse(h)).ToArray();
                if (check_MaHoaHang_str(str) == 1)
                {
                    Invoke(new Action(() => txtKetQua.AppendText(rtxtbanro.Text.ToUpper())));
                    //Invoke(new Action(() => rtxtbanro.AppendText(MaHoaHang_Decrypt(str, key))));
                }
            }
            else if (cipher_type.Text.ToString() == "DES")
            {
                txtKetQua.Clear();
                if (txtkey.Text.Length != 16)
                {
                    MessageBox.Show("  Độ dài K phải = 16!", "Thông báo");
                    return;
                }
                if (rtxtbanma.Text == "")
                {
                    MessageBox.Show("Mời bạn nhập dữ liệu cần giải mã!", "Thông báo");
                    return;
                }
                string cypher = "";
                string cypherText1 = rtxtbanma.Text;
                while (cypherText1.Length % 16 != 0)
                {
                    cypherText1 += "F";
                }
                rtxtbanma.Text = cypherText1;
                string[] cypherTextArray = new string[cypherText1.Length / 16];
                int index1 = 0;
                for (int i = 0; i < cypherTextArray.Length; i++)
                {
                    cypherTextArray[i] = cypherText1.Substring(index1, 16);
                    index1 += 16;
                }

                txtKetQua.AppendText("  Bản mã chia thành các đoạn: ");
                txtKetQua.AppendText(Environment.NewLine);
                for (int i = 0; i < cypherTextArray.Length; i++)
                {
                    txtKetQua.AppendText("  Đoạn " + (i + 1) + ": ");
                    txtKetQua.AppendText(cypherTextArray[i]);
                    txtKetQua.AppendText(Environment.NewLine);
                }
                for (int k = 0; k < cypherTextArray.Length; k++)
                {

                    txtKetQua.AppendText(Environment.NewLine);
                    txtKetQua.AppendText("  Đoạn rõ " + (k + 1) + ": " + cypherTextArray[k]); txtKetQua.AppendText(Environment.NewLine);
                    cypher = cypherTextArray[k];

                    TimLR_GiaiMa(cypher);
                    string[] R0L0 = DES.listRn[16].Concat(DES.listLn[16]).ToArray();
                    string[] cypherText = DES.hoanViNguoc(DES.MT_IP, R0L0);

                    string banRoCuaDoan = DES.binary4bitToHexDecimal(string.Join("", cypherText));
                    rtxtbanro.Clear();
                    rtxtbanro.Text += banRoCuaDoan;

                    txtKetQua.AppendText(Environment.NewLine);
                    txtKetQua.AppendText("  L0:" + string.Join("", DES.listLn[0]));
                    txtKetQua.AppendText("  R0:" + string.Join("", DES.listRn[0]));
                    int index = 16;
                    for (int i = 1; i <= 16; i++)
                    {
                        txtKetQua.AppendText(Environment.NewLine);
                        txtKetQua.AppendText(Environment.NewLine);
                        txtKetQua.AppendText("----------------------------------------------------------------------Vòng " + i + "---------------------------------------------------------------");


                        txtKetQua.AppendText(Environment.NewLine);
                        txtKetQua.AppendText("  L" + i + " :"); if (i <= 9) txtKetQua.AppendText("  ");
                        for (int j = 0; j < DES.listLn[i].Length; j++)
                            txtKetQua.AppendText(DES.listLn[i][j]);

                        txtKetQua.AppendText(Environment.NewLine);

                        txtKetQua.AppendText("  E(R" + (i - 1) + ") :"); if (i <= 9) txtKetQua.AppendText("  ");
                        txtKetQua.AppendText(string.Join(" ", DES.listE_R[i - 1]));
                        txtKetQua.AppendText(Environment.NewLine);

                        txtKetQua.AppendText("  K" + (index) + ":"); if (i <= 9) txtKetQua.AppendText("  ");
                        txtKetQua.AppendText(string.Join(" ", DES.key_List[index - 1]));
                        txtKetQua.AppendText(Environment.NewLine);

                        txtKetQua.AppendText("  ER" + (i - 1) + " XOR K" + (index) + ":"); if (i <= 9) txtKetQua.AppendText("  ");
                        txtKetQua.AppendText(string.Join(" ", DES.listERXorK[i - 1]));
                        txtKetQua.AppendText(Environment.NewLine);

                        txtKetQua.AppendText("  SBox_Out " + (i) + ":"); if (i <= 9) txtKetQua.AppendText("  ");
                        txtKetQua.AppendText(string.Join(" ", DES.listSboxOut[i - 1]));
                        txtKetQua.AppendText(Environment.NewLine);

                        txtKetQua.AppendText("  S" + (i) + "  B" + (i) + ":"); if (i <= 9) txtKetQua.AppendText("  ");
                        txtKetQua.AppendText(string.Join(" ", DES.listSnBnArray[i - 1]));
                        txtKetQua.AppendText(Environment.NewLine);

                        txtKetQua.AppendText("  F(R" + (i - 1) + "K" + (index) + "):"); if (i <= 9) txtKetQua.AppendText("  ");
                        txtKetQua.AppendText(string.Join(" ", DES.listFRK[i - 1]));

                        txtKetQua.AppendText(Environment.NewLine);
                        txtKetQua.AppendText("  L" + (i - 1) + " :"); if (i <= 9) txtKetQua.AppendText("  ");
                        for (int j = 0; j < DES.listLn[i].Length; j++)
                            txtKetQua.AppendText(DES.listLn[i - 1][j] + " ");
                        txtKetQua.AppendText(Environment.NewLine);
                        txtKetQua.AppendText("  R" + i + " :"); if (i <= 9) txtKetQua.AppendText("  ");
                        for (int j = 0; j < DES.listRn[i].Length; j++)
                            txtKetQua.AppendText(DES.listRn[i][j] + " ");

                        index--;
                    }

                    txtKetQua.AppendText(Environment.NewLine);
                    txtKetQua.AppendText("  Bản rõ của đoạn: " + banRoCuaDoan);
                    txtKetQua.AppendText(Environment.NewLine);

                    DES.DisposeAll();
                }

                txtKetQua.AppendText("_____________________________________________________________________________________");
                txtKetQua.AppendText(Environment.NewLine);

            }
            else if (cipher_type.Text.ToString() == "RSA")
            {
                if (rsa_check() == 1)
                {
                    Invoke(new Action(() => rtxtbanro.Clear()));
                    Invoke(new Action(() => rtxtbanro.AppendText(rsa_decrypt())));
                }
            }

        }

        /********************************************************************************************************************
        ****************************************** PLAY MÃ HÓA HÀNG FUNNCTIONS********************************************************/
        public int check_MaHoaHang_str(String str)
        {
            int j = 0;
            while (j < str.Length)
            {
                if (!(((str[j] >= 'a') && (str[j] <= 'z')) || ((str[j] >= 'A') && (str[j] <= 'Z')) || (str[j] == ' ')))
                {
                    MessageBox.Show("Error: Pleaase enter a valid Play Fair message", "ERROR");
                    return 0;
                }
                j++;
            }
            return 1;
        }

        static int col = 7;
        public string MaHoaHang_Encrypt(string plaintext, int[] key)
        {
            int[] index = new int[col];
            for (int i = 0; i < col; i++)
            {
                index[key[i] - 1] = i;
            }
            int len = plaintext.Length;
            string input = plaintext;
            int row = len / col;
            int pad = len % col;
            row++;
            len = input.Length;
            string cipher = "";
            foreach (int k in index)
            {
                for (int i = 0; i < row; i++)
                {
                    int c = i * col + k;
                    if (c < len)
                    {
                        cipher += input[c];
                    }
                }
            }
            return cipher.ToUpper();
        }

        public string MaHoaHang_Decrypt(string cipher, int[] key)
        {
            int len = cipher.Length;
            int row = len / col;
            string plaintext = "";
            for (int i = 0; i < row; i++)
            {
                foreach (int k in key)
                {
                    int p = (k - 1) * row + i;
                    plaintext += cipher[p];
                }
            }
            return plaintext.ToUpper();
        }

        /********************************************************************************************************************
        ****************************************** END MÃ HÓA HÀNG FUNCTIONS********************************************************/


        /********************************************************************************************************************
        ****************************************** PLAY RAIL FENCE FUNCTIONS********************************************************/
        public int check_Rail_str(String str)
        {
            int j = 0;
            while (j < str.Length)
            {
                if (!(((str[j] >= 'a') && (str[j] <= 'z')) || ((str[j] >= 'A') && (str[j] <= 'Z')) || (str[j] == ' ')))
                {
                    MessageBox.Show("Error: Pleaase enter a valid Play Fair message", "ERROR");
                    return 0;
                }
                j++;
            }
            return 1;
        }

        public static string Rail_Encrypt(int rail, string plainText)
        {
            List<string> railFence = new List<string>();
            for (int i = 0; i < rail; i++)
            {
                railFence.Add("");
            }

            int number = 0;
            int increment = 1;
            foreach (char c in plainText)
            {
                if (number + increment == rail)
                {
                    increment = -1;
                }
                else if (number + increment == -1)
                {
                    increment = 1;
                }
                railFence[number] += c;
                number += increment;
            }

            string buffer = "";
            foreach (string s in railFence)
            {
                buffer += s;
            }
            return buffer.ToUpper();
        }

        ///GIẢI MÃ
        public static string Rail_Decrypt(int rail, string cipherText)
        {
            int cipherLength = cipherText.Length;
            List<List<int>> railFence = new List<List<int>>();
            for (int i = 0; i < rail; i++)
            {
                railFence.Add(new List<int>());
            }

            int number = 0;
            int increment = 1;
            for (int i = 0; i < cipherLength; i++)
            {
                if (number + increment == rail)
                {
                    increment = -1;
                }
                else if (number + increment == -1)
                {
                    increment = 1;
                }
                railFence[number].Add(i);
                number += increment;
            }

            int counter = 0;
            char[] buffer = new char[cipherLength];
            for (int i = 0; i < rail; i++)
            {
                for (int j = 0; j < railFence[i].Count; j++)
                {
                    buffer[railFence[i][j]] = cipherText[counter];
                    counter++;
                }
            }

            return new string(buffer).ToUpper();

        }

        /********************************************************************************************************************
        ****************************************** END RAIL FENCE FUNCTIONS********************************************************/


        /********************************************************************************************************************
        ****************************************** PLAY VINGENRE FUNCTIONS********************************************************/
        int check_Vingenre_str(String str)
        {
            int j = 0;

            while (j < str.Length)
            {
                if (!(((str[j] >= 'a') && (str[j] <= 'z')) || ((str[j] >= 'A') && (str[j] <= 'Z')) || (str[j] == ' ')))
                {
                    MessageBox.Show("Error: Pleaase enter a valid Play Fair message", "ERROR");
                    return 0;
                }

                j++;
            }

            return 1;
        }

        public static void VigenereEncrypt(ref StringBuilder s, string key)
        {
            for (int i = 0; i < s.Length; i++) s[i] = Char.ToUpper(s[i]);
            key = key.ToUpper();
            int j = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (Char.IsLetter(s[i]))
                {
                    s[i] = (char)(s[i] + key[j] - 'A');
                    if (s[i] > 'Z') s[i] = (char)(s[i] - 'Z' + 'A' - 1);
                }
                j = j + 1 == key.Length ? 0 : j + 1;
            }
        }

        public static void VigenereDecrypt(ref StringBuilder s, string key)
        {
            for (int i = 0; i < s.Length; i++) s[i] = Char.ToUpper(s[i]);
            key = key.ToUpper();
            int j = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (Char.IsLetter(s[i]))
                {
                    s[i] = s[i] >= key[j] ?
                              (char)(s[i] - key[j] + 'A') :
                              (char)('A' + ('Z' - key[j] + s[i] - 'A') + 1);
                }
                j = j + 1 == key.Length ? 0 : j + 1;
            }
        }

        /********************************************************************************************************************
        ****************************************** END VINGENRE FUNCTIONS********************************************************/


        /********************************************************************************************************************
        ****************************************** PLAY FAIR FUNCTIONS********************************************************/

        int check_PF_str(String str)
        {
            int j = 0;

            while (j < str.Length)
            {
                if (!(((str[j] >= 'a') && (str[j] <= 'z')) || ((str[j] >= 'A') && (str[j] <= 'Z')) || (str[j] == ' ')))
                {
                    MessageBox.Show("Error: Pleaase enter a valid Play Fair message", "ERROR");
                    return 0;
                }

                j++;
            }

            return 1;
        }

        String PlayFair_encrypt(String str)
        {
            StringBuilder tmp_str = new StringBuilder(str.ToUpper());
            int[] space_indexes = new int[20];
            int space_count = 0;

            for (int count1 = 0; count1 < tmp_str.Length; count1 += 1)
            {

                if (tmp_str[count1] == ' ')
                {
                    tmp_str = tmp_str.Remove(count1, 1);
                    space_indexes[space_count] = count1;
                    space_count++;
                }

            }
            space_indexes[space_count] = -1;
            for (int count1 = 0; count1 < tmp_str.Length; count1 += 1)
            {

                if (tmp_str[count1] == 'j')
                {
                    tmp_str[count1] = 'i';
                }

                if (tmp_str[count1] == 'J')
                {
                    tmp_str[count1] = 'I';
                }

            }

            for (int count1 = 0; ((count1 < tmp_str.Length) && ((count1 + 1) < tmp_str.Length)); count1 += 2)
            {

                if (tmp_str[count1] == tmp_str[count1 + 1])
                {
                    tmp_str.Insert(count1 + 1, "x");
                }

            }

            if ((tmp_str.Length % 2) == 1)
            {
                tmp_str.Append("x");
            }

            for (int count1 = 0; count1 < tmp_str.Length; count1++)
            {

                if (tmp_str[count1] >= 'a' && tmp_str[count1] <= 'z')
                {
                    tmp_str[count1] -= (char)((int)'a' - (int)'A');
                }

            }

            String key = txtkey.Text.ToString();
            StringBuilder tmp_key = new StringBuilder(key);

            for (int count1 = 0; count1 < tmp_key.Length; count1 += 1)
            {

                if (tmp_key[count1] == 'j')
                {
                    tmp_key[count1] = 'i';
                }

                if (tmp_key[count1] == 'J')
                {
                    tmp_key[count1] = 'I';
                }

            }

            for (int count1 = 0; count1 < tmp_key.Length; count1++)
            {
                for (int count2 = 0; count2 < count1; count2++)
                {

                    if (tmp_key[count1] == tmp_key[count2])
                    {
                        tmp_key = tmp_key.Remove(count1, 1);
                        count1--;
                        break;
                    }

                }

            }

            for (int count1 = 0; count1 < tmp_key.Length; count1++)
            {

                if (tmp_key[count1] >= 'a' && tmp_key[count1] <= 'z')
                {
                    tmp_key[count1] -= (char)((int)'a' - (int)'A');
                }

            }

            int keyword_stored_flag = 0;
            int exists_in_keyord = 0;

            char[,] matrix = new char[5, 5];

            for (int row_count = 0, alphabet_counter = 0; row_count < 5; row_count++)
            {

                for (int col_count = 0; col_count < 5; col_count++)
                {
                    if ((((row_count * 5) + col_count) < tmp_key.Length) && (keyword_stored_flag == 0))
                    {
                        matrix[row_count, col_count] = tmp_key[(row_count * 5) + col_count];
                    }
                    else
                    {
                        keyword_stored_flag = 1;
                        exists_in_keyord = 0;
                        for (int count1 = 0; count1 < tmp_key.Length; count1++)
                        {

                            if ('A' + alphabet_counter == tmp_key[count1])
                            {
                                exists_in_keyord = 1;
                                break;
                            }

                        }

                        if ((exists_in_keyord == 0) && (('A' + alphabet_counter) != 'J'))
                        {
                            matrix[row_count, col_count] = (char)((int)'A' + alphabet_counter);
                        }
                        else
                        {
                            col_count--;
                        }

                        alphabet_counter++;
                    }

                }

            }


            int letter1_row = 0, letter1_col = 0, letter2_row = 0, letter2_col = 0;

            for (int m_count = 0; m_count < tmp_str.Length; m_count += 2)
            {

                get_index(matrix, tmp_str[m_count], ref letter1_row, ref letter1_col);
                get_index(matrix, tmp_str[m_count + 1], ref letter2_row, ref letter2_col);

                if (letter1_row == letter2_row)
                {
                    tmp_str[m_count] = matrix[letter1_row, (letter1_col + 1) % 5];
                    tmp_str[m_count + 1] = matrix[letter2_row, (letter2_col + 1) % 5];
                }
                else if (letter1_col == letter2_col)
                {
                    tmp_str[m_count] = matrix[(letter1_row + 1) % 5, letter1_col];
                    tmp_str[m_count + 1] = matrix[(letter2_row + 1) % 5, letter2_col];
                }
                else
                {
                    tmp_str[m_count] = matrix[letter1_row, letter2_col];
                    tmp_str[m_count + 1] = matrix[letter2_row, letter1_col];
                }

            }

            for (int count = 0; space_indexes[count] != -1; count++)
            {
                tmp_str.Insert(space_indexes[count] + count, " ");
            }

            str = tmp_str.ToString();

            return str;


        }


        String PlayFair_decrypt(String str)
        {
            StringBuilder tmp_str = new StringBuilder(str.ToUpper());

            int[] space_indexes = new int[20];
            int space_count = 0;

            for (int count1 = 0; count1 < tmp_str.Length; count1 += 1)
            {

                if (tmp_str[count1] == ' ')
                {
                    tmp_str = tmp_str.Remove(count1, 1);
                    space_indexes[space_count] = count1;
                    space_count++;
                }

            }

            space_indexes[space_count] = -1;

            String key = txtkey.Text.ToString();

            StringBuilder tmp_key = new StringBuilder(key.ToUpper());
            for (int count1 = 0; count1 < tmp_key.Length; count1 += 1)
            {

                if (tmp_key[count1] == 'J')
                {
                    tmp_key[count1] = 'I';
                }

            }

            for (int count1 = 0; count1 < tmp_key.Length; count1++)
            {
                for (int count2 = 0; count2 < count1; count2++)
                {

                    if (tmp_key[count1] == tmp_key[count2])
                    {
                        tmp_key = tmp_key.Remove(count1, 1);
                        count1--;
                        break;
                    }

                }

            }

            int keyword_stored_flag = 0;
            int exists_in_keyord = 0;

            char[,] matrix = new char[5, 5];

            for (int row_count = 0, alphabet_counter = 0; row_count < 5; row_count++)
            {

                for (int col_count = 0; col_count < 5; col_count++)
                {
                    if ((((row_count * 5) + col_count) < tmp_key.Length) && (keyword_stored_flag == 0))
                    {
                        matrix[row_count, col_count] = tmp_key[(row_count * 5) + col_count];
                    }
                    else
                    {
                        keyword_stored_flag = 1;
                        exists_in_keyord = 0;
                        for (int count1 = 0; count1 < tmp_key.Length; count1++)
                        {

                            if ('A' + alphabet_counter == tmp_key[count1])
                            {
                                exists_in_keyord = 1;
                                break;
                            }

                        }

                        if ((exists_in_keyord == 0) && (('A' + alphabet_counter) != 'J'))
                        {
                            matrix[row_count, col_count] = (char)((int)'A' + alphabet_counter);
                        }
                        else
                        {
                            col_count--;
                        }

                        alphabet_counter++;
                    }

                }

            }

            int letter1_row = 0, letter1_col = 0, letter2_row = 0, letter2_col = 0;

            for (int m_count = 0; m_count < tmp_str.Length; m_count += 2)
            {

                get_index(matrix, tmp_str[m_count], ref letter1_row, ref letter1_col);
                get_index(matrix, tmp_str[m_count + 1], ref letter2_row, ref letter2_col);

                if (letter1_row == letter2_row)
                {
                    tmp_str[m_count] = matrix[letter1_row, (letter1_col + 4) % 5];
                    tmp_str[m_count + 1] = matrix[letter2_row, (letter2_col + 4) % 5];
                }
                else if (letter1_col == letter2_col)
                {
                    tmp_str[m_count] = matrix[(letter1_row + 4) % 5, letter1_col];
                    tmp_str[m_count + 1] = matrix[(letter2_row + 4) % 5, letter2_col];
                }
                else
                {
                    tmp_str[m_count] = matrix[letter1_row, letter2_col];
                    tmp_str[m_count + 1] = matrix[letter2_row, letter1_col];
                }


            }

            for (int i = tmp_str.Length - 1; i >= 0; i--)
            {
                if (tmp_str[i] == 'X')
                {

                    if (i > 0)
                    {
                        if (i == (tmp_str.Length - 1))
                        {
                            tmp_str.Remove(i, 1);
                        }
                        else if (tmp_str[i - 1] == tmp_str[i + 1])
                        {
                            tmp_str.Remove(i, 1);
                        }
                    }

                }
            }

            for (int count = 0; space_indexes[count] != -1; count++)
            {
                tmp_str.Insert(space_indexes[count] + count, " ");
            }

            str = tmp_str.ToString();
            return str;
        }



        void get_index(char[,] matrix, char chr, ref int row, ref int col)
        {
            for (int row_count = 0, char_match_flag = 0; char_match_flag == 0; row_count++)
            {

                for (int col_count = 0; col_count < 5; col_count++)
                {

                    if (matrix[row_count, col_count] == chr)
                    {
                        char_match_flag = 1;
                        col = col_count;
                        row = row_count;
                        break;
                    }

                }

            }

        }

        /**********************************************END OF PLAYFAIR FUNCTIONS*********************************************************
        ********************************************************************************************************************************/


        /********************************************************************************************************************************
       *********************************************START OF RSA ENCRYPTION FUNCTIONS*********************************************************/

        byte rsa_check()
        {
            //p & q are prime  
            //M < n
            //e < phi
            //e relatively prime to phi

            int P = Convert.ToInt32(txt_p.Text, 10);
            int Q = Convert.ToInt32(txt_q.Text, 10);
            int e = Convert.ToInt32(txt_e.Text, 10);
            int phi = (P - 1) * (Q - 1);

            //check P is prime
            for (int i = 2; i < P; i++)
            {
                if (P % i == 0)
                {
                    MessageBox.Show("Error: enter a prime P number", "Error");
                    return 0;
                }

            }
            //check q is prime
            for (int i = 2; i < Q; i++)
            {
                if (Q % i == 0)
                {
                    MessageBox.Show("Error: enter a prime Q number", "Error");
                    return 0;
                }
            }
            //e < phi
            if (e >= phi)
            {
                MessageBox.Show("Error: e is >= phi ", "Error");
                return 0;
            }
            //e is relatively prime
            if (phi % e == 0)
            {
                MessageBox.Show("Error: e is not relatively prime to phi ", "Error");
                return 0;
            }
            return 1;
        }


        string rsa_encrypt()
        {
            txtKetQua.Clear();
            string M_str = rtxtbanro.Text;
            string M_str1 = "";
            for (int i = 0; i < M_str.Length; i++)
            {
                if ((M_str[i] >= '0' && M_str[i] <= '9'))
                {
                    M_str1 += M_str[i].ToString();
                }
                else
                {
                    M_str1 += ((byte)M_str[i]).ToString();
                }
            }

            BigInteger M = new BigInteger(M_str1, 10);
            BigInteger P = new BigInteger(txt_p.Text, 10);
            BigInteger Q = new BigInteger(txt_q.Text, 10);
            BigInteger e = new BigInteger(txt_e.Text, 10);

            BigInteger n = P * Q;
            BigInteger phi = (P - 1) * (Q - 1);
            txtKetQua.AppendText("Khóa bí mật P =  " + P.ToString());
            txtKetQua.AppendText(Environment.NewLine);
            txtKetQua.AppendText("Khóa bí mật q =  " + Q.ToString());
            txtKetQua.AppendText(Environment.NewLine);
            txtKetQua.AppendText("Khóa công khai n =  " + n.ToString());
            txtKetQua.AppendText(Environment.NewLine);
            txtKetQua.AppendText("phi(n) = " + phi.ToString());
            txtKetQua.AppendText(Environment.NewLine);
            txtKetQua.AppendText("=> Khóa công khai e = " + e.ToString());
            txtKetQua.AppendText(Environment.NewLine);
            txtKetQua.AppendText("=>> Mã hóa công khai KU =" + "{" + e.ToString() + "," + n.ToString() + "}");
            txtKetQua.AppendText(Environment.NewLine);
            BigInteger d = 0;
            BigInteger mod1_phi = phi + 1;

            while (d == 0)
            {
                if (mod1_phi % e == 0)
                {
                    d = mod1_phi / e;
                }
                else
                {
                    mod1_phi += phi;
                }
            }
            txtKetQua.AppendText("=>> Mã hóa riêng tư: KR =" + "{" + d.ToString() + "," + n.ToString() + "}");
            txtKetQua.AppendText(Environment.NewLine);
            BigInteger C = M.modPow(e, n);
            txtKetQua.AppendText("==> Mã hóa C = " + C.ToString());
            txtKetQua.AppendText(Environment.NewLine);
            return C.ToString();
        }

        string rsa_decrypt()
        {
            txtKetQua.Clear();
            BigInteger C = new BigInteger(rtxtbanma.Text, 10);
            BigInteger P = new BigInteger(txt_p.Text, 10);
            BigInteger Q = new BigInteger(txt_q.Text, 10);
            BigInteger e = new BigInteger(txt_e.Text, 10);

            BigInteger n = P * Q;
            BigInteger phi = (P - 1) * (Q - 1);
            txtKetQua.AppendText("Khóa bí mật P =  " + P.ToString());
            txtKetQua.AppendText(Environment.NewLine);
            txtKetQua.AppendText("Khóa bí mật q =  " + Q.ToString());
            txtKetQua.AppendText(Environment.NewLine);
            txtKetQua.AppendText("Khóa công khai n =  " + n.ToString());
            txtKetQua.AppendText(Environment.NewLine);
            txtKetQua.AppendText("phi(n) = " + phi.ToString());
            txtKetQua.AppendText(Environment.NewLine);
            txtKetQua.AppendText("Khóa công khai e = " + e.ToString());
            txtKetQua.AppendText(Environment.NewLine);
            txtKetQua.AppendText("=>> Mã hóa công khai KU =" + "{" + e.ToString() + "," + n.ToString() + "}");
            txtKetQua.AppendText(Environment.NewLine);
            BigInteger d = 0;
            BigInteger mod1_phi = phi + 1;

            while (d == 0)
            {
                if (mod1_phi % e == 0)
                {
                    d = mod1_phi / e;
                }
                else
                {
                    mod1_phi += phi;
                }
            }
            txtKetQua.AppendText("Khóa bí mật d = " + d.ToString());
            txtKetQua.AppendText(Environment.NewLine);
            txtKetQua.AppendText("=>> Mã hóa riêng tư KR =" + "{" + d.ToString() + "," + n.ToString() + "}");
            txtKetQua.AppendText(Environment.NewLine);
            BigInteger M = C.modPow(d, n);
            txtKetQua.AppendText(Environment.NewLine);
            txtKetQua.AppendText("==> Giải mã M = " + M.ToString());
            txtKetQua.AppendText(Environment.NewLine);
            return M.ToString();
        }

        /********************************************************************************************************************************
      *********************************************START OF DIFFIE- HELLMAN ENCRYPTION FUNCTIONS****************************************************/
        bool kiemtra()
        {
            if (int.Parse(txt_Xa.Text) < int.Parse(txt_q.Text))
            {
                return true;
            }
            else if (int.Parse(txt_Xb.Text) < int.Parse(txt_q.Text))
            {
                return true;
            }
            return false;

        }
        void diff_encrypt()
        {
            BigInteger Q = new BigInteger(txt_q.Text, 10);
            BigInteger Anpha = new BigInteger(txt_anpha.Text, 10);
            BigInteger Xa = new BigInteger(txt_Xa.Text, 10);
            BigInteger Xb = new BigInteger(txt_Xb.Text, 10);

            txtKetQua.AppendText("Số nguyên tố q =  " + Q.ToString());
            txtKetQua.AppendText(Environment.NewLine);
            txtKetQua.AppendText("Căn nguyên của q Anpha =  " + Anpha.ToString());
            txtKetQua.AppendText(Environment.NewLine);
            txtKetQua.AppendText("Khóa riêng Xa = " + Xa.ToString());
            txtKetQua.AppendText(Environment.NewLine);
            txtKetQua.AppendText("Khóa riêng Xb = " + Xb.ToString());
            txtKetQua.AppendText(Environment.NewLine);

            BigInteger Ya = 0;
            BigInteger Yb = 0;

            if (kiemtra())
            {
                Ya = Anpha.modPow(Xa, Q);
                Yb = Anpha.modPow(Xb, Q);
            }

            txtKetQua.AppendText("Khóa công khai Ya = " + Ya.ToString());
            txtKetQua.AppendText(Environment.NewLine);
            txtKetQua.AppendText("Khóa công khai Yb = " + Yb.ToString());
            txtKetQua.AppendText(Environment.NewLine);

            BigInteger Ka = Yb.modPow(Xa, Q);
            BigInteger Kb = Ya.modPow(Xb, Q);
            txtKetQua.AppendText("==> Khóa bí mật theo Ya = " + Ka.ToString());
            txtKetQua.AppendText(Environment.NewLine);
            txtKetQua.AppendText("==> Khóa bí mật theo Yb = " + Kb.ToString());
            txtKetQua.AppendText(Environment.NewLine);
        }

        /********************************************************************************************************************************
      *********************************************END OF DIFFIE- HELLMAN ENCRYPTION FUNCTIONS****************************************************/


        /********************************************************************************************************************************
       *********************************************START OF DES ENCRYPTION FUNCTIONS****************************************************/

        public string[] stringArr_NhiPhan(string key)
        {

            string[] keyBinaryArray = DES.HexToBin4bit(key);
            return keyBinaryArray;
        }

        public void Key_Binary()
        {
            string temp = "";
            foreach (var item in stringArr_NhiPhan(txtkey.Text))
            {
                temp += (item + " ");
            }
            txtKetQua.AppendText("  K nhị phân: " + temp + Environment.NewLine);
        }

        public void tim_K_table(string[] matranPC02_Array)
        {
            for (int i = 0; i < 16; i++)
            {
                string[] key_Array = new string[56];
                key_Array = DES.hoanVi(matranPC02_Array, DES.listCnDn[i], 48);
                DES.key_List.Add(key_Array);
            }

            for (int k = 0; k < 16; k++)
            {
                txtKetQua.AppendText("  K" + (k + 1) + " :");
                if (k < 9) txtKetQua.AppendText("  ");
                for (int j = 0; j < 48; j++)
                {
                    txtKetQua.AppendText(DES.key_List[k][j].ToString() + " ");

                }
                txtKetQua.AppendText(Environment.NewLine);
            }
        }

        public void HoanViKey()
        {
            string[] binaryStr64 = DES.Convert_16unit4bit_To_64unit1bit(stringArr_NhiPhan(txtkey.Text));
            string[] strArray = DES.hoanVi(DES.MT_PC1, binaryStr64, 56);
            string temp = "";

            for (int i = 0; i < strArray.Length; i++)
            {
                temp += strArray[i];
                if ((i + 1) % 4 == 0) temp += " ";
            }

            txtKetQua.AppendText("  K hoán vị  : " + temp + Environment.NewLine);
        }

        public void CnDnTable()
        {
            string[] binaryStr64 = DES.Convert_16unit4bit_To_64unit1bit(stringArr_NhiPhan(txtkey.Text));
            string[] keyHoanVi = DES.hoanVi(DES.MT_PC1, binaryStr64, 56);
            DES.CnDnTable(DES.Dich_CnDn, keyHoanVi);

            txtKetQua.AppendText(Environment.NewLine);
            for (int i = 0; i <= 16; i++)
            {

                txtKetQua.AppendText("  C" + i + ": ");
                if (i <= 9) txtKetQua.AppendText("  ");
                for (int j = 0; j < 28; j++)
                {

                    txtKetQua.AppendText((DES.listCn[i][j] + " "));
                }
                txtKetQua.AppendText("|D" + i + ": ");
                if (i <= 9) txtKetQua.AppendText("  ");
                for (int j = 0; j < 28; j++)
                {

                    txtKetQua.AppendText((DES.listDn[i][j] + " "));

                }
                txtKetQua.AppendText(Environment.NewLine);
            }
        }
        public void TimLnRn_MaHoa(string plainText)
        {
            tim_K_table(DES.MT_PC2);
            for (int i = 0; i < 16; i++)
            {
                //moi vong co SiBi

                //tinh R tiep theo de gan cho L
                //muon tim dc R1 thi phai lat L0 XOR f(ER0,K1). L0 co, R0 co, K1 co. 
                //b1.Phai tim f(ER0,K1). 
                //b2: f chia thanh 8 nhom 6 bit,
                //b3:moix nhom 6bit hoan vi qua bang sbox tuong ung
                //b3.1: tim x,y;
                //b3.2: tim x,y tuong ung trong Sbox => hoan thanh 1 Si(Bi), lap lai 8 lan;
                //Thuc hien b1:tim f(ER0,K1)

                //listLn[1] = listRn[0];

                DES.L0R0(stringArr_NhiPhan(plainText));
                string[] f = DES.KeyXorER(DES.key_List[i], DES.listRn[i]);//xong b1;

                string[] Bn_array = DES.Bn(f);//xong b2;
                DES.listSboxOut.Add(Bn_array);
                //thuc hien buoc 3;
                //ket qua ra S1(B1) -> S8(B8)
                DES.timXY(Bn_array);
                DES.hoanViFquaSBox(Bn_array);
                string[] tempSnBn = DES.DecimalToBin4bit(DES.SnBnArray);
                DES.listSnBnArray.Add(tempSnBn);
                //hoan vi cua f(R0,K1) ;
                string[] binaryStr = DES.Convert_8unit4bit_To_32unit1bit(tempSnBn);
                string[] F_RK = DES.hoanVi(DES.MT_P, binaryStr, 32);
                DES.listFRK.Add(F_RK);
                string[] temp = DES.listRn[i];
                DES.listLn.Insert(i + 1, temp);

                string[] temp2 = DES.L_Xor_F_RK(DES.listLn[i], F_RK);
                DES.listRn.Insert(i + 1, temp2);

            }

        }

        public void TimLR_GiaiMa(string cypher)
        {

            Key_Binary();

            //hoan vi khoa 56 bit
            HoanViKey();

            //bang dich theo key theo bang CnDn
            CnDnTable();
            tim_K_table(DES.MT_PC2);
            string cypherText = cypher;
            string[] ipNegative1 = DES.HexToBin4bit(cypherText);
            ipNegative1 = DES.Convert_16unit4bit_To_64unit1bit(ipNegative1);
            string[] L16R16 = DES.hoanViNguoc(DES.MT_IP_negative1, ipNegative1);
            //txtKetQua.AppendText(string.Join("", ipNegative1));
            // txtKetQua.AppendText("\r\nL16R16: "+string.Join("",L16R16));
            string[] temp = new string[32];

            for (int j = 0; j < 32; j++)
            {
                temp[j] = L16R16[j];
            }
            DES.listLn.Add(temp);
            temp = new string[32];
            int index = 0;
            for (int j = 32; j < 64; j++)
            {
                temp[index] = L16R16[j];
                index++;
            }
            DES.listRn.Add(temp);
            int ind = 0;
            for (int i = 15; i >= 0; i--)
            {


                string[] f = DES.KeyXorER(DES.key_List[i], DES.listRn[ind]);//xong b1;

                string[] Bn_array = DES.Bn(f);//xong b2;
                DES.listSboxOut.Add(Bn_array);
                //thuc hien buoc 3;
                //ket qua ra S1(B1) -> S8(B8)
                DES.timXY(Bn_array);
                DES.hoanViFquaSBox(Bn_array);
                string[] tempSnBn = DES.DecimalToBin4bit(DES.SnBnArray);
                DES.listSnBnArray.Add(tempSnBn);
                //hoan vi cua f(R0,K1) ;
                string[] binaryStr = DES.Convert_8unit4bit_To_32unit1bit(tempSnBn);
                string[] F_RK = DES.hoanVi(DES.MT_P, binaryStr, 32);
                DES.listFRK.Add(F_RK);
                string[] temp1 = DES.listRn[ind];

                DES.listLn.Insert(ind + 1, temp1);

                string[] temp2 = DES.L_Xor_F_RK(DES.listLn[ind], F_RK);
                DES.listRn.Insert(ind + 1, temp2);
                ind++;
            }
        }


        /****************************************END OF DES DECRYPTION FUNCTIONS*************************************************************
        **************************************************************************************************************************/



        /********************************************************************************************************************************
        *********************************************START OF RC4 ENCRYPTION FUNCTIONS*********************************************************/
        byte check_Diff(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                //if the input does no consists of hex chars
                if (!((str[i] >= '0' && str[i] <= '9') || (str[i] >= 'a' && str[i] <= 'f') || (str[i] >= 'A' && str[i] <= 'F')))
                {
                    MessageBox.Show("Error: non hex chars detected", "ERROR");
                    return 0;

                }

            }

            return 1;
        }


        /********************************************************************************************************************************
        *********************************************START OF CEASER FUNCTIONS*********************************************************/


        int check_ceaser_str(String str)
        {
            int j = 0;

            while (j < str.Length) //loop each character until the end of the string
            {

                /* if the character is not an alphabet nor a space, then assign FALSE to the valid_message*/
                if (!(((str[j] >= 'a') && (str[j] <= 'z')) || ((str[j] >= 'A') && (str[j] <= 'Z')) || (str[j] == ' ')))
                {
                    MessageBox.Show("Error: Please enter a valid Ceaser message", "ERROR");
                    return 0;
                }

                j++;
            }

            return 1;
        }



        String ceaser_encrypt(String str, int key)
        {
            StringBuilder tmp_str = new StringBuilder(str);
            int i = 0;
            while (i < tmp_str.Length)
            {

                if (tmp_str[i] != ' ')
                {
                    tmp_str[i] = (char)(tmp_str[i] + key);
                }

                if ((tmp_str[i] > 'z'))
                {
                    tmp_str[i] = (char)((tmp_str[i] % 'z') + ('a' - 1));
                }
                else if ((tmp_str[i] > 'Z') && (tmp_str[i] < 'a'))
                {
                    tmp_str[i] = (char)((tmp_str[i] % 'Z') + ('A' - 1));
                }

                i++;

            }
            //tmp_str[i] = (char)0;


            str = tmp_str.ToString().ToUpper();

            return str;
        }

        String ceaser_decrypt(String str, int key)
        {
            StringBuilder tmp_str = new StringBuilder(str);
            int i = 0;
            while (i < tmp_str.Length)
            {

                if (tmp_str[i] != ' ')
                {
                    tmp_str[i] = (char)(tmp_str[i] - key);
                }

                if (((tmp_str[i] < 'a') && (tmp_str[i] > 'Z')))
                {
                    tmp_str[i] = (char)(('z' + 1) - ('a' - tmp_str[i]));
                }
                else if ((tmp_str[i] < 'A') && (tmp_str[i] > ' '))
                {
                    tmp_str[i] = (char)(('Z' + 1) - ('A' - tmp_str[i]));
                }

                i++;

            }

            str = tmp_str.ToString().ToUpper();

            return str;
        }


        /**********************************************END OF CEASER FUNCTIONS*********************************************************
        ********************************************************************************************************************************/

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnchoose_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "txt files (*.txt*)|*.txt*|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string a = File.ReadAllText(openFileDialog1.FileName);
                rtxtbanro.Text = a;
            }
        }

        private void btnopenkey_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "txt files (*.txt*)|*.txt*|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string a = File.ReadAllText(openFileDialog1.FileName);
                txtkey.Text = a;
            }
        }

        private void resetValue()
        {
            rtxtbanro.ResetText();
            rtxtbanma.ResetText();
            txtkey.ResetText();
            txtKetQua.ResetText();
            txt_e.ResetText();
            txt_p.ResetText();
            txt_q.ResetText();
            txt_anpha.ResetText();
            txt_Xa.ResetText();
            txt_Xb.ResetText();
        }
        private void cipher_type_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cipher_type.Text.ToString() == "Ceaser")
            {
                txt_e.Enabled = false;
                txt_p.Enabled = false;
                txt_q.Enabled = false;
                txt_anpha.Enabled = false;
                txtkey.Enabled = true;
                rtxtbanma.Enabled = true;
                rtxtbanro.Enabled = true;
                txt_Xa.Enabled = false;
                txt_Xb.Enabled = false;
                btntinhkhoabm.Visible = false;
                btn_Decrypt.Visible = true;
                btn_Encrypt.Visible = true;
            }
            if (cipher_type.Text.ToString() == "Vingenre")
            {
                txt_e.Enabled = false;
                txt_p.Enabled = false;
                txt_q.Enabled = false;
                txtkey.Enabled = true;
                rtxtbanma.Enabled = true;
                rtxtbanro.Enabled = true;
                txt_anpha.Enabled = false;
                txt_Xa.Enabled = false;
                txt_Xb.Enabled = false;
                btntinhkhoabm.Visible = false;
                btn_Decrypt.Visible = true;
                btn_Encrypt.Visible = true;
            }
            else if (cipher_type.Text.ToString() == "PlayFair")
            {
                txt_e.Enabled = false;
                txt_p.Enabled = false;
                txt_q.Enabled = false;
                txtkey.Enabled = true;
                rtxtbanma.Enabled = true;
                rtxtbanro.Enabled = true;
                txt_anpha.Enabled = false;
                txt_Xa.Enabled = false;
                txt_Xb.Enabled = false;
                btntinhkhoabm.Visible = false;
                btn_Decrypt.Visible = true;
                btn_Encrypt.Visible = true;
            }
            else if (cipher_type.Text.ToString() == "RailFence")
            {
                txt_e.Enabled = false;
                txt_p.Enabled = false;
                txt_q.Enabled = false;
                txtkey.Enabled = true;
                rtxtbanma.Enabled = true;
                rtxtbanro.Enabled = true;
                txt_anpha.Enabled = false;
                txt_Xa.Enabled = false;
                txt_Xb.Enabled = false;
                btntinhkhoabm.Visible = false;
                btn_Decrypt.Visible = true;
                btn_Encrypt.Visible = true;
            }
            else if (cipher_type.Text.ToString() == "Mã hóa hàng")
            {
                txt_e.Enabled = false;
                txt_p.Enabled = false;
                txt_q.Enabled = false;
                txtkey.Enabled = true;
                rtxtbanma.Enabled = true;
                rtxtbanro.Enabled = true;
                txt_anpha.Enabled = false;
                txt_Xa.Enabled = false;
                txt_Xb.Enabled = false;
                btntinhkhoabm.Visible = false;
                btn_Decrypt.Visible = true;
                btn_Encrypt.Visible = true;
            }
            else if (cipher_type.Text.ToString() == "DES")
            {
                txt_e.Enabled = false;
                txt_p.Enabled = false;
                txt_q.Enabled = false;
                txt_anpha.Enabled = false;
                txt_Xa.Enabled = false;
                txt_Xb.Enabled = false;
                btntinhkhoabm.Visible = false;
                btn_Decrypt.Visible = true;
                btn_Encrypt.Visible = true;
                txtkey.Enabled = true;
                rtxtbanma.Enabled = true;
                rtxtbanro.Enabled = true;
            }
            else if (cipher_type.Text.ToString() == "RSA")
            {
                txt_e.Enabled = true;
                txt_p.Enabled = true;
                txt_q.Enabled = true;
                txtkey.Enabled = false;
                txt_anpha.Enabled = false;
                txt_Xa.Enabled = false;
                txt_Xb.Enabled = false;
                btntinhkhoabm.Visible = false;
                btn_Decrypt.Visible = true;
                btn_Encrypt.Visible = true;
                rtxtbanma.Enabled = true;
                rtxtbanro.Enabled = true;
            }
            else if (cipher_type.Text.ToString() == "Diffie_Hellman")
            {
                txt_e.Enabled = false;
                txt_p.Enabled = false;
                txt_q.Enabled = true;
                txtkey.Enabled = false;
                rtxtbanma.Enabled = false;
                rtxtbanro.Enabled = false;
                txt_anpha.Enabled = true;
                txt_Xa.Enabled = true;
                txt_Xb.Enabled = true;
                btntinhkhoabm.Visible = true;
                btn_Decrypt.Visible = false;
                btn_Encrypt.Visible = false;
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            resetValue();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btntinhkhoabm.Visible = false;
        }

        private void btntinhkhoabm_Click(object sender, EventArgs e)
        {
            diff_encrypt();
        }
    }
}
