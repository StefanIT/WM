using EfApplication.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfApplication.EfCommands
{
    public abstract class BaseEfCommand
    {
        public BaseEfCommand(WMContext context)
        {
            Context = context;
        }
        protected WMContext Context { get; }

    }
}
