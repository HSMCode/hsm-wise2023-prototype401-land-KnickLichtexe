using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSpawner : MonoBehaviour
{

    public GameObject Monkey;

    //6 Enemies
    public GameObject Elephant;
    public GameObject Hedgehog;
    public GameObject HornedLizard;
    public GameObject Rattlesnake;
    public GameObject Snake;
    public GameObject Cobra;
    public GameObject Boss;

    public static bool SpawnSomething = true;

    public static int EnemieType = 0;

    public static int enemiespawner = 0;

    // Start is called before the first frame update
    void Start()
    {
        SpawnSomething = true;
        enemiespawner = 0;
        EnemieType = 0;
        enemiespawner = 0;
        Instantiate(Monkey, new Vector3(-7, 0, 0), transform.rotation * Quaternion.Euler(0, 90f, 0));



    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnSomething == true && Input.GetKeyDown(KeyCode.Space))
        {
            SpawnAnything();
        }
    }

    void SpawnAnything()
    {
        enemiespawner = Random.Range(1, 7);


        if (enemiespawner == 1)
        {
            Instantiate(Elephant, new Vector3(7, 0, 0), transform.rotation * Quaternion.Euler(0, -90f, 0));
            EnemieType = 6;
        }
        if (enemiespawner == 2)
        {
            Instantiate(Hedgehog, new Vector3(7, 0, 0), transform.rotation * Quaternion.Euler(0, -90f, 0));
            EnemieType = 5;
        }
        if (enemiespawner == 3)
        {
            Instantiate(HornedLizard, new Vector3(7, 0, 0), transform.rotation * Quaternion.Euler(0, -90f, 0));
            EnemieType = 4;
        }
        if (enemiespawner == 4)
        {
            Instantiate(Rattlesnake, new Vector3(7, 0, 0), transform.rotation * Quaternion.Euler(0, -90f, 0));
            EnemieType = 2;
        }
        if (enemiespawner == 5)
        {
            Instantiate(Snake, new Vector3(7, 0, 0), transform.rotation * Quaternion.Euler(0, -90f, 0));
            EnemieType = 1;
        }
        if (enemiespawner == 6)
        {
            Instantiate(Cobra, new Vector3(7, 0, 0), transform.rotation * Quaternion.Euler(0, -90f, 0));
            EnemieType = 3;
        }
        if (enemiespawner == 7)
        {
            Instantiate(Boss, new Vector3(7, 0, 0), transform.rotation * Quaternion.Euler(0, -90f, 0));
            EnemieType = 7;
        }
        SpawnSomething = false;
    }


}
