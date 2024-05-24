using LogErrorAnalyzer;

string logFilePath = "D:/Documents/dev/bendig-bits/LogErrorAnalyzer/log.md";
string outputFilePath = "output.txt";

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
