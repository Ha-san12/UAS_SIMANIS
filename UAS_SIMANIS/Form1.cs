using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UAS_SIMANIS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // PASTIKAN METHOD INI ADA ↓↓↓
        private void button1_Click(object sender, EventArgs e)
        {
            // Kode login Anda di sini
            DB db = new DB();
            string username = Username.Text;
            string password = Password.Text;

            string query = "SELECT * FROM users WHERE username=@user AND password=@pass";

            using (var conn = db.GetConnection())
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password);

                db.Open(); // matches DB.cs
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        MessageBox.Show("Login berhasil!");
                        this.Hide();
                        new Dashboard().Show();
                    }
                    else
                    {
                        MessageBox.Show("Username atau password salah!");
                    }
                }
                db.CloseConnection();
            }
        }

        // Method lainnya...
        private void Form1_Load(object sender, EventArgs e)
        { /* ... */
            {
                // Set ukuran form menjadi 80% dari lebar dan tinggi layar
                this.Width = (int)(Screen.PrimaryScreen.WorkingArea.Width * 0.8);
                this.Height = (int)(Screen.PrimaryScreen.WorkingArea.Height * 0.8);

                // Set posisi form di tengah layar
                this.StartPosition = FormStartPosition.CenterScreen;

                // --- SETUP PLACEHOLDER TEXT ---

                // Inisialisasi placeholder text
                string usernamePlaceholder = "Username";
                string passwordPlaceholder = "Password";

                // Set teks placeholder awal
                Username.Text = usernamePlaceholder;
                Password.Text = passwordPlaceholder;

                // Atur warna teks placeholder (opsional, biar keliatan beda)
                Username.ForeColor = SystemColors.GrayText;
                Password.ForeColor = SystemColors.GrayText;

                // Event saat textbox mendapat fokus (klik atau tab masuk)
                Username.Enter += (s, ev) =>
                {
                    if (Username.Text == usernamePlaceholder)
                    {
                        Username.Text = "";
                        Username.ForeColor = SystemColors.WindowText; // Warna teks normal
                    }
                };

                Password.Enter += (s, ev) =>
                {
                    if (Password.Text == passwordPlaceholder)
                    {
                        Password.Text = "";
                        Password.ForeColor = SystemColors.WindowText;
                    }
                };

                // Event saat textbox kehilangan fokus (klik di luar atau tab keluar)
                Username.Leave += (s, ev) =>
                {
                    if (string.IsNullOrWhiteSpace(Username.Text))
                    {
                        Username.Text = usernamePlaceholder;
                        Username.ForeColor = SystemColors.GrayText;
                    }
                };

                Password.Leave += (s, ev) =>
                {
                    if (string.IsNullOrWhiteSpace(Password.Text))
                    {
                        Password.Text = passwordPlaceholder;
                        Password.ForeColor = SystemColors.GrayText;
                    }
                };
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e) { /* ... */ }
        private void Password_TextChanged(object sender, EventArgs e) { /* ... */ }
        private void label1_Click_1(object sender, EventArgs e) { /* ... */ }
    }
}