using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public GameObject Player;         //�ǔ� �I�u�W�F�N�g
    public Vector2 rotationSpeed;           //��]���x
    private Vector3 lastMousePosition;      //�Ō�̃}�E�X���W
    private Vector3 lastTargetPosition;     //�Ō�̒ǔ��I�u�W�F�N�g�̍��W

    private float zoom;
    // Start is called before the first frame update
    void Start()
    {
        zoom = 0.0f;
        lastMousePosition = Input.mousePosition;
        lastTargetPosition = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Zoom();
    } 

    void Rotate()
    {
        transform.position += Player.transform.position - lastTargetPosition;
        lastTargetPosition = Player.transform.position;

        if (Input.GetMouseButton(1))
        {

            Vector3 nowMouseValue = Input.mousePosition - lastMousePosition;

            var newAngle = Vector3.zero;
            newAngle.x = rotationSpeed.x * nowMouseValue.x;
            newAngle.y = rotationSpeed.y * nowMouseValue.y;

            transform.RotateAround(Player.transform.position, Vector3.up, newAngle.x);
            transform.RotateAround(Player.transform.position, transform.right, -newAngle.y);
        }

        lastMousePosition = Input.mousePosition;
    }
    //�g��k��
    void Zoom()
    {
        zoom = Input.GetAxis("Mouse ScrollWheel");
        Vector3 offset = new Vector3(0, 0, 0);
        Vector3 pos = Player.transform.position - transform.position;

        if (zoom > 0)
        {
            offset = pos.normalized * 1;
        }
        else if (zoom < 0)
        {
            offset = -pos.normalized * 1;

        }
        transform.position = transform.position + offset;
    }

}
