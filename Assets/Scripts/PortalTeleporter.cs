using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public Transform player;
    public Transform reciever;

    private bool playerIsOverlapping = false;

    void Start(){
        //Debug.Log(player.position);
        //Debug.Log(reciever.position);
    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(playerIsOverlapping);
        if (playerIsOverlapping){
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);
            
            //Debug.Log(player.position);
            // if this is true; player is moved across the portal
            
            if (dotProduct < 0f){
                // teleport 
                float rotationDiff = Quaternion.Angle(transform.rotation, reciever.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = reciever.position + positionOffset;
                //Debug.Log(player.position);
                //Debug.Log(reciever.position);
                playerIsOverlapping = false;
            }
        }
        
    }

    void OnTriggerEnter (Collider coll){
        if (coll.tag == "Player"){
            playerIsOverlapping = true;
            //player.position =reciever.position;
            //Debug.Log("went thru");
        }
    }

    void OnTriggerExit (Collider coll){
        if (coll.tag == "Player"){
            playerIsOverlapping = false;
            //player.transform.position = reciever.transform.position;
            //Debug.Log(player.position);
        }
    }
}
