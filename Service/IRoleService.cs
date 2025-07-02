﻿using MyChannel.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Core.Service
{
    public interface IRoleService
    {
        List<Role> GetallRole();
        void CreateRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(int id);
        Role GetRoleById(int id);
    }
}
