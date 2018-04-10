using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playButtonaScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void MoveToGame ()
    {
        SceneManager.LoadScene(1);
        //Debug.Log("You have clicked the button!");
    }
}
