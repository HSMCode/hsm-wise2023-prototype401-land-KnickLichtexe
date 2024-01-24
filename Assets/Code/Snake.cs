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
    public static bool EnemieDefeat = false, StopAttack = false;
    public static bool FightWon = false;
    private Animator animator;
    public float HealTimer = 0;
    

    public TextMeshProUGUI enemieText;


    // Start is called before the first frame update
    void Start()
    {
        EnemieDefeat = false;
        FightWon = false;
        animator = GetComponent<Animator>();
        HP = SpawnerSpawner.EnemieType  * PlayerInteraction.Level;
        ATP = (SpawnerSpawner.EnemieType)  * (PlayerInteraction.Level) / 2;
        SpecialAttack = Random.Range(0, 6);

        enemieText = GetComponent<TextMeshProUGUI>();
        enemieText = GameObject.Find("Enemie Info").GetComponent<TextMeshProUGUI>();

        enemieText.text = "Enemie HP: " + HP.ToString();
        StopAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        HealTimer += Time.deltaTime;
        //HP Reduction for an Attack
        if (Input.GetKeyDown(KeyCode.Space) && PlayerInteraction.AttackCooldown <= 0f) 
        {
            HP -= PlayerInteraction.PlayerATP;
            PlayerInteraction.AttackCooldown = 2;
            enemieText.text = "Enemie HP: " + HP.ToString();
            HealTimer = 0;
            PlayerInteraction.SelfAttack = true;
        }

         if (PlayerInteraction.PlayerHP < PlayerInteraction.MaxHP && HealTimer >= 1.9f && PlayerInteraction.Death == false)
         {
                PlayerInteraction.PlayerHP += PlayerInteraction.Level;
                PlayerInteraction.Heal = true;
                HealTimer = 0;
         }


        if (HP <= 0) 
        {
            EnemieDefeat = true;
            FightOver();
        }

        if (PlayerInteraction.EAttack == true)
        {
            animator.SetBool("EAttack", true);
            Invoke("AtttackAnimation", .5f);
            PlayerInteraction.EAttack = false;
        }
    }
    void FightOver()
    {
        SpawnerSpawner.SpawnSomething = true;
        FightWon = true;
        StopAttack = false;
        GameObject.Destroy(this.gameObject);
    }
    void AtttackAnimation()
    {
        animator.SetBool("EAttack", false);
    }
}
