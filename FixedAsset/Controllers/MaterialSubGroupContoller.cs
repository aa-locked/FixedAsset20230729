using FixedAsset.DataAccess.Data;
using FixedAsset.Model.Domain.MaterialGroup;
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
            ViewBag.MtrlGroup = abc;
            ViewData["ABC"]=abc;
            return View();
        }
        [HttpPost]
        public IActionResult Create(TFAMtrlSubGrp tFAMtrlSubGrp)
        {
            if (ModelState.IsValid == true)
            {
                _fixedAssetDBContext.tFAMtrlSubGrp.Add(tFAMtrlSubGrp);
                _fixedAssetDBContext.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }

    }
}
