using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Declare gameobject references
    public GameObject pickUp;
    public GameObject dropDown;
    public GameObject startGameUI;
    // public GameObject levelSelectField;
    public InputField levelSelectField;
    public Text levelInstructions;

    // Set the way that the pickups spawn
    private int numberOfPickups = 4;
    private int numberOfDropDowns = 2;
    private int spawnRange = 9;

    // Variables to deal with the progression of the game.
    public Text countText;
    public Text winText;
    private int count;

    public bool isGameActive;


    private void Start()
    {
        // Initialize the count and game text.
        count = 0;
        SetCountText();
        winText.text = "";
    }

    // Start is called before the first frame update
    public void myGameStart()
    {

        // Spawns the pickups in random locations by looping through 'numberOfPickup' times
        for (int i = 0; i < numberOfPickups; i = i + 1)
        {
            drawObjects(pickUp);
        }

        // Spawns the pickups in random locations by looping through 'numberOfPickup' times
        for (int i = 0; i < numberOfDropDowns; i = i + 1)
        {
            drawObjects(dropDown);
        }


        isGameActive = true;
        startGameUI.SetActive(false);

    }

    public void validateLevelSelect()
    {

        //string textInput = levelSelectField.GetComponent<InputField>().text;
        string textInput = levelSelectField.text;

        int number;
        if (string.IsNullOrEmpty(textInput))
        {
            levelInstructions.text = "Level can not be left blank.";
        }
        else if (!int.TryParse(textInput, out number))
        {
            Debug.Log("String is not a number: " + number);
            levelInstructions.text = textInput + " is not a number.";
        }
        else if (number < 1 || number > 9)
        {
            levelInstructions.text = textInput + " is outside the required range.";
        }
        else
        {
            numberOfPickups = number;
            numberOfDropDowns = number * 2;
            myGameStart();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void increaseCount()
    {
        // Increases the number of pickups collected
        count = count + 1;
        SetCountText();
    }

    public void decreaseCount()
    {
        // Increases the number of pickups collected
        count = count - 1;
        SetCountText();
    }

    void SetCountText()
    {
        // Updates the count text and checks win state.
        countText.text = "Count : " + count.ToString();
        if (count >= numberOfPickups)
        {
            winText.text = "You win!!";
            isGameActive = false;
        }
        else if (count <= 0)
        {
            winText.text = "You Lose!!";
            isGameActive = false;
        }
    }
    // dropDown
    private void drawObjects(GameObject myObject)
    {
        // Instantiates passed over game objects at random locations
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosY = Random.Range(-spawnRange, spawnRange);
        Instantiate(myObject, new Vector3(spawnPosX, 0.5f, spawnPosY), myObject.transform.rotation);
    }

}
