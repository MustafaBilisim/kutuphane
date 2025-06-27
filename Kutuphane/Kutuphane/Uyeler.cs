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

namespace Kutuphane
{
    public partial class Uyeler: Form
    {
        public Uyeler()
        {
            InitializeComponent();
        }

        OleDbConnection bagla = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = kutuphane.mdb");
        string kimlik;

       

        void uyeleriGoster()
        {
            OleDbDataAdapter adaptor = new OleDbDataAdapter("SELECT * FROM uyeler ", bagla);
            DataTable dt = new DataTable();
            adaptor.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void kitaplariGoster()
        {
            OleDbDataAdapter adaptor = new OleDbDataAdapter("SELECT * FROM kitaplar ", bagla);
            DataTable dt = new DataTable();
            adaptor.Fill(dt);
            dataGridView2.DataSource = dt;
        }
        private void Uyeler_Load(object sender, EventArgs e)
        {
            // Form açıldığı zaman, Paneller üst üste gözüksün
            uyeleriGoster();
            panel2.Location = panel1.Location;
            panel3.Location = panel1.Location;
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Üye seçimi yapılınca, Kitap seçme ekranını göster
            panel1.Visible = false;
            panel2.Visible = true;
            kitaplariGoster();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kitap seçimi de yapıldıktan sonra, özet bilgi ekranını göster
            panel2.Visible = false;
            panel3.Visible = true;
        }
    }
}
