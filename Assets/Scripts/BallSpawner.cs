using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallSpawner : MonoBehaviour
{
    public static BallSpawner Instance;
    private RaycastHit2D ray;
    [SerializeField] private LayerMask layerMask;
    public Dots dotLine;
    private float angle;
    [SerializeField] Vector2 minMaxAngle;
    public int ballSum;
    public int currentBall;
    // public GameObject ballPrefab;
    public Ball ballPrefab;
    public float force;
    public TMP_Text ballNum;
    private Game game;

    private void Awake() {
        if(Instance != null)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
    }
    private void Start() {
        game = FindObjectOfType<Game>();
        currentBall = ballSum;
        ballNum.text = "x" + currentBall.ToString();
     }
    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            ray = Physics2D.Raycast(transform.position, transform.up, 15f, layerMask);
            Vector2 reflactPos = Vector2.Reflect(new Vector3(ray.point.x, ray.point.y) - transform.position, ray.normal);

            if(angle >= minMaxAngle.x && angle <= minMaxAngle.y)
            {
                dotLine.DrawDottedLine(transform.position, ray.point);
                dotLine.DrawDottedLine(ray.point, ray.point + reflactPos.normalized * 3f);
            }
            DotLineRotate();
        }
    }
    private void DotLineRotate()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.AngleAxis(angle, transform.forward);
    }
    IEnumerator BallShoot()
    {
        int temp = ballSum;
        for(int i = 0; i < temp; i++) {
            Ball ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            ball.GetComponent<Rigidbody2D>().AddForce(transform.up * force);
            // Debug.Log(ball.startPosition);
            yield return new WaitForSeconds(0.08f);
            currentBall--;
            ballNum.text = "x" + currentBall.ToString();
        }
        
        while(currentBall != ballSum)
        {
            yield return null;
        }
        Debug.Log("End of turn");
        game.EndTurn();
    }
    private void FixedUpdate() {
        if(Input.GetMouseButtonUp(0) && currentBall == ballSum)
        {
            StartCoroutine(BallShoot());
        }
    }
    
}
