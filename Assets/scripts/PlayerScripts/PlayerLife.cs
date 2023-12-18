using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLife : MonoBehaviour
{
private Animator anim;
private Rigidbody2D rb;
    [SerializeField] private AudioSource dieSound;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Trapp")){
Die();
        }
    }

    public void Die(){
        dieSound.Play();
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
    }
        public void Respawn(){
  SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
