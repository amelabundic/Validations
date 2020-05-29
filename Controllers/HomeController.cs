using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using javascript7.Models;
using System.Text;

namespace javascript7.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
public IActionResult Validacija(string ime,string prezime,string lozinka,string potvrda)
{
    Dictionary<string,string> rjecnikGresaka = new Dictionary<string, string>();
    if (ime ==null)
    {
     rjecnikGresaka.Add("ime","Niste unijeli ime");   
    }
    if (prezime ==null)
    {
     rjecnikGresaka.Add("prezime","Niste unijeli prezime");   
    }
    if (lozinka ==null)
    {
     rjecnikGresaka.Add("lozinka","Niste unijeli lozinku");   
    }
    if (potvrda ==null)
    {
     rjecnikGresaka.Add("potvrda","Niste unijeli potvrdu");   
    }
    if (lozinka != potvrda)
    {
        rjecnikGresaka.Add("potvrda1","Potvrda ne odgovara lozinci");
    }
    if (rjecnikGresaka.Count == 0)
    {
        return Redirect("/access.html");
    }
    else
    {
     StringBuilder sb = new StringBuilder();

     foreach (string greska in rjecnikGresaka.Values)
     {
         sb.Append(greska + "_");
     }
     return Redirect("/error.html?poruke=" + sb.ToString());
    }
}
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
