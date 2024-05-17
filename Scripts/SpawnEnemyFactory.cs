using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyFactory : MonoBehaviour
{
    public GameObject enemy;

    public Transform [] position;

    private void Start() {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy(){
        

        for (int i = 0; i < position.Length; i++)
        {   
            yield return new WaitForSeconds(4f);
            GameObject spawn = Instantiate(enemy);
            Destroy(spawn.GetComponent<HoseMove>());
            spawn.transform.position = position[i].position;
            spawn.transform.rotation = Quaternion.Euler(new Vector3(0, UnityEngine.Random.Range(0, 270),0));
            spawn.GetComponent<AutoUnitCreate>().enabled = true;
            spawn.GetComponent<AutoUnitCreate>().isEnemy = true;
        }
    }
}
