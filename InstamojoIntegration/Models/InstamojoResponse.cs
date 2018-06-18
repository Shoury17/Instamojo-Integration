using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstamojoIntegration.Models
{
    public class InstamojoResponse
    {
        public bool success { get; set; }
        public instamojoResponse2 payment_request { get; set; }
    }

    public class instamojoResponse2
    {
        public string id { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string buyer_name { get; set; }
        public string amount { get; set; }
        public string purpose { get;set;}
        public string expires_at { get;set;}
        public string status { get;set;}
        public bool send_sms { get;set;}
        public bool send_email { get;set;}
        public string sms_status { get;set;}
        public string email_status { get;set;}
        public string shorturl { get;set;}
        public string longurl { get;set;}
        public string redirect_url { get;set;}
        public string webhook { get;set;}
        public List<instamojoResponse3> payments { get; set; }
        public DateTime created_at { get;set;}
        public DateTime modified_at { get;set;}
        public bool allow_repeated_payments { get;set;}
    }

    public class instamojoResponse3
    {
        public string payment_id { get; set; }
        public int quantity { get; set; }
        public string status { get; set; }
        public string link_slug { get; set; }
        public string link_title { get; set; }
        public string buyer_name { get; set; }
        public string buyer_phone { get; set; }
        public string currency { get; set; }
        public string buyer_email { get; set; }
        public string unit_price { get; set; }
        public string amount { get; set; }
        public string fees { get; set; }
        public string shipping_address { get; set; }
        public string shipping_city { get; set; }
        public string shipping_state { get; set; }
        public string shipping_zip { get; set; }
        public string shipping_country { get; set; }
        public string discount_code { get; set; }
        public string g { get; set; }
        public string discount_amount_off { get; set; }
        public string affiliate_id { get; set; }
        public string affiliate_commission { get; set; }
        public string instrument_type { get; set; }
        public string billing_instrument { get; set; }
        public string failure { get; set; }
        public instamojoResponse4 payout { get; set; }
        public DateTime created_at { get; set; }
        public string payment_request { get; set; }
    }

    public class instamojoResponse4
    {
        public string id { get; set; }
        public DateTime paid_out_at { get; set; }
    }
}