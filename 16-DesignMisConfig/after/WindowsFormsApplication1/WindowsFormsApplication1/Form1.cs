using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
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
            bool allowedUser = ClientSideCheck();

            if (allowedUser)
            {
                SimpleWCFService.Service1Client ss = new SimpleWCFService.Service1Client();

                string token = ss.Authenticate(tbxUsername.Text, tbxPassword.Text);

                //Token in Message header
                using (OperationContextScope scope = new OperationContextScope(ss.InnerChannel))
                {
                    MessageHeader header = MessageHeader.CreateHeader("Token", "http://tempuri.org/", token);
                    OperationContext.Current.OutgoingMessageHeaders.Add(header);
                    lblResult.Text = ss.GetData(numericUpDown1.Value.ToString());
                }
            }
            else
                lblResult.Text = "Your IP is not allowed or Not authenticated!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool allowedUser = ClientSideCheck();

            if (allowedUser)
            {
                SimpleWCFService.Service1Client ss = new SimpleWCFService.Service1Client();
                //Token in message body
                string token = ss.Authenticate(tbxUsername.Text, tbxPassword.Text);
                lblResult.Text = ss.GetSecretData(numericUpDown1.Value.ToString(), token);
            }
            else
                lblResult.Text = "Your IP is not allowed or Not authenticated!";
        }

        private bool ClientSideCheck()
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

            return allowedIP && allowedUser;
        }
    }
}
