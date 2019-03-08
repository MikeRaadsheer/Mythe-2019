public class Enemy
{

    public string name;
    public int hp;
    public int att;
    public int def;
    public AttackTypes weakness;
    public AttackTypes immunity;
    public int lvl;

    public static int enemyCount;


    public Enemy(string Name, int HP, int ATT, int DEF, int LVL)
    {
        enemyCount++;

        name = Name;
        hp = HP;
        att = ATT;
        def = DEF;
        lvl = LVL;
    }

    public Enemy(string Name, int HP, int ATT, int DEF, AttackTypes Weakness, int LVL)
    {
        enemyCount++;

        name = Name;
        hp = HP;
        att = ATT;
        def = DEF;
        weakness = Weakness;
        lvl = LVL;
    }

    public Enemy(string Name, int HP, int ATT, int DEF, AttackTypes Weakness, AttackTypes Immunity, int LVL)
    {
        enemyCount++;

        name = Name;
        hp = HP;
        att = ATT;
        def = DEF;
        weakness = Weakness;
        immunity = Immunity;
        lvl = LVL;
    }
}
