using C__SQL_ADO.NET_UI.GeneralProcess;
using C__SQL_ADO.NET_UI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_UI.Action
{
    public abstract class BaseAction:IAction
    {

        public ActionStatus Execute()
        {
            ActionStatus status=OnExecute();

            DeleteHelper.Delete();

            return status;
        }

        public abstract ActionStatus OnExecute();

    }
}
