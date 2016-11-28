using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uygulama.Mobile.Helper;

namespace Uygulama.Mobile.BLL
{
    public class UygulamaBLL
    {
        private readonly  Services _services=new Services();
        public List<Model.Uygulama> List()
        {
            return _services.List().OrderByDescending(o=>o.Date).ToList();
        } 
    }
}
