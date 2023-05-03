using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace locadoraDeCarros.Models
{
    public class CarroModel
    {
        public int Id { get; set; } //Primary Key
        public string Nome { get; set; } //Not Null
        public MarcaModel Marca { get; set; } //Foreing Key
        public DateTime? DataLocacao { get; set; } //Null
        public int MarcaId { get; set; }

    }
}