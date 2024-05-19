namespace GaragedbAPP
{
    partial class FormModifica
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
            marca = new Label();
            tipo = new Label();
            dataImmatricolazione = new Label();
            textBoxMarca = new TextBox();
            textBoxTipo = new TextBox();
            textBoxDataImmatricolazione = new TextBox();
            saveButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // marca
            // 
            marca.AutoSize = true;
            marca.Location = new Point(122, 48);
            marca.Name = "marca";
            marca.Size = new Size(50, 20);
            marca.TabIndex = 0;
            marca.Text = "Marca";
            // 
            // tipo
            // 
            tipo.AutoSize = true;
            tipo.Location = new Point(122, 131);
            tipo.Name = "tipo";
            tipo.Size = new Size(39, 20);
            tipo.TabIndex = 1;
            tipo.Text = "Tipo";
            // 
            // dataImmatricolazione
            // 
            dataImmatricolazione.AutoSize = true;
            dataImmatricolazione.Location = new Point(12, 226);
            dataImmatricolazione.Name = "dataImmatricolazione";
            dataImmatricolazione.Size = new Size(178, 20);
            dataImmatricolazione.TabIndex = 2;
            dataImmatricolazione.Text = "Data di Immatricolazione";
            // 
            // textBoxMarca
            // 
            textBoxMarca.Location = new Point(196, 45);
            textBoxMarca.Name = "textBoxMarca";
            textBoxMarca.Size = new Size(129, 27);
            textBoxMarca.TabIndex = 3;
            // 
            // textBoxTipo
            // 
            textBoxTipo.Location = new Point(196, 128);
            textBoxTipo.Name = "textBoxTipo";
            textBoxTipo.Size = new Size(129, 27);
            textBoxTipo.TabIndex = 4;
            // 
            // textBoxDataImmatricolazione
            // 
            textBoxDataImmatricolazione.Location = new Point(196, 223);
            textBoxDataImmatricolazione.Name = "textBoxDataImmatricolazione";
            textBoxDataImmatricolazione.Size = new Size(129, 27);
            textBoxDataImmatricolazione.TabIndex = 5;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(292, 289);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(116, 35);
            saveButton.TabIndex = 6;
            saveButton.Text = "Salva";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(133, 289);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(116, 35);
            cancelButton.TabIndex = 7;
            cancelButton.Text = "Annulla";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // FormModifica
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(529, 345);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(textBoxDataImmatricolazione);
            Controls.Add(textBoxTipo);
            Controls.Add(textBoxMarca);
            Controls.Add(dataImmatricolazione);
            Controls.Add(tipo);
            Controls.Add(marca);
            Name = "FormModifica";
            Text = "Modifica";
            Load += FormModifica_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label marca;
        private Label tipo;
        private Label dataImmatricolazione;
        private TextBox textBoxMarca;
        private TextBox textBoxTipo;
        private TextBox textBoxDataImmatricolazione;
        private Button saveButton;
        private Button cancelButton;
    }
}