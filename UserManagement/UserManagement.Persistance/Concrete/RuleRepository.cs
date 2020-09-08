using CrossCutting.Persistance.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Application.Persistance.Abstraction;
using UserManagement.Domain.Models;

namespace UserManagement.Persistance.Concrete
{
    public sealed class RuleRepository : Repository<Rule>, IRuleRepository
    {
        public RuleRepository(ApplicationDbContext context)
            : base(context)
        {
            Context = context;
        }

        public ApplicationDbContext Context { get; }
    }
}
