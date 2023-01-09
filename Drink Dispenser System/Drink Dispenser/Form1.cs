using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drink_Dispenser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //######################## ORDER ############################
        string name;
        double price;
        double total;
        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (checkBoxAp.Checked)
            {
                name = "Apple Juice";
                int qty = int.Parse(numericUpDown1.Value.ToString());
                price = 130.00;
                total = qty * price;
                this.dataGridView1.Rows.Add(name, price.ToString("#.00"), qty, total.ToString("#.00"));
            }

            if (checkBoxOr.Checked)
            {
                name = "Orange Juice";
                int qty = int.Parse(numericUpDown2.Value.ToString());
                price = 120.00;
                total = qty * price;
                this.dataGridView1.Rows.Add(name, price.ToString("#.00"), qty, total.ToString("#.00"));
            }

            if (checkBoxCo.Checked)
            {
                name = "Coffee";
                int qty = int.Parse(numericUpDown3.Value.ToString());
                price = 100.00;
                total = qty * price;
                this.dataGridView1.Rows.Add(name, price.ToString("#.00"), qty, total.ToString("#.00"));
            }

            double sum = 0;
            for (int row = 0; row < dataGridView1.Rows.Count; row++)
            {
                sum = sum + Convert.ToDouble(dataGridView1.Rows[row].Cells[3].Value);
            }

            textBoxTotal.Text = sum.ToString("#.00");
            MessageBox.Show("Thank you for ordering............ \n\n" +"Your Total Amount : "+sum.ToString("#.00")
                + "\nPlease enter the Cash Payment Amount and Confirm it.");
        }

        //######################## CONFIRM ORDER ############################
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            double pym_amount = double.Parse(textBoxCash.Text);
            double total = double.Parse(textBoxTotal.Text);
            double change = pym_amount - total;
            textBoxCash.Text = pym_amount.ToString("#.00");
            textBoxChange.Text = change.ToString("#.00");
        }

        //######################## RESET ############################
        private void Resetcheckbox()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is CheckBox)
                        (control as CheckBox).Checked = false;
                    else
                        func(control.Controls);
            };
            func(Controls);
        }

        private void Resetnumericupdown()
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is NumericUpDown)
                        (control as NumericUpDown).Value = 0;
                    else
                        func(control.Controls);
            };
            func(Controls);
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            Resetcheckbox();
            Resetnumericupdown();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            textBoxTotal.Text = String.Empty;
            textBoxCash.Text = String.Empty;
            textBoxChange.Text = String.Empty;

        }
    }
}
