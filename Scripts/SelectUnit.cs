using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.AI;

public class SelectUnit : MonoBehaviour
{
    public GameObject cube;
    public LayerMask layer;
    public LayerMask layerUnits;
    
    public List<GameObject> units;
    private Camera _camera;
    private RaycastHit _hit;

    private GameObject _cubeSelection;
    private void Awake() {
        _camera = GetComponent<Camera>();
    }
    private void Update() {
        if(Input.GetMouseButton(1) && units.Count > 0) {
              Ray ray = _camera.ScreenPointToRay(UnityEngine.Input.mousePosition);

               if(Physics.Raycast(ray, out RaycastHit hitsMove, 1000f, layer))
                  foreach(var item in units)
                    item.GetComponent<NavMeshAgent>().SetDestination(hitsMove.point);    
        }
        if(Input.GetMouseButtonDown(0)) {
            foreach(var item in units)
                if(item != null)
                    item.transform.GetChild(0).gameObject.SetActive(false);
            units.Clear();
            Ray ray =_camera.ScreenPointToRay(UnityEngine.Input.mousePosition);
               if(Physics.Raycast(ray, out _hit, 1000f, layer)) 
                   _cubeSelection = Instantiate(cube, new Vector3(_hit.point.x, 6, _hit.point.z), Quaternion.identity);
         }
        if(_cubeSelection){
              Ray ray = _camera.ScreenPointToRay(UnityEngine.Input.mousePosition);

               if(Physics.Raycast(ray, out RaycastHit newHits, 1000f, layer)){
                    float zScale = (_hit.point.z - newHits.point.z) * -1;
                    float xScale = (_hit.point.x - newHits.point.x);

                   if(xScale < 0.0f && zScale < 0.0f){
                            _cubeSelection.transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
                    }
                    else if(xScale < 0.0f){
                            _cubeSelection.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 180));
                    }else if(zScale < 0.0f){
                            _cubeSelection.transform.localRotation = Quaternion.Euler(new Vector3(180, 0, 0));
                    }
                    
                    else{
                         _cubeSelection.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    }

                    _cubeSelection.transform.localScale = new Vector3(Math.Abs(xScale), 1, Math.Abs(zScale));
                    }
        }
        if(Input.GetMouseButtonUp(0) && _cubeSelection){
            RaycastHit [] hits = Physics.BoxCastAll(_cubeSelection.transform.position,
                _cubeSelection.transform.localScale,
                Vector3.up, Quaternion.identity,
                0,  layerUnits);
            foreach (var item in hits)
            {
                if(item.collider.CompareTag("Enemy")) {
                    continue;
                }else{
                units.Add(item.transform.gameObject);
                item.transform.GetChild(0).gameObject.SetActive(true);
                }
            }
            Destroy(_cubeSelection);
        }
}
}