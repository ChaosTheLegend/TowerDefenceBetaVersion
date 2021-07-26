using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowersContainer : MonoBehaviour
{
    [SerializeField] private TowerArrow _arrow;
    public TowerArrow Arrow => _arrow;
}
