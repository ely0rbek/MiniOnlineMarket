﻿using CustomerManagement.Domain.Entities.Enums;
using CustomerManagement.Domain.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using System.Text.Json;

namespace CustomerManagement.API.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Enum)]
    public class IdentityFilterAttribute : Attribute, IAuthorizationFilter
    {
        private readonly int _permissionId;
        public IdentityFilterAttribute(Permissions permission)
        {
            _permissionId = (int)permission;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var identity = context.HttpContext.User.Identity as ClaimsIdentity;

            var permissionIds = identity.FindFirst("Permissions")?.Value;

            var result = JsonSerializer.Deserialize<List<int>>(permissionIds).Any(x => _permissionId == x);

            if (!result)
            {
                context.Result = new ForbidResult();
                return;
            }
        }
    }
}
