using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    public float EatingTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        EatingTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey("space"))
        {
            EatingTimer += Time.deltaTime;
        }
        if (Input.GetKeyUp("space"))
        {
            EatingTimer = 0;
        }

        if (EatingTimer >= .5f)
        {
            PlayerInteraction.SpecialItem = 0;
            PlayerInteraction.PlayerHP = PlayerInteraction.MaxHP;
            PlayerInteraction.BANANA = true;
            Destroy(gameObject);
        }



 
        
    }
}
