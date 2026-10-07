# Identificador de Letras

Projeto desenvolvido para a disciplina de **Teoria de Linguagens**, com o objetivo de aplicar conceitos de **Expressões Regulares** e **Autômatos Finitos Determinísticos (AFD)** na identificação e análise de obscenidades em letras musicais.

## Sobre o projeto

O sistema recebe letras de músicas e utiliza expressões regulares para identificar palavras consideradas obscenas, incluindo algumas de suas variações.

As letras podem ser obtidas por meio de APIs de letras musicais ou carregadas a partir de um arquivo local.

Após obter a letra, o sistema:

* Identifica palavras obscenas;
* Conta a quantidade de ocorrências encontradas;
* Mede o tempo de execução das expressões regulares;
* Permite validar os padrões por meio de testes de falsos positivos;
* Permite comparar o desempenho da implementação com outras linguagens.

## Tecnologias utilizadas

* C#
* .NET 8
* Expressões Regulares (Regex)
* APIs de letras musicais
* JSON

## Funcionamento

O programa apresenta duas opções:

1. Buscar letra pela API
2. Usar letra do arquivo local

Na busca pela API, o usuário informa a música no formato:

"Artista - Música"

O sistema consulta inicialmente o LRCLIB. Caso a letra não seja encontrada, tenta o Lyrics.ovh.

Depois da obtenção da letra, as expressões regulares são utilizadas para identificar as palavras procuradas.

Também é possível utilizar uma letra armazenada localmente na pasta `Letras`.

## Estrutura do projeto

IdentificadorLetras
│
├── Dados
│   └── swear-words.json
│
├── Letras
│   └── musica1.txt
│
├── AnalisadorLetras.cs
├── ApiLetras.cs
├── TestesRegex.cs
├── Program.cs
└── IdentificadorLetras.csproj


## Testes

O projeto possui uma classe específica para validação das expressões regulares.

Os testes verificam:

* Palavras que devem ser identificadas;
* Variações das palavras;
* Casos que não devem ser identificados;
* Possíveis falsos positivos.

Nos testes realizados atualmente, foram obtidos **111 acertos e 0 erros**.

## Objetivo da análise

O projeto faz parte de um estudo comparativo entre diferentes linguagens de programação.

Serão coletados dados como:

* Quantidade de obscenidades encontradas;
* Tempo de consulta da API;
* Tempo de execução das expressões regulares;
* Resultados obtidos em cada linguagem.

Esses dados serão utilizados posteriormente para uma comparação de desempenho entre as implementações.

## Disciplina

**Teoria de Linguagens**
**Bacharelado em Sistemas de Informação**
**IFMG – Campus Sabará**
