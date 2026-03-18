using System.Globalization;

string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";
List<string> listaDosFilmes = new List<string> { "KILL BILL", "Cidade de Deus", "Forrest Gump" };

// CORREÇÃO: A declaração deve vir antes do uso de métodos como .Add()
Dictionary<string, List<int>> filmesregistrados = new Dictionary<string, List<int>>();

filmesregistrados.Add("Marty Supreme", new List<int>{1, 2, 3});
filmesregistrados.Add("Cidade de Deus", new List<int>());
filmesregistrados.Add("KILL BILL", new List<int>());
filmesregistrados.Add("Forrest Gump", new List<int>());

void ExibirLogo()
{
    Console.WriteLine(@"
    S C R E E N   S O U N D
    ");
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu()
{
    Console.WriteLine("\nDigite 1 para registrar um filme");
    Console.WriteLine("Digite 2 para mostrar todos os filmes");
    Console.WriteLine("Digite 3 para avaliar um filme");
    Console.WriteLine("Digite 4 para exibir a média de um filme");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            RegistrarFilmes();
            break;
        case 2:
            MostrarFilmesRegistrados();
            break;
        case 3: 
            AvaliarUmFilme();
            break;
        case 4:
            ExibirMedia();
            break;
        case -1:
            Console.WriteLine("Você escolheu a opção " + opcaoEscolhidaNumerica);
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
}

void RegistrarFilmes()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro dos filmes");
    Console.Write("Digite o nome do filme que deseja: ");
    string nomeDoFilme = Console.ReadLine()!;
    filmesregistrados.Add(nomeDoFilme, new List<int>());
    listaDosFilmes.Add(nomeDoFilme);
    Console.WriteLine($"O filme {nomeDoFilme} foi registrado");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void MostrarFilmesRegistrados()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo todos os filmes registrados");

    foreach (string filme in listaDosFilmes)
    {
        Console.WriteLine($"Filme: {filme}");
    }

    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarUmFilme()
{
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar filme");
    Console.Write("Digite o nome do filme que deseja avaliar: ");
    string nomeDoFilme = Console.ReadLine()!;
    if (filmesregistrados.ContainsKey(nomeDoFilme))
    {
        Console.Write($"Qual a nota que o filme {nomeDoFilme} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        filmesregistrados[nomeDoFilme].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para o filme {nomeDoFilme}");
        Thread.Sleep(2000); 
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"\nO filme {nomeDoFilme} não foi encontrado!");
        Console.Write("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

void ExibirMedia()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibir média do filme");
    Console.Write("Digite o nome do filme que deseja exibir a média: ");
    string nomeDoFilme = Console.ReadLine()!;
    if (filmesregistrados.ContainsKey(nomeDoFilme))
    {
        List<int> notasDoFilme = filmesregistrados[nomeDoFilme];
        // Prevenção de erro: verifica se há notas antes de calcular média
        if (notasDoFilme.Count > 0)
        {
            Console.WriteLine($"\nA média do filme {nomeDoFilme} é {notasDoFilme.Average()}.");
        }
        else
        {
            Console.WriteLine($"\nO filme {nomeDoFilme} ainda não possui notas registradas.");
        }
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"\nO filme {nomeDoFilme} não foi encontrado!");
        Console.Write("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

ExibirLogo();
ExibirOpcoesDoMenu();
