using System;
using System.Collections.Generic;
using System.Text;

namespace DonationStore.Infrastructure.CQRS.Abstractions
{
    public interface ICommand
    {
        bool Validate();
    }
}
