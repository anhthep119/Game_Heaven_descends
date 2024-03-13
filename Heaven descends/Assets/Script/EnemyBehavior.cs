using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Path movingPath;
    public float movingSpeed;

    int currentPointIndex = 0;
    float minDistanceLimit = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float Distance = Vector3.Distance(new Vector3 (movingPath.listPoints[currentPointIndex].position.x, this.transform.position.y,0.0f), new Vector3(this.transform.position.x,this.transform.position.y,0.0f));

        this.transform.position += (movingPath.listPoints[currentPointIndex].position - this.transform.position).normalized * movingSpeed * Time.deltaTime;

        if(Distance < minDistanceLimit)
        {
            currentPointIndex++;
            if(currentPointIndex >= movingPath.listPoints.Count)
            {
                currentPointIndex = 0;
                //GameObject.Destroy(this.gameObject);
            }
        }
    }
}
