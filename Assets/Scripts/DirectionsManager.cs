using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionsManager : MonoBehaviour
{
    [SerializeField]
    private RawImage directionImage;

    [SerializeField]
    private Texture mashHappyDirections;

    [SerializeField]
    private SceneChanger sceneChanger;


    [SerializeField]
    private Text player1ReadyText;
    [SerializeField]
    private Text player2ReadyText;
    [SerializeField]
    private Text player3ReadyText;
    [SerializeField]
    private Text player4ReadyText;

    [SerializeField]
    private bool player1Ready;
    [SerializeField]
    private bool player2Ready;
    [SerializeField]
    private bool player3Ready;
    [SerializeField]
    private bool player4Ready;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Leave the screen, go to minigame
        if (Input.GetKeyDown("space"))
        {
            sceneChanger.LeaveDirectionsScreen();
        }

        if (Input.GetKeyDown("w"))
        {
            player1Ready = !player1Ready;

            //if (player)
        }
        if (Input.GetKeyDown("a"))
        {
            player1Ready = !player1Ready;
        }
        if (Input.GetKeyDown("s"))
        {
            player1Ready = !player1Ready;
        }
        if (Input.GetKeyDown("d"))
        {
            player1Ready = !player1Ready;
        }
    }

    private void OnEnable()
    {
        if (directionImage != null)
        {
            if (sceneChanger.nextScene == "MashHappy")
            {
                directionImage.texture = mashHappyDirections;
            }
        }

        player1Ready = false;
        player2Ready = false;
        player3Ready = false;
        player4Ready = false;
    }
}
