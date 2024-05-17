using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBuildingForButtons : MonoBehaviour
{
   public GameObject building;

   public void PlaceObject(){
        Instantiate(building, Vector3.zero, Quaternion.identity);
   }
}
