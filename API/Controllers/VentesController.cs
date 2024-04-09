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
    [Route("api/ventes")]
    [ApiController]
    public class VentesController : ControllerBase
    {
        protected readonly IVenteService _service;

        public VentesController(IVenteService service)
        {
            _service = service;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<ActionResult<List<Vente>>> GetAll()
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
        public async Task<ActionResult<Vente>> GetVente(int id)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                var lst = await _service.GetVente(id);



                if (lst != null)
                {
                    return new OkObjectResult(lst);
                }
                else
                {
                    var showmessage = "Pas de vente avec ce id";
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
        public async Task<ActionResult> AddVente(Vente e)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                await _service.AddVente(e)
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
        public async Task<ActionResult> UpdateVente(Vente e)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                await _service.UpdateVente(e)
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
        public async Task<ActionResult> DeleteVente(int id)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                await _service.DeleteVente(id)
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
