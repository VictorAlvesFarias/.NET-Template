using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class IDbContextTransactionExtension
    {
        public static void CommitDispose(this IDbContextTransaction context)
        {
            context.Commit();
            context.Dispose();
        }
        public static void RollbackDispose(this IDbContextTransaction context)
        {
            context.Rollback();
            context.Dispose();
        }
    }
}
