using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    public int cardValue;
    public bool faceUp;
    public int timer;
    public GameObject card;

    // Start is called before the first frame update
    void Start()
    {
        faceUp = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a")) {
            StartFlip();
        }
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

            if (timer == 45 || timer == -45) {
                Flip();
            }
        }
        timer = 0;
    }
}
