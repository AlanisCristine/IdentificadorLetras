using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class ApiLetras
{
    private readonly HttpClient cliente;

    public ApiLetras()
    {
        cliente = new HttpClient();

        cliente.DefaultRequestHeaders.UserAgent.ParseAdd(
            "LyricsFetcher/1.0"
        );

        cliente.Timeout = TimeSpan.FromSeconds(10);
    }

    public async Task<string?> BuscarLetra(string musica)
    {
        Console.WriteLine("Consultando o LRCLIB...");

        string? letra = await BuscarLRCLIB(musica);

        if (!string.IsNullOrWhiteSpace(letra))
        {
            Console.WriteLine("Encontrado no LRCLIB!");
            return letra;
        }

        Console.WriteLine("LRCLIB não encontrou.");
        Console.WriteLine("Consultando o Lyrics.ovh...");

        letra = await BuscarLyricsOvh(musica);

        if (!string.IsNullOrWhiteSpace(letra))
        {
            Console.WriteLine("Encontrado no Lyrics.ovh!");
            return letra;
        }

        Console.WriteLine("Letra não encontrada.");
        return null;
    }

    private async Task<string?> BuscarLRCLIB(string musica)
    {
        try
        {
            string url =
                "https://lrclib.net/api/search" +
                $"?q={Uri.EscapeDataString(musica)}";

            HttpResponseMessage resposta =
                await cliente.GetAsync(url);

            if (!resposta.IsSuccessStatusCode)
                return null;

            string conteudo =
                await resposta.Content.ReadAsStringAsync();

            JsonDocument documento =
                JsonDocument.Parse(conteudo);

            foreach (JsonElement resultado
                     in documento.RootElement.EnumerateArray())
            {
                bool instrumental =
                    resultado.TryGetProperty(
                        "instrumental",
                        out JsonElement instrumentalElemento
                    )
                    && instrumentalElemento.GetBoolean();

                if (instrumental)
                    continue;

                string? plainLyrics = null;
                string? syncedLyrics = null;

                if (resultado.TryGetProperty(
                    "plainLyrics",
                    out JsonElement plainElemento))
                {
                    plainLyrics = plainElemento.GetString();
                }

                if (resultado.TryGetProperty(
                    "syncedLyrics",
                    out JsonElement syncedElemento))
                {
                    syncedLyrics = syncedElemento.GetString();
                }

                if (!string.IsNullOrWhiteSpace(plainLyrics))
                    return plainLyrics;

                if (!string.IsNullOrWhiteSpace(syncedLyrics))
                    return RemoverTempo(syncedLyrics);
            }

            return null;
        }
        catch (Exception erro)
        {
            Console.WriteLine(
                $"Erro no LRCLIB: {erro.Message}"
            );

            return null;
        }
    }

    private async Task<string?> BuscarLyricsOvh(string musica)
    {
        try
        {
            string suggestUrl =
                $"https://api.lyrics.ovh/suggest/{Uri.EscapeDataString(musica)}";

            HttpResponseMessage respostaSugestao =
                await cliente.GetAsync(suggestUrl);

            if (!respostaSugestao.IsSuccessStatusCode)
                return null;

            string conteudoSugestao =
                await respostaSugestao.Content.ReadAsStringAsync();

            JsonDocument documentoSugestao =
                JsonDocument.Parse(conteudoSugestao);

            JsonElement dados =
                documentoSugestao.RootElement
                    .GetProperty("data");

            if (dados.GetArrayLength() == 0)
                return null;

            JsonElement melhorResultado = dados[0];

            string artista =
                melhorResultado
                    .GetProperty("artist")
                    .GetProperty("name")
                    .GetString()!;

            string titulo =
                melhorResultado
                    .GetProperty("title")
                    .GetString()!;

            string url =
                $"https://api.lyrics.ovh/v1/" +
                $"{Uri.EscapeDataString(artista)}/" +
                $"{Uri.EscapeDataString(titulo)}";

            HttpResponseMessage resposta =
                await cliente.GetAsync(url);

            if (!resposta.IsSuccessStatusCode)
                return null;

            string conteudo =
                await resposta.Content.ReadAsStringAsync();

            JsonDocument documento =
                JsonDocument.Parse(conteudo);

            if (documento.RootElement.TryGetProperty(
                "lyrics",
                out JsonElement lyrics))
            {
                string? letra = lyrics.GetString();

                if (!string.IsNullOrWhiteSpace(letra))
                    return letra.Trim();
            }

            return null;
        }
        catch (Exception erro)
        {
            Console.WriteLine(
                $"Erro no Lyrics.ovh: {erro.Message}"
            );

            return null;
        }
    }

    private string RemoverTempo(string letra)
    {
        string[] linhas =
            letra.Split(
                new[] { '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries
            );

        List<string> resultado =
            new List<string>();

        foreach (string linha in linhas)
        {
            int posicao = linha.IndexOf(']');

            if (posicao >= 0)
            {
                resultado.Add(
                    linha.Substring(posicao + 1).Trim()
                );
            }
            else
            {
                resultado.Add(linha);
            }
        }

        return string.Join(
            Environment.NewLine,
            resultado
        );
    }
}


