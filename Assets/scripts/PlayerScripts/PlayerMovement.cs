using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    private Rigidbody2D player_body;
    private BoxCollider2D player_collider;
    private Animator  player_animation;

    private SpriteRenderer sprite;
    [SerializeField] public float jump_speed = 7;
    [SerializeField] public float move_speed = 7;

    [SerializeField] private LayerMask jumpableGround;

    private enum MovementState {idle,running,jumping,falling}
    [SerializeField] private AudioSource jumpSound;

    private MovementState state = MovementState.idle;

    public Vector3[] moves = new Vector3[3];
    
    private float dirX;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello Adventurer!!");
        player_body = GetComponent<Rigidbody2D>();
        player_animation = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        player_collider =GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        animatePlayer();
    }
    private void move()
    {
        dirX = Input.GetAxis("Horizontal");
        player_body.velocity = new Vector3(dirX * move_speed , player_body.velocity.y);
        if (Input.GetButtonDown("Jump") && IsGrounded()){
            jumpSound.Play();
            player_body.velocity = new Vector2(player_body.velocity.x, jump_speed);
        }
    }

    private void animatePlayer(){
        MovementState state;
        if(dirX < 0f ){
            sprite.flipX = true;
            state = MovementState.running;
        }
        else if(dirX > 0f){
            sprite.flipX = false;
            state = MovementState.running;
        }
        else {
            state = MovementState.idle;
        }

        if(player_body.velocity.y > 0.1f){
            state = MovementState.jumping;
        }
        else if(player_body.velocity.y < -0.1f){
            state = MovementState.falling;
        }
        player_animation.SetInteger("state", (int)state);
    }

    private bool IsGrounded(){
        return Physics2D.BoxCast(player_collider.bounds.center, player_collider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
