using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillDispenser : MonoBehaviour
{
    public GameObject pill;
    public float reloadTime = 1f;
    public float fireSpeed = 2f;

    private bool canShoot;
    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            StartCoroutine (FirePills());
        }
    }

    // This fires the pills.
    IEnumerator FirePills()
    {
        GameObject firedpill = Object.Instantiate(pill);
        firedpill.GetComponent<Pill>().dispenser = this.gameObject;
        firedpill.transform.position = transform.position + transform.forward;
        firedpill.transform.eulerAngles += transform.eulerAngles;
        Rigidbody rb = firedpill.GetComponent<Rigidbody>();
        Vector3 direction = transform.forward;
        Vector3 velocity = direction * fireSpeed;
        rb.velocity = velocity;
        canShoot = false;
        yield return new WaitForSeconds(reloadTime);
        canShoot = true;
    }
}
