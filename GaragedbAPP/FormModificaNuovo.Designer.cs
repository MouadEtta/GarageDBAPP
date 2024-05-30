namespace GaragedbAPP
{
    partial class FormModificaNuovo
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
            textBoxTarga = new TextBox();
            textBoxDataImmatricolazione = new TextBox();
            targaLabel = new Label();
            marcaLabel = new Label();
            tipoLabel = new Label();
            dataImmatricolazioneLabel = new Label();
            buttonCancel = new Button();
            buttonAdd = new Button();
            comboBoxMarca = new ComboBox();
            comboBoxTipo = new ComboBox();
            SuspendLayout();
            // 
            // textBoxTarga
            // 
            textBoxTarga.Location = new Point(95, 124);
            textBoxTarga.Name = "textBoxTarga";
            textBoxTarga.Size = new Size(164, 27);
            textBoxTarga.TabIndex = 0;
            // 
            // textBoxDataImmatricolazione
            // 
            textBoxDataImmatricolazione.Location = new Point(453, 283);
            textBoxDataImmatricolazione.Name = "textBoxDataImmatricolazione";
            textBoxDataImmatricolazione.Size = new Size(211, 27);
            textBoxDataImmatricolazione.TabIndex = 4;
            // 
            // targaLabel
            // 
            targaLabel.AutoSize = true;
            targaLabel.Location = new Point(137, 91);
            targaLabel.Name = "targaLabel";
            targaLabel.Size = new Size(45, 20);
            targaLabel.TabIndex = 4;
            targaLabel.Text = "Targa";
            // 
            // marcaLabel
            // 
            marcaLabel.AutoSize = true;
            marcaLabel.Location = new Point(482, 91);
            marcaLabel.Name = "marcaLabel";
            marcaLabel.Size = new Size(50, 20);
            marcaLabel.TabIndex = 5;
            marcaLabel.Text = "Marca";
            // 
            // tipoLabel
            // 
            tipoLabel.AutoSize = true;
            tipoLabel.Location = new Point(132, 251);
            tipoLabel.Name = "tipoLabel";
            tipoLabel.Size = new Size(39, 20);
            tipoLabel.TabIndex = 6;
            tipoLabel.Text = "Tipo";
            // 
            // dataImmatricolazioneLabel
            // 
            dataImmatricolazioneLabel.AutoSize = true;
            dataImmatricolazioneLabel.Location = new Point(472, 251);
            dataImmatricolazioneLabel.Name = "dataImmatricolazioneLabel";
            dataImmatricolazioneLabel.Size = new Size(161, 20);
            dataImmatricolazioneLabel.TabIndex = 7;
            dataImmatricolazioneLabel.Text = "Data Immatricolazione";
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(181, 376);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(159, 33);
            buttonCancel.TabIndex = 8;
            buttonCancel.Text = "Annulla";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(453, 376);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(159, 33);
            buttonAdd.TabIndex = 9;
            buttonAdd.Text = "Aggiungi";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // comboBoxMarca
            // 
            comboBoxMarca.FormattingEnabled = true;
            comboBoxMarca.Location = new Point(453, 123);
            comboBoxMarca.Name = "comboBoxMarca";
            comboBoxMarca.Size = new Size(151, 28);
            comboBoxMarca.TabIndex = 10;
            comboBoxMarca.SelectedIndexChanged += comboBoxMarca_SelectedIndexChanged;
            // 
            // comboBoxTipo
            // 
            comboBoxTipo.FormattingEnabled = true;
            comboBoxTipo.Location = new Point(108, 283);
            comboBoxTipo.Name = "comboBoxTipo";
            comboBoxTipo.Size = new Size(151, 28);
            comboBoxTipo.TabIndex = 11;
            // 
            // FormNuovo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboBoxTipo);
            Controls.Add(comboBoxMarca);
            Controls.Add(buttonAdd);
            Controls.Add(buttonCancel);
            Controls.Add(dataImmatricolazioneLabel);
            Controls.Add(tipoLabel);
            Controls.Add(marcaLabel);
            Controls.Add(targaLabel);
            Controls.Add(textBoxDataImmatricolazione);
            Controls.Add(textBoxTarga);
            Name = "FormNuovo";
            Text = "FormNuovo";
            Load += FormNuovo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxTarga;
        private TextBox textBoxDataImmatricolazione;
        private Label targaLabel;
        private Label marcaLabel;
        private Label tipoLabel;
        private Label dataImmatricolazioneLabel;
        private Button buttonCancel;
        private Button buttonAdd;
        private ComboBox comboBoxMarca;
        private ComboBox comboBoxTipo;
    }
}