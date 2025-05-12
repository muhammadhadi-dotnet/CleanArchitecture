using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interface;
using CleanArchitecture.Domain.Entity;

namespace CleanArchitecture.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
      IProduct product { get; }
      ICategory category { get; }
      Task Save();
    }
}
