namespace WPFAspire.Database.Entities
{
    public class Email : BaseEntity
    {
        public string Adreess { get; set; }

        public Contact Contact { get; set; }
    }
}
