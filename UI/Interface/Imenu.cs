using C__SQL_ADO.NET_Application.Session;
using C__SQL_ADO.NET_UI.GeneralProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_UI.Interface
{
    public interface Imenu
    {
        ActionStatus PrivateMenu(UserSession session);
       
    }
}
