using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.src
{
    public class CepInfo
    {
        // Defina a classe CepInfo para mapear a estrutura da resposta JSON

        public string cep { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string neighborhood { get; set; }
        public string street { get; set; }
        public string service { get; set; }
    }
}