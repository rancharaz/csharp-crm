using System;
using System.Configuration;
using System.Windows.Forms;
using System.Threading;
using jpddoocp.models;
using jpddoocp.controllers;

namespace jpddoocp.views
{
    public partial class SignUpView : Form
    {
        Thread thread;
        MDI mdi;
        public SignUpView(MDI mdi)
        {
            InitializeComponent();
            this.mdi = mdi;
        }
      
        private void btnSignup_Click(object sender, EventArgs e)
        {
            string firstname=txtFirstname.Text.Trim();
            string surname=txtSurname.Text.Trim();
            string address=txtAddress.Text.Trim();
            string username=txtUsername.Text.Trim();
            string pwd=txtPassword.Text.Trim();
            string email=txtEmail.Text.Trim();


            if (pwd==txtConfirmPassword.Text.Trim())
            {
                //Redirect User to Login Form
                new SignupController(firstname, surname, address, username, pwd, email).Signup();
                MessageBox.Show("Registration successful, Please log in.", ConfigurationManager.AppSettings["appName"], MessageBoxButtons.OK, MessageBoxIcon.Warning);

                
                this.Close();
                thread = new Thread(LoadUI);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
            else
            {
                MessageBox.Show("Passwords Unmatched!", ConfigurationManager.AppSettings["appName"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            string appName = ConfigurationManager.AppSettings["appName"];
            this.Text = appName;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetBtnSignupEnabledState(object sender, EventArgs e)
        {
            Boolean state = !txtFirstname.Text.Equals("") &&
                !txtSurname.Text.Equals("") &&
                !txtUsername.Text.Equals("") &&
                !txtPassword.Text.Equals("") &&
                !txtConfirmPassword.Text.Equals("") &&
                !txtEmail.Text.Equals("") ? true : false;
            btnSignup.Enabled = state;
        }
        private void LoadUI()
        {
           
           Application.Run(new LogInView(this.mdi));
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            txtUsername.Text =txtFirstname.Text + txtSurname.Text;
        }
    }
  
}
