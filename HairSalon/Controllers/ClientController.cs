using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
  public class ClientController : Controller
  {
    [HttpGet("/stylists/{stylistId}/clients/new")]
    public ActionResult New(int stylistId)
    {
     Stylist stylist = Stylist.Find(stylistId);
     return View(stylist);
    }

    [HttpGet("/stylists/{stylistId}/clients/{clientId}")]
    public ActionResult Show(int stylistId, int clientId)
    {
      Client client = Client.Find(clientId);
      Dictionary<string, object> info = new Dictionary<string, object>();
      Stylist stylist = Stylist.Find(stylistId);
      info.Add("client", client);
      info.Add("stylist", stylist);
      return View(info);
    }

    [HttpPost("/stylists/{stylistId}/clients/{clientId}")]
    public ActionResult Update(int stylistId, int clientId, string newName, string newPhone)
    {
      Client client = Client.Find(clientId);
      client.Edit(newName, newPhone);
      Dictionary<string, object> info = new Dictionary<string, object>();
      Stylist stylist = Stylist.Find(stylistId);
      info.Add("stylist", stylist);
      info.Add("client", client);
      return View("Show", info);
    }

    [HttpGet("/stylists/{stylistId}/clients/{clientId}/edit")]
    public ActionResult Edit(int stylistId, int clientId)
    {
      Dictionary<string, object> info = new Dictionary<string, object>();
      Stylist stylist = Stylist.Find(stylistId);
      info.Add("stylist", stylist);

      Client client = Client.Find(clientId);
      info.Add("client", client);
      return View(info);
    }

    [HttpPost("/stylists/{stylistId}/clients/{clientId}/delete")]
    public ActionResult Delete(int clientId, int stylistId)
    {
      Dictionary<string, object> info = new Dictionary<string, object>();
      Client client = Client.Find(clientId);
      Stylist stylist  = Stylist.Find(stylistId);
      info.Add("client", client);
      info.Add("stylist", stylist);
      client.Delete();
      return View("Delete", info);
    }
  }
}
