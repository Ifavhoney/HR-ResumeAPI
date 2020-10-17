using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ResumeAPI.Models;
using ResumeAPI.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResumeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeController : ControllerBase
    {
        IResumeRepository resumeRepository;

        public ResumeController(IResumeRepository _resumeRepository)
        {
           
            resumeRepository = _resumeRepository;
        } 

        [HttpGet]
        [Route("GetAllInfo")]

        public async Task<IActionResult> GetAllUserInfo()
        {
            try
            {
             var allUsers = await resumeRepository.GetAllUserInfo();
                if (allUsers == null)
                {
                    return NotFound();
                }
                return Ok(allUsers);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }



        [HttpPost]
        [Route("AddInfo")]

        public async Task<IActionResult> AddInfo([FromBody]UserInfo model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var id = await resumeRepository.AddInfo(model);
                    if (id >= 0)
                    {
                        return Ok(id);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("DeleteInfo")]
        public async Task<IActionResult> DeleteInfo(int? infoID)
        {
            int result = 0;

            if (infoID == null)
            {
                return BadRequest();
            }

            try
            {
                result = await resumeRepository.DeleteInfo(infoID);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        [Route("UpdateInfo")]
        public async Task<IActionResult> UpdateInfo([FromBody]UserInfo model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await resumeRepository.UpdateInfo(model);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                             "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();


        }


        [HttpGet]
        [Route("GetAllUserResumes")]

        public async Task<IActionResult> GetAllUserResumes()
        {
            try
            {
                var allUserExperience = await resumeRepository.GetAllUserResumes();
                if (allUserExperience == null)
                {
                    return NotFound();
                }
                return Ok(allUserExperience);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }





        [HttpPut]
        [Route("GetStats")]

        public async Task<IActionResult> GetStats(int? infoID)
        {
            if (infoID == null)
            {
                return BadRequest();
            }
            try
            {
                var userExperience = await resumeRepository.GetStats(infoID);
                if (userExperience == null)
                {
                    return NotFound();
       
                }
                return Ok(userExperience);
       
            }
            catch (Exception) { return BadRequest(); }
       
        }

        [HttpPost]
        [Route("AddUserExperience")]

        public async Task<IActionResult> AddExperience([FromBody]UserExperience model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var id = await resumeRepository.addExperience(model);
                    if (id >= 0)
                    {
                        return Ok(id);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("DeleteExperience")]
        public async Task<IActionResult> DeleteExperience(int? infoID )
        {
            int result = 0;

            if (infoID == null)
            {
                return BadRequest();
            }

            try
            {
                result = await resumeRepository.deleteExperience(infoID);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        [Route("UpdateExperience")]
        public async Task<IActionResult> UpdatePost([FromBody]UserExperience model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await resumeRepository.updateExperience(model);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                             "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }



        [HttpPost]
        [Route("AddOther")]

        public async Task<IActionResult> AddOther([FromBody]UserOther model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var id = await resumeRepository.AddOther(model);
                    if (id >= 0)
                    {
                        return Ok(id);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("DeleteOther")]
        public async Task<IActionResult> DeleteOther(int? infoID)
        {
            int result = 0;

            if (infoID == null)
            {
                return BadRequest();
            }

            try
            {
                result = await resumeRepository.DeleteOther(infoID);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        [Route("UpdateOther")]
        public async Task<IActionResult> UpdateOther([FromBody]UserOther model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await resumeRepository.UpdateOther(model);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                             "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }



















    }
}
