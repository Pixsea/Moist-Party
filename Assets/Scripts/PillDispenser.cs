using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillDispenser : MonoBehaviour
{
    public GameObject pill;
    public float reloadTime;
    public float fireSpeed;

    private bool canShoot;
    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canShoot)
        {
            FirePills();
        }
    }

    // This fires the pills.
    void FirePills()
    {
        GameObject firedpill = Object.Instantiate(pill);
        Rigidbody rb = firedpill.GetComponent<Rigidbody>();
        Vector3 direction = firedpill.transform.forward;
        Vector3 velocity = direction * fireSpeed;
        rb.velocity = velocity;
    }
}
