using UnityEditorInternal;
using UnityEngine;

public class Hacker : MonoBehaviour
{   //Game configuration data
    string[] level1Passwords = {"reviere", "cheating", "silent", "embarrassment", "poison"};
    string[] level2Passwords = { "metadata", "encryption", "pharmaceutical", "hallucinogens", "buprenorphine"};
    string[] level3Passwords = { "cybersecurity", "hospitalization", "acetylcholine", "bereavement", "cholinesterase"};
    //Game State
    int level;
    //Game Screen State
    enum Screen {MainMenu, Password, Win};
    Screen currentScreen;
    string keyword;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu("Hello Benjamin");
    }
    // Main menu code
    void ShowMainMenu(string greeting)
    {
        Terminal.ClearScreen();
        currentScreen = Screen.MainMenu;
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("Good Evening!");
        Terminal.WriteLine("This terminal can hack anything.");
        Terminal.WriteLine("What Will you do?");
        Terminal.WriteLine("Press 1 to hack School's data.");
        Terminal.WriteLine("Press 2 to hack Crush's social media.");
        Terminal.WriteLine("Press 3 to hack into Avocado.net.");
        Terminal.WriteLine("Type menu to return.");
        Terminal.WriteLine("Choose a number then press Return: ");
    }
    // This should only decide who to handle input, not actually do it. All inputs need to go through here. So whatever the player types somehow it must be linked through here. 
    void OnUserInput(string input)
    {
        if (input.ToLower().Equals("menu"))
        {
            ShowMainMenu("Welcome back");
        }
        else if (input.ToLower() == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("If on the web close the tab :)"); 
            Application.Quit(); 
        }
        else if (currentScreen == Screen.MainMenu)
        {
            DifficultyLevels(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }
    // Difficulty that goes through input
    void DifficultyLevels(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Invalid Option");
        }
    }
    //Sets the screen password. Calls SetRandomPassoword function. 
    void StartGame()
    {
        Terminal.ClearScreen();
        currentScreen = Screen.Password;
        SetRandomPassword();
        Terminal.WriteLine("Enter Keyword: " + keyword.Anagram());
    }

    private void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                int index1 = Random.Range(0, level1Passwords.Length);
                keyword = level1Passwords[index1];
                break;
            case 2:
                int index2 = Random.Range(0, level2Passwords.Length);
                keyword = level2Passwords[index2];
                break;
            case 3:
                int index3 = Random.Range(0, level3Passwords.Length);
                keyword = level3Passwords[index3];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input) //
    {
        if (input.ToLower() == keyword)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("Incorrect Keyword");
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Well Done Doc!");
                Terminal.WriteLine(@"
   @}     {)
   |\_/~\_/|
   ||     ||
  //\\    /)
 ///\\\  / |
////\\\\ \ I
~~~~~~~~ ^ ^
"
                );
                break;
            case 2:
                Terminal.WriteLine("Well Done Simp!");
                Terminal.WriteLine(@"
      .-.
     (/^\)
     (\ /)
     .-'-.
    /(_I_)\
    \\) (//
     /   \
     \ | /
"
                );
                break;
            case 3:
                Terminal.WriteLine("Well Done! :)");
                Terminal.WriteLine(@"
     _            _   _     
    | |          | | | |    
  __| | ___  __ _| |_| |__  
 / _` |/ _ \/ _` | __| '_ \ 
| (_| |  __/ (_| | |_| | | |
 \__,_|\___|\__,_|\__|_| |_|
"
                );
                break;
        }
        
    }
}
