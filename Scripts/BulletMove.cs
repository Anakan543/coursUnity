using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BulletMove : MonoBehaviour
{
   [NonSerialized]
   public Vector3 position;
   public float speed = 30f;
   public int damage = 20;
    
   private int _score;

    private void Update() {
        float step = Time.deltaTime * speed;
        transform.position = Vector3.MoveTowards(transform.position, position, step);
        
        if(transform.position == position){
            Destroy(gameObject);
        }
        Debug.Log(_score);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Enemy")|| other.CompareTag("Player")) 
        {
            CarAtack attack = other.GetComponent<CarAtack>();
            attack._health -= damage;

            Transform healthBar = other.transform.GetChild(0).transform;
            healthBar.localScale = new Vector3(healthBar.localScale.x + 0.5f, healthBar.localScale.y, healthBar.localScale.z);
            if(attack._health <= 0){
                Destroy(other.gameObject);
                _score++;
            }
           
        }
    }
}
