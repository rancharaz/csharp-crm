using System;
using System.Configuration;
using System.Windows.Forms;
using jpddoocp.controllers;
using jpddoocp.models;
using System.Drawing;
using System.Threading;
namespace jpddoocp.views
{
    public partial class LogInView : Form
    {
        Thread thread;
        MDI mdi;
        public LogInView(MDI mdi)
        {
            InitializeComponent();
            this.mdi = mdi;
            this.mdi.LogingIn();
        }

        private void LogInView_Load(object sender, EventArgs e)
        {
            string appName = ConfigurationManager.AppSettings["appName"];
            this.Text = appName;
            txtUsername.Text = "jtalbot";
            txtPwd.Text = "123456";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String username = txtUsername.Text.Trim();
            String password = txtPwd.Text.Trim();
            AuthController auth = new AuthController(username, password);
            if (auth.Authenticate())
            {
                //log in user
                mdi.LoggedIn();

                this.Close();
                thread = new Thread(LoadUI);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            else
            {
                MessageBox.Show("Wrong Credentials", ConfigurationManager.AppSettings["appName"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetBtnLoginEnabledState()
        {
            Boolean state = !txtUsername.Text.Equals("") && !txtPwd.Text.Equals("") ? true : false;
            btnLogin.Enabled = state;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            SetBtnLoginEnabledState();
        }

        private void txtPwd_TextChanged(object sender, EventArgs e)
        {
            SetBtnLoginEnabledState();
        }

        private void txtUsername_MouseEnter(object sender, EventArgs e)
        {
            txtUsername.BackColor = Color.OrangeRed;
            txtPwd.BackColor = Color.Crimson;
        }

        private void txtPwd_MouseEnter(object sender, EventArgs e)
        {
            txtUsername.BackColor = Color.Crimson; 
            txtPwd.BackColor = Color.OrangeRed;
        }
        private void LoadUI()
        {
          
           // Application.Run(new SignUpView());
        }
    }
}
