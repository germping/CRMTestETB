using AutoMapper;
using BLL.Services.Interfaces;
using Data.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class InteractionService : IInteractionService
    {
        private readonly IUnitWorkInteraction _unitWork;
        private readonly IMapper _mapper;

        public InteractionService(IMapper mapper, IUnitWorkInteraction unitWork)
        {
            _unitWork = unitWork;
            _mapper = mapper;
        }

        public async Task<InteractionDTO> Add(InteractionDTO relationRegisterDTO)
        {
            int maxRegisters = 10;
            int registrosActuales = _unitWork.GetCountRegisters();
            if (maxRegisters == registrosActuales)
            {
                throw new TaskCanceledException("Error save Interaction, max 10 registers");
            }
            try
            {
                Interaction interaction = new Interaction
                {
                    
                };
                await _unitWork.Interaction.Add(interaction);
                await _unitWork.Save();
                if (interaction.Id == 0)
                {
                    throw new TaskCanceledException("Error save SubjectUser");
                }
                return _mapper.Map<InteractionDTO>(interaction);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task Update(InteractionDTO interactionDTO)
        {
            try
            {
                var interactionDb = await _unitWork.Interaction.GetFirst(e => e.Id == interactionDTO.Id);
                
                _unitWork.Interaction.Update(interactionDb);
                await _unitWork.Save();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Delete(int idInteraction)
        {
            try
            {
                var InteractionDb = await _unitWork.Interaction.GetFirst(e => e.Id == idInteraction);
                if (InteractionDb == null)
                {
                    throw new TaskCanceledException("Interaction not found");
                }
                _unitWork.Interaction.Remove(InteractionDb);
                await _unitWork.Save();

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<InteractionDTO>> GetInteractions()
        {
            try
            {
                var lista = await _unitWork.Interaction
                    .GetAll(orderBy: e => e.OrderBy(e => e.Id));
                return _mapper.Map<IEnumerable<InteractionDTO>>(lista);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}
