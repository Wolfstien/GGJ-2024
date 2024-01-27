using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapController : MonoBehaviour
{
    public Rigidbody Player1, Player2;
    public float MoveAmountMultiplier = 0.1f;
    public bool isGameOver = false;

    void Start()
    {
        
    }

    public void Tap(int _id)
    {
        Debug.Log(_id);
        if (isGameOver)
        {
            return;
        }

        Rigidbody player = _id == 1 ? Player1 : Player2;
        // player.MovePosition(player.transform.position + (player.transform.forward * MoveAmountMultiplier));
        player.AddForce(player.transform.forward * MoveAmountMultiplier, ForceMode.VelocityChange);
    }

    public void DisablePhysics()
    {
        Player1.isKinematic = true;
        Player2.isKinematic = true;
    }

    void OnEnable() 
    {
        InputManager.ButtonTap += Tap;
    }

    void OnDisable() 
    {
        InputManager.ButtonTap -= Tap;
    }
}
