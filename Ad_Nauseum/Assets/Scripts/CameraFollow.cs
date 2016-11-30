using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{


    public GameObject follow;
    public float followSpeed;
    Vector3 position;
    protected new Camera camera;
    public int top = 30;
    public int bottom = -10;

	public float centerMod = .2f;
	private float posMod;
    // Use this for initialization
    void Start()
    {
        camera = GetComponent<Camera>();
        this.follow = GameObject.Find("Player");
		posMod = 1;
    }

    // Update is called once per frame
    void LateUpdate()
    {


        position = new Vector3(Mathf.Lerp(this.transform.position.x, follow.transform.position.x, followSpeed * Time.fixedDeltaTime),
        Mathf.Lerp(this.transform.position.y, follow.transform.position.y, followSpeed * Time.fixedDeltaTime),
        this.transform.position.z);

        if (position.y + camera.orthographicSize > top)
        {
            position.y = top - camera.orthographicSize;
        }
        else if (position.y - camera.orthographicSize < bottom)
        {
            position.y = bottom + camera.orthographicSize;
        }

		if (Movement.turn) {
			posMod = -1;
		} else {
			posMod = 1;
		}


		position.x = follow.transform.position.x + (posMod * centerMod * (camera.orthographicSize * camera.aspect));
		position.x = Mathf.Lerp (this.transform.position.x, position.x, followSpeed * Time.fixedDeltaTime);
        this.transform.position = position;
    }
}
