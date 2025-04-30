using System;
using MottuRental.Domain.Shared.Entities;
using MottuRental.Domain.Entregadores.ValueObjects;

namespace MottuRental.Domain.Entregadores.Entities
{
    public class Entregador : BaseEntity
    {
        public string Identificador { get; private set; }
        public string Nome { get; private set; }
        public string Cnpj { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string NumeroCnh { get; private set; }
        public string TipoCnh { get; private set; }
        public string ImagemCnhUrl { get; private set; }

        // Construtor protegido para EF Core
        protected Entregador() { }

        public Entregador(string identificador, string nome, string cnpj, DateTime dataNascimento, string numeroCnh, string tipoCnh)
        {
            // Validações básicas
            if (string.IsNullOrWhiteSpace(identificador))
                throw new ArgumentException("Identificador não pode ser vazio", nameof(identificador));
            
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome não pode ser vazio", nameof(nome));
            
            if (string.IsNullOrWhiteSpace(cnpj))
                throw new ArgumentException("CNPJ não pode ser vazio", nameof(cnpj));
            
            if (dataNascimento > DateTime.Now || dataNascimento.Year < 1900)
                throw new ArgumentException("Data de nascimento inválida", nameof(dataNascimento));
            
            if (string.IsNullOrWhiteSpace(numeroCnh))
                throw new ArgumentException("Número da CNH não pode ser vazio", nameof(numeroCnh));
            
            if (string.IsNullOrWhiteSpace(tipoCnh) || !ValidarTipoCnh(tipoCnh))
                throw new ArgumentException("Tipo de CNH inválido. Deve ser A, B ou A+B", nameof(tipoCnh));

            Identificador = identificador;
            Nome = nome;
            Cnpj = cnpj;
            DataNascimento = dataNascimento;
            NumeroCnh = numeroCnh;
            TipoCnh = tipoCnh;
        }

        public void AtualizarImagemCnh(string imagemUrl)
        {
            if (string.IsNullOrWhiteSpace(imagemUrl))
                throw new ArgumentException("URL da imagem não pode ser vazia", nameof(imagemUrl));

            ImagemCnhUrl = imagemUrl;
            AtualizarDataModificacao();
        }

        private bool ValidarTipoCnh(string tipoCnh)
        {
            // Tipos válidos: A, B ou A+B
            return tipoCnh == "A" || tipoCnh == "B" || tipoCnh == "A+B";
        }
    }
}