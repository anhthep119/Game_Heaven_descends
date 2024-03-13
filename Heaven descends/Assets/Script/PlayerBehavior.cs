using System.Collections;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public GameObject bullet;
    public float planeSpeed = 3f;
    public float fireRate = 0.1f; //

    private Coroutine firingCoroutine; //

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

    void Start()
    {
        
        firingCoroutine = StartCoroutine(FireBulletRepeatedly());
    }

    void Update()
    {
       
        MovePlane();

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBullet();
        }
    }

    void MovePlane()
    {
       
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * planeSpeed * Time.deltaTime);
    }

    IEnumerator FireBulletRepeatedly()
    {
        while (true)
        {
            FireBullet(); 
            yield return new WaitForSeconds(fireRate); 
        }
    }

    public void FireBullet()
    {
        GameObject bulletClone = Instantiate(bullet);
        Vector3 position = new Vector3(transform.position.x, transform.position.y + sizeOfSprite.y / 2.0f - bulletClone.GetComponent<BulletBehavior>().sizeOfSprite.y / 2.0f, 0.0f);
        bulletClone.transform.position = position;
    }
}
