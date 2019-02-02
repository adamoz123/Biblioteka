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
    public partial class add_books : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=localhost;Initial Catalog=master;Integrated Security=True");

        public add_books()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into books_info values('" + txtTitle.Text + "','" + txtAuthor.Text + "','" + txtPubDate.Text + "','" + txtBuyDate.Text + "'," + txtPrice.Text + "," + txtQuantity.Text + ")";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Dodano ksizke");

            txtTitle.Text = "";
            txtAuthor.Text = "";
            txtPubDate.Text = "";
            txtBuyDate.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
        }
    }
}
