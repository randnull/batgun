using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;  
    
    void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        
        direction.y = 0f;

        transform.position += direction * speed * Time.deltaTime;

        if (direction != Vector3.zero)
        {
            Quaternion RotationToPlayer = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, RotationToPlayer, 360 * Time.deltaTime);
        }
    }
}