using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformer : MonoBehaviour
{
    private int speed = 1;

    private void Update()
    {
        if(Score.score <= 50)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        
        if(Score.score > 50)
        {
            transform.position += Vector3.down * speed * 1.5f * Time.deltaTime;
        }

        if(Score.score > 100)
        {
            transform.position += Vector3.down * speed * 2 * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Remove"))
        {
            Destroy(this.gameObject);
        }

        
    }

}
