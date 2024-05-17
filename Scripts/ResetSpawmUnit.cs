using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSpawmUnit : MonoBehaviour
{
   public GameObject House;
   
   public void ResetSpawn(){
    AutoUnitCreate game = House.GetComponent<AutoUnitCreate>();
   }
}
