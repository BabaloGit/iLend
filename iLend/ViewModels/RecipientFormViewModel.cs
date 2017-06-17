using iLend.Models;
using System.Collections.Generic;

namespace iLend.ViewModels
{
    public class RecipientFormViewModel
    {
        public IEnumerable<UserGroup> UserGroups { get; set; }
        public Recipient Recipient { get; set; }
        public string Title
        {
            get
            {
                if (Recipient != null && Recipient.Id != 0)
                    return "Edit Recipient";

                return "New Recipient";
            }
        }
    }
}