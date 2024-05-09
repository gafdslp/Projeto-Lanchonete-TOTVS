using System;
using System.Collections.Generic;
using System.Globalization;

public class Produto {
    public string Nome;
    public string Descricao;
    public double Preco;

    public Produto(string nome, string descricao, double preco){
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
    }
}

public class Pedido {
    public int Quantidade;
    public string Produto;
    public double ValorTotal;

    public Pedido(int quantidade, string produto, double valorTotal) {
        Quantidade = quantidade;
        Produto = produto;
        ValorTotal = valorTotal;
    }
}

namespace SistemaLanchonete {
    internal class Program {
        static void Main(string[] args){
            int Quantidade = 0;
            int contadorProdutos = 0;
            string ContinuarComprando = "";
            string continuarAdicionando;
            double Total = 0;
            double ValorFinal = 0;
            double TaxaServico = 0;
            double CalcularTaxaServico = 0.07;
            double Final = 0;

            List<Produto> listaProdutos = new List<Produto>();
            List<Pedido> detalhesPedidos = new List<Pedido>();

            Console.WriteLine("Olá, seja bem vindo(a) a nossa lanchonete!");

            Console.WriteLine("\nVamos iniciar adicionando os produtos no sistema.\nOBS: O número máximo de produtos que podem ser adicionados é 10.\n");
            
            Console.WriteLine("\n-------------- CRIAR UM NOVO PRODUTO --------------\n");
            
            do
            {
                if (contadorProdutos >= 10)
                {
                    Console.WriteLine("Você atingiu o o máximo de 10 produtos adicionados.");
                    break;
                }

                Console.Write("Vamos lá!\nDigite o NOME do seu produto:");
                string nomeProduto = Console.ReadLine().ToUpper();

                Console.Write("Certo! Agora digite a DESCRIÇÃO do seu produto:");
                string descricaoProduto = Console.ReadLine();

                Console.Write("Agora é só informar o PREÇO do seu produto: ");
                double precoProduto = Convert.ToDouble(Console.ReadLine());

                listaProdutos.Add(new Produto(nomeProduto, descricaoProduto, precoProduto));

                contadorProdutos++;

                Console.WriteLine("\nParabéns!\nO seu produto foi registrado com sucesso!\n");

                Produto produtoCriado = listaProdutos.Last();
                Console.WriteLine("\n----------------------------------------\n{0,-15} {1,-15}", "Nome", "Descrição\n");
                Console.WriteLine("{0, -15} {1, -15} \n\nTOTAL: R$ {2,-20}\n----------------------------------------\n", produtoCriado.Nome, produtoCriado.Descricao, produtoCriado.Preco.ToString("F2", CultureInfo.InvariantCulture));

                Console.Write("\nDeseja continuar adicionando mais algum produto?");
                
                continuarAdicionando = Console.ReadLine();

            } while (continuarAdicionando.ToLower() == "sim"       ||
                     continuarAdicionando.ToLower() == "adicionar" ||
                     continuarAdicionando.ToLower() == "quero"     ||
                     continuarAdicionando.ToLower() == "continuar" ||
                     continuarAdicionando.ToLower() == "s"         ||
                     continuarAdicionando.ToLower() == "ok" 
                    );
            
            do
            {
                Console.WriteLine("-------------- CARDÁPIO --------------\n");

                Console.WriteLine("{0,-15} {1,-15} {2,-40}", "Nome", "Preço", "Descrição \n");
                foreach (Produto produto in listaProdutos)
                {
                    Console.WriteLine("{0, -15} R$ {1, -15} {2,-40}\n", produto.Nome, produto.Preco.ToString("F2", CultureInfo.InvariantCulture), produto.Descricao);
                }

                Console.WriteLine("\n\n-------------- FAZER PEDIDO --------------\n");

                Console.Write("Hora de realizar o seu pedido!\n");
                Console.WriteLine("\nDigite o NOME do produto conforme o CARDÁPIO acima.\n");

                string nomeProdutoEscolhido = Console.ReadLine().ToUpper();

                Console.WriteLine("Quantas unidades desse produto?\n");
                Quantidade = Convert.ToInt32(Console.ReadLine());   

            
                Produto produtoEscolhido = listaProdutos.FirstOrDefault(p => p.Nome.ToUpper() == nomeProdutoEscolhido);
            
                if (produtoEscolhido != null)
                {
                    Total = Quantidade * produtoEscolhido.Preco;
                    Pedido novoPedido = new Pedido(Quantidade, produtoEscolhido.Nome, Total);
                    detalhesPedidos.Add(novoPedido);

                    Console.WriteLine("-------------- PEDIDO ANOTADO COM SUCESSO --------------\n");
                    Console.WriteLine("Você escolheu: {0} unidades(s) de {1} Total R$ {2}", Quantidade, produtoEscolhido.Nome, Total.ToString("F2", CultureInfo.InvariantCulture));
                }
                else
                {
                    
                }    

                ValorFinal += Total;
            
                Console.Write("\n----------------------------------------------------------\n\nDeseja fazer um novo pedido ?");
                ContinuarComprando = Console.ReadLine();

            } while (ContinuarComprando.ToLower() == "sim"        ||
                     ContinuarComprando.ToLower() == "vamos"      ||
                     ContinuarComprando.ToLower() == "quero"      ||
                     ContinuarComprando.ToLower() == "continuar"  ||
                     ContinuarComprando.ToLower() == "ok"         ||
                     ContinuarComprando.ToLower() == "s"          
                     );

            Console.WriteLine("\n\nDETALHES DO PEDIDO:\n\n");

            Console.WriteLine("{0,-15} {1,-20} {2,-10}", "Quantidade", "Produto", "Valor\n");
            foreach (Pedido pedido in detalhesPedidos)
            {
                Console.WriteLine("{0,-15} {1,-20} {2,-10}", pedido.Quantidade, pedido.Produto, "R$ " + pedido.ValorTotal.ToString("F2", CultureInfo.InvariantCulture));
            }

            TaxaServico = ValorFinal * CalcularTaxaServico;
            Final = TaxaServico + ValorFinal;

            Console.Write("\n----------------------------------------------------------\nValor total dos pedidos:             R$ {0}", ValorFinal.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("\nTaxa de serviço(7%):                 R$ {0}\n", TaxaServico.ToString("F2", CultureInfo.InvariantCulture).PadLeft(5, '0'));
            Console.WriteLine("----------------------------------------------------------\nValor final da compra:               R$ {0}\n\n", Final.ToString("F2", CultureInfo.InvariantCulture));
            
            Console.Write("\n\nAtendimento Finalizado, obrigado pela Preferência!");
            Console.Read();
        }
    }
}  
