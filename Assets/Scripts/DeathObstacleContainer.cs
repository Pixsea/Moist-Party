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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartFlash()
    {
        //Decides the pattern in which the cubes this controls flashes, and changes the color to match the pattern, blue for 1, green for 2, and purple for 3.
        //Values are hard coded, ew. Change the first 3 numbers to change the color.
        if (flashType == 1)
        {
            foreach (MeshRenderer cube in this.GetComponentsInChildren<MeshRenderer>())
            {
                cube.material.color = new Color32(20, 125, 207,255);
            }
            StartCoroutine(Flash1());
        }
        else if (flashType == 2)
        {
            foreach (MeshRenderer cube in this.GetComponentsInChildren<MeshRenderer>())
            {
                cube.material.color = new Color32(54, 161, 77,255);
            }
            StartCoroutine(Flash2());
        }
        else if (flashType == 3)
        {
            foreach (MeshRenderer cube in this.GetComponentsInChildren<MeshRenderer>())
            {
                cube.material.color = new Color32(224, 101, 229,255);
            }
            StartCoroutine(Flash3());
        }
    }
    //Waits the twice the flash time, then changes the state.
    private IEnumerator Flash1()
    {
        while (willFlash)
        {
            Debug.Log("Flash Cycle 1");
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
            Debug.Log("Flash Cycle 2");
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
            Debug.Log("Flash Cycle 3");
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
