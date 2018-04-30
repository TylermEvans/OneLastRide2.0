using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreCounter : MonoBehaviour
{
    public int mScoreCount = 0;
    public Text mText;
    scoreCounter score = GameObject.Find("ScoreCounterObj").GetComponent<scoreCounter>();
    // Use this for initialization
    void Start()
    {

    }
    
    public void add(int num)
    {
        mScoreCount += num;
    }

	
	// Update is called once per frame
	void Update ()
    {
        mText.text = "Score : " + mScoreCount.ToString();
        ///score.GetComponent<UnityEngine.UI.Text>().text = "Score : " + score.mScoreCount;
    }
}
