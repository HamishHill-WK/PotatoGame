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
        SoundManager.PlaySound("ButtonTap"); //calls sound from SoundManager Script - hs
    }

    public void openProfile() //show profile screen -hh
    {
        switchState(States.profile);
        SoundManager.PlaySound("ButtonTap"); //calls sound from SoundManager Script - hs
    }

    public void openMenu() //show menu screen -hh
    {
        switchState(States.menu);
        SoundManager.PlaySound("ButtonTap"); //calls sound from SoundManager Script - hs
    }
        
    public void openFarm() //open farm scene -hh
    {
        SceneManager.LoadScene("Farming");
        SoundManager.PlaySound("ButtonTap"); //calls sound from SoundManager Script - hs
    }


    public void openCooking() //open cooking scene -hs
    {
        SceneManager.LoadScene("Cooking");
        SoundManager.PlaySound("ButtonTap"); //calls sound from SoundManager Script - hs
    }

    public void openOptions() //open options screen -hh
    {
        switchState(States.options);
        SoundManager.PlaySound("ButtonTap"); //calls sound from SoundManager Script - hs

        PlayerPrefs.SetInt("newScore", 0);

        PlayerPrefs.Save();
    }

    public void closeApp()
    {
        Application.Quit();
    }

    public void clearSave() //had to call this puplic static function clearBinaryFile from here because button OnClick() doesn't like static methods - hh 
    {
        SaveSystem.clearBinaryFile();
    }

    private void switchState(States state)
    {
        current = state;
        switch (current)
        {
            case States.menu:
                profilePanel.SetActive(false);
                menuPanel.SetActive(true);
                optionsPanel.SetActive(false);
                gamePanel.SetActive(false);
                break;
            case States.profile:
                profilePanel.SetActive(true);
                menuPanel.SetActive(false);
                optionsPanel.SetActive(false);
                gamePanel.SetActive(false);
                break;
            case States.options:
                profilePanel.SetActive(false);
                menuPanel.SetActive(false);
                optionsPanel.SetActive(true);
                gamePanel.SetActive(false);
                break;            
            case States.closed:
                profilePanel.SetActive(false);
                menuPanel.SetActive(false);
                optionsPanel.SetActive(false);
                gamePanel.SetActive(true);
                break;
        }
    }
    
}
