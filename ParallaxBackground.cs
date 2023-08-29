using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private GameObject cam;
    [SerializeField] private float parallaxEffect;
    private float xPosition;
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        //cam.transform.position = new Vector2(0,0);
        xPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToMove = cam.transform.position.x * parallaxEffect;
        //Debug.Log(cam.transform.position.x);

        transform.position = new Vector3(xPosition + distanceToMove, transform.position.y);
    }
}
