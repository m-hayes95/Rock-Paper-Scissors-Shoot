using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Ref for code from Code Monkey: "How to make a Heart Health System like Legend of Zelda (Unity Tutorial)".
// https://www.youtube.com/watch?v=xWCJfE_sAXE

public class NewHeartsVisual : MonoBehaviour
{
    [SerializeField] private Sprite fullHeartSprite;
    [SerializeField] private Sprite emptyHeartSprite;

    private int totalNumberOfHearts = 3;
    private bool isHeartRemoved = false;

    //private Sprite[] heartImagesList;
    private List<HeartImage> currentPlayerHearts;

    private void Awake()
    { 
        // Instantiate list of current hearts in scene.
        currentPlayerHearts = new List<HeartImage>();
    }

    private void Start()
    {
        DrawAllHearts(totalNumberOfHearts);
    }
    private HeartImage DrawHeartImage(Vector2 nextDrawAnchoredPosition)
    {
        // Create Game Object.
        GameObject heartGameObject = new GameObject("Heart", typeof(Image));
        // Set the game object as a child of this transfrom.
        heartGameObject.transform.SetParent(transform);
        heartGameObject.transform.localPosition = Vector3.zero;
        // Set location of heart game object.
        heartGameObject.GetComponent<RectTransform>().anchoredPosition = nextDrawAnchoredPosition;


        // Set full heart Sprite
        Image heartImageUI = heartGameObject.GetComponent<Image>();
        heartImageUI.sprite = fullHeartSprite;

        // Create a new Image for the current drawn heart.
        HeartImage heartImage = new HeartImage(this,heartImageUI);
        // Add the new Image to the list.
        currentPlayerHearts.Add(heartImage);
        
        return heartImage;
    }

    private void DrawAllHearts (int totalHearts)
    {
        // Start position of hearts.
        Vector2 heartVisualStartAnchoredPoistion = new Vector2(0, 0);
        // Right offset for next heart position.
        Vector2 nextHeartVisualAnchoredPoistionOffset = new Vector2(100, 0);
    
        for (int i = 0; i < totalHearts; i++)
        {
            DrawHeartImage((heartVisualStartAnchoredPoistion));
            heartVisualStartAnchoredPoistion += nextHeartVisualAnchoredPoistionOffset;
        }
    }


    public void PlayerTakenDamage()
    {
        for (int i = currentPlayerHearts.Count - 1; i >= 0; i--)
        {
            HeartImage heart = currentPlayerHearts[i];
            if (isHeartRemoved == false)
            {
                heart.SetHeartFill(0);
                isHeartRemoved = true;
            }
            
        }
    }


    // Represents a single heart.
    public class HeartImage
    {
        private Image heartImage;
        private NewHeartsVisual heartsVisual;

        public HeartImage(NewHeartsVisual heartsVisual, Image heartImage)
        {
            this.heartsVisual = heartsVisual;
            this.heartImage = heartImage;
        }

        public void SetHeartFill(int heartFill)
        {
            switch (heartFill)
            {
                case 0: heartImage.sprite = heartsVisual.emptyHeartSprite; break;
                case 1: heartImage.sprite = heartsVisual.fullHeartSprite; break;
                default: break;
            }
        }
    }

}
