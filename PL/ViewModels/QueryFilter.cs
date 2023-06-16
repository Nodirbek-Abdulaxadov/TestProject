namespace PL.ViewModels;

public record QueryFilter (
    string? searchText,
    OperatorCode? operatorCode,
    DateTime? startDate,
    DateTime? endDate,
    int? startAge = 0,
    int? endAge = 0
);