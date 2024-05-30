using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace GaragedbAPP
{
    public class DbQueries
    {
        private SqlConnection conn { get; set; }

        public DbQueries()
        {
            try
            {
                string connectionString = @"Data Source=LAPTOP-2MF9GFD7;Initial Catalog=garage;Integrated Security=True;";
                conn = new SqlConnection(connectionString);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
        //  metodo per valorizzare la lista con tutte le macchine che ci sono nel db questo metodo viene eseguito al avvio del form
        //  e quando si conclude in uno dei form elimina,modifica,nuovo
        public DataTable getAllCars()
        {

            DataTable tb = new DataTable();
            conn.Open();
            String sql = "";
            try
            {
                sql = "Select Targa,Marca,Tipo,DataImmatricolazione from Automobili";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                tb = new DataTable();
                adapter.Fill(tb);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
            finally { conn.Close(); }

            return tb;
        }
        public void checkMarcaExists(string marca)
        {
            conn.Open();
            SqlCommand command;
            //Query SQL 
            string sql = @"
        IF NOT EXISTS (SELECT 1 FROM Marche WHERE Marca = @Marca)
        BEGIN
            INSERT INTO Marche (Marca) VALUES (@marca);
        END";

            try
            {
                // Creazione della query 
                command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@marca", marca);
                // Eseguo la query
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //il comando nel try ha lanciato un eccezione
                MessageBox.Show($"{ex.Message}");
                conn.Close();
                return;
            }

            //chiudo la connessione dopo aver finito il try 

            conn.Close();


        }
        public void checkTipoofMarcaExists(string tipo, string marca)
        {
            conn.Open();
            SqlCommand command;
            //Query SQL 
            string sql = @"
        IF NOT EXISTS (SELECT 1 FROM Tipi WHERE Tipo = @Tipo AND Marca = @marca)
        BEGIN
            INSERT INTO Tipi (Tipo, Marca) VALUES (@Tipo, @Marca);
        END";

            try
            {
                // Creazione della query 
                command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@marca", marca);
                command.Parameters.AddWithValue("@tipo", tipo);

                // Eseguo la query
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //il comando nel try ha lanciato un eccezione
                MessageBox.Show($"{ex.Message}");
                conn.Close();
                return;
            }

            //chiudo la connessione dopo aver finito il try 

            conn.Close();


        }
        public bool addNewCar(string targa, string marca, string tipo, string dataDiImmatricolazione)
        {
            if (targa != "" && marca != "" && tipo != "" && dataDiImmatricolazione != "") { 
                checkMarcaExists(marca);
            checkTipoofMarcaExists(tipo, marca);
            conn.Open();
            SqlCommand command;
            bool res = false;
            string sql = "INSERT INTO Automobili (Targa, Marca, Tipo, DataImmatricolazione) VALUES (@targa, @marca, @tipo, @data_di_immatricolazione)";
            //        // Creazione della connessione
            try
            {
                // Creazione del comando SQL
                command = new SqlCommand(sql, conn);

                // aggiungo i parametri al comando sql
                command.Parameters.AddWithValue("@targa", targa);
                command.Parameters.AddWithValue("@marca", marca);
                command.Parameters.AddWithValue("@tipo", tipo);
                command.Parameters.AddWithValue("@data_di_immatricolazione", dataDiImmatricolazione);

                // Esecuzione del comando
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
                conn.Close();
                return false;
            }
            MessageBox.Show($"aggiunta con successo ");
            // Chiude la connessione
            conn.Close();
                return true;
            }
            else
            {
                MessageBox.Show("devi compilare tutti i campi");
                return false;
            }
        }
        //metodo per popolare combobox dei marche
        public DataTable getAllBrands()
        {
            DataTable tb = new DataTable();
            conn.Open();
            String sql = "";
            sql = "Select Marca from Marche";
            try
            {

                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                tb = new DataTable();
                adapter.Fill(tb);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
            finally
            {
                conn.Close();

            }
            return tb;
        }

        //metodo per popolare combobox dei tipi 
        public DataTable getAllTypesOfBrand(string marca)
        {
            DataTable tb = new DataTable();
            conn.Open();
            String sql = "";
            sql = "Select  Tipo from Tipi where Marca=@marca";
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@marca", marca);
                adapter.Fill(tb);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
            finally
            {
                conn.Close();

            }
            return tb;
        }
        public bool EditRecord(string targa, string marca, string tipo, string dataDiImmatricolazione)
        {
            if (targa != "" && marca != "" && tipo != "" && dataDiImmatricolazione != "") { 
                checkMarcaExists(marca);
            checkTipoofMarcaExists(tipo, marca);
            conn.Open();
            SqlCommand command;
            //Query SQL 
            string sql = "update Automobili set Marca=@marca, Tipo=@tipo, DataImmatricolazione=@data_di_immatricolazione where Targa=@targa";

            try
            {
                // Creazione della query 
                command = new SqlCommand(sql, conn);
                // Aggiungo aggiungo i parametri alla query  
                command.Parameters.AddWithValue("@targa", targa);
                command.Parameters.AddWithValue("@marca", marca);
                command.Parameters.AddWithValue("@tipo", tipo);
                command.Parameters.AddWithValue("@data_di_immatricolazione", dataDiImmatricolazione);
                // Eseguo la query
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //il comando nel try ha lanciato un eccezione
                MessageBox.Show($"{ex.Message}");
                conn.Close();
                return false;
            }

            MessageBox.Show("modificato con successo ");

            //chiudo la connessione dopo aver finito il try 

            conn.Close();
                return true;
            }

            else
            {
                MessageBox.Show("devi compilare tutti i campi");
                return false;
            }
        }

        public void DeleteCar(string targa)
        {
            conn.Open();
            SqlCommand command;
            string sql = "delete Automobili where targa=@targa";
            try
            {
                // Creazione della query 
                command = new SqlCommand(sql, conn);
                // Aggiungo il parametro della targa della macchina da eliminare 
                command.Parameters.AddWithValue("@targa", targa);
                // Eseguo la query
                int rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //il comando nel try ha lanciato un eccezione
                MessageBox.Show($"{ex.Message}");
                conn.Close();
                return;
            }
            MessageBox.Show($"rimosso con successo");
            //chiudo la connessione dopo aver finito il try 
            conn.Close();

        }
    }
}
