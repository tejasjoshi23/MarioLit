using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectable_collected : MonoBehaviour
{
    [SerializeField] private float destroy_delay = 0.5f;
    [SerializeField] private Text score_bar;
    [SerializeField] private AudioSource collectSoundEffect;

    private int Score=0;
    void Start(){
        score_bar.text = "Score : 0";
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Cherry")){
            collectSoundEffect.Play();
            collision.GetComponent<Animator>().SetBool("isCollected",true);
            Destroy(collision.gameObject,destroy_delay); //Destroy(gameObject,Delay before destroying the object)
            itemCollected(1);
        }
    }
    private void itemCollected(int i){
        Score += i;
        updateScoreBar();
    }

    private void updateScoreBar(){
        score_bar.text = "Score : " + Score;
    }
}
