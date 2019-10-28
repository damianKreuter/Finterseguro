using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Procesamiento_de_datos
{
    class Lagrange
    {
        public Lagrange() { }

        public DataGridView mostrarPasos(DataGridView datos)
        {

            return datos;
        }

        public String pasoPolinomioBasico(double x, double[] xArray, int i)
        {
            String devolver = "";
            int size = xArray.Length;
            for (int j = 0; j < size; j++)
            {
                if (j != i)
                {
                    String cadena = divisionToString(x, xArray[j], xArray[i]);
                    devolver = devolver + cadena;
                }
            }
            return devolver;
        }
        
        private String divisionToString(double buscado, double x, double y)
        {
            return entreParentesis(buscado, x) + "/" + entreParentesis(x, y);
        }

        private String entreParentesis(double x1, double x2)
        {
            return "(" + x1.ToString() + "-" + x2.ToString() + ")";
        }

        //SEGUN LA CANTIDAD DE GRADOS SE SUMAN LA CANTIDAD DE COSAS QUE HAY QUE AHCER

        public ArrayList obtenerLosLxi(double x, double[] xArray, int i)
        {
            ArrayList lxis = new ArrayList();
            int size = xArray.Length;
            for (int j = 0; j < size; j++)
            {
                if (j != i)
                {
                    lxis.Add((x - xArray[j]) / (xArray[i] - xArray[j]));
                }
            }
            return lxis;
        }

        private static double polinomioBasico(double x, double[] xArray, int i)
        {
            int size = xArray.Length;

            double basicPolynomial = 1;

            for (int j = 0; j < size; j++)
            {
                if (j != i)
                {
                    basicPolynomial *= (x - xArray[j]) / (xArray[i] - xArray[j]);
                }
            }

            return basicPolynomial;
        }

        /*
         * X        -> El punto al que quiero buscar su imagen
         * XARRAY   -> Conjunto de puntos que existen como dominio
         * YARRAY   -> Conjunto de puntos que existen en la imagen
         * */
        public static double LagrangeInterpolacionPolimonial(double x, double[] xArray, double[] yArray)
        {
            int size = xArray.Length;

            double lagrangePolynomial = 0;

            for (int i = 0; i < size; i++)
            {
                lagrangePolynomial += polinomioBasico(x, xArray, i) * yArray[i];
            }

            return lagrangePolynomial;
        }
    }
}
