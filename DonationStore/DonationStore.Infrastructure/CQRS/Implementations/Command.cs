using MediatR;
using System.Net;

namespace DonationStore.Infrastructure.CQRS.Implementations
{
    public abstract class Command
    {
        public Command()
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