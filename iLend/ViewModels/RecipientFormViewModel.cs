using iLend.Models;
using System.Collections.Generic;

namespace iLend.ViewModels
{
    public class RecipientFormViewModel
    {
        public IEnumerable<UserGroup> UserGroups { get; set; }
        public Recipient Recipient { get; set; }
    }
}