using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DonationStore.Infrastructure.CQRS.Implementations
{
    public class Request
    {
        public Request()
        {
            IsValid = true;
        }
        public string Message { get; private set; }

        public HttpStatusCode StatusCode { get; private set; }

        public bool IsValid { get; private set; }

        protected void SetBadRequest(string message)
        {
            SetInvalid(message);
            StatusCode = HttpStatusCode.BadRequest;
        }

        private void SetInvalid(string message)
        {
            IsValid = false;
            Message = message;
        }
    }
}
