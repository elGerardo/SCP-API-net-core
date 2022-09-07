using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_scp_net.Models
{
    public class IScp
    {
        public int id { get; set; }
        public string name{ get; set; }
        public string feeling { get; set; }
        public string picture { get; set; }
        public List<IClasses> class_id { get; set; }
        public int type_id { get; set; }
        public int feature_id { get; set; }
    }

    public class IClasses
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}