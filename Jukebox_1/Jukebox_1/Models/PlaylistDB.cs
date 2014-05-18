using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;


namespace Jukebox_1.Models
{
    public class JukeboxDB : DbContext
    {
        public DbSet<tblPlaylist> Playlists { get; set; }
    }


}