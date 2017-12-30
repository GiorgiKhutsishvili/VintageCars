using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VintageCars.Models
{
    public class ConsumedModels
    {
        public List<ImageTbl> imageTbl { get; set; }
        public List<ServiceTbl> serviceTbl { get; set; }
        public List<SocialLinksTbl> socialLinksTbl { get; set; }
        public List<SubscriberTbl> subscriberTbl { get; set; }
    }
}