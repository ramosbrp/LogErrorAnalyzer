using LogErrorAnalyzer;



//string logFilePath = "D:/Documents/dev/bendig-bits/LogErrorAnalyzer/log.md";
//string outputFilePath = "D:/Documents/dev/bendig-bits/LogErrorAnalyzer/output.txt";


if (args.Length < 2)
{
    Console.WriteLine("Usage: dotnet run <path_to_log_file> <output_file>");
    return;
}

string logFilePath = args[0]; // Primeiro argumento: caminho para o arquivo de log
string outputFilePath = args[1]; // Segundo argumento: caminho para o arquivo de saída

if (!File.Exists(logFilePath))
{
    Console.WriteLine("Arquivo de log não encontrado");
    return;
}

var logProcessor = new LogProcessor();
var blockWithError = logProcessor.ProcessLogFile(logFilePath);

var groupeHashes = logProcessor.GroupHashesByRealm(blockWithError);

logProcessor.WriteResultsToFile(outputFilePath, groupeHashes);

Console.WriteLine("Processamento completo, verifique o arquivo de saída.");
