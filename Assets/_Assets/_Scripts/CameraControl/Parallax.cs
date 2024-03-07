using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length,height, startPosX,startPosY;
    public GameObject cam;
    public float parallexEffectX;
    public float parallexEffectY;
    void Start()
    {
        startPosX = transform.position.x;
        startPosY = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
        cam = GameObject.Find("Main Camera");    
    }
    void Update()
    {
        float tempX = (cam.transform.position.x * (1 - parallexEffectX));
        float distX = (cam.transform.position.x * parallexEffectX);
        float tempY = (cam.transform.position.y * ( parallexEffectY));
        float distY = (cam.transform.position.y * parallexEffectY);
        transform.position = new Vector3(startPosX + distX, startPosY +distY , transform.position.z);
        if (tempX > startPosX + length) startPosX += length;
        else if (tempX < startPosX - length) startPosX -= length;

        if (tempY > startPosY + length) startPosY += height;
        else if (tempY < startPosY - length) startPosY -= height;
    }
}