using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.WSA;

public class levelEndSwitcher : MonoBehaviour
{
    SceneManager manager = new SceneManager();
    string[] AllScenes;
    Scene currentLevel;

    // Start is called before the first frame update
    void Start()
    {
        AllScenes = GameObject.FindGameObjectWithTag("gameHandler").GetComponent<GameState>().scenes;
        Scene currentLevel = SceneManager.GetActiveScene();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLevel()
    {
        for (int i = 0; i < AllScenes.Length; i++)
        {
            if (currentLevel.name == AllScenes[i])
            {
                SceneManager.LoadScene(AllScenes[0]);
            }
        }
    }
}
