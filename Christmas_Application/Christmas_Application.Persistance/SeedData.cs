﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using UserManagement.Domain.Models;

namespace UserManagement.Persistance
{
    public static class SeedData
    {

        static Guid AdminRoleId => new Guid("6df194b0-63cd-48a6-60a0-08d7f4f81cd6");
        static Guid UserRoleId => new Guid("018593e5-d1ec-42dc-60a1-08d7f4f81cd6");
        static Guid AdminUserId => new Guid("89f5e7cd-2cdf-4fbd-dd51-08d7f4f81e85");

        public static ModelBuilder SeedGender(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>().HasData(new Gender { Id = (int)Enumerations.GenderEnum.Male, Name = Enumerations.GenderEnum.Male.ToString() });
            modelBuilder.Entity<Gender>().HasData(new Gender { Id = (int)Enumerations.GenderEnum.Female, Name = Enumerations.GenderEnum.Female.ToString() });

            return modelBuilder;
        }
        public static ModelBuilder SeedDefaultRole(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole
            {
                Id = AdminRoleId,
                Name = "Admins",
                NormalizedName = "ADMINS",
                ConcurrencyStamp = "9d3fc107-acf1-45e9-ad14-41a23c5f96da"
            });
            modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole
            {
                Id = UserRoleId,
                Name = "Users",
                NormalizedName = "USERS",
                ConcurrencyStamp = "87b55c4d-6c11-4f51-a602-07f30420e813"
            });
            return modelBuilder;
        }

        public static ModelBuilder SeedDefaultUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = AdminUserId,
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAENRpmAztefZfDZELUGslmddk8qyx8PQb5ku2yWlqkgMvnhWODmaqWqORwfZF1yMC4w==",
                SecurityStamp = "M5NDORJRS6LNKXZZG2PFMCAOD34OZUPI",
                ConcurrencyStamp = "099835ee-d89c-49a7-a24a-948817385cf1",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                CreatedOn = DateTime.Now,
                FirstName = "Admin",
                MiddleName = "",
                LastName = "",
                BirthDate = DateTime.Now,
                PhoneNumber = "00000000",
                Email = "Admin@Admin.com",
                Address = ""
            });

            return modelBuilder;
        }

        public static ModelBuilder SeedDefaultUserRole(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = AdminRoleId,
                UserId = AdminUserId
            });
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = UserRoleId,
                UserId = AdminUserId
            });

            return modelBuilder;
        }

        public static ModelBuilder SeedDefaultPolicies(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationPolicy>().HasData(new ApplicationPolicy
            {
                Id = 1,
                Name = "AdminPolicy"
            });
            modelBuilder.Entity<ApplicationPolicy>().HasData(new ApplicationPolicy
            {
                Id = 2,
                Name = "UserPolicy"
            });

            modelBuilder.Entity<ApplicationPolicyRole>().HasData(new ApplicationPolicyRole
            {
                Id = 1,
                ApplicationPolicyId = 1,
                ApplicationRoleId = AdminRoleId
            });
            modelBuilder.Entity<ApplicationPolicyRole>().HasData(new ApplicationPolicyRole
            {
                Id = 2,
                ApplicationPolicyId = 1,
                ApplicationRoleId = UserRoleId
            });

            modelBuilder.Entity<ApplicationPolicyRole>().HasData(new ApplicationPolicyRole
            {
                Id = 3,
                ApplicationPolicyId = 2,
                ApplicationRoleId = UserRoleId
            });
            return modelBuilder;
        }
    }

}
