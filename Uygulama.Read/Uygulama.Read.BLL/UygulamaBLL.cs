using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uygulama.Read.Helper;
using Uygulama.Read.Model;

namespace Uygulama.Read.BLL
{
    public class UygulamaBLL
    {
        readonly Services _services=new Services();

        public Message Add(Model.Uygulama uygulama)
        {
            return _services.Add(uygulama);
        }
    }
}
