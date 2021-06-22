using System;
using System.Collections.Generic;
using System.Text;

namespace DonationStore.Infrastructure.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message) { }
    }
}
