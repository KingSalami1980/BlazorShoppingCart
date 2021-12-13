﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataModels.CustomModels
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "*Product Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "*Product Price is Required")]
        public int? Price { get; set; }
        [Required(ErrorMessage = "*Product Stock is Required")]
        public int? Stock { get; set; }
        [Required(ErrorMessage = "*Product Category is Required")]
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "*Kindly Upload Product Photo")]
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
        public bool CartFlag { get; set; }
    }
}
