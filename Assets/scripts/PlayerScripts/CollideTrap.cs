using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideTrap : MonoBehaviour
{
    private Animator player_animation;
    private Rigidbody2D rigid_player;
    [SerializeField] private AudioSource dieSound;
    void Start()
    {
        player_animation = GetComponent<Animator>();
        rigid_player = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D call_object) {
        if (call_object.gameObject.CompareTag("Trap")){
            Die();
        }
    }

    private void Die(){
        dieSound.Play();
        rigid_player.bodyType = RigidbodyType2D.Static;
        player_animation.SetBool("death",true);

    }

    private void restart_level(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void respawn_player(){

    }
}
