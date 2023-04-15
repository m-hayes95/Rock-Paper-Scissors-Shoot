using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrailGameObjectSpin : MonoBehaviour
{
    private void Update()
    {
        float yRotationAmount = 30;
        float xRotationAmount = 30;
        float zRotationAmount = 30;
        transform.Rotate(xRotationAmount * Time.deltaTime, 
            yRotationAmount * Time.deltaTime, 
            zRotationAmount * Time.deltaTime);
    }
}
