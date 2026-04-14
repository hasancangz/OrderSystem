using C__SQL_ADO.NET_Application.Session;
using C__SQL_ADO.NET_UI.GeneralProcess;
using C__SQL_ADO.NET_UI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_UI.Menu
{
    public abstract class BaseMenu
    {
        public int Selection { get; set; }
        public UserSession Session { get; }

        public Dictionary<int, Func<IAction>> privatedict { get; set; }

        public ActionStatus baseMenu()
        {
            ActionStatus status = ActionStatus.Continue;

            while (status == ActionStatus.Continue)
            {
                status = privatedict[PrivateMenu()]().Execute();
            }
            return status;
        }



         public BaseMenu(UserSession session1)
        {
            this.Session = session1;
        }

        public abstract int PrivateMenu();

    }
}
