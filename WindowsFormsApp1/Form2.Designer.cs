namespace WindowsFormsApp1
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.ComboBoxPriorytet = new MetroFramework.Controls.MetroComboBox();
            this.TextBoxOpisZadania = new MetroFramework.Controls.MetroTextBox();
            this.TextBoxTytulZadania = new MetroFramework.Controls.MetroTextBox();
            this.TextBoxRodzajZadania = new MetroFramework.Controls.MetroTextBox();
            this.ButtonDodajZadanie = new MetroFramework.Controls.MetroButton();
            this.ComboBoxRodzajZadania = new MetroFramework.Controls.MetroComboBox();
            this.CheckBoxInnyRodzaj = new MetroFramework.Controls.MetroCheckBox();
            this.ComboBoxWykonawca = new MetroFramework.Controls.MetroComboBox();
            this.dateTimePickerData = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTime = new System.Windows.Forms.DateTimePicker();
            this.ButtonDodajKolejne = new MetroFramework.Controls.MetroButton();
            this.CheckBoxTermin = new MetroFramework.Controls.MetroCheckBox();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(58, 107);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(62, 20);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "priorytet";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(63, 169);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(57, 20);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "zadanie";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(18, 246);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(98, 20);
            this.metroLabel3.TabIndex = 2;
            this.metroLabel3.Text = "rodzaj zadania";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(36, 311);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(80, 20);
            this.metroLabel4.TabIndex = 3;
            this.metroLabel4.Text = "wykonawca";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(72, 374);
            this.metroLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(49, 20);
            this.metroLabel5.TabIndex = 4;
            this.metroLabel5.Text = "termin";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(708, 107);
            this.metroLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(34, 20);
            this.metroLabel6.TabIndex = 5;
            this.metroLabel6.Text = "opis";
            // 
            // ComboBoxPriorytet
            // 
            this.ComboBoxPriorytet.FormattingEnabled = true;
            this.ComboBoxPriorytet.ItemHeight = 24;
            this.ComboBoxPriorytet.Items.AddRange(new object[] {
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
            this.ComboBoxPriorytet.Location = new System.Drawing.Point(173, 107);
            this.ComboBoxPriorytet.Margin = new System.Windows.Forms.Padding(4);
            this.ComboBoxPriorytet.Name = "ComboBoxPriorytet";
            this.ComboBoxPriorytet.Size = new System.Drawing.Size(160, 30);
            this.ComboBoxPriorytet.TabIndex = 6;
            this.ComboBoxPriorytet.UseSelectable = true;
            // 
            // TextBoxOpisZadania
            // 
            // 
            // 
            // 
            this.TextBoxOpisZadania.CustomButton.Image = null;
            this.TextBoxOpisZadania.CustomButton.Location = new System.Drawing.Point(-28, 1);
            this.TextBoxOpisZadania.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxOpisZadania.CustomButton.Name = "";
            this.TextBoxOpisZadania.CustomButton.Size = new System.Drawing.Size(327, 327);
            this.TextBoxOpisZadania.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxOpisZadania.CustomButton.TabIndex = 1;
            this.TextBoxOpisZadania.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxOpisZadania.CustomButton.UseSelectable = true;
            this.TextBoxOpisZadania.CustomButton.Visible = false;
            this.TextBoxOpisZadania.Lines = new string[0];
            this.TextBoxOpisZadania.Location = new System.Drawing.Point(759, 107);
            this.TextBoxOpisZadania.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxOpisZadania.MaxLength = 32767;
            this.TextBoxOpisZadania.Multiline = true;
            this.TextBoxOpisZadania.Name = "TextBoxOpisZadania";
            this.TextBoxOpisZadania.PasswordChar = '\0';
            this.TextBoxOpisZadania.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxOpisZadania.SelectedText = "";
            this.TextBoxOpisZadania.SelectionLength = 0;
            this.TextBoxOpisZadania.SelectionStart = 0;
            this.TextBoxOpisZadania.ShortcutsEnabled = true;
            this.TextBoxOpisZadania.Size = new System.Drawing.Size(300, 329);
            this.TextBoxOpisZadania.TabIndex = 7;
            this.TextBoxOpisZadania.UseSelectable = true;
            this.TextBoxOpisZadania.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxOpisZadania.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TextBoxTytulZadania
            // 
            // 
            // 
            // 
            this.TextBoxTytulZadania.CustomButton.Image = null;
            this.TextBoxTytulZadania.CustomButton.Location = new System.Drawing.Point(430, 2);
            this.TextBoxTytulZadania.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxTytulZadania.CustomButton.Name = "";
            this.TextBoxTytulZadania.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.TextBoxTytulZadania.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxTytulZadania.CustomButton.TabIndex = 1;
            this.TextBoxTytulZadania.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxTytulZadania.CustomButton.UseSelectable = true;
            this.TextBoxTytulZadania.CustomButton.Visible = false;
            this.TextBoxTytulZadania.Lines = new string[0];
            this.TextBoxTytulZadania.Location = new System.Drawing.Point(173, 169);
            this.TextBoxTytulZadania.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxTytulZadania.MaxLength = 32767;
            this.TextBoxTytulZadania.Multiline = true;
            this.TextBoxTytulZadania.Name = "TextBoxTytulZadania";
            this.TextBoxTytulZadania.PasswordChar = '\0';
            this.TextBoxTytulZadania.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxTytulZadania.SelectedText = "";
            this.TextBoxTytulZadania.SelectionLength = 0;
            this.TextBoxTytulZadania.SelectionStart = 0;
            this.TextBoxTytulZadania.ShortcutsEnabled = true;
            this.TextBoxTytulZadania.Size = new System.Drawing.Size(464, 36);
            this.TextBoxTytulZadania.TabIndex = 8;
            this.TextBoxTytulZadania.UseSelectable = true;
            this.TextBoxTytulZadania.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxTytulZadania.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TextBoxRodzajZadania
            // 
            // 
            // 
            // 
            this.TextBoxRodzajZadania.CustomButton.Image = null;
            this.TextBoxRodzajZadania.CustomButton.Location = new System.Drawing.Point(149, 2);
            this.TextBoxRodzajZadania.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxRodzajZadania.CustomButton.Name = "";
            this.TextBoxRodzajZadania.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.TextBoxRodzajZadania.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextBoxRodzajZadania.CustomButton.TabIndex = 1;
            this.TextBoxRodzajZadania.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextBoxRodzajZadania.CustomButton.UseSelectable = true;
            this.TextBoxRodzajZadania.CustomButton.Visible = false;
            this.TextBoxRodzajZadania.Lines = new string[0];
            this.TextBoxRodzajZadania.Location = new System.Drawing.Point(399, 246);
            this.TextBoxRodzajZadania.Margin = new System.Windows.Forms.Padding(4);
            this.TextBoxRodzajZadania.MaxLength = 32767;
            this.TextBoxRodzajZadania.Name = "TextBoxRodzajZadania";
            this.TextBoxRodzajZadania.PasswordChar = '\0';
            this.TextBoxRodzajZadania.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TextBoxRodzajZadania.SelectedText = "";
            this.TextBoxRodzajZadania.SelectionLength = 0;
            this.TextBoxRodzajZadania.SelectionStart = 0;
            this.TextBoxRodzajZadania.ShortcutsEnabled = true;
            this.TextBoxRodzajZadania.Size = new System.Drawing.Size(183, 36);
            this.TextBoxRodzajZadania.TabIndex = 9;
            this.TextBoxRodzajZadania.UseSelectable = true;
            this.TextBoxRodzajZadania.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextBoxRodzajZadania.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // ButtonDodajZadanie
            // 
            this.ButtonDodajZadanie.Location = new System.Drawing.Point(320, 532);
            this.ButtonDodajZadanie.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonDodajZadanie.Name = "ButtonDodajZadanie";
            this.ButtonDodajZadanie.Size = new System.Drawing.Size(183, 52);
            this.ButtonDodajZadanie.TabIndex = 12;
            this.ButtonDodajZadanie.Text = "Dodaj zadanie";
            this.ButtonDodajZadanie.UseSelectable = true;
            this.ButtonDodajZadanie.Click += new System.EventHandler(this.ButtonDodajZadanie_Click);
            // 
            // ComboBoxRodzajZadania
            // 
            this.ComboBoxRodzajZadania.FormattingEnabled = true;
            this.ComboBoxRodzajZadania.ItemHeight = 24;
            this.ComboBoxRodzajZadania.Location = new System.Drawing.Point(173, 246);
            this.ComboBoxRodzajZadania.Name = "ComboBoxRodzajZadania";
            this.ComboBoxRodzajZadania.Size = new System.Drawing.Size(160, 30);
            this.ComboBoxRodzajZadania.TabIndex = 14;
            this.ComboBoxRodzajZadania.UseSelectable = true;
            // 
            // CheckBoxInnyRodzaj
            // 
            this.CheckBoxInnyRodzaj.AutoSize = true;
            this.CheckBoxInnyRodzaj.Location = new System.Drawing.Point(413, 222);
            this.CheckBoxInnyRodzaj.Name = "CheckBoxInnyRodzaj";
            this.CheckBoxInnyRodzaj.Size = new System.Drawing.Size(50, 17);
            this.CheckBoxInnyRodzaj.TabIndex = 15;
            this.CheckBoxInnyRodzaj.Text = "inny:";
            this.CheckBoxInnyRodzaj.UseSelectable = true;
            // 
            // ComboBoxWykonawca
            // 
            this.ComboBoxWykonawca.FormattingEnabled = true;
            this.ComboBoxWykonawca.ItemHeight = 24;
            this.ComboBoxWykonawca.Location = new System.Drawing.Point(173, 311);
            this.ComboBoxWykonawca.Name = "ComboBoxWykonawca";
            this.ComboBoxWykonawca.Size = new System.Drawing.Size(160, 30);
            this.ComboBoxWykonawca.TabIndex = 16;
            this.ComboBoxWykonawca.UseSelectable = true;
            // 
            // dateTimePickerData
            // 
            this.dateTimePickerData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerData.Location = new System.Drawing.Point(269, 377);
            this.dateTimePickerData.Name = "dateTimePickerData";
            this.dateTimePickerData.Size = new System.Drawing.Size(121, 22);
            this.dateTimePickerData.TabIndex = 17;
            this.dateTimePickerData.Visible = false;
            // 
            // dateTimePickerTime
            // 
            this.dateTimePickerTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerTime.Location = new System.Drawing.Point(413, 377);
            this.dateTimePickerTime.Name = "dateTimePickerTime";
            this.dateTimePickerTime.ShowUpDown = true;
            this.dateTimePickerTime.Size = new System.Drawing.Size(84, 22);
            this.dateTimePickerTime.TabIndex = 18;
            this.dateTimePickerTime.Visible = false;
            // 
            // ButtonDodajKolejne
            // 
            this.ButtonDodajKolejne.Location = new System.Drawing.Point(568, 532);
            this.ButtonDodajKolejne.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonDodajKolejne.Name = "ButtonDodajKolejne";
            this.ButtonDodajKolejne.Size = new System.Drawing.Size(183, 52);
            this.ButtonDodajKolejne.TabIndex = 19;
            this.ButtonDodajKolejne.Text = "Dodaj kolejne zadanie";
            this.ButtonDodajKolejne.UseSelectable = true;
            this.ButtonDodajKolejne.Click += new System.EventHandler(this.ButtonDodajKolejne_Click);
            // 
            // CheckBoxTermin
            // 
            this.CheckBoxTermin.AutoSize = true;
            this.CheckBoxTermin.Location = new System.Drawing.Point(147, 377);
            this.CheckBoxTermin.Name = "CheckBoxTermin";
            this.CheckBoxTermin.Size = new System.Drawing.Size(68, 17);
            this.CheckBoxTermin.TabIndex = 20;
            this.CheckBoxTermin.Text = "wybierz";
            this.CheckBoxTermin.UseSelectable = true;
            this.CheckBoxTermin.CheckedChanged += new System.EventHandler(this.CheckBoxTermin_CheckedChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 716);
            this.Controls.Add(this.CheckBoxTermin);
            this.Controls.Add(this.ButtonDodajKolejne);
            this.Controls.Add(this.dateTimePickerTime);
            this.Controls.Add(this.dateTimePickerData);
            this.Controls.Add(this.ComboBoxWykonawca);
            this.Controls.Add(this.CheckBoxInnyRodzaj);
            this.Controls.Add(this.ComboBoxRodzajZadania);
            this.Controls.Add(this.ButtonDodajZadanie);
            this.Controls.Add(this.TextBoxRodzajZadania);
            this.Controls.Add(this.TextBoxTytulZadania);
            this.Controls.Add(this.TextBoxOpisZadania);
            this.Controls.Add(this.ComboBoxPriorytet);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form2";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Text = "Nowe zadanie";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroComboBox ComboBoxPriorytet;
        private MetroFramework.Controls.MetroTextBox TextBoxOpisZadania;
        private MetroFramework.Controls.MetroTextBox TextBoxTytulZadania;
        private MetroFramework.Controls.MetroTextBox TextBoxRodzajZadania;
        private MetroFramework.Controls.MetroButton ButtonDodajZadanie;
        private MetroFramework.Controls.MetroComboBox ComboBoxRodzajZadania;
        private MetroFramework.Controls.MetroCheckBox CheckBoxInnyRodzaj;
        private MetroFramework.Controls.MetroComboBox ComboBoxWykonawca;
        private System.Windows.Forms.DateTimePicker dateTimePickerData;
        private System.Windows.Forms.DateTimePicker dateTimePickerTime;
        private MetroFramework.Controls.MetroButton ButtonDodajKolejne;
        private MetroFramework.Controls.MetroCheckBox CheckBoxTermin;
    }
}