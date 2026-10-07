//using System.Collections.Generic;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Text.Json;
//using System.Diagnostics;

//string caminho = "Dados/swear-words.json";

//string json = File.ReadAllText(caminho);

//JsonDocument documento = JsonDocument.Parse(json);

//JsonElement palavrasJson =
//    documento.RootElement.GetProperty("swear-words");

//List<string> palavrasProibidas = new List<string>();

//foreach (JsonElement palavra in palavrasJson.EnumerateArray())
//{
//    palavrasProibidas.Add(palavra.GetString()!);
//}

//// API
//ApiLetras api = new ApiLetras();

//Console.Write("Artista: ");
//string artista = Console.ReadLine()!;

//Console.Write("Música: ");
//string musica = Console.ReadLine()!;

//Stopwatch tempoApi = Stopwatch.StartNew();

//string? letraApi = await api.BuscarLetra(artista, musica);

//tempoApi.Stop();

//if (letraApi == null)
//{
//    Console.WriteLine("Não foi possível encontrar a letra.");
//    return;
//}

//Console.WriteLine();
//Console.WriteLine("Letra encontrada!");
//Console.WriteLine(
//    $"Tempo da API: {tempoApi.Elapsed.TotalMilliseconds} ms"
//);

//// Regex
//AnalisadorLetras analisador =
//    new AnalisadorLetras();

//Stopwatch tempoRegex = Stopwatch.StartNew();

//int total = analisador.IdentificarPalavras(letraApi);

//tempoRegex.Stop();

//Console.WriteLine();
//Console.WriteLine($"Total encontrado: {total}");
//Console.WriteLine(
//    $"Tempo do Regex: {tempoRegex.Elapsed.TotalMilliseconds} ms"
//);

//// Mascaramento
//Console.WriteLine();
//Console.WriteLine("Letra mascarada:");
//Console.WriteLine();

//string letraMascarada =
//    analisador.MascararPalavras(letraApi);

//Console.WriteLine(letraMascarada);


using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Diagnostics;

// =====================================================
// CARREGAR PALAVRAS PROIBIDAS
// =====================================================

string caminho = "Dados/swear-words.json";

string json = File.ReadAllText(caminho);

JsonDocument documento = JsonDocument.Parse(json);

JsonElement palavrasJson =
    documento.RootElement.GetProperty("swear-words");

List<string> palavrasProibidas = new List<string>();

foreach (JsonElement palavra in palavrasJson.EnumerateArray())
{
    palavrasProibidas.Add(palavra.GetString()!);
}

// =====================================================
// ESCOLHA DA FONTE DA LETRA
// =====================================================

Console.WriteLine("=================================");
Console.WriteLine("     IDENTIFICADOR DE LETRAS");
Console.WriteLine("=================================");
Console.WriteLine();

Console.WriteLine("1 - Buscar letra pela API");
Console.WriteLine("2 - Usar letra do arquivo local");
Console.WriteLine();

Console.Write("Escolha uma opção: ");
string opcao = Console.ReadLine()!;

string? letra = null;

// =====================================================
// OPÇÃO 1 - API
// =====================================================

if (opcao == "1")
{
    ApiLetras api = new ApiLetras();

    Console.WriteLine();
    Console.Write("Artista - Música: ");
    string musica = Console.ReadLine()!;

    Stopwatch tempoApi = Stopwatch.StartNew();

    letra = await api.BuscarLetra(musica);

    tempoApi.Stop();

    if (letra == null)
    {
        Console.WriteLine();
        Console.WriteLine("Não foi possível encontrar a letra.");
        return;
    }

    Console.WriteLine();
    Console.WriteLine("Letra encontrada!");
    Console.WriteLine(
        $"Tempo da API: {tempoApi.Elapsed.TotalMilliseconds:F4} ms"
    );
}

// =====================================================
// OPÇÃO 2 - ARQUIVO LOCAL
// =====================================================

else if (opcao == "2")
{
    string caminhoLetra = "Letras/musica1.txt";

    if (!File.Exists(caminhoLetra))
    {
        Console.WriteLine();
        Console.WriteLine(
            "O arquivo musica1.txt não foi encontrado."
        );

        return;
    }

    Stopwatch tempoLeitura = Stopwatch.StartNew();

    letra = File.ReadAllText(caminhoLetra);

    tempoLeitura.Stop();

    Console.WriteLine();
    Console.WriteLine("Letra carregada do arquivo.");
    Console.WriteLine(
        $"Tempo de leitura: {tempoLeitura.Elapsed.TotalMilliseconds:F4} ms"
    );
}

// =====================================================
// OPÇÃO INVÁLIDA
// =====================================================

else
{
    Console.WriteLine();
    Console.WriteLine("Opção inválida.");
    return;
}

// =====================================================
// ANÁLISE COM REGEX
// =====================================================

AnalisadorLetras analisador =
    new AnalisadorLetras();

Console.WriteLine();
Console.WriteLine("=================================");
Console.WriteLine("        ANÁLISE COM REGEX");
Console.WriteLine("=================================");
Console.WriteLine();

Stopwatch tempoRegex = Stopwatch.StartNew();

int total = analisador.IdentificarPalavras(letra);

tempoRegex.Stop();


Console.WriteLine();
Console.WriteLine($"Total encontrado: {total}");
Console.WriteLine(
    $"Tempo do Regex: {tempoRegex.Elapsed.TotalMilliseconds:F4} ms"
);

TestesRegex.Executar();

//// =====================================================
//// MASCARAMENTO
//// =====================================================

//Console.WriteLine();
//Console.WriteLine("=================================");
//Console.WriteLine("       LETRA MASCARADA");
//Console.WriteLine("=================================");
//Console.WriteLine();

//string letraMascarada =
//    analisador.MascararPalavras(letra);

//Console.WriteLine(letraMascarada);
