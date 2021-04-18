using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ProductReviewManagement
{
    public class Management
    {
        public readonly DataTable table = new DataTable();
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
                              where (productReview.ProducID == 1 || productReview.ProducID == 4 || productReview.ProducID == 9)
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
                Console.WriteLine(list.ProductID + "--->" + list.Count);
            }
        }

        public void SelectProductId(List<ProductReview> productReviewList)
        {
            var recordData = (from productReview in productReviewList
                              select new { productReview.ProducID, productReview.Review });
            foreach (var list in recordData)
            {
                Console.WriteLine("ProductId:" + list.ProducID + "Review:" + list.Review);
            }

        }

        public void SkipTopRecords(List<ProductReview> productReviewList)
        {
            var recordData = (from productReview in productReviewList
                              select productReview).Skip(5);
            foreach (var list in recordData)
            {
                Console.WriteLine("ProductID:- " + list.ProducID + " " + "UserID:- " + list.UserID
                       + " " + "Rating:- " + list.Rating + " " + "Review:- " + list.Review + " " + "isLike:- " + list.isLike);
            }
        }
        
        public void AddToDataTable(List<ProductReview> productReviewList)
        {
            //DataTable table = new DataTable();
            table.Columns.Add("ProductID");
            table.Columns.Add("UserID");
            table.Columns.Add("Rating");
            table.Columns.Add("Review");
            table.Columns.Add("isLike");

            table.Rows.Add("1", "1", "2","Good","true");
            table.Rows.Add("2", "1", "4", "Good", "true");
            table.Rows.Add("3", "1", "5", "Good", "true");
            table.Rows.Add("4", "1", "6", "Good", "false");
            table.Rows.Add("5", "1", "2", "nice", "true");
            table.Rows.Add("6", "1", "1", "bad", "true");
            table.Rows.Add("8", "1", "1", "Good", "false");
            table.Rows.Add("8", "1", "9", "Nice", "true");
            table.Rows.Add("2", "1", "10", "Nice", "true");
            table.Rows.Add("10", "1", "8", "Nice", "true");
            table.Rows.Add("11", "1", "3", "Nice", "true");
            table.Rows.Add("10", "1", "9", "Nice", "true");
            table.Rows.Add("11", "1", "3", "Good", "true");
            table.Rows.Add("12", "1", "1", "Bad", "false");
            table.Rows.Add("13", "1", "4", "Good", "true");
            table.Rows.Add("13", "1", "5", "Nice", "true");
            table.Rows.Add("14", "1", "6", "Good", "true");
            table.Rows.Add("15", "1", "9", "Nice", "true");
            table.Rows.Add("16", "1", "1", "Bad", "false");
            table.Rows.Add("16", "1", "1", "Bad","false");
            table.Rows.Add("17", "1", "10", "Nice", "true");
            table.Rows.Add("18", "1", "8", "nice", "true");
            table.Rows.Add("3", "1", "10", "nice", "true");
            table.Rows.Add("5", "1", "8", "nice", "true");
            table.Rows.Add("6", "1", "3", "nice", "true");
            Console.WriteLine("Data Added To Data Table Successfully.......");
            //DisplayDataTable(table);

        }

        public void RetriveFromDataTable()
        {
            var recordData = (from rows in table.AsEnumerable()
                 where rows.Field<string>("isLike") == "true"
                 select rows);
            foreach (DataRow row in recordData)
            {
                Console.WriteLine("ProductId:{0},UserId:{1},Rating:{2},Review:{3},isLike:{4}", row["ProductId"], row["UserId"], row["Rating"], row["Review"], row["isLike"]);
            }
        }

        public void DisplayDataTable(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                
                Console.WriteLine("ProductId:{0},UserId:{1},Rating:{2},Review:{3},isLike:{4}",row["ProductId"],row["UserId"],row["Rating"],row["Review"],row["isLike"]);
            }
            Console.ReadKey();
        }
    }
}