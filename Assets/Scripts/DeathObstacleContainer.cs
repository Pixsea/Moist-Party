using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathObstacleContainer : MonoBehaviour
{

    public bool willFlash = true;
    public float flashTimer = 1f;

    public int flashType = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Decides the pattern in which the cubes this controls flashes
        if(flashType == 1)
        {
            StartCoroutine(Flash1());
        }
        else if (flashType == 2)
        {
            StartCoroutine(Flash2());
        }
        else if (flashType == 3)
        {
            StartCoroutine(Flash3());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Waits the twice the flash time, then changes the state.
    private IEnumerator Flash1()
    {
        while (willFlash)
        {
            yield return new WaitForSeconds(flashTimer*2);
            foreach (Transform child in transform)
            {
                if (child.gameObject.activeSelf)
                {
                    child.gameObject.SetActive(false);
                }
                else
                {
                    child.gameObject.SetActive(true);
                }
            }
        }
    }

    private IEnumerator Flash2()
    {
        while (willFlash)
        {
            yield return new WaitForSeconds(flashTimer);
            foreach (Transform child in transform)
            {
                if (child.gameObject.activeSelf)
                {
                    child.gameObject.SetActive(false);
                }
                else
                {
                    child.gameObject.SetActive(true);
                }
            }
            yield return new WaitForSeconds(flashTimer);
        }
    }

    private IEnumerator Flash3()
    {
        while (willFlash)
        {
            foreach (Transform child in transform)
            {
                if (child.gameObject.activeSelf)
                {
                    child.gameObject.SetActive(false);
                }
                else
                {
                    child.gameObject.SetActive(true);
                }
            }
            yield return new WaitForSeconds(flashTimer * 2);
        }
    }

}
