using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] private Text locationText;
    [SerializeField] private Text locationText2;
    public int diemso = 0;
    public AudioSource collectSound; // xu ly am thanh khi va cham
    public AudioSource chamda; 
    public AudioSource anmau; 
    public AudioSource gameover; 
    private bool isHitStone = true; // trang thai va cham
    private bool stoneCollisionProcessed = false;
    public int maxHealth = 100;
    public int currentHealth = 0;
    public GameObject gameOver;
    public HealthBar healthBar;
    
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Coin")
        {
            diemso += 1;
            collectSound.Play();
            hit.gameObject.GetComponent<Coin>().Dead(); // goi ham dead tu Coin

        }
        else if (hit.gameObject.tag == "StoneLocation")
        {
            // Trừ điểm
            
            chamda.Play();
           

            // Kiểm tra xem đã xử lý va chạm với đá chưa
            if (!stoneCollisionProcessed)
            {
                StartCoroutine(EnableColliderAfterDelay(hit, 1f));
                locationText.text = "Stone: Location";
                diemso--;
                TakeDamage(34);
                // Đặt cờ để chỉ đánh giá va chạm với đá một lần
                stoneCollisionProcessed = true;
            }

            if (currentHealth <= 0)
            {
                gameover.Play();
                AudioManager.instance.StopBackgroundMusic();
                Time.timeScale = 0;
                gameOver.SetActive(true);
            }
        }

        //update len Text canvas
        if (hit.gameObject.tag == "MushroomLocation")
        {
            locationText.text = "Mushroom: Location";
        }
        if (hit.gameObject.tag == "Coin")
        {
            locationText.text = "Coin: Location";
        }
        else if (hit.gameObject.tag == "HouseLocation")
        {
            locationText.text = "House: Location";
        }
        else if (hit.gameObject.tag == "FireLocation")
        {
            locationText.text = "Fire: Location";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "blood")
        {
            anmau.Play();
            locationText.text = "Blood: Location";
            if (currentHealth < 100) // Kiểm tra xem máu hiện tại có nhỏ hơn 100 không
            {
                AddBlood(34);
            
                if (currentHealth > 100)
                {
                    currentHealth = 100; // Đảm bảo rằng currentHealth không vượt quá 100
                }

                healthBar.SetHealth(currentHealth);
            }

            Destroy(other.gameObject);
        }
    }
    
    private IEnumerator EnableColliderAfterDelay(ControllerColliderHit hit, float seconds)
    {
        // Đợi sau một khoảng thời gian
        yield return new WaitForSeconds(seconds);

        // Bật lại collider sau khi đã đợi
        hit.collider.enabled = true;

        // Đặt lại cờ isHitStone
        isHitStone = true;

        // Reset cờ xử lý va chạm đá
        stoneCollisionProcessed = false;
    }

    void Start()
    {
        AudioManager.instance.PlayBackgroundMusic();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        locationText2.text = "Điểm: " + diemso;
    }

    // Update is called once per frame
    void Update()
    {
        if (diemso < 0)
        {
            diemso = 0;
        }
        locationText2.text = "Điểm: " + diemso;
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
    
    void AddBlood(int damage)
    {
        currentHealth += damage;

        healthBar.SetHealth(currentHealth);
    }
    
    
}
