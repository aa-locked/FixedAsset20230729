using FixedAsset.Model.Domain.MaterialGroup;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedAsset.Model.ViewModels
{
    public class VM_MtrlSubGrp
    {
        public TFAMtrlSubGrp TFAMtrlSubGrp { get; set; }    
        public IEnumerable<SelectListItem> MtrlGrpList { get; set; }    
    }
}
