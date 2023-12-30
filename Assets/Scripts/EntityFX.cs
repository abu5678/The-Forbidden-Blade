using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EntityFX : MonoBehaviour
{
    [Header("Pop Up Text")]
    [SerializeField] private GameObject popUpTextPrefab;
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

    //used to make the sprite render colour keep alternating between red and white
    private void RedColourBlink()
    {
        if(spriteRenderer.color != Color.white)
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
    public void createPopUpText(string text)
    {
        //makes it so that the pop up text appears in a random loaction above the character
        float randomX = Random.Range(4.5f,6.5f);
        float randomY = Random.Range(0,1.5f);

        Vector3 positionOffset = new Vector3(randomX, randomY, 0);
        GameObject newText = Instantiate(popUpTextPrefab,transform.position + positionOffset,Quaternion.identity);

        newText.GetComponent<TextMeshPro>().text = text;
    }
}
