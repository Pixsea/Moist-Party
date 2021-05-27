using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartShooter : MonoBehaviour
{
    [SerializeField]
    private int playerNum;
    [SerializeField]
    private string fireButton;  // Button for the given player to shoot a dart
    [SerializeField]
    private GameObject dart;  // Bullet prefab
    [SerializeField]
    private GameObject target;  // reference to target
    //[SerializeField]
    //private GameObject player;  // reference to player
    [SerializeField]
    private GameObject gameManager; // reference to GameManager

    private float timer = 0;  // Timer to ahndle shot delay
    [SerializeField]
    private float fireDelay;  // delay ins seconds between shots


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Each individual script on the dart spawner object handles one player
        // Check if the player's button is pressed, the fire delay is up, the game is palying, and the player is actually playing
        if (Input.GetKeyDown(fireButton) && (gameManager.GetComponent<DartofGold>().playing == true)  && (timer >= fireDelay) && (gameManager.GetComponent<DartofGold>().numPlayers >= playerNum))
        {
            Shoot();
            timer = 0;
        }

        timer += 1 * Time.deltaTime;
    }

    void Shoot()
    {
        GameObject newDart = Instantiate(dart, gameObject.transform.position, gameObject.transform.rotation);
        newDart.GetComponent<Dart>().playerNum = playerNum;
        newDart.GetComponent<Dart>().target = target;
        //newDart.GetComponent<Dart>().player = player;
        newDart.GetComponent<Dart>().gameManager = gameManager;
    }
}
