using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Proyecto.Interfaces
{
    public interface IBeginTransactionAsync
    {
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}