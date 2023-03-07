using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileChecker : MonoBehaviour
{
    public Material red, blue, green, yellow;
    public Renderer r;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //r.material = red;
        //r.material = blue;
        //r.material = green;
        //r.material = yellow;
    }
}
