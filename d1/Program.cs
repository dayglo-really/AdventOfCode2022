namespace d1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("../../../input.txt");

            string nextLine = "";
            List<int> calorieCount = new List<int>();
            int index = 0;
            bool firstNum = true;

            while (nextLine != null)
            {
                nextLine = reader.ReadLine();

                if (nextLine == null)
                {
                    reader.Close();
                    break;
                }

                else
                {
                    //If this is the start of a new set, increase the index of the iteration
                    if (nextLine == "")
                    {
                        index++;
                        firstNum = true;
                    }
                    else
                    {
                        //If it's the first number in a set, add an empty spot in the list
                        if (firstNum)
                        {
                            calorieCount.Add(0);
                            firstNum = false;
                        }

                        //Add the new value to the current index
                        calorieCount[index] = calorieCount[index] + int.Parse(nextLine);
                    }
                }
            }

            //Return the highest value
            Console.WriteLine("Highest value: " + calorieCount.Max());

            //Puzzle 2 code:

            Console.WriteLine();
            List<int> tempCalorieCount = calorieCount.GetRange(0, calorieCount.Count);
            int totalCalories = 0;

            for (int i = 0; i < 3; i++)
            {
                totalCalories += calorieCount.Max();
                calorieCount.Remove(calorieCount.Max());
            }
            Console.WriteLine("Total of top 3 elves: " + totalCalories);

        }
    }
}