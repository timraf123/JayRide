using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication6.Models.DefaultModel
{
    public class DefaultModel
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string location { get; set; }


        public DefaultModel()
        {
            this.firstname = "XX";
            this.lastname = "CC";
            this.location = "MM";
        }
    }
}