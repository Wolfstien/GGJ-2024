using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    public static InGameUI instance;

    void Awake() 
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        
    }

    public void ButtonTap(int _id)
    {
        InputManager.instance.OnButtonTap(_id);
    }
}
