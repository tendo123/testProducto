using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace pract01.Models
{
    [Table("t_producto")]
    public class VideoGame
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("categoria")]
        public string Categoria { get; set; }
        [Column("precio")]
        public double Precio {get; set;}
        [Column("descuento")]
        public double Descuento {get; set; }     

    }
}