namespace T034.Models
{
    public class YandexUserModel : UserModel
    {
        public override string Name
        {
            get { return string.IsNullOrEmpty(display_name) ? 
                "" : 
                string.Format("{0}[{1}]", display_name, default_email); }
        }
        public string default_email { get; set; }
        public string display_name { get; set; }
    }
}