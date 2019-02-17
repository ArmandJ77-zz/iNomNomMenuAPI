using AutoMapper;
using Domain.Health.DTO;
using Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Threading.Tasks;

namespace Domain.Health.Handlers
{
    public class HealthCheckHandler: BaseHandler, IHealthCheckHandler
    {
        public HealthCheckHandler(IMapper autoMapper, MenuContext context) : base(autoMapper, context)
        {
        }

        public async Task<HealthDto> ExecuteAsync()
        {
            try
            {
                var foo = await Context.Menus.ToListAsync();

                return new HealthDto(){CanAccessDb = true};
            }
            catch (Exception e)
            {
                return new HealthDto() {CanAccessDb = false};
            }
            
        }
    }

    public interface IHealthCheckHandler
    {
        Task<HealthDto> ExecuteAsync();
    }
}
