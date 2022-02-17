using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcentrationManager : MonoBehaviour
{

    public GameObject CardPrefab;

    public List<int> cardValues = new List<int> { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8 };

    void CardSetup() {
        

        for (int i = 0; i < cardValues.Count; i++) {
            var temp = Instantiate(CardPrefab, new Vector3(0f, 0f, 0f), new Quaternion(0f, 0f, 0f, 0f));
            temp.GetComponent<CardScript>().cardValue = cardValues[i];
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CardSetup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
