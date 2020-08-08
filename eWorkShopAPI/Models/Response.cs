using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eWorkShopAPI.Models
{
  public class Response
  {
    public string Message { get; set; }
    public int Code { get; set; }

  }

  public class ResponseResult<T>
  {
    public bool Success { get; set; }

    public string Message { get; set; }
  }
}