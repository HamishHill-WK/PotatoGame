using UnityEngine;
using UnityEngine.SceneManagement;

//this script was written by Hamish Hill Github: @HamishHill-WK
//this script controls which panel the user is viewing - hh
//each public function has a corresponding button in the scene 

public class Menu : MonoBehaviour
{
    private GameObject menuPanel;
    private GameObject profilePanel;
    private GameObject optionsPanel;
    private GameObject gamePanel;

    enum States { menu = 0, profile, options, closed };     //state machine to track which page the user is viewing -hh
    States current = States.menu;

    void Start()
    {
        menuPanel = GameObject.Find("MainMenu");
        profilePanel = GameObject.Find("Profile");
        optionsPanel = GameObject.Find("Options");
        gamePanel = GameObject.Find("GameView");

        switchState(States.menu);
    }

    public void enterGame() //show screen to enter farming or cooking -hh
    {
        switchState(States.closed);
    }

    public void openProfile() //show profile screen -hh
    {
        switchState(States.profile);
    }

    public void openMenu() //show menu screen -hh
    {
        switchState(States.menu);
    }
        
    public void openFarm() //open farm scene -hh
    {
        SceneManager.LoadScene("Farming");
    }

    public void openCooking() //open cooking scene -hs
    {
        SceneManager.LoadScene("Cooking");
    }

    public void openOptions() //open options screen -hh
    {
        switchState(States.options);

        PlayerPrefs.SetInt("newScore", 0);

        PlayerPrefs.Save();
    }

    public void closeApp()
    {
        Application.Quit();
    }

    private void switchState(States state)
    {
        current = state;
        switch (current)
        {
            case States.menu:
                // code block
                profilePanel.SetActive(false);
                menuPanel.SetActive(true);
                optionsPanel.SetActive(false);
                gamePanel.SetActive(false);
                break;
            case States.profile:
                // code block
                profilePanel.SetActive(true);
                menuPanel.SetActive(false);
                optionsPanel.SetActive(false);
                gamePanel.SetActive(false);
                break;
            case States.options:
                // code block
                profilePanel.SetActive(false);
                menuPanel.SetActive(false);
                optionsPanel.SetActive(true);
                gamePanel.SetActive(false);
                break;            
            case States.closed:
                // code block
                profilePanel.SetActive(false);
                menuPanel.SetActive(false);
                optionsPanel.SetActive(false);
                gamePanel.SetActive(true);
                break;
        }
    }
    
}
