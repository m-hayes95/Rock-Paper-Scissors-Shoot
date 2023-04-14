using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

// Ref for code from Code Monkey: "How to make a Heart Health System like Legend of Zelda (Unity Tutorial)".
// https://www.youtube.com/watch?v=xWCJfE_sAXE

public class NewHeartsVisual : MonoBehaviour
{
    [SerializeField] private Sprite fullHeartSprite;
    [SerializeField] private Sprite emptyHeartSprite;
    private int totalNumberOfHearts = 3;
    private int playersHealth; 

    public bool noHeartsLeft = false; // ref in Game Manager when player dies, to destroy this singleton.

    //private Sprite[] heartImagesList;
    private List<HeartImage> currentPlayerHearts;

    private void Awake()
    {
        // Instantiate list of current hearts in scene.
        currentPlayerHearts = new List<HeartImage>();
    }

    private void Start()
    {
        // Display number of hearts.
        DrawAllHearts(totalNumberOfHearts);
    }

    private void Update()
    {
        // Set players current health to a new variable.
        playersHealth = PlayerHealth.Instance.health;

        PlayersCurrentHearts(); // Update players hearts according to current health.
    }
    private HeartImage DrawHeartImage(Vector2 nextDrawAnchoredPosition)
    {
        // Create Game Object for each new heart.
        GameObject heartGameObject = new GameObject("Heart", typeof(Image));
        // Set the game object as a child of this parent using its transform.
        heartGameObject.transform.SetParent(transform);
        // Set the position to the parents transform.
        heartGameObject.transform.localPosition = Vector3.zero;
        // Set location of heart game object.
        heartGameObject.GetComponent<RectTransform>().anchoredPosition = nextDrawAnchoredPosition;


        // Set full heart Sprite
        Image heartImageUI = heartGameObject.GetComponent<Image>();
        heartImageUI.sprite = fullHeartSprite;

        // Create a new Image for the current drawn heart.
        HeartImage heartImage = new HeartImage(this,heartImageUI);
        // Add the new Image to the new current players heart list.
        currentPlayerHearts.Add(heartImage);
        
        return heartImage;
    }

    private void DrawAllHearts (int totalHearts)
    {
        // Start position of hearts.
        Vector2 heartVisualStartAnchoredPoistion = new Vector2(0, 0);
        // Right offset for next heart position.
        Vector2 nextHeartVisualAnchoredPoistionOffset = new Vector2(100, 0);

        // Draw next heart with an offset using the total number of hearts as a parameter.
        for (int i = 0; i < totalHearts; i++)
        {
            DrawHeartImage((heartVisualStartAnchoredPoistion));
            heartVisualStartAnchoredPoistion += nextHeartVisualAnchoredPoistionOffset;
        }
    }


    private void PlayersCurrentHearts()
    {
        // Loop through each heart added to the players current hearts list.
        for (int i = 0; i < currentPlayerHearts.Count; i++)
        {
            // Check if the players current health is less than the current heart count.
            if (i >= playersHealth)
            {
                // If yes, set the current heart to empty, using the HeartImage state machine.
                currentPlayerHearts[i].SetHeartFill(0);
            }
        }
    }


    // Represents a single heart.
    public class HeartImage
    {
        private Image heartImage;
        private NewHeartsVisual heartsVisual;

        // Create a reference to the New Hearts viusal script and the heart image
        public HeartImage(NewHeartsVisual heartsVisual, Image heartImage)
        {
            this.heartsVisual = heartsVisual;
            this.heartImage = heartImage;
        }

        public void SetHeartFill(int heartFill)
        {
            switch (heartFill)
            {
                // Create a case for full and empty heart to be used as the current heart display.
                case 0: heartImage.sprite = heartsVisual.emptyHeartSprite; break;
                case 1: heartImage.sprite = heartsVisual.fullHeartSprite; break;
                default: break;
            }
        }
    }

}
