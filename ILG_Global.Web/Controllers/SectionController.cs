using ILG_Global.BussinessLogic.Abstraction.Services;
using ILG_Global.BussinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ILG_Global.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly ISectionDetailService oSectionDetailService;

        public SectionController(ISectionDetailService oSectionDetailService)
        {
            this.oSectionDetailService = oSectionDetailService;
        }
        // GET: api/<SectionController>

        [HttpGet]
        public async Task<List<SectionDetailViewModel>> GetAllSections()
        {
            return await oSectionDetailService.SelectAllAsync();
        }

        // GET api/<SectionController>/5
        [HttpGet("{id}")]
        public async Task<SectionDetailViewModel> GetSectionByID(int id)
        {
            return await oSectionDetailService.SelectByIdAsync(id);
        }

        // POST api/<SectionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<SectionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SectionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
