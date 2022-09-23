using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Repo.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BreedController : ControllerBase
    {
        private readonly IBreedRepository breedRepository;
        // private object mapper;

        public BreedController(IBreedRepository breedRepository)
        {
            this.breedRepository = breedRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddBreed([FromBody]BreedCreation field)
        {
            var dataFromRepo = await breedRepository.AddBreed(field);
            if(dataFromRepo == null)
            {
                return BadRequest(new
                {
                    Message = "Error",
                    StatusCode = 401,
                    IsSuccessful = false
                });
            }

            return Ok(new
                {
                    Message = "Success",
                    StatusCode = 201,
                    IsSuccessful = true,
                    Data = dataFromRepo
                }
            );
        }

        [HttpGet]

        public async Task<IActionResult> getAuthors()
        {
            var dataFromRepo = await breedRepository.GetBreeds();
            if(dataFromRepo == null)
            {
                return BadRequest(new
                {
                    Message = "Error",
                    StatusCode = 401,
                    IsSuccessful = false
                });
            }

            return Ok(new
                {
                    Message = "Success",
                    StatusCode = 201,
                    IsSuccessful = true,
                    Data = dataFromRepo
                });
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> getBreedWithId(int id)
        {
            var dataFromRepo = await breedRepository.GetBreedWithId(id);
            if(dataFromRepo == null)
            {
                return BadRequest(new
                {
                    Message = "Error",
                    StatusCode = 401,
                    IsSuccessful = false
                });
            }

            return Ok(new
                {
                    Message = "Success",
                    StatusCode = 201,
                    IsSuccessful = true,
                    BreedId = id,
                    Data = dataFromRepo
                }
            );
        }

        [HttpGet]
        [Route("name")]
        public async Task<IActionResult> GetBreedWithTitle(string name)
        {
            var dataFromRepo = await breedRepository.GetBreedWithName(name);
            if(dataFromRepo == null)
            {
                return BadRequest(new
                {
                    Message = "Error",
                    StatusCode = 401,
                    IsSuccessful = false
                });
            }

            return Ok(new
                {
                    Message = "Success",
                    StatusCode = 201,
                    IsSuccessful = true,
                    Data = dataFromRepo
                }
            );
        }

        [HttpPut("update")]

        public async Task<IActionResult> UpdateBreed(BreedUpdate model)
        { 
            var dataFromRepo = await breedRepository.UpdateBreed(model);
            if(dataFromRepo == null)
            {
                return BadRequest(new
                {
                    Message = "Error",
                    StatusCode = 401,
                    IsSuccessful = false
                });
            }

            return Ok(new
                {
                    Message = "Success",
                    StatusCode = 201,
                    IsSuccessful = true,
                    Data = dataFromRepo
                }
            );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBreed(int id)
        {
            var dataFromRepo = await breedRepository.DeleteBreed(id);
            if(!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    Message = "Error",
                    StatusCode = 401,
                    IsSuccessful = false
                });
            }

            return Ok(new
                {
                    Message = "Success",
                    StatusCode = 201,
                    IsSuccessful = true,
                    BreedId = id,
                    Data = dataFromRepo
                }
            );
        }

    }
}