using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapOnOff : MonoBehaviour
{
    public TresholdController _TC;

    public List<GameObject> mapList = new List<GameObject>();

    public void Start()
    {

        _TC.onPointAction += MapSwitch;
    }


    private void MapSwitch(int id)
    {
        for (int i = 0; i < mapList.Count; i++)
        {
            mapList[i].SetActive(true);
            Debug.Log(mapList[i]);
        }
        mapList[id].SetActive(false);

    }
}
 