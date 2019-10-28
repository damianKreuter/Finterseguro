using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApp1.Mostrar_datos
{
    public partial class MostrarPasos : Form
    {
        private String tipoAlgoritmo;
        private DataGridView datos;
        private ArrayList array;

        public MostrarPasos(DataGridView datos, String tipoAlgoritmo)
        {
            InitializeComponent();
            array = new ArrayList();

            foreach (DataGridViewRow row in datos.Rows)
            {
                array.Add(row.Cells[0].Value);
            }

            this.datos = datos;
            labelAlgoritmoUsado.Text = tipoAlgoritmo;
            this.tipoAlgoritmo = tipoAlgoritmo;
            llenarGrilla();
        }

        private void llenarGrilla()
        {
            DataGridView datosDeAlgoritmo;
            if (tipoAlgoritmo.Equals("Lagrange")){
                Procesamiento_de_datos.Lagrange lagrange = new Procesamiento_de_datos.Lagrange();
                datosDeAlgoritmo = lagrange.mostrarPasos(datos);
            } else
            {
          //      datosDeAlgoritmo = Procesamiento_de_datos.NewtonGregory.mostrarPasos(datos, tipoAlgoritmo);
            }
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }









}
