using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;       // Tốc độ di chuyển của kẻ địch
    public float separationDistance = 1f; // Khoảng cách tối thiểu giữa các kẻ địch
    private Transform player;           // Tham chiếu đến vị trí của người chơi
    public GameObject Explosion;

    void Start()
    {
        // Tìm đối tượng người chơi theo tag "Player" và lấy vị trí (Transform) của nó
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("Không tìm thấy đối tượng Player trong scene!");
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Di chuyển về phía người chơi
            Vector3 moveDirection = (player.position - transform.position).normalized;
            Vector3 separation = CalculateSeparation();
            Vector3 newPosition = transform.position + (moveDirection + separation) * moveSpeed * Time.deltaTime;
            transform.position = newPosition;
        }
    }

    Vector3 CalculateSeparation()
    {
        Vector3 separationForce = Vector3.zero;
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        foreach (Enemy otherEnemy in enemies)
        {
            if (otherEnemy != this)
            {
                float distance = Vector3.Distance(transform.position, otherEnemy.transform.position);
                if (distance < separationDistance)
                {
                    // Tạo lực đẩy ra xa khỏi kẻ địch khác
                    Vector3 directionAway = (transform.position - otherEnemy.transform.position).normalized;
                    separationForce += directionAway / distance; // Lực tỉ lệ nghịch với khoảng cách
                }
            }
        }

        return separationForce;
    }

    public void Die()
    {
        if (Explosion != null)
        {
            Instantiate(Explosion, transform.position, Quaternion.identity); // Tạo hiệu ứng nổ
        }
        Destroy(gameObject); // Phá hủy đối tượng
    }
}
