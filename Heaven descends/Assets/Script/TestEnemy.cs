using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 5f; 

    private Vector3[] targetPositions; 
    private int currentTargetIndex = 0; 

    void Start()
    {
        
        InitializeTargetPositions();
    }

    void Update()
    {
        
        if (currentTargetIndex >= targetPositions.Length)
        {
            Destroy(gameObject);
            return;
        }

        
        transform.position = Vector3.MoveTowards(transform.position, targetPositions[currentTargetIndex], moveSpeed * Time.deltaTime);

        
        if (Vector3.Distance(transform.position, targetPositions[currentTargetIndex]) < 0.1f)
        {
            currentTargetIndex++;
        }
    }

   
    void InitializeTargetPositions()
    {
        
        targetPositions = new Vector3[16];
        int index = 0;
        for (int row = 0; row < 4; row++)
        {
            for (int col = 0; col < 4; col++)
            {
                targetPositions[index] = new Vector3(col, 0, row); 
                index++;
            }
        }
    }
}
