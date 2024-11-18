using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector2 diff =  Vector2.zero;

    private void Start()
    {
        Cursor.visible = false;
    }

    void OnMouseDown()
    {
        diff = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
    }

    void Update()
    { 
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - diff;
    
        if (Input.GetMouseButtonDown(0))
        {
            KillEnemy();
        }
    }

    void KillEnemy()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
        if (hit.collider != null && hit.collider.CompareTag("Enemy"))
        {
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null) 
            { 
                enemy.Die();            
            }
        }
    }
}
