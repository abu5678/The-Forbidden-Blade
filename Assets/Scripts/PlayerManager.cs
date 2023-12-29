using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //makes it so that now the player can be accessed anywhere by using the player manager
    public static PlayerManager instance;
    public Player player;

    private void Awake()
    {
        //makes it so that only one instance can be active at one time
        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;
    }
}
