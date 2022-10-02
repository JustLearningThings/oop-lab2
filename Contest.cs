public class Contest : SelectionEntity {
    DateTime receivedAt { get; init; }
    
    public Contest(string contestName, DateTime contestReceivedAt, string contesetDomain)
                : base(contestName, contesetDomain) {
        receivedAt = contestReceivedAt;
    }

    public static List<Contest> createListOfContests(string[] names, DateTime[] recieveDates, string[] contestDomains) {
        int len = names.Length;
        List<Contest> contests = new List<Contest>();

        for (int i = 0; i < len; i++)
            contests.Add(new Contest(names[i], recieveDates[i], contestDomains[i]));

        return contests;
    }
}