namespace TRAODOITAILIEU.BusinessLayer.DTOs
{
    public class DocumentRequest
    {
        public string DocumentName { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public float Price { get; set; }
        public DateTime commentDate { get; set; }
        public string content { get; set; }
    }
}
