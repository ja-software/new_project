using CrossCutting.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Application.Persistance;
using UserManagement.Application.Services.Abstraction;
using UserManagement.Domain.Mapper;
using UserManagement.Domain.Models;
using UserManagement.Domain.ViewModels;
using RuleManagementResources = UserManagement.Localization.RulesManagement.RulesManagement;

namespace UserManagement.Application.Services.Concrete
{
    public class RuleService : IRuleService
    {
        public RuleService(Rule ruleManager, IUserManagementUnitOfWork userManagementUnitOfWork)
        {
            RuleManager = ruleManager;
            UserManagementUnitOfWork = userManagementUnitOfWork;
        }

        public Rule RuleManager { get; }
        public IUserManagementUnitOfWork UserManagementUnitOfWork { get; }

        public async Task<ReturnResult<RuleViewModel>> GetById(Guid ruleId)
        {
            ReturnResult<RuleViewModel> result = new ReturnResult<RuleViewModel>();

            var rule = await UserManagementUnitOfWork.RuleRepository.GetByIdAsync(ruleId);
            result.Value = rule;

            

            return result;

        }

        public async Task<List<RuleViewModel>> GetAll()
        {
            return (await UserManagementUnitOfWork.RuleRepository.GetAsync())
                    .Select(rule => RuleMapper.MapToViewModel(rule)).ToList();
            
        }

        public async Task<ReturnResult<RuleViewModel>> Add(ReturnResult<RuleViewModel> model)
        {
            var result = await UserManagementUnitOfWork.RuleRepository.CreateAsync(model.Value);

            if (!result.Succeeded)
            {
                result.Errors.ToList().ForEach(error =>
                {
                    model.AddErrorItem("", $"{error.Code} : {error.Description}");
                });
            }

            return model;
        }

        public async Task<ReturnResult<RuleViewModel>> Update(ReturnResult<RuleViewModel> model)
        {
            var rule = await UserManagementUnitOfWork.RuleRepository.FindByIdAsync(model.Value.Id.ToString());
            rule.Name = model.Value.Name;

            var result = await UserManagementUnitOfWork.RuleRepository.UpdateAsync(rule);

            if (!result.Succeeded)
            {
                result.Errors.ToList().ForEach(error =>
                {
                    model.AddErrorItem("", $"{error.Code} : {error.Description}");
                });
            }

            return model;
        }

        public async Task<ReturnResult<Guid>> Delete(ReturnResult<Guid> model)
        {
            var rule = await UserManagementUnitOfWork.RuleRepository.FindByIdAsync(model.Value.ToString());

            
            if (model.IsValid)
            {
                var result = await UserManagementUnitOfWork.RuleRepository.DeleteAsyncNew(rule);

                if (!result.Succeeded)
                {
                    result.Errors.ToList().ForEach(error =>
                    {
                        model.AddErrorItem("", $"{error.Code} : {error.Description}");
                    });
                }
            }

            return model;
        }
        
        public async Task<RuleFilterViewModel> Search(RuleFilterViewModel model)
        {
            var query = UserManagementUnitOfWork.RuleRepository.GetQuery(m=>m.Name.Contains(model.Name.ToLower()));

            if (!string.IsNullOrEmpty(model.Name))
                query = query.Where(m => m.Name.Contains(model.Name.ToLower()));

            List<RuleViewModel> items = new List<RuleViewModel>();

            model.TotalCount = query.Count();
            if (model.jtPageSize > 0)
                items = await query.Skip((int)(model.PageNumber * model.jtPageSize)).Take((int)model.jtPageSize)
                    .Select(role => RuleMapper.MapToViewModel(role)).ToListAsync();
            else
                items = await query.Select(role => RuleMapper.MapToViewModel(role)).ToListAsync();

            model.Items = items;

            return model;
        }

    
    }
}
