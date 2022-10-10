using GematriaCalculator.Data;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GematriaCalculator.Filters
{
    public class DataFilter : IAsyncPageFilter
    {
        private readonly StrongsDbContext _dbContext;

        public DataFilter(StrongsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
        {
            if (ApplicationData.Gematrias == null)
                ApplicationData.Gematrias = _dbContext.Gematrias.ToList();

            if (ApplicationData.Greeks == null)
                ApplicationData.Greeks = _dbContext.Greeks.ToList();

            if (ApplicationData.Hebrews == null)
                ApplicationData.Hebrews = _dbContext.Hebrews.ToList();

            if (ApplicationData.Isopsephys == null)
                ApplicationData.Isopsephys = _dbContext.Isopsephys.ToList();

            if (ApplicationData.Strongs == null)
                ApplicationData.Strongs = _dbContext.Strongs.ToList();

            return Task.CompletedTask;
        }

        public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
        {
            await next.Invoke();
        }
    }
}
