using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    [SerializeField]
    private GameObject p1;
    [SerializeField]
    private GameObject p2;
    [SerializeField]
    private GameObject p3;
    [SerializeField]
    private GameObject p4;

    // Start is called before the first frame update
    void Start()
    {
        p1.SetActive(false);
        p2.SetActive(false);
        p3.SetActive(false);
        p4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayers(int num)
    {
        p1.SetActive(true);
        p2.SetActive(true);

        if (num >= 3)
        {
            p3.SetActive(true);
        }
        if (num >= 4)
        {
            p4.SetActive(true);
        }

        gameObject.SetActive(false);
    }
}
