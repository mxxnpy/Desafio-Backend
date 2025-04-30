using System;
using MottuRental.Domain.Motos.Entities;
using MottuRental.Domain.Shared.Events;

namespace MottuRental.Domain.Motos.Events
{
    public class MotoCadastradaEvent : DomainEvent
    {
        public string Identificador { get; private set; }
        public int Ano { get; private set; }
        public string Modelo { get; private set; }
        public string Placa { get; private set; }

        public MotoCadastradaEvent(Moto moto) : base(moto.Id)
        {
            if (moto == null)
                throw new ArgumentNullException(nameof(moto));

            Identificador = moto.Identificador;
            Ano = moto.Ano;
            Modelo = moto.Modelo;
            Placa = moto.Placa;
        }
    }
}