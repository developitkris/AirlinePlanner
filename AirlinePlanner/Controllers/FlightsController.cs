using System;
using System.Collections.Generic;
using AirlinePlanner.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirlinePlanner.Controllers
{
  public class FlightsController : Controller
  {
    [HttpGet("/flights")]
    public ActionResult Index()
    {
      List<Flight> allFlights = Flight.GetAllFlights();
      return View(allFlights);
    }

    [HttpGet("/flights/new")]
    public ActionResult CreateForm()
    {
        return View();
    }

    [HttpPost("/flights")]
    public ActionResult Create()
    {
        Flight newFlight = new Flight(Request.Form["flight-name"], Request.Form["date"], Request.Form["dept-city"], Request.Form["arrival-city"], Request.Form["status"]);
        newFlight.Save();
        return RedirectToAction("Success", "~/Flights/Index");
    }

    [HttpGet("/flights/{id}")]
    public ActionResult Details(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Flight selectedFlight = Flight.Find(id);
      List<City> flightCities = selectedFlight.GetCities();
      List<City> allCities = City.GetAllCities();
      model.Add("selectedFlight", selectedFlight);
      model.Add("flightCities", flightCities);
      model.Add("allCities", allCities);
      return View(model);
    }
  }
}
