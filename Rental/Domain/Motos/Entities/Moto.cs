using System;
using MottuRental.Domain.Shared.Entities;
using MottuRental.Domain.Motos.ValueObjects;

namespace MottuRental.Domain.Motos.Entities
{
    public class Moto : BaseEntity
    {
        public string Identificador { get; private set; }
        public int Ano { get; private set; }
        public string Modelo { get; private set; }
        public string Placa { get; private set; }
        public bool Disponivel { get; private set; }

        // Construtor protegido para EF Core
        protected Moto() { }

        public Moto(string identificador, int ano, string modelo, string placa)
        {
            // Validações básicas
            if (string.IsNullOrWhiteSpace(identificador))
                throw new ArgumentException("Identificador não pode ser vazio", nameof(identificador));
            
            if (ano <= 0)
                throw new ArgumentException("Ano deve ser um valor positivo", nameof(ano));
            
            if (string.IsNullOrWhiteSpace(modelo))
                throw new ArgumentException("Modelo não pode ser vazio", nameof(modelo));
            
            if (string.IsNullOrWhiteSpace(placa))
                throw new ArgumentException("Placa não pode ser vazia", nameof(placa));

            Identificador = identificador;
            Ano = ano;
            Modelo = modelo;
            Placa = placa;
            Disponivel = true;
        }

        public void AlterarPlaca(string novaPlaca)
        {
            // Validação básica
            if (string.IsNullOrWhiteSpace(novaPlaca))
                throw new ArgumentException("Placa não pode ser vazia", nameof(novaPlaca));

            Placa = novaPlaca;
        }

        public void MarcarComoIndisponivel()
        {
            Disponivel = false;
        }

        public void MarcarComoDisponivel()
        {
            Disponivel = true;
        }
    }
}