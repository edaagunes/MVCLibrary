using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCLibrary.Models.Entity;

namespace MVCLibrary.Models.Classes
{
    public class Class1
    {
        public IEnumerable<Book> Value1 { get; set; }
        public IEnumerable<About> Value2 { get; set; }
    }
}