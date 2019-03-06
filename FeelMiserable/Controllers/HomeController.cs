using FeelMiserable.Models;
using FeelMiserable.Services;
using Microsoft.AspNet.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FeelMiserable.Controllers
{
    public class HomeController : Controller
    {
        private Context _context = new Context();

        Randomize randomize;
        private SlangStore slang = null;


        public HomeController(Context db)
        {
            _context = db;
        }

        public HomeController()
        {

        }

        public ActionResult Index()
        {
            ViewBag.slang = "";
            return View();
        }

        [HttpGet]
        public JsonResult Hit()
        {

            List<SlangStore> slangs = _context.SlangStores.ToList();
            List<SlangStore> tempslangs = new List<SlangStore>();
            tempslangs = (List<SlangStore>)Session["slangs"];

            randomize = new Randomize(); //it is an object
            if (tempslangs == null)
            {
                tempslangs = slangs;
                Session["slangs"] = tempslangs;

                slang = randomize.GetRandom(tempslangs);
                tempslangs = (List<SlangStore>)Session["slangs"];
                tempslangs.Remove(slang);
                Session["slangs"] = tempslangs;
                ViewBag.slang = slang.Name;
            }
            else if (tempslangs.Count != slangs.Count && tempslangs.Count > 0)
            {

                slang = randomize.GetRandom(tempslangs);

                tempslangs = (List<SlangStore>)Session["slangs"];
                tempslangs.Remove(slang);
                Session["slangs"] = tempslangs;
                ViewBag.slang = slang.Name;
            }
            else
            {

                string hot = "suggested to reveal the hidden you with just... no one! Share it if you had fun!";
                Session["developer"] = "Developed By Dipjyoti";
                return Json(hot, JsonRequestBehavior.AllowGet);

            }

            return Json(slang.Name, JsonRequestBehavior.AllowGet);
        }

        //public int GetUniqueId(List<int> slangs, int id)
        //{
        //    int count = 0;
        //    foreach (var item in slangs)
        //    {
        //        if (item == id)
        //        {
        //            count++;
        //        }
        //    }

        //    if (count > 0)
        //    {
        //        var tempIdss = Session["temp"];
        //        var tempIdLists = tempIdss as List<int>;

        //        var newuniqueId = randomize.GetRandom();

        //        GetUniqueId(tempIdLists, newuniqueId);
        //    }

        //    if (count == 0)
        //    {
        //        foundId = id;
        //    }

        //    return foundId;
        //}
    }



}