using System;
using MottuRental.Domain.Shared.Entities;
using MottuRental.Domain.Motos.Entities;
using MottuRental.Domain.Entregadores.Entities;

namespace MottuRental.Domain.Locacoes.Entities
{
    public class Locacao : BaseEntity
    {
        public Guid MotoId { get; private set; }
        public Guid EntregadorId { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public int DiasLocacao { get; private set; }
        public decimal ValorDiaria { get; private set; }
        public decimal ValorTotal { get; private set; }
        public bool Ativa { get; private set; }

        // Propriedades de navegação para EF Core
        public virtual Moto Moto { get; private set; }
        public virtual Entregador Entregador { get; private set; }

        // Construtor protegido para EF Core
        protected Locacao() { }

        public Locacao(Moto moto, Entregador entregador, int diasLocacao, DateTime dataInicio)
        {
            if (moto == null)
                throw new ArgumentNullException(nameof(moto), "Moto não pode ser nula");

            if (entregador == null)
                throw new ArgumentNullException(nameof(entregador), "Entregador não pode ser nulo");

            if (diasLocacao <= 0)
                throw new ArgumentException("Dias de locação deve ser maior que zero", nameof(diasLocacao));

            MotoId = moto.Id;
            EntregadorId = entregador.Id;
            DiasLocacao = diasLocacao;
            DataInicio = dataInicio;
            DataFim = dataInicio.AddDays(diasLocacao);
            ValorDiaria = CalcularValorDiaria(diasLocacao);
            ValorTotal = ValorDiaria * diasLocacao;
            Ativa = true;

            // Atualizar estado da moto
            moto.MarcarComoIndisponivel();
        }

        public void FinalizarLocacao()
        {
            if (!Ativa)
                throw new InvalidOperationException("Esta locação já está finalizada");

            Ativa = false;
            AtualizarDataModificacao();

            // Nota: A moto deve ser marcada como disponível pelo serviço de domínio
        }

        private decimal CalcularValorDiaria(int diasLocacao)
        {
            // Planos disponíveis conforme requisitos
            return diasLocacao switch
            {
                7 => 30.00m,   // 7 dias - R$30,00 por dia
                15 => 28.00m,  // 15 dias - R$28,00 por dia
                30 => 22.00m,  // 30 dias - R$22,00 por dia
                45 => 20.00m,  // 45 dias - R$20,00 por dia
                _ => throw new ArgumentException("Plano de locação inválido. Os planos disponíveis são: 7, 15, 30 ou 45 dias", nameof(diasLocacao))
            };
        }
    }
}