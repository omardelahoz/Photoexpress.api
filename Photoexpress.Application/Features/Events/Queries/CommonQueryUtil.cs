using Photoexpress.Domain.Entities;

namespace Photoexpress.Application.Features.Events.Queries
{
    internal class CommonQueryUtil
    {
        public static Func<IQueryable<Event>, IOrderedQueryable<Event>> GetOrderBy(string orderBy, bool ascendent)
        {
            Func<IQueryable<Event>, IOrderedQueryable<Event>>? response = null;

            if (ascendent)
            {
                switch (orderBy.ToLower())
                {
                    case "institutionname":
                        {
                            response = x => x.OrderBy(x => x.InstitutionName);
                            break;
                        }
                    case "numstudents":
                        {
                            response = x => x.OrderBy(x => x.NumStudents);
                            break;
                        }
                    default:
                        {
                            response = x => x.OrderBy(x => x.StartTime);
                            break;
                        }
                }
            }
            else
            {
                switch (orderBy.ToLower())
                {
                    case "institutionname":
                        {
                            response = x => x.OrderByDescending(x => x.InstitutionName);
                            break;
                        }
                    case "numstudents":
                        {
                            response = x => x.OrderByDescending(x => x.NumStudents);
                            break;
                        }
                    default:
                        {
                            response = x => x.OrderByDescending(x => x.StartTime);
                            break;
                        }
                }
            }

            return response;
        }
    }
}
