using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackArm : MonoBehaviour
{
    [SerializeField]
    private float knockbackStrength = 10f;

    [SerializeField]
    private GameObject directionBase;  // The base of the spinner to base the knockback direction

    private GameObject[] hit;  // Players recently hit so the colldier only hits it once

    [SerializeField]
    private bool clockwise = true;

    [SerializeField]
    private float stunTime = .2f;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(other.gameObject.name);
            Vector3 direction = other.transform.position - directionBase.transform.position;
            direction = new Vector3(direction.x, 0, direction.z);

            int rotationDirection = 1;
            if (clockwise)
            {
                rotationDirection = -1;
            }


            direction = Quaternion.Euler(0, rotationDirection * 45, 0) * direction;
            //other.GetComponent<Rigidbody>().AddForce(direction * knockbackStrength, ForceMode.VelocityChange);
            //other.GetComponent<Rigidbody>().AddForce(Vector3.up * Mathf.Sqrt(jumpPower), ForceMode.VelocityChange);

            //other.gameObject.GetComponent<Rigidbody>().AddExplosionForce(knockbackStrength, direction, 0, .5f, ForceMode.VelocityChange);

            //Debug.Log(transform.forward.normalized);


            //other.gameObject.GetComponent<PlayerController2>().ApplyKnockback(transform.forward.normalized, knockbackStrength, .2f);
            other.gameObject.GetComponent<PlayerController2>().ApplyKnockback(direction, knockbackStrength, 20, stunTime);

        }
    }
}
