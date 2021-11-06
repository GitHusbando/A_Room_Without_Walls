using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treasureSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform spawn1; //
    public GameObject burger;

    private GameObject holder;
    
    public GameObject tree;

    void Start()
    {
        Instantiate(burger, spawn1.position, spawn1.rotation);
        Instantiate(tree, spawn1.position, spawn1.rotation);
       
    }

}
