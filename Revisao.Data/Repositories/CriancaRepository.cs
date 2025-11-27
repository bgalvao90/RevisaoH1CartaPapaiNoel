using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Revisao.Data.Context;
using Revisao.Domain.Entities;
using Revisao.Domain.Interfaces;

namespace Revisao.Data.Repositories
{
    public class CriancaRepository : ICriancaRepository
    {
        private readonly AppDbContext _context;

        public CriancaRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Crianca> AdicionarCrianca(Crianca crianca)
        {

            await _context.Database.ExecuteSqlRawAsync(
                "exec prAdicionarCrianca @Nome, @Rua, @Numero, @Bairro, @Cidade, @Estado, @CEP, @Idade, @TextoCarta",

                new SqlParameter("@Nome", crianca.Nome),
                new SqlParameter("@Rua", crianca.Rua),
                new SqlParameter("@Numero", crianca.Numero),
                new SqlParameter("@Bairro", crianca.Bairro),
                new SqlParameter("@Cidade", crianca.Cidade),
                new SqlParameter("@Estado", crianca.Estado),
                new SqlParameter("@CEP", crianca.CEP),
                new SqlParameter("@Idade", crianca.Idade),
                new SqlParameter("@TextoCarta", crianca.TextoCarta)
                );

            var novaCrianca = await _context.Crianca
                                    .AsNoTracking()
                                    .OrderByDescending(c => c.CriancaID)
                                    .FirstOrDefaultAsync();

            if (novaCrianca is null)
                throw new InvalidOperationException("Erro ao criar criança");


            return (novaCrianca);
        }

        public async Task<IEnumerable<Crianca>> ListarCriancas()
        {
            var lista = await _context.Crianca.ToListAsync();

            return lista;
        }

        public async Task<Crianca> ObterPorID(int criancaID)
        {
            var crianca = await _context.Crianca
                                .FirstOrDefaultAsync(c => c.CriancaID == criancaID);
            return crianca;
        }
    }
}
