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
        public IBaseNameFeature classe { get; set; }
        public IBaseNameFeature type { get; set; }
        public IFeatures features { get; set; }
    }

    public class IBaseNameFeature
    {
        public string name { get; set; }
        public string description { get; set; }
    }

    public class IFeatures
    {
        public string short_description { get; set; }
        public string full_description { get; set; }
        public string color { get; set; }
        public decimal height { get; set; }
        public decimal width { get; set; }
        public decimal weight { get; set; }
    }

    public class IBaseEnemies
    {
        public int scp { get; set; }
        public List<IEnemies> enemies { get; set; }
    }

    public class IEnemies
    {
        public int scp_enemy { get; set; }
        public string name { get; set; }
        public string scp_link { get; set; }

    }

    public class IClasses
    {
        public string name { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class IInterviews
    {
        public int? scp { get; set; }
        public DateTime interview_date { get; set; }
        public string transcription { get; set; }
    }
}