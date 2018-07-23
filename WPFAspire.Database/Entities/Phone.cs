namespace WPFAspire.Database.Entities
{
    public class Phone : BaseEntity
    {
        public string Number { get; set; }

        public Contact Contact { get; set; }
    }
}
