﻿namespace UserManagement.Application
{
    public class NavigationConstants
    {
        public const string Area = "UserManagementAdmin";
        public class Pages
        {
            public const string Dashboard = "/Index";

            public const string PolicyCreate = "/Policies/Create";
            public const string PolicyDisplay = "/Policies/Display";
            public const string PolicyEdite = "/Policies/Edite";
            public const string PolicyIndex = "/Policies/Index";
            public const string ApplyPolicies = "/Policies/ApplyPolicies";
            public const string ApplyPoliciesMessage = "/Policies/ApplyPoliciesMessage";

            public const string RoleCreate = "/Roles/Create";
            public const string RoleDisplay = "/Roles/Display";
            public const string RoleEdite = "/Roles/Edite";
            public const string RoleIndex = "/Roles/Index";

            public const string SettingsAuthentication = "/Settings/Authentication";
            public const string SettingsSmpt = "/Settings/SmptSettings";

            public const string UserChangePassword = "/Users/ChangePassword";
            public const string UserCreate = "/Users/Create";
            public const string UserDisplay = "/Users/Display";
            public const string UserEdite = "/Users/Edite";
            public const string UserIndex = "/Users/Index";

        }
    }
}
