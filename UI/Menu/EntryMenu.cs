using C__SQL_ADO.NET_Application.DTO;
using C__SQL_ADO.NET_Application.InterfaceRepor;
using C__SQL_ADO.NET_Application.Repositories;
using C__SQL_ADO.NET_Application.Services;
using C__SQL_ADO.NET_Application.Session;
using C__SQL_ADO.NET_Domain.Domain;
using C__SQL_ADO.NET_Domain.DomainRule;
using C__SQL_ADO.NET_UI.GeneralProcess;
using C__SQL_ADO.NET_UI.Interface;
using C__SQL_ADO.NET_UI.Menu;
using C__SQL_ADO.NET_UI.ProcessLogin;
using C__SQL_ADO.NET_UI.ProcessRegister;
using C__SQL_ADO.NET_UI.ProcessRegister.ProcessRegister;

class EntryMenu
{
   
       public void Show()
        {

            ActionStatus status=ActionStatus.Continue;

            while (status!=ActionStatus.Exit)
            {
                

                int a = Choosewayofentry.Choose(); 
                 

                var dict = new Dictionary<int, Func<IProcess>>()
                {

                    { 1,()=>new CustomerLogin(new AuthService<Custom>(new AuthCustomerRepor()))},
                    { 2,() => new ManagerLogin(new AuthService<Manager>(new AuthManagerRepor())) },
                    { 3,() => new CustomerRegister(new AuthService<Custom>(new AuthCustomerRepor())) }
                };

                Result<AuthDto>result = dict.TryGetValue(a, out var process) ? dict[a]().Execute() : Result<AuthDto>.Fail("the option that except range");


                if (result.Issuccess)
                {
                      UserSession session = new UserSession(result.Value.id, result.Value.name, result.Value.username, result.Value.Role);
                      MainMenu menu = new MainMenu(session);
                     Console.WriteLine(result.Message);
                     DeleteHelper.Delete();
    
                    status= menu.ShowMenu();
                    
                }
                else
                {
                    Console.WriteLine(result.Message);
                    
                      
                }               
            }

        }
}