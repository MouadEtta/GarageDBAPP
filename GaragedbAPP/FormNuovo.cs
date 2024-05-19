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

    public partial class FormNuovo : Form
    {
        // Definisce l'evento CarNew che aggiornerà la tabella 
        public event EventHandler CarNew;
        public FormNuovo()
        {
            InitializeComponent();
        }
        //popolo le combobox varie
        private void FormNuovo_Load(object sender, EventArgs e)
        {
            getAllBrands();
            getAllTypes();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=LAPTOP-2MF9GFD7;Initial Catalog=garage;Integrated Security=True;";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand command;
            string sql = "INSERT INTO Automobili (targa, marca, tipo, data_di_immatricolazione) VALUES (@targa, @marca, @tipo, @data_di_immatricolazione)";
            //        // Creazione della connessione
            try
            {
                // Creazione del comando SQL
                command = new SqlCommand(sql, cnn);

                // aggiungo i parametri al comando sql
                command.Parameters.AddWithValue("@targa", textBoxTarga.Text);
                command.Parameters.AddWithValue("@marca", comboBoxMarca.Text);
                command.Parameters.AddWithValue("@tipo", comboBoxTipo.Text);
                command.Parameters.AddWithValue("@data_di_immatricolazione", textBoxDataImmatricolazione.Text);

                // Esecuzione del comando
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
            finally
            {
                //invoco evento del aggiunta di una nuova macchina cosi da aggiornare la griglia
                CarNew?.Invoke(this, EventArgs.Empty);
                // Chiude la connessione
                cnn.Close();
                this.Close();

            }


        }
        //metodo per popolare combobox dei marche
        public void getAllBrands()
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=LAPTOP-2MF9GFD7;Initial Catalog=garage;Integrated Security=True;";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            String sql = "";
            sql = "Select marca from Automobili";
            try
            {

                SqlDataAdapter adapter = new SqlDataAdapter(sql, cnn);
                DataTable tb = new DataTable();
                adapter.Fill(tb);
                comboBoxMarca.DataSource = tb;
                comboBoxMarca.DisplayMember = "marca";
                // Imposta la modalità di auto-completamento su SuggestAppend
                comboBoxMarca.AutoCompleteMode = AutoCompleteMode.SuggestAppend;


            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
            finally
            {
                cnn.Close();

            }

        }

        //metodo per popolare combobox dei tipi 
        public void getAllTypes()
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=LAPTOP-2MF9GFD7;Initial Catalog=garage;Integrated Security=True;";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            String sql = "";
            sql = "Select tipo from Automobili where marca=@marca";
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, cnn);
                adapter.SelectCommand.Parameters.AddWithValue("@marca", comboBoxMarca.Text);
                DataTable tb = new DataTable();
                adapter.Fill(tb);
                comboBoxTipo.DataSource = tb;
                comboBoxTipo.DisplayMember = "tipo";
                // Imposta la modalità di auto-completamento su SuggestAppend
                comboBoxTipo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;


            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
            finally
            {
                cnn.Close();

            }
        }
    }
}
