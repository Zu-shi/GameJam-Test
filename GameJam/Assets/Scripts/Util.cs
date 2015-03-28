using UnityEngine;
using System.Collections;
using System;

public static class Utils {

	public static bool printAssertMessages = false;
    public static Vector2 OUT_OF_SCREEN = new Vector2(-100000f, -100000f);

    public static float HalfScreenWidth 
    {
        get{ return Camera.main.orthographicSize * Camera.main.aspect; }
    }

    public static float HalfScreenHeight
    {
        get{ return Camera.main.orthographicSize; }
    }

    public static Vector2 CameraPos
    {
        get{ return new Vector2(Camera.main.transform.position.x, Camera.main.transform.position.y); }
    }

    public static int RandomSign(){
        return Mathf.FloorToInt(UnityEngine.Random.Range(0f, 2f)) == 1 ? 1 : -1;
    }

	public static void Assert(bool statement, string context = ""){
		if(printAssertMessages && context != ""){
			Debug.Log(context);
		}

		if (!statement) {
			Debug.LogError("Assertion failed");
		}
	}	
    
    public static _Mono InstanceCreate(Vector2 xy, _Mono prefab){
        return InstanceCreate(xy.x, xy.y, prefab);
    }

    public static _Mono InstanceCreate(float x, float y, _Mono prefab){
        return InstanceCreate(x, y, 0, prefab);
    }

    public static _Mono InstanceCreate(float x, float y, float z, _Mono prefab){
        GameObject go = GameObject.Instantiate(prefab.gameObject, new Vector3(x, y, z), Quaternion.identity) as GameObject;
        return go.AddComponent<_Mono>();
    }

    public static T InstanceCreate<T>(Vector2 xy, T prefab) where T : UnityEngine.Component{
        T go = GameObject.Instantiate(prefab, new Vector3(xy.x, xy.y, 0), Quaternion.identity) as T;
        return go.gameObject.AddComponent<_Mono>().GetComponent<T>();
    }

    public static _Mono InstanceCreate<T>(float x, float y, float z, T prefab) where T : UnityEngine.Component{
        T go = GameObject.Instantiate(prefab.gameObject, new Vector3(x, y, z), Quaternion.identity) as T;
        return go.gameObject.AddComponent<_Mono>();
    }

    public static T RandomFromValues<T>(params T[] t){
        return (T)( t[UnityEngine.Random.Range(0, t.Length)] );
    }

    public static T RandomFromArray<T>(T[] t){
        return (T)( t[UnityEngine.Random.Range(0, t.Length)] );
    }

    public static Vector2 RandomVectorInRadius(float radius){
        float r = UnityEngine.Random.Range(0f, radius);
        float theta = UnityEngine.Random.Range(0f, 2 * Mathf.PI);
        return new Vector2(r * Mathf.Sin(theta), r * Mathf.Cos(theta));
    }

    public static float PointDistance(Vector2 v1, Vector2 v2){
        return Vector2.Distance(v1, v2);
    }

    public static float PointAngle(Vector2 v1, Vector2 v2){
        return Mathf.Atan2(v2.y - v1.y, v2.x - v1.x) * Mathf.Rad2Deg;
    }

    public static bool IsDestroyed(_Mono o){
        return (o == null || o.Equals(null));
    }
}
