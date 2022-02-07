CREATE PROCEDURE [dbo].[DeleteUser]
    @userId int
AS
    DELETE [UserProfiles] WHERE [UserProfiles].UserId = @userId;
