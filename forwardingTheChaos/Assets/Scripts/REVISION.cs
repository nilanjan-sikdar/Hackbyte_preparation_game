using System;
using UnityEngine;

public class REVISION : MonoBehaviour
{
    // Code Style Naming Rule

    // Constants: UpperCase SnakeCase
    public const int Constant_Field = 42;

    // Property: PascalCase
    public int PropertyField { get; set; } = 10;

    // Events: PascalCase
    public event EventHandler OnSomething;

    // Fields: camelCase
    private int privateField = 5;

    // function name : camelCase
    private void Start()
    {
        Debug.Log("Constant Field: " + Constant_Field);
    }

    // function parameters: camelCase
    private void ExampleFunction(int exampleParameter)
    {
        Debug.Log("Example Parameter: " + exampleParameter);
    }

}
