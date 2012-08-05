using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BaffleTalk.Common.Exceptions
{
    public class ValidationException : Exception
    {
        private readonly IDictionary<string, string> errorList;

        public ValidationException(string fieldName, string friendlyMessage)
            : base(friendlyMessage)
        {
            errorList = new ReadOnlyDictionary<string, string>(new Dictionary<string, string> { { fieldName, friendlyMessage } });
        }

        public ValidationException(string friendlyMessage)
            : base(friendlyMessage)
        {
            errorList = new ReadOnlyDictionary<string, string>(new Dictionary<string, string> { { String.Empty, friendlyMessage } });
        }

        public ValidationException(IDictionary<string, string> errorList)
        {
            this.errorList = new ReadOnlyDictionary<string, string>(errorList);
        }

        public ValidationException()
        {
            errorList = new Dictionary<string, string>();
        }

        public IDictionary<string, string> ErrorList
        {
            get { return errorList; }
        }

        public void AddError(string fieldName, string friendlyMessage)
        {
            errorList.Add(fieldName, friendlyMessage);
        }
    }
}