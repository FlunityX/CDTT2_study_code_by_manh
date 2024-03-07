using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startposX,startposY, height;
    public GameObject cam;
    public float parallexEffectX;
    public float parallexEffectY;
    void Start()
    {
        startposX = transform.position.x;
        startposY = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }
    void Update()
    {
        float tempX = (cam.transform.position.x * (1 - parallexEffectX));
        float distX = (cam.transform.position.x * parallexEffectX);
        float tempY = (cam.transform.position.y * (1 - parallexEffectY));
        float distY = (cam.transform.position.y * parallexEffectY);
        if (tempX > startposX + length) startposX += length;
        else if (tempX < startposX - length) startposX -= length;
        if (tempY > startposY + length) startposX += height;
        else if (tempY < startposY - length) startposX -= height;
      
        transform.position = new Vector3(startposX + distX,startposY + distY , transform.position.z);
       
    }
}