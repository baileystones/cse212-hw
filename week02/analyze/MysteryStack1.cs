public static class MysteryStack1 {
    public static string Run(string text) {
        //Creating a stack, LIFO
        var stack = new Stack<char>();
        //Every character in the text is pushed into the stack
        foreach (var letter in text)
            stack.Push(letter);
        //Start with empty string
        var result = "";
        //As long as the stack is not empty loop runs
        //Characters are popped from reverse order they were added
        while (stack.Count > 0)
            result += stack.Pop();
        //Returns reversed input string
        return result;
    }
}