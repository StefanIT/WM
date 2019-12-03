using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCommands
{
	public abstract class BaseCommand
	{
		protected productEntities Entities;

		protected BaseCommand(productEntities _entities)
		{
			Entities = _entities;
		}
	}
}
