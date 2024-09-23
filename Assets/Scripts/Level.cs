using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] int BreackBlocks;

    SceneLoader sceneloader;

    public void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();        
    }

    public void CountBlocks()
    {
        BreackBlocks++; 
    }

    public void BlockDestroyed()
    {
        BreackBlocks--;
        if (BreackBlocks == 0)
        {
            sceneloader.LoadNextScene();
        }
    }        
}
