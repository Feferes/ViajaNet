using System;

namespace Middleware.Repository.Model
{
    public class Log
    {
        public int Id { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}
