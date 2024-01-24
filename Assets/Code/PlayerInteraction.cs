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
    public static int Level = 1;
    public int MaxXP = 10;
    public static bool Death = false;
    public static float AttackCooldown = 0f;
    public static float EAttackCooldown = 0f;
    public static int SpecialItem = 0;
    public static bool EAttack = false;

    public GameObject Banana;
    public TextMeshProUGUI playerText, enemieText, levelText;



    // Start is called before the first frame update
    void Start()
    {
        Level = 1;
        MaxHP = 20;
        PlayerHP = 20;
        PlayerATP = 1;

        playerText = GetComponent<TextMeshProUGUI>();
        enemieText = GetComponent<TextMeshProUGUI>();
        levelText = GetComponent<TextMeshProUGUI>();

        playerText = GameObject.Find("Player Info").GetComponent<TextMeshProUGUI>();
        enemieText = GameObject.Find("Enemie Info").GetComponent<TextMeshProUGUI>();
        levelText = GameObject.Find("Level Info").GetComponent<TextMeshProUGUI>();

        playerText.text = "Player HP: " + PlayerHP.ToString();
        levelText.text = "Level: " + Level.ToString();
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

        if (Input.GetKeyDown(KeyCode.Space) && PlayerInteraction.EAttackCooldown <= 0f)
        {
            PlayerHP -= Snake.ATP;
            EAttackCooldown = 2f;
            playerText.text = "Player " + PlayerHP.ToString();
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
        MaxHP = MaxHP + Level;
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
