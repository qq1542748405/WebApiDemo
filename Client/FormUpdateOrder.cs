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
    public partial class FormUpdateOrder : Form
    {
        private Order order;

        public FormUpdateOrder()
        {
            InitializeComponent();
        }

        public FormUpdateOrder(Order order) : this()
        {
            this.order = order;
            txtCustomerName.Text = order.CustomerName;
            txtShipperCity.Text = order.ShipperCity;
            comIsShipped.SelectedIndex = Convert.ToInt32(order.IsShipped);
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
            if (comIsShipped.SelectedIndex < 0)
            {
                return;
            }
            var isShipped = Convert.ToBoolean(comIsShipped.SelectedIndex);
            var phoneNumber = txtPhoneNumber.Text.Trim();
            if (phoneNumber == "")
            {
                return;
            }
            order.CustomerName = customerName;
            order.ShipperCity = shipperCity;
            order.IsShipped = isShipped;
            order.PhoneNumber = phoneNumber;
            this.Enabled = false;
            order = new DWebApi().UpdateOder(order, out string message);
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
