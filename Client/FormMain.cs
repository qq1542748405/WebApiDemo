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
    public partial class FormMain : Form
    {
        private List<Order> orders;

        public FormMain()
        {
            InitializeComponent();
            comIsShipped.SelectedIndex = 0;
            dtpEnd.Value = DateTime.Now.AddDays(1).Date;
            dtpStart.Value = DateTime.Now.AddDays(-1).Date;
        }

        private int page = 1;

        private int pageSize = 2;

        private void btnSelect_Click(object sender, EventArgs e)
        {
            page = 1;
            SelectOrder();
        }

        private void SelectOrder()
        {
            splitContainer1.Panel1.Enabled = false;
            var order = new OrderInfo
            {
                CustomerName = txtCustomerName.Text.Trim(),
                ShipperCity = txtShipperCity.Text.Trim(),
                ShipState = comIsShipped.SelectedIndex - 1,
                PageIndex = page,
                PageSize = pageSize,
                StartTime = dtpStart.Value,
                EndTime = dtpEnd.Value,
            };
            var info = new DWebApi().GetOrders(order, out string message);
            orders = info.Orders;
            splitContainer1.Panel1.Enabled = true;
            dataGridView1.DataSource = orders;
            page = info.PageIndex;
            lbPageIndex.Text = $"第 {info.PageIndex} 页，共 {info.MaxPageIndex} 页，共 {info.TotalCount} 条";
            btnNextPage.Enabled = page < info.MaxPageIndex;
            btnPreviousPage.Enabled = page > 1;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            FormCreateOrder form = new FormCreateOrder();
            if (form.ShowDialog() == DialogResult.OK)
            {
                btnSelect_Click(this, null);
            }
            //var order = new Order
            //{

            //};
            //OrderedEnumerableRowCollection= new DWebApi().CreateOder();
        }

        private void 删除订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (orders == null || orders.Count == 0)
            {
                return;
            }
            if (dataGridView1.SelectedCells.Count > 0 && dataGridView1.SelectedCells[0].ColumnIndex == 0 && dataGridView1.SelectedCells[0].RowIndex > -1)
            {
                //int index = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
                splitContainer1.Panel1.Enabled = false;
                var order = new DWebApi().DeleteOder(orders[dataGridView1.SelectedCells[0].RowIndex].Id, out string message);
                splitContainer1.Panel1.Enabled = true;
                btnSelect_Click(this, null);
            }
        }

        private void 编辑订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (orders == null || orders.Count == 0)
            {
                return;
            }
            if (dataGridView1.SelectedCells.Count > 0 && dataGridView1.SelectedCells[0].ColumnIndex == 0 && dataGridView1.SelectedCells[0].RowIndex > -1)
            {
                FormUpdateOrder form = new FormUpdateOrder(orders[dataGridView1.SelectedCells[0].RowIndex]);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    btnSelect_Click(this, null);
                }
            }
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            page--;
            SelectOrder();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            page++;
            SelectOrder();
        }
    }
}
