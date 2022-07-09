using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace Musictify.Models
{
    public class ViewModel
    {
        public List<Artist> artistList { get; set; }
        public List<Song> songList { get; set; }
    }
}
