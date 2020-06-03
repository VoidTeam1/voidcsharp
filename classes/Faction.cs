using System.Drawing;
using System.Numerics;

public struct FactionInfo {
    public int id;
    public string name;
    public string logo;
    public Color color;
    public int xp;
    public int level;
    public Vector3 spawnPos;
    public Faction parentFaction;
    public int maxMembers;
    public string tag;
}

public class Faction {

    int ID { get; set; }
    string Name { get; set; }
    string Logo { get; set; }
    Color Color { get; set; }
    int XP { get; set; }
    int Level { get; set; }
    Vector3 SpawnPos { get; set; }
    Faction ParentFaction { get; set; }
    int MaxMembers { get; set; }
    string Tag { get; set; }

    public Faction(FactionInfo factionInfo) {
        ID = factionInfo.id;
        Name = factionInfo.name;
        Logo = factionInfo.logo;
        Color = factionInfo.color;
        XP = factionInfo.xp;
        Level = factionInfo.level;
        SpawnPos = factionInfo.spawnPos;
        MaxMembers = factionInfo.maxMembers;
        Tag = factionInfo.tag;
    }
}