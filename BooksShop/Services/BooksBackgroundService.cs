using BooksShop.Interfaces;
using BooksShop.ViewModels;

namespace BooksShop.Services
{
    public class BooksBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<BooksBackgroundService> _logger;

        public BooksBackgroundService(IServiceScopeFactory serviceScopeFactory, ILogger<BooksBackgroundService> logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Delayed book processing service starting...");

                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var bookService = scope.ServiceProvider.GetRequiredService<IBookService>();
                    // Call your BookService methods here
                    BookVm bookVm = new BookVm() {
                        PublisherId = 2,
                        Title = "some Name"
                    };
                    //await bookService.AddBookAsync(bookVm); // Replace with your actual book processing logic

                    //some logic
                }

                _logger.LogInformation("Delayed book processing completed. Waiting 15 seconds...");
                await Task.Delay(TimeSpan.FromSeconds(15), stoppingToken);
            }
        }
    }
}
