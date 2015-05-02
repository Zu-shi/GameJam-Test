using UnityEngine;
using System.Collections;

public class ParticleSortlayerScript : MonoBehaviour {

	void Start () {
        //Change Foreground to the layer you want it to display a particle system on, otherwise particles will not show up.
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Foreground";
	}
}
