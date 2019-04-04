using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class TresholdController : MonoBehaviour
{
    public Action<int> onPointAction;
    
    private int Timer = 6;
    
    public GameObject[] Treshold;
    public GameObject Player;

    [SerializeField]
    private GameObject spawnPointLvl1_1;
    [SerializeField]
    private GameObject spawnPointLvl2;
    [SerializeField]
    private GameObject spawnPointLvl3;

    [HideInInspector]
    public int _ID;

    public void Start()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Treshold")
        {
            for(int i=0; i<Timer; i++)
            {
                if (Treshold[0].GetComponent<TresholdNumber>().TresholdID == 1)
                {
                    //switch naar lvl 1.1
                    Treshold[0].GetComponent<TresholdNumber>().TresholdID = _ID;
                    onPointAction(_ID);
                    //Player.transform.position = spawnPointLvl1_1.transform.position;
                }
                if (Treshold[1].GetComponent<TresholdNumber>().TresholdID == 2)
                {
                    //switch naar lvl 2
                    Treshold[i].GetComponent<TresholdNumber>().TresholdID = _ID;
                    onPointAction(_ID);
                    Player.transform.position = spawnPointLvl2.transform.position;
                }
                if(Treshold[2].GetComponent<TresholdNumber>().TresholdID == 3)
                {
                    //switch naar eindlevel
                    Treshold[i].GetComponent<TresholdNumber>().TresholdID = _ID;
                    onPointAction(_ID);
                    //Player.transform.position = spawnPointLvl3.transform.position;
                }



            }
        }
    }
    
}
