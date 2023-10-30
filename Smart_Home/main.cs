using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Smart_Home
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            cs = new EquipementService();
            zs = new ZoneService();
            loadlistZone();
            loadEquipement();
            load();
            loadstatus();
            loadetat();
            loadlistZoneSupprimer();


        }

        public String parametres = "SERVER=127.0.0.1; DATABASE=smart_home; UID=root; PASSWORD=";
        private EquipementService cs;
        private ZoneService zs;
        private static int id;
        
        private void loadEquipement()
        {
            listeEquipement.DataSource = null;

            DataTable data = new DataTable();

            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();

            String request = "select * from equipement";
            MySqlCommand cmd = new MySqlCommand(request, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(data);

            listeEquipement.DataSource = data;
            connection.Close();
        }
        public void load()
        {
            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();

            String request = "SELECT idZone FROM zone";
            MySqlCommand cmd = new MySqlCommand(request, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["idZone"].ToString());
            }
            reader.Close();
        }
        public void loadlistZone()
        {
            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();

            String request = "SELECT nom FROM listezone";
            MySqlCommand cmd = new MySqlCommand(request, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                listZone.Items.Add(reader["nom"].ToString());
            }
            reader.Close();

        }
        public void loadlistZoneSupprimer()
        {
            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();

            String request = "SELECT nom FROM zone";
            MySqlCommand cmd = new MySqlCommand(request, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox4.Items.Add(reader["nom"].ToString());
            }
            reader.Close();

        }

        public void loadstatus()
        {
            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();

            String request = "SELECT status FROM equipement";
            MySqlCommand cmd = new MySqlCommand(request, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox2.Items.Add(reader["status"].ToString());
            }
            reader.Close();
        }
        public void loadetat()
        {
            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();

            String request = "SELECT etat FROM equipement";
            MySqlCommand cmd = new MySqlCommand(request, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                comboBox3.Items.Add(reader["etat"].ToString());

            }
            reader.Close();
        }

        private void Btn_Ajouter_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();
            String nom = textBox1.Text;
            int zone = int.Parse(comboBox1.Text);
            string status = comboBox2.Text;
            string etat = comboBox3.Text;
            MySqlCommand cmd = connection.CreateCommand();
            Equipement c = new Equipement(nom, status, etat, zone);
            cs.create(c);
            loadEquipement();
            load();
            loadstatus();
            loadetat();
            connection.Close();
            textBox1.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();

        }

        private void Btn_Modifier_Click(object sender, EventArgs e)
        {
            String nom = textBox1.Text;
            int zone = int.Parse(comboBox1.Text);
            string status = comboBox2.Text;
            string etat = comboBox3.Text;


            Equipement c = new Equipement(nom, status, etat, zone);
            cs.update(c, id);
            loadEquipement();
            load();
            loadstatus();
            loadetat();
            textBox1.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();

        }

        private void Btn_Supprimer_Click(object sender, EventArgs e)
        {
            cs.delete(id);
            loadEquipement();
            textBox1.Clear();
            load();
            loadstatus();
            loadetat();
        }

        private void listeCapteurs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(listeEquipement.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text =  listeEquipement.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBox1.Text = listeEquipement.Rows[e.RowIndex].Cells[5].Value.ToString();
            comboBox2.Text = listeEquipement.Rows[e.RowIndex].Cells[3].Value.ToString();
            comboBox3.Text = listeEquipement.Rows[e.RowIndex].Cells[4].Value.ToString();
        }


        private void Actualiserbtn_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            load();
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "deconnecter")
            {
                comboBox3.Visible = false;
            }
            else
            {
                comboBox3.Visible = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login frm = new Login();
            frm.ShowDialog();
            this.Close();
        }

        private void AjouterZone_Click(object sender, EventArgs e)
        {

            /* MySqlConnection connection = new MySqlConnection(parametres);
             connection.Open();
             String zone = textBox3.Text;
             MySqlCommand cmd = connection.CreateCommand();
             Zone z = new Zone(zone);
             zs.create(z);

             connection.Close();
             textBox3.Clear();
            */

            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();

            string zone = listZone.Text;

            MySqlCommand cmd = connection.CreateCommand();
            Zone d = new Zone(zone);
            zs.create(d);
            connection.Close();
            if (zone == "saloon")
            {
                sallon.Visible = true;
            }
            else if (zone == "chambre_coucher")
            {
                chambre_coucher.Visible = true;
            }
            else if (zone == "chambre_coucher2")
            {
                chambre_coucher2.Visible = true;
            }
            else if (zone == "chambre")
            {
                chambre.Visible = true;
            }
            else if (zone == "cuisine")
            {
                cuisine.Visible = true;
            }
            else if (zone == "couloir")
            {
                couloir.Visible = true;
            }
            else if (zone == "toilette")
            {
                toilette.Visible = true;
            }
            else if (zone == "escalier")
            {
                escalier.Visible = true;
            }
            else if (zone == "saloon2")
            {
                saloon2.Visible = true;
            }
            else if (zone == "douche")
            {
                douche.Visible = true;
            }
            else if (zone == "garage")
            {
                garage.Visible = true;
            }


        }

        private void btn_sup_zone_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(parametres);
            connection.Open();
            string nom = comboBox4.Text;
            MySqlCommand cmd = connection.CreateCommand();
            zs.delete(nom);
            loadEquipement();
            load();
            loadlistZoneSupprimer();
            loadstatus();
            loadetat();
            connection.Close();
        }
    }
}
