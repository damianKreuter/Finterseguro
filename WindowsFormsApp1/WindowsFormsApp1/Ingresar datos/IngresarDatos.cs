using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            radioButtonLagrange.Checked = true;
        }

        private void buttonIngresarDatos_Click(object sender, EventArgs e)
        {
            DataGridView data = dataGridView1;
            double dominio = (double) numericUpDown1.Value;
            double imagen = (double) numericUpDown2.Value;

            string dato = string.Empty;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dato = row.Cells[0].Value.ToString();
                if (dominio.ToString().Equals(dato))
                {
                    //YA EXISTE EN LA TABLA ASI QUE MANDO ALERT 
                    //Y TERMINO ESTA OPERACION
                    MessageBox.Show("Error", "Ya existe el numero de dominio "+ dominio.ToString() + " en la tabla a ingresar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            dataGridView1.Rows.Add(dominio, imagen);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCalcularInterpolante_Click(object sender, EventArgs e)
        {
            String tipoAlgoritmo;
            if (radioButtonLagrange.Checked)
            {
                tipoAlgoritmo = "Lagrange";
            }
            else if(radioButtonNewtonProgresivo.Checked)
            {
                tipoAlgoritmo = "Newton-Gregory Progresivo";
            }
            else tipoAlgoritmo = "Newton-Gregory Regresivo";
            Mostrar_datos.MostrarPasos pasos =
                new Mostrar_datos.MostrarPasos(dataGridView1, tipoAlgoritmo);
                
        }
    }
}
