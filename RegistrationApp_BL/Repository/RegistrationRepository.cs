using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RegistrationApp_DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationApp_BL.Repository
{
    public interface IRegistrationRepository
    {
        Task<ResponseModel<RegistrationModel>> registrationList();
        Task<RegistrationModel> getInfoById(int paramRegisterID);
        Task<ResponseModel<RegistrationModel>> deleteInfoById(int paramRegisterID);
        Task<IEnumerable<StateModel>> GetState();
        Task<IEnumerable<CityModel>> getCityListByState(int paramStateId);
        Task<ResponseModel<SP_RegistrationInsertUpdateModel>> saveRegistration(RegistrationModel paramRegistrationModel);
    }
    public class RegistrationRepository : IRegistrationRepository
    {
        private RegistrationDBContext _dbContext;
        public RegistrationRepository(RegistrationDBContext DBContext)
        {
            _dbContext = DBContext;
        }
        public async Task<IEnumerable<StateModel>> GetState()
        {
            return await _dbContext.tblState.ToListAsync();
        }
        public async Task<IEnumerable<CityModel>> getCityListByState(int paramStateId)
        {
            return await _dbContext.tblCity.Where(s => s.refID_StateMst == paramStateId).ToListAsync();
        }
        public async Task<RegistrationModel> getInfoById(int paramRegisterID)
        {
            return await _dbContext.tblUserRegistration.Where(x => x.Id == paramRegisterID).FirstOrDefaultAsync();
        }
        public async Task<ResponseModel<RegistrationModel>> deleteInfoById(int paramRegisterID)
        {
            ResponseModel<RegistrationModel> _ObjResponseModel;
            RegistrationModel objRegistrationModel = new RegistrationModel();
            objRegistrationModel = await _dbContext.tblUserRegistration.Where(x => x.Id == paramRegisterID).FirstOrDefaultAsync();
            _dbContext.tblUserRegistration.Remove(objRegistrationModel);
            _dbContext.SaveChanges();
            return _ObjResponseModel = new ResponseModel<RegistrationModel>()
            {
                Result = HelperMessage.ResponceResult.OK,
            };
        }
        public async Task<ResponseModel<RegistrationModel>> registrationList()
        {
            ResponseModel<RegistrationModel> _ObjResponseModel;
            try
            {
                var _ObjRegistrationModel = await _dbContext.tblUserRegistration.OrderByDescending(x=>x.Id).ToListAsync();
                return _ObjResponseModel = new ResponseModel<RegistrationModel>()
                {
                    ListResult = _ObjRegistrationModel
                };
            }
            catch (Exception ex)
            {
                return _ObjResponseModel = new ResponseModel<RegistrationModel>()
                {
                    Message = ex.Message,
                    Result = HelperMessage.ResponceResult.ERROR,
                    Status = (int)HttpStatusCode.BadRequest
                };
            }
        }
        public async Task<ResponseModel<SP_RegistrationInsertUpdateModel>> saveRegistration(RegistrationModel paramEnrollmentModel)
        {
            ResponseModel<SP_RegistrationInsertUpdateModel> _ObjSP_RegistrationInsertUpdateModel;
            try
            {

                var _id = new SqlParameter("@paramId", paramEnrollmentModel.Id);
                var _refID_StateMst = new SqlParameter("@paramRefID_StateMst", paramEnrollmentModel.refID_StateMst);
                var _refID_CityMst = new SqlParameter("@paramrefID_CityMst", paramEnrollmentModel.refID_CityMst);
                var _Name = new SqlParameter("@paramName", paramEnrollmentModel.Name);
                var _Email = new SqlParameter("@paramEmail", paramEnrollmentModel.Email);
                var _Phone = new SqlParameter("@paramPhone", paramEnrollmentModel.Phone);
                var _Address = new SqlParameter("@paramAddress", paramEnrollmentModel.Address == null ? "" : paramEnrollmentModel.Address);
                return _ObjSP_RegistrationInsertUpdateModel = new ResponseModel<SP_RegistrationInsertUpdateModel>
                {
                    ListResult = await _dbContext.SP_RegistrationInsertUpdate.FromSqlRaw("EXEC [dbo].[SP_RegistrationInsertUpdate] @paramId,@paramRefID_StateMst,@paramrefID_CityMst,@paramName,@paramEmail,@paramPhone,@paramAddress", _id, _refID_StateMst, _refID_CityMst, _Name, _Email, _Phone, _Address).ToListAsync(),
                    Result = HelperMessage.ResponceResult.OK,
                };


            }
            catch (Exception ex)
            {
                return _ObjSP_RegistrationInsertUpdateModel = new ResponseModel<SP_RegistrationInsertUpdateModel>()
                {
                    Message = ex.Message,
                    Result = HelperMessage.ResponceResult.ERROR,
                    Status = (int)HttpStatusCode.BadRequest
                };
            }
        }

       
    }
}
