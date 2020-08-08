using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eWorkShopAPI.Common
{
  public class Constants
  {
    // Status Codes
    public const int Exception = -1;
    public const int Failure = 0;
    public const int Success = 1;

    // Status Responses
    public const string EmptyPassword = "Please Enter Password.";
    public const string EmptyEmail = "Please Enter Email.";
    public const string FalseLogin = "Invalid Credentials.";
  }
}