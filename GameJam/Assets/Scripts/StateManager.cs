using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateManager{
	public static List<KeyScript> P1ActiveKeys = new List<KeyScript>();
	public static List<KeyScript> P2ActiveKeys = new List<KeyScript>();
	public static List<KeyScript>[] activeKeysList = {
		null, P1ActiveKeys, P2ActiveKeys
	};

	public static void ClearActiveKeys(){
		P1ActiveKeys = new List<KeyScript>();
		P2ActiveKeys = new List<KeyScript>();
		activeKeysList[0] = null;
	}
}
