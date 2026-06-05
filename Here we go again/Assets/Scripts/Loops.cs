using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Globalization;

public class Loops : MonoBehaviour
{
   
    public bool isLooped;
    public bool hasDelhi;
    public bool hasDubai;
    public int intelligence = 67;
    public string leading;
   

    public enum spacial
    {
        hase5haa534h,
        tgy98wegfQP9I,
        AWESYFUWIFEAgiu,
        efiuefgueiwf,
        efgvvuvw,
        vfqevfivbsduvg,
        ehggerv4hrvhergoehgrihoefrb,
        rvrwubvuiwbvibwerivbwvbwibve,
        r4yvv5ybvy5y43gyevhwve,
        bbewrcgecv

    }

    
    void Start()
    {
        List<string> loops = new List<string>();
        List<double> marathons = new List<double>();
        List<string> citiesList = new List<string> { "Delhi", "Los Angeles" };
        int numberCitiesList = citiesList.Count;
        Console.WriteLine(marathons.Count);
        marathons.Add(143.23);
        Console.WriteLine(marathons.Contains(143.23));
        Console.WriteLine(marathons.Count);
        Console.WriteLine(marathons.Count());
        bool success = citiesList.Remove("Delhi)");
        Console.WriteLine(marathons[1]);
        bool removed = marathons.Remove(143.12);
        Console.WriteLine(marathons[1]);
        Console.WriteLine(removed);

        List<bool> b = new List<bool>();
        List<IServiceProvider> i = new List<IServiceProvider>();

        citiesList.Add("New York City");

        foreach (string city in citiesList)
        {
            Console.WriteLine($"Welcome to...{city}!");
        }
        


        



        



        bool hasDelhi = citiesList.Contains("Delhi");
        bool hasDubai = citiesList.Contains("Dubai");
        {
            Console.WriteLine("Speech imbedded");
            Console.WriteLine("Speech encapsulated");


        }
        if (isLooped != false)
        {
            Console.WriteLine("It is inactive");
        }
    }



    void Update()
    {
        
    }

    void Calculator()
    {
        

    }

 
}
