namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroTabControl2 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.DateTimeZakresDatDo = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel26 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel25 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel24 = new MetroFramework.Controls.MetroLabel();
            this.DateTimeZakresDatOd = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel23 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel22 = new MetroFramework.Controls.MetroLabel();
            this.ComboBoxKolumnaSzukania = new MetroFramework.Controls.MetroComboBox();
            this.CheckBoxMalejaco = new MetroFramework.Controls.MetroCheckBox();
            this.CheckBoxRosnaco = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.ComboBoxSortowanie = new MetroFramework.Controls.MetroComboBox();
            this.metroTabTaskDetails = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage7 = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel29 = new MetroFramework.Controls.MetroLabel();
            this.textBoxIle_dni_do_konca_zadania = new System.Windows.Forms.TextBox();
            this.TextBoxDetailsTerm = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel21 = new MetroFramework.Controls.MetroLabel();
            this.ComboBoxDetailsZmienPriorytet = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel20 = new MetroFramework.Controls.MetroLabel();
            this.TextBoxDetailsID = new MetroFramework.Controls.MetroTextBox();
            this.TextBoxDetailsPriorytet = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel19 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel18 = new MetroFramework.Controls.MetroLabel();
            this.TextBoxDetailsRodzaj = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel17 = new MetroFramework.Controls.MetroLabel();
            this.TextBoxDetailsStatus = new MetroFramework.Controls.MetroTextBox();
            this.TextBoxDetailsDodanePrzez = new MetroFramework.Controls.MetroTextBox();
            this.TextBoxDetailsDataZak = new MetroFramework.Controls.MetroTextBox();
            this.TextBoxDetailsDataDod = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel14 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel15 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel16 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.TextBoxDetailsWykonawca = new MetroFramework.Controls.MetroTextBox();
            this.ButtonUsunZadanie = new MetroFramework.Controls.MetroButton();
            this.ButtonEditTask = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.ComboBoxDetailsWykonawcy = new MetroFramework.Controls.MetroComboBox();
            this.TextBoxDetailsZadanie = new MetroFramework.Controls.MetroTextBox();
            this.TextBoxDetailsOpis = new MetroFramework.Controls.MetroTextBox();
            this.TextBoxSzukanaFraza = new MetroFramework.Controls.MetroTextBox();
            this.ButtonNewTask = new MetroFramework.Controls.MetroButton();
            this.ComboBoxStatus = new MetroFramework.Controls.MetroComboBox();
            this.ComboBoxWykonawcy = new MetroFramework.Controls.MetroComboBox();
            this.metroGrid1 = new MetroFramework.Controls.MetroGrid();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priorytet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Zad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rodzaj_zad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dla_kogo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dodanie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.termin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.zakonczenie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dodal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metroTabPage4 = new MetroFramework.Controls.MetroTabPage();
            this.metroTabControl3 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage5 = new MetroFramework.Controls.MetroTabPage();
            this.TextBoxUsersList = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.TextBoxAddUser = new MetroFramework.Controls.MetroTextBox();
            this.ButtonDodajUzytkownika = new MetroFramework.Controls.MetroButton();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.ButtonLogowanie = new MetroFramework.Controls.MetroButton();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.TextBoxUserName = new MetroFramework.Controls.MetroTextBox();
            this.metroTabPage6 = new MetroFramework.Controls.MetroTabPage();
            this.TextBoxDBTesting = new MetroFramework.Controls.MetroTextBox();
            this.TextBoxDBinfo = new MetroFramework.Controls.MetroTextBox();
            this.TextBoxDBPassword = new MetroFramework.Controls.MetroTextBox();
            this.TextBoxDBUser = new MetroFramework.Controls.MetroTextBox();
            this.TextBoxDBName = new MetroFramework.Controls.MetroTextBox();
            this.TextBoxServerID = new MetroFramework.Controls.MetroTextBox();
            this.ButtonSaveDB = new MetroFramework.Controls.MetroButton();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroTabPage8 = new MetroFramework.Controls.MetroTabPage();
            this.TxtBoxGreen = new MetroFramework.Controls.MetroTextBox();
            this.TxtBoxYellow = new MetroFramework.Controls.MetroTextBox();
            this.TxtBoxOrange = new MetroFramework.Controls.MetroTextBox();
            this.TxtBoxRed = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel30 = new MetroFramework.Controls.MetroLabel();
            this.TextBoxSzary = new MetroFramework.Controls.MetroTextBox();
            this.TextBoxJasnyZielony = new MetroFramework.Controls.MetroTextBox();
            this.TextBoxCzarny = new MetroFramework.Controls.MetroTextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.metroLabel28 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel27 = new MetroFramework.Controls.MetroLabel();
            this.metroTabPage9 = new MetroFramework.Controls.MetroTabPage();
            this.ButtonZapiszWidokKolumn = new MetroFramework.Controls.MetroButton();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.metroCheckBox10 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox9 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox8 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox7 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox6 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox5 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox4 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox3 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox2 = new MetroFramework.Controls.MetroCheckBox();
            this.metroCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.metroContextMenu1 = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.metroTabControl2.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            this.metroTabTaskDetails.SuspendLayout();
            this.metroTabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
            this.metroTabPage4.SuspendLayout();
            this.metroTabControl3.SuspendLayout();
            this.metroTabPage5.SuspendLayout();
            this.metroTabPage6.SuspendLayout();
            this.metroTabPage8.SuspendLayout();
            this.metroTabPage9.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl2
            // 
            this.metroTabControl2.Controls.Add(this.metroTabPage3);
            this.metroTabControl2.Controls.Add(this.metroTabPage4);
            this.metroTabControl2.Location = new System.Drawing.Point(9, 17);
            this.metroTabControl2.Name = "metroTabControl2";
            this.metroTabControl2.SelectedIndex = 0;
            this.metroTabControl2.Size = new System.Drawing.Size(1484, 789);
            this.metroTabControl2.TabIndex = 0;
            this.metroTabControl2.UseSelectable = true;
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.DateTimeZakresDatDo);
            this.metroTabPage3.Controls.Add(this.metroLabel26);
            this.metroTabPage3.Controls.Add(this.metroLabel25);
            this.metroTabPage3.Controls.Add(this.metroLabel24);
            this.metroTabPage3.Controls.Add(this.DateTimeZakresDatOd);
            this.metroTabPage3.Controls.Add(this.metroLabel23);
            this.metroTabPage3.Controls.Add(this.metroLabel22);
            this.metroTabPage3.Controls.Add(this.ComboBoxKolumnaSzukania);
            this.metroTabPage3.Controls.Add(this.CheckBoxMalejaco);
            this.metroTabPage3.Controls.Add(this.CheckBoxRosnaco);
            this.metroTabPage3.Controls.Add(this.metroLabel3);
            this.metroTabPage3.Controls.Add(this.metroLabel2);
            this.metroTabPage3.Controls.Add(this.ComboBoxSortowanie);
            this.metroTabPage3.Controls.Add(this.metroTabTaskDetails);
            this.metroTabPage3.Controls.Add(this.TextBoxSzukanaFraza);
            this.metroTabPage3.Controls.Add(this.ButtonNewTask);
            this.metroTabPage3.Controls.Add(this.ComboBoxStatus);
            this.metroTabPage3.Controls.Add(this.ComboBoxWykonawcy);
            this.metroTabPage3.Controls.Add(this.metroGrid1);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 10;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(1476, 747);
            this.metroTabPage3.TabIndex = 0;
            this.metroTabPage3.Text = "Zadania";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 10;
            // 
            // DateTimeZakresDatDo
            // 
            this.DateTimeZakresDatDo.Location = new System.Drawing.Point(732, 698);
            this.DateTimeZakresDatDo.MinimumSize = new System.Drawing.Size(0, 30);
            this.DateTimeZakresDatDo.Name = "DateTimeZakresDatDo";
            this.DateTimeZakresDatDo.Size = new System.Drawing.Size(200, 30);
            this.DateTimeZakresDatDo.TabIndex = 22;
            this.DateTimeZakresDatDo.ValueChanged += new System.EventHandler(this.DateTimeZakresDatDo_ValueChanged);
            // 
            // metroLabel26
            // 
            this.metroLabel26.AutoSize = true;
            this.metroLabel26.Location = new System.Drawing.Point(663, 670);
            this.metroLabel26.Name = "metroLabel26";
            this.metroLabel26.Size = new System.Drawing.Size(77, 20);
            this.metroLabel26.TabIndex = 21;
            this.metroLabel26.Text = "Zakres dat:";
            // 
            // metroLabel25
            // 
            this.metroLabel25.AutoSize = true;
            this.metroLabel25.Location = new System.Drawing.Point(701, 705);
            this.metroLabel25.Name = "metroLabel25";
            this.metroLabel25.Size = new System.Drawing.Size(25, 20);
            this.metroLabel25.TabIndex = 20;
            this.metroLabel25.Text = "do";
            // 
            // metroLabel24
            // 
            this.metroLabel24.AutoSize = true;
            this.metroLabel24.Location = new System.Drawing.Point(464, 705);
            this.metroLabel24.Name = "metroLabel24";
            this.metroLabel24.Size = new System.Drawing.Size(25, 20);
            this.metroLabel24.TabIndex = 19;
            this.metroLabel24.Text = "od";
            // 
            // DateTimeZakresDatOd
            // 
            this.DateTimeZakresDatOd.Location = new System.Drawing.Point(495, 698);
            this.DateTimeZakresDatOd.MinimumSize = new System.Drawing.Size(0, 30);
            this.DateTimeZakresDatOd.Name = "DateTimeZakresDatOd";
            this.DateTimeZakresDatOd.Size = new System.Drawing.Size(200, 30);
            this.DateTimeZakresDatOd.TabIndex = 18;
            this.DateTimeZakresDatOd.ValueChanged += new System.EventHandler(this.DateTimeZakresDatOd_ValueChanged);
            // 
            // metroLabel23
            // 
            this.metroLabel23.AutoSize = true;
            this.metroLabel23.Location = new System.Drawing.Point(381, 0);
            this.metroLabel23.Name = "metroLabel23";
            this.metroLabel23.Size = new System.Drawing.Size(97, 20);
            this.metroLabel23.TabIndex = 17;
            this.metroLabel23.Text = "Szukana fraza:";
            // 
            // metroLabel22
            // 
            this.metroLabel22.AutoSize = true;
            this.metroLabel22.Location = new System.Drawing.Point(594, 23);
            this.metroLabel22.Name = "metroLabel22";
            this.metroLabel22.Size = new System.Drawing.Size(19, 20);
            this.metroLabel22.TabIndex = 16;
            this.metroLabel22.Text = "w";
            // 
            // ComboBoxKolumnaSzukania
            // 
            this.ComboBoxKolumnaSzukania.FormattingEnabled = true;
            this.ComboBoxKolumnaSzukania.ItemHeight = 24;
            this.ComboBoxKolumnaSzukania.Items.AddRange(new object[] {
            "ID",
            "Priorytet",
            "Zadanie",
            "Rodzaj zadania",
            "Wykonawca",
            "Opis",
            "Termin",
            "Status",
            "Data zakończenia",
            "Dodane przez"});
            this.ComboBoxKolumnaSzukania.Location = new System.Drawing.Point(619, 17);
            this.ComboBoxKolumnaSzukania.Name = "ComboBoxKolumnaSzukania";
            this.ComboBoxKolumnaSzukania.Size = new System.Drawing.Size(121, 30);
            this.ComboBoxKolumnaSzukania.TabIndex = 15;
            this.ComboBoxKolumnaSzukania.UseSelectable = true;
            // 
            // CheckBoxMalejaco
            // 
            this.CheckBoxMalejaco.AutoSize = true;
            this.CheckBoxMalejaco.Checked = true;
            this.CheckBoxMalejaco.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxMalejaco.Location = new System.Drawing.Point(264, 685);
            this.CheckBoxMalejaco.Name = "CheckBoxMalejaco";
            this.CheckBoxMalejaco.Size = new System.Drawing.Size(76, 17);
            this.CheckBoxMalejaco.TabIndex = 14;
            this.CheckBoxMalejaco.Text = "malejąco";
            this.CheckBoxMalejaco.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBoxMalejaco.UseSelectable = true;
            this.CheckBoxMalejaco.CheckedChanged += new System.EventHandler(this.CheckBoxMalejaco_CheckedChanged);
            // 
            // CheckBoxRosnaco
            // 
            this.CheckBoxRosnaco.AutoSize = true;
            this.CheckBoxRosnaco.Location = new System.Drawing.Point(264, 708);
            this.CheckBoxRosnaco.Name = "CheckBoxRosnaco";
            this.CheckBoxRosnaco.Size = new System.Drawing.Size(71, 17);
            this.CheckBoxRosnaco.TabIndex = 13;
            this.CheckBoxRosnaco.Text = "rosnąco";
            this.CheckBoxRosnaco.UseSelectable = true;
            this.CheckBoxRosnaco.CheckedChanged += new System.EventHandler(this.CheckBoxRosnaco_CheckedChanged);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(10, 695);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(98, 20);
            this.metroLabel3.TabIndex = 11;
            this.metroLabel3.Text = "Sortuj według:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(337, 6);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(0, 0);
            this.metroLabel2.TabIndex = 9;
            // 
            // ComboBoxSortowanie
            // 
            this.ComboBoxSortowanie.FormattingEnabled = true;
            this.ComboBoxSortowanie.ItemHeight = 24;
            this.ComboBoxSortowanie.Items.AddRange(new object[] {
            "ID",
            "Priorytet",
            "Zadanie",
            "Rodzaj zadania",
            "Wykonawca",
            "Data dodania",
            "Termin",
            "Status",
            "Data zakończenia",
            "Dodane przez"});
            this.ComboBoxSortowanie.Location = new System.Drawing.Point(114, 695);
            this.ComboBoxSortowanie.Name = "ComboBoxSortowanie";
            this.ComboBoxSortowanie.Size = new System.Drawing.Size(121, 30);
            this.ComboBoxSortowanie.TabIndex = 10;
            this.ComboBoxSortowanie.UseSelectable = true;
            this.ComboBoxSortowanie.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSortowanie_SelectedIndexChanged);
            // 
            // metroTabTaskDetails
            // 
            this.metroTabTaskDetails.Controls.Add(this.metroTabPage7);
            this.metroTabTaskDetails.Location = new System.Drawing.Point(1035, 8);
            this.metroTabTaskDetails.Name = "metroTabTaskDetails";
            this.metroTabTaskDetails.SelectedIndex = 0;
            this.metroTabTaskDetails.Size = new System.Drawing.Size(438, 710);
            this.metroTabTaskDetails.TabIndex = 8;
            this.metroTabTaskDetails.UseCustomBackColor = true;
            this.metroTabTaskDetails.UseCustomForeColor = true;
            this.metroTabTaskDetails.UseSelectable = true;
            // 
            // metroTabPage7
            // 
            this.metroTabPage7.Controls.Add(this.metroLabel29);
            this.metroTabPage7.Controls.Add(this.textBoxIle_dni_do_konca_zadania);
            this.metroTabPage7.Controls.Add(this.TextBoxDetailsTerm);
            this.metroTabPage7.Controls.Add(this.metroLabel21);
            this.metroTabPage7.Controls.Add(this.ComboBoxDetailsZmienPriorytet);
            this.metroTabPage7.Controls.Add(this.metroLabel20);
            this.metroTabPage7.Controls.Add(this.TextBoxDetailsID);
            this.metroTabPage7.Controls.Add(this.TextBoxDetailsPriorytet);
            this.metroTabPage7.Controls.Add(this.metroLabel19);
            this.metroTabPage7.Controls.Add(this.metroLabel18);
            this.metroTabPage7.Controls.Add(this.TextBoxDetailsRodzaj);
            this.metroTabPage7.Controls.Add(this.metroLabel17);
            this.metroTabPage7.Controls.Add(this.TextBoxDetailsStatus);
            this.metroTabPage7.Controls.Add(this.TextBoxDetailsDodanePrzez);
            this.metroTabPage7.Controls.Add(this.TextBoxDetailsDataZak);
            this.metroTabPage7.Controls.Add(this.TextBoxDetailsDataDod);
            this.metroTabPage7.Controls.Add(this.metroLabel14);
            this.metroTabPage7.Controls.Add(this.metroLabel15);
            this.metroTabPage7.Controls.Add(this.metroLabel16);
            this.metroTabPage7.Controls.Add(this.metroLabel13);
            this.metroTabPage7.Controls.Add(this.metroLabel12);
            this.metroTabPage7.Controls.Add(this.TextBoxDetailsWykonawca);
            this.metroTabPage7.Controls.Add(this.ButtonUsunZadanie);
            this.metroTabPage7.Controls.Add(this.ButtonEditTask);
            this.metroTabPage7.Controls.Add(this.metroLabel1);
            this.metroTabPage7.Controls.Add(this.ComboBoxDetailsWykonawcy);
            this.metroTabPage7.Controls.Add(this.TextBoxDetailsZadanie);
            this.metroTabPage7.Controls.Add(this.TextBoxDetailsOpis);
            this.metroTabPage7.HorizontalScrollbarBarColor = true;
            this.metroTabPage7.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage7.HorizontalScrollbarSize = 10;
            this.metroTabPage7.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage7.Name = "metroTabPage7";
            this.metroTabPage7.Size = new System.Drawing.Size(430, 668);
            this.metroTabPage7.TabIndex = 0;
            this.metroTabPage7.Text = "Szczegóły zadania";
            this.metroTabPage7.VerticalScrollbarBarColor = true;
            this.metroTabPage7.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage7.VerticalScrollbarSize = 10;
            // 
            // metroLabel29
            // 
            this.metroLabel29.AutoSize = true;
            this.metroLabel29.Location = new System.Drawing.Point(13, 92);
            this.metroLabel29.Name = "metroLabel29";
            this.metroLabel29.Size = new System.Drawing.Size(62, 20);
            this.metroLabel29.TabIndex = 31;
            this.metroLabel29.Text = "Zadanie:";
            // 
            // textBoxIle_dni_do_konca_zadania
            // 
            this.textBoxIle_dni_do_konca_zadania.Location = new System.Drawing.Point(3, 3);
            this.textBoxIle_dni_do_konca_zadania.Name = "textBoxIle_dni_do_konca_zadania";
            this.textBoxIle_dni_do_konca_zadania.ReadOnly = true;
            this.textBoxIle_dni_do_konca_zadania.Size = new System.Drawing.Size(423, 22);
            this.textBoxIle_dni_do_konca_zadania.TabIndex = 30;
            this.textBoxIle_dni_do_konca_zadania.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextBoxDetailsTerm
            // 
            // 
            // 
            // 
            this.TextBoxDetailsTerm.CustomButton.Image = null;
            this.TextBoxDetailsTerm.CustomButton.Location = new System.Drawing.Point(112, 2);
            this.TextBoxDetailsTerm.CustomButton.Name = "";
            this.TextBoxDetailsTerm.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.TextBoxDetailsTerm.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxDetailsTerm.CustomButton.TabIndex = 1;
            this.TextBoxDetailsTerm.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxDetailsTerm.CustomButton.UseSelectable = true;
            this.TextBoxDetailsTerm.CustomButton.Visible = false;
            this.TextBoxDetailsTerm.Lines = new string[0];
            this.TextBoxDetailsTerm.Location = new System.Drawing.Point(73, 68);
            this.TextBoxDetailsTerm.MaxLength = 32767;
            this.TextBoxDetailsTerm.Name = "TextBoxDetailsTerm";
            this.TextBoxDetailsTerm.PasswordChar = '\0';
            this.TextBoxDetailsTerm.ReadOnly = true;
            this.TextBoxDetailsTerm.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxDetailsTerm.SelectedText = "";
            this.TextBoxDetailsTerm.SelectionLength = 0;
            this.TextBoxDetailsTerm.SelectionStart = 0;
            this.TextBoxDetailsTerm.ShortcutsEnabled = true;
            this.TextBoxDetailsTerm.Size = new System.Drawing.Size(134, 24);
            this.TextBoxDetailsTerm.TabIndex = 27;
            this.TextBoxDetailsTerm.UseSelectable = true;
            this.TextBoxDetailsTerm.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxDetailsTerm.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel21
            // 
            this.metroLabel21.AutoSize = true;
            this.metroLabel21.Location = new System.Drawing.Point(13, 68);
            this.metroLabel21.Name = "metroLabel21";
            this.metroLabel21.Size = new System.Drawing.Size(54, 20);
            this.metroLabel21.TabIndex = 26;
            this.metroLabel21.Text = "Termin:";
            // 
            // ComboBoxDetailsZmienPriorytet
            // 
            this.ComboBoxDetailsZmienPriorytet.FormattingEnabled = true;
            this.ComboBoxDetailsZmienPriorytet.ItemHeight = 24;
            this.ComboBoxDetailsZmienPriorytet.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.ComboBoxDetailsZmienPriorytet.Location = new System.Drawing.Point(292, 626);
            this.ComboBoxDetailsZmienPriorytet.Name = "ComboBoxDetailsZmienPriorytet";
            this.ComboBoxDetailsZmienPriorytet.Size = new System.Drawing.Size(121, 30);
            this.ComboBoxDetailsZmienPriorytet.TabIndex = 25;
            this.ComboBoxDetailsZmienPriorytet.UseSelectable = true;
            this.ComboBoxDetailsZmienPriorytet.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDetailsZmienPriorytet_SelectedIndexChanged);
            // 
            // metroLabel20
            // 
            this.metroLabel20.AutoSize = true;
            this.metroLabel20.Location = new System.Drawing.Point(292, 593);
            this.metroLabel20.Name = "metroLabel20";
            this.metroLabel20.Size = new System.Drawing.Size(104, 20);
            this.metroLabel20.TabIndex = 24;
            this.metroLabel20.Text = "zmień priorytet";
            // 
            // TextBoxDetailsID
            // 
            // 
            // 
            // 
            this.TextBoxDetailsID.CustomButton.Image = null;
            this.TextBoxDetailsID.CustomButton.Location = new System.Drawing.Point(112, 2);
            this.TextBoxDetailsID.CustomButton.Name = "";
            this.TextBoxDetailsID.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.TextBoxDetailsID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxDetailsID.CustomButton.TabIndex = 1;
            this.TextBoxDetailsID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxDetailsID.CustomButton.UseSelectable = true;
            this.TextBoxDetailsID.CustomButton.Visible = false;
            this.TextBoxDetailsID.Lines = new string[0];
            this.TextBoxDetailsID.Location = new System.Drawing.Point(279, 31);
            this.TextBoxDetailsID.MaxLength = 32767;
            this.TextBoxDetailsID.Name = "TextBoxDetailsID";
            this.TextBoxDetailsID.PasswordChar = '\0';
            this.TextBoxDetailsID.ReadOnly = true;
            this.TextBoxDetailsID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxDetailsID.SelectedText = "";
            this.TextBoxDetailsID.SelectionLength = 0;
            this.TextBoxDetailsID.SelectionStart = 0;
            this.TextBoxDetailsID.ShortcutsEnabled = true;
            this.TextBoxDetailsID.Size = new System.Drawing.Size(134, 24);
            this.TextBoxDetailsID.TabIndex = 23;
            this.TextBoxDetailsID.UseSelectable = true;
            this.TextBoxDetailsID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxDetailsID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TextBoxDetailsPriorytet
            // 
            // 
            // 
            // 
            this.TextBoxDetailsPriorytet.CustomButton.Image = null;
            this.TextBoxDetailsPriorytet.CustomButton.Location = new System.Drawing.Point(112, 2);
            this.TextBoxDetailsPriorytet.CustomButton.Name = "";
            this.TextBoxDetailsPriorytet.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.TextBoxDetailsPriorytet.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxDetailsPriorytet.CustomButton.TabIndex = 1;
            this.TextBoxDetailsPriorytet.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxDetailsPriorytet.CustomButton.UseSelectable = true;
            this.TextBoxDetailsPriorytet.CustomButton.Visible = false;
            this.TextBoxDetailsPriorytet.Lines = new string[0];
            this.TextBoxDetailsPriorytet.Location = new System.Drawing.Point(73, 31);
            this.TextBoxDetailsPriorytet.MaxLength = 32767;
            this.TextBoxDetailsPriorytet.Name = "TextBoxDetailsPriorytet";
            this.TextBoxDetailsPriorytet.PasswordChar = '\0';
            this.TextBoxDetailsPriorytet.ReadOnly = true;
            this.TextBoxDetailsPriorytet.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxDetailsPriorytet.SelectedText = "";
            this.TextBoxDetailsPriorytet.SelectionLength = 0;
            this.TextBoxDetailsPriorytet.SelectionStart = 0;
            this.TextBoxDetailsPriorytet.ShortcutsEnabled = true;
            this.TextBoxDetailsPriorytet.Size = new System.Drawing.Size(134, 24);
            this.TextBoxDetailsPriorytet.TabIndex = 22;
            this.TextBoxDetailsPriorytet.UseSelectable = true;
            this.TextBoxDetailsPriorytet.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxDetailsPriorytet.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel19
            // 
            this.metroLabel19.AutoSize = true;
            this.metroLabel19.Location = new System.Drawing.Point(4, 35);
            this.metroLabel19.Name = "metroLabel19";
            this.metroLabel19.Size = new System.Drawing.Size(63, 20);
            this.metroLabel19.TabIndex = 21;
            this.metroLabel19.Text = "Priotytet:";
            // 
            // metroLabel18
            // 
            this.metroLabel18.AutoSize = true;
            this.metroLabel18.Location = new System.Drawing.Point(248, 35);
            this.metroLabel18.Name = "metroLabel18";
            this.metroLabel18.Size = new System.Drawing.Size(25, 20);
            this.metroLabel18.TabIndex = 19;
            this.metroLabel18.Text = "ID:";
            // 
            // TextBoxDetailsRodzaj
            // 
            // 
            // 
            // 
            this.TextBoxDetailsRodzaj.CustomButton.Image = null;
            this.TextBoxDetailsRodzaj.CustomButton.Location = new System.Drawing.Point(267, 2);
            this.TextBoxDetailsRodzaj.CustomButton.Name = "";
            this.TextBoxDetailsRodzaj.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.TextBoxDetailsRodzaj.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxDetailsRodzaj.CustomButton.TabIndex = 1;
            this.TextBoxDetailsRodzaj.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxDetailsRodzaj.CustomButton.UseSelectable = true;
            this.TextBoxDetailsRodzaj.CustomButton.Visible = false;
            this.TextBoxDetailsRodzaj.Lines = new string[0];
            this.TextBoxDetailsRodzaj.Location = new System.Drawing.Point(118, 214);
            this.TextBoxDetailsRodzaj.MaxLength = 32767;
            this.TextBoxDetailsRodzaj.Name = "TextBoxDetailsRodzaj";
            this.TextBoxDetailsRodzaj.PasswordChar = '\0';
            this.TextBoxDetailsRodzaj.ReadOnly = true;
            this.TextBoxDetailsRodzaj.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxDetailsRodzaj.SelectedText = "";
            this.TextBoxDetailsRodzaj.SelectionLength = 0;
            this.TextBoxDetailsRodzaj.SelectionStart = 0;
            this.TextBoxDetailsRodzaj.ShortcutsEnabled = true;
            this.TextBoxDetailsRodzaj.Size = new System.Drawing.Size(295, 30);
            this.TextBoxDetailsRodzaj.TabIndex = 18;
            this.TextBoxDetailsRodzaj.UseSelectable = true;
            this.TextBoxDetailsRodzaj.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxDetailsRodzaj.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel17
            // 
            this.metroLabel17.AutoSize = true;
            this.metroLabel17.Location = new System.Drawing.Point(4, 214);
            this.metroLabel17.Name = "metroLabel17";
            this.metroLabel17.Size = new System.Drawing.Size(104, 20);
            this.metroLabel17.TabIndex = 17;
            this.metroLabel17.Text = "Rodzaj zadania:";
            // 
            // TextBoxDetailsStatus
            // 
            // 
            // 
            // 
            this.TextBoxDetailsStatus.CustomButton.Image = null;
            this.TextBoxDetailsStatus.CustomButton.Location = new System.Drawing.Point(162, 2);
            this.TextBoxDetailsStatus.CustomButton.Name = "";
            this.TextBoxDetailsStatus.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.TextBoxDetailsStatus.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxDetailsStatus.CustomButton.TabIndex = 1;
            this.TextBoxDetailsStatus.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxDetailsStatus.CustomButton.UseSelectable = true;
            this.TextBoxDetailsStatus.CustomButton.Visible = false;
            this.TextBoxDetailsStatus.Lines = new string[0];
            this.TextBoxDetailsStatus.Location = new System.Drawing.Point(27, 549);
            this.TextBoxDetailsStatus.MaxLength = 32767;
            this.TextBoxDetailsStatus.Name = "TextBoxDetailsStatus";
            this.TextBoxDetailsStatus.PasswordChar = '\0';
            this.TextBoxDetailsStatus.ReadOnly = true;
            this.TextBoxDetailsStatus.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxDetailsStatus.SelectedText = "";
            this.TextBoxDetailsStatus.SelectionLength = 0;
            this.TextBoxDetailsStatus.SelectionStart = 0;
            this.TextBoxDetailsStatus.ShortcutsEnabled = true;
            this.TextBoxDetailsStatus.Size = new System.Drawing.Size(184, 24);
            this.TextBoxDetailsStatus.TabIndex = 16;
            this.TextBoxDetailsStatus.UseSelectable = true;
            this.TextBoxDetailsStatus.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxDetailsStatus.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TextBoxDetailsDodanePrzez
            // 
            // 
            // 
            // 
            this.TextBoxDetailsDodanePrzez.CustomButton.Image = null;
            this.TextBoxDetailsDodanePrzez.CustomButton.Location = new System.Drawing.Point(162, 2);
            this.TextBoxDetailsDodanePrzez.CustomButton.Name = "";
            this.TextBoxDetailsDodanePrzez.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.TextBoxDetailsDodanePrzez.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxDetailsDodanePrzez.CustomButton.TabIndex = 1;
            this.TextBoxDetailsDodanePrzez.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxDetailsDodanePrzez.CustomButton.UseSelectable = true;
            this.TextBoxDetailsDodanePrzez.CustomButton.Visible = false;
            this.TextBoxDetailsDodanePrzez.Lines = new string[0];
            this.TextBoxDetailsDodanePrzez.Location = new System.Drawing.Point(27, 493);
            this.TextBoxDetailsDodanePrzez.MaxLength = 32767;
            this.TextBoxDetailsDodanePrzez.Name = "TextBoxDetailsDodanePrzez";
            this.TextBoxDetailsDodanePrzez.PasswordChar = '\0';
            this.TextBoxDetailsDodanePrzez.ReadOnly = true;
            this.TextBoxDetailsDodanePrzez.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxDetailsDodanePrzez.SelectedText = "";
            this.TextBoxDetailsDodanePrzez.SelectionLength = 0;
            this.TextBoxDetailsDodanePrzez.SelectionStart = 0;
            this.TextBoxDetailsDodanePrzez.ShortcutsEnabled = true;
            this.TextBoxDetailsDodanePrzez.Size = new System.Drawing.Size(184, 24);
            this.TextBoxDetailsDodanePrzez.TabIndex = 15;
            this.TextBoxDetailsDodanePrzez.UseSelectable = true;
            this.TextBoxDetailsDodanePrzez.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxDetailsDodanePrzez.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TextBoxDetailsDataZak
            // 
            // 
            // 
            // 
            this.TextBoxDetailsDataZak.CustomButton.Image = null;
            this.TextBoxDetailsDataZak.CustomButton.Location = new System.Drawing.Point(112, 2);
            this.TextBoxDetailsDataZak.CustomButton.Name = "";
            this.TextBoxDetailsDataZak.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.TextBoxDetailsDataZak.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxDetailsDataZak.CustomButton.TabIndex = 1;
            this.TextBoxDetailsDataZak.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxDetailsDataZak.CustomButton.UseSelectable = true;
            this.TextBoxDetailsDataZak.CustomButton.Visible = false;
            this.TextBoxDetailsDataZak.Lines = new string[0];
            this.TextBoxDetailsDataZak.Location = new System.Drawing.Point(279, 549);
            this.TextBoxDetailsDataZak.MaxLength = 32767;
            this.TextBoxDetailsDataZak.Name = "TextBoxDetailsDataZak";
            this.TextBoxDetailsDataZak.PasswordChar = '\0';
            this.TextBoxDetailsDataZak.ReadOnly = true;
            this.TextBoxDetailsDataZak.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxDetailsDataZak.SelectedText = "";
            this.TextBoxDetailsDataZak.SelectionLength = 0;
            this.TextBoxDetailsDataZak.SelectionStart = 0;
            this.TextBoxDetailsDataZak.ShortcutsEnabled = true;
            this.TextBoxDetailsDataZak.Size = new System.Drawing.Size(134, 24);
            this.TextBoxDetailsDataZak.TabIndex = 14;
            this.TextBoxDetailsDataZak.UseSelectable = true;
            this.TextBoxDetailsDataZak.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxDetailsDataZak.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TextBoxDetailsDataDod
            // 
            // 
            // 
            // 
            this.TextBoxDetailsDataDod.CustomButton.Image = null;
            this.TextBoxDetailsDataDod.CustomButton.Location = new System.Drawing.Point(112, 2);
            this.TextBoxDetailsDataDod.CustomButton.Name = "";
            this.TextBoxDetailsDataDod.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.TextBoxDetailsDataDod.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxDetailsDataDod.CustomButton.TabIndex = 1;
            this.TextBoxDetailsDataDod.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxDetailsDataDod.CustomButton.UseSelectable = true;
            this.TextBoxDetailsDataDod.CustomButton.Visible = false;
            this.TextBoxDetailsDataDod.Lines = new string[0];
            this.TextBoxDetailsDataDod.Location = new System.Drawing.Point(279, 493);
            this.TextBoxDetailsDataDod.MaxLength = 32767;
            this.TextBoxDetailsDataDod.Name = "TextBoxDetailsDataDod";
            this.TextBoxDetailsDataDod.PasswordChar = '\0';
            this.TextBoxDetailsDataDod.ReadOnly = true;
            this.TextBoxDetailsDataDod.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxDetailsDataDod.SelectedText = "";
            this.TextBoxDetailsDataDod.SelectionLength = 0;
            this.TextBoxDetailsDataDod.SelectionStart = 0;
            this.TextBoxDetailsDataDod.ShortcutsEnabled = true;
            this.TextBoxDetailsDataDod.Size = new System.Drawing.Size(134, 24);
            this.TextBoxDetailsDataDod.TabIndex = 12;
            this.TextBoxDetailsDataDod.UseSelectable = true;
            this.TextBoxDetailsDataDod.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxDetailsDataDod.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel14
            // 
            this.metroLabel14.AutoSize = true;
            this.metroLabel14.Location = new System.Drawing.Point(279, 526);
            this.metroLabel14.Name = "metroLabel14";
            this.metroLabel14.Size = new System.Drawing.Size(121, 20);
            this.metroLabel14.TabIndex = 12;
            this.metroLabel14.Text = "Data zakończenia:";
            // 
            // metroLabel15
            // 
            this.metroLabel15.AutoSize = true;
            this.metroLabel15.Location = new System.Drawing.Point(27, 470);
            this.metroLabel15.Name = "metroLabel15";
            this.metroLabel15.Size = new System.Drawing.Size(100, 20);
            this.metroLabel15.TabIndex = 13;
            this.metroLabel15.Text = "Dodane przez:";
            // 
            // metroLabel16
            // 
            this.metroLabel16.AutoSize = true;
            this.metroLabel16.Location = new System.Drawing.Point(279, 470);
            this.metroLabel16.Name = "metroLabel16";
            this.metroLabel16.Size = new System.Drawing.Size(93, 20);
            this.metroLabel16.TabIndex = 11;
            this.metroLabel16.Text = "Data dodania:";
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.Location = new System.Drawing.Point(13, 178);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(86, 20);
            this.metroLabel13.TabIndex = 10;
            this.metroLabel13.Text = "Wykonawca:";
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.Location = new System.Drawing.Point(27, 264);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(40, 20);
            this.metroLabel12.TabIndex = 9;
            this.metroLabel12.Text = "Opis:";
            // 
            // TextBoxDetailsWykonawca
            // 
            // 
            // 
            // 
            this.TextBoxDetailsWykonawca.CustomButton.Image = null;
            this.TextBoxDetailsWykonawca.CustomButton.Location = new System.Drawing.Point(267, 2);
            this.TextBoxDetailsWykonawca.CustomButton.Name = "";
            this.TextBoxDetailsWykonawca.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.TextBoxDetailsWykonawca.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxDetailsWykonawca.CustomButton.TabIndex = 1;
            this.TextBoxDetailsWykonawca.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxDetailsWykonawca.CustomButton.UseSelectable = true;
            this.TextBoxDetailsWykonawca.CustomButton.Visible = false;
            this.TextBoxDetailsWykonawca.Lines = new string[0];
            this.TextBoxDetailsWykonawca.Location = new System.Drawing.Point(118, 178);
            this.TextBoxDetailsWykonawca.MaxLength = 32767;
            this.TextBoxDetailsWykonawca.Name = "TextBoxDetailsWykonawca";
            this.TextBoxDetailsWykonawca.PasswordChar = '\0';
            this.TextBoxDetailsWykonawca.ReadOnly = true;
            this.TextBoxDetailsWykonawca.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxDetailsWykonawca.SelectedText = "";
            this.TextBoxDetailsWykonawca.SelectionLength = 0;
            this.TextBoxDetailsWykonawca.SelectionStart = 0;
            this.TextBoxDetailsWykonawca.ShortcutsEnabled = true;
            this.TextBoxDetailsWykonawca.Size = new System.Drawing.Size(295, 30);
            this.TextBoxDetailsWykonawca.TabIndex = 8;
            this.TextBoxDetailsWykonawca.UseSelectable = true;
            this.TextBoxDetailsWykonawca.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxDetailsWykonawca.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // ButtonUsunZadanie
            // 
            this.ButtonUsunZadanie.Location = new System.Drawing.Point(27, 628);
            this.ButtonUsunZadanie.Name = "ButtonUsunZadanie";
            this.ButtonUsunZadanie.Size = new System.Drawing.Size(112, 28);
            this.ButtonUsunZadanie.TabIndex = 7;
            this.ButtonUsunZadanie.Text = "Usuń zadanie";
            this.ButtonUsunZadanie.UseSelectable = true;
            this.ButtonUsunZadanie.Click += new System.EventHandler(this.ButtonUsunZadanie_Click);
            // 
            // ButtonEditTask
            // 
            this.ButtonEditTask.Location = new System.Drawing.Point(27, 593);
            this.ButtonEditTask.Name = "ButtonEditTask";
            this.ButtonEditTask.Size = new System.Drawing.Size(112, 28);
            this.ButtonEditTask.TabIndex = 6;
            this.ButtonEditTask.Text = "Edytuj zadanie";
            this.ButtonEditTask.UseSelectable = true;
            this.ButtonEditTask.Click += new System.EventHandler(this.ButtonEditTask_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(161, 593);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(123, 20);
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "zmień wykonawcę";
            // 
            // ComboBoxDetailsWykonawcy
            // 
            this.ComboBoxDetailsWykonawcy.FormattingEnabled = true;
            this.ComboBoxDetailsWykonawcy.ItemHeight = 24;
            this.ComboBoxDetailsWykonawcy.Location = new System.Drawing.Point(163, 626);
            this.ComboBoxDetailsWykonawcy.Name = "ComboBoxDetailsWykonawcy";
            this.ComboBoxDetailsWykonawcy.Size = new System.Drawing.Size(121, 30);
            this.ComboBoxDetailsWykonawcy.TabIndex = 4;
            this.ComboBoxDetailsWykonawcy.UseSelectable = true;
            this.ComboBoxDetailsWykonawcy.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDetailsWykonawcy_SelectedIndexChanged);
            // 
            // TextBoxDetailsZadanie
            // 
            // 
            // 
            // 
            this.TextBoxDetailsZadanie.CustomButton.AutoSize = true;
            this.TextBoxDetailsZadanie.CustomButton.Image = null;
            this.TextBoxDetailsZadanie.CustomButton.Location = new System.Drawing.Point(353, 2);
            this.TextBoxDetailsZadanie.CustomButton.Name = "";
            this.TextBoxDetailsZadanie.CustomButton.Size = new System.Drawing.Size(43, 43);
            this.TextBoxDetailsZadanie.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxDetailsZadanie.CustomButton.TabIndex = 1;
            this.TextBoxDetailsZadanie.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxDetailsZadanie.CustomButton.UseSelectable = true;
            this.TextBoxDetailsZadanie.CustomButton.Visible = false;
            this.TextBoxDetailsZadanie.Lines = new string[0];
            this.TextBoxDetailsZadanie.Location = new System.Drawing.Point(14, 113);
            this.TextBoxDetailsZadanie.MaximumSize = new System.Drawing.Size(399, 500);
            this.TextBoxDetailsZadanie.MaxLength = 32767;
            this.TextBoxDetailsZadanie.Multiline = true;
            this.TextBoxDetailsZadanie.Name = "TextBoxDetailsZadanie";
            this.TextBoxDetailsZadanie.PasswordChar = '\0';
            this.TextBoxDetailsZadanie.ReadOnly = true;
            this.TextBoxDetailsZadanie.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxDetailsZadanie.SelectedText = "";
            this.TextBoxDetailsZadanie.SelectionLength = 0;
            this.TextBoxDetailsZadanie.SelectionStart = 0;
            this.TextBoxDetailsZadanie.ShortcutsEnabled = true;
            this.TextBoxDetailsZadanie.Size = new System.Drawing.Size(399, 48);
            this.TextBoxDetailsZadanie.TabIndex = 3;
            this.TextBoxDetailsZadanie.UseSelectable = true;
            this.TextBoxDetailsZadanie.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxDetailsZadanie.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TextBoxDetailsOpis
            // 
            // 
            // 
            // 
            this.TextBoxDetailsOpis.CustomButton.Image = null;
            this.TextBoxDetailsOpis.CustomButton.Location = new System.Drawing.Point(222, 2);
            this.TextBoxDetailsOpis.CustomButton.Name = "";
            this.TextBoxDetailsOpis.CustomButton.Size = new System.Drawing.Size(161, 161);
            this.TextBoxDetailsOpis.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxDetailsOpis.CustomButton.TabIndex = 1;
            this.TextBoxDetailsOpis.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxDetailsOpis.CustomButton.UseSelectable = true;
            this.TextBoxDetailsOpis.CustomButton.Visible = false;
            this.TextBoxDetailsOpis.Lines = new string[0];
            this.TextBoxDetailsOpis.Location = new System.Drawing.Point(27, 287);
            this.TextBoxDetailsOpis.MaxLength = 32767;
            this.TextBoxDetailsOpis.Multiline = true;
            this.TextBoxDetailsOpis.Name = "TextBoxDetailsOpis";
            this.TextBoxDetailsOpis.PasswordChar = '\0';
            this.TextBoxDetailsOpis.ReadOnly = true;
            this.TextBoxDetailsOpis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxDetailsOpis.SelectedText = "";
            this.TextBoxDetailsOpis.SelectionLength = 0;
            this.TextBoxDetailsOpis.SelectionStart = 0;
            this.TextBoxDetailsOpis.ShortcutsEnabled = true;
            this.TextBoxDetailsOpis.Size = new System.Drawing.Size(386, 166);
            this.TextBoxDetailsOpis.TabIndex = 2;
            this.TextBoxDetailsOpis.UseSelectable = true;
            this.TextBoxDetailsOpis.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxDetailsOpis.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TextBoxSzukanaFraza
            // 
            // 
            // 
            // 
            this.TextBoxSzukanaFraza.CustomButton.Image = null;
            this.TextBoxSzukanaFraza.CustomButton.Location = new System.Drawing.Point(192, 1);
            this.TextBoxSzukanaFraza.CustomButton.Name = "";
            this.TextBoxSzukanaFraza.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.TextBoxSzukanaFraza.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxSzukanaFraza.CustomButton.TabIndex = 1;
            this.TextBoxSzukanaFraza.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxSzukanaFraza.CustomButton.UseSelectable = true;
            this.TextBoxSzukanaFraza.CustomButton.Visible = false;
            this.TextBoxSzukanaFraza.Lines = new string[0];
            this.TextBoxSzukanaFraza.Location = new System.Drawing.Point(358, 18);
            this.TextBoxSzukanaFraza.MaxLength = 32767;
            this.TextBoxSzukanaFraza.Name = "TextBoxSzukanaFraza";
            this.TextBoxSzukanaFraza.PasswordChar = '\0';
            this.TextBoxSzukanaFraza.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxSzukanaFraza.SelectedText = "";
            this.TextBoxSzukanaFraza.SelectionLength = 0;
            this.TextBoxSzukanaFraza.SelectionStart = 0;
            this.TextBoxSzukanaFraza.ShortcutsEnabled = true;
            this.TextBoxSzukanaFraza.Size = new System.Drawing.Size(220, 29);
            this.TextBoxSzukanaFraza.TabIndex = 6;
            this.TextBoxSzukanaFraza.UseSelectable = true;
            this.TextBoxSzukanaFraza.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxSzukanaFraza.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.TextBoxSzukanaFraza.TextChanged += new System.EventHandler(this.TextBoxSzukanaFraza_TextChanged);
            // 
            // ButtonNewTask
            // 
            this.ButtonNewTask.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ButtonNewTask.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonNewTask.Location = new System.Drawing.Point(887, 9);
            this.ButtonNewTask.Name = "ButtonNewTask";
            this.ButtonNewTask.Size = new System.Drawing.Size(125, 38);
            this.ButtonNewTask.TabIndex = 5;
            this.ButtonNewTask.Text = "Nowe zadanie";
            this.ButtonNewTask.UseSelectable = true;
            this.ButtonNewTask.Click += new System.EventHandler(this.ButtonNewTask_Click);
            // 
            // ComboBoxStatus
            // 
            this.ComboBoxStatus.FormattingEnabled = true;
            this.ComboBoxStatus.ItemHeight = 24;
            this.ComboBoxStatus.Location = new System.Drawing.Point(141, 17);
            this.ComboBoxStatus.Name = "ComboBoxStatus";
            this.ComboBoxStatus.Size = new System.Drawing.Size(121, 30);
            this.ComboBoxStatus.TabIndex = 4;
            this.ComboBoxStatus.UseSelectable = true;
            this.ComboBoxStatus.SelectedIndexChanged += new System.EventHandler(this.ComboBoxStatus_SelectedIndexChanged);
            // 
            // ComboBoxWykonawcy
            // 
            this.ComboBoxWykonawcy.FormattingEnabled = true;
            this.ComboBoxWykonawcy.ItemHeight = 24;
            this.ComboBoxWykonawcy.Location = new System.Drawing.Point(3, 17);
            this.ComboBoxWykonawcy.Name = "ComboBoxWykonawcy";
            this.ComboBoxWykonawcy.Size = new System.Drawing.Size(121, 30);
            this.ComboBoxWykonawcy.TabIndex = 3;
            this.ComboBoxWykonawcy.UseSelectable = true;
            this.ComboBoxWykonawcy.SelectedIndexChanged += new System.EventHandler(this.ComboBoxWykonawcy_SelectedIndexChanged);
            // 
            // metroGrid1
            // 
            this.metroGrid1.AllowUserToAddRows = false;
            this.metroGrid1.AllowUserToResizeRows = false;
            this.metroGrid1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.metroGrid1.BackgroundColor = System.Drawing.Color.White;
            this.metroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.metroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.metroGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.priorytet,
            this.Zad,
            this.rodzaj_zad,
            this.dla_kogo,
            this.dodanie,
            this.termin,
            this.status,
            this.zakonczenie,
            this.dodal});
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle25.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid1.DefaultCellStyle = dataGridViewCellStyle25;
            this.metroGrid1.EnableHeadersVisualStyles = false;
            this.metroGrid1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGrid1.GridColor = System.Drawing.Color.White;
            this.metroGrid1.Location = new System.Drawing.Point(-4, 60);
            this.metroGrid1.MultiSelect = false;
            this.metroGrid1.Name = "metroGrid1";
            this.metroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.metroGrid1.RowHeadersWidth = 51;
            this.metroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.metroGrid1.Size = new System.Drawing.Size(1041, 608);
            this.metroGrid1.TabIndex = 2;
            this.metroGrid1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.metroGrid1_CellMouseClick);
            this.metroGrid1.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.metroGrid1_CellMouseUp);
            this.metroGrid1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.metroGrid1_CellValueChanged);
            this.metroGrid1.SelectionChanged += new System.EventHandler(this.metroGrid1_SelectionChanged);
            // 
            // id
            // 
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.id.DefaultCellStyle = dataGridViewCellStyle15;
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 30;
            // 
            // priorytet
            // 
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.priorytet.DefaultCellStyle = dataGridViewCellStyle16;
            this.priorytet.HeaderText = "Priorytet";
            this.priorytet.MinimumWidth = 6;
            this.priorytet.Name = "priorytet";
            this.priorytet.ReadOnly = true;
            this.priorytet.Width = 70;
            // 
            // Zad
            // 
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Zad.DefaultCellStyle = dataGridViewCellStyle17;
            this.Zad.HeaderText = "Zadanie";
            this.Zad.MinimumWidth = 6;
            this.Zad.Name = "Zad";
            this.Zad.ReadOnly = true;
            this.Zad.Width = 150;
            // 
            // rodzaj_zad
            // 
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.rodzaj_zad.DefaultCellStyle = dataGridViewCellStyle18;
            this.rodzaj_zad.HeaderText = "Rodzaj zadania:";
            this.rodzaj_zad.MinimumWidth = 6;
            this.rodzaj_zad.Name = "rodzaj_zad";
            this.rodzaj_zad.ReadOnly = true;
            this.rodzaj_zad.Width = 125;
            // 
            // dla_kogo
            // 
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dla_kogo.DefaultCellStyle = dataGridViewCellStyle19;
            this.dla_kogo.HeaderText = "Wykonawca";
            this.dla_kogo.MinimumWidth = 6;
            this.dla_kogo.Name = "dla_kogo";
            this.dla_kogo.ReadOnly = true;
            this.dla_kogo.Width = 125;
            // 
            // dodanie
            // 
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dodanie.DefaultCellStyle = dataGridViewCellStyle20;
            this.dodanie.HeaderText = "Data dodania";
            this.dodanie.MinimumWidth = 6;
            this.dodanie.Name = "dodanie";
            this.dodanie.ReadOnly = true;
            this.dodanie.Width = 125;
            // 
            // termin
            // 
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.termin.DefaultCellStyle = dataGridViewCellStyle21;
            this.termin.HeaderText = "Termin";
            this.termin.MinimumWidth = 6;
            this.termin.Name = "termin";
            this.termin.ReadOnly = true;
            this.termin.Width = 125;
            // 
            // status
            // 
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.NullValue = false;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.status.DefaultCellStyle = dataGridViewCellStyle22;
            this.status.FalseValue = "0";
            this.status.HeaderText = "Status";
            this.status.MinimumWidth = 6;
            this.status.Name = "status";
            this.status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.status.TrueValue = "1";
            this.status.Width = 125;
            // 
            // zakonczenie
            // 
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.zakonczenie.DefaultCellStyle = dataGridViewCellStyle23;
            this.zakonczenie.HeaderText = "Data zakończenia";
            this.zakonczenie.MinimumWidth = 6;
            this.zakonczenie.Name = "zakonczenie";
            this.zakonczenie.ReadOnly = true;
            this.zakonczenie.Width = 125;
            // 
            // dodal
            // 
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dodal.DefaultCellStyle = dataGridViewCellStyle24;
            this.dodal.HeaderText = "Dodane przez";
            this.dodal.MinimumWidth = 6;
            this.dodal.Name = "dodal";
            this.dodal.ReadOnly = true;
            this.dodal.Width = 125;
            // 
            // metroTabPage4
            // 
            this.metroTabPage4.Controls.Add(this.metroTabControl3);
            this.metroTabPage4.HorizontalScrollbarBarColor = true;
            this.metroTabPage4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage4.HorizontalScrollbarSize = 10;
            this.metroTabPage4.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage4.Name = "metroTabPage4";
            this.metroTabPage4.Size = new System.Drawing.Size(1476, 747);
            this.metroTabPage4.TabIndex = 1;
            this.metroTabPage4.Text = "Ustawienia";
            this.metroTabPage4.VerticalScrollbarBarColor = true;
            this.metroTabPage4.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage4.VerticalScrollbarSize = 10;
            // 
            // metroTabControl3
            // 
            this.metroTabControl3.Controls.Add(this.metroTabPage5);
            this.metroTabControl3.Controls.Add(this.metroTabPage6);
            this.metroTabControl3.Controls.Add(this.metroTabPage8);
            this.metroTabControl3.Controls.Add(this.metroTabPage9);
            this.metroTabControl3.Location = new System.Drawing.Point(56, 24);
            this.metroTabControl3.Name = "metroTabControl3";
            this.metroTabControl3.SelectedIndex = 3;
            this.metroTabControl3.Size = new System.Drawing.Size(1275, 591);
            this.metroTabControl3.TabIndex = 2;
            this.metroTabControl3.UseSelectable = true;
            // 
            // metroTabPage5
            // 
            this.metroTabPage5.Controls.Add(this.TextBoxUsersList);
            this.metroTabPage5.Controls.Add(this.metroLabel11);
            this.metroTabPage5.Controls.Add(this.metroLabel10);
            this.metroTabPage5.Controls.Add(this.TextBoxAddUser);
            this.metroTabPage5.Controls.Add(this.ButtonDodajUzytkownika);
            this.metroTabPage5.Controls.Add(this.metroLabel9);
            this.metroTabPage5.Controls.Add(this.ButtonLogowanie);
            this.metroTabPage5.Controls.Add(this.metroLabel8);
            this.metroTabPage5.Controls.Add(this.TextBoxUserName);
            this.metroTabPage5.HorizontalScrollbarBarColor = true;
            this.metroTabPage5.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage5.HorizontalScrollbarSize = 10;
            this.metroTabPage5.Location = new System.Drawing.Point(4, 39);
            this.metroTabPage5.Name = "metroTabPage5";
            this.metroTabPage5.Size = new System.Drawing.Size(1267, 548);
            this.metroTabPage5.TabIndex = 0;
            this.metroTabPage5.Text = "Użytkownik";
            this.metroTabPage5.VerticalScrollbarBarColor = true;
            this.metroTabPage5.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage5.VerticalScrollbarSize = 10;
            // 
            // TextBoxUsersList
            // 
            // 
            // 
            // 
            this.TextBoxUsersList.CustomButton.Image = null;
            this.TextBoxUsersList.CustomButton.Location = new System.Drawing.Point(-48, 2);
            this.TextBoxUsersList.CustomButton.Name = "";
            this.TextBoxUsersList.CustomButton.Size = new System.Drawing.Size(195, 195);
            this.TextBoxUsersList.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxUsersList.CustomButton.TabIndex = 1;
            this.TextBoxUsersList.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxUsersList.CustomButton.UseSelectable = true;
            this.TextBoxUsersList.CustomButton.Visible = false;
            this.TextBoxUsersList.Lines = new string[0];
            this.TextBoxUsersList.Location = new System.Drawing.Point(424, 60);
            this.TextBoxUsersList.MaxLength = 32767;
            this.TextBoxUsersList.Multiline = true;
            this.TextBoxUsersList.Name = "TextBoxUsersList";
            this.TextBoxUsersList.PasswordChar = '\0';
            this.TextBoxUsersList.ReadOnly = true;
            this.TextBoxUsersList.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.TextBoxUsersList.SelectedText = "";
            this.TextBoxUsersList.SelectionLength = 0;
            this.TextBoxUsersList.SelectionStart = 0;
            this.TextBoxUsersList.ShortcutsEnabled = true;
            this.TextBoxUsersList.Size = new System.Drawing.Size(150, 200);
            this.TextBoxUsersList.TabIndex = 10;
            this.TextBoxUsersList.UseSelectable = true;
            this.TextBoxUsersList.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxUsersList.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(434, 28);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(130, 20);
            this.metroLabel11.TabIndex = 9;
            this.metroLabel11.Text = "Lista użytkowników:";
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(847, 60);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(134, 20);
            this.metroLabel10.TabIndex = 8;
            this.metroLabel10.Text = "Nazwa użytkownika:";
            // 
            // TextBoxAddUser
            // 
            // 
            // 
            // 
            this.TextBoxAddUser.CustomButton.Image = null;
            this.TextBoxAddUser.CustomButton.Location = new System.Drawing.Point(100, 2);
            this.TextBoxAddUser.CustomButton.Name = "";
            this.TextBoxAddUser.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.TextBoxAddUser.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxAddUser.CustomButton.TabIndex = 1;
            this.TextBoxAddUser.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxAddUser.CustomButton.UseSelectable = true;
            this.TextBoxAddUser.CustomButton.Visible = false;
            this.TextBoxAddUser.Lines = new string[0];
            this.TextBoxAddUser.Location = new System.Drawing.Point(977, 60);
            this.TextBoxAddUser.MaxLength = 32767;
            this.TextBoxAddUser.Name = "TextBoxAddUser";
            this.TextBoxAddUser.PasswordChar = '\0';
            this.TextBoxAddUser.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxAddUser.SelectedText = "";
            this.TextBoxAddUser.SelectionLength = 0;
            this.TextBoxAddUser.SelectionStart = 0;
            this.TextBoxAddUser.ShortcutsEnabled = true;
            this.TextBoxAddUser.Size = new System.Drawing.Size(128, 30);
            this.TextBoxAddUser.TabIndex = 7;
            this.TextBoxAddUser.UseSelectable = true;
            this.TextBoxAddUser.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxAddUser.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // ButtonDodajUzytkownika
            // 
            this.ButtonDodajUzytkownika.Location = new System.Drawing.Point(1011, 109);
            this.ButtonDodajUzytkownika.Name = "ButtonDodajUzytkownika";
            this.ButtonDodajUzytkownika.Size = new System.Drawing.Size(75, 23);
            this.ButtonDodajUzytkownika.TabIndex = 6;
            this.ButtonDodajUzytkownika.Text = "Dodaj";
            this.ButtonDodajUzytkownika.UseSelectable = true;
            this.ButtonDodajUzytkownika.Click += new System.EventHandler(this.ButtonDodajUzytkownika_Click);
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(906, 27);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(215, 20);
            this.metroLabel9.TabIndex = 5;
            this.metroLabel9.Text = "Dodawanie nowego użytkownika:";
            // 
            // ButtonLogowanie
            // 
            this.ButtonLogowanie.Location = new System.Drawing.Point(45, 109);
            this.ButtonLogowanie.Name = "ButtonLogowanie";
            this.ButtonLogowanie.Size = new System.Drawing.Size(75, 23);
            this.ButtonLogowanie.TabIndex = 4;
            this.ButtonLogowanie.Text = "Zapisz";
            this.ButtonLogowanie.UseSelectable = true;
            this.ButtonLogowanie.Click += new System.EventHandler(this.ButtonLogowanie_Click);
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(19, 28);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(134, 20);
            this.metroLabel8.TabIndex = 3;
            this.metroLabel8.Text = "Nazwa użytkownika:";
            // 
            // TextBoxUserName
            // 
            // 
            // 
            // 
            this.TextBoxUserName.CustomButton.Image = null;
            this.TextBoxUserName.CustomButton.Location = new System.Drawing.Point(100, 2);
            this.TextBoxUserName.CustomButton.Name = "";
            this.TextBoxUserName.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.TextBoxUserName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxUserName.CustomButton.TabIndex = 1;
            this.TextBoxUserName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxUserName.CustomButton.UseSelectable = true;
            this.TextBoxUserName.CustomButton.Visible = false;
            this.TextBoxUserName.Lines = new string[0];
            this.TextBoxUserName.Location = new System.Drawing.Point(19, 60);
            this.TextBoxUserName.MaxLength = 32767;
            this.TextBoxUserName.Name = "TextBoxUserName";
            this.TextBoxUserName.PasswordChar = '\0';
            this.TextBoxUserName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxUserName.SelectedText = "";
            this.TextBoxUserName.SelectionLength = 0;
            this.TextBoxUserName.SelectionStart = 0;
            this.TextBoxUserName.ShortcutsEnabled = true;
            this.TextBoxUserName.Size = new System.Drawing.Size(128, 30);
            this.TextBoxUserName.TabIndex = 2;
            this.TextBoxUserName.UseSelectable = true;
            this.TextBoxUserName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxUserName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTabPage6
            // 
            this.metroTabPage6.Controls.Add(this.TextBoxDBTesting);
            this.metroTabPage6.Controls.Add(this.TextBoxDBinfo);
            this.metroTabPage6.Controls.Add(this.TextBoxDBPassword);
            this.metroTabPage6.Controls.Add(this.TextBoxDBUser);
            this.metroTabPage6.Controls.Add(this.TextBoxDBName);
            this.metroTabPage6.Controls.Add(this.TextBoxServerID);
            this.metroTabPage6.Controls.Add(this.ButtonSaveDB);
            this.metroTabPage6.Controls.Add(this.metroLabel7);
            this.metroTabPage6.Controls.Add(this.metroLabel6);
            this.metroTabPage6.Controls.Add(this.metroLabel5);
            this.metroTabPage6.Controls.Add(this.metroLabel4);
            this.metroTabPage6.HorizontalScrollbarBarColor = true;
            this.metroTabPage6.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage6.HorizontalScrollbarSize = 10;
            this.metroTabPage6.Location = new System.Drawing.Point(4, 39);
            this.metroTabPage6.Name = "metroTabPage6";
            this.metroTabPage6.Size = new System.Drawing.Size(1267, 548);
            this.metroTabPage6.TabIndex = 1;
            this.metroTabPage6.Text = "Baza danych";
            this.metroTabPage6.VerticalScrollbarBarColor = true;
            this.metroTabPage6.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage6.VerticalScrollbarSize = 10;
            // 
            // TextBoxDBTesting
            // 
            // 
            // 
            // 
            this.TextBoxDBTesting.CustomButton.Image = null;
            this.TextBoxDBTesting.CustomButton.Location = new System.Drawing.Point(-11, 2);
            this.TextBoxDBTesting.CustomButton.Name = "";
            this.TextBoxDBTesting.CustomButton.Size = new System.Drawing.Size(395, 395);
            this.TextBoxDBTesting.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxDBTesting.CustomButton.TabIndex = 1;
            this.TextBoxDBTesting.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxDBTesting.CustomButton.UseSelectable = true;
            this.TextBoxDBTesting.CustomButton.Visible = false;
            this.TextBoxDBTesting.Lines = new string[0];
            this.TextBoxDBTesting.Location = new System.Drawing.Point(648, 61);
            this.TextBoxDBTesting.MaxLength = 32767;
            this.TextBoxDBTesting.Name = "TextBoxDBTesting";
            this.TextBoxDBTesting.PasswordChar = '\0';
            this.TextBoxDBTesting.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxDBTesting.SelectedText = "";
            this.TextBoxDBTesting.SelectionLength = 0;
            this.TextBoxDBTesting.SelectionStart = 0;
            this.TextBoxDBTesting.ShortcutsEnabled = true;
            this.TextBoxDBTesting.Size = new System.Drawing.Size(387, 400);
            this.TextBoxDBTesting.TabIndex = 12;
            this.TextBoxDBTesting.UseSelectable = true;
            this.TextBoxDBTesting.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxDBTesting.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TextBoxDBinfo
            // 
            // 
            // 
            // 
            this.TextBoxDBinfo.CustomButton.Image = null;
            this.TextBoxDBinfo.CustomButton.Location = new System.Drawing.Point(218, 1);
            this.TextBoxDBinfo.CustomButton.Name = "";
            this.TextBoxDBinfo.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TextBoxDBinfo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxDBinfo.CustomButton.TabIndex = 1;
            this.TextBoxDBinfo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxDBinfo.CustomButton.UseSelectable = true;
            this.TextBoxDBinfo.CustomButton.Visible = false;
            this.TextBoxDBinfo.Lines = new string[0];
            this.TextBoxDBinfo.Location = new System.Drawing.Point(119, 272);
            this.TextBoxDBinfo.MaxLength = 32767;
            this.TextBoxDBinfo.Name = "TextBoxDBinfo";
            this.TextBoxDBinfo.PasswordChar = '\0';
            this.TextBoxDBinfo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxDBinfo.SelectedText = "";
            this.TextBoxDBinfo.SelectionLength = 0;
            this.TextBoxDBinfo.SelectionStart = 0;
            this.TextBoxDBinfo.ShortcutsEnabled = true;
            this.TextBoxDBinfo.Size = new System.Drawing.Size(240, 23);
            this.TextBoxDBinfo.TabIndex = 11;
            this.TextBoxDBinfo.UseSelectable = true;
            this.TextBoxDBinfo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxDBinfo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TextBoxDBPassword
            // 
            // 
            // 
            // 
            this.TextBoxDBPassword.CustomButton.Image = null;
            this.TextBoxDBPassword.CustomButton.Location = new System.Drawing.Point(139, 1);
            this.TextBoxDBPassword.CustomButton.Name = "";
            this.TextBoxDBPassword.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TextBoxDBPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxDBPassword.CustomButton.TabIndex = 1;
            this.TextBoxDBPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxDBPassword.CustomButton.UseSelectable = true;
            this.TextBoxDBPassword.CustomButton.Visible = false;
            this.TextBoxDBPassword.Lines = new string[0];
            this.TextBoxDBPassword.Location = new System.Drawing.Point(160, 161);
            this.TextBoxDBPassword.MaxLength = 32767;
            this.TextBoxDBPassword.Name = "TextBoxDBPassword";
            this.TextBoxDBPassword.PasswordChar = '\0';
            this.TextBoxDBPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxDBPassword.SelectedText = "";
            this.TextBoxDBPassword.SelectionLength = 0;
            this.TextBoxDBPassword.SelectionStart = 0;
            this.TextBoxDBPassword.ShortcutsEnabled = true;
            this.TextBoxDBPassword.Size = new System.Drawing.Size(161, 23);
            this.TextBoxDBPassword.TabIndex = 10;
            this.TextBoxDBPassword.UseSelectable = true;
            this.TextBoxDBPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxDBPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TextBoxDBUser
            // 
            // 
            // 
            // 
            this.TextBoxDBUser.CustomButton.Image = null;
            this.TextBoxDBUser.CustomButton.Location = new System.Drawing.Point(139, 1);
            this.TextBoxDBUser.CustomButton.Name = "";
            this.TextBoxDBUser.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TextBoxDBUser.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxDBUser.CustomButton.TabIndex = 1;
            this.TextBoxDBUser.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxDBUser.CustomButton.UseSelectable = true;
            this.TextBoxDBUser.CustomButton.Visible = false;
            this.TextBoxDBUser.Lines = new string[0];
            this.TextBoxDBUser.Location = new System.Drawing.Point(160, 128);
            this.TextBoxDBUser.MaxLength = 32767;
            this.TextBoxDBUser.Name = "TextBoxDBUser";
            this.TextBoxDBUser.PasswordChar = '\0';
            this.TextBoxDBUser.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxDBUser.SelectedText = "";
            this.TextBoxDBUser.SelectionLength = 0;
            this.TextBoxDBUser.SelectionStart = 0;
            this.TextBoxDBUser.ShortcutsEnabled = true;
            this.TextBoxDBUser.Size = new System.Drawing.Size(161, 23);
            this.TextBoxDBUser.TabIndex = 9;
            this.TextBoxDBUser.UseSelectable = true;
            this.TextBoxDBUser.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxDBUser.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TextBoxDBName
            // 
            // 
            // 
            // 
            this.TextBoxDBName.CustomButton.Image = null;
            this.TextBoxDBName.CustomButton.Location = new System.Drawing.Point(139, 1);
            this.TextBoxDBName.CustomButton.Name = "";
            this.TextBoxDBName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TextBoxDBName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxDBName.CustomButton.TabIndex = 1;
            this.TextBoxDBName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxDBName.CustomButton.UseSelectable = true;
            this.TextBoxDBName.CustomButton.Visible = false;
            this.TextBoxDBName.Lines = new string[0];
            this.TextBoxDBName.Location = new System.Drawing.Point(160, 89);
            this.TextBoxDBName.MaxLength = 32767;
            this.TextBoxDBName.Name = "TextBoxDBName";
            this.TextBoxDBName.PasswordChar = '\0';
            this.TextBoxDBName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxDBName.SelectedText = "";
            this.TextBoxDBName.SelectionLength = 0;
            this.TextBoxDBName.SelectionStart = 0;
            this.TextBoxDBName.ShortcutsEnabled = true;
            this.TextBoxDBName.Size = new System.Drawing.Size(161, 23);
            this.TextBoxDBName.TabIndex = 8;
            this.TextBoxDBName.UseSelectable = true;
            this.TextBoxDBName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxDBName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TextBoxServerID
            // 
            // 
            // 
            // 
            this.TextBoxServerID.CustomButton.Image = null;
            this.TextBoxServerID.CustomButton.Location = new System.Drawing.Point(139, 1);
            this.TextBoxServerID.CustomButton.Name = "";
            this.TextBoxServerID.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TextBoxServerID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxServerID.CustomButton.TabIndex = 1;
            this.TextBoxServerID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxServerID.CustomButton.UseSelectable = true;
            this.TextBoxServerID.CustomButton.Visible = false;
            this.TextBoxServerID.Lines = new string[0];
            this.TextBoxServerID.Location = new System.Drawing.Point(160, 49);
            this.TextBoxServerID.MaxLength = 32767;
            this.TextBoxServerID.Name = "TextBoxServerID";
            this.TextBoxServerID.PasswordChar = '\0';
            this.TextBoxServerID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxServerID.SelectedText = "";
            this.TextBoxServerID.SelectionLength = 0;
            this.TextBoxServerID.SelectionStart = 0;
            this.TextBoxServerID.ShortcutsEnabled = true;
            this.TextBoxServerID.Size = new System.Drawing.Size(161, 23);
            this.TextBoxServerID.TabIndex = 7;
            this.TextBoxServerID.UseSelectable = true;
            this.TextBoxServerID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxServerID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // ButtonSaveDB
            // 
            this.ButtonSaveDB.Location = new System.Drawing.Point(204, 211);
            this.ButtonSaveDB.Name = "ButtonSaveDB";
            this.ButtonSaveDB.Size = new System.Drawing.Size(75, 23);
            this.ButtonSaveDB.TabIndex = 6;
            this.ButtonSaveDB.Text = "Zapisz";
            this.ButtonSaveDB.UseSelectable = true;
            this.ButtonSaveDB.Click += new System.EventHandler(this.ButtonSaveDB_Click);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel7.Location = new System.Drawing.Point(95, 161);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(44, 20);
            this.metroLabel7.TabIndex = 5;
            this.metroLabel7.Text = "hasło";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel6.Location = new System.Drawing.Point(102, 132);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(36, 20);
            this.metroLabel6.TabIndex = 4;
            this.metroLabel6.Text = "user";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(10, 89);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(137, 20);
            this.metroLabel5.TabIndex = 3;
            this.metroLabel5.Text = "nazwa bazy danych";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(63, 49);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(79, 20);
            this.metroLabel4.TabIndex = 2;
            this.metroLabel4.Text = "ID serwera";
            // 
            // metroTabPage8
            // 
            this.metroTabPage8.Controls.Add(this.TxtBoxGreen);
            this.metroTabPage8.Controls.Add(this.TxtBoxYellow);
            this.metroTabPage8.Controls.Add(this.TxtBoxOrange);
            this.metroTabPage8.Controls.Add(this.TxtBoxRed);
            this.metroTabPage8.Controls.Add(this.metroLabel30);
            this.metroTabPage8.Controls.Add(this.TextBoxSzary);
            this.metroTabPage8.Controls.Add(this.TextBoxJasnyZielony);
            this.metroTabPage8.Controls.Add(this.TextBoxCzarny);
            this.metroTabPage8.Controls.Add(this.textBox7);
            this.metroTabPage8.Controls.Add(this.textBox6);
            this.metroTabPage8.Controls.Add(this.textBox5);
            this.metroTabPage8.Controls.Add(this.textBox4);
            this.metroTabPage8.Controls.Add(this.textBox3);
            this.metroTabPage8.Controls.Add(this.textBox2);
            this.metroTabPage8.Controls.Add(this.textBox1);
            this.metroTabPage8.Controls.Add(this.metroLabel28);
            this.metroTabPage8.Controls.Add(this.metroLabel27);
            this.metroTabPage8.HorizontalScrollbarBarColor = true;
            this.metroTabPage8.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage8.HorizontalScrollbarSize = 10;
            this.metroTabPage8.Location = new System.Drawing.Point(4, 39);
            this.metroTabPage8.Name = "metroTabPage8";
            this.metroTabPage8.Size = new System.Drawing.Size(1267, 548);
            this.metroTabPage8.TabIndex = 2;
            this.metroTabPage8.Text = "Kolory terminów";
            this.metroTabPage8.VerticalScrollbarBarColor = true;
            this.metroTabPage8.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage8.VerticalScrollbarSize = 10;
            // 
            // TxtBoxGreen
            // 
            // 
            // 
            // 
            this.TxtBoxGreen.CustomButton.Image = null;
            this.TxtBoxGreen.CustomButton.Location = new System.Drawing.Point(92, 1);
            this.TxtBoxGreen.CustomButton.Name = "";
            this.TxtBoxGreen.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TxtBoxGreen.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TxtBoxGreen.CustomButton.TabIndex = 1;
            this.TxtBoxGreen.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TxtBoxGreen.CustomButton.UseSelectable = true;
            this.TxtBoxGreen.CustomButton.Visible = false;
            this.TxtBoxGreen.Lines = new string[] {
        "powyżej 10dni"};
            this.TxtBoxGreen.Location = new System.Drawing.Point(507, 278);
            this.TxtBoxGreen.MaxLength = 32767;
            this.TxtBoxGreen.Name = "TxtBoxGreen";
            this.TxtBoxGreen.PasswordChar = '\0';
            this.TxtBoxGreen.ReadOnly = true;
            this.TxtBoxGreen.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TxtBoxGreen.SelectedText = "";
            this.TxtBoxGreen.SelectionLength = 0;
            this.TxtBoxGreen.SelectionStart = 0;
            this.TxtBoxGreen.ShortcutsEnabled = true;
            this.TxtBoxGreen.Size = new System.Drawing.Size(114, 23);
            this.TxtBoxGreen.TabIndex = 53;
            this.TxtBoxGreen.Text = "powyżej 10dni";
            this.TxtBoxGreen.UseSelectable = true;
            this.TxtBoxGreen.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TxtBoxGreen.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TxtBoxYellow
            // 
            // 
            // 
            // 
            this.TxtBoxYellow.CustomButton.Image = null;
            this.TxtBoxYellow.CustomButton.Location = new System.Drawing.Point(92, 1);
            this.TxtBoxYellow.CustomButton.Name = "";
            this.TxtBoxYellow.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TxtBoxYellow.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TxtBoxYellow.CustomButton.TabIndex = 1;
            this.TxtBoxYellow.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TxtBoxYellow.CustomButton.UseSelectable = true;
            this.TxtBoxYellow.CustomButton.Visible = false;
            this.TxtBoxYellow.Lines = new string[] {
        "od 5 do 10 dni"};
            this.TxtBoxYellow.Location = new System.Drawing.Point(507, 234);
            this.TxtBoxYellow.MaxLength = 32767;
            this.TxtBoxYellow.Name = "TxtBoxYellow";
            this.TxtBoxYellow.PasswordChar = '\0';
            this.TxtBoxYellow.ReadOnly = true;
            this.TxtBoxYellow.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TxtBoxYellow.SelectedText = "";
            this.TxtBoxYellow.SelectionLength = 0;
            this.TxtBoxYellow.SelectionStart = 0;
            this.TxtBoxYellow.ShortcutsEnabled = true;
            this.TxtBoxYellow.Size = new System.Drawing.Size(114, 23);
            this.TxtBoxYellow.TabIndex = 52;
            this.TxtBoxYellow.Text = "od 5 do 10 dni";
            this.TxtBoxYellow.UseSelectable = true;
            this.TxtBoxYellow.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TxtBoxYellow.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TxtBoxOrange
            // 
            // 
            // 
            // 
            this.TxtBoxOrange.CustomButton.Image = null;
            this.TxtBoxOrange.CustomButton.Location = new System.Drawing.Point(92, 1);
            this.TxtBoxOrange.CustomButton.Name = "";
            this.TxtBoxOrange.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TxtBoxOrange.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TxtBoxOrange.CustomButton.TabIndex = 1;
            this.TxtBoxOrange.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TxtBoxOrange.CustomButton.UseSelectable = true;
            this.TxtBoxOrange.CustomButton.Visible = false;
            this.TxtBoxOrange.Lines = new string[] {
        "od 1 do 4 dni"};
            this.TxtBoxOrange.Location = new System.Drawing.Point(507, 191);
            this.TxtBoxOrange.MaxLength = 32767;
            this.TxtBoxOrange.Name = "TxtBoxOrange";
            this.TxtBoxOrange.PasswordChar = '\0';
            this.TxtBoxOrange.ReadOnly = true;
            this.TxtBoxOrange.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TxtBoxOrange.SelectedText = "";
            this.TxtBoxOrange.SelectionLength = 0;
            this.TxtBoxOrange.SelectionStart = 0;
            this.TxtBoxOrange.ShortcutsEnabled = true;
            this.TxtBoxOrange.Size = new System.Drawing.Size(114, 23);
            this.TxtBoxOrange.TabIndex = 51;
            this.TxtBoxOrange.Text = "od 1 do 4 dni";
            this.TxtBoxOrange.UseSelectable = true;
            this.TxtBoxOrange.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TxtBoxOrange.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TxtBoxRed
            // 
            // 
            // 
            // 
            this.TxtBoxRed.CustomButton.Image = null;
            this.TxtBoxRed.CustomButton.Location = new System.Drawing.Point(92, 1);
            this.TxtBoxRed.CustomButton.Name = "";
            this.TxtBoxRed.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TxtBoxRed.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TxtBoxRed.CustomButton.TabIndex = 1;
            this.TxtBoxRed.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TxtBoxRed.CustomButton.UseSelectable = true;
            this.TxtBoxRed.CustomButton.Visible = false;
            this.TxtBoxRed.Lines = new string[] {
        "0 dni"};
            this.TxtBoxRed.Location = new System.Drawing.Point(507, 144);
            this.TxtBoxRed.MaxLength = 32767;
            this.TxtBoxRed.Name = "TxtBoxRed";
            this.TxtBoxRed.PasswordChar = '\0';
            this.TxtBoxRed.ReadOnly = true;
            this.TxtBoxRed.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TxtBoxRed.SelectedText = "";
            this.TxtBoxRed.SelectionLength = 0;
            this.TxtBoxRed.SelectionStart = 0;
            this.TxtBoxRed.ShortcutsEnabled = true;
            this.TxtBoxRed.Size = new System.Drawing.Size(114, 23);
            this.TxtBoxRed.TabIndex = 50;
            this.TxtBoxRed.Text = "0 dni";
            this.TxtBoxRed.UseSelectable = true;
            this.TxtBoxRed.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TxtBoxRed.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel30
            // 
            this.metroLabel30.AutoSize = true;
            this.metroLabel30.Location = new System.Drawing.Point(627, 146);
            this.metroLabel30.Name = "metroLabel30";
            this.metroLabel30.Size = new System.Drawing.Size(0, 0);
            this.metroLabel30.TabIndex = 38;
            // 
            // TextBoxSzary
            // 
            // 
            // 
            // 
            this.TextBoxSzary.CustomButton.Image = null;
            this.TextBoxSzary.CustomButton.Location = new System.Drawing.Point(92, 1);
            this.TextBoxSzary.CustomButton.Name = "";
            this.TextBoxSzary.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TextBoxSzary.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxSzary.CustomButton.TabIndex = 1;
            this.TextBoxSzary.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxSzary.CustomButton.UseSelectable = true;
            this.TextBoxSzary.CustomButton.Visible = false;
            this.TextBoxSzary.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.TextBoxSzary.Lines = new string[] {
        "WYKONANE"};
            this.TextBoxSzary.Location = new System.Drawing.Point(507, 384);
            this.TextBoxSzary.MaxLength = 32767;
            this.TextBoxSzary.Name = "TextBoxSzary";
            this.TextBoxSzary.PasswordChar = '\0';
            this.TextBoxSzary.ReadOnly = true;
            this.TextBoxSzary.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxSzary.SelectedText = "";
            this.TextBoxSzary.SelectionLength = 0;
            this.TextBoxSzary.SelectionStart = 0;
            this.TextBoxSzary.ShortcutsEnabled = true;
            this.TextBoxSzary.Size = new System.Drawing.Size(114, 23);
            this.TextBoxSzary.TabIndex = 36;
            this.TextBoxSzary.Text = "WYKONANE";
            this.TextBoxSzary.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxSzary.UseSelectable = true;
            this.TextBoxSzary.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxSzary.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TextBoxJasnyZielony
            // 
            // 
            // 
            // 
            this.TextBoxJasnyZielony.CustomButton.Image = null;
            this.TextBoxJasnyZielony.CustomButton.Location = new System.Drawing.Point(92, 1);
            this.TextBoxJasnyZielony.CustomButton.Name = "";
            this.TextBoxJasnyZielony.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TextBoxJasnyZielony.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxJasnyZielony.CustomButton.TabIndex = 1;
            this.TextBoxJasnyZielony.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxJasnyZielony.CustomButton.UseSelectable = true;
            this.TextBoxJasnyZielony.CustomButton.Visible = false;
            this.TextBoxJasnyZielony.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.TextBoxJasnyZielony.Lines = new string[] {
        "BEZTERMINOWE"};
            this.TextBoxJasnyZielony.Location = new System.Drawing.Point(507, 337);
            this.TextBoxJasnyZielony.MaxLength = 32767;
            this.TextBoxJasnyZielony.Name = "TextBoxJasnyZielony";
            this.TextBoxJasnyZielony.PasswordChar = '\0';
            this.TextBoxJasnyZielony.ReadOnly = true;
            this.TextBoxJasnyZielony.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxJasnyZielony.SelectedText = "";
            this.TextBoxJasnyZielony.SelectionLength = 0;
            this.TextBoxJasnyZielony.SelectionStart = 0;
            this.TextBoxJasnyZielony.ShortcutsEnabled = true;
            this.TextBoxJasnyZielony.Size = new System.Drawing.Size(114, 23);
            this.TextBoxJasnyZielony.TabIndex = 35;
            this.TextBoxJasnyZielony.Text = "BEZTERMINOWE";
            this.TextBoxJasnyZielony.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxJasnyZielony.UseSelectable = true;
            this.TextBoxJasnyZielony.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxJasnyZielony.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TextBoxCzarny
            // 
            // 
            // 
            // 
            this.TextBoxCzarny.CustomButton.Image = null;
            this.TextBoxCzarny.CustomButton.Location = new System.Drawing.Point(120, 1);
            this.TextBoxCzarny.CustomButton.Name = "";
            this.TextBoxCzarny.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TextBoxCzarny.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxCzarny.CustomButton.TabIndex = 1;
            this.TextBoxCzarny.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxCzarny.CustomButton.UseSelectable = true;
            this.TextBoxCzarny.CustomButton.Visible = false;
            this.TextBoxCzarny.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.TextBoxCzarny.Lines = new string[] {
        "ZADANIA PO TERMINIE"};
            this.TextBoxCzarny.Location = new System.Drawing.Point(507, 426);
            this.TextBoxCzarny.MaxLength = 32767;
            this.TextBoxCzarny.Name = "TextBoxCzarny";
            this.TextBoxCzarny.PasswordChar = '\0';
            this.TextBoxCzarny.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxCzarny.SelectedText = "";
            this.TextBoxCzarny.SelectionLength = 0;
            this.TextBoxCzarny.SelectionStart = 0;
            this.TextBoxCzarny.ShortcutsEnabled = true;
            this.TextBoxCzarny.Size = new System.Drawing.Size(142, 23);
            this.TextBoxCzarny.TabIndex = 30;
            this.TextBoxCzarny.Text = "ZADANIA PO TERMINIE";
            this.TextBoxCzarny.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TextBoxCzarny.UseSelectable = true;
            this.TextBoxCzarny.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxCzarny.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.Silver;
            this.textBox7.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textBox7.Location = new System.Drawing.Point(375, 384);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(100, 22);
            this.textBox7.TabIndex = 29;
            this.textBox7.Text = "szary";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.textBox6.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textBox6.Location = new System.Drawing.Point(375, 338);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(100, 22);
            this.textBox6.TabIndex = 28;
            this.textBox6.Text = "jasno-zielony";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.Green;
            this.textBox5.ForeColor = System.Drawing.Color.Ivory;
            this.textBox5.Location = new System.Drawing.Point(375, 278);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(100, 22);
            this.textBox5.TabIndex = 27;
            this.textBox5.Text = "zielony";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.Yellow;
            this.textBox4.ForeColor = System.Drawing.Color.Black;
            this.textBox4.Location = new System.Drawing.Point(375, 235);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 26;
            this.textBox4.Text = "żołty";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.textBox3.ForeColor = System.Drawing.SystemColors.Info;
            this.textBox3.Location = new System.Drawing.Point(375, 192);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 25;
            this.textBox3.Text = "pomarańczowy";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Red;
            this.textBox2.ForeColor = System.Drawing.SystemColors.Info;
            this.textBox2.Location = new System.Drawing.Point(375, 146);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 24;
            this.textBox2.Text = "czerwony";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textBox1.ForeColor = System.Drawing.SystemColors.Info;
            this.textBox1.Location = new System.Drawing.Point(375, 427);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 23;
            this.textBox1.Text = "czarny";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // metroLabel28
            // 
            this.metroLabel28.AutoSize = true;
            this.metroLabel28.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel28.Location = new System.Drawing.Point(397, 100);
            this.metroLabel28.Name = "metroLabel28";
            this.metroLabel28.Size = new System.Drawing.Size(54, 20);
            this.metroLabel28.TabIndex = 21;
            this.metroLabel28.Text = "KOLOR";
            // 
            // metroLabel27
            // 
            this.metroLabel27.AutoSize = true;
            this.metroLabel27.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel27.Location = new System.Drawing.Point(507, 100);
            this.metroLabel27.Name = "metroLabel27";
            this.metroLabel27.Size = new System.Drawing.Size(225, 20);
            this.metroLabel27.TabIndex = 20;
            this.metroLabel27.Text = "ILOŚĆ DNI DO KOŃCA ZADANIA";
            // 
            // metroTabPage9
            // 
            this.metroTabPage9.Controls.Add(this.ButtonZapiszWidokKolumn);
            this.metroTabPage9.Controls.Add(this.metroTextBox1);
            this.metroTabPage9.Controls.Add(this.metroCheckBox10);
            this.metroTabPage9.Controls.Add(this.metroCheckBox9);
            this.metroTabPage9.Controls.Add(this.metroCheckBox8);
            this.metroTabPage9.Controls.Add(this.metroCheckBox7);
            this.metroTabPage9.Controls.Add(this.metroCheckBox6);
            this.metroTabPage9.Controls.Add(this.metroCheckBox5);
            this.metroTabPage9.Controls.Add(this.metroCheckBox4);
            this.metroTabPage9.Controls.Add(this.metroCheckBox3);
            this.metroTabPage9.Controls.Add(this.metroCheckBox2);
            this.metroTabPage9.Controls.Add(this.metroCheckBox1);
            this.metroTabPage9.Controls.Add(this.label10);
            this.metroTabPage9.Controls.Add(this.label9);
            this.metroTabPage9.Controls.Add(this.label8);
            this.metroTabPage9.Controls.Add(this.label7);
            this.metroTabPage9.Controls.Add(this.label6);
            this.metroTabPage9.Controls.Add(this.label5);
            this.metroTabPage9.Controls.Add(this.label4);
            this.metroTabPage9.Controls.Add(this.label3);
            this.metroTabPage9.Controls.Add(this.label2);
            this.metroTabPage9.Controls.Add(this.label1);
            this.metroTabPage9.HorizontalScrollbarBarColor = true;
            this.metroTabPage9.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage9.HorizontalScrollbarSize = 10;
            this.metroTabPage9.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage9.Name = "metroTabPage9";
            this.metroTabPage9.Size = new System.Drawing.Size(1267, 549);
            this.metroTabPage9.TabIndex = 3;
            this.metroTabPage9.Text = "Widoczność Kolumn";
            this.metroTabPage9.VerticalScrollbarBarColor = true;
            this.metroTabPage9.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage9.VerticalScrollbarSize = 10;
            // 
            // ButtonZapiszWidokKolumn
            // 
            this.ButtonZapiszWidokKolumn.Location = new System.Drawing.Point(461, 274);
            this.ButtonZapiszWidokKolumn.Name = "ButtonZapiszWidokKolumn";
            this.ButtonZapiszWidokKolumn.Size = new System.Drawing.Size(75, 23);
            this.ButtonZapiszWidokKolumn.TabIndex = 24;
            this.ButtonZapiszWidokKolumn.Text = "Zapisz";
            this.ButtonZapiszWidokKolumn.UseSelectable = true;
            this.ButtonZapiszWidokKolumn.Click += new System.EventHandler(this.ButtonZapiszWidokKolumn_Click_1);
            // 
            // metroTextBox1
            // 
            // 
            // 
            // 
            this.metroTextBox1.CustomButton.Image = null;
            this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(60, 1);
            this.metroTextBox1.CustomButton.Name = "";
            this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(459, 459);
            this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox1.CustomButton.TabIndex = 1;
            this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox1.CustomButton.UseSelectable = true;
            this.metroTextBox1.CustomButton.Visible = false;
            this.metroTextBox1.Lines = new string[] {
        "metroTextBox1"};
            this.metroTextBox1.Location = new System.Drawing.Point(657, 46);
            this.metroTextBox1.MaxLength = 32767;
            this.metroTextBox1.Multiline = true;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PasswordChar = '\0';
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox1.SelectedText = "";
            this.metroTextBox1.SelectionLength = 0;
            this.metroTextBox1.SelectionStart = 0;
            this.metroTextBox1.ShortcutsEnabled = true;
            this.metroTextBox1.Size = new System.Drawing.Size(520, 461);
            this.metroTextBox1.TabIndex = 23;
            this.metroTextBox1.Text = "metroTextBox1";
            this.metroTextBox1.UseSelectable = true;
            this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroCheckBox10
            // 
            this.metroCheckBox10.AutoSize = true;
            this.metroCheckBox10.Checked = true;
            this.metroCheckBox10.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroCheckBox10.Location = new System.Drawing.Point(252, 477);
            this.metroCheckBox10.MinimumSize = new System.Drawing.Size(0, 30);
            this.metroCheckBox10.Name = "metroCheckBox10";
            this.metroCheckBox10.Size = new System.Drawing.Size(16, 30);
            this.metroCheckBox10.TabIndex = 22;
            this.metroCheckBox10.UseSelectable = true;
            this.metroCheckBox10.CheckedChanged += new System.EventHandler(this.metroCheckBox10_CheckedChanged);
            // 
            // metroCheckBox9
            // 
            this.metroCheckBox9.AutoSize = true;
            this.metroCheckBox9.Checked = true;
            this.metroCheckBox9.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroCheckBox9.Location = new System.Drawing.Point(252, 424);
            this.metroCheckBox9.MinimumSize = new System.Drawing.Size(0, 30);
            this.metroCheckBox9.Name = "metroCheckBox9";
            this.metroCheckBox9.Size = new System.Drawing.Size(16, 30);
            this.metroCheckBox9.TabIndex = 21;
            this.metroCheckBox9.UseSelectable = true;
            this.metroCheckBox9.CheckedChanged += new System.EventHandler(this.metroCheckBox9_CheckedChanged);
            // 
            // metroCheckBox8
            // 
            this.metroCheckBox8.AutoSize = true;
            this.metroCheckBox8.Checked = true;
            this.metroCheckBox8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroCheckBox8.Location = new System.Drawing.Point(252, 373);
            this.metroCheckBox8.MinimumSize = new System.Drawing.Size(0, 30);
            this.metroCheckBox8.Name = "metroCheckBox8";
            this.metroCheckBox8.Size = new System.Drawing.Size(16, 30);
            this.metroCheckBox8.TabIndex = 20;
            this.metroCheckBox8.UseSelectable = true;
            this.metroCheckBox8.CheckedChanged += new System.EventHandler(this.metroCheckBox8_CheckedChanged);
            // 
            // metroCheckBox7
            // 
            this.metroCheckBox7.AutoSize = true;
            this.metroCheckBox7.Checked = true;
            this.metroCheckBox7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroCheckBox7.Location = new System.Drawing.Point(252, 318);
            this.metroCheckBox7.MinimumSize = new System.Drawing.Size(0, 30);
            this.metroCheckBox7.Name = "metroCheckBox7";
            this.metroCheckBox7.Size = new System.Drawing.Size(16, 30);
            this.metroCheckBox7.TabIndex = 19;
            this.metroCheckBox7.UseSelectable = true;
            this.metroCheckBox7.CheckedChanged += new System.EventHandler(this.metroCheckBox7_CheckedChanged);
            // 
            // metroCheckBox6
            // 
            this.metroCheckBox6.AutoSize = true;
            this.metroCheckBox6.Checked = true;
            this.metroCheckBox6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroCheckBox6.Location = new System.Drawing.Point(252, 267);
            this.metroCheckBox6.MinimumSize = new System.Drawing.Size(0, 30);
            this.metroCheckBox6.Name = "metroCheckBox6";
            this.metroCheckBox6.Size = new System.Drawing.Size(16, 30);
            this.metroCheckBox6.TabIndex = 18;
            this.metroCheckBox6.UseSelectable = true;
            this.metroCheckBox6.CheckedChanged += new System.EventHandler(this.metroCheckBox6_CheckedChanged);
            // 
            // metroCheckBox5
            // 
            this.metroCheckBox5.AutoSize = true;
            this.metroCheckBox5.Checked = true;
            this.metroCheckBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroCheckBox5.Location = new System.Drawing.Point(252, 216);
            this.metroCheckBox5.MinimumSize = new System.Drawing.Size(0, 30);
            this.metroCheckBox5.Name = "metroCheckBox5";
            this.metroCheckBox5.Size = new System.Drawing.Size(16, 30);
            this.metroCheckBox5.TabIndex = 17;
            this.metroCheckBox5.UseSelectable = true;
            this.metroCheckBox5.CheckedChanged += new System.EventHandler(this.metroCheckBox5_CheckedChanged);
            // 
            // metroCheckBox4
            // 
            this.metroCheckBox4.AutoSize = true;
            this.metroCheckBox4.Checked = true;
            this.metroCheckBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroCheckBox4.Location = new System.Drawing.Point(252, 164);
            this.metroCheckBox4.MinimumSize = new System.Drawing.Size(0, 30);
            this.metroCheckBox4.Name = "metroCheckBox4";
            this.metroCheckBox4.Size = new System.Drawing.Size(16, 30);
            this.metroCheckBox4.TabIndex = 16;
            this.metroCheckBox4.UseSelectable = true;
            this.metroCheckBox4.CheckedChanged += new System.EventHandler(this.metroCheckBox4_CheckedChanged);
            // 
            // metroCheckBox3
            // 
            this.metroCheckBox3.AutoSize = true;
            this.metroCheckBox3.Checked = true;
            this.metroCheckBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroCheckBox3.Location = new System.Drawing.Point(252, 115);
            this.metroCheckBox3.MinimumSize = new System.Drawing.Size(0, 30);
            this.metroCheckBox3.Name = "metroCheckBox3";
            this.metroCheckBox3.Size = new System.Drawing.Size(16, 30);
            this.metroCheckBox3.TabIndex = 15;
            this.metroCheckBox3.UseSelectable = true;
            this.metroCheckBox3.CheckedChanged += new System.EventHandler(this.metroCheckBox3_CheckedChanged);
            // 
            // metroCheckBox2
            // 
            this.metroCheckBox2.AutoSize = true;
            this.metroCheckBox2.Checked = true;
            this.metroCheckBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroCheckBox2.Location = new System.Drawing.Point(252, 68);
            this.metroCheckBox2.MinimumSize = new System.Drawing.Size(0, 30);
            this.metroCheckBox2.Name = "metroCheckBox2";
            this.metroCheckBox2.Size = new System.Drawing.Size(16, 30);
            this.metroCheckBox2.TabIndex = 14;
            this.metroCheckBox2.UseSelectable = true;
            this.metroCheckBox2.CheckedChanged += new System.EventHandler(this.metroCheckBox2_CheckedChanged);
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.AutoSize = true;
            this.metroCheckBox1.Checked = true;
            this.metroCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.metroCheckBox1.Location = new System.Drawing.Point(252, 17);
            this.metroCheckBox1.MinimumSize = new System.Drawing.Size(0, 30);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Size = new System.Drawing.Size(16, 30);
            this.metroCheckBox1.TabIndex = 13;
            this.metroCheckBox1.UseSelectable = true;
            this.metroCheckBox1.CheckedChanged += new System.EventHandler(this.metroCheckBox1_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(57, 477);
            this.label10.MinimumSize = new System.Drawing.Size(30, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(179, 30);
            this.label10.TabIndex = 12;
            this.label10.Text = "DODANE PRZEZ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(3, 424);
            this.label9.MinimumSize = new System.Drawing.Size(30, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(233, 30);
            this.label9.TabIndex = 11;
            this.label9.Text = "DATA ZAKOŃCZENIA";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(134, 373);
            this.label8.MinimumSize = new System.Drawing.Size(30, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 30);
            this.label8.TabIndex = 10;
            this.label8.Text = "STATUS";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(141, 318);
            this.label7.MinimumSize = new System.Drawing.Size(30, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 30);
            this.label7.TabIndex = 9;
            this.label7.Text = "TERMIN";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(59, 267);
            this.label6.MinimumSize = new System.Drawing.Size(30, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 30);
            this.label6.TabIndex = 8;
            this.label6.Text = "DATA DODANIA";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(73, 216);
            this.label5.MinimumSize = new System.Drawing.Size(30, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 30);
            this.label5.TabIndex = 7;
            this.label5.Text = "WYKONAWCA";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(36, 164);
            this.label4.MinimumSize = new System.Drawing.Size(30, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(200, 30);
            this.label4.TabIndex = 6;
            this.label4.Text = "RODZAJ ZADANIA";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(129, 115);
            this.label3.MinimumSize = new System.Drawing.Size(30, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 30);
            this.label3.TabIndex = 5;
            this.label3.Text = "ZADANIE";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(101, 68);
            this.label2.MinimumSize = new System.Drawing.Size(30, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 30);
            this.label2.TabIndex = 4;
            this.label2.Text = "PRIORYTET";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(201, 17);
            this.label1.MinimumSize = new System.Drawing.Size(30, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroContextMenu1
            // 
            this.metroContextMenu1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.metroContextMenu1.Name = "metroContextMenu1";
            this.metroContextMenu1.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1512, 829);
            this.Controls.Add(this.metroTabControl2);
            this.Name = "Form1";
            this.metroTabControl2.ResumeLayout(false);
            this.metroTabPage3.ResumeLayout(false);
            this.metroTabPage3.PerformLayout();
            this.metroTabTaskDetails.ResumeLayout(false);
            this.metroTabPage7.ResumeLayout(false);
            this.metroTabPage7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            this.metroTabPage4.ResumeLayout(false);
            this.metroTabControl3.ResumeLayout(false);
            this.metroTabPage5.ResumeLayout(false);
            this.metroTabPage5.PerformLayout();
            this.metroTabPage6.ResumeLayout(false);
            this.metroTabPage6.PerformLayout();
            this.metroTabPage8.ResumeLayout(false);
            this.metroTabPage8.PerformLayout();
            this.metroTabPage9.ResumeLayout(false);
            this.metroTabPage9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroTabControl metroTabControl2;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroComboBox ComboBoxSortowanie;
        private MetroFramework.Controls.MetroTabControl metroTabTaskDetails;
        private MetroFramework.Controls.MetroTabPage metroTabPage7;
        private MetroFramework.Controls.MetroButton ButtonEditTask;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox ComboBoxDetailsWykonawcy;
        private MetroFramework.Controls.MetroTextBox TextBoxDetailsZadanie;
        private MetroFramework.Controls.MetroTextBox TextBoxDetailsOpis;
        private MetroFramework.Controls.MetroTextBox TextBoxSzukanaFraza;
        private MetroFramework.Controls.MetroButton ButtonNewTask;
        private System.Windows.Forms.DataGridViewTextBoxColumn priotytet;
        private System.Windows.Forms.DataGridViewTextBoxColumn zadanie;
        private System.Windows.Forms.DataGridViewTextBoxColumn rodzaj;
        private System.Windows.Forms.DataGridViewTextBoxColumn wykonawca;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataD;
        private System.Windows.Forms.DataGridViewCheckBoxColumn status1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataW;
        private MetroFramework.Controls.MetroTabPage metroTabPage4;
        private MetroFramework.Controls.MetroTabControl metroTabControl3;
        private MetroFramework.Controls.MetroTabPage metroTabPage5;
        private MetroFramework.Controls.MetroButton ButtonLogowanie;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroTextBox TextBoxUserName;
        private MetroFramework.Controls.MetroTabPage metroTabPage6;
        private MetroFramework.Controls.MetroTextBox TextBoxDBPassword;
        private MetroFramework.Controls.MetroTextBox TextBoxDBUser;
        private MetroFramework.Controls.MetroTextBox TextBoxDBName;
        private MetroFramework.Controls.MetroTextBox TextBoxServerID;
        private MetroFramework.Controls.MetroButton ButtonSaveDB;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroTextBox TextBoxAddUser;
        private MetroFramework.Controls.MetroButton ButtonDodajUzytkownika;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroTextBox TextBoxUsersList;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroTextBox TextBoxDBTesting;
        private MetroFramework.Controls.MetroTextBox TextBoxDBinfo;
        private MetroFramework.Controls.MetroButton ButtonUsunZadanie;
        private MetroFramework.Controls.MetroTextBox TextBoxDetailsWykonawca;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroLabel metroLabel13;
        private MetroFramework.Controls.MetroTextBox TextBoxDetailsDodanePrzez;
        private MetroFramework.Controls.MetroTextBox TextBoxDetailsDataZak;
        private MetroFramework.Controls.MetroTextBox TextBoxDetailsDataDod;
        private MetroFramework.Controls.MetroLabel metroLabel14;
        private MetroFramework.Controls.MetroLabel metroLabel15;
        private MetroFramework.Controls.MetroLabel metroLabel16;
        private MetroFramework.Controls.MetroTextBox TextBoxDetailsStatus;
        private MetroFramework.Controls.MetroLabel metroLabel18;
        private MetroFramework.Controls.MetroTextBox TextBoxDetailsRodzaj;
        private MetroFramework.Controls.MetroLabel metroLabel17;
        private MetroFramework.Controls.MetroTextBox TextBoxDetailsPriorytet;
        private MetroFramework.Controls.MetroLabel metroLabel19;
        private MetroFramework.Controls.MetroComboBox ComboBoxDetailsZmienPriorytet;
        private MetroFramework.Controls.MetroLabel metroLabel20;
        private MetroFramework.Controls.MetroContextMenu metroContextMenu1;
        public MetroFramework.Controls.MetroTextBox TextBoxDetailsID;
        private MetroFramework.Controls.MetroTextBox TextBoxDetailsTerm;
        private MetroFramework.Controls.MetroLabel metroLabel21;
        public MetroFramework.Controls.MetroGrid metroGrid1;
        private MetroFramework.Controls.MetroCheckBox CheckBoxMalejaco;
        private MetroFramework.Controls.MetroCheckBox CheckBoxRosnaco;
        private MetroFramework.Controls.MetroComboBox ComboBoxKolumnaSzukania;
        private MetroFramework.Controls.MetroLabel metroLabel23;
        private MetroFramework.Controls.MetroLabel metroLabel22;
        private MetroFramework.Controls.MetroLabel metroLabel26;
        private MetroFramework.Controls.MetroLabel metroLabel25;
        private MetroFramework.Controls.MetroLabel metroLabel24;
        public MetroFramework.Controls.MetroComboBox ComboBoxStatus;
        public MetroFramework.Controls.MetroComboBox ComboBoxWykonawcy;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn priorytet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Zad;
        private System.Windows.Forms.DataGridViewTextBoxColumn rodzaj_zad;
        private System.Windows.Forms.DataGridViewTextBoxColumn dla_kogo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dodanie;
        private System.Windows.Forms.DataGridViewTextBoxColumn termin;
        private System.Windows.Forms.DataGridViewCheckBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn zakonczenie;
        private System.Windows.Forms.DataGridViewTextBoxColumn dodal;
        private System.Windows.Forms.TextBox textBoxIle_dni_do_konca_zadania;
        private MetroFramework.Controls.MetroTabPage metroTabPage8;
        private MetroFramework.Controls.MetroLabel metroLabel30;
        private MetroFramework.Controls.MetroTextBox TextBoxSzary;
        private MetroFramework.Controls.MetroTextBox TextBoxJasnyZielony;
        private MetroFramework.Controls.MetroTextBox TextBoxCzarny;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private MetroFramework.Controls.MetroLabel metroLabel28;
        private MetroFramework.Controls.MetroLabel metroLabel27;
        private MetroFramework.Controls.MetroTextBox TxtBoxGreen;
        private MetroFramework.Controls.MetroTextBox TxtBoxYellow;
        private MetroFramework.Controls.MetroTextBox TxtBoxOrange;
        private MetroFramework.Controls.MetroTextBox TxtBoxRed;
        public MetroFramework.Controls.MetroDateTime DateTimeZakresDatDo;
        public MetroFramework.Controls.MetroDateTime DateTimeZakresDatOd;
        private MetroFramework.Controls.MetroTabPage metroTabPage9;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox10;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox9;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox8;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox7;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox6;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox5;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox4;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox3;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox2;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox1;
        private System.Windows.Forms.Label label10;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private MetroFramework.Controls.MetroLabel metroLabel29;
        private MetroFramework.Controls.MetroButton ButtonZapiszWidokKolumn;
    }
}

