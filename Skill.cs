public class Skill {
    public string name { get; init; }
    public int rarity { get; init; }
    public bool isHardSkill { get; init; }

    public Skill(string skillName, int skillRarity, bool skillIsHardSkill) {
        name = skillName;
        rarity = skillRarity;
        isHardSkill = skillIsHardSkill;
    }

    public static List<Skill> createListOfSkills(string[] names, int[] rarity, bool[] isHard) {
        int len = names.Length;
        List<Skill> SList = new List<Skill>();

        for (int i = 0; i < len; i++)
            SList.Add(new Skill(names[i], rarity[i], isHard[i]));

        return SList;
    }

    // used by HR
    public static int evaluateHardness(bool isHard) {
        return isHard ? 1 : 0;
    }
}