using Client.WebApi;
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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            if (username == "")
            {
                return;
            }
            string password = txtPassword.Text.Trim();
            if (password == "")
            {
                return;
            }
            this.Enabled = false;
            var token = new DWebApi().GetToken(username, password, out string message);
            this.Enabled = true;
            if (token == null)
            {
                return;
            }
            if (token.access_token == null)
            {
                MessageBox.Show(token.error + ":" + token.error_description);
                return;
            }
            UserClient.Client.Login(token.token_type, token.access_token);
            Program.StatusCode = 1;
            DialogResult = DialogResult.OK;
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.StatusCode == 1)
            {
                Properties.Settings.Default.Save();
            }
        }
    }
}
