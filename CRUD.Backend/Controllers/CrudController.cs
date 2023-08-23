using CRUD.Backend.Managers;
using CRUD.Backend.Repository.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CrudController : ControllerBase
    {
        private readonly ICrudManager _crudManager;

        public CrudController(ICrudManager crudManager)
        {
            _crudManager = crudManager;
        }

        [HttpPost("addItem")]
        public async Task<IActionResult> AddItem([FromBody] AddItemRequest request)
        {
            var result = await _crudManager.AddItem(request);
            return Ok(result);
        }

        [HttpGet("getItem")]
        public async Task<IActionResult> GetItem([FromQuery] int id)
        {
            var result = await _crudManager.GetItem(id);
            return Ok(result);
        }

        [HttpGet("itemList")]
        public async Task<IActionResult> GetItemList()
        {
            var result = await _crudManager.GetItemList();
            return Ok(result);
        }

        [HttpPut("updateItem")]
        public async Task<IActionResult> UpdateItem(UpdateItemRequest request)
        {
            var result = await _crudManager.UpdateItem(request);
            return Ok(result);
        }

        [HttpDelete("deleteItem")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var result = await _crudManager.DeleteItem(id);
            return Ok(result);
        }

    }
}
