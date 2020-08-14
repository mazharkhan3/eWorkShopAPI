using eWorkShopAPI.Common;
using eWorkShopAPI.Entity;
using eWorkShopAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace eWorkShopAPI.Controllers

{
   
    public class AccountsController : ApiController
  {
    readonly Response _response;
    eWorkShop123Entities dbContext = new eWorkShop123Entities();

    public AccountsController()
    {
      _response = new Response();  
    }

    [HttpPost]
    public HttpResponseMessage Login(User user)
    {
      try
      {
        if (user.Email == null || user.Email == "")
        {
          _response.Code = Constants.Failure;
          _response.Message = Constants.EmptyEmail;
          return Request.CreateResponse(HttpStatusCode.Forbidden, _response);
        }
        else if (string.IsNullOrEmpty(user.Password.ToString()))
        {
          _response.Code = Constants.Failure;
          _response.Message = Constants.EmptyPassword;
          return Request.CreateResponse(HttpStatusCode.Forbidden, _response);
        }
        //else if (user.UserTypeId < 2 || user.UserTypeId > 3)
        //{
        //    response.Code = Constants.Failure;
        //    response.Message = Constants.EmptyUserType;
        //    return Request.CreateResponse(HttpStatusCode.Forbidden, response);
        //}
        else
        {

          // fetch the user
          var userObj = dbContext.Users.FirstOrDefault(x => x.Email == user.Email && x.IsArchived == false);

          if (userObj != null)
          {
              return Request.CreateResponse(HttpStatusCode.OK, userObj);
          }
          else
          {
            _response.Code = Constants.Failure;
            _response.Message = Constants.FalseLogin;
            return Request.CreateResponse(HttpStatusCode.InternalServerError, _response);

          }
        }
      }
      catch (Exception ex)
      {
        _response.Code = 500;
        _response.Message = ex.Message + ex.InnerException;
        return Request.CreateResponse(HttpStatusCode.InternalServerError, _response);
      }
    }
  }
}
