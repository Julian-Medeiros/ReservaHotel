using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservaHotel.Models
{
    public class Reserva
    {
    
        public Reserva(int diasReservados)
        {
            if (diasReservados < 0)
            {
                throw new ArgumentException("Número de dias reservados deve ser maior que zero.");
            }
            DiasReservados = diasReservados;
        }

        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }
      
        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new ArgumentException("Número de hóspedes excede a capacidade da suíte.");
            }
        }
        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }
        public (string quantidadeString, int quantidadeInt) ObterQuantidadeHospedes()
        {
            return ($"A quantidade de hóspedes para esta reserva é de {Hospedes.Count} " +
                   (Hospedes.Count > 1 ? "pessoas." : "pessoa."), Hospedes.Count);
        }
        public (decimal valor, string desconto) CalcularValorDiaria()
        {
            decimal valor = DiasReservados * Suite.ValorDiaria;
            decimal desconto = 0;
            if (DiasReservados >= 10)
            {
                desconto = valor * 0.1m;
                valor -= desconto;
                return (valor, $"Desconto de 10%, {desconto:C}, aplicado por reserva de 10 dias ou mais.");
            }
            return (valor, "Não houve desconto");
        }
    }
}