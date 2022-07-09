using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Musictify.Models
{
    public partial class Artist
    {
        public int ArtistId { get; set; }
        [DisplayName("Artists")]
        public string ArtistName { get; set; } = null!;
       
        [DisplayName("Date of Birth")]
        public string DateofBirth { get; set; }
        public string Bio { get; set; } = null!;
    }
}
