using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode._2021.Day14;

public static class Day14Common
{

    public static (List<char> polymer, Dictionary<string, char> insertionRules) ParseInput(string[] input)
    {
        var insertionRules = new Dictionary<string, char>();

        input
            .Skip(2)
            .ToList()
            .ForEach(rule =>
            {
                var ruleData = rule.Split(" -> ");
                insertionRules.Add(ruleData[0], ruleData[1].ToList().First());
            });
        
        return (input.First().ToList(), insertionRules);
    }

    public static List<char> RunPolymerizationStep(List<char> startingPolymer, Dictionary<string, char> insertionRules)
    {
        var finalPolymer = new List<char>();
        var listOfGroups = new List<string>();

        var polymerChars = startingPolymer.ToArray();

        for (var i = 0; i < startingPolymer.Count - 1; i++)
        {
            var twoChars = new string(polymerChars, i, 2);
            listOfGroups.Add(twoChars);
        }

        finalPolymer.Add(startingPolymer.First());
        
        foreach (var group in listOfGroups)
        {
            if (!insertionRules.ContainsKey(group)) continue;
            
            finalPolymer.Add(insertionRules[group]);
            finalPolymer.Add(group.Last());
        }
        
        return finalPolymer;
    }

    public static long GetElementScore(List<char> polymer)
    {
        var elementCount = new Dictionary<char, long>();

        for (var i = 0; i < polymer.Count; i++)
        {
            if(!elementCount.ContainsKey(polymer[i])) elementCount.Add(polymer[i], 0);
            elementCount[polymer[i]]++;
        }

        return elementCount.Values.Max() - elementCount.Values.Min();
    }
    
}