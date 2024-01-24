using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Snake : MonoBehaviour
{

    public float HP = 1f;
    public static int ATP = 1;
    public static int SpecialAttack = 0;
    public static bool EnemieDefeat = false;
    public static bool FightWon = false;
    private Animator animator;
    

    public TextMeshProUGUI enemieText;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        HP = (SpawnerSpawner.EnemieType / 2) * (PlayerInteraction.Level/2);
        ATP = (SpawnerSpawner.EnemieType / 4) * (PlayerInteraction.Level / 2);
        SpecialAttack = Random.Range(0, 6);

        enemieText = GetComponent<TextMeshProUGUI>();
        enemieText = GameObject.Find("Enemie Info").GetComponent<TextMeshProUGUI>();

        enemieText.text = "Player HP: " + HP.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        //HP Reduction for an Attack
        if (Input.GetKeyDown(KeyCode.Space) && PlayerInteraction.EAttackCooldown <= 0f) 
        {
            HP -= PlayerInteraction.PlayerATP;
            PlayerInteraction.EAttackCooldown = 2;
            enemieText.text = "Enemie HP: " + HP.ToString();
        }

        if (HP <= 0) 
        {
            EnemieDefeat = true;
            FightOver();
        }

        if (PlayerInteraction.EAttack == true)
        {

        }
    }
    void FightOver()
    {
        SpawnerSpawner.SpawnSomething = true;
        FightWon = true;
        GameObject.Destroy(this.gameObject);
    }
}
