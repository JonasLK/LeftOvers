using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnUnitButton : MonoBehaviour
{
    public GameObject unitToSpawn;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FakeStart(string unitName)
    {
        GetComponentInChildren<TextMeshProUGUI>().text = unitName;
    }

    public void OnClick()
    {

    }
}
