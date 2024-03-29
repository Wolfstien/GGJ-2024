using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapController : MonoBehaviour
{
    public Rigidbody Player1, Player2;
    public BabyAnimator BabyAnimator1, BabyAnimator2;
    public float MoveAmountMultiplier = 0.1f;
    public bool isStarted = false;
    public bool isGameOver = false;

    public GameObject CamStart, CamCombat;

    int hitCooldownTime = -1;

    void Start()
    {
        Time.timeScale = 1;
        SoundManager.instance.PlayMusic("BattleTheme");
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

    void FixedUpdate() 
    {
        hitCooldownTime--;
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
        StartCoroutine(PlayEndSFX());
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
            GameManager.instance.Player2Score++;
            DisablePhysics();
            BabyAnimator1.SetLose();
            BabyAnimator2.SetWon();
        }
        
        if (_player.gameObject == Player2.gameObject)
        {
            GameManager.instance.Player1Score++;
            DisablePhysics();
            BabyAnimator2.SetLose();
            BabyAnimator1.SetWon();
        }
    }

    public void PlayHitSFX(string _value)
    {
        if (hitCooldownTime < 0)
        {
            hitCooldownTime = 2;
            SoundManager.instance.PlaySFX(_value);
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator PlayEndSFX()
    {
        InGameUI.instance.UpdateBottles();
        SoundManager.instance.PlaySFX("BabyScream");
        yield return new WaitForSeconds(1f);
        SoundManager.instance.PlaySFX("FallThud");
        yield return new WaitForSeconds(0.2f);
        SoundManager.instance.PlaySFX("BellMatchEnd");
        yield return new WaitForSeconds(0.7f);
        SoundManager.instance.PlaySFX("VictoryLaugh");
        yield return new WaitForSeconds(2f);

        if (GameManager.instance.Player1Score>=3 || GameManager.instance.Player2Score>=3)
        {
            InGameUI.instance.ShowWinner();
            Invoke("LoadMenu", 4f);
        }
        else
        {
            SceneManager.LoadScene("TapLevel");
        }

        yield return new WaitForSeconds(5f);
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
