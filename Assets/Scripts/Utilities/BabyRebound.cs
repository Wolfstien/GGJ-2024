using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyRebound : MonoBehaviour
{
    public float ReboundForceMultiplier = 10f;
    void Start()
    {
        
    }

    private void OnCollisionStay(Collision other) 
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (GetComponent<Rigidbody>().velocity.magnitude < other.rigidbody.velocity.magnitude)
            {
                return;
            }
            other.rigidbody.AddForce((other.transform.position - transform.position).normalized * ReboundForceMultiplier, ForceMode.Impulse);
        }
    }
}
