// abstract class Skills {
//     public string[] skillNames;

//     public Skills(string[] SskillNames) {
//         skillNames = SskillNames;
//     }

//     // look how many preffered skills does the person have
//     public int calculatePoints(string[] skills) {
//         int count = 0;

//         foreach(string skill in skills)
//             if (this.skillNames.Contains(skill))
//             count++;

//         return count;
//     }
// }

public class Skill {
    public string name { get; init; }
    public int rarity { get; init; }
    public bool isHardSkill { get; init; }

    public Skill(string skillName, int skillRarity, bool skillIsHardSkill) {
        name = skillName;
        rarity = skillRarity;
        isHardSkill = skillIsHardSkill;
    }

    public static Skill[] createListOfSkills(string[] names, int[] rarity, bool[] isHard) {
        int len = names.Length;
        Skill[] SList = {};

        for (int i = 0; i < len; i++)
            SList.Append(new Skill(names[i], rarity[i], isHard[i]));

        return SList;
    }
}