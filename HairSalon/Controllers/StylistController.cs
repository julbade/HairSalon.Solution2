using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class StylistController : Controller
  {

    [HttpGet("/stylists")]
    public ActionResult Index()
    {
      List<Stylist> allStylists = Stylist.GetAll();
      return View(allStylists);
    }

    [HttpGet("/stylists/new")]
    public ActionResult CreateForm()
    {
      return View();
    }

    [HttpPost("/stylists")]
    public ActionResult Create()
    {
      Stylist newStylist = new Stylist(Request.Form["new-stylist"]);
      newStylist.Save();
      List<Stylist> allStylists = Stylist.GetAll();
      return RedirectToAction("Index");
    }

    [HttpGet("/stylists/{id}")]
    public ActionResult Details(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist selectedStylist = Stylist.Find(id);
      List<Client> stylistClients = selectedStylist.GetClients();
      model.Add("specialty", selectedStylist);
      model.Add("stylist", selectedStylist);
      model.Add("client", stylistClients);
      return View(model);
   }

  [HttpPost("/stylists/{id}")]
  public ActionResult CreateClient(string clientName, int stylistId)
  {
    Dictionary<string, object> model = new Dictionary<string, object>();
    Stylist foundStylist = Stylist.Find(stylistId);
    Client newClient = new Client(Request.Form["new-client"], stylistId);
    newClient.Save();
    List<Client> stylistClients = foundStylist.GetClients();
    model.Add("client", stylistClients);
    model.Add("stylist", foundStylist);
    return RedirectToAction("Details");
  }

 //  [HttpGet("/stylists/specialties/{id}")]
 //  public ActionResult Specialties(int id)
 //  {
 //    Dictionary<string, object> model = new Dictionary<string, object>();
 //    Stylist selectedStylist = Stylist.Find(id);
 //    List<Specialty> stylistSpecialties = selectedStylist.GetSpecialties();
 //    model.Add("stylist", selectedStylist);
 //    model.Add("specialty", stylistSpecialties);
 //    return View(model);
 // }
 //
 // [HttpPost("/stylists/specialties/{id}")]
 // public ActionResult CreateSpecialty(string specialtyName, int stylistId)
 // {
 //   Dictionary<string, object> model = new Dictionary<string, object>();
 //   Stylist foundStylist = Stylist.Find(stylistId);
 //   Specialty newSpecialty = new Specialty(Request.Form["new-specialty"], stylistId);
 //   newSpecialty.Save();
 //   List<Specialty> stylistSpecialties = foundStylist.GetSpecialties();
 //   model.Add("specialty", stylistSpecialties);
 //   model.Add("stylist", foundStylist);
 //   return RedirectToAction("Specialties");
 // }

  [HttpPost("/stylists/delete")]
  public ActionResult DeleteAll()
  {

    Stylist.DeleteAll();
    return View();
  }

}
}
