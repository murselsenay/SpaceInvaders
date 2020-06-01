using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    float startPosition;
    bool switchDirection;
    public GameObject deathAnimPrefab;
    void Start()
    {
        startPosition = transform.position.x;
        StartCoroutine(MoveEnemyDown());
    }


    void Update()
    {
        MoveEnemy(0.3f,0.01f);
        if (ShipScript.instance.canDestroyed)
        {
            Destroy(gameObject);
        }
    }
    public void MoveEnemy(float distance, float moveSpeed)
    {
        if (transform.position.x < startPosition + distance && switchDirection)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed, transform.position.y);
        }
        else
        {
            switchDirection = false;
        }
        if (transform.position.x > startPosition && !switchDirection)
        {
            transform.position = new Vector2(transform.position.x - moveSpeed, transform.position.y);
        }
        else
        {
            switchDirection = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="Bullet")
        {
            Instantiate(deathAnimPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            GameManager.instance.score += 1;
            GameManager.instance.scoreText.text = GameManager.instance.score.ToString();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    public IEnumerator MoveEnemyDown()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.2f);
        }
        
    }
}
