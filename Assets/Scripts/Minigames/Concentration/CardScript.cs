using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    public int cardValue;
    public bool faceUp;
    public int player; // 0 is no player selected; ints 1-4 represents player that has selected the 
    public int timer;
    public GameObject card;
    public int index;

    // Start is called before the first frame update
    void Start()
    {
        faceUp = false;
        player = 0;
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void StartFlip() {
        
        StartCoroutine(CardFlip());
    }

    public void Flip() {
        faceUp = !faceUp;
    }

    IEnumerator CardFlip() {
        for (int i = 0; i < 90; i++) {
            yield return new WaitForSeconds(0.01f);
            transform.Rotate(new Vector3(2f, 0f, 0f));
            timer++;
        }
        timer = 0;
        Flip();
    }

    public void Remove() {
        Destroy(card);
        Destroy(this);
    }
}
