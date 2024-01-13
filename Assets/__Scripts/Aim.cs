using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    private Vector3 _directionFromPlayerToAim;
    [SerializeField] private bool backwards = false;


    public Vector3 directionFromPlayerToAim
    {
        get
        {
            return _directionFromPlayerToAim;
        }
        set
        {
            _directionFromPlayerToAim = value;
            IsAimLooksBack(directionFromPlayerToAim);
        }
    }


    private void IsAimLooksBack(Vector3 directionFromPlayerToAim)
    {
        if (directionFromPlayerToAim.x < 0)
        {
            if (backwards == false)
            {
                TurnBackwards();
            }

        }

        else if (directionFromPlayerToAim.x > 0)
        {
            if (backwards == true)
            {
                TurnBackwards();
            }

        }

    }

    private void TurnBackwards()
    {
        backwards = !backwards;
    }



}
