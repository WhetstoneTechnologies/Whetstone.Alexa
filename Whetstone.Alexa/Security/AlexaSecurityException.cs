using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Whetstone.Alexa.Security
{
    public class AlexaSecurityException : Exception
    {

        private HttpStatusCode? _statusCode = null;
        private string _errorType = null;
        private string _code = null;

        /// <summary>
        /// Initializes a new instance of the System.Exception class.
        /// </summary>
        public AlexaSecurityException() : base()
        {


        }
        
        /// <summary>
        /// Initializes a new instance of the System.Exception class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public AlexaSecurityException(string message) : base(message)
        {


        }

        
        /// <summary>
        /// Initializes a new instance of the System.Exception class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="statusCode">Http status code of the Alexa Http response.</param>
        internal AlexaSecurityException(string message,  HttpStatusCode statusCode) : base(message)
        {
            _statusCode = statusCode;
        }


        /// <summary>
        /// Initializes a new instance of the System.Exception class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="errorType">Type of the error, according to the Alexa error response message.</param>
        /// <param name="statusCode">Http status code of the Alexa Http response.</param>
        public AlexaSecurityException(AlexaSecurityErrorResponse errResponse, HttpStatusCode statusCode) : base(errResponse.Message)
        {
            _errorType = errResponse.Type;
            _code = errResponse.Code;
            _statusCode = statusCode;

        }

        /// <summary>
        ///  Initializes a new instance of the System.Exception class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference.</param>
        public AlexaSecurityException(string message, Exception innerException) : base(message, innerException)
        {


        }

        /// <summary>
        ///  Initializes a new instance of the System.Exception class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="statusCode">Http status code of the Alexa Http response.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference.</param>
        public AlexaSecurityException(string message,  HttpStatusCode? statusCode, Exception innerException) : base(message, innerException)
        {
            _statusCode = statusCode;

        }


        /// <summary>
        /// Status code of the Alexa http response.
        /// </summary>
        /// <remarks>
        /// If the code is 403, then the user
        /// 
        /// <list type="table">
        /// <listheader>  
        /// <term>Status Code</term>  
        /// <description>Description</description>  
       /// </listheader>  
      /// <item>  
      ///  <term>Unauthorized (401)</term>  
      ///  <description>The API authentication token is invalid or has expired.</description>  
      /// </item>  
      /// <item>
      /// <term>Forbidden (403)</term>
      /// <description>API authentication token is valid, but access to the resource is denied. An appropriate response is to send
      /// a card authorization request.</description>
      /// </item>
        /// </list>
        /// </remarks>
        public HttpStatusCode? StatusCode { get { return _statusCode; }  }

        public string ErrorType { get { return _errorType; } }


        public string ErrorCode { get { return _code; } }

    }
}
