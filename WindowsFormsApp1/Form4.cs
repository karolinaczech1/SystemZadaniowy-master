using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            //domyślny zakres dat

            if (form1.zalogowany == true) ComboBoxWykonawcy.SelectedItem = form1.zalogowany_user;

        }

        
       
        private void btnGenerujPDF_Click(object sender, EventArgs e)
        {
          
            DateTime dod = Convert.ToDateTime(DateTimeOD.Value.ToShortDateString());
            DateTime ddo = Convert.ToDateTime(DateTimeDO.Value.ToShortDateString());
            MessageBox.Show(ComboBoxWykonawcy.SelectedItem + "   " + dod + "  -  "+ ddo);
            //form1.podmien_html(dod, ddo, ComboBoxWykonawcy.SelectedText);
            form1.podmien_html(dod, ddo, ComboBoxWykonawcy.SelectedItem.ToString());

        }
    }
}
