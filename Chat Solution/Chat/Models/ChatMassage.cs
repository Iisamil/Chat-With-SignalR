namespace Chat.Models
{
    public class ChatMassage
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
        public DateTime MassageDate { get; set; } = DateTime.Now;
    }
}
