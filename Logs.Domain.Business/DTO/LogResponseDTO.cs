using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Logs.Domain.Business.DTO
{
    public class LogResponseDTO
    {
        public string Pk { get; set; } = default!;
        public string App { get; set; } = default!;
        public string User { get; set; } = default!;
        public DateTime DateRegister { get; set; } = default!;
        public string IPAddress { get; set; } = default!;
        public string Url { get; set; } = default!;
        public string Event { get; set; } = default!;
        public int Status { get; set; } = default!;
        public string Error { get; set; } = default!;
    }
}