using CalucalatingNumbers;

List<double> inputNumbers = new() { 2, 5, 6, 7 };
List<double> valuesToMatch = new();
for (int i = 0; i < 101; i++)
{
    valuesToMatch.Add(i);   //Generate the values to match list
}

Interactions.SelectDataToView(Calculations.GetAllPossibleFormulas(inputNumbers, valuesToMatch), valuesToMatch);