using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource finishSound;
    private bool levelCompleted = false;
    private void Start()
    {
        // finishSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player") && !levelCompleted){
            finishSound.Play();
            levelCompleted = true;
            Debug.Log(other.gameObject.name + " is ");
            //wait before going to next level
            Invoke("OnCompleteLevel", 3f);
            OnCompleteLevel();
        }
    }
    private void OnCompleteLevel(){
        if(SceneManager.GetActiveScene().buildIndex == 2){
            SceneManager.LoadScene(0);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
