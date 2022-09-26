public class Contest {
    string name { get; init; }
    DateTime receivedAt { get; init; }
    string domain;
    
    public Contest(string contestName, DateTime contestReceivedAt, string contesetDomain) {
        name = contestName;
        receivedAt = contestReceivedAt;
        domain = contesetDomain;
    }

    public static Contest[] createListOfContests(string[] names, DateTime[] recieveDates, string[] contestDomains) {
        int len = names.Length;
        Contest[] contests = {};

        for (int i = 0; i < len; i++)
            contests.Append(new Contest(names[i], recieveDates[i], contestDomains[i]));

        return contests;
    }
}