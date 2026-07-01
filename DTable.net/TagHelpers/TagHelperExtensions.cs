using DvStyle.Memory.Resources.Enums;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DvStyle.Memory.DataLayer.Identity;

namespace TagHelpers
{
    public static class TagHelperExtensions 
    {
        public static string OperationRessourceKey = "OperationRessource";

        public static bool HasKey(this TagHelperContext context, string key)
        {
            return context.Items.ContainsKey(key);
        }

        public static T GetValue<T>(this TagHelperContext context, string key)        
        {
            if (context.HasKey(key))
            {
                context.Items.TryGetValue(key, out object val);
                return (T)val;
            }
            return default(T);
        }

        public static bool CheckUserPermissionAccess(this TagHelperContext context,  OperationAction operation, ClaimsPrincipal User)
        {
            if (context.HasKey(OperationRessourceKey)){

                var ressource = context.GetValue<OperationRessource>(OperationRessourceKey);
                return User.UserHasPermissionFor(ressource, operation);
            }
            return false;
        }

        public static bool CheckUserPermissionAccess(this TagHelperContext context, OperationAction operation, OperationRessource operationRessource ,ClaimsPrincipal user)
        {
            return user.UserHasPermissionFor(operationRessource, operation);
        }
    }
}
