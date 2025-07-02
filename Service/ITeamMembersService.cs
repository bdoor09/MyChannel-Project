using MyChannel.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Core.Service
{
    public interface ITeamMembersService
    {
        List<Teammember> GetAllTeam();

        Teammember GetTeamById(int id);

        void CreateTeam(Teammember teammember);

        void UpdateTeam(Teammember teammember);

        Teammember DeleteTeam(int id);

    }
}
