using UnityEngine;
using UnityEngine.EventSystems;

public class CameraFollow : MonoBehaviour
{
    [Header("Настройки камеры")]
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public bool lockCursor = true;
    
    [Header("Ограничения")]
    public float minVerticalAngle = -90f;
    public float maxVerticalAngle = 90f;

    private float xRotation = 0f;

    void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Update()
    {
        // Получаем ввод мыши
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Вертикальный поворот (вверх/вниз)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minVerticalAngle, maxVerticalAngle);

        // Применяем поворот камеры
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        
        // Горизонтальный поворот персонажа (влево/вправо)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
