using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    private Player player;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private ItemData itemData;
    private int healthAmount = 50;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = itemData.icon;
        player = PlayerManager.instance.player;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            collision.GetComponent<PlayerStats>().increaseHP(healthAmount);
            Destroy(gameObject);
        }
    }
}
