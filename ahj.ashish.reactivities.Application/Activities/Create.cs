using System;
using System.Threading;
using System.Threading.Tasks;
using ahj.ashish.reactivities.Domain;
using ahj.ashish.reactivities.Persistence;
using MediatR;

namespace ahj.ashish.reactivities.Application.Activities
{
    public class Create
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
            public DateTime Date { get; set; }
            public string City { get; set; }
            public string Venue { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = new Activity {
                    Id = request.Id,
                    Title = request.Title,
                    Category = request.Category,
                    Venue = request.Venue,
                    Description = request.Description,
                    Date = request.Date,
                    City = request.City
                };

                await _context.Activities.AddAsync(activity);
                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}