using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LukeTest.Models.ViewModels.Partials
{
    public class DynamicTablePartialViewModel
    {
        public IEnumerable<object> Data { get; set; }
        public string EmptyDataText { get; set; }
    }
}