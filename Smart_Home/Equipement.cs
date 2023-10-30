using System;
using System.Collections.Generic;
using System.Text;

namespace Smart_Home
{
    class Equipement
    {
        private string nom;
        private int idzone;
        private string status;
        private string etat;
        private int id;
        private static int cmp = 0;

        public Equipement(int id, string nom, string status, string etat, int idzone)
        {
            this.id = id;
            this.nom = nom;
            this.idzone = idzone;
            this.status = status;
            this.etat = etat;

        }
        public Equipement(string nom, string status, string etat, int idzone)
        {
            this.id = cmp++;
            this.nom = nom;
            this.idzone = idzone;
            this.status = status;
            this.etat = etat;

        }

        public int getId()
        {
            return this.id;
        }
        public void setId(int id)
        {
            this.id = id;
        }
        public void Setzone(int idzone)
        {
            this.idzone = idzone;
        }
        public int getidzone()
        {
            return this.idzone;
        }
        public void Setnom(string nom)
        {
            this.nom = nom;
        }
        public string getnom()
        {
            return this.nom;
        }
        public void setStatus(string status)
        {
            this.status = status;
        }
        public string getstatus()
        {
            return this.status;
        }
        public void setetat(string etat)
        {
            this.etat = etat;
        }
        public string getetat()
        {
            return this.etat;
        }
    }
}
