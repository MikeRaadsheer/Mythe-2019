using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateText : MonoBehaviour
{

    public enum targetType { PLAYER, SWARM };

    public targetType targetSelector;

    public TextMeshProUGUI txtName;
    public TextMeshProUGUI txtHP;
    public Text txtLVL;

    private GameObject target;


    private void Start()
    {
        switch (targetSelector)
        {
            case targetType.PLAYER:
                Player player = FindObjectOfType<Player>();
                txtName.text = player.GetName();
                setHpTxt(player.GetHp());
                player.hpChanged += setHpTxt;
                player.GetLvl();
                break;
            case targetType.SWARM:
                Swarm swarm = FindObjectOfType<Swarm>();
                txtName.text = swarm.GetName();
                setHpTxt(swarm.GetHp());
                swarm.hpChanged += setHpTxt;
                swarm.GetLvl();
                break;
        }
    }
    
    void setHpTxt(int ammount)
    {
        txtHP.text = "HP: " + ammount.ToString();
    }

    void SetLvlText(int ammount)
    {
        txtLVL.text = "LVL: " + ammount.ToString();
    }
}
