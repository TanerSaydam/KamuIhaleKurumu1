namespace _01.MyFirstApi.Dtos;

public sealed class PaginationResult<T>
    where T : class
{    
    public PaginationResult(List<T> datas, int pageNumber, int pageSize, int count)
    {
        Datas = datas;
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        IsFirstPage = pageNumber == 1;
        IsLastPage = pageNumber == TotalPages;
    }

    public List<T> Datas { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public bool IsFirstPage { get; set; }
    public bool IsLastPage { get; set; }
}
