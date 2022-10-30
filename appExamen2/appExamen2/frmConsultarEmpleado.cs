using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace appExamen2
{
    public partial class frmConsultarEmpleado : Form
    {
        Validacion v = new Validacion();
        public frmConsultarEmpleado()
        {
            InitializeComponent();
        }

        private void frmConsultarEmpleado_Load(object sender, EventArgs e)
        {
            mostrarDatos("");
        }

        public void mostrarDatos(string texto)
        {
            var obj = new Empleado();
            var ds = new DataSet();
            obj.NOMBRE = texto;
            ds = obj.Consultar();
            dgvDatos.Rows.Clear();
            foreach (DataRow fila in ds.Tables[0].Rows)
            {
                dgvDatos.Rows.Add(null, null, fila[0], fila[1], fila[2], fila[3], fila[4], fila[5], fila[6], fila[7]);
            }
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            mostrarDatos(txtTexto.Text);
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dgvDatos.Rows[dgvDatos.CurrentRow.Index];
            Program.IDEMPLEADO = int.Parse(fila.Cells[2].Value.ToString());
            if (e.ColumnIndex == 0)
            {
                Program.semaforo = 1;
                var f = new frmIngresarEmpleado(this);
                f.txtNombre.Text = fila.Cells[3].Value.ToString();
                f.txtCedula.Text = fila.Cells[4].Value.ToString();
                f.txtDireccion.Text = fila.Cells[5].Value.ToString();
                f.txtTelefono.Text = fila.Cells[6].Value.ToString();
                f.txtSueldo.Text = fila.Cells[7].Value.ToString();
                f.dtpFecha.Text = fila.Cells[8].Value.ToString();
                f.txtCargo.Text = fila.Cells[9].Value.ToString();
                f.ShowDialog();
            }
            else if (e.ColumnIndex == 1)
            {
                DialogResult res = MessageBox.Show("¿Está Seguro?", "ELIMINAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    var obj = new Empleado();
                    obj.IDEMPLEADO = Program.IDEMPLEADO;
                    string mensaje = obj.Eliminar();
                    if (mensaje == null)
                    {
                        MessageBox.Show("Empleado Eliminado", "ELIMINADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(mensaje);
                    }
                    mostrarDatos("");
                }
            }
        }

        private void txtTexto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = v.validarLetra(e.KeyChar);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmIngresarEmpleado f = new frmIngresarEmpleado(this);
            f.ShowDialog();
        }
    }
}
