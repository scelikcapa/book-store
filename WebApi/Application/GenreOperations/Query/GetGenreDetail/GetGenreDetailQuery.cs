using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Query.GetGenreDetail;
public class GetGenreDetailQuery
{
    private readonly BookStoreDbContext context;
    private readonly IMapper mapper;
    public int GenreId { get; set; }

    public GetGenreDetailQuery(BookStoreDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public GetGenreDetailViewModel Handle()
    {
        var genre = context.Genres.SingleOrDefault(g => g.IsActive == true && g.Id == GenreId);
        if (genre is null)
            throw new InvalidOperationException("Kitap Türü bulunamadı");
        return mapper.Map<GetGenreDetailViewModel>(genre);
    }
}

public class GetGenreDetailViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
}