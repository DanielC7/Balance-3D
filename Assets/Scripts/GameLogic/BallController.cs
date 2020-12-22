using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float speed = 30;
    private Rigidbody rb;
    private Transform player;
    [SerializeField] private InGameUI inGameUI;

    void Start() {
        rb = GetComponent<Rigidbody>();
        player = transform;
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement*speed);
        
        if(player.transform.position.y <= -5) {
            FinishGame(false);
            SceneManager.LoadScene("GameScene");
        }
    }
    void OnCollisionEnter(Collision col) {
        if(col.gameObject.name == "FinishPoint") {
            FinishGame(true);
            SceneManager.LoadScene("FinishScene");
        }
    }

    void FinishGame(bool didReachFinish) {
        inGameUI.GameOver(didReachFinish);
    }
}