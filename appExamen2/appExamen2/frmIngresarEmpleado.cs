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
    public partial class frmIngresarEmpleado : Form
    {
        Validacion v = new Validacion();
        frmConsultarEmpleado forma;
        public frmIngresarEmpleado(frmConsultarEmpleado f)
        {
            InitializeComponent();
            forma = f;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = v.validarLetra(e.KeyChar);
            if(e.KeyChar == 13)
            {
                txtCedula.Focus();
            }
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = v.validarNumero(e.KeyChar);
            if(e.KeyChar == 13)
            {
                txtDireccion.Focus();
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                txtTelefono.Focus();
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = v.validarNumero(e.KeyChar);
            if(e.KeyChar == 13)
            {
                txtSueldo.Focus();
            }
        }

        private void txtSueldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = v.validarDecimal(e.KeyChar, txtSueldo.Text);
            if(e.KeyChar == 13)
            {
                dtpFecha.Focus();
            }
        }

        private void dtpFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtCargo.Focus();
            }
        }

        private void txtCargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = v.validarLetra(e.KeyChar);
            if(e.KeyChar == 13)
            {
                btnAceptar.Focus();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string m = "";
            if (txtNombre.Text.Length == 0)
            {
                m += "Falta Ingresar Nombre\n";
            }
            if (txtCedula.Text.Length == 0)
            {
                m += "Falta Ingresar Cedula\n";
            }
            if (txtDireccion.Text.Length == 0)
            {
                m += "Falta Ingresar Direccion\n";
            }
            if(txtTelefono.Text.Length == 0)
            {
                m += "Falta Ingresar Telefono\n";
            }
            else if (txtTelefono.Text.Length != 10)
            {
                m += "El Telefono Debe Tener 10 Dígitos\n";
            }
            if(txtSueldo.Text.Length == 0)
            {
                m += "Falta Ingresar Sueldo\n";
            }
            if(dtpFecha.Value > DateTime.Today)
            {
                m += "El Fecha de Ingreso no debe ser Mayor a la de Hoy\n";
            }
            if (txtSueldo.Text.Length == 0)
            {
                m += "Falta Ingresar Cargo\n";
            }
            if (m.Length != 0)
            {
                MessageBox.Show(m, "FALTA INGRESAR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            ValidarCedula(sender, e);
        }

        private void ValidarCedula(object sender, EventArgs e)
        {
            string mensaje = "";

            if (txtCedula.Text.Length == 10)
            {
                if (int.Parse(txtCedula.Text.Substring(0, 2)) < 1
                    || int.Parse(txtCedula.Text.Substring(0, 2)) > 24)
                {
                    mensaje += "Los 2 Primeros Dígitos Son Inválidos\n";
                }

                else
                {
                    int digito = 0, suma = 0;

                    for (int i = 0; i < txtCedula.Text.Length; i++)
                    {
                        digito = int.Parse(txtCedula.Text.Substring(i, 1));

                        if ((i + 1) % 2 != 0)
                        {
                            digito *= 2;
                            if (digito > 9)
                            {
                                digito -= 9;
                            }
                        }

                        suma += digito;
                    }

                    if (suma % 10 != 0)
                    {
                        mensaje += "Número de Cédula Inválido\n";
                    }
                }
            }

            else
            {
                mensaje += "La Cédula debe tener 10 Dígitos\n";
            }

            if (mensaje.Length != 0)
            {
                MessageBox.Show(mensaje, "CEDULA INVALIDA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                AgregarPersona(sender, e);
            }
        }

        private void AgregarPersona(object sender, EventArgs e)
        {
            try
            {
                var obj = new Empleado();
                string mensaje;
                obj.NOMBRE= txtNombre.Text;
                obj.CEDULA = txtCedula.Text;
                obj.DIRECCION = txtDireccion.Text;
                obj.TELEFONO = txtTelefono.Text;
                obj.SUELDO = float.Parse(txtSueldo.Text);
                obj.FECHA_INGRESO = dtpFecha.Value;
                obj.CARGO = txtCargo.Text;
                if (Program.IDEMPLEADO == 0)
                {
                    mensaje = obj.Grabar();
                    if (mensaje == null)
                    {
                        MessageBox.Show("Empleado Registrado", "REGISTRADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(mensaje);
                    }
                }
                else
                {
                    obj.IDEMPLEADO = Program.IDEMPLEADO;
                    mensaje = obj.Modificar();
                    if (mensaje == null)
                    {
                        MessageBox.Show("Empleado Modificado", "MODIFICADO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(mensaje);
                    }
                }
                forma.mostrarDatos("");
                btnCancelar_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIngresarEmpleado_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.semaforo = 0;
            Program.IDEMPLEADO = 0;
        }

        private void frmIngresarEmpleado_Load(object sender, EventArgs e)
        {
            this.Top = 50;
        }
    }
}
