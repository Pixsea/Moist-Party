using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardScript : MonoBehaviour
{
    public int cardValue;
    public bool faceUp;
    public int player; // 0 is no player selected; ints 1-4 represents player that has selected the 
    public int timer;
    public GameObject card;
    public int index;

    public GameObject pointText;

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
        Flip();
        for (int i = 0; i < 18; i++) {
            yield return new WaitForSeconds(0.01f);
            transform.Rotate(new Vector3(10f, 0f, 0f));
            timer++;
        }
        timer = 0;
    }

    public void Remove() {
        Destroy(card);
        Destroy(this);
    }

    public void ScorePopup() {

        GameObject pointEffect = Instantiate(pointText, new Vector3(0, gameObject.transform.position.y, gameObject.transform.position.z - 1), Quaternion.Euler(0, 0, 0));
        Text textEdit = pointEffect.GetComponent<PointEffect>().pointText;
        if (player == 1) {
            textEdit.color = Color.red;
            pointEffect.transform.position += new Vector3(-1.5f, 0, 0);
        }
        if (player == 2) {
            textEdit.color = Color.blue;
            pointEffect.transform.position += new Vector3(-.5f, 0, 0);
        }
        if (player == 3) {
            textEdit.color = Color.green;
            pointEffect.transform.position += new Vector3(5f, 0, 0);
        }
        if (player == 4) {
            textEdit.color = Color.yellow;
            pointEffect.transform.position += new Vector3(1.5f, 0, 0);
        }
        textEdit.text = "+1";
    }
}
