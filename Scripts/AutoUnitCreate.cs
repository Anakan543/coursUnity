using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class AutoUnitCreate : MonoBehaviour
{
   [NonSerialized]
    public bool isEnemy = false;
   
   public GameObject car;

   public float time = 8.5f;

   private void Start() {
    StartCoroutine(SpawnUnit());
   }

   IEnumerator SpawnUnit(){
    for(int i = 0; i < 5; i++){
        yield return new WaitForSeconds(time);
        Vector3 pos = new Vector3(transform.GetChild(0).position.x + UnityEngine.Random.Range(0f,10f), transform.GetChild(0).position.y, transform.GetChild(0).position.z + UnityEngine.Random.Range(0f,20f));
       
        if(isEnemy){
            car.tag = "Enemy";
        } else{
            car.tag = "Player";
        }
        Instantiate(car, pos, Quaternion.identity);
    }
    Destroy(gameObject);
   }
}
