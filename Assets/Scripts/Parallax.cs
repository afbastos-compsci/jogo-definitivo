using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length;
    private float startPos;
    private Transform cam;
    public float parallaxEffect;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main.transform;
        
    }

    
    void Update()
    {
        float restartPos = cam.transform.position.x * (1 - parallaxEffect);
        float distancia = cam.transform.position.x * parallaxEffect;
        transform.position = new Vector3(startPos + distancia, transform.position.y, transform.position.z);

        if(restartPos > startPos + length){
            startPos += length;
        }
        else if( restartPos < startPos - length){
            startPos -= length;
        }
        
    }
}
