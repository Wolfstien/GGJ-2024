using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyRebound : MonoBehaviour
{
    public float ReboundForceMultiplier = 10f;
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            other.rigidbody.AddForce((other.transform.position - transform.position).normalized * ReboundForceMultiplier, ForceMode.Impulse);
        }
    }
}
