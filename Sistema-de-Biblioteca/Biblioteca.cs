namespace Sistema_de_Biblioteca
{
    class Biblioteca
    {
        public class Livro
        {
            public string Titulo { get; set; } = string.Empty;
            public string Autor { get; set; } = string.Empty;
            public int AnoPublicacao { get; set; }
            public int QuantDisponivel { get; set; }
            public double PrecoDiaria { get; set; }

            public double CalcularCustoEmprestimo(int diasEmprestimo)
            {
                return PrecoDiaria * diasEmprestimo;
            }

            public bool PodePegarEmprestado()
            {
                return QuantDisponivel > 0;
            }

            public int AtualizarQuantidade(int quantidade)
            {
                QuantDisponivel += quantidade;
                return QuantDisponivel;
            }
        }

        public class Usuario
        {
            public string Nome { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string Telefone { get; set; } = string.Empty;
            public string Tipo { get; set; } = string.Empty;

            public double CalcularDesconto()
            {
                if (Tipo.Equals("Bronze", StringComparison.OrdinalIgnoreCase))
                {
                    return 0.00;
                }
                else if (Tipo.Equals("Prata", StringComparison.OrdinalIgnoreCase))
                {
                    return 0.05; // Ajustado para 5% para bater com a interface
                }
                else if (Tipo.Equals("Ouro", StringComparison.OrdinalIgnoreCase))
                {
                    return 0.15;
                }
                else
                {
                    return 0.00;
                }
            }
        }

        public class Emprestimo
        {
            public Livro Livro { get; set; } = new Livro();
            public Usuario usuario { get; set; } = new Usuario();
            public DateTime DataEmprestimo { get; set; }
            public DateTime DataDevolucao { get; set; }

            public int CalcularDiasEmprestimo()
            {
                TimeSpan diferencaData = DataDevolucao - DataEmprestimo;
                return diferencaData.Days;
            }

            public double CalcularValorBruto()
            {
                // Agora o valor calcula baseado na diária e nos dias de empréstimo
                int dias = CalcularDiasEmprestimo();
                return Livro.CalcularCustoEmprestimo(dias > 0 ? dias : 1);
            }

            public double AplicarDesconto(double valor)
            {
                return valor - (valor * usuario.CalcularDesconto());
            }

            public double CalcularValorFinal()
            {
                return AplicarDesconto(CalcularValorBruto());
            }

            public string Relatorio()
            {
                string nome = usuario.Nome;
                string book = Livro.Titulo;
                int dias = CalcularDiasEmprestimo();
                double valorSemDesconto = CalcularValorBruto();
                double desconto = usuario.CalcularDesconto() * 100; // Em porcentagem para exibição
                double valorFinal = CalcularValorFinal();

                return $"Usuário: {nome}\n" +
                       $"Livro: {book}\n" +
                       $"Dias: {dias}\n" +
                       $"Desconto (%): {desconto}%\n" +
                       $"Valor sem Desconto: R$ {valorSemDesconto:F2}\n" +
                       $"Valor Final: R$ {valorFinal:F2}";
            }
        }
    }
}