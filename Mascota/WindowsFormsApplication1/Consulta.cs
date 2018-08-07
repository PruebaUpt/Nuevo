using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{


    public partial class Consulta : Form
    {

        String Cadena = "";
        mascota m = new mascota();
        public Consulta()
        {
            InitializeComponent();
            Cadena = ConfigurationManager.ConnectionStrings["Cadena1"].ConnectionString;
            ComboM();
        }

        private void Consulta_Load(object sender, EventArgs e)
        {
            Reporte1();



        }

        public void Reporte1()
        {
            

        }
        private void button3_Click(object sender, EventArgs e)
        {
            m.Nombre = Convert.ToString(cbmmascota.SelectedValue);
            m.Eliminar();
            ComboM();
        }


        public void ComboM()
        {
            using (SqlConnection conexion = new SqlConnection(Cadena))
            {
                try
                {
                    string query = "C_comboM";
                    SqlDataAdapter adaptador = new SqlDataAdapter(query, conexion);
                    adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable datos = new DataTable();
                    adaptador.Fill(datos);
                    cbmmascota.DataSource = datos;
                    cbmmascota.DisplayMember = "NombreM";
                    cbmmascota.ValueMember = "NombreM";


                }
                catch (Exception ei)
                {

                    MessageBox.Show("Error de conexion " + ei.ToString());
                }
            }

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 A = new Form1();
            A.Show();
            Dispose(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(Cadena))
            {
                try
                {
                    string query = "ConsultaVM";
                    SqlDataAdapter adaptador = new SqlDataAdapter(query, conexion);
                    adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adaptador.SelectCommand.Parameters.AddWithValue("@NombreM", cbmmascota.SelectedValue);
                    DataSet datos = new DataSet();
                    adaptador.Fill(datos, "trabajoBD");


                    if (datos.Tables.Count > 0)
                    {
                      LVDatos.DataSource = datos;
                      LVDatos.DataMember = "trabajoBD";
                    }
                    else
                    {
                        MessageBox.Show("No hay registros");
                    }
                }
                catch (Exception ei)
                {

                    MessageBox.Show("Error de conexion " + ei.ToString());
                }

            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void vacunarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AplicacionVacunas ap = new AplicacionVacunas();
            ap.Show();
            Dispose(false);
        }
    }
}
