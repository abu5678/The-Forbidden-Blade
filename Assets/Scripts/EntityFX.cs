using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFX : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] private Material hitMaterial;
    private Material originalMaterial;
    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();    
        originalMaterial = spriteRenderer.material;
    }


    //when this is called it makes it so that the hit material displays for short time then it will go to its
    //origianl material
    private IEnumerator flashFX()
    {
        spriteRenderer.material = hitMaterial;

        yield return new WaitForSeconds(0.2f);

        spriteRenderer.material = originalMaterial;
    }

    //make the sprite render colour keep alternating between red and white
    private void RedColourBlink()
    {
        if(spriteRenderer.color != Color.red)
            spriteRenderer.color = Color.white;
        else
            spriteRenderer.color = Color.red;
        
    }

    //used to make the sprite render stop changing colours
    private void cancelRedBlink()
    {
        CancelInvoke();
        spriteRenderer.color = Color.white;
    }
}
