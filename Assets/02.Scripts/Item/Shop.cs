using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private SpriteRenderer shopImage;
    public Sprite image;
    public GameObject UI;
    Rigidbody2D rb;
    public void Awake()
    {
        shopImage = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponentInParent<Rigidbody2D>();
        shopImage.sprite = image;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("충돌out");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("충돌in");

            UI.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        UI.SetActive(false);
    }
} 