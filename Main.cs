using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

class MainClass {
  private static NGenero ngenero = new NGenero();
  private static NAutor nautor = new NAutor();
  private static NLivro nlivro = new NLivro();
  private static NCliente ncliente = new NCliente();
  private static Cliente clienteLogin = null;
  public static void Main() {
    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

    int ol = 0;
    int perfil = 0;
    Console.WriteLine ("----- Sebo Virtual de Livros ------");
    do {
      try {
        if (perfil == 0) {
          ol = 0;
          perfil = MenuUsuario();
        }

        if (perfil == 1) {
          ol = MenuVendedor();
          switch(ol) {
            case 1 : GeneroListar(); break;
            case 2 : GeneroInserir(); break;
            case 3 : GeneroAtualizar(); break;
            case 4 : GeneroExcluir(); break;
            case 5 : AutorListar(); break;
            case 6 : AutorInserir(); break;
            case 7 : AutorAtualizar(); break;
            case 8 : AutorExcluir(); break;
            case 9 : LivroListar(); break;
            case 10 : LivroInserir(); break;
            case 11 : LivroAtualizar(); break;
            case 12 : LivroExcluir(); break;
            case 13 : ClienteListar(); break;
            case 14 : ClienteInserir(); break;
            case 15 : ClienteAtualizar(); break;
            case 16 : ClienteExcluir(); break;
            case 99 : perfil = 0; break;
          }
        }

        if (perfil == 2 && clienteLogin == null) {
          ol = MenuClienteLogin();
          switch(ol) {
            case 1  : ClienteLogin(); break;
            case 99 : perfil = 0; break;
          }
        }
        if (perfil == 2 && clienteLogin != null) {
          ol = MenuClienteLogout();
          switch(ol) {
            case 1  : ClienteVendaListar(); break;
            case 2  : ClienteLivroListar(); break;
            case 3  : ClienteLivroInserir(); break;
            case 4  : ClienteCarrinhoVisualizar(); break;
            case 5  : ClienteCarrinhoLimpar(); break;
            case 6  : ClienteCarrinhoComprar(); break;
            case 99 : ClienteLogout(); break;
          }
        }
      }

      catch (Exception erro) {
        Console.WriteLine(erro.Message);
        ol = 100;
      }
    } while (ol != 0);
    Console.WriteLine ("Fim...");    
  }
  public static int MenuUsuario() {
    Console.WriteLine();
    Console.WriteLine("----------------------------------");
    Console.WriteLine("1 - Entrar como Vendedor");
    Console.WriteLine("2 - Entrar como Cliente");
    Console.WriteLine("0 - Fim");
    Console.WriteLine("----------------------------------");
    Console.Write("Informe uma op????o: ");
    int ol = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return ol; 
  }

  public static int MenuVendedor() {
    Console.WriteLine();
    Console.WriteLine("----------------------------------");
    Console.WriteLine("1 - Genero - Listar");
    Console.WriteLine("2 - Genero - Inserir");
    Console.WriteLine("3 - Genero - Atualizar");
    Console.WriteLine("4 - Genero - Excluir");
    Console.WriteLine("5 - Autor - Listar");
    Console.WriteLine("6 - Autor - Inserir");
    Console.WriteLine("7 - Autor - Atualizar");
    Console.WriteLine("8 - Autor - Excluir");
    Console.WriteLine("9 - Livro - Listar");
    Console.WriteLine("10 - Livro - Inserir");
    Console.WriteLine("11 - Livro - Atualizar");
    Console.WriteLine("12 - Livro - Excluir");
    Console.WriteLine("13 - Cliente - Listar");
    Console.WriteLine("14 - Cliente - Inserir");
    Console.WriteLine("15 - Cliente - Atualizar");
    Console.WriteLine("16 - Cliente - Excluir");
    Console.WriteLine("99 - Voltar");
    Console.WriteLine("0 - Fim");
    Console.WriteLine("----------------------------------");
    Console.Write("Informe uma opcao: ");
    int ol = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return ol; 
  }

  public static int MenuClienteLogin() {
    Console.WriteLine();
    Console.WriteLine("----------------------------------");
    Console.WriteLine("01 - Login");
    Console.WriteLine("99 - Voltar");
    Console.WriteLine("0  - Fim");
    Console.WriteLine("----------------------------------");
    Console.Write("Informe uma op????o: ");
    int ol = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return ol; 
  }

