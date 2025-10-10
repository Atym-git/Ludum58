using UnityEngine;

public class LayerMaskUtil
{
    public static bool ContainsLayer(LayerMask layerMask,
                                     GameObject gameObject)
    {
        return (layerMask.value & 1 << gameObject.layer) > 0;
    }
}
