namespace T034.Models
{
    public class MailUserModel : UserModel
    {
        public override string Name
        {
            get { return string.IsNullOrEmpty(first_name) ? 
                "" : 
                string.Format("{0}[{1}]", first_name, email); }
        }
        public string email { get; set; }
        public string first_name { get; set; }
    }
}