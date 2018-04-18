using Microsoft.EntityFrameworkCore;
using Middleware.Repository.Context;
using Middleware.Repository.Interface;
using Middleware.Repository.Model;
using System;
using System.Threading.Tasks;

namespace Middleware.Repository
{
    public class LogRepository : ILogRepository
    {
        public async Task GravarAsync(string Mesangem)
        {
            try
            {
                var options = new DbContextOptionsBuilder<LogContext>();
                options.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=Middleware.Database;User=sa;Password=Wolters@102030");
                using (var context = new LogContext(options))
                {
                    context.Add(new Log
                    {
                        Mensagem = Mesangem
                    });

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}