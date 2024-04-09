using HHPWsBe.DTOs;

namespace HHPWsBe.APIs
{
    public class UsersAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapPost("/checkuser", (HHPWsDbContext db, UserDTO userAuthDto) => {
                var userUid = db.Users.SingleOrDefault(user => user.Uid == userAuthDto.Uid);

                if (userUid == null)
                {
                    return Results.NotFound();
                }
                else
                {
                    return Results.Ok(userUid);
                }
            });
        }
    }
}
