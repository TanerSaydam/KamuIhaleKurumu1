namespace _01.MyFirstApi.Dtos;

public sealed record Request(
    int PageNumber = 1,
    int PageSize = 10,
    string Search = "",
    string ColumnName = "",
    bool Reverse = false);
 