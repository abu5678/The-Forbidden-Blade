using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class SwordSkillController : MonoBehaviour
{ 
    private Animator animator;
    private Rigidbody2D rigidbody2D;
    private CircleCollider2D circleCollider2D;
    private Player player;
    private bool canRotate = true;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    public void setupSword(Vector2 throwDir,float gravityScale)
    {
        //gets the gravity scale and the direction that should be applied when throwing the sword
        rigidbody2D.velocity = throwDir;
        rigidbody2D.gravityScale = gravityScale;
    }
    private void Update()
    {
        //make the sword rotate towards where its going to land
        if(canRotate)
            transform.right = rigidbody2D.velocity;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //stop it rotating and disable the collider
        canRotate = false;
        circleCollider2D.enabled = false;

        
        rigidbody2D.isKinematic = true;
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        
        //makes it a child of what ever it collided with
        transform.parent = collision.transform; 
    }
}
