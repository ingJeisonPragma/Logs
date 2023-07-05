using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Logs.Domain.Business.DTO
{
    public class LogRequestDTO
    {
        [Required]
        public string App { get; set; } = default!;

        [Display(Name = "User")]
        public string User { get; set; } = default!;

        [Required]
        [Display(Name = "DateRegister")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime DateRegister { get; set; } = default!;

        [Display(Name = "IPAddress")]
        [RegularExpression(@"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$", ErrorMessage = "El campo {0} no es valida.")]
        [MaxLength(20, ErrorMessage = "El campo {0} es obligatorio.")]
        public string IPAddress { get; set; } = default!;

        [RegularExpression(@"((([A-Za-z]{3,9}:(?:\/\/)?)(?:[-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+|(?:www.|[-;:&=\+\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w-_]*)?\??(?:[-\+=&;%@.\w_]*)#?(?:[\w]*))?)", ErrorMessage = "La {0} no es valida.")]
        public string Url { get; set; } = default!;

        [Display(Name = "Event")]
        public string Event { get; set; } = default!;

        [Display(Name = "Event")]
        public int Status { get; set; } = default!;

        [Required]
        [Display(Name = "Event")]
        public string Error { get; set; } = default!;
    }
}