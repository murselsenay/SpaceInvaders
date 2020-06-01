using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject restartButtonPrefab;
    public bool canDestroyed;

    public static ShipScript instance;

    void Start()
    {
        instance = this;
    }

   
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }
    }

    public void Move()
    {
        Vector3 mouseXPosition = new Vector3(Input.mousePosition.x, 0, 0);
        mouseXPosition = Camera.main.ScreenToWorldPoint(mouseXPosition);
        transform.position = new Vector3(mouseXPosition.x, transform.position.y, transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="Enemy")
        {
            GameObject restartButton = Instantiate(restartButtonPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            restartButton.transform.SetParent(GameObject.Find("Canvas").transform, false);
            GameObject.Find("FinalScoreText").GetComponent<Text>().text = GameManager.instance.score.ToString();
            canDestroyed = true;
            Destroy(gameObject);
        }
    }
}
