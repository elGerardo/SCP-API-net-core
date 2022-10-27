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
       private SCPEntities db = new SCPEntities();

        /*------------------SCP ROUTES------------------*/

        [HttpGet]
        [Route("api/v1/scp/all")]
        public IHttpActionResult all([FromUri] int limit = 20)
        {
            try
            {
                List<IScp> data = db.scp.Select( s => new IScp()
                {
                    id = s.id,
                    name = s.name,
                    feeling = s.feeling,
                    picture = s.picture,
                    classe = new IBaseNameFeature(){ 
                        name = s.classes.name,
                        description = s.classes.description
                    },
                    type = new IBaseNameFeature()
                    {
                        name = s.types.name,
                        description = s.types.description
                    },
                    features = new IFeatures()
                    {
                        short_description = s.features.short_description,
                        full_description = s.features.full_description,
                        color = s.features.color,
                        height = s.features.height,
                        width = s.features.width,
                        weight = s.features.weight
                    }
                } ).Take(limit).ToList();

                return Ok(data);

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("api/v1/scp/find")]
        public IHttpActionResult find([FromUri] int scp)
        {
            try
            {
                IScp data = db.scp.Select(s => new IScp()
                {
                    id = s.id,
                    name = s.name,
                    feeling = s.feeling,
                    picture = s.picture,
                    classe = new IBaseNameFeature()
                    {
                        name = s.classes.name,
                        description = s.classes.description
                    },
                    type = new IBaseNameFeature()
                    {
                        name = s.types.name,
                        description = s.types.description
                    },
                    features = new IFeatures()
                    {
                        short_description = s.features.short_description,
                        full_description = s.features.full_description,
                        color = s.features.color,
                        height = s.features.height,
                        width = s.features.width,
                        weight = s.features.weight
                    }
                }).Where(w => w.id == scp).FirstOrDefault();

                return Ok(data);

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("api/v1/scp/range")]
        public IHttpActionResult getByIdRange([FromUri] int first, [FromUri] int last)
        {
            try
            {
                List<IScp> data = db.scp.Select(s => new IScp()
                {
                    id = s.id,
                    name = s.name,
                    feeling = s.feeling,
                    picture = s.picture,
                    classe = new IBaseNameFeature()
                    {
                        name = s.classes.name,
                        description = s.classes.description
                    },
                    type = new IBaseNameFeature()
                    {
                        name = s.types.name,
                        description = s.types.description
                    },
                    features = new IFeatures()
                    {
                        short_description = s.features.short_description,
                        full_description = s.features.full_description,
                        color = s.features.color,
                        height = s.features.height,
                        width = s.features.width,
                        weight = s.features.weight
                    }
                }).Where(w => w.id >= first && w.id <= last).ToList();

                return Ok(data);

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("api/v1/scp/enemies")]
        public IHttpActionResult getEnemies([FromUri] int scp)
        {
            try
            {
                IBaseEnemies data = new IBaseEnemies()
                {
                    scp = scp,
                    enemies = db.scp_enemies.Select(s => new IEnemies()
                    {
                        scp_enemy = s.scp_enemy_id,
                        name = s.scp.name,
                        scp_link = s.scp.scp_link
                    }).ToList(),
            };
                return Ok(data);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /*------------------CLASSES ROUTES------------------*/
        /*
        [HttpGet]
        [Route("api/v1/allClasses")]
        public IHttpActionResult getAllClasses()
        {
            try
            {
                List<IClasses> data = db.classes.Select(s => new IClasses()
                {
                    id = s.id,
                    name = s.name,
                    description = s.description
                }).ToList();

                return Ok(data);

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        */
    }
}
