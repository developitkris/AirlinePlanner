using System;
using System.Collections.Generic;
using AirlinePlanner.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirlinePlanner.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();  //returns index view
    }

    [HttpGet("/success")]
    public ActionResult Success()
    {
        return View("Success");
    }
  }
}
