using UnityEngine;
using System.Collections;

public class EnemyFormationController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int rows = 4;
    public int columns = 4;
    public float spacing = 1f;
    public float moveSpeed = 1f;

    void Start()
    {
        float screenWidth = Camera.main.aspect * Camera.main.orthographicSize * 2;
        float screenHeight = Camera.main.orthographicSize * 2;

        float startX = -screenWidth / 9 - spacing;
        float startY = screenHeight / 3 + spacing;

        
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Vector3 spawnPosition = new Vector3(startX, startY, 0);
                GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                newEnemy.transform.SetParent(transform);

                Vector3 targetPosition = new Vector3(startX + col * spacing, startY - row * spacing, 0);
                MoveEnemy(newEnemy.transform, targetPosition);
            }
        }

        
        Invoke("ChangeToDiamondFormation", 5f);
    }

    
    void MoveEnemy(Transform enemyTransform, Vector3 targetPosition)
    {
        StartCoroutine(MoveCoroutine(enemyTransform, targetPosition));
    }

    IEnumerator MoveCoroutine(Transform enemyTransform, Vector3 targetPosition)
    {
        while (Vector3.Distance(enemyTransform.position, targetPosition) > 0.01f)
        {
            enemyTransform.position = Vector3.MoveTowards(enemyTransform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        enemyTransform.position = targetPosition;
    }

    
    void ChangeToDiamondFormation()
    {
        float screenWidth = Camera.main.aspect * Camera.main.orthographicSize * 2;
        float screenHeight = Camera.main.orthographicSize * 2;

        float startX = -screenWidth / 9 - spacing;
        float startY = screenHeight / 3 + spacing;

        
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                float offsetX = col * spacing;
                float offsetY = row * spacing;

                
                Vector3 diamondPosition = new Vector3(startX + offsetX, startY - offsetY, 0);

                
                GameObject enemy = transform.GetChild(row * columns + col).gameObject;
                MoveEnemy(enemy.transform, diamondPosition);
            }
        }
    }
}
