using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class HoseMove : MonoBehaviour
{
   public LayerMask layer;

    private void Start() {
        ObjectMove();
    }

    

    private void Update() {
        ObjectMove();
    
    if(UnityEngine.Input.GetMouseButtonDown(0))
    {
       gameObject.GetComponent<AutoUnitCreate>().enabled = true;
       gameObject.name = "HouseCreatePlayer";
        Destroy(gameObject.GetComponent<HoseMove>());
    }
    
    if(UnityEngine.Input.GetKey(KeyCode.X))
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 100f);
    }else if(UnityEngine.Input.GetKey(KeyCode.Z))
    {
        transform.Rotate(Vector3.up * Time.deltaTime * -100f);
    }
    }
    private void ObjectMove()
    {
        Ray ray = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);

        RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 1000f, layer))
        {
             transform.position = hit.point;
        }
    }
}
