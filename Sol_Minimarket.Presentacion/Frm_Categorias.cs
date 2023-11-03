using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sol_Minimarket.Entidades;
using Sol_Minimarket.Negocio;

namespace Sol_Minimarket.Presentacion
{
    public partial class Frm_Categorias : Form
    {
        public Frm_Categorias()
        {
            InitializeComponent();
        }


        #region Mis variables
        int Estado_Guarda = 0; //Sin ninguna accion
        int Codigo_Ca = 0;

        #endregion

        #region Mis metodos

        private void Formato_ca()
        {
            Dgv_Principal.Columns[0].Width = 100;
            Dgv_Principal.Columns[0].HeaderText = "Código ca";
            Dgv_Principal.Columns[1].Width = 300;
            Dgv_Principal.Columns[1].HeaderText = "Categoria";
        }

        private void Listado_ca(string cTexto)
        {
            try
            {
                Dgv_Principal.DataSource = N_Categorias.Listado_ca(cTexto);
                this.Formato_ca();

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Estado_Botones_Principales(bool lEstado)
        {
            this.Btn_Nuevo.Enabled = lEstado;
            this.Btn_Actualizar.Enabled = lEstado;
            this.Btn_Eliminar.Enabled = lEstado;
            this.Btn_Reporte.Enabled = lEstado;
            this.Btn_Salir.Enabled = lEstado;
        }

        private void Estado_Botones_Procesos(bool lEstado)
        {
            this.Btn_Cancelar.Visible = lEstado;
            this.Btn_Guardar.Visible = lEstado;
            this.Btn_Retornar.Visible = !lEstado;
        }

        private void Selecciona_Item()
        {
            if(string.IsNullOrEmpty(Convert.ToString(Dgv_Principal.CurrentRow.Cells["codigo_ca"].Value)))
            {
                MessageBox.Show("No se tiene información para mostrar", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Codigo_Ca = Convert.ToInt32(Dgv_Principal.CurrentRow.Cells["codigo_ca"].Value);
                Txt_Descripcion_Ca.Text = Convert.ToString(Dgv_Principal.CurrentRow.Cells["descripcion_ca"].Value);
            }
        }

        #endregion

        private void Frm_Categorias_Load(object sender, EventArgs e)
        {
            this.Listado_ca(txt_Buscar.Text.Trim());
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            if(Txt_Descripcion_Ca.Text == string.Empty)
            {
                MessageBox.Show("Falta ingresar datos requeridos (*)", "Aviso del sistema", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            } else
            {
                E_Categorias categorias = new E_Categorias();
                string Rpta = string.Empty;
                categorias.Codigo_ca = this.Codigo_Ca;
                categorias.Descripcion_ca = Txt_Descripcion_Ca.Text.Trim();
                Rpta = N_Categorias.Guardar_ca(Estado_Guarda, categorias);
                if(Rpta == "Ok")
                {
                    MessageBox.Show("Registro creado con éxito","Aviso del sistema",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Estado_Guarda = 0;
                    Txt_Descripcion_Ca.Text = string.Empty;
                    this.Estado_Botones_Principales(true);
                    this.Estado_Botones_Procesos(false);
                    Tbp_principal.SelectedIndex = 0;
                    this.Listado_ca(txt_Buscar.Text.Trim());
                }
                else
                {
                    MessageBox.Show(Rpta, "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
            Estado_Guarda = 1; //Nuevo registro
            this.Estado_Botones_Principales(false);
            this.Estado_Botones_Procesos(true);
            Txt_Descripcion_Ca.Text = string.Empty;
            Txt_Descripcion_Ca.Focus();
            Txt_Descripcion_Ca.ReadOnly = false;
            Tbp_principal.SelectedIndex = 1;
        }

        private void Btn_Actualizar_Click(object sender, EventArgs e)
        {
            Estado_Guarda = 2;//Actualizar registro
            this.Estado_Botones_Principales(false);
            this.Estado_Botones_Procesos(true);
            this.Selecciona_Item();
            Txt_Descripcion_Ca.ReadOnly = false;
            Txt_Descripcion_Ca.Focus();
            Tbp_principal.SelectedIndex = 1;
        }

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            Estado_Guarda = 0; //Sin acción
            this.Codigo_Ca = 0;
            Txt_Descripcion_Ca.Text = string.Empty;
            Txt_Descripcion_Ca.ReadOnly = true;
            this.Estado_Botones_Principales(true);
            this.Estado_Botones_Procesos(false);
        }

        private void Dgv_Principal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Selecciona_Item();
            this.Estado_Botones_Procesos(false);
            Tbp_principal.SelectedIndex = 1;
        }

        private void Btn_Retornar_Click(object sender, EventArgs e)
        {
            this.Codigo_Ca = 0;
            Txt_Descripcion_Ca.Text = string.Empty;
            Txt_Descripcion_Ca.ReadOnly = true;
            this.Estado_Botones_Procesos(false);
            Tbp_principal.SelectedIndex = 0;
            this.Codigo_Ca = 0;
        }

        private void Btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_Principal.CurrentRow.Cells["codigo_ca"].Value)))
            {
                MessageBox.Show("No se ha seleccionado ningun registro a eliminar", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult opcion;
                opcion = MessageBox.Show("¿Estas seguro de eliminar el registro seleccionado?", "Aviso del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(opcion == DialogResult.Yes)
                {
                    string Rpta = string.Empty;
                    this.Codigo_Ca = Convert.ToInt32(Dgv_Principal.CurrentRow.Cells["codigo_ca"].Value);
                    Rpta = N_Categorias.Eliminar_ca(this.Codigo_Ca);
                    if(Rpta == "Ok")
                    {
                        this.Listado_ca(txt_Buscar.Text.Trim());
                        this.Codigo_Ca = 0;
                        MessageBox.Show("Registro eliminado con éxito", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void Btn_Reporte_Click(object sender, EventArgs e)
        {
            Reportes.Frm_RPT_Categprias oRpt1 = new Reportes.Frm_RPT_Categprias();
            oRpt1.textBox1.Text = txt_Buscar.Text;
            oRpt1.ShowDialog();
        }
    }
}
