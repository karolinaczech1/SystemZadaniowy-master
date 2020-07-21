using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Drawing;
using System.Net.Mail;
using MetroFramework.Controls;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Tasks
    {
        public int Id_zadania { get; set; }
        public int Priorytet { get; set; }
        public string Zadanie { get; set; }
        public string Rodzaj { get; set; }
        public string Wykonawca { get; set; }
        public System.DateTime Data_dodania {get; set;}
        public string Data_dodania_string { get; set; }
        public string Termin { get; set; }
        public bool Status { get; set; }
        public string Data_wykonania { get; set; }
        public string Opis { get; set; }
        public string Dodane_przez { get; set; }


        public Tasks(int i,  int prio, string zad, string rodz, string wyk, System.DateTime dd, string dds, string term, bool stat, string dw, string op, string dod)
        {
            this.Id_zadania = i;
            this.Priorytet = prio;
            this.Zadanie = zad;
            this.Rodzaj = rodz;
            this.Wykonawca = wyk;
            this.Data_dodania = dd;
            this.Data_dodania_string = dds;
            this.Termin = term;
            this.Status = stat;
            this.Data_wykonania = dw;
            this.Opis = op;
            this.Dodane_przez = dod;
        }
    }

    public class Users
    {
        public int id_uzytkownika { get; set; }
        public string nazwa_uzytkownika { get; set; }

        public Users(int id, string name)
        {
            this.id_uzytkownika = id;
            this.nazwa_uzytkownika = name;
        }
    }

    public class Types
    {
        public int id_rodzaju { get; set; }
        public string rodzaj { get; set; }
        
        public Types(int id, string rodzaj)
        {
            this.id_rodzaju = id;
            this.rodzaj = rodzaj;
        }
    }

    public class Today
    {
        public Panel panel { get; set; }
        public MetroTile tile { get; set; }
        public MetroCheckBox checkbox { get; set; }
        public MetroLabel label { get; set; }
        public Tasks task { get; set;}

        public Today(Panel panel, MetroTile tile, MetroCheckBox checkbox, MetroLabel label, Tasks task)
        {
            this.panel = panel;
            this.tile = tile;
            this.checkbox = checkbox;
            this.label = label;
            this.task = task;

         
        }
    }
    
}
