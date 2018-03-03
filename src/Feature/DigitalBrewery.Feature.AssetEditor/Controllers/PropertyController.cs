using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using System.IO;
using System.Web.Mvc;

namespace DigitalBrewery.Feature.AssetEditor.Controllers
{
    public class PropertyController : Controller
    {
        public ActionResult GetProperty(Guid id, string dbName)
        {
            if (!ID.IsID(id.ToString()))
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }

            Database db = Sitecore.Configuration.Factory.GetDatabase(dbName);

            if (db == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }

            MediaItem mediaItem = db.GetItem(new ID(id));

            if (mediaItem == null)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }

            return Json(GenerateMediaHtml(mediaItem), JsonRequestBehavior.AllowGet);
        }

        protected virtual string GenerateMediaHtml(MediaItem mediaItem)
        {
            using (StreamReader reader = new StreamReader(mediaItem.GetMediaStream()))
            {
                return reader.ReadToEnd();
            }
        }
    }
}