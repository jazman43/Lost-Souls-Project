using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEffect : MonoBehaviour
{
    public float amplitude = 0.1f;  //wave hight
    public float frequency = 1f;  //wave frequency

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPos + amplitude * new Vector3(0.0f, Mathf.Sin(Time.time * frequency), 0.0f);
    }
}
