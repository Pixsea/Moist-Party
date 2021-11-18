using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointLights : MonoBehaviour
{
    public SpotlightMazeManager sMM;
    public bool givesPoints = true;
    [SerializeField]
    private List<int> whoGetPoints;
    private List<int> whoGotPoints;
    [SerializeField]
    private float pointGiveTime;
    [SerializeField]
    private GameObject pointText;



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

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            int pNum = other.GetComponent<PlayerController2>().playerNum;
            whoGetPoints.Add(pNum);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            whoGetPoints.Remove(other.GetComponent<PlayerController2>().playerNum);
        }
    }

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
}
