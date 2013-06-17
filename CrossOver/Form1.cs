using CrossOver.MethodResult;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace CrossOver
{
    public partial class Form1 : Form
    {
        Computer[] allComputers;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FindComputers();
        }

        private void FindComputers()
        {
            try
            {
                //Find prefix
                string localIP = LocalIPAddress();
                string[] values = localIP.Split('.');
                string prefix = values[0] + "." + values[1];

                Computer[] ips = ScanComputers(prefix);
                allComputers = ips;
                foreach (Computer ip in ips)
                {
                    //Check if the port is open

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error while getting local computers. Error: " + e.Message, "Cross Over - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Computer[] ScanComputers(string ipPrefix)
        {
            List<Computer> computers = new List<Computer>();
            for (int i = 0; i <= 255; i++)
            {
                string scanIP = ipPrefix + "." + i.ToString();
                IPAddress myScanIP = IPAddress.Parse(scanIP);
                IPHostEntry myScanHost = null;
                try
                {
                    myScanHost = Dns.GetHostEntry(myScanIP);
                }
                catch
                {
                    continue;
                }
                if (myScanHost != null)
                {
                    computers.Add(new Computer(myScanHost.HostName.ToString(), myScanIP.ToString()));
                }
            }

            return computers.ToArray();
        }

        private string LocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }
    }
}
