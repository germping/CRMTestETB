using BLL.Services;
using BLL.Services.Interfaces;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Models.DTOs;
using Models.Entities;
using Interaction = Models.Entities.Interaction;

namespace API.Controllers
{
    public class InteractionsController : BaseApiController
    {
        private readonly IInteractionService _interactionService;
        private ApiResponse _response;

        private readonly ApplicationDbContext _db;


        public InteractionsController(IInteractionService interactionService, ApplicationDbContext db)
        {
            _db = db;
            _interactionService = interactionService;
            _response = new();
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                _response.Result = await _interactionService.GetInteractions();
                _response.IsSuccesful = true;
                _response.StatusCode = System.Net.HttpStatusCode.OK;

            }
            catch (Exception ex)
            {

                _response.IsSuccesful = false;
                _response.Message = ex.Message;
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            return Ok(_response);
        }

     
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _interactionService.Delete(id);
                _response.IsSuccesful = true;
                _response.StatusCode = System.Net.HttpStatusCode.NoContent;
            }
            catch (Exception ex)
            {

                _response.IsSuccesful = false;
                _response.Message = ex.Message;
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            return Ok(_response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(InteractionDTO modelDto)
        {
            _response.IsSuccesful = false;
            _response.StatusCode = System.Net.HttpStatusCode.OK;


            if (await InteractionExists(modelDto.Id))
            {
                _response.Message = "Interacción ya existe";
                return Ok(_response);
            }
            
            try
            {
                await _interactionService.Add(modelDto);
                _response.IsSuccesful = true;
                _response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {

                _response.IsSuccesful = false;
                _response.Message = ex.Message;
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            return Ok(_response);
        }

        private async Task<bool> InteractionExists(int idInteraction)
        {
            return await _db.Interactions.AnyAsync(x => x.Id == idInteraction);
        }
        
    }
}
