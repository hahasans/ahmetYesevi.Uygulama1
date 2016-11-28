using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uygulama.Mobile.BLL;
using Xamarin.Forms;

namespace Uygulama.Mobile.UI
{
    public partial class Uygulama : ContentPage
    {
        public Uygulama()
        {
            InitializeComponent();
            List();
        }
        private void List()
        {
            var uygulamaBll=new UygulamaBLL();
            lstUygulama.BindingContext = uygulamaBll.List();
        }

        private void OnRefresh(object sender, EventArgs e)
        {
            List();
            lstUygulama.IsRefreshing = false;
        }
    }
}
