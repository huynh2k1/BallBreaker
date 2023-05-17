using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // BallSpawner ballSpawner;
    private Vector2 startPosition;
    private Rigidbody2D rb;
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start() {

        // rb.velocity = direction*speed;
        startPosition = BallSpawner.Instance.transform.position;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.CompareTag("Wall"))
        {
            Debug.Log("1111111");
            StartCoroutine(moveToPosition(transform, BallSpawner.Instance.transform.position, 0.2f));
            
            // MoveToStartPosition();
            // rb.simulated = false;
            
        }
        if(other.collider.CompareTag("Brick"))
        {
            other.collider.GetComponent<Box>().ReduceHp(1);
            GUIManager.Instance.scoreStart++;
            GUIManager.Instance.score.text = "SCORE: " + GUIManager.Instance.scoreStart.ToString();
        }
    }
    public IEnumerator moveToPosition(Transform transform, Vector3 position, float timeToMove)
    {
        var currentPos = transform.position; // 
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(currentPos, position, t);
            yield return null;
        }
        BallSpawner.Instance.currentBall += 1;
        BallSpawner.Instance.ballNum.text = BallSpawner.Instance.currentBall.ToString();
        Destroy(gameObject);
    }
}

