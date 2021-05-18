using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Itau.Workflow.FI.Offer.Domain.Entities;
using Itau.Workflow.FI.Offer.Persistence;
using MediatR;

namespace Itau.Workflow.FI.Offer.Core.Offer.Init
{
    public class InitHandler : IRequestHandler<Init, int>
    {
        private HubDbContext dbContext;

        public InitHandler(HubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> Handle(Init request, CancellationToken cancellationToken)
        {
            await this.LoadIndexers();
            await this.LoadInstructions();
            await this.LoadOffers();

            return 0;
        }


        #region Carregar Dados Falsos

        #region Carregar Dados Instrução CVM
        private async Task LoadInstructions()
        {
            var instructions = new List<InstructionCvm>
            {
                new InstructionCvm
                {
                    Id = 1,
                    Descricao = "Teste Instrucao 1"
                },
                new InstructionCvm
                {
                    Id = 2,
                    Descricao = "Teste Instrucao 2"
                },
                new InstructionCvm
                {
                    Id = 3,
                    Descricao = "Teste Instrucao 3"
                }
            };

            await this.dbContext.InstructionsCvm.AddRangeAsync(instructions);

            await this.dbContext.SaveChangesAsync();
        }
        #endregion

        #region Carregar Dados Indexadores
        private async Task LoadIndexers()
        {
            var indexers = new List<Indexer>
            {
                new Indexer
                {
                    Id = 1,
                    Descricao = "Teste 1"
                },
                new Indexer
                {
                    Id = 2,
                    Descricao = "Teste 2"
                },
                new Indexer
                {
                    Id = 3,
                    Descricao = "Teste 3"
                }
            };

            await this.dbContext.Indexers.AddRangeAsync(indexers);

            await this.dbContext.SaveChangesAsync();
        }
        #endregion

        #region Carregar Dados Ofertas
        private async Task LoadOffers()
        {
            var offers = new List<Domain.Entities.Offer>
            {
                new Domain.Entities.Offer
                {
                    Indexador = dbContext.Indexers.FirstOrDefault(i => i.Id == 1),
                    InstrucaoCvm = dbContext.InstructionsCvm.FirstOrDefault(i => i.Id == 1),
                    IdCelulaRF = 1,
                    IdCelulaRFSecundaria = 1,
                    IdEmpresaGrupo = 1,
                    IdGestor = 1,
                    IdGrupo = 1,
                    IdProduto = 1,
                    IdSvpVp = 1,
                    IdSvpVpSecundario = 1,
                    PorcentagemCarteira = 10.0M,
                    PorcentagemMercado = 10.0M,
                    PrazoTotal = 10,
                    TaxaFinal = 10,
                    ValorBanco = 10,
                    ValorOperacao = 10,
                    DataPrevista = DateTime.Now
                },
                new Domain.Entities.Offer
                {
                    Indexador = dbContext.Indexers.FirstOrDefault(i => i.Id == 2),
                    InstrucaoCvm = dbContext.InstructionsCvm.FirstOrDefault(i => i.Id == 2),
                    IdCelulaRF = 2,
                    IdCelulaRFSecundaria = 2,
                    IdEmpresaGrupo = 2,
                    IdGestor = 2,
                    IdGrupo = 2,
                    IdProduto = 2,
                    IdSvpVp = 2,
                    IdSvpVpSecundario = 2,
                    PorcentagemCarteira = 20.0M,
                    PorcentagemMercado = 20.0M,
                    PrazoTotal = 20,
                    TaxaFinal = 20,
                    ValorBanco = 20,
                    ValorOperacao = 20,
                    DataPrevista = DateTime.Now
                },
                new Domain.Entities.Offer
                {
                    Indexador = dbContext.Indexers.FirstOrDefault(i => i.Id == 3),
                    InstrucaoCvm = dbContext.InstructionsCvm.FirstOrDefault(i => i.Id == 3),
                    IdCelulaRF = 3,
                    IdCelulaRFSecundaria = 3,
                    IdEmpresaGrupo = 3,
                    IdGestor = 3,
                    IdGrupo = 3,
                    IdProduto = 3,
                    IdSvpVp = 3,
                    IdSvpVpSecundario = 3,
                    PorcentagemCarteira = 30.0M,
                    PorcentagemMercado = 30.0M,
                    PrazoTotal = 30,
                    TaxaFinal = 30,
                    ValorBanco = 30,
                    ValorOperacao = 30,
                    DataPrevista = DateTime.Now
                }
            };

            await this.dbContext.Offers.AddRangeAsync(offers);

            await this.dbContext.SaveChangesAsync();
        }
        #endregion
        #endregion

    }
}
