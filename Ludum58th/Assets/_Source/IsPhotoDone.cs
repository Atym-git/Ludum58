using System;
using System.Collections.Generic;
using UnityEngine;

public class IsPhotoDone
{
    private List<Slot> _wholePhotoSlots = new();

    //private int _itemsDone = 0;

    private GameEnder _gameEnder;

    public IsPhotoDone(List<Slot> slots, GameEnder gameEnder)
    {
        _wholePhotoSlots = slots;
        _gameEnder = gameEnder;
    }

    public bool IsPartDone(List<Slot> slots)
    {
        int itemsDone = 0;
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].IsPartDone) itemsDone++;
        }

        if (itemsDone == slots.Count)
        {
            return true;
        }
        return false;
    }

    public void CheckFullPhoto()
    {
        if (IsPartDone(_wholePhotoSlots))
        {
            _gameEnder.ConstructPhotoDone();
        }
    }
}
