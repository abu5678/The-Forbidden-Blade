using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class AfterImageFX : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float colourLoseSpeed;

    public void setupAfterImage(float losingSpeed,Sprite spriteImage)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = spriteImage;
        colourLoseSpeed = losingSpeed;
    }

    private void Update()
    {
        //makes it lose colour over time
        float alpha = spriteRenderer.color.a - colourLoseSpeed * Time.deltaTime;
        spriteRenderer.color = new Color(spriteRenderer.color.r,spriteRenderer.color.g,spriteRenderer.color.b,alpha);

        //once it has lost enough colour it should be destroyed
        if (spriteRenderer.color.a <= 0)
            Destroy(gameObject);
    }
}
