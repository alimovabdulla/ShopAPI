namespace ShopAPI.Models
{
    public class EmailData
    {
        public string From { get; set; }

        public string? To { get; set; } = "abdullaalimov555@gmail.com";

        public string? Subject { get; set; } = "Test";

        public string? Body { get; set; } = "Salam";

        public string Password { get; set; }

        public EmailData()
        {
            From = "abdullaxt999@gmail.com";
            Password = "xkte uheo   aobi";
        }
    }
}
