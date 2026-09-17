namespace Galasy.Pedidos.Entities;


public partial class MaestroDetalle: BaseEntity
{

    public int IdMaestro { get; set; }

    public string Codigo { get; set; } = null!;

    public string Valor { get; set; } = null!;
    
    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual Maestro IdMaestroNavigation { get; set; } = null!;

    public virtual ICollection<Producto> ProductoIdCategoriaMaeNavigations { get; set; } = new List<Producto>();

    public virtual ICollection<Producto> ProductoIdMarcaMaeNavigations { get; set; } = new List<Producto>();
}
