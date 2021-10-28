using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathObstacleContainer : MonoBehaviour
{

    public bool willFlash = true;
    public float flashTimer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Flash());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Flash()
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
        }
    }

}
