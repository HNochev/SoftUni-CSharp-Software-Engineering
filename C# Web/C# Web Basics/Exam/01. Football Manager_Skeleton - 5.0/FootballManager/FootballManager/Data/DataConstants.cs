
namespace FootballManager.Data
{
    public class DataConstants
    {
        public const int IdMaxLength = 40;

        public const int UserUsernameMinLength = 5;
        public const int UserUsernameMaxLength = 20;
        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        public const int UserEmailMin = 10;
        public const int UserEmailMax = 60;
        public const int UserPasswordMin = 5;
        public const int UserPasswordMax = 20;

        public const int PlayerFullnameMinLength = 5;
        public const int PlayerFullnameMaxLength = 80;
        public const int PlayerPositionMinLength = 5;
        public const int PlayerPositionMaxLength = 20;
        public const int PlayerSpeedMin = 0;
        public const int PlayerSpeedMax = 10;
        public const byte PlayerEnduranceMin = 0;
        public const byte PlayerEnduranceMax = 10;
        public const int PlayerDescriptionMaxLength = 200;

        public const string PlayerGoalkeeper = "Goalkeeper";
        public const string PlayerRFullback = "Right Fullback";
        public const string PlayerLFullback = "Left Fullback";
        public const string PlayerCBack = "Center Back";
        public const string PlayerDefender = "Defender";
        public const string PlayerStriker = "Striker";
        public const string PlayerWinger = "Winger";
    }
}
