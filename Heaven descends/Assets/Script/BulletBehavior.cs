using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private float dameBullet;
    [HideInInspector]
    public Vector3 sizeOfSprite
       
    {
        get
        {
            float pixelPerUnit = this.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
            Vector3 sizeOfSprite = new Vector3(this.GetComponent<SpriteRenderer>().sprite.rect.width, this.GetComponent<SpriteRenderer>().sprite.rect.height, 0.0f);
            sizeOfSprite = new Vector3(sizeOfSprite.x / pixelPerUnit * this.transform.localScale.x, sizeOfSprite.y / pixelPerUnit * this.transform.localScale.y, 0.0f);
            return sizeOfSprite;
        }
    }
    public float bulletSpeed = 4.0f;
    private float limitScreen;
    // Start is called before the first frame update
    void Start()
    {
        
        limitScreen = FindObjectOfType<Background>().maxPoint.y + sizeOfSprite.y / 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y >= limitScreen)
        {
            GameObject.Destroy(this.gameObject);

        }
        else
        {
            this.transform.position += new Vector3(0.0f, bulletSpeed * Time.deltaTime, 0.0f);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
           Destroy(gameObject);

        }
    }
    public float getDameBullet()
    {
        return dameBullet;
    }
}
