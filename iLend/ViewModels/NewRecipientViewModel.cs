using iLend.Models;
using System.Collections.Generic;

namespace iLend.ViewModels
{
    public class NewRecipientViewModel
    {
        public IEnumerable<UserGroup> UserGroups { get; set; }
        public Recipient Recipient { get; set; }
    }
}