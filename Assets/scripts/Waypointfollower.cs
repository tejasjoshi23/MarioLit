using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypointfollower : MonoBehaviour
{
public GameObject[] way;
public GameObject Player;
public int currentwaypoint = 0;
private Rigidbody2D rb;
private float speed = 2f;
public float dir = 0f;

void Start(){
    rb = GetComponent<Rigidbody2D>();
}
    void Update()
    {
        if(Vector2.Distance(way[currentwaypoint].transform.position, transform.position) < .1f){
            currentwaypoint++;
                    if(currentwaypoint == 2){
            currentwaypoint = 0;
        }
        }

        
        if(currentwaypoint == 0){
dir = 1f;
        }else{
dir = -1f;
        }

        // rb.velocity = new Vector3(4*dir, 0);
       
     transform.position = Vector2.MoveTowards(transform.position, way[currentwaypoint].transform.position,Time.deltaTime*speed);
    }

    void ParentChange(){
       
    }
    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("OnCollisionEnter");
other.gameObject.transform.SetParent(transform);
    }
       void OnTriggerExit2D(Collider2D other){
        other.gameObject.transform.SetParent(null);
    }

    
}
