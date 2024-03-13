using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private float hp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            BulletBehavior bullet = collision.GetComponent<BulletBehavior>();
            if(bullet != null)
            {
                hp -= bullet.getDameBullet();
            }
            if(hp<= 0)
            {
                Destroy(gameObject);
                ScoreController.instance.GetScore(score);
            }
        }
    }
    public void setHp(float hpCurrent)
    {
        this.hp = hpCurrent;
    }
}
