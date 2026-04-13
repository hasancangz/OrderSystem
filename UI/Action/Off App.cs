using C__SQL_ADO.NET_UI.GeneralProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__SQL_ADO.NET_UI.Action
{
    internal class Off_App:BaseAction
    {

        public override ActionStatus OnExecute()
        {
            return ActionStatus.Exit;
        }

    }
}
