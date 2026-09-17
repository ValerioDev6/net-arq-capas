using System.ComponentModel.DataAnnotations;
using Galasy.Pedidos.Common.Contasnts;

namespace Galasy.Pedidos.DTO.Request.Cliente;

public class ClienteRequest
{
    [Required(ErrorMessage = ErrorMessages.RequiredMessage)]
    [Display(Name = "Razón social")]
    public string RazonSocial { get; set; } = null!;

    [Required(ErrorMessage = ErrorMessages.RequiredMessage)]
    [Display(Name = "Tipo de documento")]
    public string? TipoDocumento { get; set; }

    [Display(Name = "Número de documento")]
    public string? NumeroDocumento { get; set; }

    [Required(ErrorMessage = ErrorMessages.RequiredMessage)]
    [Display(Name = "Contacto")]
    public string Contacto { get; set; } = null!;

    [Required(ErrorMessage = ErrorMessages.RequiredMessage)]
    [Display(Name = "Dirección")]
    public string Direccion { get; set; } = null!;

    [Required(ErrorMessage = ErrorMessages.RequiredMessage)]
    [EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido")]
    [Display(Name = "Correo electrónico")]
    public string CorreoElectronico { get; set; } = null!;

    [Display(Name = "Celular")]
    public string? Celular { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Seleccione un rubro")]
    [Display(Name = "Rubro")]
    public int IdRubroMae { get; set; }

}
