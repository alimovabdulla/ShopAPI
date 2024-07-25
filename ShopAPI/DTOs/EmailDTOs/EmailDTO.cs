namespace ShopAPI.DTOs.EmailDTOs
{
    public class EmailDTO
    {


        public string From { get; set; }

        public string? To { get; set; } = "abdullaalimov555@gmail.com";

        public string? Subject { get; set; }

        public string? Body { get; set; }

        public string Password { get; set; }

    }
}
