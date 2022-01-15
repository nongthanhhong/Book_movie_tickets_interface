using System;
using System.Collections.Generic;
using System.Text;

namespace Book_movie_tickets.Model
{
    public class Movies
    {
        public int ID { get; set; } //Id Phim
        public string Title { get; set; } //ten phim
        public string Poster { get; set; } // hinh anh
        public string Description { get; set; } //Gioi thieu
        public string Showday { get; set; } //ngay chieu
        public string Rating { get; set; } //diem danh gia tren 10
        public string Length { get; set; } // Do dai bo phim
        public string Trailer { get; set; } //link trailer on youtube 
        public string Director { get; set; } //Dao dien
        public string Language { get; set; } //Ngon ngu
        public string Genre { get; set; } //the loai
        public int Price { get; set; } //gia ve
    }
}
