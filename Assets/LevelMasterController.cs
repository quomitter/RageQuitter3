using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMasterController : MonoBehaviour
{
    [SerializeField] CanvasGroup masterCanvasGroup; 
    [SerializeField] GameObject masterCanvas; 
    [SerializeField] Image masterPanel; 

    [SerializeField] GameObject levelOne;
    [SerializeField] GameObject levelTwo;
    [SerializeField] GameObject player;

    [SerializeField] bool keyHasBeenPressed; 
    // Start is called before the first frame update
    void Start()
    {
        keyHasBeenPressed = false;
        masterCanvas = GameObject.Find("MasterCanvas");
        masterCanvasGroup = GameObject.Find("MasterCanvas").GetComponent<CanvasGroup>();
        masterPanel = GameObject.Find("MasterPanel").GetComponent<Image>();
        levelOne = GameObject.Find("LevelOne");
        levelTwo = GameObject.Find("LevelTwo");
        player = GameObject.Find("Player");

        masterCanvas.SetActive(true);
        levelOne.SetActive(true);
        levelTwo.SetActive(true);
        levelTwo.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.anyKeyDown || keyHasBeenPressed){
                float fadeTimer =+ Time.deltaTime;
                masterCanvasGroup.alpha -= Time.deltaTime;
                keyHasBeenPressed = true; 
                if(masterCanvasGroup.alpha <= 0)
                    keyHasBeenPressed = false; 

        }
    }
}
