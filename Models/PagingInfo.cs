using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPizza.Models
{
    public class PagingInfo
    {
        public int TotalItems { get; set; } //Количество товаров
        public int ItemsPerPage { get; set; } //количество товаров на одной странице
        public int CurrentPage { get; set; } //текущая страница
        public int TotalPages //общее количество страниц
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }
    }
}