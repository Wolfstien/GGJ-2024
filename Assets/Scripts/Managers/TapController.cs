using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapController : MonoBehaviour
{
    public Rigidbody Player1, Player2;
    public float MoveAmountMultiplier = 0.1f;

    void Start()
    {
        
    }

    public void Tap(int _id)
    {
        Debug.Log(_id);
        Rigidbody player = _id == 1 ? Player1 : Player2;
        // player.MovePosition(player.transform.position + (player.transform.forward * MoveAmountMultiplier));
        player.AddForce(player.transform.forward * MoveAmountMultiplier, ForceMode.VelocityChange);
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
