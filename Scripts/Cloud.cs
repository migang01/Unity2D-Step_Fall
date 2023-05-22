using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private void Update()
    {
        transform.position += Vector3.down * 1 * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Remove"))
        {
            Destroy(this.gameObject);
        }
    }
}
