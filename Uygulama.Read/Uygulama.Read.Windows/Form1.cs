using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Uygulama.Read.BLL;

namespace Uygulama.Read.Windows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private SerialPort sp;
        private readonly UygulamaBLL _uygulamaBll=new UygulamaBLL();

        private void Sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string veri = sp.ReadLine();
            this.BeginInvoke(new LineReceivedEvent(LineReceived), veri);
        }

        private delegate void LineReceivedEvent(string veri);

        private void LineReceived(string veri)
        {
            var aralık = Convert.ToInt32(nudAralık.Text);
            var parse = veri.Split('=')[1];
            var data = parse.Substring(0, parse.Length - 2);
            lstValue.Items.Insert(0,data);
            var uygulama = new Model.Uygulama
            {
                Data=data,
                Date=DateTime.Now
            };
            _uygulamaBll.Add(uygulama);
            Thread.Sleep(aralık*1000);
        }
        private void btnRead_Click(object sender, EventArgs e)
        {
            sp = new SerialPort(txtPort.Text, 9600);
            sp.Open();
            sp.DataReceived += Sp_DataReceived;
        }
    }
}
