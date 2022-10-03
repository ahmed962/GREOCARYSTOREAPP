using System;
using System.Collections.Generic;
using System.Globalization;
using System.Transactions;

public class Smoothie
{
    List<string> order = new List<string>();
    double cost = 0;
    Dictionary<string, double> prices = new Dictionary<string, double>()
        {
            {"strawberry", 1.50 },
            {"banana", 0.50 },
            {"mango", 2.50 },
            {"blueberry", 1.00 },
            {"peache", 1.00 },
            {"apple", 1.75 },
            {"orange", 3.50 }

        };
    public Smoothie(List<string> _order)
    {
        order = _order;
    }

    public double GetCost()
    {
        foreach (var element in order)
            if (prices.ContainsKey(element))
            {
                cost += prices[element];
            }

        return cost;
    }

    public string GetPrice(double _cost)
    {
        double price = _cost * 1.5;
        return price.ToString("C", CultureInfo.CurrentCulture);
    }

    public string GetName()
    {
        order.Sort();

        string name = "";

        foreach (var element in order)
        {
            string adjelement = element;
            if (element.EndsWith("ies"))
            {

                adjelement = element.Replace("ies", "y");

            }
            if (String.Compare(name, "") != 0)
            {
                name = name + " " + adjelement;
            }

            else
            {
                name = adjelement;
            }
        }

        if (order.Count == 1)
        {
            name = name + "Smoothie";
        }

        else
        {
            name = name + " Fusion";
        }
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name);
    }


}

public class MainClass
{
    public static void Main(string[] args)
    {
        List<string> order = new List<string>();
        Smoothie ingredients = new Smoothie(order);
        string ingredient = "-1";

        do
        {
            Console.WriteLine("Please give ingredient: ");
            ingredient = Console.ReadLine();
            order.Add(ingredient);
        } while (ingredient != string.Empty);

        Console.WriteLine(ingredients.GetCost().ToString("C", CultureInfo.CurrentCulture));
        Console.WriteLine(ingredients.GetPrice(ingredients.GetCost()));
        Console.WriteLine(ingredients.GetName());
    }
}

