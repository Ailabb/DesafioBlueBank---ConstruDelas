using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public int NumeroConta { get; set; }
        public double Saldo { get; set; }
    }
}
