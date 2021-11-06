using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beaconCollider : MonoBehaviour
{
   
    void OnTriggerEnter(Collider col){
        Destroy(gameObject);
    }
}