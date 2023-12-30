using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


//makes the background follow the player
public class ParallaxBackground : MonoBehaviour
{
    private GameObject cam;

    [SerializeField] private float parallaxEffect;

    private float xPosition;
    private float length;

    private float yPosition;
    private float height;

    void Start()
    {
        cam = GameObject.Find("Main Camera");

        xPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

        yPosition = transform.position.y;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceMoved = cam.transform.position.x * (1 - parallaxEffect);
        float distanceToMove = cam.transform.position.x * parallaxEffect;

        transform.position = new Vector3 (xPosition + distanceToMove, transform.position.y);

        if (distanceMoved > xPosition + length)
        {
            xPosition = xPosition + length;
        }
        else if (distanceMoved < xPosition - length)
        {
            xPosition = xPosition - length;
        }

        float distanceMovedY = cam.transform.position.y * (1 - parallaxEffect);
        float distanceToMoveY = cam.transform.position.y * parallaxEffect;

        transform.position = new Vector3(transform.position.x, yPosition + distanceToMoveY);

        if (distanceMovedY > yPosition + height)
        {
            yPosition = yPosition + height;
        }
        else if (distanceMovedY < yPosition - height)
        {
            yPosition = yPosition - height;
        }
    }
}
