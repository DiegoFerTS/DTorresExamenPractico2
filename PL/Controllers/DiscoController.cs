using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class DiscoController : Controller
    {
        // GET: Disco
        public ActionResult GetAll()
        {
            ML.Result resultado = BL.Disco.GetAll();
            ML.Disco disco = new ML.Disco();

            disco.Discos = resultado.Objects;

            return View(disco);
        }

        [HttpGet]
        public ActionResult Form(int? idDisco)
        {
            if (idDisco == null)
            {
                idDisco = 0;
            }

            if (idDisco == 0) // ADD
            {
                return View();
            }
            else // UPDATE
            {
                ML.Disco disco = new ML.Disco();
                ML.Result resultado = BL.Disco.GetById(idDisco.Value);

                disco = (ML.Disco)resultado.Object;

                return View(disco);
            }
        }
    }
}