using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISensor
{
    public string Name { get; set; }
    public bool HasContact();
}
