﻿using Business.Handlers.GroupClaims.Commands;
using Business.Handlers.GroupClaims.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    ///  
    [Route("api/[controller]")]
    [ApiController]
    public class GroupClaimsController : BaseApiController
    {
        ///<summary>
        ///GroupClaims list
        ///</summary>
        ///<remarks>GroupClaims</remarks>
        ///<return>GroupClaims List</return>
        ///<response code="200"></response>  
        [HttpGet("getall")]
        //[AllowAnonymous]
        public async Task<IActionResult> GetList()
        {
            var result = await Mediator.Send(new GetGroupClaimsQuery());
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
        ///<return>GroupClaims List</return>
        ///<response code="200"></response>  
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await Mediator.Send(new GetGroupClaimQuery { Id = id });
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        ///<summary>
        ///Brings up Claims by Group Id.
        ///</summary>
        ///<remarks>bla bla bla </remarks>
        ///<return>GroupClaims List</return>
        ///<response code="200"></response>  
        [HttpGet("getgroupclaimsbygroupid")]
        public async Task<IActionResult> GetGroupClaimsByGroupId(int id)
        {
            var result = await Mediator.Send(new GetGroupClaimsLookupByGroupIdQuery { GroupId = id });
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }


        /// <summary>
        /// Addded GroupClaim .
        /// </summary>
        /// <param name="createGroupClaim"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateGroupClaimCommand createGroupClaim)
        {
            var result = await Mediator.Send(createGroupClaim);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        /// <summary>
        /// Update GroupClaim.
        /// </summary>
        /// <param name="updateGroupClaim"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGroupClaimCommand updateGroupClaim)
        {
            var result = await Mediator.Send(updateGroupClaim);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        /// <summary>
        /// Delete GroupClaim.
        /// </summary>
        /// <param name="deleteGroupClaim"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteGroupClaimCommand deleteGroupClaim)
        {
            var result = await Mediator.Send(deleteGroupClaim);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
