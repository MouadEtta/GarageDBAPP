using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace GaragedbAPP
{
    public partial class FormModifica : Form
    {
        // Definisce l'evento CarNew che aggiornerà la tabella 
        public event EventHandler CarEdit;
        public Car car { get; set; }
        public FormModifica(Car car)
        {
            this.car = car;
            InitializeComponent();
        }
        //inserisco nelle textbox i valori della riga da modificare
        private void FormModifica_Load(object sender, EventArgs e)
        {
            textBoxMarca.Text = car.Marca;
            textBoxTipo.Text = car.Tipo;
            textBoxDataImmatricolazione.Text = car.dataDiImmatricolazione;
        }
 
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=LAPTOP-2MF9GFD7;Initial Catalog=garage;Integrated Security=True;";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand command;
            //Query SQL 
            string sql = "update Automobili set marca=@marca, tipo=@tipo, data_di_immatricolazione=@data_di_immatricolazione where targa=@targa";

            try
            {
                // Creazione della query 
                command = new SqlCommand(sql, cnn);
                // Aggiungo aggiungo i parametri alla query  
                command.Parameters.AddWithValue("@targa", car.Targa);
                command.Parameters.AddWithValue("@marca", textBoxMarca.Text);
                command.Parameters.AddWithValue("@tipo", textBoxTipo.Text);
                command.Parameters.AddWithValue("@data_di_immatricolazione", textBoxDataImmatricolazione.Text);
                // Eseguo la query
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //il comando nel try ha lanciato un eccezione
                MessageBox.Show($"{ex.Message}");
            }
            finally
            {
                //invoko l evento di modifica di un  record cosi da aggiornare la griglia
                CarEdit?.Invoke(this, EventArgs.Empty);
                //chiudo la connessione dopo aver finito il try 
                cnn.Close();
                this.Close();
            }

        }
    }
}
