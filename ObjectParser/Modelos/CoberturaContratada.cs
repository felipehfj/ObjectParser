namespace ObjectParser.Modelos
{
    public class CoberturaContratada
    {
        public string IdExterno { get; set; }
        public string InscricaoCertificado { get; set; }
        public string UnidadeProducao { get; set; }
        public string UnidadeFiscal { get; set; }
        public int ItemProdutoId { get; set; }
        public int FormaContratacaoId { get; set; }
        public int RelacaoSeguradoId { get; set; }
        public int TipoRendaId { get; set; }
        public DateTime? Assinatura { get; set; }
        public DateTime? Implantacao { get; set; }
        public DateTime? FimVigencia { get; set; }
        public DateTime InicioVigencia { get; set; }
        public int? PrazoContribuicao { get; set; }
        public int ParcelasPagas { get; set; }
        public string NumeroProposta { get; set; }
        public int FormaCobrancaId { get; set; }
        public DateTime DataEvento { get; set; }
        public Proposta Proposta { get; set; }
        public string CodigoParceiro { get; set; }
        public int TipoInscricaoId { get; set; }
        public int TipoRegimeIRId { get; set; }
        public double? Contribuicao { get; set; }
        public double? Beneficio { get; set; }
        public double? CapitalSegurado { get; set; }
        public ProdutoresParticipantes? ProdutoresParticipantes { get; set; }
        public int? ClasseRiscoId { get; set; }
        public double IOF { get; set; }
        public DateTime? PrazoDecrescimo { get; set; }
        public int PeriodicidadePagamento { get; set; }
        public int? TempoPagamentoAntecipado { get; set; }
        public double CapitalSeguradoOriginal { get; set; }
    }
}
