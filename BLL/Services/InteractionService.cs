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
                Interactions interaction = new Interactions
                {
                    
                };



                await _unitWork.SubjectUser.Add(interaction);
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
                var relationDb = await _unitWork.GetFirst(e => e.Id == relationRegisterDTO.Id);
                
                _unitWork.SubjectUser.Update(relationDb);
                await _unitWork.Save();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Delete(int idRelation)
        {
            try
            {
                var TeacherDb = await _unitWork.SubjectUser.GetFirst(e => e.Id == idRelation);
                if (TeacherDb == null)
                {
                    throw new TaskCanceledException("Relation not found");
                }
                _unitWork.SubjectUser.Remove(TeacherDb);
                await _unitWork.Save();

            }
            catch (Exception)
            {

                throw;
            }
        }



        
        }
    }
}