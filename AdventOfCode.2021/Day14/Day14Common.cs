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

    public static List<char> RunPolymerizationStep_Part1(List<char> startingPolymer, Dictionary<string, char> insertionRules)
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
    
    public static Dictionary<string, long> RunPolymerizationForXSteps(int steps, string startingPolymer, Dictionary<string, char> insertionRules)
    {
        var polymerGroups = new Dictionary<string, long>();

        for (var i = 0; i < startingPolymer.Length - 1; i++)
        {
            var group = startingPolymer.Substring(i, 2);
            if(!polymerGroups.ContainsKey(group)) polymerGroups.Add(group, 0);

            polymerGroups[group]++;
        }

        for (var step = 0; step < steps; step++)
        {
            var newPolymerGroup = new Dictionary<string, long>();
            var visitedGroups = new List<string>();
            
            foreach (var (ruleKey, ruleVal) in insertionRules)
            {
                if(!polymerGroups.ContainsKey(ruleKey)) continue;
                
                var rulePairCount = polymerGroups[ruleKey];
                var firstNewGroup = $"{ruleKey.First()}{ruleVal}";
                var secondNewGroup = $"{ruleVal}{ruleKey.Last()}";
                
                if(!newPolymerGroup.ContainsKey(firstNewGroup)) newPolymerGroup.Add(firstNewGroup, 0);
                if(!newPolymerGroup.ContainsKey(secondNewGroup)) newPolymerGroup.Add(secondNewGroup, 0);

                newPolymerGroup[firstNewGroup] += rulePairCount;
                newPolymerGroup[secondNewGroup] += rulePairCount;
                
                visitedGroups.Add(ruleKey);
            }
            
            polymerGroups.Keys.Except(visitedGroups).ToList().ForEach(it => newPolymerGroup.Add(it, polymerGroups[it]));

            polymerGroups = newPolymerGroup;
        }

        return polymerGroups
            .Where(it => it.Value > 0)
            .ToDictionary(it => it.Key, it => it.Value);
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
    
    public static long GetElementScore_Part2(string startingPolymer, Dictionary<string, long> polymerGroups)
    {
        var polymer = new Dictionary<string, long>();

        foreach (var group in polymerGroups)
        {
            var firstOfGroup = $"{group.Key.First()}";
            if(!polymer.ContainsKey(firstOfGroup)) polymer.Add(firstOfGroup, 0);

            polymer[firstOfGroup] += group.Value;
        }

        var lastElement = $"{startingPolymer.Last()}";
        if(!polymer.ContainsKey(lastElement)) polymer.Add(lastElement, 0);
        polymer[lastElement]++;
        
        return polymer.Values.Max() - polymer.Values.Min();
    }
    
}