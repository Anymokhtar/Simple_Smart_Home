using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Smart_Home
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string cs = @"server=localhost;userid=root;PASSWORD=;database=smart_home";
            var con = new MySqlConnection(cs);

            try
            {
                con.Open();
                string stm = "select name,password from login WHERE name =@Name AND password =@Password";
                var cmd = new MySqlCommand(stm, con);

                cmd.Parameters.AddWithValue("@Name", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.ExecuteReader();
                main_form();
            }
            catch (Exception )
            {
                Console.WriteLine("login failed");

            }
            con.Close();
         
        }
        private void main_form()
        {
            this.Hide();
            main frm = new main();
            frm.ShowDialog();
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
    }
}
