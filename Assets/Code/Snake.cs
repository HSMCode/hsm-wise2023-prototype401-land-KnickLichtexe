using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{

    public float HP = 1f;
    public static int ATP = 1;
    public static int SpecialAttack = 0;
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
        if (Input.GetKeyDown(KeyCode.Space) && PlayerInteraction.EAttackCooldown <= 0f) 
        {
            HP -= PlayerInteraction.PlayerATP;
            PlayerInteraction.EAttackCooldown = 2;
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
