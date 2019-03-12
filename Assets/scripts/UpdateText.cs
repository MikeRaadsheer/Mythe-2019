using UnityEngine;
using UnityEngine.UI;

public class UpdateText : MonoBehaviour
{

    public enum targetType { PLAYER, SWARM };

    public targetType targetSelector;

    public Text txtName;
    public Text txtHP;
    public Text txtLVL;

    private GameObject target;

    private void Start()
    {
        InvokeRepeating("UpdateInfo", 0f, 1f/30f);
    }

    private void UpdateInfo()
    {
        switch (targetSelector)
        {
            case targetType.PLAYER:
                UpdatePlayer();
                break;
            case targetType.SWARM:
                UpdateSwarm();
                break;
        }
    }

    void UpdatePlayer()
    {
        Player player = FindObjectOfType<Player>();

        if (!FindObjectOfType<Player>())
        {
            CancelInvoke("UpdateInfo");
            return;
        }

        txtName.text = player.GetName();
        txtHP.text = "HP: " + player.GetHp().ToString();
        txtLVL.text = "LVL: " + player.GetLvl().ToString();
    }

    void UpdateSwarm()
    {
        Swarm swarm = FindObjectOfType<Swarm>();

        if (!FindObjectOfType<Swarm>())
        {
            CancelInvoke("UpdateInfo");
            return;
        }

        txtName.text = swarm.GetName();
        txtHP.text = "HP: " + swarm.GetHp().ToString();
        txtLVL.text = "LVL: " + swarm.GetLvl().ToString();
    }

}
