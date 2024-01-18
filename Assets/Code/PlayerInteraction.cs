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
    public int MaxHP = 20;
    public static int PlayerATP = 1;
    public int XP = 0;
    public static int Level = 2;
    public int MaxXP = 10;
    public static bool Death = false;
    public static float AttackCooldown = 0f;
    public static float EAttackCooldown = 0f;
    public static int SpecialItem = 0;

    public GameObject Banana;
    public TextMeshProUGUI playerText;
    public TextMeshProUGUI enemieText;


    // Start is called before the first frame update
    void Start()
    {
        playerText = GetComponent<TextMeshProUGUI>();
        enemieText = GetComponent<TextMeshProUGUI>();

        playerText = GameObject.Find("Player Info").GetComponent<TextMeshProUGUI>();
        enemieText = GameObject.Find("Enemie Info").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Gorilla Warfare", LoadSceneMode.Single);
        }

        AttackCooldown -= Time.deltaTime;
        EAttackCooldown -= Time.deltaTime;
        if (Snake.FightWon == true) 
        {
            GainXP();
            PlayerHP = MaxHP;
            Snake.FightWon = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && AttackCooldown <= 0f)
        {

            PlayerHP -= Snake.ATP;
            AttackCooldown = 2f;
        }
        if (PlayerHP <= 0)
        {
            Death = true;
            Ded();
        }
        if (Input.GetKeyDown(KeyCode.Space) && AttackCooldown > 0f)
        {
            BananaEaten();
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
            LevelUP();
        }
    }
    void LevelUP()
    {
        MaxHP = MaxHP + (Level/2);
        PlayerATP = PlayerATP * (Level/2);
        MaxXP = Level * 5;
    }
    void Ded()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Gorilla Warfare", LoadSceneMode.Single);
        }
    }

    void SpecialItemDrop()
    {
        if (Snake.SpecialAttack >= 5)
        {
            Instantiate(Banana, new Vector3(-7, 2, 0), transform.rotation * Quaternion.Euler(0, 90f, 0));
            SpecialItem = 1;
        }
    }
    void BananaEaten()
    {
        PlayerHP = MaxHP;
        SpecialItem = 0;
    }
}
