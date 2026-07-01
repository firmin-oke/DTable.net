using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagHelpers
{
    public class DataTableRequest : DataComponentRequest
    {
        public DataTableOrder[] Order { get; set; }

        public DataTableColumn[] Columns { get; set; }

        public DataTableSearch Search { get; set; }

        public KeyValuePair<string, object> [] Globalqueryfilters { get; set; }

        public DateTime? SearchStartDate { get; set; }

        public DateTime? SearchEndDate { get; set; }

        public Guid [] UoFilters { get; set; }

        //public int Draw { get; set; }

        //public int Start { get; set; }

        //public int Length { get; set; }

        //public string SortColumn { get; set; }

        //public string SortColumnDirection { get; set; }

        //public string SearchValue { get; set; }

        //public string SearchColumn { get; set; }

        //public string Proprties { get; set; }

        //public static DataTableRequestParam Init(HttpContext context)
        //{

        //   var draw = context.Request.Form["draw"].FirstOrDefault();

        //    // Skip number of Rows count  
        //    var start = context.Request.Form["start"].FirstOrDefault();

        //    // Paging Length 10,20  
        //    var length = context.Request.Form["length"].FirstOrDefault();

        //    // Sort Column Name  
        //    var sortColumn = context.Request.Form["columns[" + context.Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();

        //    return new DataTableRequestParam
        //    {
        //        SearchValue = context.Request.Form["search[value]"].FirstOrDefault(),
        //        SortColumnDirection = context.Request.Form["order[0][dir]"].FirstOrDefault(),
        //        Length = length!=null?int.Parse(length) : 0,
        //        Start = start != null ? int.Parse(start) : 0,
        //        Draw = draw != null ? int.Parse(draw) : 0,
        //        SortColumn = sortColumn
        //    };
        //}
    }
}
