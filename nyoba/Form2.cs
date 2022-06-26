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

namespace nyoba
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-UP691C2\IQBAL;Initial Catalog=tratix;Integrated Security=True");

        private void button2_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO account VALUES (@username, @password)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@username", textusername.Text);
                cmd.Parameters.AddWithValue("@password", textpass.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data baru telah ditambahkan", "Disimpan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool IsValid()
        {
            if (textusername.Text == String.Empty)
            {
                MessageBox.Show("Username tidak boleh kosong", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 a = new Form1();
            a.Show();
        }
    }
}
