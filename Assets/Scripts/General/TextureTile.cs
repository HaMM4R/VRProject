using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TextureTile : MonoBehaviour
{
    public float scaleFactorX = 5.0f;
    public float scaleFactorZ = 5.0f;
    Material mat;

    void Start()
    {
        GetComponent<Renderer>().material.mainTextureScale = new Vector2(transform.localScale.x / scaleFactorX, transform.localScale.z / scaleFactorZ);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.hasChanged && Application.isEditor && !Application.isPlaying)
        {
            Debug.Log("The transform has changed!");
            GetComponent<Renderer>().material.mainTextureScale = new Vector2(transform.localScale.x / scaleFactorX, transform.localScale.z / scaleFactorZ);
            transform.hasChanged = false;
        }
    }
}
