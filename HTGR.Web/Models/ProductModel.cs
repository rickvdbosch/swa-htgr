namespace HTGR.Web.Models
{
    public class ProductResult
    {
        public ProductModel[] value { get; set; }
        public string nextLink { get; set; }
    }

    public class ProductModel
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string Color { get; set; }
        public float StandardCost { get; set; }
        public float ListPrice { get; set; }
        public string Size { get; set; }
        public float? Weight { get; set; }
        public int ProductCategoryID { get; set; }
        public int ProductModelID { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime? SellEndDate { get; set; }
        public object DiscontinuedDate { get; set; }
        public string ThumbNailPhoto { get; set; }
        public string ThumbnailPhotoFileName { get; set; }
        public string rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
