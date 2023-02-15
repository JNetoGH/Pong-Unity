using System;
using Unity.VisualScripting;
using UnityEngine;


public class PlayersController : MonoBehaviour {
    
    private const float MoveSpeed = 18f;
    private Rigidbody _rgb;
    private Vector3 _direction = new Vector3(0,0,0);

    private void Start() {
        this._rgb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        this._direction = GetDirection();
        this._rgb.velocity = new Vector3(0,0, this._direction.z * MoveSpeed);
    }

    private Vector3 GetDirection() {
        return this.name switch {
            "Player 1" when Input.GetKey(KeyCode.W) => new Vector3(0, 0, 1),
            "Player 1" when Input.GetKey(KeyCode.S) => new Vector3(0, 0, -1),
            "Player 2" when Input.GetKey(KeyCode.UpArrow) => new Vector3(0, 0, 1),
            "Player 2" when Input.GetKey(KeyCode.DownArrow) => new Vector3(0, 0, -1),
            _ => new Vector3(0, 0, 0)
        };
    } 
    
}
