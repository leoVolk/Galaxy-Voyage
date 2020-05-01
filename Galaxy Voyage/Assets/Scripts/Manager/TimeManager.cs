using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager _instance;
    public float slowdownFactor = 0.05f;
	public float slowdownLength = 2f;

    void Awake()
    {
        if(_instance == null)
            _instance = this;
    }

	void Update ()
	{
		Time.timeScale += Time.unscaledDeltaTime;
		Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
	}

	public void DoSlowmotion ()
	{
		Time.timeScale = slowdownFactor;
		Time.fixedDeltaTime = Time.timeScale * .02f;
	}


}
