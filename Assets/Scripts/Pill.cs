using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill : MonoBehaviour
{
    public float destroyTimer = 3f;
    public GameObject dispenser;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimedDestroy());
    }

    // Update is called once per frame
    void Update()
    {
    }


    private IEnumerator TimedDestroy()
    {
        yield return new WaitForSeconds(destroyTimer);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().GetHit();
        }
        if (other.gameObject != dispenser)
        {
            Destroy(this.gameObject);
        }
    }
}
