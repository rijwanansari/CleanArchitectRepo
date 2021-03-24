using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserSelfDesk.Applcaiton.Common.Model
{
   public class ResponseModel
    {
        internal ResponseModel(bool success, string message, dynamic output)
        {
            Success = success;
            Message = message;
            Output = output;
            //Errors = errors.ToArray();
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public dynamic Output { get; set; }
        public string[] Errors { get; set; }

        public static ResponseModel SuccessResponse(string message, dynamic output)
        {
            return new ResponseModel(true, message, output);
        }
        public static ResponseModel FailureResponse(string message, dynamic output)
        {
            return new ResponseModel(false, message, output);
        }

    }
}
