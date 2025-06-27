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
using System.Runtime.ConstrainedExecution;

namespace Kutuphane
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection bagla = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = kutuphane.mdb");
        string kimlik;


        private void Form1_Load(object sender, EventArgs e)
        {
            kitaplariGoster();
            dataGridView1.Columns[0].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }
        void kitaplariGoster()
        {
            OleDbDataAdapter adaptor = new OleDbDataAdapter("SELECT * FROM kitaplar ", bagla);
            DataTable dt = new DataTable();
            adaptor.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string kitap_adi    = textBox1.Text;
            string yazar_adi    = textBox2.Text;
            string yayin_evi    = textBox3.Text;
            string sayfa_sayisi = textBox4.Text;
            string yer          = textBox5.Text;
            string tarih        = DateTime.Now.ToString("dd.MM.yyyy");


            string sql = "INSERT INTO kitaplar " +
                "(kitap_adi,yazar,yayin_evi,sayfa_sayisi,yer,eklenmeTarihi) " +
                "VALUES ('"+ kitap_adi + " ','"+ yazar_adi + "','" + yayin_evi +"','" + sayfa_sayisi + "','"+ yer + "','" +tarih+ "')";
            
            OleDbCommand sorgu = new OleDbCommand(sql, bagla);

            bagla.Open();
            sorgu.ExecuteNonQuery();
            bagla.Close();

            kitaplariGoster();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            kimlik = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM kitaplar WHERE Kimlik="+kimlik;
            OleDbCommand sorgu = new OleDbCommand(sql, bagla);

            bagla.Open();
            sorgu.ExecuteNonQuery();
            bagla.Close();

            kitaplariGoster();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string kitap_adi = textBox1.Text;
            string yazar_adi = textBox2.Text;
            string yayin_evi = textBox3.Text;
            string sayfa_sayisi = textBox4.Text;
            string yer = textBox5.Text;

            string sql = "UPDATE kitaplar " +
                "SET kitap_adi='"+ kitap_adi + "',yazar='"+ yazar_adi + "',yayin_evi='"+ yayin_evi + "',sayfa_sayisi='"+ sayfa_sayisi + "',yer='"+yer+"' " +
                "WHERE Kimlik = " + kimlik;

            OleDbCommand sorgu = new OleDbCommand(sql, bagla);

            bagla.Open();
            sorgu.ExecuteNonQuery();
            bagla.Close();

            kitaplariGoster();
        }
    }
}
