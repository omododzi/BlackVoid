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
    public GameObject obj;

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
        coins = Mathf.Clamp(initialCoins + (target_position.x / pos_x) * 100f, 0, 1000000000);; // Обновляем coins
        
        UpdateCoinText();
    }
    
    public void OnClick_Left()
    {
        target_position += new Vector3(-pos_x, 0f, 0f);
        coins = Mathf.Clamp(initialCoins + (target_position.x / pos_x) * 100f, 0, 1000000000); // Обновляем coins
        
        UpdateCoinText();
    }

    private void Update()
    {
        Vector3 pos = new Vector3(0, 0, 0);

        
        if (pos.x == camera.position.x)
        {
            obj.SetActive(false);
        }
        else
        {
            obj.SetActive(true);
        }
        
        if (camera != null)
            camera.position = Vector3.MoveTowards(camera.position, target_position, speed * Time.deltaTime);
    }

    private void UpdateCoinText()
    {
        if (text != null)
        {
            text.text = coins.ToString("0") + " Монет"; 
        }
    }
}