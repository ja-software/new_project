using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UserManagement.Domain.Mapper;
using UserManagement.Domain.Models;

namespace UserManagement.Domain.ViewModels
{
    public class RuleViewModel
    {
        public Guid? Id { set; get; }

        [Required]
        public string Name { set; get; }
        [Required]
        public string Description { set; get; }
        public bool Folowed { get; set; }

        public static implicit operator RuleViewModel(Rule model)
        {
            return RuleMapper.MapToViewModel(model);
        }
        public static implicit operator Rule(RuleViewModel model)
        {
            return RuleMapper.MapToModel(model);
        }

        
    }
}
