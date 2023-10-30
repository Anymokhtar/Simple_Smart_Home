using System;
using System.Collections.Generic;
using System.Text;


namespace Smart_Home
{
    class Zone
    {
        private int id;
        private String nom;
        private static int cmp = 0;

        public Zone(int id, string zone)
        {
            this.id = id;
            this.nom = zone;
        }

        public Zone(string nom)
        {
            this.id = cmp++;
            this.nom = nom;
        }
        public int getId()
        {
            return this.id;
        }
        public void setId(int id)
        {
            this.id = id;
        }
        public void Setnom(string nom)
        {
            this.nom = nom;
        }
        public string getnom()
        {
            return this.nom;
        }
    }
}
