using InstaMojo.API;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace InstamojoIntegration.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("createrequest")]
        public async Task<ActionResult> createrequest(Models.CreateRequestModel _model)
        {
            InstoMojo_Init ini = new InstoMojo_Init()
            {
                Api_Url = InstamojoCredentials.instamojoUrl,
                Private_API_Key = InstamojoCredentials.privateApiKey,
                Private_Auth_Token = InstamojoCredentials.privateAuthenticationToken,
                Private_Salt = InstamojoCredentials.privateSalt
            };
            InstoMojo insta = new InstoMojo(ini);
            CreatePaymentRequest req = new CreatePaymentRequest()
            {
                AllowRepeatedPayments = false,
                Amount = 100,
                BuyerName = _model.buyerName,
                Email = _model.email,
                Phone = _model.phone,
                Purpose = _model.purpose,
                SendEmail = false,
                SendSms = false,
                RedirectUrl = InstamojoCredentials.redirectUrl,
                Webhook = InstamojoCredentials.webhook,
            };
            var x = await insta.CreateRequest(req);
            if (x.success)
            {
                var url = x.payment_request.longurl;
                string paymentRequestId = x.payment_request.id;
                return Redirect(url);
            }
            else
            {
                return new HttpStatusCodeResult(500);
            }
        }

        // Webhook response only comes when your project is live
        public ActionResult webhook(WebhookModel webhook)
        {
            MacCalculator macCalculator = new MacCalculator();
            var values = WebhookToDictonary(webhook);   // Convert to dictionary
            var salt = InstamojoCredentials.privateSalt;    // Private Salt
            var response = macCalculator.MacComparer(values, salt);  // Compare dictionary and Salt
            
            // If response is true than you have to save transaction data in database
            if (response)
            {
                
            }
            return new HttpStatusCodeResult(400);
        }

        [HttpGet]
        [ActionName("redirectto")]
        public ActionResult redirectto(string payment_id, string payment_request_id)
        {
            // Check the transaction status again from the instamojo if you want
            var data = GetRequestDetails(payment_request_id);
            if (data.payment_request.status == "credit")
            {
                // Redirect to Success transaction page
                string url = "–Your transaction success View page url–";
                return Redirect(url);
            }
            else
            {
                // Redirect to Failed transaction page
                string url = "–Your transaction failed View page url–";
                return Redirect(url);
            }
        }
        
        private Dictionary<string, string> WebhookToDictonary(WebhookModel webhook)
        {
            Dictionary<string, string> dict = new
                Dictionary<string, string>();

            dict.Add("amount", webhook.amount.ToString());
            dict.Add("buyer", webhook.buyer);
            dict.Add("buyer_name", webhook.buyer_name);
            dict.Add("buyer_phone", webhook.buyer_phone);
            dict.Add("currency", webhook.currency);
            dict.Add("fees", webhook.fees.ToString());
            dict.Add("longurl", webhook.longurl);
            dict.Add("mac", webhook.mac);
            dict.Add("payment_id", webhook.payment_id);
            dict.Add("payment_request_id", webhook.payment_request_id);
            dict.Add("purpose", webhook.purpose);
            dict.Add("shorturl", webhook.shorturl);
            dict.Add("status", webhook.status);
            return dict;
        }


        public Models.InstamojoResponse GetRequestDetails(string paymentId)
        {
            try
            {
                WebRequest tRequest;
                tRequest = WebRequest.Create($"{InstamojoCredentials.instamojoUrl}payment-requests/{paymentId}");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                tRequest.Headers.Add(string.Format("X-Api-Key:{0}",InstamojoCredentials.privateApiKey));

                tRequest.Headers.Add(string.Format("X-Auth-Token:{0}", InstamojoCredentials.privateAuthenticationToken));

                tRequest.ContentLength = 0;
                Stream dataStream = tRequest.GetRequestStream();
                dataStream.Close();

                WebResponse tResponse = tRequest.GetResponse();

                dataStream = tResponse.GetResponseStream();

                StreamReader tReader = new StreamReader(dataStream);

                String sResponseFromServer = tReader.ReadToEnd();
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                var data = jsonSerializer.Deserialize<Models.InstamojoResponse>(sResponseFromServer);

                tReader.Close();
                dataStream.Close();
                tResponse.Close();
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}