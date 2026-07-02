using System;
using System.Collections.Generic;
using System.Text;

namespace TagHelpers.Binders
{
    public abstract class DataTableServerRequestResponse
    {
        public int Draw { get; set; }
        public long RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; } 
        public string Error { get; set; }
    }
}
