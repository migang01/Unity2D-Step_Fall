using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerSpawner : MonoBehaviour
{
    public GameObject[] platformer;
    private float timer = 0f;
    private float maxTime = 2f;
    private int random;
    private int newRandom;

    private void Start()
    {
        random = Random.Range(0, 3);
        GameObject newPlatformer = Instantiate(platformer[random]);
        newPlatformer.transform.position = transform.position + new Vector3(Random.Range(-3.5f, 3f), 0, 0);

    }
    private void Update()
    {
        if (timer > maxTime)
        {
            newRandom = Random.Range(0, 3);
            if(newRandom == random)
            {
                newRandom -= 2;
                if(newRandom < 0)
                {
                    newRandom *= -1;
                }
            }
            GameObject newPlatformer = Instantiate(platformer[newRandom]);
            newPlatformer.transform.position = transform.position + new Vector3(Random.Range(-3.5f, 3f), 0, 0);
            random = newRandom;
            timer = 0;
        }

        timer += Time.deltaTime;

    }

}
