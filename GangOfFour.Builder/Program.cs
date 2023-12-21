ReportDirector reportDirector = new();

// Financial report
IReportBuilder financialBuilder = new FinancialReportBuilder();
reportDirector.SetReportBuilder(financialBuilder);
reportDirector.ConstructReport();
Report financialReport = financialBuilder.GetReport();
financialReport.Display();

Console.WriteLine();

// Sales report
IReportBuilder salesBuilder = new SalesReportBuilder();
reportDirector.SetReportBuilder(salesBuilder);
reportDirector.ConstructReport();
Report salesReport = salesBuilder.GetReport();
salesReport.Display();

Console.ReadKey();
class Report
{
    public string Header { get; set; }
    public string Footer { get; set; }
    public List<Tuple<string, decimal, DateTime>> Table { get; set; } = new List<Tuple<string, decimal, DateTime>>();

    public void Display()
    {
        Console.WriteLine(Header);
        Console.WriteLine($"{"Description",-30}{"Amount",-10}{"Date",-30}");
        foreach (var item in Table)
            Console.WriteLine($"{item.Item1,-30}{item.Item2,-10}{item.Item3,-30}");
        Console.WriteLine(Footer);
    }
}

// Abstract Builder: ReportBuilder
interface IReportBuilder
{
    void BuildHeader();
    void BuildFooter();
    void BuildTable();
    Report GetReport();
}

// Concrete Builder: FinancialReportBuilder
class FinancialReportBuilder : IReportBuilder
{
    private Report report = new Report();

    public void BuildHeader()
    {
        report.Header = "Financial Report Header";
    }

    public void BuildFooter()
    {
        report.Footer = "Financial Report Footer";
    }

    public void BuildTable()
    {
        report.Table.Add(new Tuple<string, decimal, DateTime>("Expense 01", 159.99M, DateTime.Now.AddDays(-2)));
        report.Table.Add(new Tuple<string, decimal, DateTime>("Expense 02", 87.99M, DateTime.Now.AddDays(-7)));
        report.Table.Add(new Tuple<string, decimal, DateTime>("Expense 03", 1588.00M, DateTime.Now.AddDays(-15)));
        report.Table.Add(new Tuple<string, decimal, DateTime>("Expense 04", 199.59M, DateTime.Now.AddDays(-18)));
    }
    public Report GetReport()
    {
        return report;
    }
}
// Concrete Builder: SalesReportBuilder
class SalesReportBuilder : IReportBuilder
{
    private Report report = new Report();


    public void BuildHeader()
    {
        report.Header = "Sales Report Header";
    }

    public void BuildFooter()
    {
        report.Footer = "Sales Report Footer";
    }


    public void BuildTable()
    {
        report.Table.Add(new Tuple<string, decimal, DateTime>("Sale 01", 877.99M, DateTime.Now.AddDays(-2)));
        report.Table.Add(new Tuple<string, decimal, DateTime>("Sale 02", 5899.99M, DateTime.Now.AddDays(-7)));
        report.Table.Add(new Tuple<string, decimal, DateTime>("Sale 03", 855.00M, DateTime.Now.AddDays(-15)));
        report.Table.Add(new Tuple<string, decimal, DateTime>("Sale 04", 9987.59M, DateTime.Now.AddDays(-18)));
    }
    public Report GetReport()
    {
        return report;
    }
}



// Director: ReportDirector
class ReportDirector
{
    private IReportBuilder reportBuilder;

    public void SetReportBuilder(IReportBuilder builder)
    {
        reportBuilder = builder;
    }

    public void ConstructReport()
    {
        reportBuilder.BuildHeader();
        reportBuilder.BuildFooter();
        reportBuilder.BuildTable();
    }
}