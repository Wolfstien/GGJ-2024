using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    public Rigidbody Player1, Player2;
    public float RotationSlerp = 0.1f;
    public float MoveForceMultiplier = 20f;

    Vector3 Player1Direction3D, Player2Direction3D;

    void Start()
    {
        
    }

    void FixedUpdate() 
    {
        Player1.rotation = Quaternion.Slerp(Player1.rotation, Quaternion.Euler(0, Player1.transform.eulerAngles.y, 0), RotationSlerp);
        Player2.rotation = Quaternion.Slerp(Player2.rotation, Quaternion.Euler(0, Player2.transform.eulerAngles.y, 0), RotationSlerp);

        if (Player1Direction3D.magnitude > 0.1f)
        {
            Player1.AddForce(Player1Direction3D * MoveForceMultiplier, ForceMode.Force);
            // Player1.AddForce(Player1Direction3D * MoveForceMultiplier/5, ForceMode.VelocityChange);
            Player1.rotation = Quaternion.Slerp(Player1.rotation, Quaternion.LookRotation(Player1.velocity, Vector3.up), RotationSlerp);
        }
        if (Player2Direction3D.magnitude > 0.1f)
        {
            Player2.AddForce(Player2Direction3D * MoveForceMultiplier, ForceMode.Force);
            // Player2.AddForce(Player2Direction3D * MoveForceMultiplier/5, ForceMode.VelocityChange);
            Player2.rotation = Quaternion.Slerp(Player2.rotation, Quaternion.LookRotation(Player2.velocity, Vector3.up), RotationSlerp);
        }
    }

    public void PlayerMove1(Vector2 _direction)
    {
        Player1Direction3D = new Vector3(_direction.x, 0, _direction.y);
    }

    public void PlayerMove2(Vector2 _direction)
    {
        Player2Direction3D = new Vector3(_direction.x, 0, _direction.y);
    }

    void OnEnable() 
    {
        InputManager.Joystick1 += PlayerMove1;
        InputManager.Joystick2 += PlayerMove2;
    }

    void OnDisable() 
    {
        InputManager.Joystick1 -= PlayerMove1;
        InputManager.Joystick2 -= PlayerMove2;
    }
}
