using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameSprite_script : MonoBehaviour
{
    private int miniGameSel;

    private GameObject gameController;

    public Sprite[] recipe1Sprites;
    public Sprite[] recipe2Sprites;

    private Sprite[] referencedSprites;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("Game Controller");

        miniGameSel = gameController.GetComponent<RecipeBook_script>().miniGameSelection;

        switch (miniGameSel)
        {
            default:
                break;

            case 1:
                referencedSprites = recipe1Sprites;

                PotatoCutting();        // Start the potato cutting minigame
                break;

            case 2:
                referencedSprites = recipe2Sprites;

                BoilMiniGame();
                break;
        }
    }

    void Awake()        //Only works on a rigidbody
    {
        
    }
    
    void PotatoCutting()
    {
        Debug.Log("Potato Cutting");

        this.GetComponent<SpriteRenderer>().sprite = referencedSprites[0];
    }

    void BoilMiniGame()
    {
        Debug.Log("Potato Boiling");

        this.GetComponent<SpriteRenderer>().sprite = referencedSprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
