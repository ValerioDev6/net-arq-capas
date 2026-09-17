using System.ComponentModel.DataAnnotations;
using Galasy.Pedidos.Common.Contasnts;

namespace Galasy.Pedidos.DTO.Request.Producto;

public class ProductoRequest
{
    [Required(ErrorMessage = ErrorMessages.RequiredMessage)]
    [Display(Name = "Nombre")]
    public string Nombre { get; set; } = null!;

    [Display(Name = "Descripción")]
    public string? Descripcion { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Seleccione una marca")]
    [Display(Name = "Marca")]
    public int IdMarcaMae { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Seleccione una categoría")]
    [Display(Name = "Categoría")]
    public int IdCategoriaMae { get; set; }

    [Required(ErrorMessage = ErrorMessages.RequiredMessage)]
    [Range(0.01, double.MaxValue, ErrorMessage = "Ingrese un precio válido")]
    [Display(Name = "Precio unitario")]
    public decimal PrecioUnitario { get; set; }

    [Required(ErrorMessage = ErrorMessages.RequiredMessage)]
    [Range(0, int.MaxValue, ErrorMessage = "Ingrese un stock válido")]
    [Display(Name = "Stock")]
    public int Stock { get; set; }
}
