using System;
using System.ComponentModel.DataAnnotations;

namespace iLend.Models.Dtos
{
    public class RecipientDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        //[Min18YearsToRegister]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime BirthDate { get; set; }

        public bool IsSubscibedToNewsletter { get; set; }
        
        public byte UserGroupId { get; set; }

        public UserGroupDto UserGroup { get; set; }
    }
}