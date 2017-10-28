namespace Employees.Framework.Providers.Contracts
{
    public interface ITeamService
    {
        int CreateNewTeamId();

        void UnionTeamsIntoANewOne(int[] teamsIds, int newTeamId);
    }
}
