using UnityEngine;
using UnityEngine.UI;

public class right : MonoBehaviour
{
    public Transform camera;
    private static Vector3 target_position;
    public Text text;
    public float pos_x = 4f;
    public float speed = 4f;
    public float initialCoins = 100f; // Начальное количество монет
    public float coins; 

    private void Start()
    {
        if (camera != null)
            target_position = camera.position;
        
        coins = initialCoins + (target_position.x / pos_x) * 100f; 
        UpdateCoinText();
    }

    public void OnClick_Right()
    {
        target_position += new Vector3(pos_x, 0f, 0f);
        coins = initialCoins + (target_position.x / pos_x) * 100f; // Обновляем coins
        UpdateCoinText();
    }
    
    public void OnClick_Left()
    {
        
        target_position += new Vector3(-pos_x, 0f, 0f);
        coins = initialCoins + (target_position.x / pos_x) * 100f; // Обновляем coins
        UpdateCoinText();
    }

    private void Update()
    {
        if (camera != null)
            camera.position = Vector3.MoveTowards(camera.position, target_position, speed * Time.deltaTime);
    }

    private void UpdateCoinText()
    {
        if (text != null)
        {
            text.text = coins.ToString("0") + " Монет"; // Используем поле coins
        }
    }
}