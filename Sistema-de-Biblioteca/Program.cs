using Sistema_de_Biblioteca;
using static Sistema_de_Biblioteca.Biblioteca;

Console.WriteLine("\n--BIBLIOTECA - SISTEMA DE EMPRÉSTIMOS--\n");

var usuario = new Usuario();
var emprestimo = new Emprestimo();

Console.Write("Digite o nome do usuário: ");
usuario.Nome = Console.ReadLine() ?? string.Empty;

Console.WriteLine($"\nBem-vindo(a), {usuario.Nome}!");

Console.WriteLine("\nQual o seu tipo de Conta [Ouro, Prata, Bronze]?");
usuario.Tipo = Console.ReadLine() ?? string.Empty;

if (usuario.Tipo.Equals("Ouro", StringComparison.OrdinalIgnoreCase))
{
    Console.WriteLine("Você tem direito a 15% de desconto no valor do empréstimo.");
}
else if (usuario.Tipo.Equals("Prata", StringComparison.OrdinalIgnoreCase))
{
    Console.WriteLine("Você tem direito a 5% de desconto no valor do empréstimo.");
}
else if (usuario.Tipo.Equals("Bronze", StringComparison.OrdinalIgnoreCase))
{
    Console.WriteLine("Você não tem direito a desconto no valor do empréstimo.");
}
else
{
    Console.WriteLine("Tipo de conta inválido. Você não terá desconto no valor do empréstimo.");
}

Console.WriteLine("\nEscolha o livro desejado:");
Console.WriteLine("1 - O Senhor dos Anéis (R$ 10,00/dia)");
Console.WriteLine("2 - O Pequeno Príncipe (R$ 5,00/dia)");
Console.WriteLine("3 - Dom Casmurro (R$ 7,50/dia)");
Console.Write("Digite o nome do livro: ");
var livroEscolhido = Console.ReadLine() ?? string.Empty;

// Atribuindo preços de diária fictícios baseados na escolha para o cálculo funcionar
double precoDiaria = livroEscolhido.ToLower() switch
{
    "o senhor dos anéis" => 10.0,
    "o pequeno príncipe" => 5.0,
    "dom casmurro" => 7.5,
    _ => 5.0 // Valor padrão caso digite algo diferente
};

emprestimo.Livro = new Livro
{
    Titulo = livroEscolhido,
    PrecoDiaria = precoDiaria
};

emprestimo.usuario = usuario;

Console.Write("\nQuando você pretende pegar o livro emprestado? (formato: dd/MM/yyyy): ");
emprestimo.DataEmprestimo = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.ToString());

Console.Write("Em quantos dias você pretende devolver o livro? ");
var diasEmprestimo = int.Parse(Console.ReadLine() ?? "1");
emprestimo.DataDevolucao = emprestimo.DataEmprestimo.AddDays(diasEmprestimo);

Console.WriteLine("\n---- Aqui está o relatório do seu empréstimo ----\n");
Console.WriteLine(emprestimo.Relatorio());