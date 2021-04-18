using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ProductReviewManagement
{
    public class Management
    {
       // public readonly DataTable dataTable = new DataTable();
        public void TopRecords(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReviews in listProductReview
                                orderby productReviews.Rating descending
                                select productReviews).Take(3);

           
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID:- " + list.ProducID + " " + "UserID:- " + list.UserID
                   + " " + "Rating:- " + list.Rating + " " + "Review:- " + list.Review + " " + "isLike:- " + list.isLike);

            }

        }

        public void SelectedRecords(List<ProductReview> listProductReview)
        {
            var recordData = (from productReview in listProductReview
                              where( productReview.ProducID ==1 || productReview.ProducID ==4 || productReview.ProducID ==9)
                              && productReview.Rating > 3
                              select productReview
                              );
            foreach (var list in recordData)
            {
                Console.WriteLine("ProductID:- " + list.ProducID + " " + "UserID:- " + list.UserID
                   + " " + "Rating:- " + list.Rating + " " + "Review:- " + list.Review + " " + "isLike:- " + list.isLike);
            }
        }

        public void CountOfRecords(List<ProductReview> listProductReview)
        {
        var recordData = listProductReview.GroupBy(x => x.ProducID).Select(x => new { ProductID = x.Key, Count = x.Count() });
            foreach (var list in recordData)
            {
                Console.WriteLine(list.ProductID+"--->"+list.Count);
            }
        }

        public void SelectProductId(List<ProductReview> productReviewList)
        {
            var recordData = (from productReview in productReviewList
                              select new { productReview.ProducID, productReview.Review });
            foreach (var list in recordData)
            {
                Console.WriteLine("ProductId:"+list.ProducID+"Review:"+list.Review);
            }
        
        }
    }
}