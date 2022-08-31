using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOneExit : MonoBehaviour
{
    [SerializeField] GameObject levelOne;
    [SerializeField] GameObject levelTwo;
    [SerializeField] GameObject player; 

    // Start is called before the first frame update
    void Start()
    {
        levelOne = GameObject.Find("LevelOne");
        // levelTwo = GameObject.Find("LevelTwo");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            levelOne.SetActive(false);
            levelTwo.SetActive(true);
            player.transform.position = new Vector2(-6, -2);


        }
            
    }
}
