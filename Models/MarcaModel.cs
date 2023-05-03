using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace locadoraDeCarros.Models
{
    public class MarcaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public List<CarroModel> Carros { get; set; }
    }
}