namespace SOLID
{
    public class Document
    {
        public string Number { get; set; }

        public bool Validate()
        {
            return Number.Length == 1;
        }
    }
}
