using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeLaunch : MonoBehaviour
{
    [SerializeField]
    private float verticalPower = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<PlayerController2>().ApplyKnockback(new Vector3(1, 1, 0), 100, verticalPower, .2f);
        SoundManager.instance.PlaySound("pain");
    }
}
