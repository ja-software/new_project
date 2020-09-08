using UserManagement.Domain.Models;
using UserManagement.Domain.ViewModels;

namespace UserManagement.Domain.Mapper
{
    public static class RuleMapper
    {
        public static Rule MapToModel(RuleViewModel viewModel)
        {
            if (viewModel == null) return null;

            var rule = new Rule(viewModel.Name);
            rule.Description = viewModel.Description;
            rule.Folowed = viewModel.Folowed;
            if (viewModel.Id.HasValue)
                rule.Id = viewModel.Id.Value;

            return rule;
        }

        public static RuleViewModel MapToViewModel(Rule model)
        {
            if (model == null) return null;

            return new RuleViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Folowed = model.Folowed
            };
        }
    }
}