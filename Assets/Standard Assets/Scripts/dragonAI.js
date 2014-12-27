#pragma strict

var player : Rigidbody2D;
var moveSpeed : double;
var patrolRange: double;
var behavior : String;

function Start () {
	
}

function Update () {
	if (rigidbody2D.velocity.x == 0) {
		//	Give it an initial velocity
		var random = Random.value;
		if (random >= 0.5)
			rigidbody2D.velocity.x = moveSpeed/2;
		else
			rigidbody2D.velocity.x = -moveSpeed/2;
	}

	switch(behavior) {
		case("follow"):
			follow(player);
			break;
		case("patrol"):
			patrol();
			break;
	}
}

function follow(target) {
	//	Simple AI function that just follows the target on x direction
	if (transform.position.x >= player.transform.position.x) {
		rigidbody2D.velocity.x = -moveSpeed;
	}
	else if (transform.position.x < player.transform.position.x) {
		rigidbody2D.velocity.x = moveSpeed;
	}
	//	Switch back to patrol if player is out of range
	var distance = Mathf.Abs(transform.position.x - player.transform.position.x);
	if (distance >= patrolRange) {
		behavior = "patrol";	
	}
}

function patrol() {
	//	Patrol. If player is in range of object, then switch to follow state
	var random = Random.value;
	if (random >= 0.99)
		rigidbody2D.velocity.x *= -1;
	
	var distance = Mathf.Abs(transform.position.x - player.transform.position.x);
	if (distance <= patrolRange) {
		behavior = "follow";	
	}
}
	