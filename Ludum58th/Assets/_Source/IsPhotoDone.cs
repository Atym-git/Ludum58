using System;
using System.Collections.Generic;

public class IsPhotoDone
{
    private List<Slot> _slots = new();

    private int _itemsDone = 0;

    private GameEnder _gameEnder;

    public IsPhotoDone(List<Slot> slots, GameEnder gameEnder)
    {
        _slots = slots;
        _gameEnder = gameEnder;
    }

    public bool IsPartDone(List<Slot> slots)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            _itemsDone += Convert.ToInt32(slots[i].IsPartDone);
            if (_itemsDone == slots.Count)
            {
                if (IsPartDone(_slots))
                {
                    _gameEnder.ConstructPhotoDone();
                }
                return true;
            }
        }
        _itemsDone = 0;
        return false;
    }
}
