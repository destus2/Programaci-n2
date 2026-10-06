using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAREABASEDEDATOS
{
    public partial class FrmAgregarTarea : Form
    {
        public FrmAgregarTarea()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("El título de la tarea es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitulo.Focus();
                return;
            }

            
            string query = "INSERT INTO Tareas (Titulo, Descripcion, Estado, FechaCreacion) VALUES (@Titulo, @Descripcion, 'Pendiente', GETDATE())";

            try
            {
                
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Titulo", txtTitulo.Text.Trim());

                        if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
                        {
                            cmd.Parameters.AddWithValue("@Descripcion", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text.Trim());
                        }

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("¡Tarea agregada exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar la tarea: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmAgregarTarea_Load(object sender, EventArgs e)
        {
            
        }
    }
    
}
