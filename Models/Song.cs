using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace Musictify.Models
{
    public partial class Song
    {
        public int SongId { get; set; }
        [DisplayName("Song")]
        public string SongName { get; set; } = null!;
        [DisplayName("Date of Release")]
        public string DateReleased { get; set; }
        public string ArtWork { get; set; } = null!;
        public string Artists { get; set; } = null!;
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        

        [DisplayName("Rate")]
        public int? Rating { get; set; }

    }
}
