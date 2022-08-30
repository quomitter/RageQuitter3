using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelMove : MonoBehaviour
{
    private Image panelImage;
    private float scrollSpeed = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        panelImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = panelImage.material.GetTextureOffset("_MainTex");
        offset.y += Time.deltaTime * scrollSpeed;
        offset.x += Time.deltaTime * scrollSpeed; 

        panelImage.material.SetTextureOffset("_MainTex", offset);
    }
}
