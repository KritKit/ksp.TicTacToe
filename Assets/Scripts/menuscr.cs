using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuscr : MonoBehaviour
{
    public void Play(){
        SceneManager.LoadScene(1);
    }
    public void Exit(){
        Application.Quit();
    }
}
