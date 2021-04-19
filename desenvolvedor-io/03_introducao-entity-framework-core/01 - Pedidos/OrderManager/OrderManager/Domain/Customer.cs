namespace OrderManager.Domain
{
    //[Table("AnotherName")]
    public class Customer
    {
        //[Key]
        public int Id { get; set; }

        //[Required]
        public string Name { get; set; }

        //[Column("MobilePhone")]
        public string Phone { get; set; }

        public string PostalCode { get; set; }

        public string State { get; set; }

        public string City { get; set; }
    }
}
