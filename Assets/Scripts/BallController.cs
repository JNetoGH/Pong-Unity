using System;
using UnityEditor.UI;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour {
    
    private Rigidbody _rgb;
    
    private float Speed = 800f;
    private const float MinXAxisNorm = 0.4f;
    
    private const float LaunchThrust = 60;
    private const float FirstLaunchThrust = 30;
    private const float ReviveThrust = 10;
    private const float JumpThrust = 20;

    private void Start() {
        this._rgb = GetComponent<Rigidbody>();
        
        Vector3 initialDir = new Vector3();
        initialDir.x = Random.Range(0, 2) == 0 ? -1 : 1;
        initialDir.z = Random.Range(0, 2) == 0 ? -1 : 1;
        this.Launch(initialDir.normalized, FirstLaunchThrust);
    }
    
    private void FixedUpdate() {

        Vector3 dir = this._rgb.velocity.normalized;
        
        // avoinding ball to get stuck
        if (dir.x < 0 && dir.x > - MinXAxisNorm) {
            dir.x = - MinXAxisNorm;
            dir = dir.normalized;
        }
        else if (dir.x > 0 && dir.x < MinXAxisNorm) {
            dir.x = MinXAxisNorm;
            dir = dir.normalized;
        }
        this._rgb.velocity = this.Speed * Time.deltaTime * dir;
        
        // sometimes the launch doesnt work, and the ball stops on the floor, so I just give it another push
        if (this._rgb.velocity == Vector3.zero) 
            this.Launch(this._rgb.velocity.normalized, ReviveThrust);
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
        
        // Wall
        else if (collision.gameObject.tag.Equals("Wall")) {
            Debug.Log("Wall hit");
        }
        
        // Player
        else if (collision.gameObject.tag.Equals("Player")) {
            Debug.Log("Player hit");
        }

    }

    private void Launch(Vector3 direction, float thrust) {
        this._rgb.velocity = direction * thrust;
        //this._rgb.AddForce(Vector3.up * JumpThrust);
    }
    
}
