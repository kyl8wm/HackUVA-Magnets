using UnityEngine;
using System.Collections;

public class Restarter : MonoBehaviour {

    private GameObject Hero;

    void Start()
    {
        Hero = GameObject.Find("Hero");
    }

    void FixedUpdate()
    {
        this.transform.position = new Vector3(Hero.transform.position.x, this.transform.position.y, 0.0f);
    }

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.tag == "Player")
			Application.LoadLevel(Application.loadedLevelName);
	}
}
