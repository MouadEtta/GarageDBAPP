using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaragedbAPP
{

    public partial class FormModificaNuovo : Form
    {
        // Definisce l'evento CarNew che aggiornerà la tabella 
        public event EventHandler CarNew;
        public Car car;
        public DbQueries dbQuery { get; set; }
        public FormModificaNuovo(Car? car)
        {
            if (car != null)
            {
                this.car = car;
            }
            dbQuery = new DbQueries();
            InitializeComponent();
        }
        //popolo le combobox varie
        private void FormNuovo_Load(object sender, EventArgs e)
        {

            getAllBrands();
            getAllTypesOfBrand();
            if (car != null)
            {
                textBoxTarga.ReadOnly = true;
                textBoxTarga.Text = car.Targa;
                comboBoxMarca.Text = car.Marca;
                comboBoxTipo.Text = car.Tipo;
                textBoxDataImmatricolazione.Text = car.dataDiImmatricolazione;
                buttonAdd.Text = "modifica";
            }
            else
            {
                comboBoxMarca.SelectedIndex = -1;
                comboBoxTipo.SelectedIndex = -1;
            }
            //comboBoxMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBoxTipo.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DateTime dDate;
            if (textBoxTarga.Text != "" && comboBoxMarca.Text != "" && comboBoxTipo.Text != "" && textBoxDataImmatricolazione.Text != "")
            {
                if (DateTime.TryParse(textBoxDataImmatricolazione.Text, out dDate))
                {
                    if (dDate <= DateTime.Today)
                    {

                        if (car != null)
                        {

                            var res = dbQuery.EditRecord(textBoxTarga.Text, comboBoxMarca.Text, comboBoxTipo.Text, textBoxDataImmatricolazione.Text);

                            if (res)
                            {
                                CarNew?.Invoke(this, EventArgs.Empty);
                                this.Close();
                            }


                        }
                        else
                        {
                            var res = dbQuery.addNewCar(textBoxTarga.Text, comboBoxMarca.Text, comboBoxTipo.Text, textBoxDataImmatricolazione.Text);
                            //invoco evento del aggiunta di una nuova macchina cosi da aggiornare la griglia
                            if (res)
                            {
                                CarNew?.Invoke(this, EventArgs.Empty);
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Data non minore o uguale alla data di oggi");
                    }
                }
                else
                {
                    MessageBox.Show("data in formato errato");
                };
            }
            else
            {
                MessageBox.Show("devi compilare tutti i campi");
            }

        }
        //metodo per popolare combobox dei marche
        public void getAllBrands()
        {

            comboBoxMarca.DataSource = dbQuery.getAllBrands();
            comboBoxMarca.DisplayMember = "marca";

        }

        //metodo per popolare combobox dei tipi 
        public void getAllTypesOfBrand()
        {
            comboBoxTipo.DataSource = dbQuery.getAllTypesOfBrand(comboBoxMarca.Text);
            comboBoxTipo.DisplayMember = "tipo";
            if (car == null)
            {
                comboBoxTipo.SelectedIndex = -1;
            }

        }

        private void comboBoxMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            getAllTypesOfBrand();
        }
    }
}
