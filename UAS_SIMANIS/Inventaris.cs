using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace UAS_SIMANIS
{
    public partial class Inventaris : Form
    {
        public Inventaris()
        {
            InitializeComponent();
        }

        // Event Load — mirip Dashboard.cs
        private void Inventaris_Load(object sender, EventArgs e)
        {
            LoadDataInventaris();
        }

        // Method load data — mirip LoadDataPeminjaman()
        private void LoadDataInventaris()
        {
            try
            {
                DB db = new DB(); // Sama persis kayak di Dashboard

                // Query SELECT sederhana dari tabel inventaris
                string query =
                    "SELECT " +
                    "item_id AS 'ID', " +
                    "item_name AS 'Nama Barang', " +
                    "kategori AS 'Kategori', " +
                    "quantity AS 'Jumlah', " +
                    "status AS 'Status' " +
                    "FROM inventaris " +
                    "ORDER BY item_id ASC";

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

        // Event DataGridView (opsional)
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kosongin aja
        }
    }
}