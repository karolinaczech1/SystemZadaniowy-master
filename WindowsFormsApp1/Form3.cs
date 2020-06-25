using Renci.SshNet.Common;
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
using System.Security.Cryptography.X509Certificates;


namespace WindowsFormsApp1
{
    public partial class Form3 : MetroFramework.Forms.MetroForm
    {
        private Form1 form1;
        int id; //id zadania (takie jak w bazie)
        public Form3(Form1 glowna)
        {
            InitializeComponent();
            form1 = glowna;
            Label_ID.Text = "ID zadania: " + form1.TextBoxDetailsID.Text;
            id = Convert.ToInt32(form1.TextBoxDetailsID.Text);
            LabelDodanePrzez.Text = "Dodane przez: " + form1.Pobierz_Zadanie(form1.Znajdz_index_na_liscie(id.ToString()), "Dodane_przez");

            ComboBoxEdytujPriorytet.Text = form1.Pobierz_Zadanie(form1.Znajdz_index_na_liscie(id.ToString()), "Priorytet").ToString();
            form1.Wczytaj_wykonawcow(ComboBoxEdytujWykonawce);
            ComboBoxEdytujWykonawce.Text = form1.Pobierz_Zadanie(form1.Znajdz_index_na_liscie(id.ToString()), "Wykonawca").ToString();

            if (form1.Pobierz_Zadanie(form1.Znajdz_index_na_liscie(id.ToString()), "Termin").ToString() != string.Empty)
            {
                CheckBoxTermin.Checked = true;
                dateTimePickerData.Text = (form1.Pobierz_Zadanie(form1.Znajdz_index_na_liscie(id.ToString()), "Termin")).ToString();
            }
            else if(form1.Pobierz_Zadanie(form1.Znajdz_index_na_liscie(id.ToString()), "Termin") == null || form1.Pobierz_Zadanie(form1.Znajdz_index_na_liscie(id.ToString()), "Termin").ToString() == string.Empty)
            {
                CheckBoxTermin.Checked = false;
                dateTimePickerTime.Text = (form1.Pobierz_Zadanie(form1.Znajdz_index_na_liscie(id.ToString()), "Termin")).ToString();
            }
            

            TextBoxEdycjZadania.Text = form1.Pobierz_Zadanie(form1.Znajdz_index_na_liscie(id.ToString()), "Zadanie").ToString();
            TextBoxEdytujOpis.Text = form1.Pobierz_Zadanie(form1.Znajdz_index_na_liscie(id.ToString()), "Opis").ToString();
            TextBoxEdytujRodzajZadania.Text = form1.Pobierz_Zadanie(form1.Znajdz_index_na_liscie(id.ToString()), "Rodzaj").ToString();

            if(Convert.ToBoolean(form1.Pobierz_Zadanie(form1.Znajdz_index_na_liscie(id.ToString()), "Status")) == true)
            {
                CheckBoxEdytujStatus.Checked = true;
                CheckBoxEdytujStatus.Text = "wykonane";
                LabelDataWykonania.Show();
                TextBoxDataWykonania.Show();
                TextBoxDataWykonania.Text = form1.Pobierz_Zadanie(form1.Znajdz_index_na_liscie(id.ToString()), "Data_wykonania").ToString();
            }
            else
            {
                LabelDataWykonania.Hide();
                TextBoxDataWykonania.Hide();
                CheckBoxEdytujStatus.Checked = false;
                TextBoxDataWykonania.Text = null;
                CheckBoxEdytujStatus.Text = "niewykonane";
            }
        }

        private void ButtonZapiszZmiany_Click(object sender, EventArgs e)
        {
            //edycja w bazie
            Wprawdz_zmiany_do_bazy();
            if(zmieniono_wbazie == true)
            {
                //zmiana na liście Zadania
                form1.Podmien_zadanie(form1.Znajdz_index_na_liscie_ograniczonej(id.ToString()), zmienione_zadanie);
                form1.Podmien_zadanie_we_wszystkich(form1.Znajdz_index_na_liscie(id.ToString()), zmienione_zadanie);
                //odswiezenie datagrid
                form1.Filtrowanie(form1.ComboBoxWykonawcy.Text, form1.ComboBoxStatus.Text);
                //odswiezenie details
                form1.Load_Task_Details(form1.Znajdz_index_na_liscie(id.ToString()));

                MessageBox.Show("Zapisano zmiany.");
                this.Close();
            }
        }

