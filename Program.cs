using System;
using System.Collections.Generic;

public class Solution
{
    public int[] AsteroidCollision(int[] asteroids)
    {
        Stack<int> stack = new Stack<int>();

        foreach (int asteroid in asteroids)
        {
            bool exploded = false;
            while (stack.Count > 0 && asteroid < 0 && stack.Peek() > 0)
            {
                int top = stack.Peek();
                if (top < -asteroid)
                {
                    stack.Pop();
                    continue;
                }
                else if (top == -asteroid)
                {
                    stack.Pop();
                    exploded = true;
                    break;
                }
                else
                {
                    exploded = true;
                    break;
                }
            }
            if (!exploded)
            {
                stack.Push(asteroid);
            }
        }

        int[] result = stack.ToArray();
        Array.Reverse(result);
        return result;
    }
}

class Program
{
    static void Main()
    {
        Solution solution = new Solution();

        int[] asteroids1 = { 5, 10, -5 };
        Console.WriteLine(string.Join(", ", solution.AsteroidCollision(asteroids1)));

        int[] asteroids2 = { 8, -8 };
        Console.WriteLine(string.Join(", ", solution.AsteroidCollision(asteroids2)));

        int[] asteroids3 = { 10, 2, -5 };
        Console.WriteLine(string.Join(", ", solution.AsteroidCollision(asteroids3)));

        int[] asteroids4 = { -2, -1, 1, 2 };
        Console.WriteLine(string.Join(", ", solution.AsteroidCollision(asteroids4)));
    }
}
