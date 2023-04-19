using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayMusic : MonoBehaviour
{
    public static GameplayMusic Insatance {  get; private set; } // Singleton

    [SerializeField]
    private AudioSource crowdCheering, crowdGasp;
    [SerializeField]
    private AudioSource chooseRock, choosePaper, chooseScissors, specialTileSound;
    [SerializeField]
    private AudioSource playerMoveSound;

    public bool isRoundWin = false, isRoundDraw = false, isRoundLost = false;

    private float crowdSoundEffectTimer = 2.5f;

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
        // Destroy Instance before game over screen.
        if(GameManager.PlayerIsDead == true)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator CountSeconds(float timer) // Add a coutdown / timer before a function is called.
    {
        //Debug.Log( " second(s) have passed);
        yield return new WaitForSeconds(timer);
        crowdCheering.Stop();
        crowdGasp.Stop();
    }
    public void PlayPlayerMoveSound()
    {
        playerMoveSound.Play(); // Play move sound effects (Ref on PlayerController).
    }

    public void PlaySpecialTileSound()
    {
        specialTileSound.Play(); // Ref in Tile Manager.
    }

    public void PlayRockSound()
    {
        chooseRock.Play(); // Ref in Game Manager.
    }
    public void PlayPaperSound()
    {
        choosePaper.Play(); // Ref in Game Manager.
    }
    public void PlayScissorsSound()
    {
        chooseScissors.Play(); // Ref in Game Manager.
    }

    public void PlayCrowdCheerSound()
    {
        crowdCheering.Play(); // Ref in Game Manager.
        StartCoroutine(CountSeconds(crowdSoundEffectTimer));
    }
    public void PlayCrowdGaspSound()
    {
        crowdGasp.Play(); // Ref in Game Manager.
        StartCoroutine(CountSeconds(crowdSoundEffectTimer));
    }



}
