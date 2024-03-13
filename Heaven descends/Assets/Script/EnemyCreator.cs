using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public Path[] listPath;

    public GameObject Enemy;
    public float spamRate = 2.0f;

    float duration = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(duration > 1.0f/spamRate)
        {
            CreateEnemy();
            duration = 0.0f;
        }
        duration += Time.deltaTime;
    }
    void CreateEnemy()
    {
        int indexPath = Random.Range(0, listPath.Length);
        GameObject EnemyClone = (GameObject) GameObject.Instantiate(Enemy, listPath[indexPath].listPoints[0].position, Quaternion.identity);
        EnemyClone.GetComponent<EnemyBehavior>().movingPath = listPath[indexPath];
    }
}
