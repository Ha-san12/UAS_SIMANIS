using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Tambahkan ini kalau mau akses MySQL

namespace UAS_SIMANIS
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        // Event untuk panel (boleh dikosongin atau dihapus kalau gak dipakai)
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }

        // Event untuk DataGridView (boleh dikosongin dulu)
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kosongin aja dulu, atau hapus kalau gak dipakai
        }

        // ✅ INI HARUS DI LUAR, SEJAJAR DENGAN METHOD LAIN!
        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadDataPeminjaman();
        }

        private void LoadDataPeminjaman()
        {
            try
            {
                DB db = new DB();

                string query =
                    "SELECT " +
                    "p.peminjaman_id AS 'ID', " +
                    "u.username AS 'Peminjam', " +
                    "i.item_name AS 'Barang', " +
                    "p.borrow_date AS 'Tgl Pinjam', " +
                    "p.return_date AS 'Tgl Kembali', " +
                    "p.status AS 'Status' " +
                    "FROM peminjaman p " +
                    "JOIN users u ON p.user_id = u.user_id " +
                    "JOIN inventaris i ON p.item_id = i.item_id " +
                    "ORDER BY p.peminjaman_id DESC";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, db.GetConnection());
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }



       
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Peminjaman pm = new Peminjaman();
            pm.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Inventaris inv = new Inventaris();
            inv.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Dashboard db = new Dashboard();
            db.Show();
            this.Hide();
        }
    }
}