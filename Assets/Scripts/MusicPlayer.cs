using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    //Singleton Pattern for Music Player

    private void Awake()
    {
        int countMusicPlayer = FindObjectsOfType<MusicPlayer>().Length;

        if (countMusicPlayer > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
