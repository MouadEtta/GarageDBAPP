using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GaragedbAPP
{
    public partial class Garage : Form
    {
        public DbQueries dbQuery {  get; set; }
        public Garage()
        {
            dbQuery = new DbQueries();
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
            //controllo se c'è una riga selezionata
            if (dataGridView.CurrentRow != null)
            {
                //  trasformo la riga selezionata in un dataRowView cosi da poter
                //  prendere gli elementi della row e usarli per creare l oggetto Car
                DataRowView? rowView = dataGridView.CurrentRow.DataBoundItem as DataRowView;
                if (rowView != null)
                {    //prendo i dati nella riga con row e poi credo l oggetto da mandare con i vari form 
                    DataRow? row = rowView.Row;
                    if (row != null )
                    {
                        var conferma = MessageBox.Show("Sei sicuro di voler eliminare questa automobile?", "Conferma eliminazione", MessageBoxButtons.YesNo);
                        if (conferma == DialogResult.Yes)
                        {
                            dbQuery.DeleteCar(row["targa"]?.ToString()??"");
                            getAllCars();
                        }
                        else
                        {
                            MessageBox.Show("Eliminazione annullata");
                        }
                    }
                    //come prima cosa trasformo in oggetto la riga dda eliminare
                }
            }
            else
            {
                MessageBox.Show("selezionare una riga prima di eliminare");
            }
            
        }
       
        //bottone per aprire form di modifica di un record
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            //come prima cosa trasformo in oggetto la riga da modificare
            Car selectedCar = GetSelectedCar();
            //controllo che abbia selezionato la riga da modificare nel caso non apro il form
            if (selectedCar != null)
            {
                FormModificaNuovo formModificaNuovo = new FormModificaNuovo(selectedCar);
                formModificaNuovo.CarNew += FormModifica_CarEdit;
                formModificaNuovo.Show();
            }
        }
        // Metodo che gestisce l'evento CarEdit
        
        //bottone per aprire form di aggiunta  record
        private void buttonNew_Click(object sender, EventArgs e)
        {
            FormModificaNuovo formNuovo = new FormModificaNuovo(null);
            formNuovo.CarNew += FormNuovo_CarNew;
            formNuovo.Show();
        }
        // Metodo che gestisce l'evento CarNew

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
                        DateTime dataImmatricolazione = DateTime.Parse(row["DataImmatricolazione"]?.ToString() ?? "");
                        Car selectedCar = new Car
                        {
                            Targa = row["targa"]?.ToString() ?? string.Empty,
                            Marca = row["marca"]?.ToString() ?? string.Empty,
                            Tipo = row["tipo"]?.ToString() ?? string.Empty,
                            dataDiImmatricolazione = dataImmatricolazione.ToString("yyyy-MM-dd") ?? string.Empty,
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
            dataGridView.DataSource = dbQuery.getAllCars();
            dataGridView.Columns["DataImmatricolazione"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        }

        // Metodo che gestisce l'evento CarDeleted
        private void FormElimina_CarDeleted(object sender, EventArgs e)
        {
            // Ricarica i dati nella DataGridView
            getAllCars();
        }
        private void FormNuovo_CarNew(object sender, EventArgs e)
        {
            // Ricarica i dati nella DataGridView
            getAllCars();
        }
        private void FormModifica_CarEdit(object sender, EventArgs e)
        {
            // Ricarica i dati nella DataGridView
            getAllCars(); ;
        }
    }
}
