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
    public partial class AplicacionVacunas : Form
    {
        String Cadena = "";
        mascota m = new mascota();
        public AplicacionVacunas()
        {
            
            Cadena = ConfigurationManager.ConnectionStrings["Cadena1"].ConnectionString;

            InitializeComponent();
            ComboM();
            Combo();
            
        }

        private void AplicacionVacunas_Load(object sender, EventArgs e)
        {

        }




        public void Combo()
        {
            using (SqlConnection conexion = new SqlConnection(Cadena))
            {
                try
                {
                    string query = "C_combo";
                    SqlDataAdapter adaptador = new SqlDataAdapter(query, conexion);
                    adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable datos = new DataTable();
                    adaptador.Fill(datos);
                    cbmtipo.DataSource = datos;
                    cbmtipo.DisplayMember = "Descripcion";
                    cbmtipo.ValueMember = "Es la descripcion ";


                }
                catch (Exception ei)
                {

                    MessageBox.Show("Error de conexion " + ei.ToString());
                }
            }

        }

        ///////////////////////////////
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




        private void button1_Click(object sender, EventArgs e)
        {
            m.Nombre=Convert.ToString(cbmmascota.SelectedValue);
            m.Tipo = Convert.ToString(cbmtipo.SelectedValue);
            m.Vacunar();
       }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consulta c = new Consulta();
            c.Show();
            Dispose(false);
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consulta c = new Consulta();
            c.Show();
            Dispose(false);
        }

        private void vacunarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            Dispose(false);
        }
    }

}
