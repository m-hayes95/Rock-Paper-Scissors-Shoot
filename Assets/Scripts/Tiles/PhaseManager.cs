using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{
    [SerializeField] private GameObject player, phaseDistanceChecker;


    private void Update()
    {
        // use vector distance from player 
        // with checkpoint that change the current phase
        float distance;
        distance = Vector3.Distance(player.transform.position, phaseDistanceChecker.transform.position);
        Debug.Log("PHASE  " + distance);
        // currently not updating the distance
    }
}
