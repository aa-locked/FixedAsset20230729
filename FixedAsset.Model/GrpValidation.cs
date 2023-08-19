using FixedAsset.Model.Domain.MaterialGroup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FixedAsset.Model
{
    public class GrpValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var subgroup = (TFAMtrlSubGrp)validationContext.ObjectInstance;

            if (subgroup.SubGrpDesc.ToString().ToLower() == subgroup.SubGrpShortDesc.ToString().ToLower())
            {
                return new ValidationResult("Both Cannot Be Same!");
            }
            return ValidationResult.Success;
        }
    }
}
