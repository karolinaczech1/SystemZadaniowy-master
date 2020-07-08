using ImageMagick;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form4 : MetroFramework.Forms.MetroForm
    {
        private Form1 form1;
        public Form4(Form1 glowna)
        {
            InitializeComponent();
            form1 = glowna;

            //wczytanie wykonawców do comboboxa
            form1.Wczytaj_wykonawcow(ComboBoxWykonawcy);
            ComboBoxWykonawcy.Items.Add("wszyscy");

            if (form1.zalogowany == true) ComboBoxWykonawcy.SelectedItem = form1.zalogowany_user;

            //domyślna lokalizacja
            if(OdczytLokalizacji() == true)
            {
                CheckBoxZapiszLokalizacje.Checked = true;
                CheckBoxZapiszLokalizacje.Text = "zapisano";
                ButtonLokalizacja.Text = path;
            }
            else
            {
                CheckBoxZapiszLokalizacje.Checked = false;
                CheckBoxZapiszLokalizacje.Text = "zapisz jako miejsce docelowe";
                ButtonLokalizacja.Text = "miejsce zapisu pliku";
            }

        }

        string path;  //zmienna przechowująca miejsce zapisu pliku
        private void ButtonLokalizacja_Click_1(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                path = fbd.SelectedPath;
                ButtonLokalizacja.Text = path;

            }
            else MessageBox.Show("Nie wybrano miejsca zapisu pliku.");
        }

        //funkcja do sprawdzenia, czy należy otworzyć pdf po utworzeniu
        private bool Czy_otworzyc_pdf()
        {
            if (CheckBoxOtworzPDF.Checked == true) return true;
            else return false;
        }

        string file_name = "lokalizacjaPDF.txt";  //zmienna do przechowywania nazwy pliku zawierajacego lokalizacje pdf
        private bool OdczytLokalizacji()
        {
            if (File.Exists(file_name))
            {
                FileStream odczyt = new FileStream(file_name, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(odczyt);
                path = reader.ReadLine();
                reader.Close();
                odczyt.Close();
                if (path != string.Empty && path != null)
                {
                    return true;
                }
                else return false;
            }
            else
            {
                return false;
            }
        }

        //CheckBox do ZAPISU LOKALIZAJI JAKO DOCELOWEJ
        private void CheckBoxZapiszLokalizacje_CheckedChanged(object sender, EventArgs e)
        {
            if(path != string.Empty && path != null)
            {
                if (CheckBoxZapiszLokalizacje.Checked == true)
                {
                    if (File.Exists(file_name))
                    {
                        File.WriteAllText(file_name, String.Empty);
                        FileStream sciezka = new FileStream(file_name, FileMode.Append, FileAccess.Write);
                        StreamWriter writer = new StreamWriter(sciezka);
                        writer.WriteLine(path);
                        writer.Close();
                        sciezka.Close();
                    }
                    else
                    {
                        FileStream sciezka = new FileStream(file_name, FileMode.CreateNew);
                        StreamWriter writer = new StreamWriter(sciezka);
                        writer.WriteLine(path);
                        writer.Close();
                        sciezka.Close();
                    }
                    CheckBoxZapiszLokalizacje.Text = "zapisano.";
                }
                else
                {
                    if (File.Exists(file_name))
                    {
                        File.WriteAllText(file_name, String.Empty);
                    }
                    CheckBoxZapiszLokalizacje.Text = "zapisz jako miejsce docelowe";
                }
            }
            else
            {
                CheckBoxZapiszLokalizacje.Checked = false;
                CheckBoxZapiszLokalizacje.Text = "nie wybrano miejsca zapisu pliku.";
            }
        }


        private void btnGenerujPDF_Click(object sender, EventArgs e)
        {

            DateTime dod = Convert.ToDateTime(DateTimeOD.Value.ToShortDateString());
            DateTime ddo = Convert.ToDateTime(DateTimeDO.Value.ToShortDateString());
            if (path != string.Empty && path != null)
            {
                form1.podmien_html(dod, ddo, ComboBoxWykonawcy.SelectedItem.ToString(), path, Czy_otworzyc_pdf());
                this.Close();
            }
            else MessageBox.Show("Wybierz miejsce zapisu pliku.");

        }

        
    }
}
