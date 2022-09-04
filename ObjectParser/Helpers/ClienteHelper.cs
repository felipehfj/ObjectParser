using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ObjectParser.Modelos;
using System;

namespace ObjectParser.Helpers
{
    public static class ClienteHelper
    {
        public static Cliente MontaCliente(dynamic evento)
        {
            var json = JsonConvert.DeserializeObject<dynamic>(evento);

            var cliente = new Cliente()
            {
                Identificador= Guid.Parse(json.Identificador.ToString()),
                Matricula= json.Matricula,
                PessoaId= Convert.ToInt32(json.PessoaId.ToString()),
                Enderecos= MontaEnderecos(json.Endereco),
                Coberturas= MontaCoberturas(json.Coberturas.CoberturaContratada),
                TipoDocumentoId= json.TipoDocumentoId,
                Documento= json.Documento,
                Nome= json.Nome,
                DataNascimento= json.DataNascimento,
                Sexo= json.Sexo,
                DataExecucaoEvento= json.DataExecucaoEvento,
                ProfissaoId= json.ProfissaoId,
                IdentificadorNegocio= json.IdentificadorNegocio
            };

            return cliente;
        }

        private static Coberturas MontaCoberturas(object coberturas)
        {

            var Coberturas = new Coberturas();
            List<CoberturaContratada> coberturasContratadasDTO = new List<CoberturaContratada>();


            if (coberturas == null || string.IsNullOrEmpty(coberturas.ToString()))
            {
                Coberturas.CoberturaContratada=coberturasContratadasDTO;
            }
            
            if (coberturas.GetType() == typeof(JArray))
            {
                var coberturasContratadasREQ = JsonConvert.DeserializeObject<List<CoberturaContratada>>(coberturas.ToString());

                foreach (var coberturaREQ in coberturasContratadasREQ)
                    coberturasContratadasDTO.Add(JsonConvert.DeserializeObject<CoberturaContratada>(JsonConvert.SerializeObject(coberturaREQ)));
            }
            else
                coberturasContratadasDTO.Add(JsonConvert.DeserializeObject<CoberturaContratada>(coberturas.ToString()));


            Coberturas.CoberturaContratada = coberturasContratadasDTO;

            return Coberturas;
        }

        private static List<Endereco> MontaEnderecos(object enderecos)
        {
            List<Endereco> enderecoDTO = new List<Endereco>();


            if (enderecos == null || string.IsNullOrEmpty(enderecos.ToString()))
            {
                return enderecoDTO;
            }

            if (enderecos.GetType() == typeof(JArray))
            {
                var enderecosREQ = JsonConvert.DeserializeObject<List<Endereco>>(enderecos.ToString());

                foreach (var enderecoREQ in enderecosREQ)
                    enderecoDTO.Add(JsonConvert.DeserializeObject<Endereco>(JsonConvert.SerializeObject(enderecoREQ)));
            }
            else
                enderecoDTO.Add(JsonConvert.DeserializeObject<Endereco>(enderecos.ToString()));

            return enderecoDTO;
        }
    }
}
