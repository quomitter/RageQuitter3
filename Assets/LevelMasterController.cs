using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMasterController : MonoBehaviour
{
    [SerializeField] CanvasGroup anyKeyCanvasGroup;
    [SerializeField] CanvasGroup titleScreenCanvasGroup; 
    [SerializeField] GameObject AnyKeyCanvas; 
    [SerializeField] Image masterPanel; 

    [SerializeField] GameObject levelOne;
    [SerializeField] GameObject levelTwo;
    [SerializeField] GameObject player;

    [SerializeField] bool keyHasBeenPressed;
    private bool isOnTitleScreen;
    private bool isOnAnyKeyScreen;

    // Start is called before the first frame update
    void Start()
    {
        isOnTitleScreen = true;
        isOnAnyKeyScreen = false;
        keyHasBeenPressed = false;
        AnyKeyCanvas = GameObject.Find("AnyKeyCanvas");
        anyKeyCanvasGroup = GameObject.Find("AnyKeyCanvas").GetComponent<CanvasGroup>();
        //titleScreenCanvasGroup = GameObject.Find("TitleScreenCanvas").GetComponent<CanvasGroup>();
        levelOne = GameObject.Find("LevelOne");
        levelTwo = GameObject.Find("LevelTwo");
        player = GameObject.Find("Player");

        AnyKeyCanvas.SetActive(true);
        levelOne.SetActive(true);
        levelTwo.SetActive(true);
        levelTwo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown){
            keyHasBeenPressed = true;
        }

        if(keyHasBeenPressed && anyKeyCanvasGroup.alpha > 0){
                anyKeyCanvasGroup.alpha -= Time.deltaTime;
                if(anyKeyCanvasGroup.alpha <= 0)
                    keyHasBeenPressed = false; 

        }
    }
}
