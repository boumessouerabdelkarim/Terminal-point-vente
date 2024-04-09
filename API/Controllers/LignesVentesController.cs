using API.Services;
using API.IServices;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Core.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/lignes_ventes")]
    [ApiController]
    public class LignesVentesController : ControllerBase
    {
        protected readonly ILignedeVenteService _service;

        public LignesVentesController(ILignedeVenteService service)
        {
            _service = service;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<ActionResult<List<Lignedevente>>> GetAll()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                var lst = await _service.GetAll();



                if (lst.Count != 0)
                {
                    return new OkObjectResult(lst);
                }
                else
                {
                    var showmessage = "Pas d'element dans la liste";
                    dict.Add("Message", showmessage);
                    return NotFound(dict);

                }

            }
            catch (Exception ex)
            {


                var showmessage = "Erreur" + ex.Message;
                dict.Add("Message", showmessage);
                return BadRequest(dict);
            }
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<Lignedevente>> GetLignedevente(int id)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                var lst = await _service.GetLignedevente(id);



                if (lst != null)
                {
                    return new OkObjectResult(lst);
                }
                else
                {
                    var showmessage = "Pas de session avec ce id";
                    dict.Add("Message", showmessage);
                    return NotFound(dict);

                }

            }
            catch (Exception ex)
            {


                var showmessage = "Erreur" + ex.Message;
                dict.Add("Message", showmessage);
                return BadRequest(dict);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddLignedevente(Lignedevente e)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                await _service.AddLignedevente(e)
                          .ConfigureAwait(false);

                var showmessage = "Insertion effectuee avec succes";
                dict.Add("Message", showmessage);
                return Ok(dict);




            }
            catch (Exception ex)
            {
                var showmessage = "Erreur" + ex.Message;
                dict.Add("Message", showmessage);
                return BadRequest(dict);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        [Route("{id}")]
        [HttpPut]
        public async Task<ActionResult> UpdateLignedevente(Lignedevente e)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                await _service.UpdateLignedevente(e)
                          .ConfigureAwait(false);

                var showmessage = "Modification effectuee avec succes";
                dict.Add("Message", showmessage);
                return Ok(dict);




            }
            catch (Exception ex)
            {
                var showmessage = "Erreur" + ex.Message;
                dict.Add("Message", showmessage);
                return BadRequest(dict);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteLignedevente(int id)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                await _service.DeleteLignedevente(id)
                          .ConfigureAwait(false);

                var showmessage = "Suppression effectuee avec succes";
                dict.Add("Message", showmessage);
                return Ok(dict);




            }
            catch (Exception ex)
            {
                var showmessage = "Erreur" + ex.Message;
                dict.Add("Message", showmessage);
                return BadRequest(dict);
            }
        }
    }
}
