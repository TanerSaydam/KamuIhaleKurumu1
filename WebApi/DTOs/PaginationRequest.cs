namespace KIKWebApi.DTOs;

public sealed record PaginationRequest(
    int PageNumber = 0,
    int PageSize = 0,
    string Search = "");
