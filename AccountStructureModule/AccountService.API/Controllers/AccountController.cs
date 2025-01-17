﻿using AccountService.API.Dtos;
using AccountService.Data.Entities;
using AccountService.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly PlayerRepository _playerRepository;

        public AccountController(PlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var result = await _playerRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id) 
        {
            var result = await _playerRepository.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PlayerCreateDto dto)
        {
            var result = await _playerRepository.Create(new Player
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                UserName = dto.UserName,
            });
            return Created("",result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(PlayerUpdateDto dto)
        {
            await _playerRepository.Update(new Player
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                UserName = dto.UserName,
            });
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            await _playerRepository.Remove(id);
            return NoContent();
        }
    }
}
