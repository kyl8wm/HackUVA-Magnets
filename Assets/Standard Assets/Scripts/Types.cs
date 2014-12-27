using UnityEngine;
using System.Collections;

public class Tuple <T,T1> {

    public T item1;
    public T1 item2;

    public Tuple (T param1, T1 param2)
    {
        this.item1 = param1;
        this.item2 = param2;
    }

}

public delegate void ChoiceDelegate();

	

