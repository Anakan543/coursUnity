using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour
{
   public float rotateSpeed = 50.0f, speedMove = 50.0f, zoomMove = 600.0f;
   private float boost = 0.0f;
   
   private void Update() {
    float ver = Input.GetAxis("Vertical");
    float hor = Input.GetAxis("Horizontal");

    float rotate = 0.0f;
    if (Input.GetKey(KeyCode.Q)){
        rotate = -1.0f;
    } else if(Input.GetKey(KeyCode.E)){
        rotate = 1.0f;
    }

    boost = Input.GetKey(KeyCode.LeftShift) ? 2.5f : 1.0f;

    transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * rotate * boost, Space.World);
    transform.Translate(new Vector3(hor, 0, ver) * Time.deltaTime * speedMove * boost, Space.Self);
    
    transform.position += transform.up * Time.deltaTime * zoomMove * boost * Input.GetAxis("Mouse ScrollWheel");
    transform.position = new Vector3(Mathf.Clamp(transform.position.x, 76, 540), Mathf.Clamp(transform.position.y, 20, 200),Mathf.Clamp(transform.position.z, 60, 550));
   }
}
