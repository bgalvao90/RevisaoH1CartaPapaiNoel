using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Revisao.Domain.Entities;
using Revisao.Domain.Interfaces;

namespace Revisao.Application.Services
{
    public class CriancaServices : ICriancaService
    {
        private readonly ICriancaRepository _criancaRepository;

        public CriancaServices(ICriancaRepository criancaRepository)
        {
            _criancaRepository = criancaRepository;
        }

        public async Task<Crianca> AdicionarCrianca(Crianca crianca)
        {
           
            return await _criancaRepository.AdicionarCrianca(crianca);
        }

        public Task<IEnumerable<Crianca>> ListarCriancas()
        {
            var criancas = _criancaRepository.ListarCriancas();

            if(criancas is null)
                throw new InvalidOperationException("Nenhuma criança cadastrada.");

            return criancas;
        }
    }
}
