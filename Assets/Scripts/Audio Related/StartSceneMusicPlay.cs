using UnityEngine;

public class StartSceneMusicPlay : MonoBehaviour
{
    [SerializeField] private string musicName;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayMusic(musicName);
    }
}
