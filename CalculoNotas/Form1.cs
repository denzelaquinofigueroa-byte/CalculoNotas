using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculoNotas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtCompletivo.Enabled = false;
            txtExtraordinario.Enabled = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            // LEER NOTITAS XD
            if (!double.TryParse(txtNota1.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out double n1) ||
                !double.TryParse(txtNota2.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out double n2) ||
                !double.TryParse(txtNota3.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out double n3) ||
                !double.TryParse(txtNota4.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out double n4))
            {
                MessageBox.Show("Ingrese las cuatro notas en formato numérico válido.", "Error de formato",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // PROMEDIO
            double promedio = (n1 + n2 + n3 + n4) / 4.0;
            txtPromedio.Text = promedio.ToString("0.00");

            // APROBADO DIRECTO
            txtCompletivo.Enabled = false;
            txtExtraordinario.Enabled = false;
            if (promedio > 69)
            {
                txtResultado.Text = "Aprobado";
                return;
            }

            // COMPLETIVO
            txtCompletivo.Enabled = true;
            string txtComp = txtCompletivo.Text;
            if (string.IsNullOrWhiteSpace(txtComp))
            {
                MessageBox.Show("Ingrese la nota de completivo antes de continuar.", "Falta dato",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCompletivo.Focus();
                return; 
            }
            if (!double.TryParse(txtComp, NumberStyles.Number, CultureInfo.CurrentCulture, out double notaCompletivo))
            {
                MessageBox.Show("Formato de nota de completivo inválido. Use números válidos.", "Error de formato",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCompletivo.Focus();
                return;
            }

            double totalCompletivo = (promedio * 0.5) + (notaCompletivo * 0.5);

            if (totalCompletivo >= 70)
            {
                txtPromedio.Text = totalCompletivo.ToString("0.00");
                txtResultado.Text = "Aprobado por completivo";
                txtCompletivo.Enabled = false;
                txtExtraordinario.Enabled = false;
                return;
            }

            // EXTRAORDINARIO
            txtExtraordinario.Enabled = true;
            string txtExtra = txtExtraordinario.Text;
            if (string.IsNullOrWhiteSpace(txtExtra))
            {
                MessageBox.Show("Ingrese la nota extraordinaria antes de continuar.", "Falta dato",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtExtraordinario.Focus();
                return; 
            }
            if (!double.TryParse(txtExtra, NumberStyles.Number, CultureInfo.CurrentCulture, out double notaExtra))
            {
                MessageBox.Show("Formato de nota extraordinaria inválido. Use números válidos.", "Error de formato",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtExtraordinario.Focus();
                return;
            }

            double totalExtra = (promedio * 0.3) + (notaExtra * 0.7);
            txtPromedio.Text = totalExtra.ToString("0.00");

            if (totalExtra >= 70)
            {
                txtResultado.Text = "Aprobado por extraordinario";
            }
            else
            {
                txtResultado.Text = "Reprobado";
            }

          
            txtCompletivo.Enabled = false;
            txtExtraordinario.Enabled = false;
        }

            private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNota1.Clear();
            txtNota2.Clear();
            txtNota3.Clear();
            txtNota4.Clear();

            txtPromedio.Clear();
            txtCompletivo.Clear();
            txtExtraordinario.Clear();
            txtResultado.Clear();

            txtCompletivo.Enabled = false;
            txtExtraordinario.Enabled = false;
        }

    }
}


