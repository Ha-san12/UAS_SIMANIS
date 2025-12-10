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
            LoadDataPeminjaman(); // Panggil method load data
        }

        // Method untuk ambil data dari database
        private void LoadDataPeminjaman()
        {
            try
            {
                DB db = new DB();
                string query = "SELECT id, nama_peminjam AS Peminjam, nama_barang AS Barang, " +
                               "tgl_pinjam AS [Tgl Pinjam], status AS Status " +
                               "FROM peminjaman";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, db.GetConnection());
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Dashboard_Load_1(object sender, EventArgs e)
        {

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

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}