using UnityEngine;


public class BallInstantiator : MonoBehaviour {

    public GameObject ball = null;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(ball);
    }
}
