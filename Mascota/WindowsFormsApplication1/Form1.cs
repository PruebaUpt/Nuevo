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
    public partial class Form1 : Form
    {
        String Cadena = "";
        mascota m = new mascota();
        public Form1()
        {
            InitializeComponent();
            Cadena = ConfigurationManager.ConnectionStrings["Cadena1"].ConnectionString;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m.Clave = txtclave.Text;
            m.Nombre = txtnombre.Text;
            m.Raza = txtraza.Text;
            m.Sexo = txtsexo.Text;
            m.RegistrarM();
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
            AplicacionVacunas ap = new AplicacionVacunas();
            ap.Show();
            Dispose(false);
        }
    }
}
