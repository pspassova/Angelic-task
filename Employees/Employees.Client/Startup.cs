using Employees.Framework.Commands.Contracts;
using Ninject;

namespace Employees.Client
{
    public static class Startup
    {
        public static void Main()
        {
            IKernel kernel = new StandardKernel(new EmployeesModule());

            IDisplayEmployeesCommand employeesCommandDisplayer = kernel.Get<IDisplayEmployeesCommand>();

            #region Test calls
            //int teamId = 30;
            //employeesCommandDisplayer.DisplayEmployeesByTeamId(teamId);

            //int employeeId = 1;
            //int newTeamId = 22;
            //employeesCommandDisplayer.DisplayModifyEmloyeeTeamResult(employeeId, newTeamId);
            //employeesCommandDisplayer.DisplayEmployeesByTeamId(teamId);

            //employeesCommandDisplayer.DisplayEmployeesWithoutATeam();

            //string language = "Bulgarian";
            //employeesCommandDisplayer.DisplayTeamsFilteredByLanguage(language);

            //string client = "Yakidoo";
            //employeesCommandDisplayer.DisplayTeamsFilteredByClient(client);

            //int[] teamsIds = new int[] { 30, 44 };
            //employeesCommandDisplayer.DisplayUnionTeamsResult(teamsIds);
            #endregion
        }
    }
}
