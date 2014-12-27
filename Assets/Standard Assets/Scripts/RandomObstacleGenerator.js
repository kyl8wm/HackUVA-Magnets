#pragma strict
//	Instructions:
//	1. Set all obstacles that you want to use down below
//	2. Make sure to link these variables to the rigidbody2d objects in your game
//	3. Place them inside the list
//	4. Make sure to change the int inside the bracket[] to the correct number of obstacles
//	Note: Perhaps place this in an empty object


var player : GameObject;
var distanceTraveled = 0;
var readyRandom = true;	//	flag that's set to true when game is ready to create a new level
var levelWidth = 100;
var obstacles : GameObject[];	//	List of instantiated obstacles, game breaks after 1000*100
obstacles = new GameObject[1000];
var obstacleCount = 0;	//	Number of obstacles created
var temp : GameObject;	//	Temporary Object
//	High Score variables
var aText : GUIText;
var offset : int;		//	if Player is not exactly at x = 0, offset
var random : double;

//	Edit these variables below!
var listSize = 2;
var list : GameObject[];
list = new GameObject[listSize];
var obstacle1 : GameObject;
var obstacle2 : GameObject;
list[0] = Instantiate (obstacle1, transform.position, transform.rotation);
list[1] = Instantiate (obstacle2, transform.position, transform.rotation);
function Start () {
	offset = player.transform.position.x;	//	High Score offset helper
}

function Update () {
	//	Display score
	if (player.rigidbody2D.transform.position.x-offset > distanceTraveled) {
		distanceTraveled += (player.rigidbody2D.transform.position.x - distanceTraveled - offset);
	}
	aText.text = "" + distanceTraveled;
	
	//	Do Random
	if (distanceTraveled % levelWidth == 0 && readyRandom) {
		readyRandom = false;
		random = Mathf.Floor(Random.value * listSize);
		
		temp = list[random];
		temp.transform.position.x = player.transform.position.x + 50;
		
		obstacles[obstacleCount] = Instantiate (temp, temp.transform.position, temp.transform.rotation);
		obstacleCount++;
	}
	if (distanceTraveled % levelWidth == 1 && !readyRandom) {
		readyRandom = true;
	}
}