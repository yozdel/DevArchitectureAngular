﻿
using Business.Handlers.Translates.Commands;
using Business.Handlers.Translates.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    /// <summary>
    /// If controller methods will not be Authorize, [AllowAnonymous] is used.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TranslatesController : BaseApiController
    {
        ///<summary>
        ///List Translate
        ///</summary>
        ///<remarks>bla bla bla Translates</remarks>
        ///<return>Translates List</return>
        ///<response code="200"></response>  
        [HttpGet("getall")]
        public async Task<IActionResult> GetList()
        {
            var result = await Mediator.Send(new GetTranslatesQuery());
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        ///<summary>
        ///List Dto Translate
        ///</summary>
        ///<remarks>bla bla bla Translates</remarks>
        ///<return>Translates List</return>
        ///<response code="200"></response>  
        [HttpGet("gettranslatelistdto")]
        public async Task<IActionResult> GetTranslateListDto()
        {
            var result = await Mediator.Send(new GetTranslateListDtoQuery());
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        ///<summary>
        ///It brings the details according to its id.
        ///</summary>
        ///<remarks>bla bla bla </remarks>
        ///<return>Translate List</return>
        ///<response code="200"></response>  
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int translateId)
        {
            var result = await Mediator.Send(new GetTranslateQuery { Id = translateId });
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        /// <summary>
        /// Add Translate.
        /// </summary>
        /// <param name="createTranslate"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTranslateCommand createTranslate)
        {
            var result = await Mediator.Send(createTranslate);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        /// <summary>
        /// Update Translate.
        /// </summary>
        /// <param name="updateTranslate"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTranslateCommand updateTranslate)
        {
            var result = await Mediator.Send(updateTranslate);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        /// <summary>
        /// Delete Translate.
        /// </summary>
        /// <param name="deleteTranslate"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteTranslateCommand deleteTranslate)
        {
            var result = await Mediator.Send(deleteTranslate);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        /// <summary>
        /// Get translates by lang
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>

        [AllowAnonymous]
        [HttpGet("gettranslatesbylang")]

        public async Task<IActionResult> GetTranslatesByLang(string lang)
        {
            var result = await Mediator.Send(new GetTranslatesByLangQuery() { Lang = lang });
            if (result.Success)
            {

                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
