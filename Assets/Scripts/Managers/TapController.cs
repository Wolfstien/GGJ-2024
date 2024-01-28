using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapController : MonoBehaviour
{
    public Rigidbody Player1, Player2;
    public BabyAnimator BabyAnimator1, BabyAnimator2;
    public float MoveAmountMultiplier = 0.1f;
    public bool isStarted = false;
    public bool isGameOver = false;

    public GameObject CamStart, CamCombat;

    void Start()
    {
        
    }

    void Begin()
    {
        if (!isStarted)
        {
            CamStart.SetActive(false);
            CamCombat.SetActive(true);
            isStarted = true;
        }
    }

    public void Tap(int _id)
    {
        Debug.Log(_id);
        if (isGameOver)
        {
            return;
        }

        Begin();
        Rigidbody player = _id == 1 ? Player1 : Player2;
        BabyAnimator babyAnimator = _id == 1 ? BabyAnimator1 : BabyAnimator2;
        babyAnimator.SetStarted();
        babyAnimator.SetIsMoving(true);
        // player.MovePosition(player.transform.position + (player.transform.forward * MoveAmountMultiplier));
        player.AddForce(player.transform.forward * MoveAmountMultiplier, ForceMode.VelocityChange);
    }

    public void DisablePhysics()
    {
        isGameOver = true;
        Player1.isKinematic = true;
        Player2.isKinematic = true;
    }

    public void CheckPlayerLoss(Rigidbody _player)
    {
        if (isGameOver)
        {
            return;
        }

        if (_player.gameObject == Player1.gameObject)
        {
            DisablePhysics();
            BabyAnimator1.SetLose();
            BabyAnimator2.SetWon();
        }
        
        if (_player.gameObject == Player2.gameObject)
        {
            DisablePhysics();
            BabyAnimator2.SetLose();
            BabyAnimator1.SetWon();
        }
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
