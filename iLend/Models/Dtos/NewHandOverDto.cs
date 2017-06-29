using System.Collections.Generic;

namespace iLend.Models.Dtos
{
    public class NewHandOverDto
    {
        public int RecipientId { get; set; }
        public List<int> ProductIds { get; set; }
    }
}