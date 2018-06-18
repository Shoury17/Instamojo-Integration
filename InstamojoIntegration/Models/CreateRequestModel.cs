using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstamojoIntegration.Models
{
    public class CreateRequestModel
    {
        public string buyerName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string purpose { get; set; }
    }
}