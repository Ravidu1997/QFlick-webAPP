using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QFlick.Domain.Consts
{
    public abstract class ResponseMessage
    {
        #region UserInteract
        public const string USER_NOT_FOUND = "User Not Found";
        public const string INCORRECT_PASSWORD = "Incorrect Password";
        public const string ACCOUNT_ALREADY_EXIST = "Account With This Email Already Exist";
        #endregion

        #region Queue
        public const string QUEUE_NOT_FOUND = "This Queue Not Exists!.";
        #endregion
    }
}
