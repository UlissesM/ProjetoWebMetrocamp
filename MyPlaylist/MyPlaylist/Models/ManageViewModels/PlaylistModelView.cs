using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyPlaylist.Models.ManageViewModels
{
    public class PlaylistModelView
    {
        [Display(Name = "Titulo")]
        public string Title { get; set; }

        public string UserId { get; set; }

        public long Id { get; set; }

        [Display(Name = "Detalhes")]
        public string Description { get; set; }
    }
}
