//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace api_scp_net.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class features
    {
        public int scp_id { get; set; }
        public string short_description { get; set; }
        public string full_description { get; set; }
        public string color { get; set; }
        public decimal height { get; set; }
        public decimal width { get; set; }
        public decimal weight { get; set; }
    
        public virtual scp scp { get; set; }
    }
}
