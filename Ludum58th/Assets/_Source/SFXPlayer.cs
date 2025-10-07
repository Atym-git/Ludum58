using UnityEngine;

public class SFXPlayer
{
    private AudioSource _sFXPlayerPrefab;

    public SFXPlayer(AudioSource sFXPlayer)
    {
        _sFXPlayerPrefab = sFXPlayer;
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnedGoTransform, float volume)
    {
        AudioSource audioSource = Object.Instantiate(_sFXPlayerPrefab, spawnedGoTransform.position, Quaternion.identity);

        audioSource.clip = audioClip;

        audioSource.volume = volume;

        audioSource.Play();

        float clipLength = audioClip.length;

        Object.Destroy(audioSource.gameObject, clipLength);
    }
}
