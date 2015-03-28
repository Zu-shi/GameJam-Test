using UnityEngine;
using System.Collections;

/// <summary>
/// Basic utility class that extends the built-in Unity MonoBehavior.
/// </summary>
/// <author>Mark Gardner, Zuoming Shi, Tyler Wallace</author>
public class _Mono : MonoBehaviour {

	private SpriteRenderer _spriteRenderer;

	public float x {
		set {
			transform.position = new Vector3 (value, transform.position.y, transform.position.z);
		}
		get {
			return transform.position.x;
		}
	}

	public float y {
		set {
			transform.position = new Vector3 (transform.position.x, value, transform.position.z);
		}
		get {
			return transform.position.y;
		}
	}

	public float z {
		set {
			transform.position = new Vector3 (transform.position.x, transform.position.y, value);
		}
		get {
			return transform.position.z;
		}
	}

	public Vector2 xy {
		set {
			transform.position = new Vector3(value.x, value.y, transform.position.z);
		}
		get {
			return new Vector2(x, y);
		}
	}

    
    public Vector2 xys {
        set {
            transform.localScale = new Vector3 (value.x, value.y, transform.localScale.z);
        }
        get {
            return new Vector2(xs, ys);
        }
    }

	public float xs {
		set {
			transform.localScale = new Vector3 (value, transform.localScale.y, transform.localScale.z);
		}
		get {
			return transform.localScale.x;
		}
	}

	public float ys {
		set {
			transform.localScale = new Vector3 (transform.localScale.x, value, transform.localScale.z);
		}
		get {
			return transform.localScale.y;
		}
	}

	public float angle {
		set {
			//transform.rotation = Quaternion.AngleAxis(value % 360, Vector3.forward);
			Quaternion rotation = Quaternion.identity;
			rotation.eulerAngles = new Vector3(0, 0, value);
			transform.rotation = rotation;
		}
		get {
			return transform.rotation.eulerAngles.z;
		}
	}

	public float alpha {
		set {
			if(spriteRenderer != null){
				Color _color = spriteRenderer.color;
				spriteRenderer.color = new Color(_color.r, _color.g, _color.b, value); 
			}
		}
		get {
			if(spriteRenderer != null){
				return spriteRenderer.color.a;
			}
			else return 0;
		}
	}

    /*
    public float rotation {
        set {
            //transform.rotation = Quaternion.AngleAxis(value % 360, Vector3.forward);
            Quaternion rotation = Quaternion.identity;
            rotation.eulerAngles = new Vector3(0, 0, value);
            transform.rotation = rotation;
        }
        get {
            return transform.rotation.eulerAngles.z;
        }
    }*/

	public float guiAlpha {
		set {
			if(GetComponent<GUITexture>() != null){
				Color _color = GetComponent<GUITexture>().color;
				GetComponent<GUITexture>().color = new Color(_color.r, _color.g, _color.b, value); 
			}
		}
		get {
			if(GetComponent<GUITexture>() != null){
				return GetComponent<GUITexture>().color.a;
			}
			else return 0;
		}
	}

    public float guiTextAlpha {
        set {
            if(GetComponent<GUIText>() != null){
                Color _color = GetComponent<GUIText>().material.color;
                GetComponent<GUIText>().material.color = new Color(_color.r, _color.g, _color.b, value); 
            }
        }
        get {
            if(GetComponent<GUIText>() != null){
                return GetComponent<GUIText>().material.color.a;
            }
            else return 0;
        }
    }

	public SpriteRenderer spriteRenderer{
		get{
			if(_spriteRenderer == null){
				_spriteRenderer = GetComponent<SpriteRenderer>();
			}
			return _spriteRenderer;
		}
	}

	public void Destroy(){
		Destroy (this.gameObject);
	}

}
