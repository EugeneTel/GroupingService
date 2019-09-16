using System.Collections.Generic;
using Services.Reports;
using System;

namespace Services
{
    public class ExportService
    {
        /// <summary>
        /// Convert Report List to Text
        /// </summary>
        /// <param name="reports">List of Reports</param>
        /// <returns>string</returns>
        public string ToText(List<IReport> reports)
        {
            return string.Join(Environment.NewLine, reports.ConvertAll<string>(x => x.ToString()));
        }
    }
}
