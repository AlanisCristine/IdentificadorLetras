using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class TestesRegex
{
    public static void Executar()
    {
        Dictionary<string, string> testes = new Dictionary<string, string>
        {
            { "puta", @"\bput(a|o|inha|inho|aria|eiro|ero)\b" },
            { "merda", @"\bmerda(s)?\b" },
            { "porra", @"\bporra(s)?\b" },
            { "bosta", @"\bbosta(s)?\b" },
            { "viado", @"\bviad(o|a|inho)\b" },
            { "vadia", @"\bvadi(a|azinha)\b" },
            { "vagabunda", @"\bvagabund(o|a)\b" },
            { "buceta", @"\b(?:buceta|bucetuda)\b" },
            { "piroca", @"\b(?:piroca|pirok|piroka)\b" },
            { "rola", @"\b(?:rola|rolas|rolão|rôla)\b" },
            { "cu", @"\b(?:cu|cusinho|cuzinho|cusão|cuzão|cú)\b" },
            { "foder", @"\b(?:foda-se|fodase|fodida|fodido|fudendo|fudeno|fudeo|fuder|fuderam|fudeu)\b" },
            { "desgraça", @"\bdesgraç(?:a|ada|ado)\b" },
            { "xota", @"\b(?:xota|xoxota)\b" },
            { "xibiu", @"\bxibiu\b" },
            { "siririca", @"\bsiririca\b" },
            { "suruba", @"\bsuruba\b" },
            { "bicha", @"\bbich(a|inha|ona)\b" },
            { "bixa", @"\bbix(a|inha|ona)\b" },
            { "boquete", @"\bboquete\b" },
            { "brioco", @"\bbrioco\b" },
            { "bronha", @"\bbronha\b" },
            { "broxa", @"\bbroxa\b" },
            { "boceta", @"\bboceta\b" },
            { "chavasca", @"\b(?:chavasca|xavasca)\b" },
            { "chochota", @"\bchochota\b" },
            { "chumbolinar", @"\b(?:chumbolinar|xumbolinar)\b" },
            { "corno", @"\bcorno\b" },
            { "fdp", @"\b(?:fdp|fdpa|fds)\b" },
            { "gozada", @"\bgozada\b" },
            { "gozar", @"\bgozar\b" },
            { "grelo", @"\b(?:grelo|grelinho|greluda)\b" },
            { "pau", @"\bpau\b" },
            { "pica", @"\b(?:pica|pika)\b" },
            { "punheta", @"\b(?:punheta|punheteiro|punhetinha)\b" },
            { "putaria", @"\bputaria\b" },
            { "puteiro", @"\b(?:puteiro|putero)\b" },
            { "rabuda", @"\b(?:rabuda|rabão)\b" },
            { "rapariga", @"\brapariga\b" },
            { "raxa", @"\braxa\b" },
            { "tabaca", @"\btabaca\b" },
            { "tesuda", @"\b(?:tesuda|tesudo|tezuda|tezudo)\b" },
            { "tmc", @"\b(?:tmc|tmnc)\b" },
            { "vsf", @"\bvsf\b" },
            { "vtnc", @"\bvtnc\b" },
            { "xupeta", @"\bxupeta\b" }
        };

        string[] palavrasValidas =
        {
            "puta",
            "puto",
            "putinha",
            "putinho",
            "putaria",
            "puteiro",
            "putero",

            "merda",
            "merdas",

            "porra",
            "porras",

            "bosta",
            "viada",
            "viado",
            "viadinho",

            "vadia",
            "vadiazinha",

            "vagabunda",
            "vagabundo",

            "buceta",
            "bucetuda",

            "piroca",
            "pirok",
            "piroka",

            "rola",
            "rolas",
            "rolão",
            "rôla",

            "cu",
            "cú",
            "cuzinho",
            "cusinho",
            "cuzão",
            "cusão",

            "foda-se",
            "fodase",
            "fodida",
            "fodido",
            "fudendo",
            "fuder",
            "fuderam",
            "fudeu",

            "desgraça",
            "desgraçada",
            "desgraçado",

            "xota",
            "xoxota",
            "xibiu",
            "siririca",
            "suruba",

            "bicha",
            "bichinha",
            "bichona",

            "bixa",
            "bixinha",
            "bixona",

            "boquete",
            "brioco",
            "bronha",
            "broxa",
            "boceta",

            "chavasca",
            "xavasca",
            "chochota",

            "chumbolinar",
            "xumbolinar",

            "corno",

            "fdp",
            "fdpa",
            "fds",

            "gozada",
            "gozar",

            "grelo",
            "grelinho",
            "greluda",

            "pau",
            "pica",
            "pika",

            "punheta",
            "punheteiro",
            "punhetinha",

            "rabuda",
            "rabão",

            "rapariga",
            "raxa",

            "tabaca",

            "tesuda",
            "tesudo",
            "tezuda",
            "tezudo",

            "tmc",
            "tmnc",

            "vsf",
            "vtnc",

            "xupeta"
        };

        string[] falsosPositivos =
        {
            "disputa",
            "computador",
            "mercado",
            "curva",
            "cuidado",
            "viaduto",
            "pausa",
            "pauta",
            "picar",
            "pico",
            "corredor",
            "bicho",
            "bichinho",
            "vaga",
            "vagar",
            "desgraçadozinho"
        };

        int acertos = 0;
        int erros = 0;

        Console.WriteLine();
        Console.WriteLine("=================================");
        Console.WriteLine("      TESTE DOS REGEX");
        Console.WriteLine("=================================");
        Console.WriteLine();

        Console.WriteLine("PALAVRAS QUE DEVEM SER ENCONTRADAS:");
        Console.WriteLine();

        foreach (string palavra in palavrasValidas)
        {
            bool encontrada = false;

            foreach (string regex in testes.Values)
            {
                if (Regex.IsMatch(
                    palavra,
                    regex,
                    RegexOptions.IgnoreCase))
                {
                    encontrada = true;
                    break;
                }
            }

            if (encontrada)
            {
                Console.WriteLine($"{palavra}: OK");
                acertos++;
            }
            else
            {
                Console.WriteLine($"{palavra}: ERRO");
                erros++;
            }
        }

        Console.WriteLine();
        Console.WriteLine("PALAVRAS QUE NÃO DEVEM SER ENCONTRADAS:");
        Console.WriteLine();

        foreach (string palavra in falsosPositivos)
        {
            bool encontrada = false;

            foreach (string regex in testes.Values)
            {
                if (Regex.IsMatch(
                    palavra,
                    regex,
                    RegexOptions.IgnoreCase))
                {
                    encontrada = true;
                    break;
                }
            }

            if (!encontrada)
            {
                Console.WriteLine($"{palavra}: OK");
                acertos++;
            }
            else
            {
                Console.WriteLine($"{palavra}: FALSO POSITIVO");
                erros++;
            }
        }

        Console.WriteLine();
        Console.WriteLine("=================================");
        Console.WriteLine("          RESULTADO");
        Console.WriteLine("=================================");
        Console.WriteLine();
        Console.WriteLine($"Acertos: {acertos}");
        Console.WriteLine($"Erros: {erros}");

        if (erros == 0)
        {
            Console.WriteLine("Todos os testes passaram!");
        }
        else
        {
            Console.WriteLine("Existem testes que precisam ser corrigidos.");
        }
    }
}