using CrossCutting.Persistance;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagement.Domain.Models;

namespace UserManagement.Application.Persistance.Abstraction
{
    public interface IRuleRepository : IRepository<Rule>
    {
    }
}
