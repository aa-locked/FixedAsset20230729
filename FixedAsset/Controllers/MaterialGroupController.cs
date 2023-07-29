using FixedAsset.DataAccess.Data;
using FixedAsset.Model.Domain.MaterialGroup;
using Microsoft.AspNetCore.Mvc;

namespace FixedAsset.Controllers
{
    public class MaterialGroupController : Controller
    {
        private readonly FixedAssetDBContext _fixedAssetDBContext;

        public MaterialGroupController(FixedAssetDBContext fixedAssetDBContext)
        {
            _fixedAssetDBContext = fixedAssetDBContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TFAMtrlGrp tFAMtrlGrp)
        {

            if(tFAMtrlGrp.GrpDesc.ToLower().ToString()== tFAMtrlGrp.GrpShortDesc.ToLower().ToString())
            {
                ModelState.AddModelError("", "Group Desc Cannot Be Same As Short Desc!");

                //ModelState.AddModelError("GrpShortDesc", "Group Desc Cannot Be Same As Short Desc!");
            }

            if (ModelState.IsValid == true)
            {
                _fixedAssetDBContext.tFAMtrlGrp.Add(tFAMtrlGrp);
                _fixedAssetDBContext.SaveChanges();
                return RedirectToAction("Index", "MaterialGroup");

            }

            return View();


        }
    }
}
