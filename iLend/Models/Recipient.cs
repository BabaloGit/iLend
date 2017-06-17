namespace iLend.Models
{
    public class Recipient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSubscibedToNewsletter { get; set; }
        public UserGroup UserGroup { get; set; }
        public byte UserGroupId { get; set; }
    }
}