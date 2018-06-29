﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleApp.DataAccess.Models;
using SimpleApp.DataAccess.Repositories;

namespace SimpleAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly PetsRepository _repository;

        public PetsController(PetsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Pet>> Get()
        {
            return _repository.GetPets();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(404)]
        public ActionResult<Pet> GetById(int id)
        {
            if (!_repository.TryGetPet(id, out var pet))
            {
                return NotFound();
            }

            return pet;
        }

        [HttpPost]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Pet>> CreateAsync(Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _repository.AddPetAsync(pet);

            return CreatedAtAction(nameof(GetById),
                new { id = pet.Id }, pet);
        }
    }

}