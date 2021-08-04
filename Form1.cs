using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;

namespace IP_Viewer
{
    public partial class lblSubnet : Form
    {
        string hostname = Dns.GetHostName();
        NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
        IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();

        public lblSubnet()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblHostname.Text = hostname.ToUpper();

            //var addresses = Dns.GetHostAddresses(Dns.GetHostName());
            var addresses = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var ip in addresses)
            {
                Console.WriteLine(ip.Name.ToString());
                Console.WriteLine(ip.OperationalStatus.ToString());
                
                
                

            }

            int x = 0;
            foreach (NetworkInterface adapter in nics)
            {
                lblGateway.Items.Add("--" + adapter.Name + "--");
                lstSubnet.Items.Add("--" + adapter.Name + "--");
                lblAddress.Items.Add("--" + adapter.Name + "--");

                IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                foreach (var Gateway in adapterProperties.GatewayAddresses) 
                {
                    
                    lblGateway.Items.Add(Gateway.Address.ToString());               
                }
                
                foreach (var Subnet  in adapterProperties.UnicastAddresses)

                {
                    
                    lstSubnet.Items.Add(Subnet.IPv4Mask);
                }
                foreach (var addressip in adapterProperties.UnicastAddresses)
                {
                    
                    lblAddress.Items.Add(addressip.Address);

                }
               
            }

           




        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
