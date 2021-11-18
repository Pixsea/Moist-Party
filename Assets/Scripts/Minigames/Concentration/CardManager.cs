using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CardManager
{
    public int CardValue;

    [HideInInspector] public GameObject CardInstance;

    

    // Start is called before the first frame update
    void Start()
    {
        CardValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
