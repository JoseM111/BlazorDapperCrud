using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;

/** <CRUD METHODS>:
••••••••••••••••••••••••••••••••••••••••••••••••••••••••••
<TYPES>:
    • CREATE
    • READ
    • UPDATE
    • DELETE
••••••••••••••••••••••••••••••••••••••••••••••••••••••••••*/
namespace BlazerDapperCrud.Data 
{
    public class VideoService : IVideoService {
        ///∆: - ©-PROPERTIES
        //∆..............................
        private readonly MySqlConnectConfig _configuration;
        //∆..............................
        
        ///∆ ............. Constructor .............
        public VideoService(MySqlConnectConfig configuration) 
            => _configuration = configuration;
        
        //∆ ______________________________________________________
        ///∆ : -(CREATE) a video row-->(SQL INSERT)
        public async Task<bool> InsertVideo(VideoModel video) {
            //∆..........    
            await using var connection = new SqlConnection(_configuration.Value);
            //∆ : -Dapper API
            var parameters = new DynamicParameters();/*<-- USED HERE*/

            parameters.Add(name: "Title", value: video.Title, dbType: DbType.String);
            parameters.Add(name: "DatePublished", value: video.DatePublished, dbType: DbType.Date);
            parameters.Add(name: "IsActive", value: video.IsActive, dbType: DbType.Boolean);

            const string query = @"INSERT INTO 
                                   VideoTable (Title, DatePublished, IsActive)
                                   VALUES (@Title, @DatePublished, @IsActive)";

            await connection.ExecuteAsync(
                sql: query,
                param: new {video.Title, video.DatePublished, video.IsActive},
                commandType: CommandType.Text
            );
            
            return true;
        }
        //∆ ______________________________________________________
    }// ∆ END VideoService

}