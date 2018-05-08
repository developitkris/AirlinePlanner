using System;
using System.Collections.Generic;
using AirlinePlanner.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirlinePlanner.Controllers
{
  public class CitiesController : Controller
  {
    [HttpGet("/cities")]
    public ActionResult Index()
    {
      List<City> allCities = City.GetAllCities();
      return View(allCities);
    }

    [HttpGet("/cities/new")]
    public ActionResult CreateForm()
    {
        return View();
    }

    [HttpPost("/cities")]
    public ActionResult Create()
    {
        City newCity = new City(Request.Form["city-name"], Request.Form["airline-name"]);
        newCity.Save();
        return RedirectToAction("Success", "~/Cities/Index");
    }
  }
}
