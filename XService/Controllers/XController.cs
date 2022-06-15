using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XService.Models;
using XLibrary;

namespace XService.Controllers
{
    [Route("api/controller/")]
    [ApiController]
    public class XController : ControllerBase
    {
        static projectxxContext context = new projectxxContext();
        [HttpGet("officers")]
        public ActionResult<IEnumerable<officers>>GetAllOfficers()
        {
            IEnumerable<officers> officers = context.officers;
            if(officers == null)
            {
                return NotFound();
            }
            return Ok(officers);
        }
        [HttpGet("trial")]
        public ActionResult<IEnumerable<trial>> GetAllTrials()
        {
            return context.trial;
        }
        [HttpGet("criminal")]
        public ActionResult<IEnumerable<criminal>> GetAllCriminals()
        {
            return context.criminal;
        }
        [HttpGet("non_criminal")]
        public ActionResult<IEnumerable<non_criminal>> GetAllNonCriminals()
        {
            return context.non_criminal;
        }
        [HttpPost("officers")]
        public ActionResult<officers> AddOfficers([FromBody] officers newOfficer)
        {
            int id = context.officers.Select(x=>x.of_id).Max()+1;
            newOfficer.of_id = id;
            context.officers.Add(newOfficer);
            context.SaveChanges();
            return Ok(newOfficer);
        }
        [HttpPost("criminal")]
        public ActionResult<criminal> AddCriminal([FromBody] criminal newCriminal)
        {
            int id = context.criminal.Select(x=>x.p_id).Max()+1;
            newCriminal.p_id = id;
            context.criminal.Add(newCriminal);
            context.SaveChanges();
            return Ok(newCriminal);
        }
        [HttpPost("non_criminal")]
        public ActionResult<non_criminal> AddNonCriminal([FromBody] non_criminal newNonCriminal)
        {
            int id = context.non_criminal.Select(x=>x.p_id).Max()+1;
            newNonCriminal.p_id= id;
            context.non_criminal.Add(newNonCriminal);
            context.SaveChanges();
            return Ok(newNonCriminal);
        }
        [HttpPost("trial")]
        public ActionResult<trial> AddTrial([FromBody] trial newTrial)
        {
            int id = context.trial.Select(x=>x.t_id).Max()+1;
            newTrial.t_id= id;
            context.trial.Add(newTrial);
            context.SaveChanges();
            return Ok(newTrial);
        }
        [HttpDelete("criminal/{p_id}")]
        public ActionResult<criminal> DeleteCriminal(int p_id)
        {
            var dc = context.criminal.Where(x=>x.p_id == p_id).FirstOrDefault();
            if (dc != null)
            {
                context.criminal.Remove(dc);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("trial/{t_id}")]
        public ActionResult DeleteTrial(int t_id)
        {
            var t = context.trial.Where(t => t.t_id == t_id).FirstOrDefault();
            if(t == null)
            {
                return NotFound();
            }
            else
            {
                context.trial.Remove(t);
                context.SaveChanges();
                return Ok();
            }
        }
        [HttpDelete("officers/{of_id}")]
        public ActionResult DeleteOfficer(int of_id)
        {
            var dof = context.officers.Where(d => d.of_id == of_id).FirstOrDefault();
            if(dof == null)
            {
                return NotFound();
            }
            else
            {
                context.officers.Remove(dof);
                context.SaveChanges();
                return Ok();
            }
        }
        [HttpPatch("officers/{of_id}")]
        public ActionResult UpdateOfficers(int of_id, [FromBody] officers officers)
        {
            officers o = context.officers.Where(o => o.of_id == of_id).FirstOrDefault();
            if (o == null)
            {
                return NotFound();
            }
            else
            {
                o.of_id = officers.of_id;
                o.age = officers.age;
                o.image = officers.image;
                o.name = officers.name;
                o.yearsinposition = officers.yearsinposition;
                o.t_id = officers.t_id;
                context.SaveChanges();
                return Ok();

            }
        }
        [HttpPatch("non_criminal/{p_id}")]
        public ActionResult UpdateNonCriminal(int p_id, [FromBody] non_criminal nonCriminal)
        {
            non_criminal ncc = context.non_criminal.Where(ncc => ncc.p_id == p_id).FirstOrDefault();
            if (ncc == null)
            {
                return NotFound();
            }
            else
            {
                ncc.address = nonCriminal.address;
                ncc.age = nonCriminal.age;
                ncc.image = nonCriminal.image;
                ncc.job = nonCriminal.job;
                ncc.name = nonCriminal.name;
                context.SaveChanges();
                return Ok();

            }
        }
        [HttpPatch("criminal/{p_id}")]
        public ActionResult UpdateCriminal(int p_id, [FromBody] criminal criminal)
        {
            criminal cc = context.criminal.Where(cc=>cc.p_id==p_id).FirstOrDefault();
            if(cc == null)
            {
                return NotFound();
            }
            else
            {
                cc.address = criminal.address;
                cc.age = criminal.age;
                cc.image = criminal.image;
                cc.job = criminal.job;
                cc.name = criminal.name;
                context.SaveChanges();
                return Ok();
            }
        }
        [HttpPatch("trial/{t_id}")]
        public ActionResult UpdateTrial(int t_id, [FromBody] trial trial)
        {
            trial tc = context.trial.Where(tc=>tc.t_id==t_id).FirstOrDefault();
            if (tc == null)
            {
                return NotFound();
            }
            else
            {
                tc.place = trial.place;
                tc.date = trial.date;
                tc.t_id = trial.t_id;
                context.SaveChanges();
                return Ok();
            }
            
        }

    }
}
