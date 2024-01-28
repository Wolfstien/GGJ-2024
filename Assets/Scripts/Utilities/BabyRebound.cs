using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyRebound : MonoBehaviour
{
    public float ReboundForceMultiplier = 10f;
    public string[] HitSounds;
    public TapController TapController;

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
            
            TapController.PlayHitSFX(HitSounds[Random.Range(0, HitSounds.Length)]);
            // SoundManager.instance.PlaySFX(HitSounds[Random.Range(0, HitSounds.Length)]);
            other.rigidbody.AddForce((other.transform.position - transform.position).normalized * ReboundForceMultiplier, ForceMode.Impulse);
        }
    }
}
