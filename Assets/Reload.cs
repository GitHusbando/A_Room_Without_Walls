using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour
{

    public Button restartButton;

    void Start(){
        restartButton.onClick.AddListener(ReloadScene);
    }


    //Reloads the Level
	public void ReloadScene(){
        Debug.Log("clicked restart");
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
