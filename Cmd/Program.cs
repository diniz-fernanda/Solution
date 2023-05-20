using Cmd.API;
using System.Globalization;
using WebAPI.Entities;
using WebAPI.Entities.Enums;

string baseUrl = "https://localhost:44355"; 

CarrinhoApiClient carrinhoApiClient = new CarrinhoApiClient(baseUrl);

// Chamada para obter os produtos
Console.WriteLine("Obtendo os produtos...");
List<Produto> produtos = await carrinhoApiClient.BuscarTodos();
foreach (var produto in produtos)
{
    Console.WriteLine($"Produto: {produto.Nome} | Preço: {produto.Valor}");
}

// Chamada para adicionar um produto
Console.WriteLine("\nClique enter para adicionar um novo produto.");
Console.Write("Nome: ");
string nome = Console.ReadLine();
Console.Write("Valor: ");
decimal valor = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
Console.Write("Vendido : ");
StatusVenda vendido = Enum.Parse<StatusVenda>(Console.ReadLine());



Produto novoProduto = new Produto(nome, valor, vendido);
Produto produtoAdicionado = await carrinhoApiClient.Post(novoProduto);
Console.WriteLine($"Novo produto adicionado: {produtoAdicionado.Nome} | Preço: {produtoAdicionado.Valor}");
