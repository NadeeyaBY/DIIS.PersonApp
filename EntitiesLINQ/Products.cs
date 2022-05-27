﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DIIS.PersonApp.EntitiesLINQ
{
    [Table("PRODUCTS")]
    [Index("CategoryId", Name = "IDX_PRODUCTS_CATEGORY_ID")]
    [Index("SupplierId", Name = "IDX_PRODUCTS_SUPPLIER_ID")]
    public partial class Products
    {
        [Key]
        [Column("PRODUCT_ID")]
        [Precision(9)]
        public int ProductId { get; set; }
        [Required]
        [Column("PRODUCT_NAME")]
        [StringLength(40)]
        [Unicode(false)]
        public string ProductName { get; set; }
        [Column("SUPPLIER_ID")]
        [Precision(9)]
        public int SupplierId { get; set; }
        [Column("CATEGORY_ID")]
        [Precision(9)]
        public int CategoryId { get; set; }
        [Column("QUANTITY_PER_UNIT")]
        [StringLength(20)]
        [Unicode(false)]
        public string QuantityPerUnit { get; set; }
        [Column("UNIT_PRICE", TypeName = "NUMBER(10,2)")]
        public decimal UnitPrice { get; set; }
        [Column("UNITS_IN_STOCK")]
        [Precision(9)]
        public int UnitsInStock { get; set; }
        [Column("UNITS_ON_ORDER")]
        [Precision(9)]
        public int UnitsOnOrder { get; set; }
        [Column("REORDER_LEVEL")]
        [Precision(9)]
        public int ReorderLevel { get; set; }
        [Required]
        [Column("DISCONTINUED")]
        [StringLength(1)]
        [Unicode(false)]
        public string Discontinued { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("Products")]
        public virtual Categories Category { get; set; }
        [ForeignKey("SupplierId")]
        [InverseProperty("Products")]
        public virtual Suppliers Supplier { get; set; }
    }
}