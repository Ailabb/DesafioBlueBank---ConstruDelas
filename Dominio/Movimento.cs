using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Movimento
    {
        public int Id { get; set; }
        //public Cliente Origem { get; set; }
        public int OrigemId { get; set; }
        //public Cliente Destino { get; set; }
        public int DestinoId { get; set; }
        public double Valor { get; set; }
    }
}
