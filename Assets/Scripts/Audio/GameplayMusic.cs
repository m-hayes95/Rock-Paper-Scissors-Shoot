using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayMusic : MonoBehaviour
{
    public static GameplayMusic Insatance {  get; private set; }

    [SerializeField]
    private AudioSource crowdCheering, crowdGasp;

    public bool isRoundWin = false, isRoundDraw = false, isRoundLost = false;

    private void Awake()
    {
        if (Insatance == null)
        {
            Insatance = this;
            DontDestroyOnLoad(this);
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    { 
        // Destroy instance when the player goes to game over screen.
        if (GameManager.PlayerIsDead == true)
        {
            Destroy(gameObject);
        }

        if (isRoundWin == true || isRoundDraw == true)
        {
            float timer = 2.5f;
            crowdCheering.Play();
            isRoundWin = false; // Reset bool
            isRoundDraw= false;
            StartCoroutine(CountSeconds(timer));
            
        }

        if (isRoundLost == true)
        {
            float timer = 2.5f;
            crowdGasp.Play();
            isRoundLost = false;
            StartCoroutine(CountSeconds(timer));
        }
    }

    private IEnumerator CountSeconds(float timer) // Add a coutdown / timer before a function is called.
    {
        //Debug.Log( " second(s) have passed);
        yield return new WaitForSeconds(timer);
        crowdCheering.Stop();
        crowdGasp.Stop();
    }
}
