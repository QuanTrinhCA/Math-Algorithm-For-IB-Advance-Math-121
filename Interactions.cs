namespace CalucalatingNumbers
{
    internal class Interactions
    {
        public static void SelectDataToView(List<List<List<double>>> formulas, List<double> valuesToMatch)
        {
            Console.WriteLine("Please select a number to view the formulas that result to that number:");
            var readLine = Console.ReadLine();
            if (readLine != null)
            {
                int selectedNumber = int.Parse(readLine);
                if (valuesToMatch.Contains(selectedNumber))
                {
                    Console.Clear();
                    Console.WriteLine("Finding formulas which results in " + selectedNumber + "...");
                    List<List<List<double>>> selectedFormulas = formulas.Where(x => x[1].Last() == selectedNumber).ToList();
                    Console.WriteLine("Found " + selectedFormulas.Count + " formulas!");
                    ParseFormulas(selectedFormulas);
                }
            }
            Console.WriteLine("Please press enter to return:");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
            Console.Clear();
            SelectDataToView(formulas, valuesToMatch);
        }
        public static void ParseFormulas(List<List<List<double>>> formulas)
        {
            foreach (List<List<double>> formula in formulas)
            {
                string outputString = "";
                if (formula[0].First() < 0)
                {
                    outputString = "(" + formula[0].First().ToString() + ")";
                }
                else
                {
                    outputString = formula[0].First().ToString();
                }
                for (int i = 0; i < formula[0].Count - 1; i++)
                {
                    switch (formula[1][i])
                    {
                        // Addition
                        case 0:
                            if (formula[0][i + 1] < 0)
                            {
                                outputString = outputString + " + " + "(" + formula[0][i + 1] + ")";
                            }
                            else
                            {
                                outputString = outputString + " + " + formula[0][i + 1];
                            }
                            break;
                        // Substraction
                        case 1:
                            if (formula[0][i + 1] < 0)
                            {
                                outputString = outputString + " - " + "(" + formula[0][i + 1] + ")";
                            }
                            else
                            {
                                outputString = outputString + " - " + formula[0][i + 1];
                            }
                            break;
                        //Multiplication
                        case 2:
                            if (formula[0][i + 1] < 0)
                            {
                                outputString = "(" + outputString + ")" + " × " + "(" + formula[0][i + 1] + ")";
                            }
                            else
                            {
                                outputString = "(" + outputString + ")" + " × " + formula[0][i + 1];
                            }
                            break;
                        //Division x/y
                        case 3:
                            if (formula[0][i + 1] < 0)
                            {
                                outputString = "(" + outputString + ")" + " ÷ " + "(" + formula[0][i + 1] + ")";
                            }
                            else
                            {
                                outputString = "(" + outputString + ")" + " ÷ " + formula[0][i + 1];
                            }
                            break;
                        //Division y/x
                        case 4:
                            if (formula[0][i + 1] < 0)
                            {
                                outputString = "(" + formula[0][i + 1] + ")" + " ÷ " + "(" + outputString + ")";
                            }
                            else
                            {
                                outputString = formula[0][i + 1] + " ÷ " + "(" + outputString + ")";
                            }
                            break;
                        //Power x^y
                        case 5:
                            if (formula[0][i + 1] < 0)
                            {
                                outputString = "(" + outputString + ")" + "^" + "(" + formula[0][i + 1] + ")";
                            }
                            else
                            {
                                outputString = "(" + outputString + ")" + "^" + formula[0][i + 1];
                            }
                            break;
                        //Power y^x
                        case 6:
                            if (formula[0][i + 1] < 0)
                            {
                                outputString = "(" + formula[0][i + 1] + ")" + "^" + "(" + outputString + ")";
                            }
                            else
                            {
                                outputString = formula[0][i + 1] + "^" + "(" + outputString + ")";
                            }
                            break;
                    }
                }
                outputString += " = " + formula[1].Last();
                Console.WriteLine(outputString);
            }
        }
    }
}
