using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Configuration;
using System.Windows.Forms;
using System.Drawing;
using jpddoocp.views;
using jpddoocp.controllers;

namespace jpddoocp
{
    public partial class MDI : Form
    {
        public MDI()
        {
            InitializeComponent();
        }

        private void MDI_Load(object sender, EventArgs e)
        {
            string appName = ConfigurationManager.AppSettings["appName"];
            this.Text = appName;
            this.BackColor = Color.Crimson;
        }

        private void logInAccountMenu_Click(object sender, EventArgs e)
        {
            CloseChildForm();
            LogInView logInView = new LogInView(this);
            logInView.MdiParent = this;
            logInView.Show();
            logInView.BringToFront();

        }
        private void CloseChildForm()
        {
            Form activeForm = this.ActiveMdiChild;
            if (activeForm != null)
                ActiveMdiChild.Close();
        }

        private void signUpAccountMenu_Click(object sender, EventArgs e)
        {
            CloseChildForm();
            SignUpView signUpView = new SignUpView(this);
            signUpView.MdiParent = this;
            signUpView.Show();
            signUpView.BringToFront();
        }

        private void databaseSetupMenu_Click(object sender, EventArgs e)
        {
            new DbSetupController();
        }
        public void LogingIn()
        {
            logInAccountMenu.Visible = false;
            logOutAccountMenu.Visible = false;
            signUpAccountMenu.Visible = true;
            setupMenu.Visible = true;
        }
        public void LoggedIn()
        {
            logInAccountMenu.Visible = false;
            logOutAccountMenu.Visible = true;
            signUpAccountMenu.Visible = false;
            setupMenu.Visible = false;
        }
        public void Lauch()
        {
            logInAccountMenu.Visible = true;
            logOutAccountMenu.Visible = false;
            signUpAccountMenu.Visible = true;
            setupMenu.Visible = true;
        }

        private void logOutAccountMenu_Click(object sender, EventArgs e)
        {
            CloseChildForm();
            Lauch();
        }
    }
}
