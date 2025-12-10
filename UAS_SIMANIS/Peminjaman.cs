using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UAS_SIMANIS
{
    public partial class Peminjaman : Form
    {
        public Peminjaman()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Dashboard db = new Dashboard();
            db.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Peminjaman_Load(object sender, EventArgs e)
        {
            LoadBarang();
        }

        private void LoadBarang()
        {
            try
            {
                DB db = new DB();
                string query = "SELECT item_id, item_name FROM inventaris";

                db.Open(); // Use the correct method to open the connection

                MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    comboBarang.Items.Add(new
                    {
                        Text = reader["item_name"].ToString(),
                        Value = reader["item_id"].ToString()
                    });
                }

                comboBarang.DisplayMember = "Text";   // Yang tampil
                comboBarang.ValueMember = "Value";    // Yang dikirim ke DB

                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}
