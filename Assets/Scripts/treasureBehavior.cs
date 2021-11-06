using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class treasureBehavior : MonoBehaviour
{
    
    public static int score = 0;
    
    AudioSource source;
    public GameObject[] spawnLocations;
    public GameObject burger;
    public GameObject pumpkin;
    public GameObject tree;
    void Awake(){
        spawnLocations = GameObject.FindGameObjectsWithTag("SpawnPoint");
        
    }
    void Start(){
        burger = (GameObject)Resources.Load("burgerPrefab", typeof(GameObject));
        pumpkin = (GameObject)Resources.Load("pumpkinPrefab", typeof(GameObject));
        tree = (GameObject)Resources.Load("OptimizedTree", typeof(GameObject));
        source = GetComponent<AudioSource>();
        if (scoreCount.score > 0){
            // play pick up sound 
            source.Play(0);
        }
        
    }
    
 

    void OnTriggerEnter(Collider col){
        //source.Play();
         if(col.tag =="Player"){
            source.Play();
            Destroy(gameObject);
            scoreCount.score++;
            GameObject temp = burger;
            int spawn = Random.Range(0,spawnLocations.Length);
            print("This is the length of the array " + spawnLocations.Length);
            if(spawn%2 == 0){
                temp = pumpkin;
            }
            GameObject.Instantiate(temp, spawnLocations[spawn].transform.position, Quaternion.identity);
            GameObject.Instantiate(tree, spawnLocations[spawn].transform.position, Quaternion.identity);
            print("Spawned at index "+ spawn);
            
         }
         
    }
}
