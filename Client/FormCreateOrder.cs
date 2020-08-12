using Client.WebApi;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class FormCreateOrder : Form
    {
        public FormCreateOrder()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.Cancel;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var customerName = txtCustomerName.Text.Trim();
            if (customerName == "")
            {
                return;
            }
            var shipperCity = txtShipperCity.Text.Trim();
            if (shipperCity == "")
            {
                return;
            }
            Order order = new Order
            {
                CustomerName = customerName,
                ShipperCity = shipperCity,
                PhoneNumber = "123",
            };
            this.Enabled = false;
            order = new DWebApi().CreateOder(order, out string message);
            this.Enabled = true;
            if (order == null)
            {
                MessageBox.Show(message);
                return;
            }
            DialogResult = DialogResult.OK;
        }
    }
}
