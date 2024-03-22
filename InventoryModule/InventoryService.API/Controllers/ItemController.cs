using InventoryService.API.Dtos;
using InventoryService.Data.Entities;
using InventoryService.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ItemRepository _itemRepository;

        public ItemController(ItemRepository playerRepository)
        {
            _itemRepository = playerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _itemRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _itemRepository.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ItemCreateDto dto)
        {
            var result = await _itemRepository.Create(new Item
            {
                Name = dto.Name,
            });
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ItemUpdateDto dto)
        {
            await _itemRepository.Update(new Item
            {
                Id = dto.Id,
                Name = dto.Name,
            });
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            await _itemRepository.Remove(id);
            return NoContent();
        }
    }
}
