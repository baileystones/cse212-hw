public static class MysteryStack2 {
    
    //Makes sure string can be float
    private static bool IsFloat(string text) {
        return float.TryParse(text, out _);
    }

    public static float Run(string text) {
        //Make a stack (LIFO)
        var stack = new Stack<float>();
        //Splitting up the input string based on the space in-between
        foreach (var item in text.Split(' ')) {
            if (item == "+" || item == "-" || item == "*" || item == "/") {
                //Make sure there are at least 2 numbers in stack 
                if (stack.Count < 2)
                    throw new ApplicationException("Invalid Case 1!");
                //Most recent number popped first
                var op2 = stack.Pop();
                //Second recent number
                var op1 = stack.Pop();
                //Declaring a result float variable 
                float res;
                //Do the math
                if (item == "+") {
                    res = op1 + op2;
                }
                else if (item == "-") {
                    res = op1 - op2;
                }
                else if (item == "*") {
                    res = op1 * op2;
                }
                else {
                    // Can't divide by zero
                    if (op2 == 0)
                        throw new ApplicationException("Invalid Case 2!");

                    res = op1 / op2;
                }
                //Results pushed back into stack
                stack.Push(res);
            }
            //If a valid number, converted to float and pushed to stack
            else if (IsFloat(item)) {
                stack.Push(float.Parse(item));
            }
            //Checks if empty string and does nothing if so
            else if (item == "") {
            }
            //Anything else that isn't a valid operator, #, or empty string is invalid
            else {
                throw new ApplicationException("Invalid Case 3!");
            }
        }
        //The stack should have one number at the end
        if (stack.Count != 1)
            throw new ApplicationException("Invalid Case 4!");
        //Final result popped and returned as result
        return stack.Pop();
    }
}