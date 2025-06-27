using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Security.Cryptography;

namespace GirisEkrani
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string metin = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Veriler/kutuphane_vt.mdb;Persist Security Info=False";
        static OleDbConnection bagla = new OleDbConnection(metin);

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
            


        }
        // Veri Tipleri

        // String (Metinsel)
        // Integer [Int] = Sayısal (Tam Sayı)
        // Boolean [Bool] = Evet / Hayır
        // Double = ondalıklı Sayı


        private void button1_Click(object sender, EventArgs e)
        {
            byte[] encodedPassword = new UTF8Encoding().GetBytes(textBox2.Text+"bardak");

            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
            string encoded = BitConverter.ToString(hash)
   // without dashes
   .Replace("-", string.Empty)
   // make lowercase
   .ToLower();

            MessageBox.Show(encoded);
            string sql = "SELECT * FROM kullanicilar WHERE kullanici_adi ='"+textBox1.Text+"' AND parola='"+textBox2.Text+"'";

            OleDbCommand komut = new OleDbCommand(sql,bagla);

            bagla.Open();
            OleDbDataReader oku = komut.ExecuteReader();
            

            if(oku.Read())
            {
                
                this.Hide();
                KitapEkle yeni = new KitapEkle();
                yeni.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Hatalı");
            }

            bagla.Close();









            /*
            if (textBox1.Text == "mustafa" && textBox2.Text == "123" && checkBox2.Checked == true)
            {
                this.Hide();
                KitapEkle yeni = new KitapEkle();
                yeni.ShowDialog();

            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya Parola yanlış veya koşulları kabul etmediniz.");
            }

            */

        }


    }


}
