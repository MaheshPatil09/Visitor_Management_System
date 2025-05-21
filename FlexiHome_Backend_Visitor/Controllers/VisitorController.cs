using FlexiHome_Backend_Visitor.VistorInterface;
using Microsoft.AspNetCore.Mvc;
using FlexiHome_Backend_Visitor.VisitorModel;
namespace FlexiHome_Backend_Visitor.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class VisitorController : Controller
    {
        private readonly IVisitor _visitor;

        public VisitorController(IVisitor visitor)
        {
            _visitor = visitor;
        }

        [HttpPost]
         public async Task<IActionResult> AddVisitorInSociety(VisitorModelClass visitorModel)
        {
            try
            {
                 var response = await _visitor.AddVisitorInSocietyAsync(visitorModel);
                 return Ok(response);       

            } catch(Exception)
            {
                  return StatusCode(500, "An Error Occured While Adding The Visitor In Society ");
            } 
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVisitorsInSociety()
        {
            List<VisitorModelClass> visitors = new List<VisitorModelClass>();
            try
            {
                visitors = await _visitor.GetAllVisitorsInSocietyAsync();
                if(visitors ==  null || visitors.Count == 0)
                {
                    return BadRequest("There Are No Visitors In Society ");
                }
                return Ok(visitors);

            }catch (Exception)
            {
                return StatusCode(500, "An Error Occured While Getting All Of The Visitors");
            }
        }

        [HttpGet]
         
        public async Task<IActionResult> GetVisitorInSocietyByUniqueId(string id)
        {

            try
            {
                 var response = await  _visitor.GetVisitorInSocietyAsync(id);
                 if(response == null)
                {
                    return BadRequest("There Is No Visitor With The Given Id In Society ");
                }
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500, "The Error Occured While Fetching The Resident With Given Id");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVisitorInSociety(string visitorId, VisitorModelClass visitor)
        {
            try
            {
                var response = await _visitor.UpdateVisitorInSocietyAsync(visitorId, visitor);
                if(response == null)
                {
                    return BadRequest("The Visitor With The Given Id Not Found In The Society");
                        
                 }
                return Ok(response);

            }
            catch(Exception)
            {
                return StatusCode(500, "An Error Occured While Updating The Visitor In Society ");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteVisitorInSociety(string visitorId)
        {
            try
            {
               var response = await _visitor.DeleteVisitorInSociety(visitorId);
               if(response == null)
                {
                    return BadRequest("The Visitor With The Given Id Is Not Found In The Society ");
                }
                return Ok("Visitor In Soceity Deleted SuccessFully ");
            }
            catch(Exception)
            {
                return StatusCode(500,"An Error Occured While Deleting The Visitor In Society.");
            }
        }
    }
}