  public static int MenuClienteLogout() {
    Console.WriteLine();
    Console.WriteLine("----------------------------------");
    Console.WriteLine("Bem vindo(a), " + clienteLogin.Nome);
    Console.WriteLine("----------------------------------");
    Console.WriteLine("01 - Listar minhas compras");
    Console.WriteLine("02 - Listar livros");
    Console.WriteLine("03 - Inserir um livro no carrinho");
    Console.WriteLine("04 - Visualizar o carrinho");
    Console.WriteLine("05 - Limpar o carrinho");
    Console.WriteLine("06 - Confirmar a compra");
    Console.WriteLine("99 - Logout");
    Console.WriteLine("0  - Fim");
    Console.WriteLine("----------------------------------");
    Console.Write("Informe uma op????o: ");
    int ol = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return ol; 
  }







  public static void GeneroListar() {
    Console.WriteLine("----- Lista de G??neros -----");
    Genero[] gs = ngenero.Listar();
    if (gs.Length == 0) {
      Console.WriteLine("Nenhum g??nero cadastrado");
      return;
    }
    foreach(Genero g in gs) Console.WriteLine(g);
    Console.WriteLine();  
  }
  
  public static void GeneroInserir() {
    Console.WriteLine("----- Inser????o de G??neros -----");
    Console.Write("Informe um c??digo para o g??nero: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descri????o: ");
    string descricao = Console.ReadLine();
    // Instanciar a classe de Genero
    Genero g = new Genero(id, descricao);
    // Inser????o do genero
    ngenero.Inserir(g);
  }
  public static void GeneroAtualizar() {
    Console.WriteLine("----- Atualiza????o de G??neros -----");
    GeneroListar();
    Console.Write("Informe um c??digo para o g??nero para alterar: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descri????o: ");
    string descricao = Console.ReadLine();
    // Instanciar a classe de Genero
    Genero g = new Genero(id, descricao);
    // Inser????o do genero
    ngenero.Atualizar(g);
  }
  public static void GeneroExcluir() {
    Console.WriteLine("----- Exclus??o de Generos -----");
    GeneroListar();
    Console.Write("Informe um c??digo do g??nero para excluir: ");
    int id = int.Parse(Console.ReadLine());
    // Procurar o genero com esse id
    Genero g = ngenero.Listar(id);
    // Exclui o genero do cadastro
    ngenero.Excluir(g);
  }


  public static void AutorListar() {
    Console.WriteLine("----- Lista de Autores -----");
    Autor[] ts = nautor.Listar();
    if (ts.Length == 0) {
      Console.WriteLine("Nenhum(a) autor(a) cadastrado(a)");
      return;
    }
    foreach(Autor t in ts) Console.WriteLine(t);
    Console.WriteLine();  
  }
  public static void AutorInserir() {
    Console.WriteLine("----- Inser????o de Autores -----");
    Console.Write("Informe um c??digo para o(a) autor(a): ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descri????o: ");
    string descricao = Console.ReadLine();
    // Instanciar a classe de Autor
    Autor t = new Autor(id, descricao);
    // Inser????o do autor
    nautor.Inserir(t);
  }
  public static void AutorAtualizar() {
    Console.WriteLine("----- Atualiza????o de Autores -----");
    AutorListar();
    Console.Write("Informe um c??digo para o(a) autor(a) para alterar: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descri????o: ");
    string descricao = Console.ReadLine();
    // Instanciar a classe de Autor
    Autor t = new Autor(id, descricao);
    // Inser????o do autor
    nautor.Atualizar(t);
  }
  public static void AutorExcluir() {
    Console.WriteLine("----- Exclus??o de Autores -----");
    AutorListar();
    Console.Write("Informe um c??digo do autor para excluir: ");
    int id = int.Parse(Console.ReadLine());
    // Procurar o(a) autor(a) com esse id
    Autor t = nautor.Listar(id);
    // Exclui o autor do cadastro
    nautor.Excluir(t);
  }






