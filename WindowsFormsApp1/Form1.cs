
//autorem jest karolina czech
using System;
using System.Runtime;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MetroFramework;
using MySql.Data.MySqlClient;
using MetroFramework.Controls;
using MySqlX.XDevAPI.Relational;
using System.Drawing.Configuration;
using System.Deployment.Internal;
using Google.Protobuf.WellKnownTypes;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace WindowsFormsApp1
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            ComboBoxSortowanie.SelectedIndex = 0;    //domyślne sortowanie wg kolumny 0, czyli ID
            ComboBoxKolumnaSzukania.SelectedIndex = 2;   //domyślne wyszukiwanie w kolumnie 2, czyli zadanie
            
            //Jesli wpisno dane do łączenia z bazą:
            if (File.Exists("database.txt") && Dane[0] != string.Empty)
            {
                
                DataBase();  //próba połączenia z bazą
                Wczytaj_Filtry();
                kolor_terminu_w_dataGrid();
                ComboBoxStatus.SelectedItem = "wszystkie";  //domyslnie filtr na wyświelanie zadań wykonanych i niewykonanych
               
                //Jeślu udało się połączyć z bazą:
                if (connected == true)  
                {
                    TextBoxDBinfo.Text = "Nawiązano połączenie z bazą.";
                    //wczytanie listy userów
                    ShowUsers();
                    if(Wszystkie_Zadania_Z_Bazy.Count >= 1)
                    {
                        DateTimeZakresDatDo.Value = Wszystkie_Zadania_Z_Bazy[0].Data_dodania;   //domyslny zakres dat: od daty dodania pierwszego zadania
                        DateTimeZakresDatOd.Value = Wszystkie_Zadania_Z_Bazy[Wszystkie_Zadania_Z_Bazy.Count - 1].Data_dodania;  //domyślny zakres dat: do daty ostatniego zadania
                    }
                    else
                    {
                        DateTimeZakresDatOd.Text = "20-06-2020";   
                        DateTimeZakresDatDo.Text = "30-12-2020";
                    }
                    

                    
                    if (File.Exists("logowanie.txt"))   //jeśli plik istnieje
                    {
                        Logowanie();  //proba automatycznego zalogowania
                        if(zalogowany == true)
                        {
                            ComboBoxWykonawcy.SelectedItem = zalogowany_user;  //domyślny filtr na wyświetlanie zadań dla zalogowanego usera
                            Filtrowanie(ComboBoxWykonawcy.Text, ComboBoxStatus.Text);
                        }
                        else
                        {
                            ComboBoxWykonawcy.SelectedItem = "wszystkie";
                            Filtrowanie(ComboBoxWykonawcy.Text, ComboBoxStatus.Text);
                            MessageBox.Show("Nie jesteś zalogowany.");
                        }
                    }
                    else 
                    {
                        ComboBoxWykonawcy.SelectedItem = "wszystkie";
                        Filtrowanie(ComboBoxWykonawcy.Text, ComboBoxStatus.Text);
                        MessageBox.Show("Nie jesteś zalogowany.");
                    }
                    metroGrid1.ClearSelection();
                    if(Zadania.Count != 0)
                    {
                        Display_first_task_details(Zadania[Zadania.Count - 1]);   //przy uruchamianiu wyswietlenie szczegółów pierwszego zadania w datagrid

                    }

                }
                else 
                {
                    TextBoxDBinfo.Text = "Nie udało się nawiązać połączenia z bazą.";
                }

            }
            else
            {
                TextBoxDBinfo.Text = "Wprowadź dane do połączenia z bazą.";
            }
            this.metroGrid1.Sort(this.metroGrid1.Columns[0], ListSortDirection.Descending);   //domyślne sortowanie - malejąco według ID
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        /*  ############################## ZMIENNE, LISTY, TABLICE ############################## */
        public string zalogowany_user;
        public bool zalogowany = false;
        public string[] Dane = new string[4];
        public string[] IleDni_KoloryTerminow = new string[6];
        bool connected = false;
        bool uzytkownik_istnieje;
        List<Tasks> Zadania = new List<Tasks>();
        List<Tasks> Wszystkie_Zadania_Z_Bazy = new List<Tasks>();
        public List<Users> Uzytkownicy = new List<Users>();

        Form3 form3;
        Form1(Form3 form)
        {
            this.form3 = form;
        }

        Form2 form2;
        Form1(Form2 form)
        {
            this.form2 = form;
        }




        /*  ############################## ZDARZENIA ############################## */

        /*------------------------------------------------ PRZYCISKI Z USTAWIEŃ  ------------------------------------------------*/

        //przycisk do logowania 
        private void ButtonLogowanie_Click(object sender, EventArgs e)
        {
            //zapis nazwy uzytkownika do pliku
            Is_user_exist(TextBoxUserName.Text);
            if (uzytkownik_istnieje == false)
            {
                zalogowany = false;
                MessageBox.Show("Taki użytkownik nie istnieje.");
                File.WriteAllText("logowanie.txt", String.Empty);
                ComboBoxWykonawcy.SelectedItem = "wszystkie";

            }
            else
            {
                string file_name = "logowanie.txt";
                if (File.Exists(file_name))
                {
                    File.WriteAllText(file_name, String.Empty);
                    FileStream user = new FileStream(file_name, FileMode.Append, FileAccess.Write);
                    StreamWriter writer = new StreamWriter(user);
                    writer.WriteLine(TextBoxUserName.Text);
                    writer.Close();
                    user.Close();
                }
                else
                {
                    FileStream user = new FileStream(file_name, FileMode.CreateNew);
                    StreamWriter writer = new StreamWriter(user);
                    writer.WriteLine(TextBoxUserName.Text);
                    writer.Close();
                    user.Close();
                }
                Logowanie();
                ComboBoxWykonawcy.SelectedItem = zalogowany_user;
            }
        }


        //przycisk do dodawania nowego użytkownika
        private void ButtonDodajUzytkownika_Click(object sender, EventArgs e)
        {
            string nazwa = TextBoxAddUser.Text;
            int ostatnie_id_wbazie = (Uzytkownicy[Uzytkownicy.Count - 1].id_uzytkownika) + 1;
            Is_user_exist(nazwa);
            if (uzytkownik_istnieje == false)
            {
                if (nazwa != null && nazwa != string.Empty && nazwa.Count() > 3)
                {
                    try
                    {
                        DbConnection connection = new DbConnection(Dane[0], Dane[1], Dane[2], Dane[3]);
                        MySqlConnection con = connection.polaczenie();
                        con.Open();
                        MySqlCommand komendaSQL = con.CreateCommand();
                        komendaSQL.CommandText = "INSERT INTO `uzytkownicy` (`id_uzytkownika`, `nazwa`) VALUES (" + ostatnie_id_wbazie + ", '" + nazwa + "');";
                        MySqlDataReader r = komendaSQL.ExecuteReader();
                        r.Close();
                        con.Close();
                        Users user = new Users(ostatnie_id_wbazie, nazwa);
                        Uzytkownicy.Add(user);
                        ShowUsers();
                        Wczytaj_wykonawcow(ComboBoxDetailsWykonawcy);
                    }
                    catch (MySqlException ee)
                    {
                        MessageBox.Show("Wystąpił błąd podczas łączenia z bazą.");

                    }
                    TextBoxAddUser.Text = ostatnie_id_wbazie.ToString();
                }
                else MessageBox.Show("Nazwa użytkownika musi się składać z conajmniej 3 znaków.");
            }
            else
            {
                MessageBox.Show("Użytkownik o takiej nazwie już istnieje. Wybierz inną.");
            }
        }


        //przycisk do łączenia z bazą danych
        private void ButtonSaveDB_Click(object sender, EventArgs e)
        {

            string file_name = "database.txt";
            if (File.Exists(file_name))
            {
                File.WriteAllText(file_name, String.Empty);
                FileStream dane = new FileStream(file_name, FileMode.Append, FileAccess.Write);
                StreamWriter writer = new StreamWriter(dane);
                writer.WriteLine(TextBoxServerID.Text);
                writer.WriteLine(TextBoxDBName.Text);
                writer.WriteLine(TextBoxDBUser.Text);
                writer.WriteLine(TextBoxDBPassword.Text);
                writer.Close();
                dane.Close();
            }
            else
            {
                FileStream dane = new FileStream(file_name, FileMode.CreateNew);
                StreamWriter writer = new StreamWriter(dane);
                writer.WriteLine(TextBoxServerID.Text);
                writer.WriteLine(TextBoxDBName.Text);
                writer.WriteLine(TextBoxDBUser.Text);
                writer.WriteLine(TextBoxDBPassword.Text);
                writer.Close();
                dane.Close();
            }

            DataBase();
        }

       
             



    



        /*------------------------------------------------ SZYBKA EDYCJA W DETAILS, ZMIANA STATUSU ZADANIA w datagrid  ------------------------------------------------*/

        //zmiana wykonawcy zadania w sekji szczegóły
        private void ComboBoxDetailsWykonawcy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nowyWykonawca = ComboBoxDetailsWykonawcy.SelectedItem.ToString();
            int index = Znajdz_index_na_liscie(TextBoxDetailsID.Text);
            int id = Convert.ToInt32(TextBoxDetailsID.Text);
            //zmiana w details
            TextBoxDetailsWykonawca.Text = nowyWykonawca;
            //zmiana w bazie
            try
            {
                DbConnection connection = new DbConnection(Dane[0], Dane[1], Dane[2], Dane[3]);
                MySqlConnection con = connection.polaczenie();
                con.Open();
                MySqlCommand komendaSQL = con.CreateCommand();
                komendaSQL.CommandText = "UPDATE `zadania` SET `wykonawca` = '" + nowyWykonawca + "' WHERE `zadania`.`id_zadania` = " + id + ";";
                MySqlDataReader r = komendaSQL.ExecuteReader();
                r.Close();
                con.Close();
            }
            catch (MySqlException ee)
            {
                MessageBox.Show("Wystąpił błąd podczas łączenia z bazą.");

            }

            //zmiana na liście

            Wszystkie_Zadania_Z_Bazy[index].Wykonawca = nowyWykonawca;
            Zadania[Znajdz_index_na_liscie_ograniczonej(TextBoxDetailsID.Text)].Wykonawca = nowyWykonawca;
            //odswiezenie datagrid ShowRow()
            metroGrid1.Rows.Clear();
            ShowRow(Zadania);

        }


        //zmiana priorytetu zadania w sekcji szczegóły
        private void ComboBoxDetailsZmienPriorytet_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nowyPriorytet = Convert.ToInt32(ComboBoxDetailsZmienPriorytet.SelectedItem);
            int id = Convert.ToInt32(TextBoxDetailsID.Text);
            int index = Znajdz_index_na_liscie(TextBoxDetailsID.Text);
            //zmiana w details
            TextBoxDetailsPriorytet.Text = nowyPriorytet.ToString();
            //zmiana w bazie
            try
            {
                DbConnection connection = new DbConnection(Dane[0], Dane[1], Dane[2], Dane[3]);
                MySqlConnection con = connection.polaczenie();
                con.Open();
                MySqlCommand komendaSQL = con.CreateCommand();
                komendaSQL.CommandText = "UPDATE `zadania` SET `priorytet` = '" + nowyPriorytet + "' WHERE `zadania`.`id_zadania` = " + id + ";";
                MySqlDataReader r = komendaSQL.ExecuteReader();
                r.Close();
                con.Close();
            }
            catch (MySqlException ee)
            {
                MessageBox.Show("Wystąpił błąd podczas łączenia z bazą.");

            }
            //zmiana na liście
            Wszystkie_Zadania_Z_Bazy[index].Priorytet = nowyPriorytet;
            Zadania[Znajdz_index_na_liscie_ograniczonej(TextBoxDetailsID.Text)].Priorytet = nowyPriorytet;
            //odswiezenie datagrid ShowRow()
            metroGrid1.Rows.Clear();
            ShowRow(Zadania);
        }


        //ustawienia potrzebne do zmiany statusu w datagrid, od razu po zaznaczeniu statusu wprowadza zmiany
        private void metroGrid1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 7 && e.RowIndex > -1 && metroGrid1.Rows[e.RowIndex].Cells[7].IsInEditMode)
            {
                metroGrid1.EndEdit();
            }
        }

        //zmiana statusu w datagrid
        private void metroGrid1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int id = Convert.ToInt32(metroGrid1.Rows[e.RowIndex].Cells[0].Value);
                int numerindexu = Znajdz_index_na_liscie(id.ToString());
                int index = Znajdz_index_na_liscie_ograniczonej(id.ToString());
                try
                {
                    DbConnection connection = new DbConnection(Dane[0], Dane[1], Dane[2], Dane[3]);
                    MySqlConnection con = connection.polaczenie();
                    con.Open();
                    MySqlCommand komendaSQL = con.CreateCommand();
                    DateTime thisDay = DateTime.UtcNow.ToLocalTime();
                    if (Convert.ToInt32(metroGrid1.Rows[e.RowIndex].Cells[7].Value) == 1)
                    {
                        Zadania[index].Status = true;
                        Wszystkie_Zadania_Z_Bazy[numerindexu].Status = true;
                        Zadania[index].Data_wykonania = thisDay.ToString();
                        Wszystkie_Zadania_Z_Bazy[numerindexu].Data_wykonania = thisDay.ToString();
                        komendaSQL.CommandText = "UPDATE `zadania` SET `status` = '1', `data_wykonania` = '" + thisDay.ToString() + "' WHERE `zadania`.`id_zadania` = " + id + "; ";
                    }
                    else if (Convert.ToInt32(metroGrid1.Rows[e.RowIndex].Cells[7].Value) == 0)
                    {
                        Zadania[index].Status = false;
                        Wszystkie_Zadania_Z_Bazy[numerindexu].Status = false;
                        Zadania[index].Data_wykonania = null;
                        Wszystkie_Zadania_Z_Bazy[numerindexu].Data_wykonania = null;
                        komendaSQL.CommandText = "UPDATE `zadania` SET `status` = '0', `data_wykonania` = NULL  WHERE `zadania`.`id_zadania` = " + id + "; ";
                    }

                    MySqlDataReader r = komendaSQL.ExecuteReader();
                    r.Close();
                    con.Close();

                    Load_Task_Details(numerindexu);

                    metroGrid1.Rows.Clear();
                    ShowRow(Zadania);

                }
                catch (MySqlException ee)
                {
                    MessageBox.Show("Wystąpił błąd podczas łączenia z bazą.");

                }
            }
        }

        /*------------------------------------------------ WYŚWIETLANIE SZCZEGÓŁÓW PO ZAZNACZENIU ZADANIA  ------------------------------------------------*/

        // ustawienia zaznaczania
        private void metroGrid1_SelectionChanged(object sender, EventArgs e)
        {
            this.metroGrid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.metroGrid1.MultiSelect = false;
        }

        //wyświetlanie szczegółów po kliknięciu na zadanie w tabeli
        private void metroGrid1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                metroTabTaskDetails.Show();
                Load_Task_Details(Znajdz_index_na_liscie(metroGrid1.Rows[e.RowIndex].Cells[0].Value.ToString()));
                ComboBoxDetailsWykonawcy.Text = Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(metroGrid1.Rows[e.RowIndex].Cells[0].Value.ToString())].Wykonawca;
                ComboBoxDetailsZmienPriorytet.Text = Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(metroGrid1.Rows[e.RowIndex].Cells[0].Value.ToString())].Priorytet.ToString();
            }
            zmiana_zakresu_dat(Zadania);  //uwzględnienie zakresu dat
            

            //ZAZNACZANIE
            metroGrid1.ClearSelection(); //po kliknieciu na wiersz nastąpi wyczyszczenie wszyskich zaznaczeń 

            if (kolor(Znajdz_index_na_liscie(metroGrid1.Rows[e.RowIndex].Cells[0].Value.ToString()))[0] == Color.Black)
            {
                metroGrid1.Rows[e.RowIndex].Cells[6].Style.SelectionForeColor = Color.White;
            }
            metroGrid1.Rows[e.RowIndex].Cells[6].Style.SelectionBackColor = kolor(Znajdz_index_na_liscie(metroGrid1.Rows[e.RowIndex].Cells[0].Value.ToString()))[0];
            metroGrid1.Rows[e.RowIndex].Selected = true; //zaznaczenie kliknietego wiersza
        }



        /*------------------------------------------------ ZMIANY FILTRÓW, ZAKRESU DAT, SORTOWANIA  ------------------------------------------------*/

        // zmiana filtru "wykonawca"
        private void ComboBoxWykonawcy_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtrowanie(ComboBoxWykonawcy.Text, ComboBoxStatus.Text);
        }
        //zmiana filtru "status"
        private void ComboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtrowanie(ComboBoxWykonawcy.Text, ComboBoxStatus.Text);
        }

        //zmiana zakresu dat "OD"
        private void DateTimeZakresDatOd_ValueChanged(object sender, EventArgs e)
        {
            zmiana_zakresu_dat(Zadania);
        }
        //zmiana zakresu dat "DO"
        private void DateTimeZakresDatDo_ValueChanged(object sender, EventArgs e)
        {
            zmiana_zakresu_dat(Zadania);
        }

        //Zmiana ustawień sortowania MALEJĄCO LUB ROSNĄCO
        private void CheckBoxMalejaco_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxMalejaco.Checked == true) CheckBoxRosnaco.Checked = false;
            else CheckBoxRosnaco.Checked = true;
            Sortowanie();
        }
        private void CheckBoxRosnaco_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxRosnaco.Checked == true) CheckBoxMalejaco.Checked = false;
            else CheckBoxMalejaco.Checked = true;
            Sortowanie();
        }
        //zmiana kryterium sortowania
        private void ComboBoxSortowanie_SelectedIndexChanged(object sender, EventArgs e) 
        {
            Sortowanie();
        }



        /*------------------------------------------------ WYSZUKIWANIE  ------------------------------------------------*/

        //automatyczne wyszukiwanie po zmianie tekstu TetBoxa z frazą do wszykania
        private void TextBoxSzukanaFraza_TextChanged(object sender, EventArgs e)   //zmiana szukanej frazy
        {
            Wyszukiwanie();
            kolor_terminu_w_dataGrid();

        }




        /*------------------------------------------------ USUWANIE ZADANIA  ------------------------------------------------*/

        //przycisk do usuwania zadania
        private void ButtonUsunZadanie_Click(object sender, EventArgs e)
        {
            if (metroGrid1.Rows.Count != 0)
            {
                int db_id = Convert.ToInt32(TextBoxDetailsID.Text);

                if (Czy_usunac(Znajdz_index_na_liscie_ograniczonej(db_id.ToString())) == true)
                {
                    try
                    {
                        DbConnection connection = new DbConnection(Dane[0], Dane[1], Dane[2], Dane[3]);
                        MySqlConnection con = connection.polaczenie();
                        con.Open();
                        MySqlCommand komendaSQL = con.CreateCommand();
                        komendaSQL.CommandText = "DELETE FROM `zadania` WHERE `zadania`.`id_zadania` = " + db_id + "";
                        MySqlDataReader r = komendaSQL.ExecuteReader();
                        r.Close();
                        con.Close();
                        Zadania.RemoveAt(Znajdz_index_na_liscie_ograniczonej(db_id.ToString()));
                        Wszystkie_Zadania_Z_Bazy.RemoveAt(Znajdz_index_na_liscie(db_id.ToString()));
                        metroGrid1.Rows.Clear();
                        ShowRow(Zadania);
                    }
                    catch (MySqlException ee)
                    {
                        MessageBox.Show("Wystąpił błąd podczas łączenia z bazą.");

                    }
                    metroTabTaskDetails.Hide();
                }
                else
                {

                }
            }
        }

        /*------------------------------------------------ EDYCJA ZADANIA  ------------------------------------------------*/

        //przycisk otwiercjący Form3 z edycją zadania
        private void ButtonEditTask_Click(object sender, EventArgs e)
        {
            if(metroGrid1.Rows.Count != 0)
            {
                Form3 EdytujZadanie = new Form3(this);
                EdytujZadanie.ShowDialog();
            }
        }

        /*------------------------------------------------ DODAWANIE ZADANIA  ------------------------------------------------*/
        
        //przycisk otwierający Form2 z dodawaniem zadania
        private void ButtonNewTask_Click(object sender, EventArgs e)
        {
            if (zalogowany == true)
            {
                Form2 NoweZadanie = new Form2(this);
                NoweZadanie.ShowDialog();
            }
            else
            {
                MessageBox.Show("Zaloguj się, aby dodać zadanie");
            }
        }



        /*  ############################## FUNKCJE ############################## */

        /*---------------------------------------- PODSTAWOWE wynikające z ustawień (użytkownik, baza danych) ----------------------------------------*/

        //automatyczne logowanie, jeśli już wcześniej użytkownik sie zalogował
        public void Logowanie()
        {
            //Logowanie() używana po upewnieniu sie, ze plik "logowanie.txt" istnieje
            //odczyt
            FileStream odczyt = new FileStream("logowanie.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(odczyt);
            zalogowany_user = reader.ReadLine();
            reader.Close();
            odczyt.Close();
            Is_user_exist(zalogowany_user);
            if (uzytkownik_istnieje == true)
            {
                zalogowany = true;
                TextBoxUserName.Text = zalogowany_user;
            }
            else zalogowany = false;
        }

        //pierwsze połączenie z bazą i pobranie wszyskich zadań i użytkowników
        private void DataBase()
        {
            FileStream odczyt = new FileStream("database.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(odczyt);
            for (int i = 0; i < 4; i++)
            {
                Dane[i] = reader.ReadLine();
            }
            reader.Close();
            odczyt.Close();

            //zapisanie danych bazy w textboxach
            TextBoxServerID.Text = Dane[0];
            TextBoxDBName.Text = Dane[1];
            TextBoxDBUser.Text = Dane[2];
            TextBoxDBPassword.Text = Dane[3];

            try
            {
                DbConnection connection = new DbConnection(Dane[0], Dane[1], Dane[2], Dane[3]);
                MySqlConnection con = connection.polaczenie();
                con.Open();
                connected = true;
                MySqlCommand komenda1 = con.CreateCommand();

                komenda1.CommandText = "SELECT * FROM zadania";
                MySqlDataReader r = komenda1.ExecuteReader();
                Zadania.Clear();
                Wszystkie_Zadania_Z_Bazy.Clear();
                while (r.Read())
                {
                    int id = Convert.ToInt32(r["id_zadania"]);
                    int p = Convert.ToInt32(r["priorytet"]);
                    string z = r["zadanie"].ToString();
                    string ro = r["rodzaj"].ToString();
                    string w = r["wykonawca"].ToString();
                    System.DateTime dd = Convert.ToDateTime(r["data_dodania"]);
                    string dds = dd.ToString("ddd, dd MMM yyyy HH':'mm ");
                    string t = r["termin_wykonania"].ToString();
                    bool s = Convert.ToBoolean(r["status"]);
                    string dw = r["data_wykonania"].ToString();
                    string o = r["opis"].ToString();
                    string dp = r["dodane_przez"].ToString();
                    Tasks zadanie = new Tasks(id, p, z, ro, w, dd, dds, t, s, dw, o, dp);
                    Zadania.Add(zadanie);
                    Wszystkie_Zadania_Z_Bazy.Add(zadanie);
                }
                r.Close();

                MySqlCommand komenda2 = con.CreateCommand();
                komenda2.CommandText = "SELECT * FROM uzytkownicy";
                MySqlDataReader u = komenda2.ExecuteReader();
                while (u.Read())
                {
                    int id_uzytkownika = Convert.ToInt32(u["id_uzytkownika"]);
                    string nazwa_uzytkownika = u["nazwa"].ToString();
                    Users uzytkownik = new Users(id_uzytkownika, nazwa_uzytkownika);
                    Uzytkownicy.Add(uzytkownik);
                }

                u.Close();
                con.Close();
            }

            catch (MySqlException e)
            {
                MessageBox.Show("Wystąpił błąd podczas łączenia z bazą.");
                TextBoxDBinfo.Text = "Brak połączenia z bazą";
            }
        }

        

        





        /*---------------------------------------- PODSTAWOWE (m.in. przy uruchamianiu) ----------------------------------------*/

        //Po uruchomieniu wyświetlanie szczegółów pierwszego zadania z datagrid view
        public void Display_first_task_details(Tasks firstTask)
        {
            if(Wszystkie_Zadania_Z_Bazy.Count >= 1 && Zadania.Count >= 1)
            {
                Load_Task_Details(Znajdz_index_na_liscie(firstTask.Id_zadania.ToString()));
                ComboBoxDetailsWykonawcy.Text = firstTask.Wykonawca;
                ComboBoxDetailsZmienPriorytet.Text = firstTask.Priorytet.ToString();
                zmiana_zakresu_dat(Zadania);  //uwzględnienie zakresu dat
                metroGrid1.ClearSelection(); //po kliknieciu na wiersz nastąpi wyczyszczenie wszyskich zaznaczeń 
                metroGrid1.Rows[0].Cells[6].Style.SelectionBackColor = kolor(Znajdz_index_na_liscie(metroGrid1.Rows[0].Cells[0].Value.ToString()))[0];
                metroGrid1.Rows[0].Selected = true;
                kolor_terminu_w_dataGrid();
            }
            else
            {
                
            }
            
        }


        //funkcja do wyświetlania kolejnych wierszy DataGrid/metroGrid
        public void ShowRow(List<Tasks> lista)
        {

            for (int i = 0; i < lista.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(metroGrid1);
                row.Cells[0].Value = Zadania[i].Id_zadania;
                row.Cells[1].Value = Zadania[i].Priorytet;
                row.Cells[2].Value = Zadania[i].Zadanie;
                row.Cells[3].Value = Zadania[i].Rodzaj;
                row.Cells[4].Value = Zadania[i].Wykonawca;
                row.Cells[5].Value = Zadania[i].Data_dodania;
                row.Cells[6].Value = Zadania[i].Termin;
                row.Cells[7].Value = Zadania[i].Status;
                row.Cells[8].Value = Zadania[i].Data_wykonania;
                row.Cells[9].Value = Zadania[i].Dodane_przez;
                metroGrid1.Rows.Add(row);
            }

            Sortowanie();
        }

        //funkcja do wypełniania comboboxów z filtrami
        private void Wczytaj_Filtry()
        {
            Wczytaj_wykonawcow(ComboBoxWykonawcy);
            ComboBoxWykonawcy.Items.Add("wszystkie");

            ComboBoxStatus.Items.Clear();
            ComboBoxStatus.Items.Add("niewykonane");
            ComboBoxStatus.Items.Add("wykonane");
            ComboBoxStatus.Items.Add("wszystkie");

        }

        //funkcja do wyświetlanie listy użytkowników
        private void ShowUsers()
        {
            TextBoxUsersList.Text = "";
            for (int i = 0; i < Uzytkownicy.Count; i++)
            {
                TextBoxUsersList.Text += "ID: " + Uzytkownicy[i].id_uzytkownika + " nazwa: " + Uzytkownicy[i].nazwa_uzytkownika + " \n";
            }
        }

        //wczytywanie wykonawców do combobox w details
        public void Wczytaj_wykonawcow(MetroComboBox comboBox)
        {
            comboBox.Items.Clear();
            for (int i = 0; i < Uzytkownicy.Count; i++)
            {

                comboBox.Items.Add(Uzytkownicy[i].nazwa_uzytkownika);
            }

        }

        //wczytywanie zadań do sekcji szczegóły
        public void Load_Task_Details(int index)
        {
            /*TextBoxIle_czasu_zostalo.ForeColor = Color.Red;
            TextBoxIle_czasu_zostalo.BackColor = Color.Red; */  //nie działa

            Wczytaj_wykonawcow(ComboBoxDetailsWykonawcy);

            TextBoxDetailsPriorytet.Text = Wszystkie_Zadania_Z_Bazy[index].Priorytet.ToString();
            TextBoxDetailsID.Text = Wszystkie_Zadania_Z_Bazy[index].Id_zadania.ToString();
            TextBoxDetailsZadanie.Text = Wszystkie_Zadania_Z_Bazy[index].Zadanie;
            TextBoxDetailsWykonawca.Text = Wszystkie_Zadania_Z_Bazy[index].Wykonawca;
            TextBoxDetailsRodzaj.Text = Wszystkie_Zadania_Z_Bazy[index].Rodzaj;
            TextBoxDetailsOpis.Text = Wszystkie_Zadania_Z_Bazy[index].Opis;
            TextBoxDetailsDodanePrzez.Text = Wszystkie_Zadania_Z_Bazy[index].Dodane_przez;
            TextBoxDetailsDataDod.Text = Wszystkie_Zadania_Z_Bazy[index].Data_dodania.ToString();
           
            //W zależności od tego, czy zadanie ma termin wykonania
            if(Wszystkie_Zadania_Z_Bazy[index].Termin != null && Wszystkie_Zadania_Z_Bazy[index].Termin != string.Empty)
            {
                TextBoxDetailsTerm.Show();
                TextBoxDetailsTerm.Text = Wszystkie_Zadania_Z_Bazy[index].Termin.ToString();
            }
            else if( Wszystkie_Zadania_Z_Bazy[index].Termin == null || Wszystkie_Zadania_Z_Bazy[index].Termin == string.Empty)
            {
                TextBoxDetailsTerm.Text = string.Empty;
                TextBoxDetailsTerm.Hide();
            }

            //W zależności od stanuzadania
            if (Wszystkie_Zadania_Z_Bazy[index].Status == true)  //jeśli zadanie jest zakończone
            {
                textBoxIle_dni_do_konca_zadania.Hide();
                TextBoxDetailsStatus.Text = "wykonane";
                TextBoxDetailsDataZak.Text = Wszystkie_Zadania_Z_Bazy[index].Data_wykonania;
            }
            else
            {
                textBoxIle_dni_do_konca_zadania.Show();
                string czas = ile_czasu_do_konca_zadania(index, Wszystkie_Zadania_Z_Bazy);
                if (czas == null || czas == string.Empty) textBoxIle_dni_do_konca_zadania.Text = "zadanie bezterminowe";
                else if (Convert.ToInt32(czas) == 0) textBoxIle_dni_do_konca_zadania.Text = "DEADLINE";
                else if (Convert.ToInt32(czas) < 0) textBoxIle_dni_do_konca_zadania.Text = "Zadanie po terminie.";
                else if (Convert.ToInt32(czas) == 1) textBoxIle_dni_do_konca_zadania.Text = czas + " dzień do końca zadania";
                else textBoxIle_dni_do_konca_zadania.Text = czas + " dni do końca zadania";

                textBoxIle_dni_do_konca_zadania.BackColor = kolor(index)[0];
                textBoxIle_dni_do_konca_zadania.ForeColor = kolor(index)[1];
                TextBoxDetailsStatus.Text = "niewykonane";
                TextBoxDetailsDataZak.Text = "";
            }
            kolor_terminu_w_dataGrid();

        }



        /*---------------------------------------- KOLORY TERMINÓW ----------------------------------------*/

        //funkcja licząca ile czasu zostało do końca zadania
        private string ile_czasu_do_konca_zadania(int index, List<Tasks> lista)
        {
            if (lista[index].Termin != null && lista[index].Termin != string.Empty)
            {
                System.DateTime termin = Convert.ToDateTime(lista[index].Termin);
                string term = termin.ToString("ddd, dd MMM yyyy HH':'mm ");
                string dzis = DateTime.UtcNow.ToLocalTime().ToString("ddd, dd MMM yyyy HH':'mm ");
                TimeSpan roznica = Convert.ToDateTime(term) - Convert.ToDateTime(dzis);
                return roznica.Days.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        //funkcja zwracająca kolor w zależności od tego ile czasu zostało do końca zadania (zmienic na uniwersalna po dodaniu ustawien zakresów)
        //parametry np: mocno czerwony: <1 dni,  czerwony: 1 dzien,  pomarnczowy: 2dni, zółty: 3 dni,  zielony: >4dni
        private Color[] kolor(int index)
        {
            
            Color[] kolor = new Color[2];
            string ilosc_dni = ile_czasu_do_konca_zadania(index, Wszystkie_Zadania_Z_Bazy);
            int dni;
           
            //NIEZAKOŃCZONE ZADANIA
            if (Wszystkie_Zadania_Z_Bazy[index].Status == false)
            {
                
                    //ZADANIA niezakonczone Z TERMINEM
                    if (ilosc_dni != string.Empty)
                    {
                        dni = Convert.ToInt32(ilosc_dni);
                        if (dni < 0) { kolor[0] = Color.Black; kolor[1] = Color.White; }

                        else if (dni == 0) { kolor[0] = Color.Red; kolor[1] = Color.White; }
                        else if (dni > 0 && dni <= 4) { kolor[0] = Color.Orange; kolor[1] = Color.White; }
                        else if (dni >4 && dni <= 10) { kolor[0] = Color.Yellow; kolor[1] = Color.Black; }
                        else if (dni > 10) { kolor[0] = Color.Green; kolor[1] = Color.White; }

                        else { kolor[1] = Color.LightGreen; kolor[1] = Color.Black; }

                    }
                    //ZADANIA niezakonczone BEZ TERMINU
                    else { kolor[0] = Color.LightGreen; kolor[1] = Color.Black; }
                
            }
            //ZAKOŃCZONE ZADANIA z teminem lub bez
            else
            {
                    kolor[0] = Color.LightGray;
                    kolor[1] = Color.Gray;  
            }

            return kolor;
        }


        //Ustawianie koloru terminu w zależności od tego ile dni zostało do końca
        private void kolor_terminu_w_dataGrid()
        {
           
            for (int i=0; i<Wszystkie_Zadania_Z_Bazy.Count; i++)
             {
                 for(int j=0; j<metroGrid1.RowCount; j++)
                 {
                    if (metroGrid1[0, j].Value.ToString() == Wszystkie_Zadania_Z_Bazy[i].Id_zadania.ToString() && Wszystkie_Zadania_Z_Bazy[i].Termin != null)  //znaleznienie odpowiedniej komorki datagrid
                    {
                        metroGrid1[6, j].Style.BackColor = kolor(i)[0];
                        metroGrid1[6, j].Style.ForeColor = kolor(i)[1];
                    }
                 }
             }

         }


         /*---------------------------------------- UZYWANE W INNYCH FORMACH ----------------------------------------*/


            //funkcja służąca do przekazywania obiektów Tasks do innych form
            public Object Pobierz_Zadanie(int index, string pole)
        {
            if (pole == "Id_zadania") return Wszystkie_Zadania_Z_Bazy[index].Id_zadania;
            else if (pole == "Priorytet") return Wszystkie_Zadania_Z_Bazy[index].Priorytet;
            else if (pole == "Priorytet") return Wszystkie_Zadania_Z_Bazy[index].Priorytet;
            else if (pole == "Zadanie") return Wszystkie_Zadania_Z_Bazy[index].Zadanie;
            else if (pole == "Rodzaj") return Wszystkie_Zadania_Z_Bazy[index].Rodzaj;
            else if (pole == "Wykonawca") return Wszystkie_Zadania_Z_Bazy[index].Wykonawca;
            else if (pole == "Data_dodania") return Wszystkie_Zadania_Z_Bazy[index].Data_dodania;
            else if (pole == "Termin")
            {
                if (Wszystkie_Zadania_Z_Bazy[index].Termin != null) return Wszystkie_Zadania_Z_Bazy[index].Termin;
                else return null;
            }
            else if (pole == "Status") return Wszystkie_Zadania_Z_Bazy[index].Status;
            else if (pole == "Data_wykonania") return Wszystkie_Zadania_Z_Bazy[index].Data_wykonania;
            else if (pole == "Opis") return Wszystkie_Zadania_Z_Bazy[index].Opis;
            else if (pole == "Dodane_przez") return Wszystkie_Zadania_Z_Bazy[index].Dodane_przez;
            
            else if (pole == "last_db_id")
            {
                if (Wszystkie_Zadania_Z_Bazy.Count == 0) return 1;
                else return Wszystkie_Zadania_Z_Bazy[Wszystkie_Zadania_Z_Bazy.Count - 1].Id_zadania; 
            }
            else return null;
        }
        //podmiana zadania na liście filtrowanej
        public void Podmien_zadanie(int id, Tasks zmienone_zadanie)
        {
            Zadania.RemoveAt(id);
            Zadania.Insert(id, zmienone_zadanie);
        }
        //podmiana zadania na liście całościowej
        public void Podmien_zadanie_we_wszystkich(int id, Tasks zmienone_zadanie)
        {
            Wszystkie_Zadania_Z_Bazy.RemoveAt(id);
            Wszystkie_Zadania_Z_Bazy.Insert(id, zmienone_zadanie);
        }
        //dodanie zadania do listy filtrowanej
        public void Dodaj_Zadanie_do_listy(Tasks nowe_zadanie)
        {
            Zadania.Add(nowe_zadanie);
        }
        //dodanie zadania do listy całościowej
        public void Dodaj_Zadanie_do_listy_wszystkich_zadan(Tasks nowe_zadanie)
        {
            Wszystkie_Zadania_Z_Bazy.Add(nowe_zadanie);
        }




        /*---------------------------------------- FILTROWANIE, SORTOWANIE, ZAKRES DAT, WYSZUKIWANIE ----------------------------------------*/


        //FILTROWANIE według wykonawcy zadania i stanu zadania
        public void Filtrowanie(string uzytkownik, string stan_zadania)
        {
            try
            {
                DbConnection connection = new DbConnection(Dane[0], Dane[1], Dane[2], Dane[3]);
                MySqlConnection con = connection.polaczenie();
                con.Open();
                connected = true;
                MySqlCommand komenda1 = con.CreateCommand();
                komenda1.CommandText = "";

                if (ComboBoxStatus.SelectedItem.ToString() == "wykonane")
                {
                    if (uzytkownik != "wszystkie" && uzytkownik != null)
                    {
                        komenda1.CommandText += "SELECT * FROM `zadania` WHERE status=1 AND wykonawca='" + uzytkownik + "'";
                    }
                    else if (uzytkownik == "wszystkie" || uzytkownik == null)
                    {
                        komenda1.CommandText += "SELECT * FROM `zadania` WHERE status=1";
                    }
                }
                else if (ComboBoxStatus.SelectedItem.ToString() == "niewykonane")
                {
                    if (uzytkownik != "wszystkie" && uzytkownik != null)
                    {
                        komenda1.CommandText += "SELECT * FROM `zadania` WHERE status=0 AND wykonawca='" + uzytkownik + "'";
                    }
                    else if (uzytkownik == "wszystkie" || uzytkownik == null)
                    {
                        komenda1.CommandText += "SELECT * FROM `zadania` WHERE status=0";
                    }
                }
                else if (ComboBoxStatus.SelectedItem.ToString() == "wszystkie" || ComboBoxStatus.SelectedItem.ToString() == null)
                {
                    if (uzytkownik != "wszystkie" && uzytkownik != null)
                    {
                        komenda1.CommandText += "SELECT * FROM `zadania` WHERE wykonawca='" + uzytkownik + "'";
                    }
                    else if (uzytkownik == "wszystkie" || uzytkownik == null)
                    {
                        komenda1.CommandText += "SELECT * FROM `zadania`";
                    }
                }
                else komenda1.CommandText += "SELECT * FROM `zadania`";

                MySqlDataReader r = komenda1.ExecuteReader();
                Zadania.Clear();
                while (r.Read())
                {
                    int id = Convert.ToInt32(r["id_zadania"]);
                    int p = Convert.ToInt32(r["priorytet"]);
                    string z = r["zadanie"].ToString();
                    string ro = r["rodzaj"].ToString();
                    string w = r["wykonawca"].ToString();
                    System.DateTime dd = Convert.ToDateTime(r["data_dodania"]);
                    string dds = dd.ToString("ddd, dd MMM yyyy HH':'mm ");
                    string t = r["termin_wykonania"].ToString();
                    bool s = Convert.ToBoolean(r["status"]);
                    string dw = r["data_wykonania"].ToString();
                    string o = r["opis"].ToString();
                    string dp = r["dodane_przez"].ToString();
                    Tasks zadanie = new Tasks(id, p, z, ro, w, dd, dds, t, s, dw, o, dp);
                    Zadania.Add(zadanie);
                }
                r.Close();
                con.Close();
                metroGrid1.Rows.Clear();

                // ? zmiana zakresu dat wywołuje funkcję  zmiana_zakresu_dat(), która zasępuje ShowRow ale z uwzględnieniem dat
                if(Zadania.Count != 0)
                {
                    DateTimeZakresDatDo.Value = Zadania[0].Data_dodania;
                    DateTimeZakresDatOd.Value = Zadania[Zadania.Count - 1].Data_dodania;
                }
                                   
                
                kolor_terminu_w_dataGrid();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Wystąpił błąd podczas łączenia z bazą.");
                TextBoxDBinfo.Text = "Brak połączenia z bazą";
            }

        }


        //SORTOWANIE
        public void Sortowanie() //sortowanie w zależnościod kryterium, wywołane w ShowRow()
        {
            if (CheckBoxMalejaco.Checked == true && CheckBoxRosnaco.Checked == false)
            {
                this.metroGrid1.Sort(this.metroGrid1.Columns[ComboBoxSortowanie.SelectedIndex], ListSortDirection.Descending);
            }
            else if (CheckBoxMalejaco.Checked == false && CheckBoxRosnaco.Checked == true)
            {
                this.metroGrid1.Sort(this.metroGrid1.Columns[ComboBoxSortowanie.SelectedIndex], ListSortDirection.Ascending);
            }
            kolor_terminu_w_dataGrid();
        }


        //ZMIANY ZAKRESU DAT
        private void zmiana_zakresu_dat(List<Tasks> lista)   // może zastępować ShowRow()
        {
            metroGrid1.Rows.Clear();
            for (int i = 0; i < lista.Count; i++)
            {
                //jeśli data dodania danego zadania mieści się w wybranym zakresie
                if (Convert.ToDateTime(lista[i].Data_dodania_string) >= DateTimeZakresDatOd.Value.AddDays(-1) && Convert.ToDateTime(lista[i].Data_dodania_string) <= DateTimeZakresDatDo.Value.AddDays(1.0))
                {
                    metroGrid1.Rows.Add(konwersja(lista[i]));
                }
               
               kolor_terminu_w_dataGrid();
               Sortowanie();

            }
        }

        private void Wyszukiwanie()
        {
            metroGrid1.Rows.Clear();
            List<Tasks> Wyszukane = new List<Tasks>();

            if (ComboBoxKolumnaSzukania.SelectedIndex == 0)
            {
                for (int i = 0; i < Zadania.Count; i++)
                {
                    if (Zadania[i].Id_zadania.ToString().Contains(TextBoxSzukanaFraza.Text)) { metroGrid1.Rows.Add(konwersja(Zadania[i])); Wyszukane.Add(Zadania[i]);  }
                }
            }
            else if (ComboBoxKolumnaSzukania.SelectedIndex == 1)
            {
                for (int i = 0; i < Zadania.Count; i++)
                {
                    if (Zadania[i].Priorytet.ToString().Contains(TextBoxSzukanaFraza.Text)) { metroGrid1.Rows.Add(konwersja(Zadania[i])); Wyszukane.Add(Zadania[i]); }
                }
            }
            else if (ComboBoxKolumnaSzukania.SelectedIndex == 2)
            {
                for (int i = 0; i < Zadania.Count; i++)
                {
                    if (Zadania[i].Zadanie.Contains(TextBoxSzukanaFraza.Text)) { metroGrid1.Rows.Add(konwersja(Zadania[i])); Wyszukane.Add(Zadania[i]); }
                }
            }
            else if (ComboBoxKolumnaSzukania.SelectedIndex == 3)
            {
                for (int i = 0; i < Zadania.Count; i++)
                {
                    if (Zadania[i].Rodzaj.Contains(TextBoxSzukanaFraza.Text)) { metroGrid1.Rows.Add(konwersja(Zadania[i])); Wyszukane.Add(Zadania[i]); }
                }
            }
            else if (ComboBoxKolumnaSzukania.SelectedIndex == 4)
            {
                for (int i = 0; i < Zadania.Count; i++)
                {
                    if (Zadania[i].Wykonawca.Contains(TextBoxSzukanaFraza.Text)) { metroGrid1.Rows.Add(konwersja(Zadania[i])); Wyszukane.Add(Zadania[i]); }
                }
            }
            else if (ComboBoxKolumnaSzukania.SelectedIndex == 5)  //szukanie w opisie
            {
                for (int i = 0; i < Zadania.Count; i++)
                {
                    if (Zadania[i].Opis.Contains(TextBoxSzukanaFraza.Text))
                    {
                        metroGrid1.Rows.Add(konwersja(Zadania[i]));
                        Wyszukane.Add(Zadania[i]);
                        metroTabTaskDetails.Show();
                        Load_Task_Details(Znajdz_index_na_liscie(Zadania[i].Id_zadania.ToString()));
                    }

                }
            }
            else if (ComboBoxKolumnaSzukania.SelectedIndex == 6)
            {
                for (int i = 0; i < Zadania.Count; i++)
                {
                    if (Zadania[i].Termin.Contains(TextBoxSzukanaFraza.Text)) { metroGrid1.Rows.Add(konwersja(Zadania[i])); Wyszukane.Add(Zadania[i]); }
                }
            }
            else if (ComboBoxKolumnaSzukania.SelectedIndex == 7)
            {
                for (int i = 0; i < Zadania.Count; i++)
                {
                    if (Zadania[i].Status.ToString().Contains(TextBoxSzukanaFraza.Text)) { metroGrid1.Rows.Add(konwersja(Zadania[i])); Wyszukane.Add(Zadania[i]); }
                }
            }
            else if (ComboBoxKolumnaSzukania.SelectedIndex == 8)
            {
                for (int i = 0; i < Zadania.Count; i++)
                {
                    if (Zadania[i].Data_wykonania.Contains(TextBoxSzukanaFraza.Text)) { metroGrid1.Rows.Add(konwersja(Zadania[i])); Wyszukane.Add(Zadania[i]); }
                }
            }
            else if (ComboBoxKolumnaSzukania.SelectedIndex == 9)
            {
                for (int i = 0; i < Zadania.Count; i++)
                {
                    if (Zadania[i].Dodane_przez.Contains(TextBoxSzukanaFraza.Text)) { metroGrid1.Rows.Add(konwersja(Zadania[i])); Wyszukane.Add(Zadania[i]); }
                }
            }

            zmiana_zakresu_dat(Wyszukane);
        }




        /*---------------------------------------- INNE ----------------------------------------*/

        //konwersja obiektu Tasks do wiersza datagridview (np. do dodawania jednego wiersza do datagridview)
        public DataGridViewRow konwersja(Tasks zadanie)   
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(metroGrid1);
            row.Cells[0].Value = zadanie.Id_zadania;
            row.Cells[1].Value = zadanie.Priorytet;
            row.Cells[2].Value = zadanie.Zadanie;
            row.Cells[3].Value = zadanie.Rodzaj;
            row.Cells[4].Value = zadanie.Wykonawca;
            row.Cells[5].Value = zadanie.Data_dodania;
            row.Cells[6].Value = zadanie.Termin;
            row.Cells[7].Value = zadanie.Status;
            row.Cells[8].Value = zadanie.Data_wykonania;
            row.Cells[9].Value = zadanie.Dodane_przez;
            return row;
        }

        //WYZNACZANIE INDEKSU obiektu na liście całościowej
        public int Znajdz_index_na_liscie(string porownanie_id)
        {
            int indeks = 0;
            for (int i = 0; i < Wszystkie_Zadania_Z_Bazy.Count; i++)
            {
                if (Wszystkie_Zadania_Z_Bazy[i].Id_zadania.ToString() == porownanie_id)
                {
                    //indeks += Wszystkie_Zadania_Z_Bazy.IndexOf(Zadania[i]);
                    indeks += i;
                    break;
                }
            }
            return indeks;
        }

        //WYZNACZANIE INDEKSU obiektu na liście filtrowanej
        public int Znajdz_index_na_liscie_ograniczonej(string porownanie_id)
        {
            int indeks = 0;
            for (int i = 0; i < Zadania.Count; i++)
            {
                if (Zadania[i].Id_zadania.ToString() == porownanie_id)
                {
                    //indeks += Wszystkie_Zadania_Z_Bazy.IndexOf(Zadania[i]);
                    indeks += i;
                    break;
                }
            }
            return indeks;
        }


        //sprawdzenie, czy dodawany uztkownik juz istnieje w bazie
        private void Is_user_exist(string user)
        {
            for (int i = 0; i < Uzytkownicy.Count; i++)
            {
                if (Uzytkownicy[i].nazwa_uzytkownika == user)
                {
                    uzytkownik_istnieje = true;
                    break;
                }
                else
                {
                    uzytkownik_istnieje = false;
                }


            }
        }

        //potwierdzenie usunięcia zadania
        private bool Czy_usunac(int indeks) //potwierdzenie usunięcia zadania
        {
            DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz usunąć zadanie " + Zadania[indeks].Zadanie + "?", "Usuwanie zadania", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                return true;
            }
            else if (dialogResult == DialogResult.No)
            {
                return false;
            }
            else return false;
        }

        










        /*_______________________________________________________________________________________________________________________________________________*/





















    }
}
