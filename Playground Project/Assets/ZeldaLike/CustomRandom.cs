using UnityEngine;
using System.Collections;

public class CustomRandom : MonoBehaviour {

    public const uint MaxUInt = 4294967295;

    public uint initialSeed = 0;
    public uint randomNumber;
    //private uint lastRandom;

    public float testMin = Mathf.Infinity;
    public float testMax = -Mathf.Infinity;

    public uint[] testArray = new uint[8];
    public float[] testArray2 = new float[100];

    // Use this for initialization
    void Start ()
    {
        ResetToSeed();
    }
	
	/*void Update ()
    {
	    if (Input.GetButtonDown("Jump"))
        {
            RandomList();
        }
        RandomList();
    }*/

    public static uint CoreGenerator(uint input)
    {
        uint store = input;// Initial Value

        uint left = store ^ (store << 16);// Store XOR Right 2 Bytes of Store on the left, set as Left

        store = ByteReverse(left);// Reverse the Bytes of Left, Set as Store

        left = store ^ (((left << 16) >> 16) << 1);// Store XOR Right half of Left shifted 1 bit left, set as Left

        // 11111111,11111111,10000000,00000000
        uint right = 4294934528 ^ (left >> 1);// Constant 1 XOR Left shifted 1 bit right, set as Right

        if ((left << 31) >> 31 == 1)
        {
            // 10000000,00000000,11110000,00001000
            store = 2147545096 ^ right;// If last bit of Left is 1, Constant 2a XOR Right, set as Store
        }
        else
        {
            // 00000111,11111100,00000001,00000111
            store = 133955847 ^ right;// if last bit of left is 0, Constant 2b XOR Right, set as Store
        }

        return store;
    }

    // Base Random Number Generator
    [ContextMenu("Randomize")]
    public uint Randomize()
    {
        /*uint store = randomNumber;// Initial Value
        //Debug.Log("RNG Store 1: " + store);
        
        uint left = store ^ (store << 16);// Store XOR Right 2 Bytes of Store on the left, set as Left
        //Debug.Log("RNG Left 1: " + left);
        
        store = ByteReverse(left);// Reverse the Bytes of Left, Set as Store
        //Debug.Log("RNG Store 2(Reverse Left 1): " + store);
        
        left = store ^ (((left << 16) >> 16) << 1);// Store XOR Right half of Left shifted 1 bit left, set as Left
        //Debug.Log("RNG Left 2: " + left);
        
        //uint overHalf = 4294934528; //11111111,11111111,10000000,00000000
        uint right = 4294934528 ^ (left >> 1);// Constant 1 XOR Left shifted 1 bit right, set as Right
        //Debug.Log("RNG Right 1: " + right);
        
        
        if ((left << 31) >> 31 == 1)
        {
            // 10000000,00000000,11110000,00001000
            store = 2147545096 ^ right;// If last bit of Left is 1, Constant 2a XOR Right, set as Store
            //Debug.Log("RNG Store 3(1): " + store);
        }
        else
        {
            // 00000111,11111100,00000001,00000111
            store = 133955847 ^ right;// if last bit of left is 0, Constant 2b XOR Right, set as Store
            //Debug.Log("RNG Store 3(0): " + store);
        }
        
        // Check if output resulted in the same value as input
        if (store == lastRandom)
        {
            Debug.LogWarning("Looping Value! " + store);
            store++;
        }
        // Return Store
        lastRandom = store;
        randomNumber = store;*/
        uint newNumber = CoreGenerator(randomNumber);
        /*if (newNumber == lastRandom)
        {
            Debug.LogWarning("Looping Value! " + newNumber);
            newNumber++;
        }*/
        //lastRandom = newNumber;
        randomNumber = newNumber;

        return randomNumber;
    }

    [ContextMenu("Reset")]
    public void ResetToSeed()
    {
        randomNumber = initialSeed;
        //lastRandom = randomNumber;
    }

    /*[ContextMenu("List")]
    public void RandomList()
    {
        for (int i = 0; i < 8; i++)
        {
            testArray[i] = Randomize();
            //testArray2[i] = FloatRange(0, 100);
        }

        for (int i = 0; i < 100; i++)
        {
            float newFloat = FloatRange(0, 100);
            if (newFloat < testMin)
            {
                testMin = newFloat;
            }
            if (newFloat > testMax)
            {
                testMax = newFloat;
            }
            testArray2[i] = newFloat;
        }
    }*/

    /*public float FloatRange(float min, float max)
    {
        float random = (float)Randomize();
        float normal = random / MaxUInt;

        return normal * max;
    }*/

    public static uint ByteReverse(uint input)
    {
        byte[] data = new byte[4];
        data[0] = (byte)input;
        data[1] = (byte)(input >> 8);
        data[2] = (byte)(input >> 16);
        data[3] = (byte)(input >> 24);

        byte[] reverse = new byte[4];
        reverse[0] = data[3];
        reverse[1] = data[2];
        reverse[2] = data[1];
        reverse[3] = data[0];

        //Debug.Log("Byte Reverse: " + data[0] + ", " + data[1] + ", " + data[2] + ", " + data[3] + " >> " + reverse[0] + ", " + reverse[1] + ", " + reverse[2] + ", " + reverse[3]);
        return (uint)reverse[0] + ((uint)reverse[1] << 8) + ((uint)reverse[2] << 16) + ((uint)reverse[3] << 24);
    }
}
