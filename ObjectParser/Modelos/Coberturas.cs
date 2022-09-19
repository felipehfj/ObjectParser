namespace ObjectParser.Modelos
{
    public class Coberturas
    {
        public Coberturas()
        {
            CoberturaContratada = new List<CoberturaContratada>();
        }
        public List<CoberturaContratada> CoberturaContratada { get; set; }
    }
}
