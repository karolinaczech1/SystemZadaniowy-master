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
using MySql.Data;

namespace WindowsFormsApp1
{
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {

        private Form1 form1;
        public Form2(Form1 glowna)
        {
            InitializeComponent();
            form1 = glowna;

            Get_Types(Rodzaje);
            Load_Types();
            Load_wykonawcy();
            ComboBoxPriorytet.SelectedItem = "5";
            ComboBoxWykonawca.SelectedItem = form1.zalogowany_user;
            ComboBoxRodzajZadania.SelectedItem = "opisy";

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        List<Types> Rodzaje = new List<Types>();
        public void Get_Types(List<Types> lista)
        {
            try
            {
                DbConnection connection = new DbConnection(form1.Dane[0], form1.Dane[1], form1.Dane[2], form1.Dane[3], form1.Dane[4]);
                MySqlConnection con = connection.polaczenie();
                con.Open();
                MySqlCommand komendaSQL = con.CreateCommand();
                komendaSQL.CommandText = "SELECT * from rodzaje_zadan";
                MySqlDataReader r = komendaSQL.ExecuteReader();
                while(r.Read())
                {
                    int id_rodzaju = Convert.ToInt32(r["id_rodzaju"]);
                    string rodzaj = r["rodzaj"].ToString();
                    Types rodzaj_zadania = new Types(id_rodzaju, rodzaj);
                    lista.Add(rodzaj_zadania);
                }
                r.Close();
                con.Close();
            }
            catch (MySqlException ee)
            {
                MessageBox.Show("Wystąpił błąd podczas łączenia z bazą.");

            }
        }
        public void Load_Types()
        {
            ComboBoxRodzajZadania.Items.Clear();
            for (int i = 0; i < Rodzaje.Count; i++)
            {
                ComboBoxRodzajZadania.Items.Add(Rodzaje[i].rodzaj);
            }
        }
        private void Load_wykonawcy()
        {
            ComboBoxWykonawca.Items.Clear();
            for(int i=0; i<form1.Uzytkownicy.Count; i++)
            {
                ComboBoxWykonawca.Items.Add(form1.Uzytkownicy[i].nazwa_uzytkownika);
            }
        }
       

        public void Add_Type(string rodzaj) 
        {
            bool czy_istnieje_rodzaj = false;
            for (int i = 0; i < Rodzaje.Count; i++)
            {
                if (Rodzaje[i].rodzaj == rodzaj) 
                { 
                    czy_istnieje_rodzaj = true;
                    break;
                }
            }
                if(czy_istnieje_rodzaj == false)
                {
                    int nowe_id = (Rodzaje[Rodzaje.Count - 1].id_rodzaju) + 1;
                  
                    try
                     {
                         DbConnection connection = new DbConnection(form1.Dane[0], form1.Dane[1], form1.Dane[2], form1.Dane[3], form1.Dane[4]);
                         MySqlConnection con = connection.polaczenie();
                         con.Open();
                         MySqlCommand komendaSQL = con.CreateCommand();
                         komendaSQL.CommandText = "INSERT INTO `rodzaje_zadan` (`id_rodzaju`, `rodzaj`) VALUES (" + nowe_id + ", '" + rodzaj + "');";
                         MySqlDataReader r = komendaSQL.ExecuteReader();
                         r.Close();
                         con.Close();
                         Types rodzaj_zadania = new Types(nowe_id, rodzaj);
                         Rodzaje.Add(rodzaj_zadania);
                         Load_Types();
                     }
                     catch (MySqlException ee)
                     {
                         MessageBox.Show("Wystąpił błąd podczas łączenia z bazą.");

                     } 
                ComboBoxRodzajZadania.Text = rodzaj;
                }
                else
                {
                    ComboBoxRodzajZadania.Text = rodzaj;
                }
            
        }

        bool dodano = false;
        private void Dodaj_zadanie()
        {
            if (form1.zalogowany == true)
            {
                int nowe_id = Convert.ToInt32(form1.Pobierz_Zadanie(0, "last_db_id")) + 1;
                int priorytet = Convert.ToInt32(ComboBoxPriorytet.Text);
                string zadanie = TextBoxTytulZadania.Text;
                string rodzaj;
                string wykonawca = ComboBoxWykonawca.SelectedItem.ToString();

                System.DateTime data_dodania = DateTime.UtcNow.ToLocalTime();
                string data_dodania_string = data_dodania.ToString("ddd, dd MMM yyyy HH':'mm ");

                string termin;
                if(CheckBoxTermin.Checked == true)
                {
                    dateTimePickerData.Show();
                    dateTimePickerTime.Show();
                    termin = dateTimePickerData.Value.ToString("dd-MM-yyyy") +" "+ dateTimePickerTime.Text;
                }
                else
                {
                    dateTimePickerData.Hide();
                    dateTimePickerTime.Hide();
                    termin = string.Empty;
                }
                bool status = false;
                string data_wykonania = null;
                string opis = TextBoxOpisZadania.Text;
                string dodane_przez = form1.zalogowany_user;
                if (zadanie != string.Empty)
                {
                    if (CheckBoxInnyRodzaj.Checked == true)
                    {
                        Add_Type(TextBoxEdytujRodzajZadania.Text);
                        rodzaj = TextBoxEdytujRodzajZadania.Text;
                    }
                    else
                    {
                        rodzaj = ComboBoxRodzajZadania.Text;
                    }
                    //dodanie do bazy danych
                    string zapytanie = "INSERT INTO `zadania` (`id_zadania`, `priorytet`, `zadanie`, `rodzaj`, `wykonawca`, `data_dodania`, `termin_wykonania`, `status`, `data_wykonania`, `opis`, `dodane_przez`) " +
                             "VALUES (" + nowe_id + ", " + priorytet + ", '" + zadanie + "', '" + rodzaj + "', '" + wykonawca + "', '" + data_dodania.ToString("yyyy-MM-dd H:mm:ss") + "', '" + termin + "', " + 0 + ", '" + data_wykonania + "', '" + opis + "', '" + dodane_przez + "');";
                    form1.BazaDanych(zapytanie, form1.Dane[0], form1.Dane[1], form1.Dane[2], form1.Dane[3], form1.Dane[4]); 
                    //utworzenie obiektu
                    Tasks nowe_zadanie = new Tasks(nowe_id, priorytet, zadanie, rodzaj, wykonawca, data_dodania, data_dodania_string, termin, status, data_wykonania, opis, dodane_przez);
                    //dodanie do listy
                    form1.Dodaj_Zadanie_do_listy_wszystkich_zadan(nowe_zadanie);
                    form1.Dodaj_Zadanie_do_listy(nowe_zadanie);
                    //odswiezenie datagridview
                    form1.metroGrid1.Rows.Add(form1.konwersja(nowe_zadanie));
                    form1.DateTimeZakresDatDo.Value = nowe_zadanie.Data_dodania;

                    form1.Filtrowanie(form1.ComboBoxWykonawcy.Text, form1.ComboBoxStatus.Text);
                    form1.Sortowanie();
                    dodano = true;
                    form1.Display_first_task_details();
                    
                }
                else MessageBox.Show("Uzupełnij pole \"zadanie");
            }
            else
            {
                MessageBox.Show("Nie możesz dodać zadania, ponieważ nie jesteś zalogowany.");
            }
        }
        private void ButtonDodajZadanie_Click(object sender, EventArgs e)
        {
            Dodaj_zadanie();
            if(dodano == true) this.Close();
        }

        private void ButtonDodajKolejne_Click(object sender, EventArgs e)
        {
            Dodaj_zadanie();
            ComboBoxPriorytet.SelectedItem = null; 
            TextBoxTytulZadania.Text = "";
            TextBoxEdytujRodzajZadania.Text = "";
            TextBoxOpisZadania.Text = "";
            ComboBoxPriorytet.SelectedItem = "5";
            ComboBoxWykonawca.SelectedItem = form1.zalogowany_user;
            ComboBoxRodzajZadania.SelectedItem = "opisy";
        }

        private void CheckBoxTermin_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxTermin.Checked == true)
            {
                CheckBoxTermin.Text = " wybierz:";
                dateTimePickerData.Show();
                dateTimePickerTime.Show();
                
            }
            else if (CheckBoxTermin.Checked == false)
            {
                CheckBoxTermin.Text = "brak terminu";
                dateTimePickerData.Hide();
                dateTimePickerTime.Hide();
            }
        }


        Form3 form3;
        Form2(Form3 form)
        {
            this.form3 = form;
        }

        


    }
}
