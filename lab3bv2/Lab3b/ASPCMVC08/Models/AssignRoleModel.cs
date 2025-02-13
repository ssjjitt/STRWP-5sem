﻿using Microsoft.AspNetCore.Identity;
namespace ASPCMVC08.Models;

public class AssignRoleModel
{
    public IEnumerable<RUser> Users { get; init; }
    public IEnumerable<IdentityRole> Roles { get; init; }

    public AssignRoleModel()
    {
        Users = new List<RUser>();
        Roles = new List<IdentityRole>();
    }

    public AssignRoleModel(IEnumerable<RUser> users, IEnumerable<IdentityRole> roles)
    {
        Users = users;
        Roles = roles;
    }
}
