public class journal {

    public string JournalName {get; set;}

    public List<Entry> Entries {get; set;}

    piblic Jounral()
    {
        Entries = new List<Entry>();
    }
}