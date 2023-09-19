using Microsoft.AspNetCore.Mvc;
using CountryMasterForm.Models;
namespace CountryMasterForm.Controllers
{
    public class CategoryController : Controller
    {

        /// <summary>
        /// F for Controller
        /// </summary>
        /// <returns></returns
        public IActionResult Category()
        {
            Category objcagegory = new Category();
            try
            {
                return View(objcagegory);
            }
            catch (Exception ex)
            {
                objcagegory.responsecode = -1;
                objcagegory.responseMessage = "Something Went Wrong..!";
                return Json(objcagegory);
            }
        }

        /// <summary>
        /// Accepting Details of obj and pass to Model/View
        /// </summary>
        /// <param name="objDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Category(Category objDetails)
        {
            try
            {
                objDetails.responsecode = objDetails.SaveOrUpdateDetails(objDetails);
                return View(objDetails);
            }
            catch (Exception ex)
            {
                objDetails.responsecode = -1;
                objDetails.responseMessage = "Something Went Wrong..!";
                return Json(objDetails);
            }
        }

        /// <summary>
        /// Binding for grid Datatable
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCategoryDataTable()
        {
            Category objDt = new Category();
            try
            {
                return Json(new { data = objDt.FetchCategorydt() });
            }
            catch (Exception ex)
            {
                objDt.responsecode = -1;
                objDt.responseMessage = "Something Went Wrong..!";
                return Json(objDt);
            }
        }
    }
}
