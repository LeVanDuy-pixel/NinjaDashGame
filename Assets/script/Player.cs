using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{       
    public float jumpForce = 10f;
    bool isGround;
    bool canDash = true;
    bool isDashing = false;
    public float dashForce = 24f;
    public float dashTime = 0.2f;
    public float speed = 2f;
    public float distance;
    public AudioSource aus;
    public AudioClip jumpSound;
    public AudioClip dashSound;
    public AudioClip loseSound;
    GameController controller;
    [SerializeField] private Rigidbody2D playerRgb;
    [SerializeField] private TrailRenderer tr;
    [SerializeField] private GameObject start;
    /*private void Awake() {
       // playerRgb = GetComponent<Rigidbody2D>(); khi dùng [SerializeField] thì ko cần
       // tr = GetComponent<TrailRenderer>();
    }*/
    // Update is called once per frame
    private void Start() {
        controller = FindObjectOfType<GameController>();
    }
    private void Update()
    {
        if(isGround && transform.position.y <=-2.5f){
            comeBack();
        }
        
        if(isDashing){
            return;
        }
        if(Input.GetKeyDown(KeyCode.Space) && !isGround && canDash && check()==true ){
            StartCoroutine(Dash());
            if (aus && dashSound)
            {
                aus.PlayOneShot(dashSound);
            }
        }
        if(Input.GetKeyDown(KeyCode.Space) && isGround && check()==true){
            Jump();
            if(aus && jumpSound)
            {
                aus.PlayOneShot(jumpSound);
            }
            isGround = false;
        }
         
    }
    private void Jump(){
        playerRgb.velocity = Vector2.up * jumpForce;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground")){
            isGround = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Point")){
            controller.ScoreIncrement();
            controller.destroyWall();
        }
        if(other.CompareTag("Wall")){
            controller.setGameOver(true);
            if(aus && loseSound)
            {
                aus.PlayOneShot(loseSound);
            }
        }
    }
   
    private IEnumerator Dash(){
        canDash = false;
        isDashing = true;
        float originalGravity = playerRgb.gravityScale;
        playerRgb.gravityScale = 0f;
        playerRgb.velocity = new Vector2(transform.localScale.x * dashForce, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashTime);
        tr.emitting = false;
        playerRgb.gravityScale = originalGravity;
        isDashing = false;
        canDash=true;
    }
    private void comeBack(){
        distance = Vector2.Distance(start.transform.position,transform.position);
        Vector2 direction = start.transform.position - transform.position;
        transform.position = Vector2.MoveTowards(transform.position,start.transform.position,speed * Time.deltaTime);
    }
    public bool check(){
        return transform.position.x == start.transform.position.x;
    }
    public void Stop()
    {
        playerRgb.gravityScale = 0f;
        playerRgb.velocity = new Vector2(0,0);
    }
}
