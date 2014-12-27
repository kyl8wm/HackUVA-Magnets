using UnityEngine;
[RequireComponent(typeof(PlatformerCharacter2D))]
public class Platformer2DUserControl : MonoBehaviour 
{
	private PlatformerCharacter2D character;
    private bool jump;
    private bool actionInProgress = false;

	void Awake()
	{
		this.character = this.GetComponent<PlatformerCharacter2D>();
	}

    void Update ()
    {
        // Read the jump input in Update so button presses aren't missed.
        if (Input.GetButtonDown("Jump")) 
        { 
            this.jump = true; 
        }

		
    }

	void FixedUpdate()
	{
		// Read the inputs.
		//bool crouch = Input.GetKey(KeyCode.LeftControl);

		float h = Input.GetAxis("Horizontal");
        h = Input.GetAxis("Horizontal");
		// Pass all parameters to the character control script.
		character.Move( h, jump );

        // Reset the jump input once it has been used.
	    jump = false;
	}
}
