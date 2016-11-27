using UnityEngine;

[ExecuteInEditMode]
public class SortingScript : MonoBehaviour
{
	public float offset = 0f;
	private float yTop = 5f;
	private float yBottom = -5f;

    private float zTop = 0;
    private float zBottom = -3;


    private float zTopLayer = -3;
    private float zBottomLayer = -4;

    public bool IsTopLayer;

    void Update()
	{
		if (transform.position.y <= yTop || transform.position.y >= yBottom)
        {
            float zT = zTop;
            float zB = zBottom;
            if (IsTopLayer)
            {
                zT = zTopLayer;
                zB = zBottomLayer;
            }
			float z = (((zT - zB) * (transform.position.y - yBottom)) / (yTop - yBottom)) + zB + offset;

			Vector3 newpos = new Vector3(transform.position.x, transform.position.y, z);
			transform.position = newpos;

		}
	}

    public float GetZatPosition(float y)
    {
        float zT = zTop;
        float zB = zBottom;
        if (IsTopLayer)
        {
            zT = zTopLayer;
            zB = zBottomLayer;
        }
        return (((zT - zB) * (y - yBottom)) / (yTop - yBottom)) + zB + offset;
    }
}
