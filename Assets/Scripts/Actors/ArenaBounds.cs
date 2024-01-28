using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ArenaBounds : MonoBehaviour
{
    public UnityEvent<Rigidbody> OnPlayerRBExited;

    void Start()
    {
        
    }

    void OnTriggerExit(Collider other) 
    {
        Debug.Log(other.tag);
        if (other.tag.Equals("Player"))
        {
            OnPlayerRBExited.Invoke(other.attachedRigidbody);
        }
        // if (true)
        // {
            
        // }
    }
}
