using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 5f;
    public float sensitiv = 1f;


    void Update()
    {
        movement();
        rotate();
    }

    void movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(x,0,z) * speed * Time.deltaTime);
    }

    void rotate()
    {
        float Mouse_X = Input.GetAxis("Mouse X");

        transform.Rotate(Mouse_X * sensitiv * transform.up);
    }
}


