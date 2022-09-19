using ObjectParser.Helpers;

namespace ObjectParserTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(@"C:\Users\felip\source\repos\ObjectParser\ObjectParser\Dados\Evento_0_End.json")]
        [InlineData(@"C:\Users\felip\source\repos\ObjectParser\ObjectParser\Dados\Evento_0_Ends.json")]
        [InlineData(@"C:\Users\felip\source\repos\ObjectParser\ObjectParser\Dados\Evento_1_End.json")]
        [InlineData(@"C:\Users\felip\source\repos\ObjectParser\ObjectParser\Dados\Evento_2_Ends.json")]             
        [InlineData(@"C:\Users\felip\source\repos\ObjectParser\ObjectParser\Dados\completo.json")]
        [InlineData(@"C:\Users\felip\source\repos\ObjectParser\ObjectParser\Dados\coberturaSimples.json")]
        [InlineData(@"C:\Users\felip\source\repos\ObjectParser\ObjectParser\Dados\coberturaComposto.json")]        
        public void ConverterJsonImplantacao_QuandoDerCerto_PrecisaTerComponenteEnderecos(string uri)
        {

            string json = File.ReadAllText(uri);

            var propostaCliente = EnriquecimentoUtil.ConverterJsonImplantacao(json);

            Assert.NotNull(propostaCliente?.Enderecos);

        }

        [Theory]
        [InlineData(@"C:\Users\felip\source\repos\ObjectParser\ObjectParser\Dados\Evento_0_End.json")]
        [InlineData(@"C:\Users\felip\source\repos\ObjectParser\ObjectParser\Dados\Evento_0_Ends.json")]
        [InlineData(@"C:\Users\felip\source\repos\ObjectParser\ObjectParser\Dados\Evento_1_End.json")]
        [InlineData(@"C:\Users\felip\source\repos\ObjectParser\ObjectParser\Dados\Evento_2_Ends.json")]
        [InlineData(@"C:\Users\felip\source\repos\ObjectParser\ObjectParser\Dados\completo.json")]
        [InlineData(@"C:\Users\felip\source\repos\ObjectParser\ObjectParser\Dados\coberturaSimples.json")]
        [InlineData(@"C:\Users\felip\source\repos\ObjectParser\ObjectParser\Dados\coberturaComposto.json")]
        public void ConverterJsonImplantacao_QuandoDerCerto_PrecisaTerComponenteCoberturas(string uri)
        {

            string json = File.ReadAllText(uri);

            var propostaCliente = EnriquecimentoUtil.ConverterJsonImplantacao(json);

            Assert.NotNull(propostaCliente?.Coberturas);

        }

        [Theory]        
        [InlineData(@"C:\Users\felip\source\repos\ObjectParser\ObjectParser\Dados\completo.json")]
        [InlineData(@"C:\Users\felip\source\repos\ObjectParser\ObjectParser\Dados\coberturaSimples.json")]        
        public void ConverterJsonImplantacao_QuandoDerCerto_PrecisaTerComponenteCoberturasComUmElemento(string uri)
        {

            string json = File.ReadAllText(uri);

            var propostaCliente = EnriquecimentoUtil.ConverterJsonImplantacao(json);

            Assert.NotNull(propostaCliente?.Coberturas);
            Assert.Equal(1, propostaCliente?.Coberturas.Count);

        }       

        [Theory]              
        [InlineData(@"C:\Users\felip\source\repos\ObjectParser\ObjectParser\Dados\coberturaComposto.json")]
        public void ConverterJsonImplantacao_QuandoDerCerto_PrecisaTerComponenteCoberturasComDoisElementos(string uri)
        {

            string json = File.ReadAllText(uri);

            var propostaCliente = EnriquecimentoUtil.ConverterJsonImplantacao(json);

            Assert.NotNull(propostaCliente?.Coberturas);
            Assert.Equal(2, propostaCliente?.Coberturas.Count);

        }

    }
}