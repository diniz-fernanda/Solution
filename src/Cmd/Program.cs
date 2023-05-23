using Cmd.API;
using Cmd.ApiClient;
using Domain.Model;
using Domain.Model.Enums;
using Microsoft.Extensions.Hosting;
using System.Globalization;


string baseUrl = "https://localhost:44355"; 

CarrinhoApiClient carrinhoApiClient = new CarrinhoApiClient(baseUrl);
CarroApiClient carroApiClient = new CarroApiClient(baseUrl);
PostoDeGasolinaApiClient postoDeGasolinaApiClient = new PostoDeGasolinaApiClient(baseUrl);

//// Chamada para obter os produtos
//Console.WriteLine("Obtendo os produtos...");
//List<Produto> produtos = await carrinhoApiClient.BuscarTodos();
//foreach (var produto in produtos)
//{
//    Console.WriteLine($" Produto: {produto.Nome} | Preço: {produto.Valor} | Vendido: {produto.Vendido}");
//}

////Chamada para bucar por id
//Console.WriteLine("Digite o ID do produto:");
//int id = int.Parse(Console.ReadLine());

//Produto produtoPorId = await carrinhoApiClient.BuscarPorId(id);

//if (produtoPorId != null)
//{
//    Console.WriteLine($"Produto encontrado: {produtoPorId.Nome},  Valor: {produtoPorId.Valor}, Vendido: {produtoPorId.Vendido}");
//}
//else
//{
//    Console.WriteLine("Produto não encontrado.");
//}

//// Chamada para adicionar um produto
//Console.WriteLine("\nClique enter para adicionar um novo produto.");
//Console.Write("Nome: ");
//string nome = Console.ReadLine();
//Console.Write("Valor: ");
//decimal valor = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
//Console.Write("Vendido : ");
//StatusVenda vendido = Enum.Parse<StatusVenda>(Console.ReadLine());


////Retorno dos dados adicionados
//Produto novoProduto = new Produto(nome, valor, vendido);
//Produto produtoAdicionado = await carrinhoApiClient.Post(novoProduto);
//Console.WriteLine($"Novo produto adicionado: {produtoAdicionado.Nome} | Preço: {produtoAdicionado.Valor} | Vendido: {produtoAdicionado.Vendido}");

////Chamada para alterar um produto
//Console.WriteLine("\nClique enter para alterar um produto.");
//Console.WriteLine("Digite o ID do produto que deseja atualizar:");
//id = int.Parse(Console.ReadLine());
//Console.Write("Nome: ");
//nome = Console.ReadLine();
//Console.Write("Valor: ");
//valor = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
//Console.Write("Vendido : ");
//vendido = Enum.Parse<StatusVenda>(Console.ReadLine());

//Produto produtoAtualizado = new Produto(nome, valor, vendido);

//try
//{
//    await carrinhoApiClient.Atualizar(id, produtoAtualizado);
//    Console.WriteLine("Produto atualizado com sucesso!" +
//                       $"\n Nome: {produtoAtualizado.Nome} | Valor : {produtoAtualizado.Valor} | Vendido: {produtoAtualizado.Vendido}");
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Erro ao atualizar o produto: {ex.Message}");
//}


////Chamada para remover um produto
//Console.WriteLine("Digite o ID do produto que deseja deletar:");
//id = int.Parse(Console.ReadLine());

//try
//{
//    await carrinhoApiClient.Apagar(id);
//    Console.WriteLine("Produto deletado com sucesso!");
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Erro ao deletar o produto: {ex.Message}");
//}

Console.WriteLine("Bem-vindo ao Posto de Gasolina!");

// Solicitar informações do usuário
Console.Write("Informe a quantidade de carros: ");
int quantidadeCarros = int.Parse(Console.ReadLine());

Console.Write("Informe a quantidade de bombas: ");
int quantidadeBombas = int.Parse(Console.ReadLine());

// Criar array de carros
Carro[] carros = new Carro[quantidadeCarros];
for (int i = 0; i < quantidadeCarros; i++)
{
    Console.Write($"Informe o nome do carro {i + 1}: ");
    string nomeCarro = Console.ReadLine();

    Console.Write($"Informe o tempo de abastecimento do carro {i + 1}: ");
    int tempoAbastecimento = int.Parse(Console.ReadLine());

    carros[i] = new Carro(nomeCarro, tempoAbastecimento);
}
//Instancia criada
PostoDeGasolina posto = new PostoDeGasolina();

// Executar o abastecimento
List<Carro> carrosAbastecidos = await carroApiClient.CadastrarCarro(carros);
Console.WriteLine();
//Exibir resultados
Console.WriteLine("\nResultados do abastecimento:");
foreach (var carro in carros)
{
    Console.WriteLine($"Carro: {carro.NomeCarro} | Tempo de Abastecimento: {carro.TempoAbastecimento} segs");
}

Console.WriteLine("\nAbastecimento concluído. Obrigado!");
    

