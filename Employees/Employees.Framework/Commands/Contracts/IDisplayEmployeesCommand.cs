namespace Employees.Framework.Commands.Contracts
{
    public interface IDisplayEmployeesCommand
    {
        void DisplayEmployeesByTeamId(int? teamsId);

        void DisplayEmployeesWithoutATeam();

        void DisplayTeamsFilteredByLanguage(string language);

        void DisplayTeamsFilteredByClient(string client);

        void DisplayModifyEmloyeeTeamResult(int employeeId, int newTeamId);

        void DisplayUnionTeamsResult(int[] teamIds);
    }
}
