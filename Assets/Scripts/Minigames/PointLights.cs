using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointLights : MonoBehaviour
{
    public SpotlightMazeManager sMM;
    public bool givesPoints = true;
    public bool lightMove = false;
    private bool lightActive = false;
    [SerializeField]
    //The list of players who will get points when the time comes
    private List<int> whoGetPoints;
    //Who's been given points in each time they allot points
    private List<int> whoGotPoints;
    [SerializeField]
    //How long between points
    private float pointGiveTime;
    [SerializeField]
    private GameObject pointText;
    private float arriveTime = 1.5f;



    // Start is called before the first frame update
    void Start()
    {
        whoGetPoints = new List<int>();
        whoGotPoints = new List<int>();
        StartCoroutine(GivePoints()); 
    }

    // Update is called once per frame
    void Update()
    {

        if (!lightActive && lightMove)
        {
            StartCoroutine(LightMovement());
            lightActive = true;
            Debug.Log("Activated");
        }
    }

    //When a player enters the light, they will be listed in the points
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            int pNum = other.GetComponent<PlayerController2>().playerNum;
            whoGetPoints.Add(pNum);
        }
    }

    //When they leave, they will be unlisted
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            whoGetPoints.Remove(other.GetComponent<PlayerController2>().playerNum);
        }
    }
    //This gives the points to whoever is in the light at the alloted time
    private IEnumerator GivePoints()
    {
        while (givesPoints)
        {
            //Debug.Log("Points given");
            foreach (int player in whoGetPoints)
            {
                if (!whoGotPoints.Contains(player))
                {
                    sMM.IncreaseScore(player, 1);
                    ShowPoints(player);
                    whoGotPoints.Add(player);
                }
            }
            yield return new WaitForSeconds(pointGiveTime);
            whoGotPoints.Clear();
        }
    }

    //Shows the point effects when the points are alloted
    private void ShowPoints(int playerNum)
    {
        Debug.Log("Tried to spawn point effect");
        GameObject pointEffect = Instantiate(pointText, gameObject.transform.position, Quaternion.Euler(90, 0, 0));
        Text textEdit = pointEffect.GetComponent<PointEffect>().pointText;

        if (playerNum == 1)
        {
            textEdit.color = Color.red;
            pointEffect.transform.position += new Vector3(-1.5f, 0, 0);
        }
        if (playerNum == 2)
        {
            textEdit.color = Color.blue;
            pointEffect.transform.position += new Vector3(-.5f, 0, 0);
        }
        if (playerNum == 3)
        {
            textEdit.color = Color.green;
            pointEffect.transform.position += new Vector3(.5f, 0, 0);
        }
        if (playerNum == 4)
        {
            textEdit.color = Color.yellow;
            pointEffect.transform.position += new Vector3(1.5f, 0, 0);
        }

        textEdit.text = "+1";
    }

    //Picks a random move place between 9 options, then moves there.
    public IEnumerator LightMovement()
    {
        while(lightMove)
        { 
            Vector3 pos = transform.position;
            int x = Random.Range(-1, 2) * 9;
            int z = Random.Range(-1, 2) * 9;
            Vector3 dest = new Vector3(x, pos.y, z);
            while (dest == pos)
            {
                x = Random.Range(-1, 2) * 9;
                z = Random.Range(-1, 2) * 9;
                dest = new Vector3(x, pos.y, z);
            }
            yield return StartCoroutine(MoveToDestination(this.gameObject, dest, arriveTime));
        }
    }

    //This should move to a destination within a specific amount of seconds.
    public IEnumerator MoveToDestination(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        Debug.Log("New Dest");
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = end;
    }
}
