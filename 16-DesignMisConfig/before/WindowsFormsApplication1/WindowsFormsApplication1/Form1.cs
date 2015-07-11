using System;
using System.Net;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            string host = Dns.GetHostName();
            IPHostEntry ip = Dns.GetHostEntry(host);

            bool allowedIP = false;

            bool allowedUser = false;

            foreach (IPAddress i in ip.AddressList)
            {
                if (i.ToString() == "172.16.52.210")
                {
                    allowedIP = true;
                    break;
                }
            }

            if (tbxUsername.Text == "candan" && tbxPassword.Text == "password")
                allowedUser = true;

            if (allowedIP && allowedUser)
            {

                SimpleWCFService.Service1Client ss = new SimpleWCFService.Service1Client();
                lblResult.Text = ss.GetData(numericUpDown1.Value.ToString());
            }
            else
                lblResult.Text = "Your IP is not allowed or Not authenticated!";
        }
    }
}
