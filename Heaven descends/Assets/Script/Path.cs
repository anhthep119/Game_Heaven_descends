using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Color starPointColor = Color.red;
    public Color pathColor = Color.white;
    public Color pointColor = Color.white;

    public List<Transform> listPoints = new List<Transform>();
    private void OnDrawGizmos()
    {
        Gizmos.color = starPointColor;
        listPoints.Clear();

        foreach (Transform t in this.GetComponentInChildren<Transform>())
        {
            if(t != this.transform)
            {
                listPoints.Add(t);
            }
        }
        for(int i =0; i < listPoints.Count; i++)
        {
            if (i > 0)
            {
                Gizmos.DrawLine(listPoints[i-1].position, listPoints[i].position);
                Gizmos.color = pointColor;
                Gizmos.DrawSphere(listPoints[i].position, 0.15f);
                Gizmos.color = pathColor;
            }
            else
            {
                Gizmos.DrawSphere(listPoints[i].position, 0.15f);
                Gizmos.color = pathColor;
            }
        }
    }
    
}
