using FixedAsset.DataAccess.Data;
using FixedAsset.Model.Domain.MaterialGroup;
using FixedAsset.Model.DTO;
using FixedAsset.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Xml.Linq;

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
            //var result = _fixedAssetDBContext.tFAMtrlGrp.ToList();
            //return View(result);

            List<MtrlGrpDTO> objMtrlGrp = new List<MtrlGrpDTO>();
            string apiUrl = "https://localhost:7161/api/MatreialGroup";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(apiUrl ).Result;
            if (response.IsSuccessStatusCode)
            {
                objMtrlGrp = JsonConvert.DeserializeObject<List<MtrlGrpDTO>>(response.Content.ReadAsStringAsync().Result);
            }

            return View(objMtrlGrp);



        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(GetMtrlGrpDto FAMtrlDto)
        {

            ////if (tFAMtrlGrp.GrpDesc.ToLower().ToString() == tFAMtrlGrp.GrpShortDesc.ToLower().ToString())
            ////{
            ////    ModelState.AddModelError("", "Group Desc Cannot Be Same As Short Desc!");
            ////}
            //if (ModelState.IsValid == true)
            //{
            //    //_fixedAssetDBContext.tFAMtrlGrp.Add(tFAMtrlGrp);
            //    //_fixedAssetDBContext.SaveChanges();
            //    return RedirectToAction("Index", "MaterialGroup");

            //}


            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7161/api/");

            TFAMtrlGrp a = new TFAMtrlGrp() { GrpDesc="abc",GrpShortDesc="DEF" };


            HttpContent body = new StringContent(JsonConvert.SerializeObject(FAMtrlDto), Encoding.UTF8, "application/json");
            var response = client.PostAsync("MatreialGroup", body).Result;

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                //if (!string.IsNullOrEmpty(content))
                //{
                //    var objDeserializeObject = JsonConvert.DeserializeObject<VM_MtrlSubGrp>(content);

                //    Console.WriteLine("Data Saved Successfully.");

                //    if (objDeserializeObject != null)
                //    {
                //        Console.WriteLine(objDeserializeObject.TFAMtrlSubGrp);
                //    }
                //}
            }
            TempData["error"] = "Material Group Created Successfully";

            return View();
        }

        public IActionResult Edit(int famtrlGrpId)
        {
            var result = _fixedAssetDBContext.tFAMtrlGrp.FirstOrDefault(x => x.FAMtrlGrpId == famtrlGrpId);
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(TFAMtrlGrp tFAMtrlGrp)
        {
            if(ModelState.IsValid)
            {
                _fixedAssetDBContext.tFAMtrlGrp.Update(tFAMtrlGrp);
                _fixedAssetDBContext.SaveChanges();
                return RedirectToAction("Index", "MaterialGroup");
            }
            return View();
        }

        public IActionResult Delete(int famtrlGrpId)
        {
            var result = _fixedAssetDBContext.tFAMtrlGrp.FirstOrDefault(x => x.FAMtrlGrpId == famtrlGrpId);
            _fixedAssetDBContext.tFAMtrlGrp.Remove(result);
            _fixedAssetDBContext.SaveChanges();
            return RedirectToAction("Index", "MaterialGroup");
        }

        #region APIregion

        [HttpGet]
        public IActionResult GetAllGrp()
        {
            var result = _fixedAssetDBContext.tFAMtrlGrp.ToList();
            return Json(result);
        }
        #endregion


    }
}
