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
    public class InterviewsController : ApiController
    {
        // db constructor
        private SCPEntities db = new SCPEntities();

        [HttpGet]
        [Route("api/v1/interviews/all")]
        public IHttpActionResult all()
        {

            List<IInterviews> data = db.interviews.Select(s => new IInterviews()
            {
                scp = s.scp_id,
                interview_date = s.interview_date,
                transcription = s.transcription
            }).ToList();

            return Ok(data);
        }

        [HttpGet]
        [Route("api/v1/interviews/find")]
        public IHttpActionResult all([FromUri] int scp)
        {
            try
            {

                List<IInterviews> data = db.interviews
                .Where(w => w.scp_id == scp)
                .Select(s => new IInterviews()
                {
                    scp = s.scp_id,
                    interview_date = s.interview_date,
                    transcription = s.transcription

                }).ToList();
               return Ok(data);

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}