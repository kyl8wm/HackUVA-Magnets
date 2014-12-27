var isQuit = false;
var style : GUIText;
var theGame;

function OnMouseEnter() { 
	style.color = Color.white;
}

function OnMouseExit() { 
	style.color = Color.red;
}

function OnMouseUp() {
	if (isQuit == true) { 
		Application.Quit();
	} else {
		Application.LoadLevel("Scene");
	}
	
	if (Input.GetKey(KeyCode.Escape)) {
		Application.Quit();
	}
}