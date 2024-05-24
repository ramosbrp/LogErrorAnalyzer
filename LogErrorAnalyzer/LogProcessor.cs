namespace LogErrorAnalyzer
{
    public class LogProcessor
    {
        public List<Block> ProcessLogFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var blocks = new List<Block>();

            Block currentBlock = null;

            foreach (var line in lines)
            {
                if (line.Contains("Iniciando interpretação da mensagem..."))
                {
                    currentBlock = new Block();
                }

                if (currentBlock != null)
                {
                    currentBlock.Lines.Add(line);

                    if (line.Contains("System.ArgumentException: Parameter 'P_ID_TIPO_RESIDENCIA' not found in the collection."))
                    {
                        currentBlock.HasError = true;
                    }

                    if (line.Contains("item.MensagemHash:"))
                    {
                        var hash = line.Split("item.MensagemHash:")[1].Trim();
                        currentBlock.MensagemHash = hash;
                    }

                    if (line.Contains("item.RealmInicial:"))
                    {
                        var realm = line.Split("item.RealmInicial:")[1].Trim();
                        currentBlock.RealmInicial = realm;
                    }

                    if (line.Contains("Trabalho com pedidos foi finalizado."))
                    {
                        blocks.Add(currentBlock);
                        currentBlock = null;
                    }
                }
            }
            return blocks.Where(b => b.HasError).ToList();
        }

        public Dictionary<string, List<string>> GroupHashesByRealm(List<Block> blocks)
        {
            var groupeHashes = new Dictionary<string, List<string>>();

            foreach (var block in blocks)
            {
                if (!groupeHashes.ContainsKey(block.RealmInicial))
                {
                    groupeHashes[block.RealmInicial] = new List<string>();
                }

                groupeHashes[block.RealmInicial].Add(block.MensagemHash);
            }

            return groupeHashes;
        }

        public void WriteResultsToFile(string filePath, Dictionary<string, List<string>> groupeHashes)
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var realm in groupeHashes.Keys)
                {
                    writer.WriteLine(realm);
                    foreach (var hash in groupeHashes[realm])
                    {
                        writer.WriteLine($"\"{hash}\",");
                    }
                    writer.WriteLine();
                }
            }
        }
    }
}
