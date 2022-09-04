namespace ObjectParser.Modelos
{
    public class Cliente
    {
        public Guid Identificador { get; set; }
        public string Matricula { get; set; }
        public int PessoaId { get; set; }        
        public List<Endereco> Enderecos { get; set; }               
        public Coberturas? Coberturas { get; set; }
        public int TipoDocumentoId { get; set; }
        public long Documento { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Sexo { get; set; }
        public DateTime DataExecucaoEvento { get; set; }
        public int ProfissaoId { get; set; }
        public int IdentificadorNegocio { get; set; }
    }
}
