using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordSkillThrow : Skills
{
    [Header("Skill Info")]
    [SerializeField] private GameObject swordPrefab;
    [SerializeField] private Vector2 throwForce;
    [SerializeField] private float swordGravity;

    private Vector2 finalDir;

    [Header("Aim Dots")]
    [SerializeField] private int numberOfDots;
    [SerializeField] private float spaceBetweenDots;
    [SerializeField] private GameObject dotPrefab;
    [SerializeField] private Transform dotsParent;

    private GameObject[] dots;



    protected override void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            //this will be the direction the sword is thrown at 
            finalDir = new Vector2(aimDirection().normalized.x * throwForce.x, aimDirection().normalized.y * throwForce.y);
        }

        if(Input.GetKey(KeyCode.Mouse1))
        {
            for (int i = 0; i < dots.Length; i++)
            {
                dots[i].transform.position = dotsPosition(i * spaceBetweenDots);
            }
        }
    }
    public void createSword()
    {
        //creates the sword at the position of the player and adds the sword skill controller to it
        GameObject newSword = Instantiate(swordPrefab,player.transform.position,transform.rotation); 
        SwordSkillController newSwordScript = newSword.GetComponent<SwordSkillController>();

        //assigns the throwing direction and gravity of the newly created sword
        newSwordScript.setupSword(finalDir, swordGravity);
        player.assignNewSword(newSword);
        dotsActive(false);
    }

    public Vector2 aimDirection()
    {
        //uses the players position and the mouse position to calculate the direction the sword needs to be thrown at
        Vector2 playerPosition = player.transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - playerPosition; 

        return direction;
    }

    public void dotsActive(bool isActive)
    {
        for (int i = 0; i < dots.Length; i++)
        {
            dots[i].SetActive(isActive);
        }
    }
    
    private void generateDots()
    {
        dots = new GameObject[numberOfDots];
        for(int i = 0; i < numberOfDots; i++)
        {
            dots[i] = Instantiate(dotPrefab, player.transform.position, Quaternion.identity, dotsParent);
            dots[i].SetActive(false);
        }
    }
    private Vector2 dotsPosition(float t)
    {// uses S = ut + 1/2at^2
     //AimDirection().normalized.x * launchForce.x - This gives the initial velocity in the x direction (u_x).
     //AimDirection().normalized.y * launchForce.y - This gives the initial velocity in the y direction(u_y).
     //Physics2D.gravity * swordGravity - Represents the acceleration due to gravity.
     //Physics2D.gravity provides the gravity value and multiplying it by swordGravity scales it accordingly.
           Vector2 position = (Vector2)player.transform.position
            + new Vector2(aimDirection().normalized.x * throwForce.x, aimDirection().normalized.y * throwForce.y) * t
            + 0.5f * (Physics2D.gravity * swordGravity) * (t * t);

        return position;
    }

    protected override void Start()
    {
        base.Start();
        generateDots();
    }
}