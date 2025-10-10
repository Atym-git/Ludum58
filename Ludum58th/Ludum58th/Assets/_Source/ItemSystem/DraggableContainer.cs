using UnityEngine;

public class DraggableContainer
{
    public static GameObject DraggableItem { get; set; }

    public static bool IsDragging { get; set; }

    public static int ItemsWhichDurDidntPass { get; set; }
}
