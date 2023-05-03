using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace locadoraDeCarros.Dtos
{
    public class CarroRequestDTO
    {
        public int Id { get; set; }
        public string DescricaoCarro { get; set; }
        public int? MarcaId { get; set; }
        public string DescricaoMarca { get; set; }
        public DateTime? DataLocacao { get; set; }
    }
}