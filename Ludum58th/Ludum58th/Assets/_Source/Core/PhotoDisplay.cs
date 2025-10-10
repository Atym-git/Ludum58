using UnityEngine;

public class PhotoDisplay
{
    private GameObject _photo;

    bool _isPhotoActive = false;

    public PhotoDisplay(GameObject photo)
    {
        _photo = photo;
    }

    public void ShowPhoto()
    {
        _isPhotoActive = !_photo.activeInHierarchy;
        _photo.SetActive(_isPhotoActive);
    }
}
