namespace ForumSystem.Common
{
    public class GlobalConstants
    {
        public const string SystemName = "ForumSystem";
        public const string SystemEmail = "no-reply@ForumSystem.net";

        public const string AdministratorAreaName = "Administration";
        public const string AdministratorRoleName = "Admin";
        public const string AdministratorUserName = "Admin";
        public const string AdministratorEmail = "admin@ForumSystem.net";
        public const string AdministratorPassword = "admin12345678";
        public const string AdministratorProfilePicture = "#icon-ava-a";

        public const string TestUserUserName = "testuser";
        public const string TestUserEmail = "testuser@ForumSystem.net";
        public const string TestUserPassword = "user12345678";
        public const string TestUserProfilePicture = "#icon-ava-t";

        public const string DateTimeFormat = "dd/MM/yy HH:mm";
        public const string DateTimeShortFormat = "dd/MM/yy";

        public const string IFrameTag = "iframe";
        public const string AllowedFileExtensions = "jpg,jpeg,png";

        public const string UserUsernameDisplayName = "Display name";
        public const string UserLoginRememberMeDisplayName = "Remember me";
        public const string UserCurrentPasswordDisplayName = "Current password";
        public const string UserNewPasswordDisplayName = "New password";
        public const string UserConfirmPasswordDisplayName = "Confirm password";
        public const string UserConfirmNewPasswordDisplayName = "Confirm new password";
        public const string UserNewEmailDisplayName = "New email";
        public const string UserBirthDateDisplayName = "Birthday";
        public const string UserGenderDisplayName = "Gender";
        public const int UserUsernameMaxLength = 30;
        public const int UserUsernameMinLength = 4;
        public const int UserPasswordMaxLength = 100;
        public const int UserPasswordMinLength = 8;
        public const int UserBiographyMaxLength = 500;
        public const int UserMinAge = 18;

        public const int TagNameMaxLength = 20;
        public const int TagNameMinLength = 4;
        public const string TagsDisplayName = "Tags";

        public const int CategoryNameMaxLength = 50;
        public const int CategoryNameMinLength = 4;

        public const int MessageContentMaxLength = 300;

        public const int PostTitleMaxLength = 100;
        public const int PostTitleMinLength = 4;
        public const int PostDescriptionMaxLength = 30000;
        public const int PostReportDescriptionMaxLength = 30000;
        public const int PostReportDescriptionMinLength = 4;
        public const string PostTypeDisplayName = "Post Type";


        public const int ReplyDescriptionMaxLength = 30000;
        public const int ReplyReportDescriptionMaxLength = 30000;
        public const int ReplyReportDescriptionMinLength = 4;

        public const int ShortDescriptionAllowedLength = 50;
    }
}
