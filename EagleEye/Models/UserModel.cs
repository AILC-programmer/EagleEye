namespace EagleEye.Models;

public class UserModel
{
    public string Username { get; set; } = "User";
    public int TotalScores { get; set; } = 0;

    // Game played count
    
    public int TotalGamePlayed { get; set; } // Total game played, no matter which game
    public int TotalRememberColorGamePlayed { get; set; } // Total game played, Remember Color game only

    //
}
