using FixedAsset.DataAccess.Data;
using FixedAsset.Model.Domain.MaterialGroup;
using FixedAsset.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FixedAsset.Controllers
{
    public class MaterialSubGroupController : Controller
    {
        private readonly FixedAssetDBContext _fixedAssetDBContext;

        public MaterialSubGroupController(FixedAssetDBContext fixedAssetDBContext)
        {
            _fixedAssetDBContext = fixedAssetDBContext;
        }

        public IActionResult Create()
        {
            IEnumerable<SelectListItem> abc = _fixedAssetDBContext.tFAMtrlGrp.Select(u => new SelectListItem()
            {
                Value = u.FAMtrlGrpId.ToString(),
                Text = u.GrpDesc.ToString()
            });
            //ViewBag.MtrlGroup = abc;
            //ViewData["ABC"]=abc;


            VM_MtrlSubGrp MtrlSubGrp= new VM_MtrlSubGrp();
            MtrlSubGrp.MtrlGrpList=abc;
            MtrlSubGrp.TFAMtrlSubGrp = new TFAMtrlSubGrp();


            return View(MtrlSubGrp);
        }
        [HttpPost]
        public IActionResult Create(VM_MtrlSubGrp tFAMtrlSubGrp)
        {
            if (ModelState.IsValid == true)
            {
                //_fixedAssetDBContext.tFAMtrlSubGrp.Add(tFAMtrlSubGrp);
                //_fixedAssetDBContext.SaveChanges();
                return RedirectToAction("Index");

            }
            IEnumerable<SelectListItem> abc = _fixedAssetDBContext.tFAMtrlGrp.Select(u => new SelectListItem()
            {
                Value = u.FAMtrlGrpId.ToString(),
                Text = u.GrpDesc.ToString()
            });
            
            tFAMtrlSubGrp.MtrlGrpList = abc;
            return View(tFAMtrlSubGrp);
        }

    }
}
