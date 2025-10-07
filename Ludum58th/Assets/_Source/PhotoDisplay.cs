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
        Debug.Log($"Showing photo; PhotoGO = {_photo}; Bool IsPhotoActive = {_isPhotoActive}");
        _isPhotoActive = !_isPhotoActive;
        _photo.SetActive(_isPhotoActive);
    }
}
