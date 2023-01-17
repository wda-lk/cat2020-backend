using CAT20.Model;
using System;
using System.Collections.Generic;

namespace CAT20.DataAccess.Interface
{
    public interface IReportDataAccess
    {
        List<FeeReport> FeeReports(DateTime start, DateTime end, List<Guid> feeType, List<Guid> classes);
    }
}