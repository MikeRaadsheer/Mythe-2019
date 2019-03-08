using UnityEngine;

public class Swarm : MonoBehaviour
{


    public Dialogue dialogue;
    private Enemy swarm = new Enemy("Swarm", 10, 1, 0, AttackTypes.FIRE, AttackTypes.STAB, 1);
    private Player target;

    private bool waitToAttack = false;
    private bool takeTurn = false;


    private void Start()
    {
        target = FindObjectOfType<Player>();
    }

    private void Update()
    {
        waitToAttack = dialogue.GetTyping();

        if (Input.anyKeyDown && !waitToAttack && takeTurn)
        {
            waitToAttack = false;
            takeTurn = false;
            target.takeDamage(AttackTypes.PUNCH, swarm.att);
        }
    }

    public void takeDamage(AttackTypes type, int dmg)
    {
        switch (type)
        {
            case AttackTypes.FIRE:
                dmg *= 2;
                break;
            case AttackTypes.STAB:
                dmg = 0;
                break;
        }

        swarm.hp -= dmg;
        if (swarm.hp <= 0)
        {
            swarm.hp = 0;
            dialogue.SetText(("You killed the " + swarm.name).ToUpper());
            Destroy(gameObject, 1f);
        }
        else
        {
            dialogue.SetText(("You dealt " + dmg.ToString() + " damage!").ToUpper());
            waitToAttack = false;
        }

        takeTurn = true;

    }

    public string GetName()
    {
        return swarm.name;
    }

    public int GetHp()
    {
        return swarm.hp;
    }

    public int GetLvl()
    {
        return swarm.lvl;
    }

}
