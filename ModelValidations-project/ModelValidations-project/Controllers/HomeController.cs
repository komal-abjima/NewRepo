﻿using Microsoft.AspNetCore.Mvc;
using ModelValidations_project.Models;

namespace ModelValidations_project.Controllers
{
    public class HomeController : Controller
    {
        [Route("Register")]
        public IActionResult Index(Person person)
        {
            if (!ModelState.IsValid)
            {
                //List<string> errorsList = new List<string>();
                //foreach (var value in ModelState.Values)
                //{
                //    foreach (var error in value.Errors)
                //    {
                //        errorsList.Add(error.ErrorMessage);
                //    }

                //}
                string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors)
                    .Select(err => err.ErrorMessage));
                return BadRequest();
            }
            return Content($"{person}");
        }
    }
}