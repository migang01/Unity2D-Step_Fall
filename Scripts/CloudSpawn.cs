using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawn : MonoBehaviour
{
    public GameObject[] cloud;
    private float timer = 0f;
    private float maxTime = 1.5f;

    private void Start()
    {

        GameObject newCloud = Instantiate(cloud[Random.Range(0,2)]);
        newCloud.transform.position = transform.position + new Vector3(Random.Range(-3.5f, 4f), 0, 0);
        newCloud.transform.localScale *= Random.Range(0, 3);
    }
    private void Update()
    {
        if(timer > maxTime)
        {
            GameObject newCloud = Instantiate(cloud[Random.Range(0, 2)]);
            newCloud.transform.position = transform.position + new Vector3(Random.Range(-3.5f, 4f), 0, 0);
            newCloud.transform.localScale *= Random.Range(0, 3);
            timer = 0;
        }

        timer += Time.deltaTime;

    }    
}
