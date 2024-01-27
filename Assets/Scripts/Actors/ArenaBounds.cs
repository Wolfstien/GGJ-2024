using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArenaBounds : MonoBehaviour
{
    void Start()
    {
        
    }

    void OnTriggerExit(Collider other) 
    {
        Debug.Log(other.tag);
        if (other.tag.Equals("Player"))
        {
            SceneManager.LoadScene("MenuTemp");
        }
        // if (true)
        // {
            
        // }
    }
}
