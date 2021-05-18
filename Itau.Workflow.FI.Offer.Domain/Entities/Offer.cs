using System;

namespace Itau.Workflow.FI.Offer.Domain.Entities
{
    public class Offer
    {
        public long Id { get; set; }

        public long IdGrupo { get; set; }
        public long IdEmpresaGrupo { get; set; }
        public long IdProduto { get; set; }
        public long IdCelulaRF { get; set; }
        public long IdCelulaRFSecundaria { get; set; }

        public long IdGestor { get; set; }
        public long IdSvpVp { get; set; }
        public long IdSvpVpSecundario { get; set; }

        public decimal? ValorOperacao { get; set; }
        public decimal? ValorBanco { get; set; }
        public DateTime? DataPrevista { get; set; }
        public decimal? TaxaFinal { get; set; }
        public decimal? PrazoTotal { get; set; }
        public decimal? PorcentagemMercado { get; set; }
        public decimal? PorcentagemCarteira { get; set; }

        public virtual InstructionCvm InstrucaoCvm { get; set; }
        public virtual Indexer Indexador { get; set; }
    }
}
