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
        public void ParseJSON_PrecisaConterAtributoEnderecosETerElemento(string uri)
        {

            string json = File.ReadAllText(uri);

            var propostaCliente = ClienteHelper.MontaCliente(json);

            Assert.NotNull(propostaCliente?.Enderecos);            

        }
    }
}