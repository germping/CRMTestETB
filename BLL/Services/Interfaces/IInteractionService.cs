using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IInteractionService
    {
        Task<IEnumerable<InteractionDTO>> GetInteractions();
        Task<InteractionDTO> Add(InteractionDTO interactionDTO);
        Task Update(InteractionDTO interactionDTO);
        Task Delete(int idInteraction);

    }
}
