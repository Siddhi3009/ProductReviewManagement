using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
namespace ProductReviewManagement
{
    class Management
    {
        //Datatable for product records
        public readonly DataTable dataTable = new DataTable();
        /// <summary>
        /// Top rated 3 products are selected from list
        /// </summary>
        /// <param name="listProductReview"></param>
        public void TopRecords(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReviews in listProductReview
                                orderby productReviews.Rating descending
                                select productReviews).Take(3);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID: " + list.ProductId + "UserId: " + list.UserId + "Rating: " + list.Rating
                    + "Review: " + list.Review + "IsLike: " + list.IsLike);
            }
        }
        /// <summary>
        /// Select specific records with id = 1, 4, 9 and rating > 3
        /// </summary>
        /// <param name="listProductReview"></param>
        public void SelectRecords(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReviews in listProductReview
                                where (productReviews.ProductId == 1 || productReviews.ProductId == 4 || productReviews.ProductId == 9)
                                && productReviews.Rating > 3
                                select productReviews);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID: " + list.ProductId + "UserId: " + list.UserId + "Rating: " + list.Rating
                    + "Review: " + list.Review + "IsLike: " + list.IsLike);
            }
        }
        /// <summary>
        /// Counts products by product id
        /// </summary>
        /// <param name="listProductReview"></param>
        public void RetrieveCountOfRecords(List<ProductReview> listProductReview)
        {
            var recordedData = listProductReview.GroupBy(x => x.ProductId).Select(x => new { ProductId = x.Key, Count = x.Count() });
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductId + "------" + list.Count);
            }
        }
        /// <summary>
        /// Retrieves product id and review of products
        /// </summary>
        /// <param name="listProductReview"></param>
        public void RetrieveProductIdAndReview(List<ProductReview> listProductReview)
        {
            var recordedData = from productReviews in listProductReview
                               select new
                               {
                                   productReviews.ProductId,
                                   productReviews.Review
                               };
            foreach (var list in recordedData)
            {
                Console.WriteLine("Product Id:- " + list.ProductId + " " + "Review: " + list.Review);
            }
        }
        /// <summary>
        /// Retrieves products from list by skipping top 5 records
        /// </summary>
        /// <param name="listProductReview"></param>
        public void RetrieveProductsBySkippingTop5(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReviews in listProductReview
                                select productReviews).Skip(5);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID: " + list.ProductId + "UserId: " + list.UserId + "Rating: " + list.Rating
                    + "Review: " + list.Review + "IsLike: " + list.IsLike);
            }
        }
        /// <summary>
        /// Adds data to the DataTable
        /// </summary>
        /// <param name="listProductReviews"></param>
        public void AddToDataTableDemo(List<ProductReview> listProductReviews)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ProductId");
            table.Columns.Add("UserId");
            table.Columns.Add("Rating");
            table.Columns.Add("Review");
            table.Columns.Add("IsLike");
            foreach (ProductReview product in listProductReviews)
            {
                table.Rows.Add(product.ProductId, product.UserId, product.Rating, product.Review, product.IsLike);
            }
        }
    }
}
