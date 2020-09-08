using CrossCutting.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Domain.ViewModels;

namespace UserManagement.Application.Services.Abstraction
{
    public interface IRuleService
    {
        Task<ReturnResult<RuleViewModel>> GetById(Guid ruleId);
        Task<List<RuleViewModel>> GetAll();
        Task<ReturnResult<RuleViewModel>> Add(ReturnResult<RuleViewModel> model);
        Task<ReturnResult<RuleViewModel>> Update(ReturnResult<RuleViewModel> model);
        Task<ReturnResult<Guid>> Delete(ReturnResult<Guid> model);
        Task<RuleFilterViewModel> Search(RuleFilterViewModel model);
    }
}