  public static void LivroListar() {
    Console.WriteLine("----- Lista de Livros -----");
    Livro[] ls = nlivro.Listar();
    if (ls.Length == 0) {
      Console.WriteLine("Nenhum livro cadastrado");
      return;
    }
    foreach(Livro l in ls) Console.WriteLine(l);
    Console.WriteLine();  
  }
  public static void LivroInserir() {
    Console.WriteLine("----- Inser????o de Livros -----");
    Console.Write("Informe um c??digo para o livro: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descri????o: ");
    string descricao = Console.ReadLine();
    Console.Write("Informe o estoque do livro: ");
    int quantidade = int.Parse(Console.ReadLine());
    Console.Write("Informe o pre??o do livro: ");
    double preco = double.Parse(Console.ReadLine());


    GeneroListar();
    Console.Write("Informe o c??digo do genero do livro: ");
    int idgenero = int.Parse(Console.ReadLine());

    AutorListar();
    Console.Write("Informe o c??digo do autor do livro: ");
    int idautor = int.Parse(Console.ReadLine());



    // Seleciona o genero a partir do id
    Genero g = ngenero.Listar(idgenero);    
   


    // Seleciona o autor a partir do id
    Autor t = nautor.Listar(idautor); 


    // Instanciar a classe de Livro
    Livro l = new Livro(id, descricao, quantidade, preco, g, t);


    // Inser????o do livro
    nlivro.Inserir(l);
  }
  public static void LivroAtualizar() {
  }
  public static void LivroExcluir() {
  }


 public static void ClienteListar() {
    Console.WriteLine("----- Lista de Clientes -----");
    // Lista os clientes
    List<Cliente> cs = ncliente.Listar();
    if (cs.Count == 0) {
      Console.WriteLine("Nenhum cliente cadastrado");
      return;
    }
    foreach(Cliente c in cs) Console.WriteLine(c);
    Console.WriteLine();  
  }

  public static void ClienteInserir() {
    Console.WriteLine("----- Inser????o de Clientes -----");
    Console.Write("Nome do(a) cliente: ");
    string nome = Console.ReadLine();
    Console.Write("Data de nascimento (dd/mm/aaaa): ");
    DateTime nasc = DateTime.Parse(Console.ReadLine());
    // Instancia a classe de cliente
    Cliente c = new Cliente { Nome = nome, Nascimento = nasc };
    // Insere o cliente
    ncliente.Inserir(c);
  }

  public static void ClienteAtualizar() {
    Console.WriteLine("----- Atualiza????o de Clientes -----");
    GeneroListar();
    Console.Write("C??digo do cliente a ser atualizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Nome do(a) cliente: ");
    string nome = Console.ReadLine();
    Console.Write("Data de nascimento (dd/mm/aaaa): ");
    DateTime nasc = DateTime.Parse(Console.ReadLine());
    // Instancia a classe de cliente
    Cliente c = new Cliente { Id = id, Nome = nome, Nascimento = nasc };
    // Atualiza o cliente
    ncliente.Atualizar(c);
  }

  public static void ClienteExcluir() {
    Console.WriteLine("----- Exclus??o de Clientes -----");
    GeneroListar();
    Console.Write("C??digo do cliente a ser exclu??do: ");
    int id = int.Parse(Console.ReadLine());
    // Procura o cliente com esse id
    Cliente c = ncliente.Listar(id);
    // Exclui o cliente do cadastro
    ncliente.Excluir(c);
  }

  

  public static void ClienteLogin() { 
    Console.WriteLine("----- Login do Cliente -----");
    ClienteListar();
    Console.Write("Informe o c??digo do cliente para logar: ");
    int id = int.Parse(Console.ReadLine());
    // Procura o cliente com esse id
    clienteLogin = ncliente.Listar(id);
  }


  public static void ClienteLogout() { 
    Console.WriteLine("----- Logout do Cliente -----");
    clienteLogin = null;
  }
  public static void ClienteVendaListar() { 
    Console.WriteLine("----- Venda Listar -----");
  }
  public static void ClienteLivroListar() { 
    Console.WriteLine("----- Livro Listar -----");
  }
  public static void ClienteLivroInserir() { 
    Console.WriteLine("----- Livro Inserir -----");
  }
  public static void ClienteCarrinhoVisualizar() { 
    Console.WriteLine("----- Carrinho Visualizar -----");
  }
  public static void ClienteCarrinhoLimpar() { 
    Console.WriteLine("----- Carrinho Limpar -----");
  }
  public static void ClienteCarrinhoComprar() { 
    Console.WriteLine("----- Carrinho Comprar -----");
  }


  

}