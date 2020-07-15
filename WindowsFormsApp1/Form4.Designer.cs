namespace WindowsFormsApp1
{
    partial class Form4
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
            this.DateTimeOD = new MetroFramework.Controls.MetroDateTime();
            this.DateTimeDO = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.ComboBoxWykonawcy = new MetroFramework.Controls.MetroComboBox();
            this.btnGenerujPDF = new MetroFramework.Controls.MetroButton();
            this.ButtonLokalizacja = new MetroFramework.Controls.MetroButton();
            this.CheckBoxZapiszLokalizacje = new MetroFramework.Controls.MetroCheckBox();
            this.CheckBoxOtworzPDF = new MetroFramework.Controls.MetroCheckBox();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.metroTile7 = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(75, 89);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(120, 25);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "ZAKRES DAT:";
            // 
            // DateTimeOD
            // 
            this.DateTimeOD.Location = new System.Drawing.Point(133, 130);
            this.DateTimeOD.MinimumSize = new System.Drawing.Size(0, 30);
            this.DateTimeOD.Name = "DateTimeOD";
            this.DateTimeOD.Size = new System.Drawing.Size(278, 30);
            this.DateTimeOD.TabIndex = 1;
            // 
            // DateTimeDO
            // 
            this.DateTimeDO.Location = new System.Drawing.Point(490, 130);
            this.DateTimeDO.MinimumSize = new System.Drawing.Size(0, 30);
            this.DateTimeDO.Name = "DateTimeDO";
            this.DateTimeDO.Size = new System.Drawing.Size(278, 30);
            this.DateTimeDO.TabIndex = 2;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(78, 130);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(39, 25);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "OD";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(433, 130);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(39, 25);
            this.metroLabel3.TabIndex = 4;
            this.metroLabel3.Text = "DO";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(75, 190);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(193, 25);
            this.metroLabel4.TabIndex = 5;
            this.metroLabel4.Text = "Zadania użytkownika:";
            // 
            // ComboBoxWykonawcy
            // 
            this.ComboBoxWykonawcy.FormattingEnabled = true;
            this.ComboBoxWykonawcy.ItemHeight = 24;
            this.ComboBoxWykonawcy.Location = new System.Drawing.Point(75, 240);
            this.ComboBoxWykonawcy.Name = "ComboBoxWykonawcy";
            this.ComboBoxWykonawcy.Size = new System.Drawing.Size(182, 30);
            this.ComboBoxWykonawcy.TabIndex = 6;
            this.ComboBoxWykonawcy.UseSelectable = true;
            // 
            // btnGenerujPDF
            // 
            this.btnGenerujPDF.Location = new System.Drawing.Point(79, 365);
            this.btnGenerujPDF.Name = "btnGenerujPDF";
            this.btnGenerujPDF.Size = new System.Drawing.Size(105, 43);
            this.btnGenerujPDF.TabIndex = 7;
            this.btnGenerujPDF.Text = "Generuj PDF";
            this.btnGenerujPDF.UseSelectable = true;
            this.btnGenerujPDF.Click += new System.EventHandler(this.btnGenerujPDF_Click);
            // 
            // ButtonLokalizacja
            // 
            this.ButtonLokalizacja.Location = new System.Drawing.Point(75, 292);
            this.ButtonLokalizacja.Name = "ButtonLokalizacja";
            this.ButtonLokalizacja.Size = new System.Drawing.Size(273, 39);
            this.ButtonLokalizacja.TabIndex = 9;
            this.ButtonLokalizacja.Text = "miejsce zapisu pliku";
            this.ButtonLokalizacja.UseSelectable = true;
            this.ButtonLokalizacja.Click += new System.EventHandler(this.ButtonLokalizacja_Click_1);
            // 
            // CheckBoxZapiszLokalizacje
            // 
            this.CheckBoxZapiszLokalizacje.AutoSize = true;
            this.CheckBoxZapiszLokalizacje.Location = new System.Drawing.Point(378, 301);
            this.CheckBoxZapiszLokalizacje.Name = "CheckBoxZapiszLokalizacje";
            this.CheckBoxZapiszLokalizacje.Size = new System.Drawing.Size(195, 17);
            this.CheckBoxZapiszLokalizacje.Style = MetroFramework.MetroColorStyle.Orange;
            this.CheckBoxZapiszLokalizacje.TabIndex = 10;
            this.CheckBoxZapiszLokalizacje.Text = "zapisz jako miejsce docelowe";
            this.CheckBoxZapiszLokalizacje.UseSelectable = true;
            this.CheckBoxZapiszLokalizacje.CheckedChanged += new System.EventHandler(this.CheckBoxZapiszLokalizacje_CheckedChanged);
            // 
            // CheckBoxOtworzPDF
            // 
            this.CheckBoxOtworzPDF.AutoSize = true;
            this.CheckBoxOtworzPDF.Location = new System.Drawing.Point(213, 376);
            this.CheckBoxOtworzPDF.Name = "CheckBoxOtworzPDF";
            this.CheckBoxOtworzPDF.Size = new System.Drawing.Size(177, 17);
            this.CheckBoxOtworzPDF.Style = MetroFramework.MetroColorStyle.Orange;
            this.CheckBoxOtworzPDF.TabIndex = 11;
            this.CheckBoxOtworzPDF.Text = "otwórz PDF po utworzeniu";
            this.CheckBoxOtworzPDF.UseSelectable = true;
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Enabled = false;
            this.metroTile1.Location = new System.Drawing.Point(79, 361);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(105, 23);
            this.metroTile1.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroTile1.TabIndex = 12;
            this.metroTile1.UseSelectable = true;
            // 
            // metroTile7
            // 
            this.metroTile7.ActiveControl = null;
            this.metroTile7.Enabled = false;
            this.metroTile7.Location = new System.Drawing.Point(75, 288);
            this.metroTile7.Name = "metroTile7";
            this.metroTile7.Size = new System.Drawing.Size(273, 30);
            this.metroTile7.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroTile7.TabIndex = 34;
            this.metroTile7.UseSelectable = true;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CheckBoxOtworzPDF);
            this.Controls.Add(this.CheckBoxZapiszLokalizacje);
            this.Controls.Add(this.ButtonLokalizacja);
            this.Controls.Add(this.btnGenerujPDF);
            this.Controls.Add(this.ComboBoxWykonawcy);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.DateTimeDO);
            this.Controls.Add(this.DateTimeOD);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroTile1);
            this.Controls.Add(this.metroTile7);
            this.Name = "Form4";
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "Generuj PDF";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroDateTime DateTimeOD;
        private MetroFramework.Controls.MetroDateTime DateTimeDO;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroComboBox ComboBoxWykonawcy;
        private MetroFramework.Controls.MetroButton btnGenerujPDF;
        private MetroFramework.Controls.MetroButton ButtonLokalizacja;
        private MetroFramework.Controls.MetroCheckBox CheckBoxZapiszLokalizacje;
        private MetroFramework.Controls.MetroCheckBox CheckBoxOtworzPDF;
        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroTile metroTile7;
    }
}