using System;

[Serializable]
public class PlayerStats
{
    public string name;
    public int hp;
    public int att;
    public int def;
    public int lvl;
    public Position pos;

    public PlayerStats(string Name, int HP, int ATT, int DEF, int LVL)
    {
        name = Name;
        hp = HP;
        att = ATT;
        def = DEF;
        lvl = LVL;
    }

}
