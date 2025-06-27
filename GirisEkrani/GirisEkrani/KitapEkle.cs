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



namespace GirisEkrani
{
    public partial class KitapEkle: Form
    {
        public KitapEkle()
        {
            InitializeComponent();
        }

        static string metin = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Veriler/kutuphane_vt.mdb";
        static OleDbConnection baglanti = new OleDbConnection(metin);




        private void KitapEkle_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime su_an = DateTime.Now;

            int gun = su_an.Day;
            int ay = su_an.Month;
            int yil = su_an.Year;

            string tarih = gun.ToString() + "." + ay.ToString() + "." + yil.ToString();
            string tarih2 = su_an.ToString("dd.MM.yyyy");
            label6.Text = tarih;

            string kitap_adi = textBox1.Text;
            string yazar = textBox2.Text;
            string tur = comboBox1.Text;
            int sayfa_sayisi = Convert.ToInt32(textBox3.Text);
            string konum = textBox4.Text;




        }

        private void KitapEkle_Load(object sender, EventArgs e)
        {
            verileri_goster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            verileri_goster();
        }

        void verileri_goster()
        {
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM kitaplar", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
