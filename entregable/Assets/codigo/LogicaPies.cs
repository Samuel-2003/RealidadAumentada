using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPies : MonoBehaviour
{
    public animacion1 Animacion1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Animacion1.puedoSaltar = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Animacion1.puedoSaltar = false;
    }
}
