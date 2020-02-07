using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;
using Microsoft.Data.Sqlite;

namespace MultiSSH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private ConnectionInfo SSHconnection(string host, string username, string password)
        {
            ConnectionInfo ConnNfo = new ConnectionInfo(host, 22, username,
                new AuthenticationMethod[]{
                    new PasswordAuthenticationMethod(username,password),
                }
            );

            return ConnNfo;
        }

        private void SSHexecution(ConnectionInfo ConnNfo, string Command)
        {
            using (var sshClient = new SshClient(ConnNfo))
            {
                sshClient.Connect();
                sshClient.CreateCommand(Command);
                sshClient.Disconnect();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "MultiSSH";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectionInfo ConnInfo = SSHconnection("dock2.thy-it.com", "root", "Ert67yu89io");
            SSHexecution(ConnInfo, "whoami");
        }
    }
}
