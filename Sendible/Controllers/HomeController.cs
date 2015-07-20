using Sendible.Models;
using System;
using System.Web.Mvc;

namespace Sendible.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index(string command)
        {
            string[] commandLines;
            string roversPosition, roversInstruction, result = null;

            if (!String.IsNullOrEmpty(command))
            {
                Plateau plateau = null;
                command = command.Trim().Replace("\r\n", ",");
                commandLines = command.Split(',');

                if (commandLines.Length > 0) {
                    plateau = DefiningPlateauSize(commandLines[0]);                    
                }

                for (int i = 1; i < commandLines.Length; i = i + 2)
                {
                    roversPosition = commandLines[i];
                    roversInstruction = commandLines[i + 1];

                    string[] roversPositionSplitted = roversPosition.Split(' ');
                        
                    try
                    {
                        Rover rover = new Rover(
                        Convert.ToInt32(roversPositionSplitted[0]),
                        Convert.ToInt32(roversPositionSplitted[1]),
                        (CardinalCompass)Convert.ToChar(roversPositionSplitted[2]));
                    
                        result = result + "\r\n" + rover.SetCommands(roversInstruction, plateau);
                    }
                    catch (Exception exception)
                    {
                        result = exception.Message;
                    }
                }

                @ViewBag.Result = result;
            }

            return View();
        }

        private Plateau DefiningPlateauSize(string command)
        {
            string[] plateauSizeSplitted = command.Split(' ');
            return new Plateau(Convert.ToInt32(plateauSizeSplitted[0]), Convert.ToInt32(plateauSizeSplitted[1]));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}