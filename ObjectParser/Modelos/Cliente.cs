namespace ObjectParser.Modelos
{
    public class Cliente
    {
        public Cliente()
        {
            Enderecos = new List<Endereco>();
            Coberturas = new List<Coberturas>();
        }
        public Guid Identificador { get; set; }
        public string Matricula { get; set; }
        public int PessoaId { get; set; }        
        public List<Endereco> Enderecos { get; set; }               
        public List<Coberturas> Coberturas { get; set; }
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
