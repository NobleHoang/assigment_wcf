using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace baseNetApi.models;

public class Products
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    public string name { get; set; } = "";
    public int quantity { get; set; } = 1;
    public string price { get; set; }
    public string thubnail { get; set; } = "";
    public string description { get; set; } = "";
    public ProductStatus status { get; set; } = ProductStatus.INACTIVE;
    public int category_id { get; set; } = 1;
}