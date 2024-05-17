using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarAtack : MonoBehaviour
{
   [NonSerialized] public int _health = 100;
   public float radius = 70f;

   public GameObject bullet;

   private Coroutine _coroutine;
   private void Update() {
        DetectUnit();
   }
   private void DetectUnit()
   {
    Collider[] UnitCollidrs =  Physics.OverlapSphere(transform.position, radius);

    if(UnitCollidrs.Length == 0 && _coroutine != null)
    {
        StopCoroutine(_coroutine);
        _coroutine = null;

        if(gameObject.CompareTag("Enemy"))
            GetComponent<NavMeshAgent>().SetDestination(gameObject.transform.position);
    }

    foreach (var el in UnitCollidrs){
        if ((gameObject.CompareTag("Player") && el.gameObject.CompareTag("Enemy"))|| 
        (gameObject.CompareTag("Enemy") && el.gameObject.CompareTag("Player")))
        {

            if(gameObject.CompareTag("Enemy")){
                GetComponent<NavMeshAgent>().SetDestination(el.transform.position);
            }

            if(_coroutine == null){
                _coroutine = StartCoroutine(StartAttack(el));
            }

        }
    }
   }

   IEnumerator StartAttack(Collider position){
      GameObject obj = Instantiate(bullet,transform.GetChild(1).position,  Quaternion.identity);
      obj.GetComponent<BulletMove>().position = position.transform.position;
      yield return new WaitForSeconds(2);
      StopCoroutine(_coroutine);
      _coroutine = null;
   }
}
