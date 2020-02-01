﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComponentType { smallHand, bigHand, numbers, frame, bell, smallCog, mediumCog, bigCog}
public enum Color { red, yellow, blue}

public class ClockComponent : MonoBehaviour
{
    public ComponentType Type;
    public Color Color;
}
