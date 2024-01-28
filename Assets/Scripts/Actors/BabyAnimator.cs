using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyAnimator : MonoBehaviour
{
    public Animator Animator;

    public bool Started = false;
    public bool isMoving = false;
    public bool Lose = false;
    public bool Won = false;

    public void SetStarted()
    {
        Started = true;
        Animator.SetBool("Started", Started);
    }

    public void SetIsMoving(bool _state)
    {
        isMoving = _state;
        Animator.SetBool("isMoving", isMoving);
    }

    public void SetLose()
    {
        Debug.Log("lose", gameObject);
        Lose = true;
        Animator.SetBool("Lose", Lose);
    }

    public void SetWon()
    {
        Won = true;
        Animator.SetBool("Won", Won);
    }
}
