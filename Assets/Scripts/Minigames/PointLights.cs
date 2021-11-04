using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLights : MonoBehaviour
{
    public SpotlightMazeManager sMM;
    public bool givesPoints = true;
    [SerializeField]
    private List<int> whoGetPoints;
    [SerializeField]
    private float pointGiveTime;



    // Start is called before the first frame update
    void Start()
    {
        whoGetPoints = new List<int>();
        StartCoroutine(GivePoints());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.CompareTag("Player"))
       {
            int pNum = other.GetComponent<PlayerController2>().playerNum;
            if (!whoGetPoints.Contains(pNum))
            { 
                whoGetPoints.Add(pNum);
            }
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
        while(givesPoints)
        {
            Debug.Log("Points given");
            foreach(int player in whoGetPoints)
            {
                sMM.IncreaseScore(player, 1);
            }
            yield return new WaitForSeconds(pointGiveTime);
        }
    }


}
