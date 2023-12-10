using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource backgroundMusic;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();
        // Đảm bảo bạn đã thêm component AudioSource vào GameObject chứa script AudioManager.
    }

    public void PlayBackgroundMusic()
    {
        // Điều này sẽ chạy khi bạn muốn bắt đầu phát nhạc nền.
        backgroundMusic.Play();
    }

    public void StopBackgroundMusic()
    {
        // Gọi hàm này khi bạn muốn dừng nhạc nền.
        backgroundMusic.Stop();
    }
}