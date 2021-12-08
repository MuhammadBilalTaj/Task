using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NowSoftwareTask.Interface
{
   public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
        void CloseConnection();
    }
}
