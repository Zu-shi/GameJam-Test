using UnityEngine;
using System.Collections;

public class TrailSortlayerScript : MonoBehaviour {

	private TrailRenderer trail;
	// Use this for initialization
	void Start () {
		trail = gameObject.GetComponent<TrailRenderer>();
		trail.sortingLayerName = "Foreground";
		trail.sortingOrder = 2;
	}
}
