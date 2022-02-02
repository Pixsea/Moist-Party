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
    private Texture simonSaysDirections;
    [SerializeField]
    private Texture dartofGoldDirections;
    [SerializeField]
    private Texture glowRunDirections;
    [SerializeField]
    private Texture parkourDirections;

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
    private void Update()
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
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            player2Ready = !player2Ready;
        }
        if (Input.GetKeyDown("t"))
        {
            player3Ready = !player3Ready;
        }
        if (Input.GetKeyDown("i"))
        {
            player4Ready = !player4Ready;
        }
    }

    private void OnEnable()
    {
        Wait();

        Debug.Log("TEST");
        if (directionImage != null)
        {
            Debug.Log(sceneChanger.nextScene);
            if (sceneChanger.nextScene == "MashHappy")
            {
                directionImage.texture = mashHappyDirections;
            }
            else if (sceneChanger.nextScene == "SimonSays")
            {
                directionImage.texture = simonSaysDirections;
            }
            else if (sceneChanger.nextScene == "DartofGold")
            {
                directionImage.texture = dartofGoldDirections;
            }
            else if (sceneChanger.nextScene == "SampleScene")
            {
                directionImage.texture = glowRunDirections;
            }
            else if (sceneChanger.nextScene == "ParkourScene")
            {
                directionImage.texture = parkourDirections;
            }
        }

        player1Ready = false;
        player2Ready = false;
        player3Ready = false;
        player4Ready = false;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(.5f);
    }
}
