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
    [Route("api/articles")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        protected readonly IArticleService _service;

        public ArticlesController(IArticleService service)
        {
            _service = service;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
       
        [HttpGet]
        public async Task<ActionResult<List<Article>>> GetAll()
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
        public async Task<ActionResult<Article>> GetArticle(int id)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                var lst = await _service.GetArticle(id);



                if (lst != null)
                {
                    return new OkObjectResult(lst);
                }
                else
                {
                    var showmessage = "Pas d'cour avec ce id";
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
        public async Task<ActionResult> AddArticle(Article e)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                await _service.AddArticle(e)
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
        public async Task<ActionResult> UpdateArticle(Article e)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                await _service.UpdateArticle(e)
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
        public async Task<ActionResult> DeleteArticle(int id)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                await _service.DeleteArticle(id)
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
