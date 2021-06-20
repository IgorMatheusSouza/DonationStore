using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DonationStore.Infrastructure.CQRS.Abstractions
{
    public interface ICommandDispatcher
    {
        Task<ICommandResult> Dispatch<TParameter>(TParameter command)
           where TParameter : ICommand;
    }

    public class CommandResult : ICommandResult
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }

    public interface ICommandResult
    {
        bool Success { get; }
        string Message { get; set; }
        object Data { get; set; }
    }

    public interface ICommand
    {

    }
}
