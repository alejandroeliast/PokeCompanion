using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadCharacterCreator()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadPokedex()
    {
        SceneManager.LoadScene(0);
    }
}
