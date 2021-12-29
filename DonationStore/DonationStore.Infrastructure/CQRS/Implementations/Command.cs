using MediatR;
using Newtonsoft.Json;
using System.Net;

namespace DonationStore.Infrastructure.CQRS.Implementations
{
    public abstract class Command
    {
        public Command()
        {
            IsValid = true;
        }

        [JsonIgnore]
        public string Message { get; private set; }

        [JsonIgnore]
        public HttpStatusCode StatusCode { get; private set; }

        [JsonIgnore]
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