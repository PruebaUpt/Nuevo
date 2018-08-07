using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    class mascota
    {

        public String Clave { get; set; }
        public String Nombre { get; set; }
        public String Raza { get; set; }
        public String Sexo{get; set;}
        public String Tipo { get; set; }

        public String Consulta { get; set; }


        String Cadena = "";
        public mascota()
        {
            Cadena = ConfigurationManager.ConnectionStrings["Cadena1"].ConnectionString;
        }
        

        /// <summary>
        /// Método RegistrarM: Se encarga de registrar los animales 
        /// Autor: Flor Manzur
        /// </summary>
        public void RegistrarM()
        {
         using (SqlConnection conexion = new SqlConnection(Cadena))
            {
                string query = "AltaAnimales";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClaveM", Clave);
                    cmd.Parameters.AddWithValue("@NombreM", Nombre);
                    cmd.Parameters.AddWithValue("@Raza", Raza);
                    cmd.Parameters.AddWithValue("@Sexo", Sexo);
                    conexion.Open();
                    int registro = cmd.ExecuteNonQuery();
                    conexion.Close();
        
                    if (registro > 0)
                    {
                        MessageBox.Show("El animal se registro satisfactoriamente");
                        MessageBox.Show("");
                    }
                    else
                    {
                        MessageBox.Show("No fue posible registrar");
                        MessageBox.Show("");
                    }
                }
            }
        }

        /// <summary>
        /// Método Vacunar: Se encarga de dar de alta las vacunas de los animales
        /// Autor: Flor Manzur
        /// 
        /// </summary>
        public void Vacunar()
        {
            using (SqlConnection conexion = new SqlConnection(Cadena))
            {
                string query = "Aplicacion";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreM", Nombre );
                    cmd.Parameters.AddWithValue("@TVacuna", Tipo);
                    conexion.Open();
                    int registro = cmd.ExecuteNonQuery();
                    conexion.Close();


                    if (registro > 0)
                    {
                        MessageBox.Show("Vacuna Aplicada");
                    }
                    else
                    {
                        MessageBox.Show("No se Registro");
                    }
                }
            }
        }


        /// <summary>
        /// Metodo Eliminar
        /// Elimina los animales que no están vacunados
        /// </summary>
        public void Eliminar()
        {
            using (SqlConnection conexion = new SqlConnection(Cadena))
            {
                try
                {
                    string query = "Eliminar";
                    SqlDataAdapter adaptador = new SqlDataAdapter(query, conexion);
                    adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                   
                    adaptador.SelectCommand.Parameters.AddWithValue("@NombreM", Nombre);
                    DataSet datos = new DataSet();
                    adaptador.Fill(datos, "trabajoBD");

                    if (datos.Tables.Count > 0)
                    {
                        MessageBox.Show("El animal esta vacunado no es posible eliminarlo");
                    }
                    else
                    {
                        MessageBox.Show("Animal Eliminado del expediente");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("El animal esta vacunado no es posible eliminarlo");
                }
            }
        }

        
        
    }
}
