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

namespace GaragedbAPP
{
    public partial class FormElimina : Form
    {
        // Definisce l'evento CarDeleted
        public event EventHandler CarDeleted;
        public Car car { get; set; }
        public FormElimina(Car car)
        {
            this.car = car;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=LAPTOP-2MF9GFD7;Initial Catalog=garage;Integrated Security=True;";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand command;
            string sql = "delete Automobili where targa=@targa";
            try
            {
                // Creazione della query 
                command = new SqlCommand(sql, cnn);
                // Aggiungo il parametro della targa della macchina da eliminare 
                command.Parameters.AddWithValue("@targa", car.Targa);
                // Eseguo la query
                int rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //il comando nel try ha lanciato un eccezzione
                Console.WriteLine($"Errore: {ex.Message}");
            }
            finally
            {
                //invoca evento di eliminazione di un record per aggiornare la griglia
                CarDeleted?.Invoke(this, EventArgs.Empty);
                //chiudo la connessione dopo aver finito il try 
                cnn.Close();
                this.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
