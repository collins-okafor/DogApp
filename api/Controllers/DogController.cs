using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Repo;
using api.Repo.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DogController : ControllerBase
    {
        private readonly IDogRepository dogRepository;

        public DogController(IDogRepository dogRepository)
        {
            this.dogRepository = dogRepository;
        }

        [HttpPost]
        public async Task<IActionResult> addDog(DogCreation field)
        {
            var dataFromRepo = await dogRepository.AddDog(field);
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
        public async Task<IActionResult> getDogs()
        {
            var dataFromRepo = await dogRepository.GetDogs();
            if (dataFromRepo == null)
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
        [Route("{id}")]
        public async Task<IActionResult> getDogWithId(int id)
        {
            var dataFromRepo = await dogRepository.GetDogWithId(id);
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
        public async Task<IActionResult> getDogWithName(string name)
        {
            var dataFromRepo = await dogRepository.GetDogWithName(name);
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

        public async Task<IActionResult> UpdateDog(DogUpdate model)
        { 
            var dataFromRepo = await dogRepository.UpdateDog(model);
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
            var dataFromRepo = await dogRepository.DeleteDog(id);
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