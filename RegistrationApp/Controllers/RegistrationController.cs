using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RegistrationApp_BL.Repository;
using RegistrationApp_DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationApp.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IRegistrationRepository _iRegistrationRepository;
        public RegistrationController(IRegistrationRepository paramRegistrationRepository)
        {
            _iRegistrationRepository = paramRegistrationRepository;
        }
        public async Task<IActionResult> Index()
        {
            ResponseModel<RegistrationModel> _ResponseModel;
            _ResponseModel = await _iRegistrationRepository.registrationList();
            return View(_ResponseModel.ListResult);
        }

        public async Task<ActionResult> AddRegistration(int paramRegisterID)
        {
            ViewBag.vbSate = await _iRegistrationRepository.GetState();
            RegistrationModel _ObjRegistrationModel;
            if (paramRegisterID > 0)
                _ObjRegistrationModel = await _iRegistrationRepository.getInfoById(paramRegisterID);
            else
                _ObjRegistrationModel = new RegistrationModel();
            return PartialView("_RegisterManagePartialView", _ObjRegistrationModel);
        }

        public JsonResult GetCityListByState(int paramStateId)
        {
            List<SelectListItem> getState = new List<SelectListItem>();
            var cityList = _iRegistrationRepository.getCityListByState(paramStateId).Result;
            return Json(cityList);
        }
        public async Task<ActionResult> SaveRegistration(RegistrationModel paramObjRegistrationModel)
        {
            ResponseModel<SP_RegistrationInsertUpdateModel> _objResponseModel;
            _objResponseModel = await _iRegistrationRepository.saveRegistration(paramObjRegistrationModel);
            return Json(_objResponseModel);
        }
        public async Task<ActionResult> DeleteRegister(int paramId)
        {
            ResponseModel<RegistrationModel> _objResponseModel;
            _objResponseModel = await _iRegistrationRepository.deleteInfoById(paramId);
            return Json(_objResponseModel);
        }
    }
}
