using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class PlayerButton : MonoBehaviour
{
    public enum buttonType { start, scoreIncrease, scoreDecrease, toggleSelection, minigame, quit};

    

    public int minPlayers = 3;
    private int currPlayers = 0;  // How many players are on the button

    public float timeToActivate = 3f;

    public GameObject pointObj;

    public buttonType buttontype = buttonType.start;

    public string minigameScene = "";

    //public UnityEvent buttonAction;

    public ScoreTracker scoretracker;

    public GameObject buttonBlock;

    private float startHeight;
    public float pressedHeightChange = .25f;
    public float changeSpeed = .001f;

    [SerializeField]
    private SceneChanger sceneChanger;


    private void Start()
    {
        startHeight = buttonBlock.transform.position.y;

        if (buttontype == buttonType.minigame)
        {
            minPlayers = scoretracker.GetNumPlayers();
        }
    }


    private void Awake()
    {
        //if (buttonAction == null)
        //{
        //    buttonAction = new UnityEvent();
        //}
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if (currPlayers >= 1)
        {
            // Move button down
            float newHeight = buttonBlock.transform.position.y - changeSpeed;
            if (newHeight < startHeight - pressedHeightChange)
            {
                newHeight = startHeight - pressedHeightChange;
            }
            buttonBlock.transform.position = new Vector3(transform.position.x, newHeight, transform.position.z);
        }
        else
        {
            // Move button up
            float newHeight = buttonBlock.transform.position.y + changeSpeed;
            if (newHeight > startHeight)
            {
                newHeight = startHeight;
            }
            buttonBlock.transform.position = new Vector3(transform.position.x, newHeight, transform.position.z);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            currPlayers += 1;

            //Debug.Log(currPlayers);
            //Debug.Log(minPlayers);

            if (currPlayers >= minPlayers)
            {
                StartCoroutine(StartCountdown());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            currPlayers -= 1;

            StopAllCoroutines();
        }
    }


    IEnumerator StartCountdown()
    {
        SoundManager.instance.PlaySound("button");

        // If a score button
        if (buttontype == buttonType.scoreIncrease)
        {
            scoretracker.SetWinScore(-2);
        }
        else if (buttontype == buttonType.scoreDecrease)
        {
            scoretracker.SetWinScore(-1);
        }
        else if (buttontype == buttonType.toggleSelection)
        {
            scoretracker.ChangeRandomSelection();
        }
        else
        {
            float rotation = 0;

            if (buttontype == buttonType.minigame || buttontype == buttonType.quit)
            {
                rotation = 45f;
            }

            GameObject pointEffect = Instantiate(pointObj, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5, gameObject.transform.position.z - 1), Quaternion.Euler(rotation, 0, 0));
            pointEffect.GetComponent<PointEffect>().pointText.color = new Color(167 / 255f, 145 / 255f, 255 / 255f);
            pointEffect.GetComponent<PointEffect>().pointText.text = "3";

            yield return new WaitForSeconds(timeToActivate / 3);

            GameObject pointEffect2 = Instantiate(pointObj, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5, gameObject.transform.position.z - 1), Quaternion.Euler(rotation, 0, 0));
            pointEffect2.GetComponent<PointEffect>().pointText.color = new Color(167 / 255f, 145 / 255f, 255 / 255f);
            pointEffect2.GetComponent<PointEffect>().pointText.text = "2";

            yield return new WaitForSeconds(timeToActivate / 3);

            GameObject pointEffect3 = Instantiate(pointObj, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5, gameObject.transform.position.z - 1), Quaternion.Euler(rotation, 0, 0));
            pointEffect3.GetComponent<PointEffect>().pointText.color = new Color(167 / 255f, 145 / 255f, 255 / 255f);
            pointEffect3.GetComponent<PointEffect>().pointText.text = "1";

            yield return new WaitForSeconds(timeToActivate / 3);


            // If its the start button, set number of players and move to next scene
            if (buttontype == buttonType.start)
            {
                scoretracker.SetNumPlayers(currPlayers);
                SceneManager.LoadScene("BoardScene", LoadSceneMode.Single);
            }
            else if (buttontype == buttonType.minigame)
            {
                scoretracker.SetNumPlayers(currPlayers);
                sceneChanger.LoadMiniGame(minigameScene);
            }
            else if (buttontype == buttonType.quit)
            {
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
                scoretracker.ResetScore();
            }

            yield return null;
        }
    }
}
