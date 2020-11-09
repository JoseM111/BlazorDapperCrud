using System;

namespace BlazerDapperCrud.Data 
{
    public class VideoModel {
        ///∆: - ©-PROPERTIES
        //∆..............................
        public int VideoID { get; set; }
        public string Title { get; set; }
        public DateTime DatePublished { get; set; }
        public bool IsActive { get; set; }
        //∆..............................
    }
}