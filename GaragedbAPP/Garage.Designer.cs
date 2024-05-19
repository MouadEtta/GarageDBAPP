namespace GaragedbAPP
{
    partial class Garage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView = new DataGridView();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(51, 129);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.Size = new Size(691, 269);
            dataGridView.TabIndex = 1;
            // 
            // button2
            // 
            button2.Location = new Point(82, 59);
            button2.Name = "button2";
            button2.Size = new Size(120, 33);
            button2.TabIndex = 2;
            button2.Text = "Elimina";
            button2.UseVisualStyleBackColor = true;
            button2.Click += buttonDelete_Click;
            // 
            // button3
            // 
            button3.Location = new Point(297, 59);
            button3.Name = "button3";
            button3.Size = new Size(120, 33);
            button3.TabIndex = 3;
            button3.Text = "Modifica";
            button3.UseVisualStyleBackColor = true;
            button3.Click += buttonEdit_Click;
            // 
            // button4
            // 
            button4.Location = new Point(545, 59);
            button4.Name = "button4";
            button4.Size = new Size(120, 33);
            button4.TabIndex = 4;
            button4.Text = "Nuovo";
            button4.UseVisualStyleBackColor = true;
            button4.Click += this.buttonNew_Click;
            // 
            // Garage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(dataGridView);
            Name = "Garage";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dataGridView;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}
