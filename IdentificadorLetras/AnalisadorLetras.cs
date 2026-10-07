using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class AnalisadorLetras
{
    private readonly Dictionary<string, string> padroes;

    public AnalisadorLetras()
    {
        padroes = new Dictionary<string, string>
        {
            // PUTA E VARIAÇÕES
            { "puta", @"\bput(a|o|inha|inho|aria|eiro|ero)\b" },

            // MERDA
            { "merda", @"\bmerda(s)?\b" },

            // PORRA
            { "porra", @"\bporra(s)?\b" },

            // BOSTA
            { "bosta", @"\bbosta(s)?\b" },

            // VIADO E VARIAÇÕES
            { "viado", @"\bviad(o|a|inho)\b" },

            // VADIA
            { "vadia", @"\bvadi(a|azinha)\b" },

            // VAGABUNDA / VAGABUNDO
            { "vagabunda", @"\bvagabund(o|a)\b" },

            // BUCETA
            { "buceta", @"\b(?:buceta|bucetuda)\b" },

            // PIROCA / PIROK / PIROKA
            { "piroca", @"\b(?:piroca|pirok|piroka)\b" },

            // ROLA
            { "rola", @"\b(?:rola|rolas|rolão|rôla)\b" },

            // CU E VARIAÇÕES
            { "cu", @"\b(?:cu|cusinho|cuzinho|cusão|cuzão|cú)\b" },

            // FODER E VARIAÇÕES
            { "foder", @"\b(?:foda-se|fodase|fodida|fodido|fudendo|fudeno|fudeo|fuder|fuderam|fudeu)\b" },

            // DESGRAÇA
            { "desgraça", @"\bdesgraç(?:a|ada|ado)\b" },

            // XOTA / XOXOTA
            { "xota", @"\b(?:xota|xoxota)\b" },

            // XIBIU
            { "xibiu", @"\bxibiu\b" },

            // SIRIRICA
            { "siririca", @"\bsiririca\b" },

            // SURUBA
            { "suruba", @"\bsuruba\b" },

            // BICHA
            { "bicha", @"\bbich(a|inha|ona)\b" },

            // BIXA
            { "bixa", @"\bbix(a|inha|ona)\b" },

            // BOQUETE
            { "boquete", @"\bboquete\b" },

            // BRIOCO
            { "brioco", @"\bbrioco\b" },

            // BRONHA
            { "bronha", @"\bbronha\b" },

            // BROXA
            { "broxa", @"\bbroxa\b" },

            // BOCETA
            { "boceta", @"\bboceta\b" },

            // CHAVASCA / XAVASCA
            { "chavasca", @"\b(?:chavasca|xavasca)\b" },

            // CHOCHOTA
            { "chochota", @"\bchochota\b" },

            // CHUMBOLINAR / XUMBOLINAR
            { "chumbolinar", @"\b(?:chumbolinar|xumbolinar)\b" },

            // CORNO
            { "corno", @"\bcorno\b" },

            // FDP / FDPA / FDS
            { "fdp", @"\b(?:fdp|fdpa|fds)\b" },

            // GOZADA / GOZAR
            { "gozada", @"\bgozada\b" },
            { "gozar", @"\bgozar\b" },

            // GRELO
            { "grelo", @"\b(?:grelo|grelinho|greluda)\b" },

            // PAU
            { "pau", @"\bpau\b" },

            // PICA / PIKA
            { "pica", @"\b(?:pica|pika)\b" },

            // PUNHETA
            { "punheta", @"\b(?:punheta|punheteiro|punhetinha)\b" },

            // PUTARIA / PUTEIRO
            { "putaria", @"\bputaria\b" },
            { "puteiro", @"\b(?:puteiro|putero)\b" },

            // RABUDA / RABÃO
            { "rabuda", @"\b(?:rabuda|rabão)\b" },

            // RAPARIGA
            { "rapariga", @"\brapariga\b" },

            // RAXA
            { "raxa", @"\braxa\b" },

            // SIRIRICA / SURUBA já incluídos acima

            // TABACA
            { "tabaca", @"\btabaca\b" },

            // TESUDA / TESUDO / TEZUDA / TEZUDO
            { "tesuda", @"\b(?:tesuda|tesudo|tezuda|tezudo)\b" },

            // TMC / TMNC
            { "tmc", @"\b(?:tmc|tmnc)\b" },

            // VAGABUNDA / VAGABUNDO já incluídos

            // VIADINHO / VIADO já incluídos

            // VSF
            { "vsf", @"\bvsf\b" },

            // VTNC
            { "vtnc", @"\bvtnc\b" },

            // XUPETA
            { "xupeta", @"\bxupeta\b" }
        };
    }

    public int IdentificarPalavras(string letra)
    {
        int totalEncontrado = 0;

        foreach (var item in padroes)
        {
            MatchCollection ocorrencias =
                Regex.Matches(
                    letra,
                    item.Value,
                    RegexOptions.IgnoreCase
                );

            if (ocorrencias.Count > 0)
            {
                Console.WriteLine(
                    $"{item.Key}: {ocorrencias.Count} ocorrência(s)"
                );

                totalEncontrado += ocorrencias.Count;
            }
        }

        return totalEncontrado;
    }

    public string MascararPalavras(string letra)
    {
        string resultado = letra;

        foreach (string padrao in padroes.Values)
        {
            resultado = Regex.Replace(
                resultado,
                padrao,
                "***",
                RegexOptions.IgnoreCase
            );
        }

        return resultado;
    }
}