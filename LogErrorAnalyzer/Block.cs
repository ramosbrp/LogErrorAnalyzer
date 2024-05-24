namespace LogErrorAnalyzer
{
    public class Block
    {
        public List<string> Lines { get; set; } = new List<string>();
        public bool HasError { get; set; } = false;
        public string MensagemHash { get; set; }
        public string RealmInicial { get; set; }
    }
}
