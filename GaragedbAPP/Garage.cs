using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GaragedbAPP
{
    public partial class Garage : Form
    {
        public List<Car> Cars { get; set; }
        public string connectionString { get; set; }
        public SqlConnection cnn { get; set; }
        public Garage()
        {
            connectionString = @"Data Source=LAPTOP-2MF9GFD7;Initial Catalog=garage;Integrated Security=True;";
            cnn = new SqlConnection(connectionString);
            Cars = new List<Car>();
            InitializeComponent();
        }


        // all avvio del form popolo la griglia 
        private void Form1_Load(object sender, EventArgs e)
        {
            getAllCars();
        }

        //bottone per aprire form di conferma eliminazione record
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //come prima cosa trasformo in oggetto la riga dda eliminare
            Car selectedCar = GetSelectedCar();
            //controllo che sia selezionata una riga  nel caso non apro il form di conferma
            if (selectedCar != null)
            {
                FormElimina formElimina = new FormElimina(selectedCar);
                formElimina.CarDeleted += FormElimina_CarDeleted;
                formElimina.Show();
            }
            else
            {
                MessageBox.Show("Seleziona prima la riga da eliminare.");
            }
        }

        // Metodo che gestisce l'evento CarDeleted
        private void FormElimina_CarDeleted(object sender, EventArgs e)
        {
            // Ricarica i dati nella DataGridView
            getAllCars();
        }
        //bottone per aprire form di modifica di un record
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            //come prima cosa trasformo in oggetto la riga da modificare
            Car selectedCar = GetSelectedCar();
            //controllo che abbia selezionato la riga da modificare nel caso non apro il form
            if (selectedCar != null)
            {
                FormModifica formModifica = new FormModifica(selectedCar);
                formModifica.CarEdit += FormModifica_CarEdit;
                formModifica.Show();
            }
            else
            {
                MessageBox.Show("Seleziona una riga prima di aprire il form secondario.");
            }
        }
        // Metodo che gestisce l'evento CarEdit
        private void FormModifica_CarEdit(object sender, EventArgs e)
        {
            // Ricarica i dati nella DataGridView
            getAllCars();
        }
        //bottone per aprire form di aggiunta  record
        private void buttonNew_Click(object sender, EventArgs e)
        {
            FormNuovo formNuovo = new FormNuovo();
            formNuovo.CarNew += FormNuovo_CarNew;
            formNuovo.Show();
        }
        // Metodo che gestisce l'evento CarNew
        private void FormNuovo_CarNew(object sender, EventArgs e)
        {
            // Ricarica i dati nella DataGridView
            getAllCars();
        }
        //metodo che ritorna la macchina selezionata
        private Car? GetSelectedCar()
        {
            //controllo se c'è una riga selezionata
            if (dataGridView.CurrentRow != null)
            {
              //  trasformo la riga selezionata in un dataRowView cosi da poter
              //  prendere gli elementi della row e usarli per creare l oggetto Car
                DataRowView? rowView = dataGridView.CurrentRow.DataBoundItem as DataRowView;
                if (rowView != null)
                {    //prendo i dati nella riga con row e poi credo l oggetto da mandare con i vari form 
                    DataRow? row = rowView.Row;
                    if (row != null)
                    {
                        Car selectedCar = new Car
                        {
                            Targa = row["targa"]?.ToString() ?? string.Empty,
                            Marca = row["marca"]?.ToString() ?? string.Empty,
                            Tipo = row["tipo"]?.ToString() ?? string.Empty,
                            dataDiImmatricolazione = row["data_di_immatricolazione"]?.ToString() ?? string.Empty,
                        };

                        return selectedCar;
                    }
                }
            }
            return null;
        }

        //  metodo per valorizzare la lista con tutte le macchine che ci sono nel db questo metodo viene eseguito al avvio del form
        //  e quando si conclude in uno dei form elimina,modifica,nuovo
        public void getAllCars()
        {
           
            cnn.Open();
            String sql = "";
            sql = "Select targa,marca,tipo,data_di_immatricolazione from Automobili";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, cnn);
            DataTable tb = new DataTable();
            adapter.Fill(tb);
            dataGridView.DataSource = tb;
            dataGridView.Columns["data_di_immatricolazione"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            
            cnn.Close();

        }

    }
}
