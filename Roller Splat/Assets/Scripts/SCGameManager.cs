using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCGameManager : MonoBehaviour
{


    public GameObject[] grounds;
    public float groundNumber;
    private int currentLevel;
    void Start()
    {
        grounds = GameObject.FindGameObjectsWithTag("Ground");
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

   
    void Update()
    {
        groundNumber = grounds.Length;

    }

    public void LevelUpdate()
    {
        SceneManager.LoadScene(currentLevel + 1);
    }
}
