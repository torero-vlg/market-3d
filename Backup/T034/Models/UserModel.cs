namespace T034.Models
{
    public abstract class UserModel
    {
        public virtual string Name { get; set; }
        public bool IsAutharization { get; set; }
    }
}