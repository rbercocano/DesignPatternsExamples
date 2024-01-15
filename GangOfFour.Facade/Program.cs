using GangOfFour.Facade;

try
{
    var autoLoan = new AutoLoan(759, 10000, 7500);
    var interest = autoLoan.CalculateLoan(3000, 18000, 36);
    Console.WriteLine($"Loan Approved with {interest}% interest rate");
    Console.ReadKey();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
