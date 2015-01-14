using UnityEngine;
using System.Collections;

public class Collectibles {
	public int collected, minimum;
	
	public Collectibles(int minimum) {
		this.collected = 0;
		this.minimum = minimum;
	}
	
	public void collectedCollectible(GameObject collectible) {
		GameObject.Destroy(collectible);
		collected++;
		if(collected >= minimum) {
			State.state = 2;
		}
	}
}
