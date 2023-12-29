using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class SwordSkillController : MonoBehaviour
{
    [SerializeField] private float returnSpeed = 12f;
    private Animator animator;
    private Rigidbody2D rigidbody2D;
    private CircleCollider2D circleCollider2D;
    private Player player;
    private bool canRotate = true;
    private bool isReturning;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    public void setupSword(Vector2 throwDir,float gravityScale,Player _player)
    {
        player = _player;
        //gets the gravity scale and the direction that should be applied when throwing the sword
        rigidbody2D.velocity = throwDir;
        rigidbody2D.gravityScale = gravityScale;

        animator.SetBool("Rotation", true);
    }
    public void returnSword()
    {
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        //make it so that it is no longer a child of what it is stuck in
        transform.parent = null;
        isReturning = true;
    }
    private void Update()
    {
        //make the sword rotate towards where its going to land
        if(canRotate)
            transform.right = rigidbody2D.velocity;

        if (isReturning)
        {
            //make it move from where it is to towards the player
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, returnSpeed * Time.deltaTime);
            
            //if the sword has returned to the player it should be destroyed
            if (Vector2.Distance(transform.position,player.transform.position) < 0.5f)
                player.catchTheSword();
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("Rotation", false);
        //stop it rotating and disable the collider
        canRotate = false;
        circleCollider2D.enabled = false;

        
        rigidbody2D.isKinematic = true;
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        
        //makes it a child of what ever it collided with
        transform.parent = collision.transform; 
    }
}
