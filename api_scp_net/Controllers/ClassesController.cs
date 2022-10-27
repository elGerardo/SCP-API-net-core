using api_scp_net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace api_scp_net.Controllers
{
    public class ClassesController : ApiController
    {
        // db constructor
        private SCPEntities db = new SCPEntities();

        [HttpGet]
        [Route("api/v1/class/all")]
        public IHttpActionResult all()
        {
            try
            {
                List<IClasses> data = db.classes.Select(s => new IClasses()
                {
                    name = s.name,
                    description = s.description,
                    icon = s.icon
                }).ToList();

                return Ok(data);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("api/v1/class/find")]
        public IHttpActionResult find([FromUri] string classe)
        {
            try
            {
                IClasses data = db.classes.Select(s => new IClasses()
                {
                    name = s.name,
                    description = s.description,
                    icon = s.icon
                }).Where(w => w.name == classe).FirstOrDefault();

                return Ok(data);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}