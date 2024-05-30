# LogErrorAnalyzer

LogErrorAnalyzer é uma aplicação de console .NET que analisa arquivos de log para identificar blocos de processamento com erros específicos e extrai informações relevantes desses blocos. Ele agrupa os hashes de mensagens por banco de dados inicial (`RealmInicial`) e gera um arquivo de resultado contendo esses agrupamentos.

## Funcionalidades

- Analisa um arquivo de log e identifica blocos de processamento.
- Detecta erros específicos dentro dos blocos.
- Extrai hashes de mensagens (`MensagemHash`) e bancos de dados iniciais (`RealmInicial`) dos blocos com erros.
- Agrupa os hashes por banco de dados inicial e salva os resultados em um arquivo de saída.

## Pré-requisitos

- .NET 6 SDK ou superior instalado. Você pode baixar o SDK do .NET [aqui](https://dotnet.microsoft.com/download).

## Como Usar

### Passo 1: Clonar o Repositório

Primeiro, clone o repositório do projeto para o seu ambiente local.

```bash
bash git clone https://github.com/seu-usuario/LogErrorAnalyzer.git
```
```bash
cd LogErrorAnalyzer
```


### Passo 2: Restaurar Dependências
Restaure as dependências do projeto.
```bash
dotnet restore
```


### Passo 3: Compilar o Projeto
Compile o projeto para garantir que todos os arquivos estejam configurados corretamente.
dotnet build


### Passo 4: Executar a Aplicação
Para executar a aplicação, você deve fornecer o caminho para o arquivo de log e o caminho para o arquivo de saída onde os resultados serão salvos.
```bash
dotnet run -- "caminho/para/seu/logfile.log" "caminho/para/output.txt"
```

### Resultado Esperado
O arquivo de saída gerado terá os hashes agrupados pelo banco de dados inicial (RealmInicial), como mostrado no exemplo abaixo:

```bash
banco_de_dados_1
"C6232E367A58899A3CDD55E742618FF2", 
"B084E28BF1CA1E9319F76289BE5ADDCC", 
"40EEF17D78966AEA894B70636B61C433",

banco_de_dados_2 
"C56D46BA838AC1A6E426D102F4FD9C07", 
"3133553BC7E2684FE51112A1A3EE749F", 
...
```

### Estrutura do Projeto
O projeto tem a seguinte estrutura:
```bash
LogErrorAnalyzer/
├── LogErrorAnalyzer.csproj
├── Program.cs
├── LogProcessor.cs
├── Block.cs
└── README.md
```

### Explicação do Código
##### Program.cs: Contém o método principal que executa a lógica de análise de log e processamento dos resultados.
##### LogProcessor.cs: Classe responsável por processar o arquivo de log, identificar blocos de processamento e extrair informações relevantes.
##### Block.cs: Classe que representa um bloco de processamento no arquivo de log.



### Licença
Este projeto está licenciado sob a licença MIT - veja o arquivo [LICENSE](LICENSE) para mais detalhes.






