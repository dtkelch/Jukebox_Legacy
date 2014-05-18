using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.EntityModel;

using Jukebox_1.Models;

namespace Jukebox_1.Controllers
{
    public class JukeboxController : Controller
    {

        
        private JukeboxDB contextDB = new JukeboxDB();


        public ActionResult Index()
        {
            tblPlaylist itm = contextDB.Playlists.Find(1);

            return View("Index", contextDB.Playlists.OrderByDescending( x => x.Score ).ToList());
        }


        public ActionResult Edit(int id)
        {
            tblPlaylist playlist = contextDB.Playlists.Find(id);

            if(playlist != null)
            {
                return View("CreateEdit", playlist);
            }
            else
            {
                return HttpNotFound();
            }
            
        }

        public ActionResult New()
        {
            tblPlaylist playlist = new tblPlaylist();
            
            if (playlist != null)
            {
                return View("CreateEdit", playlist);
            }
            else
            {
                return HttpNotFound();
            }

        }

        //[Authorize] // If you uncomment this authorize, you'll need to log into the site first
        [HttpPost] // this means that something will "submit" informaiton to it.
        public ActionResult EditSave(tblPlaylist playlist)
        {
            if (ModelState.IsValid && playlist.PlaylistID != 0)
            {
                // these are offically called LINQ statements     
                tblPlaylist playlistToUpdate = contextDB.Playlists
                    .Where(p => p.PlaylistID == playlist.PlaylistID).FirstOrDefault();

                if(playlistToUpdate != null)
                {
                    contextDB.Entry(playlistToUpdate).CurrentValues.SetValues(playlist);
                    contextDB.SaveChanges();
                    ViewBag.RecipeId = playlist.PlaylistID;
                    return RedirectToAction("Index");

                }
                else
                {
                    return HttpNotFound();
                }
            }
            else
            {
                return View("CreateEdit", playlist);

            }
        }


        [HttpPost] // this means that something will "submit" informaiton to it.
        public ActionResult CreateSave(tblPlaylist newPlaylist)
        {
            if(ModelState.IsValid && newPlaylist != null)
            {
                contextDB.Playlists.Add(newPlaylist);
                contextDB.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Up(int id)
        {
            tblPlaylist playlist = contextDB.Playlists.Find(id);

            if (playlist != null)
            {
                playlist.Score++;
                contextDB.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
            
        }

        public ActionResult Down(int id)
        {
            tblPlaylist playlist = contextDB.Playlists.Find(id);

            if (playlist != null)
            {
                if (playlist.Score > 0)
                {
                    playlist.Score--;
                    contextDB.SaveChanges();
                }
                  
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }

        }


    }
}
