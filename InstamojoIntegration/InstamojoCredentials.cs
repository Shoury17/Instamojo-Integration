using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstamojoIntegration
{
    public class InstamojoCredentials
    {
        public static string privateApiKey { get; set; } = "8b88965a30276cd058e24b9d79db24f6";
        public static string privateAuthenticationToken { get; set; } = "7f92c0d102313bec01bf7cc71c33b4c9";
        public static string privateSalt { get; set; } = "8d648821ce9e427eb4406e786e4af6f3";
        public static string instamojoUrl { get; set; } = "https://test.instamojo.com/api/1.1/";

        public static string redirectUrl { get; set; } = "http://localhost:65284/Home/redirectto";

        public static string webhook { get; set; } = "";

        //public static string Insta_client_id { get; set; } = "RzwcKy9kZ9lQFWKIzcoyZr2jOUIvxNAU18cF8gBO";
        //public static string Insta_client_secret { get; set; } = "dIZltOa2oJLJgb6AH16rL317nKYHggOWS7WBYnnXr4xdxTHM4RorMweSagpfcS46FjBEY6X6bR7CtWRT23xvXZs81hiMXfyiDefier5zZcEV7TAv2R344gruGI4iuSHL";
        //public static string Insta_Endpoint { get; set; } = "https://test.instamojo.com/v2/";
        //public static string Insta_Auth_Endpoint { get; set; } = "https://test.instamojo.com/oauth2/token/";
    }
    
}