        private void CheckBoxEdytujStatus_CheckedChanged(object sender, EventArgs e)
        { 
            
            if (CheckBoxEdytujStatus.Checked == true)
            {
                CheckBoxEdytujStatus.Text = "wykonane";
                LabelDataWykonania.Show();
                TextBoxDataWykonania.Show();
                TextBoxDataWykonania.Text = DateTime.UtcNow.ToString();
            }
            else if (CheckBoxEdytujStatus.Checked == false)
            {
                CheckBoxEdytujStatus.Text = "niewykonane";
                LabelDataWykonania.Hide();
                TextBoxDataWykonania.Hide();
            }
        }
        
        Tasks zmienione_zadanie;
        bool zmieniono_wbazie = false;
        private void Wprawdz_zmiany_do_bazy()
        {
            int priorytet = Convert.ToInt32(ComboBoxEdytujPriorytet.Text);
            string zadanie = TextBoxEdycjZadania.Text;
            string rodzaj = TextBoxEdytujRodzajZadania.Text;
            string wykonawca = ComboBoxEdytujWykonawce.SelectedItem.ToString();
            string termin;
            if (CheckBoxTermin.Checked == true) termin = dateTimePickerData.Value.ToString("dd-MM-yyyy") + " " + dateTimePickerTime.Text; // + dateTimePickerTime.Value.ToString();
            else termin = null;
            bool status = CheckBoxEdytujStatus.Checked;
            string data_wykonania = TextBoxDataWykonania.Text;
            string opis = TextBoxEdytujOpis.Text;

            try
            {
                DbConnection connection = new DbConnection(form1.Dane[0], form1.Dane[1], form1.Dane[2], form1.Dane[3]);
                MySqlConnection con = connection.polaczenie();
                con.Open();
                MySqlCommand komendaSQL = con.CreateCommand();
                string zapytanie = "UPDATE `zadania` SET `priorytet` = '"+priorytet+"', `zadanie` = '"+zadanie+"', `rodzaj` = '"+rodzaj+"', `wykonawca` = '"+wykonawca+"', `termin_wykonania` = '"+termin+"', `status` = '"+status+"', `data_wykonania` = '"+data_wykonania+"', `opis` = '"+opis+"' "+
                                    "WHERE `zadania`.`id_zadania` = '"+id+"';";
                komendaSQL.CommandText = zapytanie;
                MySqlDataReader r = komendaSQL.ExecuteReader();
                r.Close();
                con.Close();
                zmieniono_wbazie = true;

                System.DateTime data_dodania = Convert.ToDateTime(form1.Pobierz_Zadanie(form1.Znajdz_index_na_liscie(id.ToString()), "Data_dodania"));
                string data_dodania_string = data_dodania.ToString("ddd, dd MMM yyyy HH':'mm ");

                zmienione_zadanie = new Tasks(id, priorytet, zadanie, rodzaj, wykonawca, data_dodania, data_dodania_string, termin, status, data_wykonania, opis, form1.Pobierz_Zadanie(form1.Znajdz_index_na_liscie(id.ToString()), "Dodane_przez").ToString());
            }
            catch (MySqlException ee)
            {
                MessageBox.Show("Wystąpił błąd podczas łączenia z bazą. Nie można edytować.");
            }
        }
        private void ButtonAnuluj_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // TERMIN LUB BRAK TERMINU
        private void CheckBoxTermin_CheckedChanged(object sender, EventArgs e)  //po zaznaczeniu/odznaczeniu checkboxa
        {
            //jeśli jest zaznaczony, to mozna wybrac termin zadania
            if(CheckBoxTermin.Checked == true)
            {
                dateTimePickerData.Show();
                dateTimePickerTime.Show();
            }
            else  //jeśli jest odznaczony, to ukrywany jest wybór terminu
            {
                dateTimePickerData.Hide();
                dateTimePickerTime.Hide();
            }
        }


        

    }
}
