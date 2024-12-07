using System.Text.Json;
using System.Collections.Generic;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE
        
        //tracking words I've already seen
        var seen = new HashSet<string>();
        //collecting pairs that match when reversed 
        var pairs = new List<string>();

        //going through each word
        foreach (var word in words)
        {
            //calculating the reverse to find the pair
            string reversedWord = new string(word.Reverse().ToArray());

            //seens if the seen set has the reversed word 
            if (seen.Contains(reversedWord))
            {
                //if yes, the pair is added to the list 
                pairs.Add($"{word} & {reversedWord}");
            }
            else
            {
                //if no, add the word to the seen set to get matched again 
                seen.Add(word);
            }
        }
        //converting the list of pairs to an array and returning it 
        return pairs.ToArray();
    }


    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        //creating a dictionary to store the info
        var degrees = new Dictionary<string, int>();
        //reading each line of the file 
        foreach (var line in File.ReadLines(filename))
        {
            //splitting the information by the commas
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE

            //getting the degree from the fourth column (index 3)
            string degree = fields[3];

            //see if the degree is already in the dictionary 
            if (degrees.ContainsKey(degree))
            {
                //if yes, increment the count for that type of education
                degrees[degree]++;
            }
            else
            {
                //if no, add it to the dictionary with the starting value of 1
                degrees[degree] = 1;
            }
        }
        //return the dictionary with the degrees summarized 
        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE
        
        //making the strings the same (lowercase and no spaces)
        word1 = word1.ToLower().Replace(" ", "");
        word2 = word2.ToLower().Replace(" ", "");
        
        //words have to be the same length
        if (word1.Length != word2.Length)
        {
            return false;
        }

        //create a dictionary to keep track of character counts for word one
        var charCount = new Dictionary<char, int>();

        //count the characters in word one
        foreach (char c in word1)
        {
            if (charCount.ContainsKey(c))
            {
                charCount[c]++;
            }
            else
            {
                charCount[c] = 1;
            }
        }

        foreach (char c in word2)
        {
            if (!charCount.ContainsKey(c))
            {
                //if a character is in word two but not word one
                return false;
            }

            charCount[c]--;

            //if a character count is below zero 
            if (charCount[c] < 0)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        //Disclaimer: I was struggling with the logic of this question so I used ChatGPT to help me, but this is my code
        var summaries = new List<string>();

        foreach (var feature in featureCollection.Features)
        {
            if (feature.Properties.Mag.HasValue && !string.IsNullOrEmpty(feature.Properties.Place))
            {
                summaries.Add($"{feature.Properties.Place} - Mag {feature.Properties.Mag:F2}");
            }
        }
        return summaries.ToArray();
    }

    public class FeatureCollection
    {
        public List<Feature> Features { get; set; }
    }

    public class Feature
    {
        public Properties Properties { get; set; }
    }

    public class Properties
    {
        public string Place { get; set; }
        public double? Mag { get; set; }
    }
}    