using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEquipment : MonoBehaviour
{
    public SpriteRenderer[] spriteRenderers;

    public void RotateDown()
    {
        foreach (SpriteRenderer sprite in spriteRenderers)
        {
            //sprite.transform.rotation = new Vector3(90, 0, 0);
        }
    }
}
