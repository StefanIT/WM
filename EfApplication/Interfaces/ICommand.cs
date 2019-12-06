using System;
using System.Collections.Generic;
using System.Text;

namespace EfApplication.Interfaces
{
    //public interface ICommand<TRequest>
    //{
    //    void Execute(TRequest request);
    //}

    public interface ICommand<TResponse>
    {
        TResponse Execute();
    }

    public interface IExecuteCommand<TRequest>
    {
        void Execute(TRequest request);
    }

	public interface ICommand<TRequest,TResponse>
	{
		TResponse Execute(TRequest request);
	}
}
