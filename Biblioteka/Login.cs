using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Biblioteka
{
    public partial class LoginForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=master;Integrated Security=True");
        int count = 0;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from library_person where username = '" + txtUsername.Text + "' and password='" + txtPass.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            count = Convert.ToInt32(dt.Rows.Count.ToString());
            if (count == 0)
            {
                MessageBox.Show("Nazwa użytkownika lub hasło są niepoprawne");
            }
            else
            {
                this.Hide();
                mdi_user mu = new mdi_user();
                mu.Show();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }
    }
}
