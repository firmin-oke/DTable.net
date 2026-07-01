using System;
using System.Collections.Generic;
using System.Text;

namespace TagHelpers
{
    public class DataTableResult : DataComponentResult, IDataCompo
    {
        public object[] Data { get; set; }
        public DataTableResult()
        {
            Data = new object[] { };
        }
    }
}
