using System.Text.Json.Serialization;
using CsvHelper.Configuration.Attributes;

namespace CityOfDallasDataApp;

public class ExpenseModel
{
    [Name("budget_fiscal_year")]
    [JsonPropertyName("budget_fiscal_year")]
    public int? BudgetFiscalYear { get; set; }
    
    [Name("ftyp")]
    [JsonPropertyName("ftyp")]
    public string Ftyp { get; set; }
    
    [Name("fundtype")]
    [JsonPropertyName("fundtype")]
    public string FoundType { get; set; }
    
    [Name("appr")]
    [JsonPropertyName("appr")]
    public string Appr { get; set; }
    
    [Name("appropriation")]
    [JsonPropertyName("appropriation")]
    public string Appropriation { get; set; }
    
    [Name("service_number")]
    [JsonPropertyName("service_number")]
    public string ServiceNumber { get; set; }
    
    [Name("service")]
    [JsonPropertyName("service")]
    public string Service { get; set; }
    
    [Name("objectgroup")]
    [JsonPropertyName("objectgroup")]
    public string ObjectGroup { get; set; }
    
    [Name("expenditure_classification")]
    [JsonPropertyName("expenditure_classification")]
    public string ExpenditureClassification { get; set; }
    
    [Name("current_budget")]
    [JsonPropertyName("current_budget")]
    public int CurrentBudget { get; set; }
    
    [Name("encumbrance")]
    [JsonPropertyName("encumbrance")]
    public double? Encumbrance { get; set; }
    
    [Name("expenses")]
    [JsonPropertyName("expenses")]
    public double? Expenses { get; set; }
    
    [Name("encumb_expense")]
    [JsonPropertyName("encumb_expense")]
    public double? EncumbExpense { get; set; }

    public override string ToString() => 
        BudgetFiscalYear + " " + Ftyp + " " + Appr + " " + Appropriation + " " + Encumbrance + " " +
        Expenses + " " + Service + " " + CurrentBudget + " " + EncumbExpense + " " + ExpenditureClassification + " " +
        FoundType + " " + ServiceNumber + " " + ObjectGroup;
}