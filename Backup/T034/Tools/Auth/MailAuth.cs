using System;
using System.Web;
using Db.Tools;
using T034.Models;

namespace T034.Tools.Auth
{
    /// <summary>
    /// http://api.mail.ru/docs/guides/oauth/sites/
    /// </summary>
    public static class MailAuth
    {
        public const string SiteId = "729641";
        public const string SecretKey = "1b8720d2c5b58077bb780ab160e4273c ";



        /// <summary>
        /// КУда будет редирект после авторизации
        /// </summary>
        public const string RedirectUri = "http://t034.ru/Auth/LoginWithMail";

        ///? HTTP/1.1
        public const string InfoUrl = "https://appsmail.ru/platform/api";

        public static TokenModel GetToken(HttpRequestBase request)
        {
            var code = request.QueryString["code"];

            var stream = HttpTools.PostStream("https://connect.mail.ru/oauth/token",
                                              string.Format(
                                                  "client_id={0}&" + 
                                                  "client_secret={1}&" +
                                                  "grant_type=authorization_code&" + 
                                                  "code={2}&" +
                                                  "redirect_uri={3}",
                                                  SiteId, SecretKey, code, RedirectUri));

            var model = SerializeTools.Deserialize<TokenModel>(stream);

            return model;



        }

        public static HttpCookie TokenCookie(TokenModel model)
        {
            var userCookie = new HttpCookie("mail_token")
            {
                Value = model.access_token,
                Expires = DateTime.Now.AddDays(30)
            };

            return userCookie;
        }

        public static MailUserModel GetUser(HttpRequestBase request)
        {
            var model = new MailUserModel{IsAutharization = false};
            try
            {
                var userCookie = request.Cookies["mail_token"];
                if (userCookie != null)
                {
                    var stream = HttpTools.PostStream(InfoUrl, 
                        string.Format("oauth_token={0}&client_id={1}&format=json&method=users.getInfo&sig={2}", 
                        userCookie.Value, SiteId, ""));
                    model = SerializeTools.Deserialize<MailUserModel>(stream);
                    model.IsAutharization = true;
                }
            }
            catch (Exception ex)
            {
                MonitorLog.WriteLog(ex.InnerException + ex.Message, MonitorLog.typelog.Error, true);
                model.IsAutharization = false;
            }

            return model;
        }
    }
}