using System.Threading.Tasks;

namespace BlazerDapperCrud.Data 
{
    public interface IVideoService {
        //∆..........
        ///∆ : -(CREATE) a video row-->(SQL INSERT)
        Task<bool> InsertVideo(VideoModel video);
    }
}