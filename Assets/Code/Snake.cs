using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{

    public float HP = 1f;
    public static int ATP = 1;
    public static int SpecialAttack = 0;
    public float AttackCooldown = 0f;
    public static bool EnemieDefeat = false;
    public static bool FightWon = false;
    

    // Start is called before the first frame update
    void Start()
    {
        HP = (SpawnerSpawner.EnemieType / 2) * (PlayerInteraction.Level/2);
        ATP = (SpawnerSpawner.EnemieType / 4) * (PlayerInteraction.Level / 2);
        SpecialAttack = Random.Range(0, 6);

    }

    // Update is called once per frame
    void Update()
    {
        //HP Reduction for an Attack
        AttackCooldown -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && AttackCooldown <= 0f) 
        {
            HP -= PlayerInteraction.PlayerATP;
            AttackCooldown = 2f;
        }

        if (HP <= 0) 
        {
            EnemieDefeat = true;
            FightOver();
        }
    }
    void FightOver()
    {
        SpawnerSpawner.SpawnSomething = true;
        FightWon = true;
        GameObject.Destroy(this.gameObject);
    }
}
