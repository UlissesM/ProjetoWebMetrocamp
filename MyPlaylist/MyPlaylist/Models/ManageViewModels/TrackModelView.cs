using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlaylist.Models.ManageViewModels
{
    public class TrackModelView
    {
        [Required]
        [Display(Name = "Titulo")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Artista")]
        
        public string Artist { get; set; }
        [Display(Name = "Link (youtube)")]
        public string UrlTrack { get; set; }

        public long Id { get; set; }
        public long PlaylistId { get; set; }

        public string PlaylistName { get; set; }

    }
}
