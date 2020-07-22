
//autorem jest karolina czech
using Microsoft.VisualBasic;
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
using Renci.SshNet.Security;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using PdfSharp;
using PdfSharp.Pdf;
using System.Net;
using System.Web;
using ImageMagick;
using System.Buffers.Text;
using System.Web.UI;
using System.Runtime.InteropServices.ComTypes;

namespace WindowsFormsApp1
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            ComboBoxSortowanie.SelectedIndex = 1;    //domyślne sortowanie wg kolumny 0, czyli ID
            ComboBoxKolumnaSzukania.SelectedIndex = 2;   //domyślne wyszukiwanie w kolumnie 2, czyli zadanie
           
            Zaladuj_ponownie();

            if(zalogowany == true)
            {
               ZadaniaNaDzis();
            }
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
        

        /*  ############################## ZMIENNE, LISTY, TABLICE ############################## */
       
        public string zalogowany_user;
        public bool zalogowany = false;
        public string[] Dane = new string[5];
        List<DatyUruchomieniaProgramu> daty_uruchomien_programu = new List<DatyUruchomieniaProgramu>();
        public string[] IleDni_KoloryTerminow = new string[6];
        bool connected = false;
        bool uzytkownik_istnieje;
        public List<Tasks> Zadania = new List<Tasks>();
        public List<Tasks> Wszystkie_Zadania_Z_Bazy = new List<Tasks>();
        public List<Users> Uzytkownicy = new List<Users>();
        public List<Types> Rodzaje = new List<Types>(); //lista przechowujaca rodzaje zadań

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

        Form4 form4;
        Form1(Form4 form)
        {
             this.form4 = form;
        }




        /*  ########################################          ZDARZENIA           ######################################## */

        /*------------------------------------------------ PRZYCISKI Z USTAWIEŃ  ------------------------------------------------*/

        //przycisk do logowania 
        private void ButtonLogowanie_Click_1(object sender, EventArgs e)
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
                if(zalogowany==true) ZadaniaNaDzis();
            }
        }


        //przycisk do dodawania nowego użytkownika
        private void ButtonDodajUzytkownika_Click_1(object sender, EventArgs e)
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
                        DbConnection connection = new DbConnection(Dane[0], Dane[1], Dane[2], Dane[3], Dane[4]);
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
                        ComboBoxWykonawcy.Items.Add(nazwa);
                        
                    }
                    catch (MySqlException ee)
                    {
                        MessageBox.Show("Wystąpił błąd podczas łączenia z bazą.");

                    }
                   
                }
                else MessageBox.Show("Nazwa użytkownika musi się składać z conajmniej 3 znaków.");
            }
            else
            {
                MessageBox.Show("Użytkownik o takiej nazwie już istnieje. Wybierz inną.");
            }
        }

        Rijndael Szyfr = Rijndael.Create();
        byte[] key = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
        byte[] iv = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
        //przycisk do łączenia z bazą danych
        private void ButtonSaveDB_Click(object sender, EventArgs e)
        {
            string server = TextBoxServerID.Text;
            string port = TextBoxDBPort.Text;
            string name = TextBoxDBName.Text;
            string user = TextBoxDBUser.Text;
            string pass = TextBoxDBPassword.Text;


            //szyfrowanie
            string ServerID = "";
            string DBPort = "";
            string DBName = "";
            string DBUser = "";
            string DBPassword = "";

            try
            {
                using (Szyfr.CreateEncryptor(key, iv))
                {
                    // Encrypt the string to an array of bytes.
                    if (server != string.Empty)
                    {
                        byte[] encryptedServerID = EncryptStringToBytes(server, key, iv);
                        for (int i = 0; i < encryptedServerID.Count(); i++) { ServerID += encryptedServerID[i] + " "; }
                    }
                    else ServerID = " ";
                    if (port != string.Empty)
                    {
                        byte[] encryptedDBPort = EncryptStringToBytes(port, key, iv);
                        for (int i = 0; i < encryptedDBPort.Count(); i++) { DBPort += encryptedDBPort[i] + " "; }
                    }
                    else DBPort = " ";
                    if (name != string.Empty)
                    {
                        byte[] encryptedDBName = EncryptStringToBytes(name, key, iv);
                        for (int i = 0; i < encryptedDBName.Count(); i++) { DBName += encryptedDBName[i] + " "; }
                    }
                    else DBName = " ";
                    if (user != string.Empty)
                    {
                        byte[] encryptedDBUser = EncryptStringToBytes(user, key, iv);
                        for (int i = 0; i < encryptedDBUser.Count(); i++) { DBUser += encryptedDBUser[i] + " "; }
                    }
                    else DBUser = " ";
                    if (pass != string.Empty)
                    {
                        byte[] encryptedDBPassword = EncryptStringToBytes(pass, key, iv);
                        for (int i = 0; i < encryptedDBPassword.Count(); i++) { DBPassword += encryptedDBPassword[i] + " "; }
                    }
                    else DBPassword = " ";

                    string file_name = "database.txt";
                    if (File.Exists(file_name))
                    {
                        File.WriteAllText(file_name, String.Empty);
                        FileStream dane = new FileStream(file_name, FileMode.Append, FileAccess.Write);
                        StreamWriter writer = new StreamWriter(dane);
                        writer.WriteLine(ServerID);
                        writer.WriteLine(DBPort);
                        writer.WriteLine(DBName);
                        writer.WriteLine(DBUser);
                        writer.WriteLine(DBPassword);
                        writer.Close();
                        dane.Close();
                        MessageBox.Show("Zapisano");
                    }
                    else
                    {
                        FileStream dane = new FileStream(file_name, FileMode.CreateNew);
                        StreamWriter writer = new StreamWriter(dane);
                        writer.WriteLine(ServerID);
                        writer.WriteLine(DBPort);
                        writer.WriteLine(DBName);
                        writer.WriteLine(DBUser);
                        writer.WriteLine(DBPassword);
                        writer.Close();
                        dane.Close();
                        MessageBox.Show("Zapisano");
                    }
                    //wylogowanie i załadowanie od nowa wszystkiego
                    zalogowany = false;
                    TextBoxUserName.Text = "";
                    File.WriteAllText("logowanie.txt", String.Empty);   
                    Zaladuj_ponownie();

                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Error: {0}", x.Message);
            }



            //DZIALAJACE BEZ SZYFROWANIA:
            /*  string file_name = "database.txt";
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

              DataBase();  */
        }

        //przycisk do zapisania ustawień widoczności kolumn
        private void ButtonZapiszWidokKolumn_Click_1(object sender, EventArgs e)
        {
            string[] Zaznaczenia = new string[10];
            string file_name = "ustawieniaKolumn.txt";
            FileStream dane;
            if (File.Exists(file_name))
            {
                File.WriteAllText(file_name, String.Empty);
                dane = new FileStream(file_name, FileMode.Append, FileAccess.Write);

            }
            else
            {
                dane = new FileStream(file_name, FileMode.CreateNew);
            }
            StreamWriter writer = new StreamWriter(dane);
            if (metroCheckBox1.Checked == true) writer.WriteLine(1);
            else writer.WriteLine(0);
            if (metroCheckBox2.Checked == true) writer.WriteLine(1);
            else writer.WriteLine(0);
            if (metroCheckBox3.Checked == true) writer.WriteLine(1);
            else writer.WriteLine(0);
            if (metroCheckBox4.Checked == true) writer.WriteLine(1);
            else writer.WriteLine(0);
            if (metroCheckBox5.Checked == true) writer.WriteLine(1);
            else writer.WriteLine(0);
            if (metroCheckBox6.Checked == true) writer.WriteLine(1);
            else writer.WriteLine(0);
            if (metroCheckBox7.Checked == true) writer.WriteLine(1);
            else writer.WriteLine(0);
            if (metroCheckBox8.Checked == true) writer.WriteLine(1);
            else writer.WriteLine(0);
            if (metroCheckBox9.Checked == true) writer.WriteLine(1);
            else writer.WriteLine(0);
            if (metroCheckBox10.Checked == true) writer.WriteLine(1);
            else writer.WriteLine(0);

            writer.Close();
            dane.Close();

            //Widocznosc_kolumn_ustawiona();
            Odczyt_Ustawien_Kolumn();
        }




        //ustawienia zaznaczeń checkboxów do widoczności kolumn
        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked == true) metroCheckBox1.Text = "widoczne";
            else metroCheckBox1.Text = "niewidoczne";

        }

        private void metroCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox2.Checked == true) metroCheckBox2.Text = "widoczne";
            else metroCheckBox2.Text = "niewidoczne";
        }

        private void metroCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox3.Checked == true) metroCheckBox3.Text = "widoczne";
            else metroCheckBox3.Text = "niewidoczne";
        }

        private void metroCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox4.Checked == true) metroCheckBox4.Text = "widoczne";
            else metroCheckBox4.Text = "niewidoczne";
        }

        private void metroCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox5.Checked == true) metroCheckBox5.Text = "widoczne";
            else metroCheckBox5.Text = "niewidoczne";
        }

        private void metroCheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox6.Checked == true) metroCheckBox6.Text = "widoczne";
            else metroCheckBox6.Text = "niewidoczne";
        }

        private void metroCheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox7.Checked == true) metroCheckBox7.Text = "widoczne";
            else metroCheckBox7.Text = "niewidoczne";
        }

        private void metroCheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox8.Checked == true) metroCheckBox8.Text = "widoczne";
            else metroCheckBox8.Text = "niewidoczne";
        }

        private void metroCheckBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox9.Checked == true) metroCheckBox9.Text = "widoczne";
            else metroCheckBox9.Text = "niewidoczne";
        }

        private void metroCheckBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox10.Checked == true) metroCheckBox10.Text = "widoczne";
            else metroCheckBox10.Text = "niewidoczne";
        }

        /*   -----------------------      przyciski    USTAWIENIA: RODZAJE ZADAŃ       ----------------------------       */


        //usuwanie uzytkownika
        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            int id_uzytkownika = Convert.ToInt32(metroGridUzytkownicy[0, metroGridUzytkownicy.CurrentRow.Index].Value);
            DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz usunąć rodzaj " + metroGridUzytkownicy[1, metroGridUzytkownicy.CurrentRow.Index].Value + "?", "Usuwanie użytkownika", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string komenda = "DELETE FROM `uzytkownicy` WHERE `uzytkownicy`.`id_uzytkownika` = " + id_uzytkownika;
                BazaDanych(komenda, Dane[0], Dane[1], Dane[2], Dane[3], Dane[4]);
                Uzytkownicy.RemoveAt(metroGridUzytkownicy.CurrentRow.Index);
                ShowUsers();
                Wczytaj_wykonawcow(ComboBoxWykonawcy);
                ComboBoxWykonawcy.Items.Add("wszystkie");
                if (zalogowany == true) ComboBoxWykonawcy.Text = zalogowany_user;
                else ComboBoxWykonawcy.Text = "wszystkie";
            }
        }


        //usuwanie rodzaju zadania
        private void ButtonUSUNRodzaj_Click(object sender, EventArgs e)
        {
            int id_rodzaju = Convert.ToInt32(metroGridRodzaje[0, metroGridRodzaje.CurrentRow.Index].Value);
            DialogResult dialogResult = MessageBox.Show("Czy na pewno chcesz usunąć rodzaj " + metroGridRodzaje[1, metroGridRodzaje.CurrentRow.Index].Value + "?", "Usuwanie rodzaju", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string komenda = "DELETE FROM `rodzaje_zadan` WHERE `rodzaje_zadan`.`id_rodzaju` = " + id_rodzaju;
                BazaDanych(komenda, Dane[0], Dane[1], Dane[2], Dane[3], Dane[4]);
                WypelnijMetroGridRodzaje();

            }
        }
        
        //funkcja, która po kliknięciu na textbox czysci go, żeby można było wpisać nowy rodzaj zadania
        private void TextBoxNowyRodzaj_Click(object sender, EventArgs e)
        {
            TextBoxNowyRodzaj.Text = string.Empty;
        }
        //dodawanie rodzaju zadania
        private void ButtonDODAJRodzaj_Click(object sender, EventArgs e)
        {

            if (TextBoxNowyRodzaj.Text != string.Empty && TextBoxNowyRodzaj.Text != "wpisz nowy rodzaj")
            {
                bool czy_istnieje_rodzaj = false;
                for (int i = 0; i < Rodzaje.Count; i++)
                {
                    if (Rodzaje[i].rodzaj == TextBoxNowyRodzaj.Text)
                    {
                        czy_istnieje_rodzaj = true;
                        break;
                    }
                }
                if (czy_istnieje_rodzaj == false)
                {

                    int id;
                    if (Rodzaje.Count < 1) id = 1;
                    else id = (Rodzaje[Rodzaje.Count - 1].id_rodzaju) + 1;
                    string nowy_rodzaj = TextBoxNowyRodzaj.Text;
                    string komenda = "INSERT INTO `rodzaje_zadan` (`id_rodzaju`, `rodzaj`) VALUES (" + id + ", '" + nowy_rodzaj + "')";
                    BazaDanych(komenda, Dane[0], Dane[1], Dane[2], Dane[3], Dane[4]);
                    WypelnijMetroGridRodzaje();
                    TextBoxNowyRodzaj.Text = "wpisz nowy rodzaj";
                }
            }
            else
            {
                TextBoxNowyRodzaj.Text = "wpisz rodzaj";
            }
        }
        //zmiana zaznaczenia rodzaju w datagrid
        private void metroGridRodzaje_SelectionChanged(object sender, EventArgs e)
        {
            if (metroGridRodzaje[1, metroGridRodzaje.CurrentRow.Index].Value != null)
            {
                TextBoxEdytujRodzaj.ReadOnly = false;
                TextBoxEdytujRodzaj.Text = metroGridRodzaje[1, metroGridRodzaje.CurrentRow.Index].Value.ToString();
            }
            else
            {
                TextBoxEdytujRodzaj.Text = string.Empty;
                TextBoxEdytujRodzaj.ReadOnly = true;
            }
        }
        //usuwanie rodzaju
        private void ButtonEDYTUJRodzaj_Click(object sender, EventArgs e)
        {
            if (TextBoxEdytujRodzaj.Text != string.Empty)
            {
                int id = Convert.ToInt32(metroGridRodzaje[0, metroGridRodzaje.CurrentRow.Index].Value);
                string edytowany_rodzaj = TextBoxEdytujRodzaj.Text;
                string komenda = "UPDATE `rodzaje_zadan` SET `rodzaj` = '" + edytowany_rodzaj + "' WHERE `rodzaje_zadan`.`id_rodzaju` = " + id + "";
                BazaDanych(komenda, Dane[0], Dane[1], Dane[2], Dane[3], Dane[4]);
                WypelnijMetroGridRodzaje();
            }
        }



        /*------------------------------------------------ SZYBKA EDYCJA W DETAILS, ZMIANA STATUSU ZADANIA w datagrid  ------------------------------------------------*/

        //zmiana wykonawcy zadania w sekji szczegóły
        private void ComboBoxDetailsWykonawcy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nowyWykonawca = ComboBoxDetailsWykonawcy.SelectedItem.ToString();
            int index = Znajdz_index_na_liscie(TextBoxDetailsID.Text);
            int id = Convert.ToInt32(TextBoxDetailsID.Text);
            //zmiana w details
            //TextBoxDetailsWykonawca.Text = nowyWykonawca;
            //zmiana w bazie
            try
            {
                DbConnection connection = new DbConnection(Dane[0], Dane[1], Dane[2], Dane[3], Dane[4]);
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
            zmiana_zakresu_dat(Zadania);
            //ShowRow(Zadania);
            Display_specific_task_details(id);
            
        }


        //zmiana priorytetu zadania w sekcji szczegóły
        private void ComboBoxDetailsZmienPriorytet_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nowyPriorytet = Convert.ToInt32(ComboBoxDetailsZmienPriorytet.SelectedItem);
            int id = Convert.ToInt32(TextBoxDetailsID.Text);
            int index = Znajdz_index_na_liscie(TextBoxDetailsID.Text);
            //zmiana w details
           // TextBoxDetailsPriorytet.Text = nowyPriorytet.ToString();
            //zmiana w bazie
            try
            {
                DbConnection connection = new DbConnection(Dane[0], Dane[1], Dane[2], Dane[3], Dane[4]);
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
            zmiana_zakresu_dat(Zadania); //może zamienić n zmiana_zakresu_dat(Zadania)
            Display_specific_task_details(id);


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
                    DbConnection connection = new DbConnection(Dane[0], Dane[1], Dane[2], Dane[3], Dane[4]);
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
                        //TerminZadania(Zadania, index);  v
                        ZadaniaNaDzis();
                        Zadania[index].Termin = "ZAKOŃCZONE";

                    }
                    else if (Convert.ToInt32(metroGrid1.Rows[e.RowIndex].Cells[7].Value) == 0)
                    {
                        Zadania[index].Status = false;
                        Wszystkie_Zadania_Z_Bazy[numerindexu].Status = false;
                        Zadania[index].Data_wykonania = null;
                        Wszystkie_Zadania_Z_Bazy[numerindexu].Data_wykonania = null;
                        komendaSQL.CommandText = "UPDATE `zadania` SET `status` = '0', `data_wykonania` = NULL  WHERE `zadania`.`id_zadania` = " + id + "; ";
                        //TerminZadania(Zadania, index);  v        
                        ZadaniaNaDzis();
                        if (Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(id.ToString())].Termin == null || Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(id.ToString())].Termin == string.Empty) Zadania[index].Termin = "BEZTERMINOWE";
                        else if (Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(id.ToString())].Termin != null && Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(id.ToString())].Termin != string.Empty) Zadania[index].Termin = Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(id.ToString())].Termin;
                        if (Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(id.ToString())].Termin != null && Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(id.ToString())].Termin != string.Empty)
                        {
                            if (Convert.ToInt32(ile_czasu_do_konca_zadania(Znajdz_index_na_liscie(id.ToString()), Wszystkie_Zadania_Z_Bazy)) < 0)
                            {
                                Zadania[Znajdz_index_na_liscie_ograniczonej(id.ToString())].Termin = Convert.ToDateTime(Zadania[Znajdz_index_na_liscie_ograniczonej(id.ToString())].Termin).ToShortDateString();
                                Zadania[Znajdz_index_na_liscie_ograniczonej(id.ToString())].Termin += "  ZADANIE PO TERMINIE";
                            }
                        }
                    }

                    MySqlDataReader r = komendaSQL.ExecuteReader();
                    r.Close();
                    con.Close();
                    int pozycja_scrollbaru = metroGrid1.FirstDisplayedScrollingRowIndex;
                    metroGrid1.Rows.Clear();
                    zmiana_zakresu_dat(Zadania);                  
                    Display_specific_task_details(id);
                    metroGrid1.FirstDisplayedScrollingRowIndex = pozycja_scrollbaru;
                    if (TextBoxSzukanaFraza.Text != string.Empty)
                    {
                        Wyszukiwanie();
                    }
                    
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
            if (Wszystkie_Zadania_Z_Bazy.Count > 0)
            {
                metroGrid1.Rows[metroGrid1.CurrentRow.Index].Cells[6].Style.SelectionBackColor = kolor(Znajdz_index_na_liscie(metroGrid1.Rows[metroGrid1.CurrentRow.Index].Cells[0].Value.ToString()))[0];   //pozostawienie koloru terminu mimo zaznaczenia
                string id = metroGrid1[0, metroGrid1.CurrentRow.Index].Value.ToString();  //id zadania w aktalnie zaznaczonym wierszu
                Load_Task_Details(Znajdz_index_na_liscie(id));  //wyświetlenie szczegolow zaznaczonego zadania
                
            }

        }



        //wyświetlanie szczegółów po kliknięciu na zadanie w tabeli
        private void metroGrid1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex != -1)
            {

                metroGrid1.ClearSelection(); //po kliknieciu na wiersz nastąpi wyczyszczenie wszyskich zaznaczeń 
                metroGrid1.Rows[e.RowIndex].Selected = true; //zaznaczenie kliknietego wiersza
                int pozycja_scrollbaru = metroGrid1.FirstDisplayedScrollingRowIndex;
                //ComboBoxDetailsWykonawcy.Text = Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(metroGrid1[0, e.RowIndex].Value.ToString())].Wykonawca;
                ComboBoxDetailsZmienPriorytet.Text = Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(metroGrid1[0, e.RowIndex].Value.ToString())].Priorytet.ToString();
                metroGrid1.FirstDisplayedScrollingRowIndex = pozycja_scrollbaru;
               
                //klikanie w zadanie w trakcie wyszukiwania
                if (TextBoxSzukanaFraza.Text != string.Empty) 
                {
                    Wyszukiwanie();
                    metroGrid1.Rows[metroGrid1.CurrentRow.Index].Selected = true;
                    Display_specific_task_details(Convert.ToInt32(metroGrid1[0, e.RowIndex].Value));
                 
                }
                
            }

        }



        /*------------------------------------------------ ZMIANY FILTRÓW, ZAKRESU DAT, SORTOWANIA  ------------------------------------------------*/

        // zmiana filtru "wykonawca"
        private void ComboBoxWykonawcy_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtrowanie(ComboBoxWykonawcy.Text, ComboBoxStatus.Text);
            TextBoxSzukanaFraza.Text = "";
            if (Zadania.Count != 0)
            {
                DateTimeZakresDatOd.Value = Zadania[0].Data_dodania;
                DateTimeZakresDatDo.Value = Zadania[Zadania.Count - 1].Data_dodania;
            }
        }
        //zmiana filtru "status"
        private void ComboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtrowanie(ComboBoxWykonawcy.Text, ComboBoxStatus.Text);
            TextBoxSzukanaFraza.Text = "";
            if (Zadania.Count != 0)
            {
                DateTimeZakresDatOd.Value = Zadania[0].Data_dodania;
                DateTimeZakresDatDo.Value = Zadania[Zadania.Count - 1].Data_dodania;
            }
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
        //zmiana ustawień zakresu dat
        private void CheckBoxZakresDatTermin_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxZakresDatTermin.Checked == true) CheckBoxZakresDatDataDodania.Checked = false;
            else CheckBoxZakresDatDataDodania.Checked = true;
            zmiana_zakresu_dat(Zadania);
        }

        private void CheckBoxZakresDatDataDodania_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxZakresDatDataDodania.Checked == true) CheckBoxZakresDatTermin.Checked = false;
            else CheckBoxZakresDatTermin.Checked = true;
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
            if (zalogowany == true)
            {
                if (metroGrid1.Rows.Count != 0)
                {
                    int db_id = Convert.ToInt32(TextBoxDetailsID.Text);

                    if (Czy_usunac(Znajdz_index_na_liscie_ograniczonej(db_id.ToString())) == true)
                    {
                        string zapytanie = "DELETE FROM `zadania` WHERE `zadania`.`id_zadania` = " + db_id + "";
                        BazaDanych(zapytanie, Dane[0], Dane[1], Dane[2], Dane[3], Dane[4]);

                        //ZAPISANIE USUNIETEGO ZADANIA DO BAZY
                        string zapytanie2="";
                        int prio = Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(db_id.ToString())].Priorytet;
                        string zad = Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(db_id.ToString())].Zadanie;
                        string ro = Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(db_id.ToString())].Rodzaj;
                        string wyk = Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(db_id.ToString())].Wykonawca;
                        string data_dod = Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(db_id.ToString())].Data_dodania.ToString("yyyy-MM-dd H:mm:ss");
                        bool status = Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(db_id.ToString())].Status;
                        string dat_wyk = Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(db_id.ToString())].Data_wykonania;
                        string dod_przez = Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(db_id.ToString())].Dodane_przez;
                        string dat_usuniecia = DateTime.UtcNow.ToLocalTime().ToString("yyyy-MM-dd H:mm:ss");
                     
                        if (Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(db_id.ToString())].Termin != string.Empty && Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(db_id.ToString())].Termin != null)
                        {
                            string term = Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(db_id.ToString())].Termin;
                            zapytanie2 += "INSERT INTO `usuniete` (`id_zadania`, `priorytet`, `zadanie`, `rodzaj`, `wykonawca`, `data_dodania`, `termin`, `status`, `data_wykonania`, `dodane_przez`, `data_usuniecia`, `usuniete_przez`) " +
                                 "VALUES (" + db_id + ", " + prio + ", '" + zad + "', '" + ro + "', '" + wyk + "', '" + data_dod + "', '" + term + "', " + status + ", '" + dat_wyk + "', '" + dod_przez + "', '" + dat_usuniecia + "', '" + zalogowany_user + "');";
                        }
                        else if (Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(db_id.ToString())].Termin == string.Empty || Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(db_id.ToString())].Termin == null)
                        {
                            zapytanie2 += "INSERT INTO `usuniete` (`id_zadania`, `priorytet`, `zadanie`, `rodzaj`, `wykonawca`, `data_dodania`, `termin`, `status`, `data_wykonania`, `dodane_przez`, `data_usuniecia`, `usuniete_przez`) " +
                                     "VALUES (" + db_id + ", " + prio + ", '" + zad + "', '" + ro + "', '" + wyk + "', '" + data_dod + "', '" + null + "', " + status + ", '" + dat_wyk + "', '" + dod_przez + "', '" + dat_usuniecia + "', '" + zalogowany_user + "');";
                        }
                        BazaDanych(zapytanie2, Dane[0], Dane[1], Dane[2], Dane[3], Dane[4]);

                        //USUWANIE
                        Zadania.RemoveAt(Znajdz_index_na_liscie_ograniczonej(db_id.ToString()));
                        Wszystkie_Zadania_Z_Bazy.RemoveAt(Znajdz_index_na_liscie(db_id.ToString()));
                        metroGrid1.Rows.Clear();
                        if (Zadania.Count > 0)
                        {
                           
                            DateTimeZakresDatOd.Value = Zadania[0].Data_dodania;
                            DateTimeZakresDatDo.Value = Zadania[Zadania.Count - 1].Data_dodania;
                            zmiana_zakresu_dat(Zadania);
                            Display_first_task_details();
                            ZadaniaNaDzis();
                        }


                        

                    }
                    else
                    {

                    }
                }
            }
            else MessageBox.Show("Musisz być zalogowany, żeby usunąć zadanie.");
        }


        //POBIERANIE PLIKU Z USUNIĘTYMI ZADANIAMI
        private void ButtonPobierzUsuniete_Click_1(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                string path = fbd.SelectedPath;
                DateTime data_usuniecia_od = Convert.ToDateTime(DateTimeUsunieteOD.Value.ToString("yyyy-MM-dd"));
                DateTime data_usuniecia_do = Convert.ToDateTime(DateTimeUsunieteDO.Value.ToString("yyyy-MM-dd"));

                try
                {
                    DbConnection connection = new DbConnection(Dane[0], Dane[1], Dane[2], Dane[3], Dane[4]);
                    MySqlConnection con = connection.polaczenie();
                    con.Open();

                    MySqlCommand komenda1 = con.CreateCommand();

                    komenda1.CommandText = "SELECT * FROM `usuniete`";
                    MySqlDataReader r = komenda1.ExecuteReader();

                    string file_name = "";
                    if(CheckBoxUsunieteWszystkie.Checked == false) file_name += path + "\\usuniete-" + data_usuniecia_od.ToString("yyyy.MM.dd") +"-"+ data_usuniecia_do.ToString("yyyy.MM.dd") + ".txt"; 
                    else file_name += path + "\\usuniete-" + DateTime.UtcNow.ToLocalTime().ToShortDateString() + ".txt";
                    
                    int nr_zadania = 1;
                    FileStream usuniete;
                    if (File.Exists(file_name))
                    {
                        File.WriteAllText(file_name, String.Empty);
                        usuniete = new FileStream(file_name, FileMode.Append, FileAccess.Write);
                    }
                    else
                    {
                        usuniete = new FileStream(file_name, FileMode.CreateNew);
                    }
                    StreamWriter writer = new StreamWriter(usuniete);

                    writer.WriteLine("Pobrano " + DateTime.UtcNow.ToLocalTime());
                    writer.WriteLine("Zakres dat: " + data_usuniecia_od.ToShortDateString() + " - " + data_usuniecia_do.ToShortDateString());
                    writer.WriteLine(" ");
                    while (r.Read())
                    {

                        string status = "";
                        if (Convert.ToBoolean(r["status"]) == true) status += "wykonane";
                        else  status += "niewykonane";
                        string termin = "";
                        if (r["termin"].ToString() == null || r["termin"].ToString() == string.Empty) termin += "bezterminowe";
                        else if (r["termin"].ToString() != null && r["termin"].ToString() != string.Empty) termin += r["termin"];

                        DateTime data_usuniecia = Convert.ToDateTime(Convert.ToDateTime(r["data_usuniecia"]).ToString("yyyy-MM-dd"));

                        if (CheckBoxUsunieteWszystkie.Checked == true)
                        {

                            writer.WriteLine(nr_zadania + ".");
                            writer.WriteLine("   ID: " + r["id_zadania"]);
                            writer.WriteLine("   Priorytet: " + r["priorytet"]);
                            writer.WriteLine("   Zadanie: " + r["zadanie"]);
                            writer.WriteLine("   Rodzaj: " + r["rodzaj"]);
                            writer.WriteLine("   Wykonawca: " + r["wykonawca"]);
                            writer.WriteLine("   Data dodania: " + r["data_dodania"]);
                            writer.WriteLine("   Termin: " + termin);
                            writer.WriteLine("   Status: " + status);
                            if (status == "wykonane") writer.WriteLine("   Data wykonania: " + r["data_wykonania"]);
                            writer.WriteLine("   Dodane przez: " + r["dodane_przez"]);
                            writer.WriteLine("   Data usunięcia: " + r["data_usuniecia"]);
                            writer.WriteLine("   Usunięte przez: " + r["usuniete_przez"]);

                            nr_zadania++;
                        }
                        else
                        {
                            if (data_usuniecia >= data_usuniecia_od && data_usuniecia <= data_usuniecia_do)
                            {
                                writer.WriteLine(nr_zadania + ".");
                                writer.WriteLine("   ID: " + r["id_zadania"]);
                                writer.WriteLine("   Priorytet: " + r["priorytet"]);
                                writer.WriteLine("   Zadanie: " + r["zadanie"]);
                                writer.WriteLine("   Rodzaj: " + r["rodzaj"]);
                                writer.WriteLine("   Wykonawca: " + r["wykonawca"]);
                                writer.WriteLine("   Data dodania: " + r["data_dodania"]);
                                writer.WriteLine("   Termin: " + termin);
                                writer.WriteLine("   Status: " + status);
                                if (status == "wykonane") writer.WriteLine("   Data wykonania: " + r["data_wykonania"]);
                                writer.WriteLine("   Dodane przez: " + r["dodane_przez"]);
                                writer.WriteLine("   Data usunięcia: " + r["data_usuniecia"]);
                                writer.WriteLine("   Usunięte przez: " + r["usuniete_przez"]);

                                nr_zadania++;
                            }
                        }
                    }
                    writer.Close();
                    usuniete.Close();
                    r.Close();
                    MessageBox.Show("Pobrano plik z usuniętymi zadaniami.");
                }
                catch (Exception u)
                {
                    MessageBox.Show("Wystąpił błąd" + u.ToString() + "  od: "+data_usuniecia_od + " do: "+data_usuniecia_do);
                }
            }
            else MessageBox.Show("Nie wybrano miejsca zapisu pliku.");
        }


        /*------------------------------------------------ EDYCJA ZADANIA  ------------------------------------------------*/

        //przycisk otwiercjący Form3 z edycją zadania
        private void ButtonEditTask_Click(object sender, EventArgs e)
        {
            if (metroGrid1.Rows.Count != 0)
            {
                Form3 EdytujZadanie = new Form3(this);
                EdytujZadanie.ShowDialog();
            }
            else MessageBox.Show("error");
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


        /*------------------------------------------------ ODŚWIEŻANIE  ------------------------------------------------*/
        private void metroButton2_Click(object sender, EventArgs e)
        {
            refresh();
        }


        /*------------------------------------------------ BACKUP BAZY DANYCH  ------------------------------------------------*/
        List<Backup> BackupUstawienia = new List<Backup>();
        //MIEJSCE ZAPISU EKSPORTU BAZY
        //zmiana na baze
        private void metroButtonDoceloweMiejsceeksportu_Click(object sender, EventArgs e)
        {
            if (zalogowany == true)
            {
                var fbd = new FolderBrowserDialog();
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string file = fbd.SelectedPath;
                    string file2 = "";
                    for(int i=0; i<file.Length; i++)
                    {
                        //file_tab[i] = file[i].ToString();
                        if (file[i] == '\\') file2 += file[i].ToString() + "\\";
                        else file2 += file[i].ToString();
                    }

                    metroLabelMiejsceZapisuEksportu.Text = file;
                    int czestotliwosc = 7;
                    if (metroTextBoxIleDni.Text != string.Empty) czestotliwosc = Convert.ToInt32(metroTextBoxIleDni.Text);

                    if (BackupUstawienia.Count <= 0)
                    {
                        string komenda2 = "INSERT INTO `backup_ustawienia` (`lokalizacja`, `czestotliwosc`, `wykonawca`) VALUES ('" + file2 + "', '" + czestotliwosc + "', '" + zalogowany_user + "');";
                        BazaDanych(komenda2, Dane[0], Dane[1], Dane[2], Dane[3], Dane[4]);
                    }
                    else
                    {
                        string komenda3 = "UPDATE `backup_ustawienia` SET `lokalizacja` = '"+file2+"', `czestotliwosc` = '"+czestotliwosc+"', `wykonawca` = '"+zalogowany_user+"' WHERE `backup_ustawienia`.`id_ustawien` = "+BackupUstawienia[0].id_ustawien+";";
                        BazaDanych(komenda3, Dane[0], Dane[1], Dane[2], Dane[3], Dane[4]);
                    }
                }
            } else MessageBox.Show("Nie jesteś zalogowany!");
        }

        //wpisywanie tylko liczb do textboxa ustawiającego co ile dni ma być wykonywany backup bazy
        private void metroTextBoxIleDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
                base.OnKeyPress(e);
            else
                e.Handled = true;
        }

        //EKSPORT BAZY DANYCH
        private void metroButtonEksport_Click(object sender, EventArgs e)
        {
            eksport_bazy();
        }

        //IMPORT BAZY DANYCH
        private void metroButtonImport_Click(object sender, EventArgs e)
        {
            string baza_test = "bazatest";
            OpenFileDialog FileDialog;
            FileDialog = new OpenFileDialog();
            FileDialog.Title = "Browse sql files";
            FileDialog.DefaultExt = "sql";
            FileDialog.Filter = "sql files (*.sql)|*.sql|All files (*.*)|*.*";
            FileDialog.ShowDialog();

            string constring = "server=" + Dane[0] + ";port=" + Dane[1] + ";user=" + Dane[3] + ";pwd=" + Dane[4] + ";database=" + baza_test + "; Convert Zero Datetime=True";

            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                DialogResult dialogResult = MessageBox.Show("Czy na pewno importować bazę " + FileDialog.FileName + " do bazy " + Dane[2] + "?", "Import bazy", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new MySqlConnection(constring))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            using (MySqlBackup mb = new MySqlBackup(cmd))
                            {
                                try
                                {
                                    cmd.Connection = conn;
                                    conn.Open();
                                    mb.ImportFromFile(FileDialog.FileName);
                                    conn.Close();
                                    MessageBox.Show("Pomyslnie importowano bazę.");

                                }
                                catch (Exception db)
                                {
                                    MessageBox.Show("wystąpił błąd " + db.ToString());
                                }
                            }
                        }
                    }
                }
            }
        }






        //
        //.......
        /*  ############################################# FUNKCJE ############################################# */
        //......
        //


        /*---------------------------------------- PODSTAWOWE wynikające z ustawień (użytkownik, baza danych) ----------------------------------------*/


        //automatyczne zapisywanie kopii zapasowej bazy danych
        //zmiana na baze
        private void autosave()
        {
            
            DbConnection connection = new DbConnection(Dane[0], Dane[1], Dane[2], Dane[3], Dane[4]);
            MySqlConnection con = connection.polaczenie();
            con.Open();
            MySqlCommand komenda = con.CreateCommand();
            komenda.CommandText = "SELECT * FROM backup";
            MySqlDataReader t = komenda.ExecuteReader();
            daty_uruchomien_programu.Clear();
            while(t.Read())
            {
                daty_uruchomien_programu.Add(new DatyUruchomieniaProgramu(Convert.ToInt32(t["id_daty"]),t["data"].ToString()));
            }
            t.Close();
            con.Close();
 
            bool czy_zawiera = false;
            //sprawdzenie czy dzisiejsza data jest juz zapisana
            for(int i=0; i < daty_uruchomien_programu.Count; i++)
            {
                if (daty_uruchomien_programu[i].data == DateTime.UtcNow.ToLocalTime().ToShortDateString())
                {
                    czy_zawiera = true;
                    break;
                }
            }

            //zapisywanie daty jeśli jeszcze nie była zapisana
            //if (czy_zawiera == false)
           // {
                int nowe_id = 1;
                if (daty_uruchomien_programu.Count > 0) nowe_id = daty_uruchomien_programu[daty_uruchomien_programu.Count - 1].id_daty + 1;
                string data = DateTime.UtcNow.ToLocalTime().ToString("yyyy-MM-dd");
                string komenda2 = "INSERT INTO `backup` (`id_daty`, `data`) VALUES (" + nowe_id + ", '" + data + "');";
                BazaDanych(komenda2, Dane[0], Dane[1], Dane[2], Dane[3], Dane[4]);
                daty_uruchomien_programu.Add(new DatyUruchomieniaProgramu(nowe_id, data));
           // }
            //sprawdzanie, czy upłynęło wystarczająco dni, żeby zrobić backup
            
                int czestotliwosc = Convert.ToInt32(metroTextBoxIleDni.Text);
                if(daty_uruchomien_programu.Count >= czestotliwosc)
                {
                   if (BackupUstawienia.Count > 0)
                   {
                     eksport_bazy();
                     for(int i=0; i<daty_uruchomien_programu.Count;i++)
                     {
                       string komenda3 = "DELETE FROM `backup` WHERE `backup`.`id_daty` = "+daty_uruchomien_programu[i].id_daty+"";
                       BazaDanych(komenda3, Dane[0], Dane[1], Dane[2], Dane[3], Dane[4]);
                     }
                     daty_uruchomien_programu.Clear();
                   }
                   else
                   {       
                    MessageBox.Show("Automatyczny backup bazy danych nie został wykonany, ponieważ nie wybrano miejsca zapisu. Wybierz miejsce zapisu w ustawieniach i wykonaj backup ręcznie.");
                   }
                }

            int kolejny = (czestotliwosc - daty_uruchomien_programu.Count);
            string info = "";
            string ilosc_dni = "";
            if(BackupUstawienia.Count > 0)
            {
                info += "Kolejna kopia bazy zostanie wykonana ";
                if (kolejny == 1) ilosc_dni += "w kolejnym dniu.";
                else if (kolejny == 0) ilosc_dni += "za " + czestotliwosc + " dni.";
                else if (kolejny > 1) ilosc_dni += "za " + kolejny + " dni.";
            }
            else
            {
                info += "Kolejna kopia bazy danych powinna zostać wykonana ";
                if (kolejny == 1) ilosc_dni += ilosc_dni += "w kolejnym dniu.";
                else if (kolejny == 0) ilosc_dni += "dzis"; //"za " + czestotliwosc + " dni.";
                else if (kolejny > 1) ilosc_dni += "za " + kolejny + " dni.";
                else if (kolejny < 0) ilosc_dni += (kolejny * (-1)) + " dni temu.";
                else if (kolejny == -1) info += "1 dzień temu.";
            }           
            metroLabelKolejnyBacku.Text = info + ilosc_dni;
       
        }



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
            Dane[0] = ""; Dane[1] = ""; Dane[2] = ""; Dane[3] = ""; Dane[4] = "";
            string[] odczyt_linii = new string[5];
            FileStream odczyt = new FileStream("database.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(odczyt);
            for (int i = 0; i < odczyt_linii.Count(); i++)
            {
                odczyt_linii[i] = reader.ReadLine();
            }
            reader.Close();
            odczyt.Close();
            //rodzielenie odczyt_linii do tablicy byte
            char spacja = ' ';

            //IP servera
            if (odczyt_linii[0] != " ")
            {
                string[] IP = odczyt_linii[0].Split(spacja);
                byte[] IPbyte = new byte[IP.Count() - 1];
                for (int i = 0; i < IP.Count() - 1; i++) IPbyte[i] = Convert.ToByte(IP[i]);
                try
                {
                    using (Szyfr.CreateDecryptor(key, iv))
                    {
                        Dane[0] += DecryptStringFromBytes(IPbyte, key, iv);
                    }
                }
                catch (Exception x)
                {
                    // Dane[0] += "1.1";
                    MessageBox.Show("Error: database()1 {0}", x.Message);
                }
            }
            else Dane[0] += "0.2";
            //PORT
            if (odczyt_linii[1] != " ")
            {
                string[] Port = odczyt_linii[1].Split(spacja);
                byte[] Portbyte = new byte[Port.Count() - 1];
                for (int i = 0; i < Port.Count() - 1; i++) Portbyte[i] = Convert.ToByte(Port[i]);
                try
                {
                    using (Szyfr.CreateDecryptor(key, iv))
                    {
                        Dane[1] += DecryptStringFromBytes(Portbyte, key, iv);
                    }
                }
                catch (Exception x)
                {
                    // Dane[1] += "1.1";
                    MessageBox.Show("Error: database()1 {0}", x.Message);
                }
            }
            else Dane[1] += "";
            //DB NAME
            if (odczyt_linii[2] != " ")
            {
                string[] Name = odczyt_linii[2].Split(spacja);
                byte[] Namebyte = new byte[Name.Count() - 1];
                for (int i = 0; i < Name.Count() - 1; i++) Namebyte[i] = Convert.ToByte(Name[i]);
                try
                {
                    using (Szyfr.CreateDecryptor(key, iv))
                    {
                        Dane[2] += DecryptStringFromBytes(Namebyte, key, iv);
                    }
                }
                catch (Exception x)
                {
                    //Dane[2] += "2.1";
                    MessageBox.Show("Error: database()2 {0}", x.Message);
                }
            }
            else Dane[2] += "";
            //DB USER
            if (odczyt_linii[3] != " ")
            {
                string[] User = odczyt_linii[3].Split(spacja);
                byte[] Userbyte = new byte[User.Count() - 1];
                for (int i = 0; i < User.Count() - 1; i++) Userbyte[i] = Convert.ToByte(User[i]);
                try
                {
                    using (Szyfr.CreateDecryptor(key, iv))
                    {
                        Dane[3] += DecryptStringFromBytes(Userbyte, key, iv);
                    }
                }
                catch (Exception x)
                {
                    // Dane[3] += "3.1";
                    MessageBox.Show("Error: database()3 {0}", x.Message);
                }
            }
            else Dane[3] += "3.2";
            //DB PASSWORD
            if (odczyt_linii[4] != " ")
            {
                string[] Password = odczyt_linii[4].Split(spacja);
                byte[] Passwordbyte = new byte[Password.Count() - 1];
                for (int i = 0; i < Password.Count() - 1; i++) Passwordbyte[i] = Convert.ToByte(Password[i]);
                try
                {
                    using (Szyfr.CreateDecryptor(key, iv))
                    {
                        Dane[4] += DecryptStringFromBytes(Passwordbyte, key, iv);
                    }
                }
                catch (Exception x)
                {
                    // Dane[4] += "4.1";
                    MessageBox.Show("Error: database()4 {0}", x.Message);
                }
            }
            else Dane[4] += "";
           
            DB_first_connection();


        }

        private void DB_first_connection()
        {
            TextBoxServerID.Text = Dane[0];
            TextBoxDBPort.Text = Dane[1];
            TextBoxDBName.Text = Dane[2];
            TextBoxDBUser.Text = Dane[3];
            TextBoxDBPassword.Text = "";
            for (int i = 0; i < Dane[4].Length; i++) TextBoxDBPassword.Text += "*";

            try
            {
                DbConnection connection = new DbConnection(Dane[0], Dane[1], Dane[2], Dane[3], Dane[4]);
                MySqlConnection con = connection.polaczenie();
                con.Open();

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

                Uzytkownicy.Clear();
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
                connected = true;
            }

            catch (MySqlException e)
            {
                connected = false;
                MessageBox.Show("Wystąpił błąd podczas łączenia z bazą." + e.ToString());
                TextBoxDBinfo.Text = "Brak połączenia z bazą";
            }
        }

        
        //pobieranie rodzajów zadań z bazy i wypisywanie ich w datagrid
        public void WypelnijMetroGridRodzaje()
        {

            try
            {
                DbConnection connection = new DbConnection(Dane[0], Dane[1], Dane[2], Dane[3], Dane[4]);
                MySqlConnection con = connection.polaczenie();
                con.Open();
                MySqlCommand komendaSQL = con.CreateCommand();
                komendaSQL.CommandText = "SELECT * from rodzaje_zadan";
                MySqlDataReader r = komendaSQL.ExecuteReader();
                Rodzaje.Clear();
                while (r.Read())
                {
                    int id_rodzaju = Convert.ToInt32(r["id_rodzaju"]);
                    string rodzaj = r["rodzaj"].ToString();
                    Types rodzaj_zadania = new Types(id_rodzaju, rodzaj);
                    Rodzaje.Add(rodzaj_zadania);
                }
                r.Close();
                con.Close();
                metroGridRodzaje.Rows.Clear();
                for (int i = 0; i < Rodzaje.Count; i++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(metroGridRodzaje);
                    row.Cells[0].Value = Rodzaje[i].id_rodzaju;
                    row.Cells[1].Value = Rodzaje[i].rodzaj;

                    metroGridRodzaje.Rows.Add(row);
                }
            }
            catch (MySqlException ee)
            {
                MessageBox.Show("Wystąpił błąd podczas łączenia z bazą.");

            }

        }


        //odczyt miejsca zapisu backupu
        private void odczyt_miejsca_zapisu_backupu()
        {
            //sprawdzenie, czy ustawienia są już zapisane
            DbConnection connection = new DbConnection(Dane[0], Dane[1], Dane[2], Dane[3], Dane[4]);
            MySqlConnection con = connection.polaczenie();
            con.Open();
            MySqlCommand komenda1 = con.CreateCommand();
            komenda1.CommandText = "SELECT * FROM backup_ustawienia";
            MySqlDataReader r = komenda1.ExecuteReader();
            BackupUstawienia.Clear();
            while (r.Read())
            {
                int id_ustawien = Convert.ToInt32(r["id_ustawien"]);
                string lokalizacja = r["lokalizacja"].ToString();
                int czestotliwosc = Convert.ToInt32(r["czestotliwosc"]);
                string wykonawca = r["wykonawca"].ToString();
                BackupUstawienia.Add(new Backup(id_ustawien, lokalizacja, czestotliwosc, wykonawca));
            }
            r.Close(); 
            con.Close();

            if (BackupUstawienia.Count > 0)
            {
                metroTextBoxIleDni.Text = BackupUstawienia[0].czestotliwosc.ToString();
                if (BackupUstawienia[0].lokalizacja != string.Empty) metroLabelMiejsceZapisuEksportu.Text = BackupUstawienia[0].lokalizacja;
                else metroLabelMiejsceZapisuEksportu.Text = "nie wybrano";
            }
            else
            {
                metroTextBoxIleDni.Text = "7";
                metroLabelMiejsceZapisuEksportu.Text = "nie wybrano";
            }
        }

        //EKSPORT BAZY DANYCH
        private void eksport_bazy()
        {
            if (connected == true)
            {
                string constring = "server=" + Dane[0] + ";port=" + Dane[1] + ";user=" + Dane[3] + ";pwd=" + Dane[4] + ";database=" + Dane[2] + "; Convert Zero Datetime=True";

                if (metroLabelMiejsceZapisuEksportu.Text != "nie wybrano")
                {
                    string nazwa_pliku = "\\backup-" + DateTime.UtcNow.ToLocalTime().ToString("yyyy.MM.dd-H.mm.ss") + ".sql";
                    string file = metroLabelMiejsceZapisuEksportu.Text + nazwa_pliku;

                    using (MySqlConnection conn = new MySqlConnection(constring))
                    {
                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            using (MySqlBackup mb = new MySqlBackup(cmd))
                            {
                                try
                                {
                                    cmd.Connection = conn;
                                    conn.Open();
                                    mb.ExportToFile(file);
                                    conn.Close();
                                }
                                catch (Exception p)
                                {

                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Wybierz miejsce zapisu pobieranej kopii zapasowej bazy danych.");
                }

            }
        }


        /*---------------------------------------- PODSTAWOWE (m.in. przy uruchamianiu) ----------------------------------------*/

        //odczytynie ustawień widoczności kolumn, odpowiednie zaznaczenie checkboków i ukrywanie odpowiednich kolumn
        private void Odczyt_Ustawien_Kolumn()
        {
            if (File.Exists("ustawieniaKolumn.txt"))
            {
                string[] Zaznaczenia = new string[10];
                FileStream odczyt = new FileStream("ustawieniaKolumn.txt", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(odczyt);
                for (int i = 0; i < 10; i++)
                {

                    Zaznaczenia[i] = reader.ReadLine();
                }
                reader.Close();
                odczyt.Close();
               
                Widocznosc_kolumn_ustawiona(Zaznaczenia);
            }
            else
            {
                Widocznosc_Kolumn_Domyslnie();
            }
        }


        //Po uruchomieniu zaznaczenie pierwszego wiersza i wyświetlanie szczegółów pierwszego zadania z datagrid view
        public void Display_first_task_details()
        {
            //Zaznaczenie odpowiedniego wiersza (o ile jakis jest)
            if (metroGrid1.Rows.Count != 0)
            {
                this.metroGrid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.metroGrid1.MultiSelect = false;

                metroGrid1.ClearSelection();
                metroGrid1.Rows[0].Selected = true;
                string id = metroGrid1[0, 0].Value.ToString();  //id zadania w aktalnie zaznaczonym wierszu
                metroGrid1.Rows[0].Cells[6].Style.SelectionBackColor = kolor(Znajdz_index_na_liscie(id))[0];   //pozostawienie koloru terminu mimo zaznaczenia
                Load_Task_Details(Znajdz_index_na_liscie(id));

            }

        }

        //zaznaczenie konkretnego wiersza i wyeswietlenie szczegolow odpowiedniego zadania (głównie dopodtrzymywania zaznaczenia po jakiejś zmianie, np zmianie statusu zadania)
        public void Display_specific_task_details(int id)
        {
            if (metroGrid1.Rows.Count != 0)
            {
                this.metroGrid1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.metroGrid1.MultiSelect = false;

                //znalezienie indexu wiersza na podstawie id
                int numerWiersza = NumerWiersza(id);
                metroGrid1.ClearSelection();
                metroGrid1.Rows[numerWiersza].Selected = true;
                metroGrid1.Rows[numerWiersza].Cells[6].Style.SelectionBackColor = kolor(Znajdz_index_na_liscie(id.ToString()))[0];   //pozostawienie koloru terminu mimo zaznaczenia
                Load_Task_Details(Znajdz_index_na_liscie(id.ToString()));

            }
        }

        //funkcja do wyświetlania kolejnych wierszy DataGrid/metroGrid
        public void ShowRow(List<Tasks> lista)
        {

            metroGrid1.Rows.Clear();
            for (int i = 0; i < lista.Count; i++)
            {
               
                    TerminZadania(Zadania, i);
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
            metroGridUzytkownicy.Rows.Clear();
            for (int i = 0; i < Uzytkownicy.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(metroGridUzytkownicy);
                row.Cells[0].Value = Uzytkownicy[i].id_uzytkownika;
                row.Cells[1].Value = Uzytkownicy[i].nazwa_uzytkownika;
                metroGridUzytkownicy.Rows.Add(row);
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

            metroTabTaskDetails.Show();
            Wczytaj_wykonawcow(ComboBoxDetailsWykonawcy);

            if (Wszystkie_Zadania_Z_Bazy.Count > 0)
            {
                TextBoxDetailsPriorytet.Text = Wszystkie_Zadania_Z_Bazy[index].Priorytet.ToString();
                TextBoxDetailsID.Text = Wszystkie_Zadania_Z_Bazy[index].Id_zadania.ToString();
                TextBoxDetailsZadanie.Text = Wszystkie_Zadania_Z_Bazy[index].Zadanie;
                TextBoxDetailsWykonawca.Text = Wszystkie_Zadania_Z_Bazy[index].Wykonawca;
                TextBoxDetailsRodzaj.Text = Wszystkie_Zadania_Z_Bazy[index].Rodzaj;
                TextBoxDetailsOpis.Text = Wszystkie_Zadania_Z_Bazy[index].Opis;
                TextBoxDetailsDodanePrzez.Text = Wszystkie_Zadania_Z_Bazy[index].Dodane_przez;
                TextBoxDetailsDataDod.Text = Wszystkie_Zadania_Z_Bazy[index].Data_dodania.ToString();


                //W zależności od tego, czy zadanie ma termin wykonania
                if (Wszystkie_Zadania_Z_Bazy[index].Termin != null && Wszystkie_Zadania_Z_Bazy[index].Termin != string.Empty)
                {
                    TextBoxDetailsTerm.Show();
                    TextBoxDetailsTerm.Text = Wszystkie_Zadania_Z_Bazy[index].Termin.ToString();
                    groupBoxDetailsTerm.BackColor = kolor(index)[0];
                    TextBoxDetailsTerm.BackColor = kolor(index)[1];
                }
                else if (Wszystkie_Zadania_Z_Bazy[index].Termin == null || Wszystkie_Zadania_Z_Bazy[index].Termin == string.Empty)
                {
                    //TextBoxDetailsTerm.Hide();
                    TextBoxDetailsTerm.Text = "brak";
                    groupBoxDetailsTerm.BackColor = kolor(index)[0];
                }

                //W zależności od stanuzadania
                if (Wszystkie_Zadania_Z_Bazy[index].Status == true)  //jeśli zadanie jest zakończone
                {
                    textBoxIle_dni_do_konca_zadania2.Text = "ZADANIE ZAKOŃCZONE";
                   // textBoxIle_dni_do_konca_zadania.BackColor = kolor(index)[0];
                   // textBoxIle_dni_do_konca_zadania.ForeColor = Color.Black;
                    TextBoxDetailsStatus.Text = "wykonane";
                    TextBoxDetailsDataZak.Text = Wszystkie_Zadania_Z_Bazy[index].Data_wykonania;
                }
                else
                {
                    textBoxIle_dni_do_konca_zadania2.Show();
                    string czas = ile_czasu_do_konca_zadania(index, Wszystkie_Zadania_Z_Bazy);
                    if (czas == null || czas == string.Empty) textBoxIle_dni_do_konca_zadania2.Text = "ZADANIE BEZTERMINOWE";
                    else if (Convert.ToInt32(czas) == 0) textBoxIle_dni_do_konca_zadania2.Text = "DEADLINE";
                    else if (Convert.ToInt32(czas) < 0) textBoxIle_dni_do_konca_zadania2.Text = "ZADANIE PO TERMINIE";
                    else if (Convert.ToInt32(czas) == 1) textBoxIle_dni_do_konca_zadania2.Text = czas + " DZIEŃ DO KOŃCA ZADANIA";
                    else textBoxIle_dni_do_konca_zadania2.Text = czas + " DNI DO KOŃCA ZADANIA";

                  //  textBoxIle_dni_do_konca_zadania.BackColor = kolor(index)[0];
                   // textBoxIle_dni_do_konca_zadania.ForeColor = kolor(index)[1];
                    TextBoxDetailsStatus.Text = "niewykonane";
                    TextBoxDetailsDataZak.Text = "";
                }

                kolor_terminu_w_dataGrid();
            }
            else metroTabTaskDetails.Hide();

        }


        // Domyślne ustawienia widoczności kolumn
        private void Widocznosc_Kolumn_Domyslnie()
        {
            //ustawienie zaznaczenia checkboxów
            metroCheckBox1.Checked = true;
            metroCheckBox1.Text = "widoczne";
            metroCheckBox2.Checked = true;
            metroCheckBox2.Text = "widoczne";
            metroCheckBox3.Checked = true;
            metroCheckBox3.Text = "widoczne";
            metroCheckBox4.Checked = true;
            metroCheckBox4.Text = "widoczne";
            metroCheckBox5.Checked = true;
            metroCheckBox5.Text = "widoczne";
            metroCheckBox6.Checked = true;
            metroCheckBox6.Text = "widoczne";
            metroCheckBox7.Checked = true;
            metroCheckBox7.Text = "widoczne";
            metroCheckBox8.Checked = true;
            metroCheckBox8.Text = "widoczne";
            metroCheckBox9.Checked = true;
            metroCheckBox9.Text = "widoczne";
            metroCheckBox10.Checked = true;
            metroCheckBox10.Text = "widoczne";
            //ustawienie widoczności kolumn
            for (int i = 0; i < 10; i++)
            {
                this.metroGrid1.Columns[i].Visible = true;
            }
        }

        //funkcja ustawiająca stan checkboxów zgodnie z ustawieniami użytkownika
        private void Widocznosc_kolumn_ustawiona(String[] tablica_ze_stanem_checkboxow)
        {
            if (tablica_ze_stanem_checkboxow[0] == "1") { metroCheckBox1.Checked = true; metroCheckBox1.Text = "widoczne"; this.metroGrid1.Columns[0].Visible = true; }
            else if (tablica_ze_stanem_checkboxow[0] == "0") { metroCheckBox1.Checked = false; metroCheckBox1.Text = "niewidoczne"; this.metroGrid1.Columns[0].Visible = false; }

            if (tablica_ze_stanem_checkboxow[1] == "1") { metroCheckBox2.Checked = true; metroCheckBox2.Text = "widoczne"; this.metroGrid1.Columns[1].Visible = true; }
            else if (tablica_ze_stanem_checkboxow[1] == "0") { metroCheckBox2.Checked = false; metroCheckBox2.Text = "niewidoczne"; this.metroGrid1.Columns[1].Visible = false; }

            if (tablica_ze_stanem_checkboxow[2] == "1") { metroCheckBox3.Checked = true; metroCheckBox3.Text = "widoczne"; this.metroGrid1.Columns[2].Visible = true; }
            else if (tablica_ze_stanem_checkboxow[2] == "0") { metroCheckBox3.Checked = false; metroCheckBox3.Text = "niewidoczne"; this.metroGrid1.Columns[2].Visible = false; }

            if (tablica_ze_stanem_checkboxow[3] == "1") { metroCheckBox4.Checked = true; metroCheckBox4.Text = "widoczne"; this.metroGrid1.Columns[3].Visible = true; }
            else if (tablica_ze_stanem_checkboxow[3] == "0") { metroCheckBox4.Checked = false; metroCheckBox4.Text = "niewidoczne"; this.metroGrid1.Columns[3].Visible = false; }

            if (tablica_ze_stanem_checkboxow[4] == "1") { metroCheckBox5.Checked = true; metroCheckBox5.Text = "widoczne"; this.metroGrid1.Columns[4].Visible = true; }
            else if (tablica_ze_stanem_checkboxow[4] == "0") { metroCheckBox5.Checked = false; metroCheckBox5.Text = "niewidoczne"; this.metroGrid1.Columns[4].Visible = false; }

            if (tablica_ze_stanem_checkboxow[5] == "1") { metroCheckBox6.Checked = true; metroCheckBox6.Text = "widoczne"; this.metroGrid1.Columns[5].Visible = true; }
            else if (tablica_ze_stanem_checkboxow[5] == "0") { metroCheckBox6.Checked = false; metroCheckBox6.Text = "niewidoczne"; this.metroGrid1.Columns[5].Visible = false; }

            if (tablica_ze_stanem_checkboxow[6] == "1") { metroCheckBox7.Checked = true; metroCheckBox7.Text = "widoczne"; this.metroGrid1.Columns[6].Visible = true; }
            else if (tablica_ze_stanem_checkboxow[6] == "0") { metroCheckBox7.Checked = false; metroCheckBox7.Text = "niewidoczne"; this.metroGrid1.Columns[6].Visible = false; }

            if (tablica_ze_stanem_checkboxow[7] == "1") { metroCheckBox8.Checked = true; metroCheckBox8.Text = "widoczne"; this.metroGrid1.Columns[7].Visible = true; }
            else if (tablica_ze_stanem_checkboxow[7] == "0") { metroCheckBox8.Checked = false; metroCheckBox8.Text = "niewidoczne"; this.metroGrid1.Columns[7].Visible = false; }

            if (tablica_ze_stanem_checkboxow[8] == "1") { metroCheckBox9.Checked = true; metroCheckBox9.Text = "widoczne"; this.metroGrid1.Columns[8].Visible = true; }
            else if (tablica_ze_stanem_checkboxow[8] == "0") { metroCheckBox9.Checked = false; metroCheckBox9.Text = "niewidoczne"; this.metroGrid1.Columns[8].Visible = false; }

            if (tablica_ze_stanem_checkboxow[9] == "1") { metroCheckBox10.Checked = true; metroCheckBox10.Text = "widoczne"; this.metroGrid1.Columns[9].Visible = true; }
            else if (tablica_ze_stanem_checkboxow[9] == "0") { metroCheckBox10.Checked = false; metroCheckBox10.Text = "niewidoczne"; this.metroGrid1.Columns[9].Visible = false; }

        }
        
        




        /*---------------------------------------- KOLORY TERMINÓW ----------------------------------------*/

        //funkcja licząca ile czasu zostało do końca zadania
        private string ile_czasu_do_konca_zadania(int index, List<Tasks> lista)
        {

            if (lista.Count > 0)
            {
                if (lista[index].Termin != null && lista[index].Termin != string.Empty)
                {
                    System.DateTime termin = Convert.ToDateTime(lista[index].Termin);
                    string term = termin.ToShortDateString();
                    //string term = termin.ToString("yyyy-MM-dd H:mm:ss");
                    string dzis = DateTime.UtcNow.ToLocalTime().ToShortDateString();
                   // string dzis = DateTime.UtcNow.ToLocalTime().ToString("yyyy-MM-dd H:mm:ss");
                    TimeSpan roznica = Convert.ToDateTime(term) - Convert.ToDateTime(dzis);
                    return roznica.Days.ToString();
                }
                else if (lista[index].Termin == null || lista[index].Termin == string.Empty)
                {
                    return string.Empty;
                }
                else return string.Empty;
            }
            else
            {
                return string.Empty;
            }
        }

        //funkcja zwracająca kolor w zależności od tego ile czasu zostało do końca zadania
       
        private Color[] kolor(int index)
        {

            Color[] kolor = new Color[2];
            string ilosc_dni = ile_czasu_do_konca_zadania(index, Wszystkie_Zadania_Z_Bazy);

            int dni;

            if (Wszystkie_Zadania_Z_Bazy.Count > 0)
            {
                //NIEZAKOŃCZONE ZADANIA
                if (Wszystkie_Zadania_Z_Bazy[index].Status == false)
                {
                    //bezteminowe wykonane i nie wykonane nie ma koloru bez zaznaczenie   
                    //ZADANIA niezakonczone Z TERMINEM
                    if (ilosc_dni != string.Empty)
                    {
                        dni = Convert.ToInt32(ilosc_dni);


                        if (dni < 0 ) { kolor[0] = Color.DarkRed; kolor[1] = Color.White; }
                        else if (dni == 0) { kolor[0] = Color.Red; kolor[1] = Color.White; }
                        else if (dni >= 1 && dni <= 4) { kolor[0] = Color.Orange; kolor[1] = Color.White; }
                        else if (dni > 4 && dni <= 10) { kolor[0] = Color.Yellow; kolor[1] = Color.Black; }
                        else if (dni > 10) { kolor[0] = Color.Green; kolor[1] = Color.White; }

                        else { kolor[1] = Color.LightGreen; kolor[1] = Color.Black; }

                    }
                    //ZADANIA niezakonczone BEZ TERMINU
                    else if (Wszystkie_Zadania_Z_Bazy[index].Termin == null || Wszystkie_Zadania_Z_Bazy[index].Termin == string.Empty) { kolor[0] = Color.LightGreen; kolor[1] = Color.Black; }

                }
                //ZAKOŃCZONE ZADANIA z teminem lub bez
                else
                {
                    kolor[0] = Color.LightGray;
                    kolor[1] = Color.Gray;
                }

                return kolor;
            }
            else return null;
        }


        //Ustawianie koloru terminu w zależności od tego ile dni zostało do końca
        private void kolor_terminu_w_dataGrid()
        {

            for (int i = 0; i < Wszystkie_Zadania_Z_Bazy.Count; i++)
            {
                for (int j = 0; j < metroGrid1.RowCount; j++)
                {
                    if (metroGrid1[0, j].Value.ToString() == Wszystkie_Zadania_Z_Bazy[i].Id_zadania.ToString() && Wszystkie_Zadania_Z_Bazy[i].Status == false) // && Wszystkie_Zadania_Z_Bazy[i].Termin != null //znaleznienie odpowiedniej komorki datagrid
                    {
                        metroGrid1[6, j].Style.BackColor = kolor(i)[0];
                        metroGrid1[6, j].Style.ForeColor = kolor(i)[1];
                        
                            
                    }
                    if (metroGrid1[0, j].Value.ToString() == Wszystkie_Zadania_Z_Bazy[i].Id_zadania.ToString() && Wszystkie_Zadania_Z_Bazy[i].Status == true)
                    {
                        metroGrid1.Rows[j].DefaultCellStyle.ForeColor = Color.Gray;
                        metroGrid1[6, j].Style.BackColor = kolor(i)[0];
                        metroGrid1[6, j].Style.ForeColor = kolor(i)[1];
                        
                    }
                    /* if (metroGrid1[0, j].Value.ToString() == Wszystkie_Zadania_Z_Bazy[i].Id_zadania.ToString() && (Wszystkie_Zadania_Z_Bazy[i].Termin == null || Wszystkie_Zadania_Z_Bazy[i].Termin == string.Empty)) // && Wszystkie_Zadania_Z_Bazy[i].Termin != null //znaleznienie odpowiedniej komorki datagrid
                     {
                         metroGrid1[6, j].Style.BackColor = kolor(i)[0];
                         metroGrid1[6, j].Style.ForeColor = kolor(i)[1];
                     }*/

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
                else return Wszystkie_Zadania_Z_Bazy[Wszystkie_Zadania_Z_Bazy.Count].Id_zadania;
            }
            else return null;
        }
        //podmiana zadania na liście filtrowanej
        public void Podmien_zadanie(int index, Tasks zmienone_zadanie)
        {
            Zadania.RemoveAt(index);
            Zadania.Insert(index, zmienone_zadanie);
        }
        //podmiana zadania na liście całościowej
        public void Podmien_zadanie_we_wszystkich(int index, Tasks zmienone_zadanie)
        {
            Wszystkie_Zadania_Z_Bazy.RemoveAt(index);
            Wszystkie_Zadania_Z_Bazy.Insert(index, zmienone_zadanie);
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
                DbConnection connection = new DbConnection(Dane[0], Dane[1], Dane[2], Dane[3], Dane[4]);
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
                metroGrid1.Rows.Clear();
                
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
                    TerminZadania(Zadania, Znajdz_index_na_liscie_ograniczonej(id.ToString()));
                    
                   // metroGrid1.Rows.Add(konwersja(zadanie));
                }
                kolor_terminu_w_dataGrid();
                r.Close();
                con.Close();
                //metroGrid1.Rows.Clear();
               
                zmiana_zakresu_dat(Zadania);       

            }
            catch (MySqlException e)
            {
                connected = false;
                MessageBox.Show("Wystąpił błąd podczas łączenia z bazą.");
                TextBoxDBinfo.Text = "Brak połączenia z bazą";
            }

        }


        //SORTOWANIE
        public void Sortowanie() //sortowanie w zależnościod kryterium
        {
            //sortowanie według terminu
            if (ComboBoxSortowanie.SelectedIndex == 6)
            {
                List<Tasks> wykonane = new List<Tasks>();
                List<Tasks> bezterminowe = new List<Tasks>();
                List<Tasks> po_terminie = new List<Tasks>();
                List<Tasks> termin = new List<Tasks>();
                metroGrid1.Columns["termin"].ValueType = System.Type.GetType("System.DateTime");

                for (int i=0; i<Zadania.Count; i++)
                {
                    if (Zadania[i].Termin == "ZAKOŃCZONE") wykonane.Add(Zadania[i]);
                    else if (Zadania[i].Termin == "BEZTERMINOWE") bezterminowe.Add(Zadania[i]);
                    else if (Convert.ToInt32(ile_czasu_do_konca_zadania(Znajdz_index_na_liscie(Zadania[i].Id_zadania.ToString()), Wszystkie_Zadania_Z_Bazy)) < 0) po_terminie.Add(Zadania[i]);
                    else termin.Add(Zadania[i]);
                }
                //malejąco
                if(CheckBoxMalejaco.Checked == true && CheckBoxRosnaco.Checked == false)
                {
                    metroGrid1.Rows.Clear();
                    for (int i = 0; i < termin.Count; i++)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(metroGrid1);
                        row.Cells[0].Value = termin[i].Id_zadania;
                        row.Cells[1].Value = termin[i].Priorytet;
                        row.Cells[2].Value = termin[i].Zadanie;
                        row.Cells[3].Value = termin[i].Rodzaj;
                        row.Cells[4].Value = termin[i].Wykonawca;
                        row.Cells[5].Value = termin[i].Data_dodania;
                        row.Cells[6].Value = Convert.ToDateTime(termin[i].Termin);
                        row.Cells[7].Value = termin[i].Status;
                        row.Cells[8].Value = termin[i].Data_wykonania;
                        row.Cells[9].Value = termin[i].Dodane_przez;
                        metroGrid1.Rows.Add(row);   
                    } 
                    this.metroGrid1.Sort(this.metroGrid1.Columns["termin"], ListSortDirection.Descending);
                    for (int i = 0; i < po_terminie.Count; i++) metroGrid1.Rows.Add(konwersja(po_terminie[i]));
                    for (int i = 0; i < bezterminowe.Count; i++) metroGrid1.Rows.Add(konwersja(bezterminowe[i]));
                    for (int i = 0; i < wykonane.Count; i++) metroGrid1.Rows.Add(konwersja(wykonane[i]));

                }
                //rosnąco
                else if(CheckBoxRosnaco.Checked == true && CheckBoxMalejaco.Checked == false)
                {
                    metroGrid1.Rows.Clear();
                    for (int i = 0; i < termin.Count; i++)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(metroGrid1);
                        row.Cells[0].Value = termin[i].Id_zadania;
                        row.Cells[1].Value = termin[i].Priorytet;
                        row.Cells[2].Value = termin[i].Zadanie;
                        row.Cells[3].Value = termin[i].Rodzaj;
                        row.Cells[4].Value = termin[i].Wykonawca;
                        row.Cells[5].Value = termin[i].Data_dodania;
                        row.Cells[6].Value = Convert.ToDateTime(termin[i].Termin);
                        row.Cells[7].Value = termin[i].Status;
                        row.Cells[8].Value = termin[i].Data_wykonania;
                        row.Cells[9].Value = termin[i].Dodane_przez;
                        metroGrid1.Rows.Add(row);
                    }
                    this.metroGrid1.Sort(this.metroGrid1.Columns["termin"], ListSortDirection.Ascending);
                    for (int i = 0; i < po_terminie.Count; i++) metroGrid1.Rows.Add(konwersja(po_terminie[i]));
                    for (int i = 0; i < bezterminowe.Count; i++) metroGrid1.Rows.Add(konwersja(bezterminowe[i]));
                    for (int i = 0; i < wykonane.Count; i++) metroGrid1.Rows.Add(konwersja(wykonane[i]));
                }
            } 
            //sortowanie według pozostałych kolumn
            else
            {
                //metroGrid1.Columns[5].ValueType = System.Type.GetType("System.DateTime");  // zmiana typu komórek data dodania <- powoduje zmiane wysokosci wiersza zadań bezterminowych
               // metroGrid1.Columns[5].DefaultCellStyle.Font = new Font("Tahoma", 9.5F);

                if (CheckBoxMalejaco.Checked == true && CheckBoxRosnaco.Checked == false)
                {
                    this.metroGrid1.Sort(this.metroGrid1.Columns[ComboBoxSortowanie.SelectedIndex], ListSortDirection.Descending);
                }
                else if (CheckBoxMalejaco.Checked == false && CheckBoxRosnaco.Checked == true)
                {
                    this.metroGrid1.Sort(this.metroGrid1.Columns[ComboBoxSortowanie.SelectedIndex], ListSortDirection.Ascending);
                }
            }

            kolor_terminu_w_dataGrid();
        }


        //ZMIANY ZAKRESU DAT
        private void zmiana_zakresu_dat(List<Tasks> lista)   // może zastępować ShowRow()
        {
            metroGrid1.Rows.Clear();
            //WEDŁUG DATY DODANIA
            if (CheckBoxZakresDatDataDodania.Checked == true)
            {
                for (int i = 0; i < lista.Count; i++)
                {   
                    //TerminZadania(lista, i);
                    DateTime data_dodania = Convert.ToDateTime(lista[i].Data_dodania.ToShortDateString());
                    DateTime data_od = Convert.ToDateTime(DateTimeZakresDatOd.Value.ToShortDateString());
                    DateTime data_do = Convert.ToDateTime(DateTimeZakresDatDo.Value.ToShortDateString());
                    if (data_dodania >= data_od && data_dodania <= data_do)
                    {
                        metroGrid1.Rows.Add(konwersja(lista[i]));
                    }
                }

            }
            //WEDŁUG TERMINU
            else if (CheckBoxZakresDatTermin.Checked == true)
            {
                for (int i = 0; i < lista.Count; i++)
                {
                   // TerminZadania(lista, i);
                    DateTime data_od = Convert.ToDateTime(DateTimeZakresDatOd.Value.ToShortDateString());
                    DateTime data_do = Convert.ToDateTime(DateTimeZakresDatDo.Value.ToShortDateString());
                    if (Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(lista[i].Id_zadania.ToString())].Termin != "BEZTERMINOWE" && Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(lista[i].Id_zadania.ToString())].Termin != "ZAKOŃCZONE" && Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(lista[i].Id_zadania.ToString())].Termin != null && Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(lista[i].Id_zadania.ToString())].Termin != string.Empty)
                    {
                        DateTime termin = Convert.ToDateTime(Convert.ToDateTime(Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(lista[i].Id_zadania.ToString())].Termin).ToShortDateString());
                        if (termin >= data_od && termin <= data_do)
                        {
                            metroGrid1.Rows.Add(konwersja(lista[i]));
                        }
                    }  
                }
 
            }
           
            Sortowanie();


            //ZADANIA ZAKONCZONE NA KONIEC DATAGRID:
          /*  if (CheckBoxZakresDatDataDodania.Checked == true)
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    //TerminZadania(lista, i);
                    DateTime data_dodania = Convert.ToDateTime(lista[i].Data_dodania.ToShortDateString());
                    DateTime data_od = Convert.ToDateTime(DateTimeZakresDatOd.Value.ToShortDateString());
                    DateTime data_do = Convert.ToDateTime(DateTimeZakresDatDo.Value.ToShortDateString());
                    if ((data_dodania >= data_od && data_dodania <= data_do) && lista[i].Status == true)
                    {
                        metroGrid1.Rows.Add(konwersja(lista[i]));
                    }
                }
            }else if(CheckBoxZakresDatTermin.Checked == true)
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    // TerminZadania(lista, i);
                    DateTime data_od = Convert.ToDateTime(DateTimeZakresDatOd.Value.ToShortDateString());
                    DateTime data_do = Convert.ToDateTime(DateTimeZakresDatDo.Value.ToShortDateString());
                    if (Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(lista[i].Id_zadania.ToString())].Termin != "BEZTERMINOWE" && Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(lista[i].Id_zadania.ToString())].Termin != "ZAKOŃCZONE" && Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(lista[i].Id_zadania.ToString())].Termin != null && Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(lista[i].Id_zadania.ToString())].Termin != string.Empty)
                    {
                        DateTime termin = Convert.ToDateTime(Convert.ToDateTime(Wszystkie_Zadania_Z_Bazy[Znajdz_index_na_liscie(lista[i].Id_zadania.ToString())].Termin).ToShortDateString());
                        if (termin >= data_od && termin <= data_do && lista[i].Status == true)
                        {
                            metroGrid1.Rows.Add(konwersja(lista[i]));
                        }
                    }
                }
            } */


            Display_first_task_details();
            kolor_terminu_w_dataGrid();

        }

        private void Wyszukiwanie()
        {
            metroGrid1.Rows.Clear();
            List<Tasks> Wyszukane = new List<Tasks>();

            if (ComboBoxKolumnaSzukania.SelectedIndex == 0)
            {
                for (int i = 0; i < Zadania.Count; i++)
                {
                    if (Zadania[i].Id_zadania.ToString().ToUpper().Contains(TextBoxSzukanaFraza.Text.ToUpper())) { Wyszukane.Add(Zadania[i]); }
                }
            }
            else if (ComboBoxKolumnaSzukania.SelectedIndex == 1)
            {
                for (int i = 0; i < Zadania.Count; i++)
                {
                    if (Zadania[i].Priorytet.ToString().ToUpper().Contains(TextBoxSzukanaFraza.Text.ToUpper())) { Wyszukane.Add(Zadania[i]); }
                }
            }
            else if (ComboBoxKolumnaSzukania.SelectedIndex == 2)
            {
                for (int i = 0; i < Zadania.Count; i++)
                {
                    if (Zadania[i].Zadanie.ToString().ToUpper().Contains(TextBoxSzukanaFraza.Text.ToUpper())) { Wyszukane.Add(Zadania[i]); }
                }
            }
            else if (ComboBoxKolumnaSzukania.SelectedIndex == 3)
            {
                for (int i = 0; i < Zadania.Count; i++)
                {
                    if (Zadania[i].Rodzaj.ToString().ToUpper().Contains(TextBoxSzukanaFraza.Text.ToUpper())) { Wyszukane.Add(Zadania[i]); }
                }
            }
            else if (ComboBoxKolumnaSzukania.SelectedIndex == 4)
            {
                for (int i = 0; i < Zadania.Count; i++)
                {
                    if (Zadania[i].Wykonawca.ToString().ToUpper().Contains(TextBoxSzukanaFraza.Text.ToUpper())) { Wyszukane.Add(Zadania[i]); }
                }
            }
            else if (ComboBoxKolumnaSzukania.SelectedIndex == 5)  //szukanie w opisie
            {
                for (int i = 0; i < Zadania.Count; i++)
                {
                    if (Zadania[i].Opis.ToString().ToUpper().Contains(TextBoxSzukanaFraza.Text.ToUpper()))
                    {

                        Wyszukane.Add(Zadania[i]);
                        metroTabTaskDetails.Show();
                        if(metroGrid1.RowCount > 0) Display_first_task_details();
                        //Load_Task_Details(Znajdz_index_na_liscie(Zadania[i].Id_zadania.ToString()));

                    }

                }
            }
            else if (ComboBoxKolumnaSzukania.SelectedIndex == 6)
            {
                for (int i = 0; i < Zadania.Count; i++)
                {
                    if (Zadania[i].Termin.ToString().ToUpper().Contains(TextBoxSzukanaFraza.Text.ToUpper())) { Wyszukane.Add(Zadania[i]); }
                }
            }
            else if (ComboBoxKolumnaSzukania.SelectedIndex == 7)
            {
                for (int i = 0; i < Zadania.Count; i++)
                {
                    if (Zadania[i].Status.ToString().ToUpper().Contains(TextBoxSzukanaFraza.Text.ToUpper())) {; Wyszukane.Add(Zadania[i]); }
                }
            }
            else if (ComboBoxKolumnaSzukania.SelectedIndex == 8)
            {
                for (int i = 0; i < Zadania.Count; i++)
                {
                    if (Zadania[i].Data_wykonania.ToString().ToUpper().Contains(TextBoxSzukanaFraza.Text.ToUpper())) { Wyszukane.Add(Zadania[i]); }
                }
            }
            else if (ComboBoxKolumnaSzukania.SelectedIndex == 9)
            {
                for (int i = 0; i < Zadania.Count; i++)
                {
                    if (Zadania[i].Dodane_przez.ToString().ToUpper().Contains(TextBoxSzukanaFraza.Text.ToUpper())) { Wyszukane.Add(Zadania[i]); }
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


        //funkcja wyszukująca numer wiersza, jeśli zawiera on dane ID
        public int NumerWiersza(int id)
        {
            int numer_wiersza = 0;
            for (int i = 0; i < metroGrid1.RowCount; i++)
            {
                if (Convert.ToInt32(metroGrid1[0, i].Value) == id)
                {
                    numer_wiersza += i;
                }
            }
            return numer_wiersza;
        }




        //FUNKCJE DO SZYFROWANIA PLIKU
        static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an Rijndael object
            // with the specified key and IV.
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        static string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Rijndael object
            // with the specified key and IV.
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }


        private void Zaladuj_ponownie()
        {
            //Jesli wpisno dane do łączenia z bazą:
            if (File.Exists("database.txt"))
            {
                connected = false;
                DataBase();  //próba połączenia z bazą


                //UDAŁO SIE POŁĄCZYĆ Z BAZĄ
                if (connected == true)
                {
                    //odczyt domyslnego miejsca zapisu pobranego backupu bazy i automayczny backup bazy
                    odczyt_miejsca_zapisu_backupu();
                    autosave();
                    //wielkosc czcionki w datagridview
                    this.metroGrid1.DefaultCellStyle.Font = new Font("Tahoma", 9.5F);
                    this.metroGrid1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);

                   //zakres dat według daty dodania
                    CheckBoxZakresDatDataDodania.Checked = true;

                    TextBoxDBinfo.Text = "Nawiązano połączenie z bazą.";

                    Wczytaj_Filtry();
                    kolor_terminu_w_dataGrid();
                    ComboBoxStatus.SelectedItem = "wszystkie";  //domyslnie filtr na wyświelanie zadań wykonanych i niewykonanych
                    ShowUsers(); //wczytanie listy userów
                    WypelnijMetroGridRodzaje(); //wypełnienie metroGridRodzaje dostępnymi rodzajami zadań
                    if (Wszystkie_Zadania_Z_Bazy.Count >= 1)
                    {
                        DateTimeZakresDatOd.Value = Wszystkie_Zadania_Z_Bazy[0].Data_dodania;   //domyslny zakres dat: od daty dodania pierwszego zadania
                        DateTimeZakresDatDo.Value = Wszystkie_Zadania_Z_Bazy[Wszystkie_Zadania_Z_Bazy.Count - 1].Data_dodania;  //domyślny zakres dat: do daty ostatniego zadania
                    }
                    else
                    {
                        DateTimeZakresDatOd.Text = "20-06-2020";
                        DateTimeZakresDatDo.Value = DateTime.Now.ToLocalTime();
                    }

                    //JEŚLI ISNIEJE PLIK LOGOWANIE.TXT
                    if (File.Exists("logowanie.txt"))
                    {
                        Logowanie();  //próba logowania

                        //JEŚLI ZALOGOWANO UZYTKOWNIKA
                        if (zalogowany == true)
                        {
                            
                            ComboBoxWykonawcy.SelectedItem = zalogowany_user;  //domyślny filtr na wyświetlanie zadań dla zalogowanego usera
                                                                               // Filtrowanie(ComboBoxWykonawcy.Text, ComboBoxStatus.Text);
                        }
                        //JEŚLI NIE ZALOGOWANO
                        else
                        {
                            ComboBoxWykonawcy.SelectedItem = "wszystkie";
                            MessageBox.Show("Nie jesteś zalogowany.");
                        }

                    }
                    //JEŚLI NIE ISTNIEJE PLIK LOGOWANIE.TXT
                    else
                    {
                        ComboBoxWykonawcy.SelectedItem = "wszystkie";
                        MessageBox.Show("Nie jesteś zalogowany.");
                    }
                    
                    Filtrowanie(ComboBoxWykonawcy.Text, ComboBoxStatus.Text);
                    Display_first_task_details();   //przy uruchamianiu wyswietlenie szczegółów pierwszego zadania w datagrid
                    Odczyt_Ustawien_Kolumn();
                    this.metroGrid1.Sort(this.metroGrid1.Columns[1], ListSortDirection.Descending); //domyślne sortowanie - malejąco według PRIORYTETU
                }

                //NIE UDAŁO SIE POŁĄCZYĆ Z BAZA
                else
                {
                    TextBoxDBinfo.Text = "Nie udało się nawiązać połączenia z bazą.";
                }
            }
            else
            {
                TextBoxDBinfo.Text = "Wprowadź dane do połączenia z bazą.";
            }
  

        }
        //funkcja do odświeżania - wyświetla wszystkie zadania
        private void refresh()
        {
            //pobranie wszystkich zadań z bazy
            DB_first_connection();
            //pobranie listy zadań według filtrów
            Filtrowanie(ComboBoxWykonawcy.Text, ComboBoxStatus.Text);
            //sortowanie (takie jakie było przed odświeżeniem)
            Sortowanie();
            //odświeżenie listy użytkowników
            ShowUsers();

        }


        //Uniwersalna funkcja do łączenia z bazą do komend: insert, update, delete
        public void BazaDanych(string komenda, string db_server, string port, string db_name, string db_user, string db_password)
        {
            try
            {
                DbConnection connection = new DbConnection(db_server, port, db_name, db_user, db_password);
                MySqlConnection con = connection.polaczenie();
                con.Open();
                MySqlCommand komendaSQL = con.CreateCommand();
                string zapytanie = komenda;
                komendaSQL.CommandText = zapytanie;
                MySqlDataReader r = komendaSQL.ExecuteReader();
                r.Close();
                con.Close();

            }
            catch (MySqlException ee)
            {
                //MessageBox.Show("Wystąpił błąd podczas łączenia z bazą. przycisk dodaj zadanie");
                MessageBox.Show(ee.ToString());
            }

        }



        /*------------------------------------------------ GENEROWANIE PDF ---------------------------------------------------*/

      
        public void generujPDF_ps(string htmlMain, DateTime dod, DateTime ddo, string path, bool czy_owtorzyc)
        {
           
           // byte[] pdfBuffer = new SimplePechkin(new GlobalConfig()).Convert(htmlMain); //Pechkin, wymagaana funkcja ByteArrayToFile(..)
            int x = 1;
            // Name and location of the PDF
            
            string filename = path + "\\"+ dod.ToShortDateString() + "-" + ddo.ToShortDateString() + "-raport" + ".pdf";
            if(File.Exists(filename))
            {
                filename = path + "\\" + dod.ToShortDateString() + "-" + ddo.ToShortDateString() + "-raport" + x + ".pdf";
                if(File.Exists(filename)) filename = path + "\\" + dod.ToShortDateString() + "-" + ddo.ToShortDateString() + "-raport" + x+1 + ".pdf";
                
            }
            //TheArtOfDev pdf sharp
            try
            {

                PdfSharp.Pdf.PdfDocument pdf = PdfGenerator.GeneratePdf(htmlMain, PageSize.A4, 0);
                pdf.Save(filename);
                
                //Open PDF
                if (czy_owtorzyc == true)
                {
                    try
                    {
                        System.Diagnostics.Process.Start(filename);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Nie mozna otworzyc pdf" + ex.Message);
                        //LogEvents loge = new LogEvents("Nie mozna otworzyc PDF: " + ex.Message + " (funkcja generatePDF2)");
                    }
                }
                else MessageBox.Show("Utworzono.");
            }catch(Exception e)
            {
                MessageBox.Show("Nie udało się utworzyć pdf");
            }

        }

        List<Tasks> Wykonane = new List<Tasks>();
        List<Tasks> Niewykonane = new List<Tasks>();

        public void podmien_html(DateTime dod, DateTime ddo, string uzytkownik, string path, bool czy_otworzyc)
        {

            string htmlMain = "";
      
            //parametry
            DateTime data_od = dod;
            DateTime data_do = ddo;
            string wykonawca = uzytkownik;


            //pobranie wybranych zadań do list:
            Wykonane.Clear();
            Niewykonane.Clear();

            string naglowki_kolumn_wykonane = "";
            string naglowki_kolumn_niewykonane = "";

          
          
            //zadania wszystkich uzytkownikow
            if (wykonawca == "wszyscy")
            {
                naglowki_kolumn_wykonane = "<tr> <th> ID </th><th> PRIORYTET </th><th> ZADANIE </th><th> RODZAJ </th><th> WYKONAWCA </th><th> DATA DODANIA </th> <th> TERMIN </th> <th> DATA WYKONANIA </th><th> DODANE PRZEZ </th></tr> ";
                naglowki_kolumn_niewykonane = "<tr> <th> ID </th><th> PRIORYTET </th><th> ZADANIE </th><th> RODZAJ </th><th> WYKONAWCA </th><th> DATA DODANIA </th> <th> TERMIN </th><th> DODANE PRZEZ </th></tr> ";

                for (int i = 0; i < Wszystkie_Zadania_Z_Bazy.Count; i++)
                {
                    DateTime data_dodania = Convert.ToDateTime(Wszystkie_Zadania_Z_Bazy[i].Data_dodania.ToShortDateString());
                    if ((data_dodania >= data_od && data_dodania <= data_do) && Wszystkie_Zadania_Z_Bazy[i].Status == true)
                    {
                        Wykonane.Add(Wszystkie_Zadania_Z_Bazy[i]);
                    }
                    else if ((data_dodania >= data_od && data_dodania <= data_do) && Wszystkie_Zadania_Z_Bazy[i].Status == false)
                    {
                        Niewykonane.Add(Wszystkie_Zadania_Z_Bazy[i]);
                    }
                }
            }
            //zadania jednego wybranego uzytkownika
            else
            {
                naglowki_kolumn_wykonane = "<tr> <th> ID </th><th> PRIORYTET </th><th> ZADANIE </th><th> RODZAJ </th><th> DATA DODANIA </th> <th> TERMIN </th> <th> DATA WYKONANIA </th><th> DODANE PRZEZ </th></tr> ";
                naglowki_kolumn_niewykonane = "<tr> <th> ID </th><th> PRIORYTET </th><th> ZADANIE </th><th> RODZAJ </th><th> DATA DODANIA </th> <th> TERMIN </th><th> DODANE PRZEZ </th></tr> ";

                for (int i = 0; i < Wszystkie_Zadania_Z_Bazy.Count; i++)
                {
                    DateTime data_dodania = Convert.ToDateTime(Wszystkie_Zadania_Z_Bazy[i].Data_dodania.ToShortDateString());
                    if ((data_dodania >= data_od && data_dodania <= data_do) && Wszystkie_Zadania_Z_Bazy[i].Status == true && Wszystkie_Zadania_Z_Bazy[i].Wykonawca == wykonawca)
                    {
                        Wykonane.Add(Wszystkie_Zadania_Z_Bazy[i]);
                    }
                    else if ((data_dodania >= data_od && data_dodania <= data_do) && Wszystkie_Zadania_Z_Bazy[i].Status == false && Wszystkie_Zadania_Z_Bazy[i].Wykonawca == wykonawca)
                    {
                        Niewykonane.Add(Wszystkie_Zadania_Z_Bazy[i]);
                    }

                }
            }

            //pobranie html:
            string htmlItem = "";

            try
            {
                 htmlItem = File.ReadAllText("raport-test.html");   //, Encoding.GetEncoding("Windows-1250")   <- przez to nie ma polskich znaków

            }
            catch (Exception ex)
            {
                MessageBox.Show("1Nie udało się podmienić danych."+ex.ToString());
                //LogEvents loge = new LogEvents("Nie udalo sie zaladowac pliku \"ItemCertCompany.html\" lub Solo: " + ex.Message + " (funkcja prepareHtmlcert w Form1)");
            }

            //stworzenie wierszy tabeli do html:
            


            string tabela_wykonane = "";
            string tabela_niewykonane = "";

                for (int i = 0; i < Wykonane.Count(); i++)
                {
                    string data_dodania = Wykonane[i].Data_dodania.ToString("dd.MM.yyyy HH':'mm ");
                    string termin = "".ToString();
                    string data_wykonania = "".ToString();
                    for (int j = 0; j <= 15; j++)
                    {
                        if (Wykonane[i].Termin != null && Wykonane[i].Termin != string.Empty) termin += Wykonane[i].Termin[j];
                        data_wykonania += Wykonane[i].Data_wykonania[j];
                    }

                    string wiersz = "";
                    if (wykonawca == "wszyscy") wiersz = "<tr> <td> " + Wykonane[i].Id_zadania + " </td><td> " + Wykonane[i].Priorytet + "</td><td> " + Wykonane[i].Zadanie + "</td><td> " + Wykonane[i].Rodzaj + "</td><td> " + Wykonane[i].Wykonawca + "</td><td> " + data_dodania + "</td><td> " + termin + "</td><td> " + data_wykonania + "</td><td> " + Wykonane[i].Dodane_przez + "</td>    </tr>";
                    else wiersz = "<tr> <td> " + Wykonane[i].Id_zadania + " </td><td> " + Wykonane[i].Priorytet + "</td><td> " + Wykonane[i].Zadanie + "</td><td> " + Wykonane[i].Rodzaj + "</td><td> " + data_dodania + "</td><td> " + termin + "</td><td> " + data_wykonania + "</td><td> " + Wykonane[i].Dodane_przez + "</td>    </tr>";
                    tabela_wykonane += wiersz;
                     
                }
            
            
                for (int i = 0; i < Niewykonane.Count(); i++)
                {
                    string data_dodania = Niewykonane[i].Data_dodania.ToString("dd.MM.yyyy HH':'mm ");
                    string termin = "".ToString();
                    for (int j = 0; j <= 15; j++)
                    {
                        if (Niewykonane[i].Termin != null && Niewykonane[i].Termin != string.Empty) termin += Niewykonane[i].Termin[j];
                    }

                    string wiersz = "";
                    if (wykonawca == "wszyscy") wiersz = "<tr> <td> " + Niewykonane[i].Id_zadania + " </td><td> " + Niewykonane[i].Priorytet + "</td><td> " + Niewykonane[i].Zadanie + "</td><td> " + Niewykonane[i].Rodzaj + "</td><td> " + Niewykonane[i].Wykonawca + "</td><td> " + data_dodania + "</td><td> " + termin + "</td><td> " + Niewykonane[i].Dodane_przez + "</td>    </tr>";
                    else wiersz = "<tr> <td> " + Niewykonane[i].Id_zadania + " </td><td> " + Niewykonane[i].Priorytet + "</td><td> " + Niewykonane[i].Zadanie + "</td><td> " + Niewykonane[i].Rodzaj + "</td><td> " + data_dodania + "</td><td> " + termin + "</td><td> " + Niewykonane[i].Dodane_przez + "</td>    </tr>";
                    tabela_niewykonane += wiersz;
                  
            }

           
            //podmiana
            try
            {             
                if (wykonawca == "wszyscy") htmlItem = htmlItem.Replace("{uzytkownik}", "Zadania wszystkich pracowników.");
                else htmlItem = htmlItem.Replace("{uzytkownik}", wykonawca);

                htmlItem = htmlItem.Replace("{data_od}", data_od.ToShortDateString());
                htmlItem = htmlItem.Replace("{data_do}", data_do.ToShortDateString());
                htmlItem = htmlItem.Replace("{ile_wykonanych}", Wykonane.Count.ToString());
                htmlItem = htmlItem.Replace("{ile_niewykonanych}", Niewykonane.Count.ToString());

                htmlItem = htmlItem.Replace("{naglowek_wykonane}", naglowki_kolumn_wykonane);
                htmlItem = htmlItem.Replace("{naglowek_niewykonane}", naglowki_kolumn_niewykonane);
                htmlItem = htmlItem.Replace("{tabela_wykonane}", tabela_wykonane);
                htmlItem = htmlItem.Replace("{tabela_niewykonane}", tabela_niewykonane);

                //Insert edited item to main html string and again create {htmlItem} tag
                //for next item.
                htmlMain += htmlItem;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Nie udalo sie podmienic zmiennych"+ex.ToString());
               //LogEvents loge = new LogEvents("Nie udalo sie podmienic zmiennych (imienazwisko,firma,adres,plec: " + ex.Message + " (funkcja prepareHtmlcert())");
            }

            generujPDF_ps(htmlMain, dod, ddo, path, czy_otworzyc);

        }
    

        
        private void ButtonGenerujPDF_Click(object sender, EventArgs e)
        {

            //otworzyc nowy form
           Form4 GenerujPDF = new Form4(this);
           GenerujPDF.ShowDialog();
           
           //podmien_html(Convert.ToDateTime("2020-05-10"),Convert.ToDateTime("2020-07-20"),zalogowany_user);
            

        }



        /****************************** WYGLĄD ************************************ */

       //wyświetlanie napisu "zakończone" lub "bezterminowe" w kolumnie termin
        public void TerminZadania(List<Tasks> lista, int i)  //używać tylko do listy Zadania, bo inaczej bedzie problem z kolorami terminow
        {
            if (lista[i].Termin == null || lista[i].Termin == string.Empty)
            {
                if (lista[i].Status == true) lista[i].Termin = "ZAKOŃCZONE";
                else lista[i].Termin = "BEZTERMINOWE";
            }
            else if ((lista[i].Termin != null && lista[i].Termin != string.Empty) && lista[i].Status == true)
            {
                lista[i].Termin = "ZAKOŃCZONE";
            }
            else if (Convert.ToInt32(ile_czasu_do_konca_zadania(Znajdz_index_na_liscie(lista[i].Id_zadania.ToString()), Wszystkie_Zadania_Z_Bazy)) < 0)
            {    //if(ile_czasu_do_konca_zadania(i, Wszystkie_Zadania_Z_Bazy) != string.Empty && Convert.ToInt32(ile_czasu_do_konca_zadania(i, Wszystkie_Zadania_Z_Bazy)) < 0)

                lista[i].Termin = Convert.ToDateTime(lista[i].Termin).ToShortDateString();
                lista[i].Termin += "  ZADANIE PO TERMINIE";    

            }

        }
        

        
        //co drugi wiersz data grid ma inny kolor
        private void metroGrid1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
             for(int i=0; i<metroGrid1.RowCount; i++)
            {
                if(i%2==1) metroGrid1.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                else metroGrid1.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }
        }








       // List<Today> dzisiejsze_zadania = new List<Today>();

        public void ZadaniaNaDzis()
        {
            TasksPanel.Controls.Clear();
            ProgressBarZadania_na_dzis.Value = 0;
            //dzisiejsze_zadania.Clear();

            //lokalizaja pierwszego panelu:
            int x = 3; 
            int y = 15;

            //ILOSC ZADAN NA DZIS:
            int ilosc_zadan_na_dzis = 0;
            int ilosc_wykonanych_zadan_na_dzis = 0;
            for (int i = 0; i < Wszystkie_Zadania_Z_Bazy.Count; i++)
            {
                if (Wszystkie_Zadania_Z_Bazy[i].Termin != null && Wszystkie_Zadania_Z_Bazy[i].Termin != string.Empty)
                {
                    DateTime termin = Convert.ToDateTime(Convert.ToDateTime(Wszystkie_Zadania_Z_Bazy[i].Termin).ToShortDateString());
                    DateTime dzis = Convert.ToDateTime(DateTime.UtcNow.ToLocalTime().ToShortDateString());
                    if (termin == dzis && Wszystkie_Zadania_Z_Bazy[i].Wykonawca == zalogowany_user)
                    {
                        ilosc_zadan_na_dzis++;
                        if (Wszystkie_Zadania_Z_Bazy[i].Status == true) ilosc_wykonanych_zadan_na_dzis++;
                    }
                }
            }

            double progress_jendego_zadania = 0;
            if (ilosc_zadan_na_dzis > 0)  progress_jendego_zadania = 100 / ilosc_zadan_na_dzis;
            ProgressBarZadania_na_dzis.Value += Convert.ToInt32(ilosc_wykonanych_zadan_na_dzis * progress_jendego_zadania);
            

            for (int i=0; i<Wszystkie_Zadania_Z_Bazy.Count; i++)
            {
                if (Wszystkie_Zadania_Z_Bazy[i].Termin != null && Wszystkie_Zadania_Z_Bazy[i].Termin != string.Empty)
                {
                    DateTime termin = Convert.ToDateTime(Convert.ToDateTime(Wszystkie_Zadania_Z_Bazy[i].Termin).ToShortDateString());

                    DateTime dzis = Convert.ToDateTime(DateTime.UtcNow.ToLocalTime().ToShortDateString());
                    if (termin == dzis && Wszystkie_Zadania_Z_Bazy[i].Wykonawca == zalogowany_user)
                    {

                        int xc = 16;  //lokalizacja checkboxa: X
                        int yc = 21;  //lokalizacja checkboxa: Y
                        int xl = 16;  //lokalizacja label: X
                        int yl = 58;  //lokalizacja label: Y

                        //panel
                        Panel g = new Panel();
                        g.BackColor = Color.White;
                        g.Text = "";
                        g.AutoSize = true;
                        g.Width = 561;
                        TasksPanel.Controls.Add(g);
                        g.Parent = TasksPanel;
                        g.Location = new Point(x, y);

                        //metrotile
                        MetroTile t = new MetroTile();
                        t.Style = MetroColorStyle.Silver;
                        t.Enabled = false;
                        t.Text = "";
                        t.Width = 11;
                        t.Height = g.Height;
                        t.Parent = g;
                        t.Location = new Point(0, 6);


                        //checkbox
                        MetroCheckBox c = new MetroCheckBox();
                        c.Style = MetroColorStyle.Orange;
                        g.Controls.Add(c);
                        c.Parent = g;
                        c.Location = new Point(xc, yc);     
                        if (Wszystkie_Zadania_Z_Bazy[i].Status == true) c.Checked = true;
                        else c.Checked = false;


                        //label
                        MetroLabel l = new MetroLabel();
                        l.Text = Wszystkie_Zadania_Z_Bazy[i].Zadanie;
                        g.Controls.Add(l);
                        l.Parent = g;
                        l.Location = new Point(xl, yl);
                        l.AutoSize = true;

                        //dzisiejsze_zadania.Add(new Today(g, t, c, l, Wszystkie_Zadania_Z_Bazy[i]));
                        
                        y += g.Height + 10;

                        //ZMIANA STANU ZADANIA
                        int index = i;
                        c.CheckedChanged += (sender, e) =>
                        {
                            try
                            {
                                DbConnection connection = new DbConnection(Dane[0], Dane[1], Dane[2], Dane[3], Dane[4]);
                                MySqlConnection con = connection.polaczenie();
                                con.Open();
                                MySqlCommand komendaSQL = con.CreateCommand();
                                DateTime thisDay = DateTime.UtcNow.ToLocalTime();
                                if (c.Checked == true)
                                {
                                    ProgressBarZadania_na_dzis.Value += Convert.ToInt32(progress_jendego_zadania);
                                    Zadania[Znajdz_index_na_liscie_ograniczonej(Wszystkie_Zadania_Z_Bazy[index].Id_zadania.ToString())].Status = true;
                                    Wszystkie_Zadania_Z_Bazy[index].Status = true;
                                    Zadania[Znajdz_index_na_liscie_ograniczonej(Wszystkie_Zadania_Z_Bazy[index].Id_zadania.ToString())].Data_wykonania = thisDay.ToString();
                                    Wszystkie_Zadania_Z_Bazy[index].Data_wykonania = thisDay.ToString();
                                    komendaSQL.CommandText = "UPDATE `zadania` SET `status` = '1', `data_wykonania` = '" + thisDay.ToString() + "' WHERE `zadania`.`id_zadania` = " + Wszystkie_Zadania_Z_Bazy[index].Id_zadania + "; ";
                                    //TerminZadania(Zadania, index);  v
                                    Zadania[Znajdz_index_na_liscie_ograniczonej(Wszystkie_Zadania_Z_Bazy[index].Id_zadania.ToString())].Termin = "ZAKOŃCZONE";

                                }
                                else 
                                {
                                    ProgressBarZadania_na_dzis.Value -= Convert.ToInt32(progress_jendego_zadania);
                                    Zadania[Znajdz_index_na_liscie_ograniczonej(Wszystkie_Zadania_Z_Bazy[index].Id_zadania.ToString())].Status = false;
                                    Wszystkie_Zadania_Z_Bazy[index].Status = false;
                                    Zadania[Znajdz_index_na_liscie_ograniczonej(Wszystkie_Zadania_Z_Bazy[index].Id_zadania.ToString())].Data_wykonania = null;
                                    Wszystkie_Zadania_Z_Bazy[index].Data_wykonania = null;
                                    komendaSQL.CommandText = "UPDATE `zadania` SET `status` = '0', `data_wykonania` = NULL  WHERE `zadania`.`id_zadania` = " + Wszystkie_Zadania_Z_Bazy[index].Id_zadania + "; ";
                                    //TerminZadania(Zadania, index);  v        
                                    if (Wszystkie_Zadania_Z_Bazy[index].Termin == null || Wszystkie_Zadania_Z_Bazy[index].Termin == string.Empty) Zadania[Znajdz_index_na_liscie_ograniczonej(Wszystkie_Zadania_Z_Bazy[index].Id_zadania.ToString())].Termin = "BEZTERMINOWE";
                                    else if (Wszystkie_Zadania_Z_Bazy[index].Termin != null && Wszystkie_Zadania_Z_Bazy[index].Termin != string.Empty) Zadania[Znajdz_index_na_liscie_ograniczonej(Wszystkie_Zadania_Z_Bazy[index].Id_zadania.ToString())].Termin = Wszystkie_Zadania_Z_Bazy[index].Termin;

                                }

                                MySqlDataReader r = komendaSQL.ExecuteReader();
                                r.Close();
                                con.Close();
                                int pozycja_scrollbaru = metroGrid1.FirstDisplayedScrollingRowIndex;
                                metroGrid1.Rows.Clear();
                                zmiana_zakresu_dat(Zadania);
                                Display_specific_task_details(Wszystkie_Zadania_Z_Bazy[index].Id_zadania);
                                metroGrid1.FirstDisplayedScrollingRowIndex = pozycja_scrollbaru;
                            }
                            catch (MySqlException ee)
                            {
                                MessageBox.Show("Wystąpił błąd podczas łączenia z bazą.");

                            }
                        };
                        
                    }
                }
            }
           
            

           


        }

        























































































        /*_______________________________________________________________________________________________________________________________________________*/



    }
}
