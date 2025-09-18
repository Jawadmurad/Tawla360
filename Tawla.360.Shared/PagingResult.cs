using System;

namespace Tawla._360.Shared;

public record PagingResult<T> where T : class
{
    public IEnumerable<T> Data { get; set; }
    public int Count { get; set; }
}
