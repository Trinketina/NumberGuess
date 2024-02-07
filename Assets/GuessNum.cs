using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GuessNum : MonoBehaviour
{
    [SerializeField] TMP_InputField guess;
    [SerializeField] TMP_Text textbox;
    [SerializeField] int defaultAttempts = 3;
    int attempts;
    int rand10;
    // Start is called before the first frame update
    void Start()
    {
        OnReset();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            OnGuess();
        }
    }

    [ContextMenu("Guess Input")]
    public void OnGuess()
    {
        if (attempts > 0)
        {
            EventSystem.current.SetSelectedGameObject(guess.gameObject);
            if (guess == null || int.Parse(guess.text) > 10 || int.Parse(guess.text) <= 0)
            {
                textbox.text = "Enter a valid guess. >:c";
                return;
            }
            attempts--;
            Debug.Log("remaining attempts: " + attempts);
            if (int.Parse(guess.text) == rand10)
                textbox.text = "YOU WON!!!";
            else if (attempts > 1)
                textbox.text = "Incorrect! You have " + attempts + " guesses remaining...";
            else if (attempts > 0)
                textbox.text = "Incorrect! You have " + attempts + " guess remaining...";
            else
                textbox.text = "YOU LOSE!!!";
        }
    }
    public void OnReset()
    {
        rand10 = Random.Range(1, 11);
        attempts = defaultAttempts;
        //Debug.Log(rand10);
        textbox.text = "I\'m thinking of a number between 1 and 10. You have " + attempts + " attempts to guess it...";
    }
}
