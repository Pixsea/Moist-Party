using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// The list of option buttons, like Play and Quit
    /// </summary>
    public List<GameObject> optionButtons = new List<GameObject>();
    /// <summary>
    /// The text that says "Press Start"
    /// </summary>
    public GameObject pressStartText;

    public GameObject selectedBackground;

    public static MainMenu instance;

    private int currentButton = 0;
    private void Start()
    {
        instance = this;
        foreach (GameObject button in optionButtons)
        {
            button.SetActive(false);
            selectedBackground.transform.position = optionButtons[currentButton].transform.position;
        }
    }

    public void StartPressed(PlayerInput input)
    {
        pressStartText.SetActive(false);
        foreach (GameObject button in optionButtons)
        {
            button.SetActive(true);
        }
        selectedBackground.SetActive(true);
    }
    /// <summary>
    /// Move which button is currently selected
    /// </summary>
    /// <param name="direction"></param>
    public void MoveSelected(int direction)
    {
        currentButton += direction;
        //handle overflow
        if (currentButton >= optionButtons.Count)
            currentButton = 0;
        if (currentButton < 0)
            currentButton = optionButtons.Count - 1;
        //Move the background to the selected object
        selectedBackground.transform.position = optionButtons[currentButton].transform.position;
    }

    public void PressSelected()
    {
        GameObject current = optionButtons[currentButton];
        Button button = current.GetComponent<Button>();
        button.onClick.Invoke();
    }

    // When "PLAY" is selected, load the next scene in the queue
    // The next scene comes from the "Build Settings" window in the editor
    public void PlayGame()
    {
        //SceneManager.LoadScene("BoardScene", LoadSceneMode.Single);
        SceneManager.LoadScene("NewOptions", LoadSceneMode.Single);
    }

    // Quits game when "QUIT" is selected
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
