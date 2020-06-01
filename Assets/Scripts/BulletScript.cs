using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Rigidbody2D bulletBody;
    internal float moveSpeed = 2f;

    void Start()
    {
        bulletBody = gameObject.GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        bulletBody.AddForce(transform.up * moveSpeed, ForceMode2D.Impulse);

        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPosition.y > Screen.height)
            Destroy(gameObject);

    }
}
