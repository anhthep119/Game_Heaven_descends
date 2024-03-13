using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [HideInInspector]
    public Vector3 maxPoint;
    public Vector3 minPoint;

    // Start is called before the first frame update
    void Start()
    {
        maxPoint = Camera.main.ScreenToWorldPoint(new Vector3 (Camera.main.pixelWidth,Camera.main.pixelHeight,0.0f));
        minPoint = Camera.main.ScreenToWorldPoint(Vector3.zero);
        float widthScreen = maxPoint.x - minPoint.x;
        float heightScreen = maxPoint.y - minPoint.y;

       float pixelPerUnit = this.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
       Vector3 sizeOfSprite = new Vector3( this.GetComponent<SpriteRenderer>().sprite.rect.width, this.GetComponent<SpriteRenderer>().sprite.rect.height, 0.0f);
       Vector3 sizeOfBG = new Vector3(widthScreen / (sizeOfSprite.x / pixelPerUnit), heightScreen / (sizeOfSprite.y / pixelPerUnit),0.0f );
       this.transform.localScale = sizeOfBG;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
