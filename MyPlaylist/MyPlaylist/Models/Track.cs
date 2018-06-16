using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyPlaylist.Models
{
    public class Track
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        [MaxLength(255)]
        public string Artist { get; set; }

        [Required]
        [MaxLength(255)]
        public string UrlTrack { get; set; }

        [Required]
        public long PlaylistId { get; set; }

        public Playlist Playlist { get; set; }

    }
}
