using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public static int PlayerHP = 20;
    public static int MaxHP = 20;
    public static int PlayerATP = 2;
    public int XP = 0;
    public static int Level = 1;
    public int MaxXP = 10;
    public static bool Death = false;
    public static float AttackCooldown = 0f;
    public static float EAttackCooldown = 0f;
    public static int SpecialItem = 0;
    public static bool EAttack = false;
    public static bool BANANA = false, Heal = false, SelfAttack = false;

    public GameObject Banana;
    public TextMeshProUGUI playerText, enemieText, levelText;
    private Animator b_animator;
    public AudioSource Hit, EHit, Music;


    // Start is called before the first frame update
    void Start()
    {
        Level = 1;
        MaxHP = 20;
        PlayerHP = 20;
        PlayerATP = 2;
        EAttack = false;
        Death = false;
        SpecialItem = 0;
        EAttackCooldown = 0f;
        AttackCooldown = 0f;
        MaxXP = 10;
        Level = 1;

        playerText = GetComponent<TextMeshProUGUI>();
        enemieText = GetComponent<TextMeshProUGUI>();
        levelText = GetComponent<TextMeshProUGUI>();

        playerText = GameObject.Find("Player Info").GetComponent<TextMeshProUGUI>();
        enemieText = GameObject.Find("Enemie Info").GetComponent<TextMeshProUGUI>();
        levelText = GameObject.Find("Level Info").GetComponent<TextMeshProUGUI>();

        playerText.text = "Player HP: " + PlayerHP + "/" + MaxHP.ToString();
        levelText.text = "Level: " + Level.ToString();
        b_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Snake.StopAttack = false;
            SceneManager.LoadScene("Gorilla Warfare", LoadSceneMode.Single);
        }
        if (SpawnerSpawner.SpawnSomething == true)
        {
            PlayerHP = MaxHP;
        }
        AttackCooldown -= Time.deltaTime;
        EAttackCooldown -= Time.deltaTime;
        if (Snake.FightWon == true)
        {
            GainXP();
            Snake.FightWon = false;
        }

        if (EAttackCooldown <= 0f && Snake.StopAttack == true)
        {
            PlayerHP -= Snake.ATP;
            EAttackCooldown = 2f;
            playerText.text = "Player HP: " + PlayerHP + "/" + MaxHP.ToString();
            EAttack = true;
            Invoke("ATA", .5f);
            EHit.Play();

        }
        if (SelfAttack == true)
        {
            b_animator.SetBool("Attack", true);
            Invoke("AttackAnim", .5f);
            SelfAttack = false;
            Hit.Play();
        }


        if (PlayerHP <= 0)
        {
            Death = true;
            Ded();
        }
        if (BANANA == true)
        {
            playerText.text = "Player HP: " + PlayerHP + "/" + MaxHP.ToString();
        }
        if (Heal == true)
        {
            playerText.text = "Player HP: " + PlayerHP + "/" + MaxHP.ToString();
            Heal = false;
        }
    }

    void GainXP()
    {
        XP += SpawnerSpawner.EnemieType;
        SpecialItemDrop();
        if (XP >= MaxXP)
        {
            Level += 1;
            XP -= MaxXP;
            PlayerHP = MaxHP;
            LevelUP();
        }
    }
    void LevelUP()
    {
        MaxHP = MaxHP + Level;
        PlayerATP = PlayerATP * (Level / 2);
        MaxXP = Level * 5;
        levelText.text = "Level: " + Level.ToString();
    }
    void Ded()
    {
        Snake.StopAttack = false;
        b_animator.SetBool("Death", true);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Snake.StopAttack = false;
            b_animator.SetBool("Death", false);
            SceneManager.LoadScene("Gorilla Warfare", LoadSceneMode.Single);
        }
    }

    void SpecialItemDrop()
    {
        if (Snake.SpecialAttack >= 4)
        {
            Instantiate(Banana, new Vector3(-7, 2, 0), transform.rotation * Quaternion.Euler(0, 90f, 0));
            SpecialItem = 1;
        }
    }

    void ATA()
    {
        b_animator.SetBool("Attack", false);
    }

    void AttackAnim ()
    {
        b_animator.SetBool("Attack", false);
    }
}
