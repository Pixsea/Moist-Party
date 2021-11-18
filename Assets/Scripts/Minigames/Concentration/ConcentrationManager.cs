using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcentrationManager : MonoBehaviour
{

    public GameObject CardPrefab;
    public CardManager[] cards;

    void CardSetup() {
        cards = new CardManager[16];
        

        for (int i = 0; i < cards.Length; i++) {
            cards[i].CardInstance = Instantiate(CardPrefab, new Vector3(0f, 0f, 0f), new Quaternion(0f, 0f, 0f, 0f));
            cards[i].CardValue = i + 1;
        }

        for (int i = 0; i < cards.Length / 2; i++) {
            cards[2 * i].CardValue = i + 1;
            cards[2 * i + 1].CardValue = i + 1;
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
