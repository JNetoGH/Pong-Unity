using System;
using UnityEditor.UI;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour {
    
    private Rigidbody _rgb;
    private Vector3 _direction = new Vector3(-1,0,0);
    private const float ReviveThrust = 10;
    private const float LaunchThrust = 60;
    private const float FirstLaunchThrust = 30;
    private const float JumpThrust = 20;

    private void Start() {
        this._rgb = GetComponent<Rigidbody>();
        this._direction.x = Random.Range(0, 2) == 0 ? -1 : 1;
        this._direction.z = Random.Range(0, 2) == 0 ? -1 : 1;
        this.Launch(FirstLaunchThrust);
    }

    private void OnCollisionEnter(Collision collision) {
        
        // Score Zone
        if (collision.gameObject.tag.Equals("Score Zone")) {
            if (collision.gameObject.name.Equals("Left Wall"))
                ScoreController.PlayerTwoScore++;
            else if (collision.gameObject.name.Equals("Right Wall"))
                ScoreController.PlayerOneScore++;
            Destroy(this.gameObject);
        }
        
        // Wall: simply updates the direction
        else if (collision.gameObject.tag.Equals("Wall")) {
            Debug.Log("Wall hit");
            this._direction.z *= -1;
         
        }
        
        // Player
        else if (collision.gameObject.tag.Equals("Player")) {
            Debug.Log("Player hit");
            this._direction.x *= -1;
            this.Launch(LaunchThrust);
        }

    }
    
    // sometimes the launch doesnt work, and the ball stops on the floor,
    // so I just give it another push
    private void Update() {
        if (this._rgb.velocity == Vector3.zero) 
            this.Launch(ReviveThrust);
    }
    
    
    private void Launch(float thrust) {
        _direction.Normalize();
        this._rgb.velocity = _direction * thrust;
        this._rgb.AddForce(Vector3.up * JumpThrust);
    }
    
}
