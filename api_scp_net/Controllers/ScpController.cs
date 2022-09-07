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
    public class ScpController : ApiController
    {

        // db constructor
        private scp_databaseEntities db = new scp_databaseEntities();

        [HttpGet]
        [Route("api/v1/all")]
        public IHttpActionResult getAll()
        {
            try
            {
                List<IScp> data = db.scps.Select( s => new IScp() 
                { 
                    id = s.id,
                    name = s.name,
                    feeling = s.feeling,
                    picture = s.picture,
                    class_id = db.classes.Where(w => w.id == s.class_id)
                    .Select(e => new IClasses()
                    {
                        id = e.id,
                        name = e.name,
                        description = e.description
                    }
                    ).ToList(),
                    type_id = s.type_id,
                    feature_id = s.feature_id
                } ).ToList();

                return Ok(data);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("api/v1/scp/{scpId}")]
        public IHttpActionResult getById(int scpId)
        {
            try
            {

                List<IScp> data = db.scps.Select( s => new IScp()
                {
                    id = s.id,
                    name = s.name,
                    feeling = s.feeling,
                    picture = s.picture,
                    class_id = db.classes.Where( w => w.id == s.class_id)
                    .Select( e => new IClasses()
                    {
                        id = e.id,
                        name = e.name,
                        description = e.description
                    }
                    ).ToList(),
                    type_id = s.type_id,
                    feature_id = s.feature_id
                }).Where( w => w.id == scpId).ToList();

                return Ok(data);

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("api/v1/{firstId}/{lastId}")]
        public IHttpActionResult getByIdRange(int firstId, int lastId)
        {
            try
            {

                List<IScp> data = db.scps.Select(s => new IScp()
                {
                    id = s.id,
                    name = s.name,
                    feeling = s.feeling,
                    picture = s.picture,
                    class_id = db.classes.Where(w => w.id == s.class_id)
                   .Select(e => new IClasses()
                   {
                       id = e.id,
                       name = e.name,
                       description = e.description
                   }
                   ).ToList(),
                    type_id = s.type_id,
                    feature_id = s.feature_id
                }).Where(w => w.id >= firstId && w.id <= lastId).ToList();

                return Ok(data);

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
