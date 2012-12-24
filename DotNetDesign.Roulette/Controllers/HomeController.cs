using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetDesign.Roulette.Models;

namespace DotNetDesign.Roulette.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var slotTypes = new List<SelectListItem>();
            foreach (var slotTypeValue in Enum.GetValues(typeof(SlotType)))
            {
                var slotType = (SlotType)slotTypeValue;
                var selectListItem = new SelectListItem();
                selectListItem.Text = slotType.ToString();
                selectListItem.Value = ((int) slotTypeValue).ToString();
                slotTypes.Add(selectListItem);
            }

            return View(slotTypes);
        }

        [HttpPost]
        public JsonResult CalculateBets(CalculateBetsViewModel model)
        {
            var random = new Random();

            var winningNumbers = new List<Number>();
            for (var i = 0; i < model.Iterations; i++)
            {
                winningNumbers.Add((Number) random.Next(1, 39));
            }

            var gameResults = new List<GameResult>(winningNumbers.Count);
            gameResults.AddRange(winningNumbers.Select(winningNumber => new GameResult(winningNumber, model.Bets)));

            var investment = gameResults.Sum(result => result.Investment);
            var delta = gameResults.Sum(result => result.Delta);


            return Json(new {investment, delta, gameResults});
        }
    }
}
