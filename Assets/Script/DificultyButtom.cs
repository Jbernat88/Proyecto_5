using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DificultyButtom : MonoBehaviour
{
    public int difficulty;
    private Button button;
    private GameManager gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);

        gameManagerScript = FindObjectOfType<GameManager>();
;    }

    public void SetDifficulty() //Añadir cosas para diferenciar la dificultat
    {
        gameManagerScript.StartGame(difficulty);
    }

}
