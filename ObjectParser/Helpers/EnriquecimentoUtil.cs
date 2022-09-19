using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ObjectParser.Modelos;

namespace ObjectParser.Helpers
{
    public static class EnriquecimentoUtil
    {
        public static Cliente ConverterJsonImplantacao(string eventoImplantacao)
        {
            var json = TratarJson(eventoImplantacao);

            var evento = new Cliente()
            {
                Identificador = Guid.Parse(json.Identificador.ToString()),
                Matricula = json.Matricula,
                PessoaId = Convert.ToInt32(json.PessoaId.ToString()),
                Enderecos = MontaEnderecos(json.Endereco),
                Coberturas = MontaPlanos(json.Coberturas),
                TipoDocumentoId = json.TipoDocumentoId,
                Documento = json.Documento,
                Nome = json.Nome,
                DataNascimento = json.DataNascimento,
                Sexo = json.Sexo,
                DataExecucaoEvento = json.DataExecucaoEvento,
                ProfissaoId = json.ProfissaoId,
                IdentificadorNegocio = json.IdentificadorNegocio
            };

            return evento;
        }

        private static List<Coberturas> MontaPlanos(dynamic planos)
        {

            var coberturas = new List<Coberturas>();

            if (planos == null || string.IsNullOrEmpty(planos?.ToString()))
            {
                return coberturas;
            }

            if (planos?.GetType() == typeof(JArray))
            {
                foreach (var plano in planos)
                {
                    if (plano.CoberturaContratada.GetType() == typeof(JArray))
                    {
                        coberturas.Add(JsonConvert.DeserializeObject<Coberturas>(plano?.ToString()));
                    }
                    else
                    {
                        coberturas.Add(MontaCoberturasContratadas(plano?.CoberturaContratada));
                    }
                }
            }
            else
            {
                coberturas.Add(MontaCoberturasContratadas(planos?.CoberturaContratada));
            }


            return coberturas;
        }

        private static Coberturas MontaCoberturasContratadas(dynamic coberturasContratadas)
        {

            var coberturaDTO = new Coberturas();

            if (coberturasContratadas == null || string.IsNullOrEmpty(coberturasContratadas?.ToString()))
            {
                return coberturaDTO;
            }

            if (coberturasContratadas?.GetType() == typeof(JArray))
            {                
                coberturaDTO.CoberturaContratada.AddRange(JsonConvert.DeserializeObject<List<CoberturaContratada>>(coberturasContratadas.ToString()));
            }
            else
            {
                coberturaDTO.CoberturaContratada.Add(JsonConvert.DeserializeObject<CoberturaContratada>(coberturasContratadas?.ToString(), new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                }));
            }

            return coberturaDTO;
        }

        private static List<Endereco> MontaEnderecos(dynamic enderecos)
        {
            List<Endereco> enderecoDTO = new List<Endereco>();


            if (enderecos == null || string.IsNullOrEmpty(enderecos?.ToString()))
            {
                return enderecoDTO;
            }

            if (enderecos?.GetType() == typeof(JArray))
            {
                var enderecosREQ = JsonConvert.DeserializeObject<List<Endereco>>(enderecos?.ToString());

                foreach (var enderecoREQ in enderecosREQ)
                    enderecoDTO.Add(JsonConvert.DeserializeObject<Endereco>(JsonConvert.SerializeObject(enderecoREQ)));
            }
            else
                enderecoDTO.Add(JsonConvert.DeserializeObject<Endereco>(enderecos?.ToString()));

            return enderecoDTO;
        }

        private static dynamic TratarJson(string json)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            };
            var root = JsonConvert.DeserializeObject<JToken>(json, settings)
                .ReplaceNilXmlElementObjectsWithNull()
                .ToObject<dynamic>(JsonSerializer.CreateDefault(settings));
            return root;
        }

        private static bool WasNilXmlElement(this JToken token)
        {
            if (token == null)
                return true;
            if (token.Type == JTokenType.Null)
                return true;
            var obj = token as JObject;
            if (obj != null)
            {
                if (obj.Properties().All(p => p.Name.StartsWith("@"))
                    && obj.Properties().Any(p => p.Name == "@nil" || p.Name.EndsWith(":nil") && p.Value.ToString() == "true"))
                    return true;
            }
            return false;
        }
        private static JToken ReplaceNilXmlElementObjectsWithNull(this JToken root)
        {
            var rootContainer = root as JContainer;
            if (rootContainer == null)
                return root;
            var list = rootContainer.DescendantsAndSelf()
                .OfType<JObject>()
                .Where(o => o.WasNilXmlElement())
                .ToList();
            foreach (var obj in list)
            {
                var replacement = JValue.CreateNull();
                if (obj.Parent != null)
                    obj.Replace(replacement);
                if (root == obj)
                    root = replacement;
            }
            return root;
        }

    }
}
