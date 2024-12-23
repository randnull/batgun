using UnityEngine;

public class Enemy: MonoBehaviour
{
    public Transform player;

	public int damageSize = 10;
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

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag("Player")) {
			Stats playerStats = collision.gameObject.GetComponent<Stats>();
			playerStats.TakeDamage(damageSize);
		}
	}
}
